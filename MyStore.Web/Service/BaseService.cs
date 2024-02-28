using MyStore.Web.Models;
using MyStore.Web.Models.DTO;
using MyStore.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using static MyStore.Web.Utility.SD;

namespace MyStore.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Response?> SendAsync(RequestDto request)
        {
            HttpClient client = _httpClientFactory.CreateClient("MyStore");

            HttpRequestMessage message = new HttpRequestMessage();        

            message.Headers.Add("Content-Type", "application/json");

            message.RequestUri = new Uri(request.Url);
            if(request.Data!=null)
            {
                message.Content= new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");

            }

            HttpResponseMessage? apiResponse = null;

            switch(request.APItype)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;

            }
             apiResponse = await client.SendAsync(message);
            try
            {
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Page not found" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<Response>(apiContent);
                        return apiResponseDto;

                }
            }
            catch (Exception ex)
            {
                return new() { IsSuccess = false, Message = ex.Message.ToString() };
            }



        }
    }
}
