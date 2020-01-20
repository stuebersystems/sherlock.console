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
    /// Helper class to process command line arguments 
    /// </summary>
    class CommandLine
    {
        private readonly string[] _args;

        public CommandLine(string[] args)
        {
            _args = args;
        }

        public bool HasArgs()
        {
            return ((_args != null) && (_args.Length > 0));
        }

        public string GetArgAsString(int index)
        {
            if (HasArg(index)) 
            {
                return _args[index];
            }
            else
            {
                throw new ArgumentNullException("Argument is missing");
            }
        }

        public string GetArgAsStringOrEmpty(int index)
        {
            if (HasArg(index))
            {
                return _args[index];
            }
            else
            {
                return String.Empty;
            }
        }

        public bool GetArgAsBool(int index)
        {
            return bool.Parse(GetArgAsString(index));
        }

        public Int64 GetArgAsInt64(int index)
        {
            return Int64.Parse(GetArgAsString(index));
        }

        public SystemTime GetArgAsSystemTime(int index)
        {
            return new SystemTime(DateTime.Parse(GetArgAsString(index)));
        }

        public ProtectionMode GetArgAsProtectionMode(int index)
        {
            return (ProtectionMode)Enum.Parse(typeof(ProtectionMode), GetArgAsString(index));
        }

        public DaysOfWeek GetArgAsDaysOfWeek(int index)
        {
            return (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), GetArgAsString(index));
        }

        public FixedVolumeProtectionMode GetArgAsFixedVolumeProtectionMode(int index)
        {
            return (FixedVolumeProtectionMode)Enum.Parse(typeof(FixedVolumeProtectionMode), GetArgAsString(index));
        }

        public FixedVolumeBootMode GetArgAsFixedVolumeBootMode(int index)
        {
            return (FixedVolumeBootMode)Enum.Parse(typeof(FixedVolumeBootMode), GetArgAsString(index));
        }
        
        public FixedVolumeBootAction GetArgAsFixedVolumeBootAction(int index)
        {
            return (FixedVolumeBootAction)Enum.Parse(typeof(FixedVolumeBootAction), GetArgAsString(index));
        }
        
        public FixedVolumeManualOperations GetArgAsFixedVolumeManualOperations(int index)
        {
            return (FixedVolumeManualOperations)Enum.Parse(typeof(FixedVolumeManualOperations), GetArgAsString(index));
        }
        
        public RemovableVolumeAccessMode GetArgAsRemovableVolumeAccessMode(int index)
        {
            return (RemovableVolumeAccessMode)Enum.Parse(typeof(RemovableVolumeAccessMode), GetArgAsString(index));
        }

        private bool HasArg(int index)
        {
            return ((_args != null) && (_args.Length > index));
        }
    }
}
