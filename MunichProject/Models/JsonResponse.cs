using System;

namespace MunichProject.Models
{
    [Serializable]
    public class JsonResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}