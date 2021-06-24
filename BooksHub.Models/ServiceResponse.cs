using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksHub.Models
{
    public interface IServiceResponse
    {
        bool IsSuccess { get; set; }
        string Status { get; set; }
        ErrorMsg Error { get; set; }
        string CorrelationId { get; set; }
    }
    public class ServiceResponse<T> : IServiceResponse
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set ; }
        public string Status { get; set; }
        public ErrorMsg Error { get; set; }
        public string CorrelationId { get; set; }
    }

    public class ErrorMsg
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("error")]
        public string Message { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
