using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Unionized.Api;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unionized.Api.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class UnionizedController : ControllerBase
    {
        /// <summary>
        /// Execute a service method
        /// </summary>
        /// <typeparam name="TOut">The service method return type</typeparam>
        /// <param name="serviceMethod">A delegate for the service method to be executed</param>
        /// <param name="svcFunction">The name of the service function being performed</param>
        /// <param name="code">The HTTP status code to return on success</param>
        /// <returns>An HTTP action result with message and status code</returns>
        protected async Task<IActionResult> ExecuteServiceMethod<TOut>(Func<Task<TOut>> serviceMethod, string svcFunction, DesiredStatusCode code)
        {
            IActionResult result = null;

            ApiResponse<TOut> apiResponse = new ApiResponse<TOut>
            {
                Success = false
            };

            try
            {
                var response = await serviceMethod();
                apiResponse.Data = response;

                switch (code)
                {
                    case DesiredStatusCode.OK:
                        apiResponse.Success = true;
                        result = Ok(apiResponse);
                        break;
                    case DesiredStatusCode.Created:
                        apiResponse.Success = true;
                        result = CreatedAtAction(svcFunction, apiResponse);
                        break;
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = $"Failed to execute service operation {svcFunction}.";
                result = BadRequest(apiResponse);
            }

            return result;
        }

        /// <summary>
        /// Execute a service method.
        /// </summary>
        /// <typeparam name="TIn">Service method input parameter type</typeparam>
        /// <typeparam name="TOut">The service method return type</typeparam>
        /// <param name="serviceMethod">A delegate for the service method to be executed</param>
        /// <param name="svcParam">The input parameter for the service method</param>
        /// <param name="svcFunction">The name of the service function being performed</param>
        /// <param name="code">The HTTP status code to return on success</param>
        /// <returns>An HTTP action result with message and status code</returns>
        protected async Task<IActionResult> ExecuteServiceMethod<TIn, TOut>(Func<TIn, Task<TOut>> serviceMethod, TIn svcParam, string svcFunction, DesiredStatusCode code)
        {
            IActionResult result = null;

            ApiResponse<TOut> apiResponse = new ApiResponse<TOut>
            {
                Success = false
            };

            try
            {
                var response = await serviceMethod(svcParam);
                apiResponse.Data = response;

                switch (code)
                {
                    case DesiredStatusCode.OK:
                        apiResponse.Success = true;
                        result = Ok(apiResponse);
                        break;
                    case DesiredStatusCode.Created:
                        apiResponse.Success = true;
                        result = CreatedAtAction(svcFunction, apiResponse);
                        break;
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = $"Failed to execute service operation {svcFunction}.";
                result = BadRequest(apiResponse);
            }

            return result;
        }

        /// <summary>
        /// Execute a service method
        /// </summary>
        /// <typeparam name="TIn">First service method input parameter type</typeparam>
        /// <typeparam name="TIn2">Second service method input parameter type</typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="serviceMethod">A delegate for the service method to be executed</param>
        /// <param name="svcParam">The input parameter for the service method</param>
        /// <param name="svcParam2">The second input parameter for the service method</param>
        /// <param name="svcFunction">The name of the service function being performed</param>
        /// <param name="code">The HTTP status code to return on success</param>
        /// <returns>An HTTP action result with message and status code</returns>
        protected async Task<IActionResult> ExecuteServiceMethod<TIn, TIn2, TOut>(
            Func<TIn, TIn2, Task<TOut>> serviceMethod,
            TIn svcParam,
            TIn2 svcParam2,
            string svcFunction,
            DesiredStatusCode code)
        {
            IActionResult result = null;

            ApiResponse<TOut> apiResponse = new ApiResponse<TOut>
            {
                Success = false
            };

            try
            {
                var response = await serviceMethod(svcParam, svcParam2);
                apiResponse.Data = response;

                switch (code)
                {
                    case DesiredStatusCode.OK:
                        apiResponse.Success = true;
                        result = Ok(apiResponse);
                        break;
                    case DesiredStatusCode.Created:
                        apiResponse.Success = true;
                        result = CreatedAtAction(svcFunction, apiResponse);
                        break;
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = $"Failed to execute service operation {svcFunction}.";
                result = BadRequest(apiResponse);
            }

            return result;
        }
    }
}
