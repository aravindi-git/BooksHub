using BooksHub.Models;
using BooksHub.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BooksHub.Services.Services
{
    public class ServiceHelper : IServiceHelper
    {

        private readonly ILogger logger;
        public ServiceHelper(ILogger<ServiceHelper> logger)
        {
            this.logger = logger;

        }
        public ServiceResponse<T> InitializeSrvResponse<T>() where T : class
        {

            var srvResponse = new ServiceResponse<T>()
            {
                IsSuccess = false,
                Error = null,
                CorrelationId = string.Empty
            };

            return srvResponse;
        }

        public ServiceResponse<T> SetFailureResponse<T>(Exception ex, ServiceResponse<T> srvResponse, object data) where T : class
        {
            srvResponse.IsSuccess = false;
            srvResponse.Error = new ErrorMsg()
            {
                Message = ex.Message,
                Id = Guid.NewGuid().ToString()
            };
            srvResponse.CorrelationId = Guid.NewGuid().ToString();

            if (data != null)
            {
                logger.LogError(ex, "ID: {id}, Error Message: {message}, Payload: {payload}", srvResponse.Error.Id, srvResponse.Error.Message, JsonSerializer.Serialize(data));
            }
            else
            {
                logger.LogError(ex, "ID: {id}, Error Message: {message}", srvResponse.Error.Id, srvResponse.Error.Message);
            }


            return srvResponse;
        }

        public ServiceResponse<T> SetSuccessResponse<T>(T data, ServiceResponse<T> srvResponse) where T : class
        {
            srvResponse.IsSuccess = true;
            srvResponse.Data = data;

            return srvResponse;
        }
    }
}
