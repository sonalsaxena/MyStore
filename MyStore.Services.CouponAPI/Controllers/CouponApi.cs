using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyStore.Services.CouponAPI.Data;
using MyStore.Services.CouponAPI.Models;
using MyStore.Services.CouponAPI.Models.DTO;
//using System.Web.Http;

namespace MyStore.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApi : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private Response response;

        public CouponApi(AppDbContext db, IMapper mapper)
        {
            _db = db;
            response = new Response();
            this._mapper = mapper;
        }

        [HttpGet]
        public Response Get()
        {
            IEnumerable<Coupon> objList = null;
            try
            {
                objList = _db.Coupons.ToList();
                response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList); 

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message= ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public Response Get( int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.CouponId == id);               
                response.Result = _mapper.Map<CouponDto>(obj); 

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message= ex.Message;

            }

            return response;
        }

        [HttpGet]
        [Route("GetByCoupnCode/{code}")]
        public Response GetByCouponId(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(x => x.CouponCode.ToLower()==code.ToLower());
                response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }

            return response;
        }

        [HttpPost]
        public Response Post([FromBody] CouponDto coupon)
        {
            try
            {

                Coupon obj = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
               response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }

            return response;
        }

        [HttpPut]
        public Response Put([FromBody] CouponDto coupon)
        {
            try
            {

                Coupon obj = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }

            return response;
        }

        [HttpDelete]
        public Response Delete(int Id)
        {
            try
            {

               Coupon obj = _db.Coupons.First( x=> x.CouponId == Id );
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
                
                response.Message = "Coupon deleted";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }

            return response;
        }





    }

}
