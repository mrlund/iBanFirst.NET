using iBanFirst.NET.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iBanFirst.NET.Tests
{
    public class FakeHttpMessageHandler<T> : HttpMessageHandler
    {
        private bool _isError;
        private object source;
        public FakeHttpMessageHandler(bool isError = false, string responseContentString = null)
        {
            _isError = isError;

            if (!string.IsNullOrEmpty(responseContentString))
            {
                source = JsonConvert.DeserializeObject(responseContentString);
            }
            else if (isError)
            {
                source = JObject.FromObject(new ErrorResponse() { message = "Something went wrong!" });
            }
            else if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            {
                var list = new List<object>() { Activator.CreateInstance(typeof(T).GetGenericArguments()[0]) };
                source = JArray.FromObject(list);
            }
            else
            {
                source = JToken.FromObject(Activator.CreateInstance<T>());
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(_isError ? HttpStatusCode.BadRequest : HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { rootObj = source }))
            };

            return await Task.FromResult(responseMessage);
        }
    }
}
