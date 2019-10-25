using System;
using System.Collections.Generic;
using System.Text;

namespace Threading
{
    public static class Guard
    {
        public static void NotNull(object value, string name)
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }
    }
}
