using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unionized.Api
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type of data object to be sent back over the API</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }
    }
}
