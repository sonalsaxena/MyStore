using MyStore.Web.Models;
using MyStore.Web.Models.DTO;

namespace MyStore.Web.Service.IService
{
    public interface ICouponService
    {
        Task<RequestDto> GetCouponByCouponIdAsync(int couponId);

        Task<RequestDto> GetCouponByCouponCodeAsync(string couponCode);

        Task<RequestDto> GetAllAsync();
        Task<RequestDto> UpdateCouponAsync(CouponDto couponDto);
        Task<RequestDto> DeleteCouponAsync(int couponId);
        Task<RequestDto> CreateCouponAsync(CouponDto couponDto);
    }
}
