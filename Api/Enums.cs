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
   [Flags]
   public enum DaysOfWeek: ushort
   {
      Everyday = 0x00,
      Sun = 0x01,
      Mon = 0x02,
      Tue = 0x04,
      Wed = 0x08,
      Thu = 0x10,
      Fri = 0x20,
      Sat = 0x40
   }

   public enum DriveType: ushort
   {
      Unknown = 0,
      RemovableDrive = 1,
      FixedDrive = 2,
      RemoteDrive = 3,
      CdRom = 4,
      RamDisk = 5
   }

   public enum ProtectionMode: ushort
   {
      Off = 0,
      On = 1
   }

   public enum FixedVolumeProtectionMode: ushort
   {
      Off = 0,
      On = 1
   }

   public enum FixedVolumeBootMode: ushort
   {
      DiscardChanges = 0,
      KeepChanges = 1,
      Inherited = 2
   }

   public enum FixedVolumeBootAction: ushort
   {
      NoAction = 0,
      DiscardChanges = 1,
      ApplyChanges = 2
   }

   [Flags]
   public enum FixedVolumeManualOperations: ushort
   {
       None = 0x00,
       DiscardChanges = 0x01,
       ApplyChanges = 0x02
   }

   public enum FixedVolumeSwapStorageStatus: ushort
   {
      Undefined = 0,
      Allocating = 1,
      Ready = 2,
      CrcMismatch = 3,
      MissingRegistry = 4,
      MissingFile = 5
   }

   public enum RemovableVolumeAccessMode: ushort
   {
      ReadWrite = 0,
      ReadOnly = 1,
      Invisible = 2,
      Inherited = 3
   }
}
