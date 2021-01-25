using System.Collections.Generic;

namespace ClosetControl.Application.Models
{
    public class Response<Clothes>
    {
        public Clothes SingleData { get; set; }
        public IEnumerable<Clothes> DataList { get; set; }
        public bool Success { get; set; }
        public List<string> MessageList { get; set; }

        public Response(bool success, List<string> messageList = null)
        {
            Success = success;
            MessageList = messageList;
        }

        public Response(bool success, string message = null, IEnumerable<Clothes> data = null)
        {
            DataList = data;
            Success = success;
            MessageList = new List<string> { message };
        }

        public Response(bool success, Clothes singleData)
        {
            SingleData = singleData;
            Success = success;
        }

        public Response()
        {
        }
    }
}
