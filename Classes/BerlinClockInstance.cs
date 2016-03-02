using System;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    class BerlinClockInstance
    {
        private const short HOURS_FIRST_ROW_CNT = 4;
        private const short HOURS_SECOND_ROW_CNT = 4;
        private const short MINUTES_FIRST_ROW_CNT = 11;
        private const short MINUTES_SECOND_ROW_CNT = 4;

        private short hours, minutes, seconds;

        public BerlinClockInstance(string aTime)
        {    
            var timeSections = (aTime ?? "").Split(':');

            if( timeSections.Length != 3 ||
                !short.TryParse(timeSections[0], out hours) || hours > 24 ||
                !short.TryParse(timeSections[1], out minutes) || minutes > 59 ||
                !short.TryParse(timeSections[2], out seconds) || seconds > 59)
            {
                throw new FormatException("Incorrect time format!");
            }
        }

        public string GenerateClockOutput()
        {
            var clockOutputBuilder = new StringBuilder();
            
            clockOutputBuilder.AppendLine(GenerateSecondsOutput());
            clockOutputBuilder.AppendLine(GenerateHoursFirstRowOutput());
            clockOutputBuilder.AppendLine(GenerateHoursSecondRowOutput());
            clockOutputBuilder.AppendLine(GenerateMinutesFirstRowOutput());
            clockOutputBuilder.Append(GenerateMinutesSecondRowOutput());

            return clockOutputBuilder.ToString();
        }

        private string GenerateSecondsOutput()
        {
            return seconds % 2 == 0 ? "Y" : "O";
        }

        private string GenerateHoursFirstRowOutput()
        {
            return string.Format("{0}{1}", 
                new string('R', hours / 5),
                new string('O', HOURS_FIRST_ROW_CNT - (hours / 5)));
        }

        private string GenerateHoursSecondRowOutput()
        {
            return string.Format("{0}{1}", 
                new string('R', hours % 5), 
                new string('O', HOURS_SECOND_ROW_CNT - (hours % 5)));
        }

        private string GenerateMinutesFirstRowOutput()
        {
            return string.Format("{0}{1}{2}",
               string.Concat(Enumerable.Repeat("YYR", minutes / 15)),
               new string('Y', (minutes / 5 - ((minutes / 15)*3))),
               new string('O', MINUTES_FIRST_ROW_CNT - (minutes / 5)));
        }

        private string GenerateMinutesSecondRowOutput()
        {
            return string.Format("{0}{1}",
               new string('Y', minutes % 5),
               new string('O', MINUTES_SECOND_ROW_CNT - (minutes % 5)));
        }
    }
}
