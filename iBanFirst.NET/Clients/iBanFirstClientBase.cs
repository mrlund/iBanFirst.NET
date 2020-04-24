using iBanFirst.NET.Entities;
using iBanFirst.NET.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace iBanFirst.NET.Clients
{
    public abstract class iBanFirstClientBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _userName;
        private readonly string _clientSecret;
        private readonly JsonSerializer _jsonSerializer;
        private readonly JsonSerializerSettings _jsonSettings;
        protected readonly ILogger _logger;

        public iBanFirstClientBase(HttpClient httpClient, string userName = null, string clientSecret = null, ILoggerFactory loggerFactory = null)
        {
            _httpClient = httpClient ?? throw new NullReferenceException(nameof(httpClient));
            _userName = userName;
            _clientSecret = clientSecret;
            _jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            _jsonSerializer = new JsonSerializer()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            if (loggerFactory != null)
            {
                _logger = loggerFactory.CreateLogger(this.GetType());
            }
        }

        protected void SetBaseUri(string baseUri)
        {
            _httpClient.BaseAddress = new Uri(baseUri);
        }
        private string GenerateAccessToken()
        {
            var nonce = GenerateRandomHexString(32);
            var nonceBytes = Encoding.ASCII.GetBytes(nonce);
            var base64Nonce = Convert.ToBase64String(nonceBytes);

            var timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

            var sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(nonce + timeStamp + _clientSecret);
            byte[] hash = sha1.ComputeHash(inputBytes);
            var token = Convert.ToBase64String(hash);
            var header = string.Format("UsernameToken Username=\"{0}\", PasswordDigest=\"{1}\", Nonce=\"{2}\", Created=\"{3}\"", _userName, token, base64Nonce, timeStamp);
            return header;
        }
        public async Task<iBanFirstApiResponse<T>> MakeApiRequest<T>(string urlPath, RequestMethod method = RequestMethod.GET, object requestObject = null) where T : class
        {
            using (var req = await _httpClient.SendAsync(CreateRequest(urlPath, method, requestObject)))
            {
                if (req.IsSuccessStatusCode)
                {
                    return new iBanFirstApiResponse<T>(DeserializeAndUnwrap<T>(await req.Content.ReadAsStringAsync()));
                }

                return new iBanFirstApiResponse<T>(await HandleError(req));
            }

        }
        private HttpRequestMessage CreateRequest(string urlPath, RequestMethod method = RequestMethod.GET, object requestObject = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method.ToString()), urlPath);
            request.Headers.Add("X-WSSE", GenerateAccessToken());
            if (requestObject != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(requestObject, _jsonSettings), Encoding.UTF8, "application/json");
            }
            return request;
        }
        private async Task<ErrorResponse> HandleError(HttpResponseMessage request)
        {
            var errorString = await request.Content.ReadAsStringAsync();
            if (_logger != null)
            {
                _logger.LogError(errorString);
            }
            if (string.IsNullOrEmpty(errorString) || request.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new ErrorResponse() { ErrorCode = (int)request.StatusCode, ErrorMessage = request.ReasonPhrase };
            }
            var token = JToken.Parse(errorString);
            if (token is JArray)
            {
                return token["Error"].ToObject<List<ErrorResponse>>(_jsonSerializer).FirstOrDefault();
                //return JsonConvert.DeserializeObject<List<ErrorResponse>>(errorString, _jsonSettings).FirstOrDefault();
            }
            else
            {
                return token["Error"].ToObject<ErrorResponse>(_jsonSerializer);
            }

        }

        private T DeserializeAndUnwrap<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            var jObject = JObject.Parse(json);
            var results = jObject.Children().First().First().ToObject<T>(_jsonSerializer);
            return results;
            //if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            //{
            //    //return JsonConvert.DeserializeObject<T>(json);
            //}
            //return jObject.ToObject<T>(_jsonSerializer);
        }

        private string GenerateRandomHexString(int digits)
        {
            var byteArray = new byte[(int)Math.Ceiling(digits / 2.0)];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byteArray);
            }
            return String.Concat(Array.ConvertAll(byteArray, x => x.ToString("X2"))).ToLower();
        }
        private byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }

}
