using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Unionized.Contract;
using Unionized.Contract.Service;

namespace Unionized.Api.Controllers
{
    public abstract class UnionizedDataController<TContract> : UnionizedController
        where TContract:UnionizedEntity
    {
        protected IUnionizedService<TContract> Service { get; private set; }
        protected UnionizedDataController(IUnionizedService<TContract> service)
        {
            Service = service;
        }

        [HttpGet,Route("")]
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

        [HttpPost,Route("")]
        public virtual async Task<IActionResult> PostAsync(TContract contract)
        {
            var result = await ExecuteServiceMethod(Service.SaveAsync, contract, "PostAsync", DesiredStatusCode.Created);

            return result;
        }

        [HttpDelete, Route("")]
        public virtual async Task<IActionResult> DeleteAsync(string slug)
        {
            var contract = await Service.GetAsync(slug);
            if (contract!=null)
            {
                contract.Active = false;
                contract.UpdatedAt = DateTime.Now;

                var result = await ExecuteServiceMethod(Service.SaveAsync, contract, "DeleteAsync", DesiredStatusCode.Created);
                return result;
            }

            return NotFound();
        }
    }
}
