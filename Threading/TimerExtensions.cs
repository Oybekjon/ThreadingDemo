using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading
{
    public static class TimerExtensions
    {
        public static void Start(this Timer timer, TimeSpan period)
        {
            Guard.NotNull(timer, nameof(timer));
            timer.Change(TimeSpan.FromSeconds(0), period);
        }
    }
}
