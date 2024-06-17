using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Shared.Response
{
    public class DefaultResponse
    {
        public DefaultResponse() { }
        public DefaultResponse(bool sucess, string message, object data)
        {
            Success = sucess;
            Message = message;  
            Data = data;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
