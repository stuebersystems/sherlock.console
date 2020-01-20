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

namespace ConfireSherlockConsole
{
    /// <summary>
    /// Represents a file size
    /// </summary>
    public struct FileSize
    {
        public long Value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Initial value in Bytes</param>
        public FileSize(long value)
        {
            Value = value;
        }

        /// <summary>
        /// FileSize to long operator
        /// </summary>
        /// <param name="fs">File size</param>
        public static implicit operator long(FileSize fs)
        {
            return fs.Value;
        }

        /// <summary>
        /// Long to FileSIze operator
        /// </summary>
        /// <param name="value">Value in Bytes</param>
        public static implicit operator FileSize(int value)
        {
            return new FileSize(value);
        }

        /// <summary>
        /// Equality operator for FileSize values 
        /// </summary>
        /// <param name="fs1">First file size</param>
        /// <param name="fs2">Second file size</param>
        /// <returns>True if equal</returns>
        public static bool operator ==(FileSize fs1, FileSize fs2)
        {
            return (fs1.Value == fs2.Value);
        }

        /// <summary>
        /// Equality operator for FileSize values 
        /// </summary>
        /// <param name="fs1">First file size</param>
        /// <param name="fs2">Second file size</param>
        /// <returns>True if not equal</returns>
        public static bool operator !=(FileSize fs1, FileSize fs2)
        {
            return !(fs1 == fs2);
        }

        /// <summary>
        /// Parse a file size from string
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>A new FileSize</returns>
        public static FileSize Parse(string source)
        {
            return new FileSize(Int64.Parse(source));
        }

        /// <summary>
        /// Displays file size as string
        /// </summary>
        /// <returns>File size as string</returns>
        /// <remarks>
        /// Code adapted from: http://timtrott.co.uk/pretty-format-bytes-kb-mb-gb/
        /// </remarks>
        public override string ToString()
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (Value > max)
                {
                    return string.Format("{0:##.##} {1}", decimal.Divide(Value, max), order);
                }
                max /= scale;
            }
            return "0 Bytes";
        }

        /// <summary>
        /// Comparing this instance with another one
        /// </summary>
        /// <param name="obj">Another instance</param>
        /// <returns>True if equal</returns>
        public override bool Equals(object obj)
        {
            if (obj is FileSize)
            {
                return ((FileSize)obj) == this;
            }
            return base.Equals(obj);
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

