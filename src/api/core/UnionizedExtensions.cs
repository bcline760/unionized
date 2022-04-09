using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Unionized
{
    public static class UnionizedExtensions
    {
        public static readonly JsonSerializerSettings JsonSerializeSettings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        /// <summary>
        /// Compares two byte arrays to see if they are equal
        /// </summary>
        /// <returns><c>true</c>, if bytes equal was ared, <c>false</c> otherwise.</returns>
        /// <param name="lhs">Lhs.</param>
        /// <param name="rhs">Rhs.</param>
        public static unsafe bool AreBytesEqual(this byte[] lhs, byte[] rhs)
        {
            if (lhs == null || rhs == null)
                return false;

            if (lhs.Length != rhs.Length)
                return false;

            fixed (byte* p1 = lhs, p2 = rhs)
            {
                byte* x1 = p1, x2 = p2;
                int l = lhs.Length;
                for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
                    if (*((long*)x1) != *((long*)x2)) return false;
                if ((l & 4) != 0) { if (*((int*)x1) != *((int*)x2)) return false; x1 += 4; x2 += 4; }
                if ((l & 2) != 0) { if (*((short*)x1) != *((short*)x2)) return false; x1 += 2; x2 += 2; }
                if ((l & 1) != 0) if (*((byte*)x1) != *((byte*)x2)) return false;
                return true;
            }
        }

        /// <summary>
        /// Get upto the first eight characters of a string. If less than 8, then returns the string
        /// </summary>
        /// <param name="lhs"></param>
        /// <returns>Up to the first eight characters of the string</returns>
        public static string FirstEight(this string lhs)
        {
            return string.IsNullOrEmpty(lhs) && lhs.Length <= 8 ? lhs : lhs.Substring(0, 8);
        }

        public static string MakeSlug(this string[] props)
        {
            if (props.Any(p => p == null))
                throw new ArgumentNullException(nameof(props), "A given property for making a slug was null");

            //If it's an array of one, just call the method below.
            if (props.Length == 1)
                return props.First().MakeSlug();

            return props.Aggregate((c, n) => c.MakeSlug() + "-" + n.MakeSlug());
        }

        public static string MakeSlug(this string prop)
        {
            prop = prop.ToLower();

            return prop;
        }

        /// <summary>
        /// Serialize a list object to JSON
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="self">The </param>
        /// <returns>A JSON string representing the serialized objects</returns>
        public static string ToJson<T>(this List<T> self) => JsonConvert.SerializeObject(self, JsonSerializeSettings);

        /// <summary>
        /// Serialize a JSON object to string
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="self"></param>
        /// <returns>A JSON string representing the serialized object</returns>
        public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, JsonSerializeSettings);
    }
}
