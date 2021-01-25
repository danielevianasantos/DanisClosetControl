using System.Collections.Generic;

namespace ClosetControl.Domain.Models
{
    public class Result
    {

        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }

        public string Message { get; set; }

        public Result(bool success = true, List<string> messages = null)
        {
            Success = success;
            ErrorMessages = messages;
        }

        public Result(bool success = true, string message = null)
        {
            Success = success;
            Message = message;
        }

        public Result()
        {
        }
    }
}
