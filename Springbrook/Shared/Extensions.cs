using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Springbrook.Shared
{
    public static class Extensions
    {
        public static bool IsNullOrWhitespace(this string item)
        {
            return String.IsNullOrWhiteSpace(item);
        }
    }
}
