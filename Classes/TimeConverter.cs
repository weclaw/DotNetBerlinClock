using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var clock = new BerlinClockInstance(aTime);
            return clock.GenerateClockOutput();
        }
    }
}
