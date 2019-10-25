using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading
{
    public static class TimerExtensions
    {
        public static void Start(this Timer timer)
        {
            if (timer == null)
                throw new ArgumentNullException(nameof(timer));
        }
    }
}
