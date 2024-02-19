using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.DTO
{
    public class MessageResponse
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public List<Error> Errors { get; set; }

        public MessageResponse(bool isSuccess, string? Message)
        {
            IsSuccess = isSuccess;
            Message = Message;
        }

        public MessageResponse(bool isSuccess, int code, string? Message)
        {
            IsSuccess = isSuccess;
            Code = code;
            Message = Message;
        }

        public MessageResponse(bool isSuccess, int code, string? message, object data)
        {
            IsSuccess = isSuccess;
            Code = code;
            Message = message;
            Data = data;
        }

        public MessageResponse(bool isSuccess, int code, string? Message, List<Error> errors)
        {
            IsSuccess = isSuccess;
            Code = code;
            Message = Message;
            Errors = errors;
        }
    }

    public class Error
    {
        public string? Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
    }
}
