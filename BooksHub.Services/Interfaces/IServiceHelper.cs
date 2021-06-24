using BooksHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksHub.Services.Interfaces
{
    public interface IServiceHelper
    {
        ServiceResponse<T> InitializeSrvResponse<T>() where T : class;
        ServiceResponse<T> SetSuccessResponse<T>(T data, ServiceResponse<T> srvResponse) where T : class;
        ServiceResponse<T> SetFailureResponse<T>(Exception ex, ServiceResponse<T> srvResponse, object data) where T : class;
    }
}
