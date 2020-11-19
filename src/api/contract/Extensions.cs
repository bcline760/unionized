using System;
using System.Collections.Generic;
using System.Text;

namespace Unionized.Contract
{
    public static class Extensions
    {
        /// <summary>
        /// Make the necessary slug as the "application key" for the record.
        /// </summary>
        /// <param name="entity">The entity to generate the slug</param>
        public static void Slugify(this UnionizedEntity entity)
        {
            entity.Slug = entity.SlugProperties.MakeSlug();
        }
    }
}
