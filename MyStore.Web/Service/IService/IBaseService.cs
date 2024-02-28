using MyStore.Web.Models;
using MyStore.Web.Models.DTO;

namespace MyStore.Web.Service.IService
{
    public interface IBaseService
    {
       Task<Response> SendAsync(RequestDto request);
    }
}
