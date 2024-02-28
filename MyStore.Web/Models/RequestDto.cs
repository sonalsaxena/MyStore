

using static MyStore.Web.Utility.SD;

namespace MyStore.Web.Models

{
    public class RequestDto
    {
        public ApiType APItype { get; set; } = ApiType.GET;
        public object Data { get; set; }
        public string AccessToken { get; set; }
        public string Url { get; set; }

    }
}
