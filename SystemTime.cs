#region CONFIRE SHERLOCK CONSOLE - Copyright (C) 2015 STÜBER SYSTEMS GmbH
/*    
 *    CONFIRE SHERLOCK CONSOLE 
 *    
 *    Copyright (C) 2015 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */
#endregion

using System;
using System.Runtime.InteropServices;

namespace ConfireSherlockConsole
{
    /// <summary>
    /// Specifies a date and time, using individual members for the month, day, year, weekday, hour, 
    /// minute, second, and millisecond. The time is in coordinated universal time (UTC).
    /// </summary>
    /// <remarks>
    /// This structure maps the Windows SYSTEMTIME structure <see href="https://msdn.microsoft.com/de-de/library/windows/desktop/ms724961(v=vs.85).aspx">
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        /// <summary>
        /// The year. The valid values for this member are 1601 through 30827.
        /// </summary>
        public ushort Year;

        /// <summary>
        /// The month. This member can be one of the following values:
        /// </summary>
        public ushort Month;

        /// <summary>
        /// The day of the week. This member can be one of the following values:
        /// </summary>
        public ushort DayOfWeek;

        /// <summary>
        /// The day of the month. The valid values for this member are 1 through 31.
        /// </summary>
        public ushort Day;

        /// <summary>
        /// The hour. The valid values for this member are 0 through 23.
        /// </summary>
        public ushort Hour;

        /// <summary>
        /// The minute. The valid values for this member are 0 through 59.
        /// </summary>
        public ushort Minute;

        /// <summary>
        /// The second. The valid values for this member are 0 through 59.
        /// </summary>
        public ushort Second;

        /// <summary>
        /// The millisecond. The valid values for this member are 0 through 999.
        /// </summary>
        public ushort Milliseconds;

        /// <summary>
        /// The minimum possible value
        /// </summary>
        public static readonly SystemTime MinValue;

        /// <summary>
        /// The maximum possible value
        /// </summary>
        public static readonly SystemTime MaxValue;

        /// <summary>
        /// Static constructor
        /// </summary>
        static SystemTime()
        {
            MinValue = new SystemTime(1601, 1, 1);
            MaxValue = new SystemTime(30827, 12, 31, 23, 59, 59, 999);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dt">DateTime value</param>
        public SystemTime(DateTime dt)
        {
            dt = dt.ToUniversalTime();
            Year = Convert.ToUInt16(dt.Year);
            Month = Convert.ToUInt16(dt.Month);
            DayOfWeek = Convert.ToUInt16(dt.DayOfWeek);
            Day = Convert.ToUInt16(dt.Day);
            Hour = Convert.ToUInt16(dt.Hour);
            Minute = Convert.ToUInt16(dt.Minute);
            Second = Convert.ToUInt16(dt.Second);
            Milliseconds = Convert.ToUInt16(dt.Millisecond);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <param name="day">Day</param>
        /// <param name="hour">Hour</param>
        /// <param name="minute">Minute</param>
        /// <param name="second">Second</param>
        /// <param name="millisecond">Millisecond</param>
        public SystemTime(ushort year, ushort month, ushort day, ushort hour = 0, ushort minute = 0, ushort second = 0, ushort millisecond = 0)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Milliseconds = millisecond;
            DayOfWeek = 0;
        }

        /// <summary>
        /// SystemTime to DateTime operator
        /// </summary>
        /// <param name="st">SystemTime value</param>
        public static implicit operator DateTime(SystemTime st)
        {
            if (st.Year == 0 || st == MinValue)
            {
                return DateTime.MinValue;
            }
            if (st == MaxValue)
            {
                return DateTime.MinValue;
            }
            return new DateTime(st.Year, st.Month, st.Day, st.Hour, st.Minute, st.Second, st.Milliseconds, DateTimeKind.Local);
        }

        /// <summary>
        /// Equality operator for SystemTime values 
        /// </summary>
        /// <param name="st1">First SystemTime value</param>
        /// <param name="st2">Second SystemTime value</param>
        /// <returns>True if equal</returns>
        public static bool operator ==(SystemTime st1, SystemTime st2)
        {
            return (st1.Year == st2.Year 
                && st1.Month == st2.Month 
                && st1.Day == st2.Day 
                && st1.Hour == st2.Hour 
                && st1.Minute == st2.Minute 
                && st1.Second == st2.Second 
                && st1.Milliseconds == st2.Milliseconds);
        }

        /// <summary>
        /// Equality operator for SystemTime values 
        /// </summary>
        /// <param name="st1">First SystemTime value</param>
        /// <param name="st2">Second SystemTime value</param>
        /// <returns>True if not equal</returns>
        public static bool operator !=(SystemTime st1, SystemTime st2)
        {
            return !(st1 == st2);
        }

        /// <summary>
        /// Comparing this instance with another one
        /// </summary>
        /// <param name="obj">Another instance</param>
        /// <returns>True if equal</returns>
        public override bool Equals(object obj)
        {
            if (obj is SystemTime)
            {
                return ((SystemTime)obj) == this;
            }
            return base.Equals(obj);
        }

        /// <summary>
        /// Displays value as string
        /// </summary>
        /// <returns>String representation of the value</returns>
        public override string ToString()
        {
            return ToString(null);
        }

        /// <summary>
        /// Displays value as formated string
        /// </summary>
        /// <param name="format">DateTime format</param>
        /// <returns>String representation of the value</returns>
        public string ToString(string format)
        {
            DateTime dt = new DateTime(Year, Month, Day, Hour, Second, Milliseconds, DateTimeKind.Local);
            return dt.ToString(format);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
