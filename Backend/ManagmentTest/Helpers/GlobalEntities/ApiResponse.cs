using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Helpers.GlobalEntities
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int Status { get; set; }

        public ApiResponse()
        {
            Status = (int)ApiStatusCode.TransactionSuccess;
            Message = "Success";
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public ApiResponse(string _message)
        {
            Message = _message;
        }

        public ApiResponse(string _message, int _status)
        {
            Message = _message;
            Status = _status;
        }
    }

    [DataContract]
    public class ApiResponse<T> : ApiResponse
    {
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public T Data { get; set; }

        public ApiResponse()
        {
            Status = (int)ApiStatusCode.TransactionSuccess;
            ;
            Message = "Success";
        }

        public ApiResponse(string _message) : base(_message)
        {
        }

        public ApiResponse(string _message, T _data) : this(_message)
        {
            Data = _data;
        }
    }
}
