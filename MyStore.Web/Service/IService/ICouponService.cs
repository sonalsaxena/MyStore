using MyStore.Web.Models;

namespace MyStore.Web.Service.IService
{
    public interface ICouponService
    {
        Task<RequestDto> GetCouponByCouponIdAsync(string couponId);

        Task<RequestDto> GetCouponByCouponCodeAsync(string couponCode);

        Task<RequestDto> GetAllAsync();
        Task<RequestDto> UpdateCouponAsync(string couponId);
        Task<RequestDto> DeleteCouponAsync(string couponId);
        Task<RequestDto> AddCouponAsync(string couponId);
    }
}
