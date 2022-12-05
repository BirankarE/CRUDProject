using System.Text.Json.Serialization;

namespace CRUDProject.Core.DTOs
{
    public class ResponseDataDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }


        public static ResponseDataDto<T> Success(int statusCode, T data)
        {
            return new ResponseDataDto<T> { StatusCode = statusCode, Data = data };
        }
        public static ResponseDataDto<T> Success(int statusCode)
        {
            return new ResponseDataDto<T> { StatusCode = statusCode };
        }

        public static ResponseDataDto<T> Fail(int statusCode, List<string> errors)
        {
            return new ResponseDataDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static ResponseDataDto<T> Fail(int statusCode, string error)
        {
            return new ResponseDataDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }

    }
}
