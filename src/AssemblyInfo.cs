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
using System.Reflection;

namespace ConfireSherlockConsole
{
    /// <summary>
    /// Helper class to extract assambly infos
    /// </summary>
    public static class AssemblyInfo
    {
        public static string GetTitle()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), true);
            if (attributes.Length > 0)
            {
                return ((AssemblyTitleAttribute)attributes[0]).Title;
            }
            else
            {
                return "CONFIRE SHERLOCK CONSOLE";
            }
        }

        public static string GetCopyright()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);
            if (attributes.Length > 0)
            {
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
            else
            {
                return null;
            }
        }

        public static string GetVersion()
        {
            return String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
    }
}

