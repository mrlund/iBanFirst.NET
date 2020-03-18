using iBanFirst.NET.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace iBanFirst.NET
{
    public class iBanFirstApiResponse<T> where T : class
    {
        private ErrorResponse _errorResponse { get; set; }

        public bool IsSuccessStatusCode { get; set; }
        public T Result { get; set; }

        public iBanFirstApiResponse()
        {
            IsSuccessStatusCode = false;
        }

        public iBanFirstApiResponse(ErrorResponse error)
        {
            IsSuccessStatusCode = false;
            _errorResponse = error;
        }

        public iBanFirstApiResponse(T source)
        {
            Result = source;
            IsSuccessStatusCode = true;
        }

        public ErrorResponse GetError()
        {
            return _errorResponse;
        }


    }
}
