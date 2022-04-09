using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Unionized.Contract;
using Unionized.Interface.Service;

namespace Unionized.Api.Controllers
{
    public abstract class UnionizedDataController<TContract> : UnionizedController
        where TContract : UnionizedEntity
    {
        protected IUnionizedService<TContract> Service { get; private set; }
        protected UnionizedDataController(IUnionizedService<TContract> service)
        {
            Service = service;
        }

        [HttpGet, Route("")]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var result = await ExecuteServiceMethod(Service.GetAllAsync, "GetAllAsync", DesiredStatusCode.OK);

            return result;
        }

        [HttpGet, Route("{slug}")]
        public virtual async Task<IActionResult> GetAsync(string slug)
        {
            var result = await ExecuteServiceMethod(Service.GetAsync, slug, "GetAsync", DesiredStatusCode.OK);

            return result;
        }

        [HttpPost, Route("")]
        public virtual async Task<IActionResult> PostAsync(TContract contract)
        {
            IActionResult result = null;

            ApiResponse<string> apiResponse = new ApiResponse<string>
            {
                Success = false
            };

            try
            {
                await Service.SaveAsync(contract);

                result = CreatedAtAction("SaveAsync", apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = $"Failed to execute service operation SaveAsync.";
                result = BadRequest(apiResponse);
            }
            return result;
        }

        [HttpDelete, Route("")]
        public virtual async Task<IActionResult> DeleteAsync(string slug)
        {
            IActionResult result = null;

            ApiResponse<string> apiResponse = new ApiResponse<string>
            {
                Success = false
            };

            try
            {
                await Service.DeleteAsync(slug);

                result = Ok();
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = $"Failed to execute service operation DeleteAsync.";
                result = BadRequest(apiResponse);
            }

            return result;
        }
    }
}
