using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Gerenciamento.Utils.Response
{
    public class ResponseObject
    {
        [DataMember()]
        public bool Success { get; set; }

        [DataMember()]
        public String Message { get; set; }

        [DataMember()]
        public dynamic Data { get; set; }

        public static ResponseObject ErrorResponse(dynamic data, string message = "")
        {
            var responseObject = new ResponseObject();
            responseObject.Success = false;
            responseObject.Message = message;
            responseObject.Data = data;
            return responseObject;
        }

        public static ResponseObject ErrorResponse(string message = null)
        {
            var responseObject = new ResponseObject();
            responseObject.Success = false;
            responseObject.Message = message;
            return responseObject;
        }

        public static ResponseObject SuccessResponse(dynamic data, string message = "")
        {
            var responseObject = new ResponseObject();
            responseObject.Success = true;
            responseObject.Message = message;
            responseObject.Data = data;
            return responseObject;
        }

        public static ResponseObject SuccessResponse(string message = "")
        {
            var responseObject = new ResponseObject();
            responseObject.Success = true;
            responseObject.Message = message;
            return responseObject;
        }



    }
}
