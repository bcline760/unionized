using System;
using System.Collections.Generic;
using System.Text;

namespace Unionized.Contract
{
    public interface ISluggable
    {
        /// <summary>
        /// A slug which uniquely identifies the 
        /// </summary>
        string Slug { get; set; }

        /// <summary>
        /// The properties which define the record slug
        /// </summary>
        string[] SlugProperties { get; }
    }
}
