using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static Article.Core.Components.Enums;

namespace Article.Core.Model
{
    public class ApiResponse
    {
        public bool HasError { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; set; }
        public int StatusCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        public ApiResponse()
        {
            HasError = false;
            Data = null;
            StatusCode = 200;
            ErrorMessage = null;
        }

        public ApiResponse(dynamic resposeData)
        {
            HasError = false;
            Data = resposeData;
            StatusCode = 200;
            ErrorMessage = null;
        }

        public ApiResponse(Error error)
        {
            HasError = true;
            StatusCode = (int)error;
            ErrorMessage = error.ToString();
        }
    }
}
