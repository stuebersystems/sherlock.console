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
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FixedVolumeBootOptions
    {
        public FixedVolumeBootMode mode;
        public FixedVolumeManualOperations manualOperations;
        public SystemTime autoDiscardTime;
        public DaysOfWeek autoDiscardWeekdays;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FixedVolumeConfiguration
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=64)]
        public string deviceName;
        public ProtectionMode protectionMode;
        public FixedVolumeBootAction bootAction;
        public FixedVolumeBootOptions bootOptions;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RemovableVolumeConfiguration
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=64)]
        public string deviceName;
        public RemovableVolumeAccessMode accessMode;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BootOptions
    {
        public FixedVolumeBootMode mode;
        public FixedVolumeManualOperations manualOperations;
        public SystemTime autoDiscardTime;
        public DaysOfWeek autoDiscardWeekdays;
        public SystemTime nextDiscardTS;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Configuration
    {
        public ProtectionMode protectionMode;
        public BootOptions bootOptions;
        public ushort fixedVolumeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public FixedVolumeConfiguration[] fixedVolumes;
        public ushort removableVolumeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public RemovableVolumeConfiguration[] removableVolumes;
        public RemovableVolumeAccessMode removableVolumesAccessMode;
        public bool hasAdminPassword;
        public bool hasUserPassword;
        public bool hideConfigCommand;
        public bool hideRebootCommand;
        public bool showTrayIcon;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FixedVolumeSwapStorageInfo
    {
        public FileSize size;
        public FileSize usedSpace;
        public FileSize freeSpace;
        public FileSize reportedFreeSpace;
        public FixedVolumeSwapStorageStatus status;
        public FileSize minSize;
        public FileSize maxSize;
        public FileSize recommendedSize;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FixedVolumeInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string deviceName;
        public char driveLetter;
        public DriveType driveType;
        public FileSize totalNumberOfBytes;
        public FileSize totalNumberOfFreeBytes;
        public FixedVolumeSwapStorageInfo swapStorageInfo;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FixedVolumeInfoArray
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 26)]
        public FixedVolumeInfo[] info;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RemovableVolumeInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string deviceName;
        public Char driveLetter;
        public DriveType driveType;
        public FileSize totalNumberOfBytes;
        public FileSize totalNumberOfFreeBytes;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RemovableVolumeInfoArray
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 32)]
        public RemovableVolumeInfo[] info; 
    }
}
