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
    /// The CONFIRE SHERLOCK API
    /// </summary>
    /// <remarks>
    /// This class imports the API as unmanaged dynamic-link library (DLL).   
    /// </remarks>
    static class Api
    {
        /// <summary>
        /// Sets license for CONFIRE SHERLOCK by providng user name, user site and key value.
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="userSite">User site</param>
        /// <param name="key">License key</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetLicenseInfo(string userName, string userSite, string key)
        {
            if (_SetLicenseInfo(userName, userSite, key) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets license for CONFIRE SHERLOCK by providng a license file.
        /// </summary>
        /// <param name="filename">File path to license file.</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetLicenseInfoFromFile(string filename)
        {
            if (_SetLicenseInfoFromFile(filename) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Returns the current protection mode of CONFIRE SHERLOCK
        /// </summary>
        /// <param name="mode">Current protection mode</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void GetProtectionMode(out ProtectionMode mode)
        {
            if (_GetProtectionMode(out mode) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets the protection mode of CONFIRE SHERLOCK
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="newMode">New protection mode</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        /// <remarks>
        /// This change will be effective only after the next reboot of the computer system.
        /// </remarks>
        public static void SetProtectionMode(string securityToken, ProtectionMode newMode)
        {
            if (_SetProtectionMode(securityToken, newMode) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets the admin password for CONFIRE SHERLOCK
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="newAdminPassword">New admin password</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetAdminPassword(string securityToken, string newAdminPassword)
        {
            if (_SetAdminPassword(securityToken, newAdminPassword) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets the user password for CONFIRE SHERLOCK
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="newUserPassword">New user password</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetUserPassword(string securityToken, string newUserPassword)
        {
            if (_SetUserPassword(securityToken, newUserPassword) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gives back the current configuration for CONFIRE SHERLOCK
        /// </summary>
        /// <param name="configuration">A Configuration struct that contains all information.</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void GetConfiguration(out Configuration configuration)
        {
            if (_GetConfiguration(out configuration) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets the global boot mode for CONFIRE SHERLOCK
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="newMode">New boot mode</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetBootMode(string securityToken, FixedVolumeBootMode newMode)
        {
            if (_SetBootMode(securityToken, newMode) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines which manual operations are allowed for a user
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="newManualOperations">Set of maunal operations</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetManualOperations(string securityToken, FixedVolumeManualOperations newManualOperations)
        {
            if (_SetManualOperations(securityToken, newManualOperations) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines a global time stamp for an auto discard of fixed volumes
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="newTime">New time stamp</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetAutoDiscardTime(string securityToken, SystemTime newTime)
        {
            if (_SetAutoDiscardTime(securityToken, newTime) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines valid weekdays for the global auto discard of fixed volumes.
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="newWeekdays">Set of weekdays</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetAutoDiscardWeekdays(string securityToken, DaysOfWeek newWeekdays)
        {
            if (_SetAutoDiscardWeekdays(securityToken, newWeekdays) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines if the config command in the tray icon menu for CONFIRE SHERLOCK is visible or not.
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="hideCommand">If true config command is not visible</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetHideConfigCommand(string securityToken, bool hideCommand)
        {
            if (_SetHideConfigCommand(securityToken, hideCommand) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines if the reboot command in the tray icon menu for CONFIRE SHERLOCK is visible or not.
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="showTrayIcon">If True reboot command is not visible</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetHideRebootCommand(string securityToken, bool hideCommand)
        {
            if (_SetHideRebootCommand(securityToken, hideCommand) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines if the tray icon for CONFIRE SHERLOCK is visible or not.
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="showTrayIcon">If True tray icon should be shown</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetShowTrayIcon(string securityToken, bool showTrayIcon)
        {
            if (_SetShowTrayIcon(securityToken, showTrayIcon) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines the global access mode for removable volumes
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="newAccessMode">New access mode</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetRemovableVolumesAccessMode(string securityToken, RemovableVolumeAccessMode newAccessMode)
        {
            if (_SetRemovableVolumesAccessMode(securityToken, newAccessMode) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines the protection mode for a given fixed volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="newMode">New protection mode</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetFixedVolumeProtectionMode(string securityToken, string deviceName, FixedVolumeProtectionMode newMode)
        {
            if (_SetFixedVolumeProtectionMode(securityToken, deviceName, newMode) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines the action for the next reboot of a given fixed volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="newAction">New boot action</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetFixedVolumeBootAction(string securityToken, string deviceName, FixedVolumeBootAction newAction)
        {
            if (_SetFixedVolumeBootAction(securityToken, deviceName, newAction) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines the boot mode for a given fixed volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="newMode">New boot mode</param>
        public static void SetFixedVolumeBootMode(string securityToken, string deviceName, FixedVolumeBootMode newMode)
        {
            if (_SetFixedVolumeBootMode(securityToken, deviceName, newMode) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines the valid manual user operations for a given fixed volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="newOperations">Set of operations</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetFixedVolumeManualOperations(string securityToken, string deviceName, FixedVolumeManualOperations newOperations)
        {
            if (_SetFixedVolumeManualOperations(securityToken, deviceName, newOperations) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines a time stamp for an auto discard of a given fixed volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="newTime">New time stamp</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetFixedVolumeAutoDiscardTime(string securityToken, string deviceName, SystemTime newTime)
        {
            if (_SetFixedVolumeAutoDiscardTime(securityToken, deviceName, newTime) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Defines valid weekdays for an auto discard of a given fixed volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="newWeekdays">Set of weekdays</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetFixedVolumeAutoDiscardWeekdays(string securityToken, string deviceName, DaysOfWeek newWeekdays)
        {
            if (_SetFixedVolumeAutoDiscardWeekdays(securityToken, deviceName, newWeekdays) != 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets access mode for a given removable volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="newMode">New access mode</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void SetRemovableVolumeAccessMode(string securityToken, string deviceName, RemovableVolumeAccessMode newMode)
        {
            if (_SetRemovableVolumeAccessMode(securityToken, deviceName, newMode) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Gives back a list of all fixed volumes recognized by CONFIRE SHERLOCK
        /// </summary>
        /// <param name="volumes">A FixedVolumeInfo array which holds all information</param>
        /// <param name="volumeCount">The number of volumes inside the FixedVolumeInfo array.</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void GetFixedVolumes(out FixedVolumeInfoArray volumes, out ushort volumeCount)
        {
            if (_GetFixedVolumes(out volumes, out volumeCount) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Gives back a list of all removable volumes recognized by CONFIRE SHERLOCK
        /// </summary>
        /// <param name="volumes">A TCFS_REMOVABLE_VOLUMES structure which holds all information</param>
        /// <param name="volumeCount">The number of volumes inside the TCFS_REMOVABLE_VOLUMES structure.</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void GetRemovableVolumes(out RemovableVolumeInfoArray volumes, out ushort volumeCount)
        {
            if (_GetRemovableVolumes(out volumes, out volumeCount) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Starts swap file allocation for a specific volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="swapSize">Swap file size in MB</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        /// <remarks>
        /// This function can only succeed if the protection mode is off.
        /// </remarks>
        public static void StartSwapStorageAllocation(string securityToken, string deviceName, ref Int64 swapSize)
        {
            if (_StartSwapStorageAllocation(securityToken, deviceName, ref swapSize) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Aborts current swap file allocation
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        /// <remarks>
        /// This function can only succeed if the protection mode is off.
        /// </remarks>
        public static void AbortSwapStorageAllocation(string securityToken)
        {
            if (_AbortSwapStorageAllocation(securityToken) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Removes swap storage from a specific volume
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <param name="deviceName">Device name of the volume</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        /// <remarks>
        /// This function can only succeed if the protection mode is off.
        /// </remarks>
        public static void RemoveSwapStorage(string securityToken, string deviceName)
        {
            if (_RemoveSwapStorage(securityToken, deviceName) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Removes all swap storages
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        /// <remarks>
        /// This function can only succeed if the protection mode is off.
        /// </remarks>
        public static void RemoveSwapStorages(string securityToken)
        {
            if (_RemoveSwapStorages(securityToken) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Get swap storage info for a specific volume
        /// </summary>
        /// <param name="deviceName">Device name of the volume</param>
        /// <param name="info"></param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        public static void GetSwapStorageInfo(string deviceName, out FixedVolumeSwapStorageInfo info)
        {
            if (_GetSwapStorageInfo(deviceName, out info) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Prepares the local computer system for turning on the protection mode.
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        /// <remarks>
        /// This function should be called after CONFIRE SHERLOCK was configured and right before the 
        /// reboot of the local computer system is triggered.
        /// </remarks>
        public static void PrepareSystem(string securityToken)
        {
            if (_PrepareSystem(securityToken) != 0)
            {
                throw new Exception("Api error");
            }
        }

        /// <summary>
        /// Tells the local computer system to reboot itself. Includes also a preparing of the 
        /// system (see PrepareSystem).
        /// </summary>
        /// <param name="securityToken">Security token</param>
        /// <exception cref="Exception">if call was not successfull.</exception>
        /// <remarks>
        /// This function should be called after CONFIRE SHERLOCK was configured.
        /// </remarks>
        public static void RebootSystem(string securityToken)
        {
            if (_RebootSystem(securityToken) != 0)
            {
                throw new Exception("Api error");
            }
        }

        #region Imports

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetLicenseInfo", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetLicenseInfo(string userName, string userSite, string key);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetLicenseInfoFromFile, CharSet = CharSet.Unicode")]
        private static extern Int32 _SetLicenseInfoFromFile(string filename);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "GetProtectionMode")]
        private static extern Int32 _GetProtectionMode(out ProtectionMode mode);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetProtectionMode", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetProtectionMode(string securityToken, ProtectionMode newMode);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetAdminPassword", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetAdminPassword(string securityToken, string newAdminPassword);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetUserPassword", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetUserPassword(string securityToken, string newUserPassword);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "GetConfiguration")]
        private static extern Int32 _GetConfiguration(out Configuration configuration);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetBootMode", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetBootMode(string securityToken, FixedVolumeBootMode newMode);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetManualOperations", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetManualOperations(string securityToken, FixedVolumeManualOperations newManualOperations);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetAutoDiscardTime", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetAutoDiscardTime(string securityToken, SystemTime newTime);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetAutoDiscardWeekdays", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetAutoDiscardWeekdays(string securityToken, DaysOfWeek newWeekdays);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetHideConfigCommand", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetHideConfigCommand(string securityToken, bool hideCommand);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetHideRebootCommand", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetHideRebootCommand(string securityToken, bool hideCommand);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetShowTrayIcon", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetShowTrayIcon(string securityToken, bool showTrayIcon);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetRemovableVolumesAccessMode", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetRemovableVolumesAccessMode(string securityToken, RemovableVolumeAccessMode newAccessMode);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetFixedVolumeProtectionMode", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetFixedVolumeProtectionMode(string securityToken, string deviceName, FixedVolumeProtectionMode newMode);
   
        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetFixedVolumeBootAction", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetFixedVolumeBootAction(string securityToken, string deviceName, FixedVolumeBootAction newAction);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetFixedVolumeBootMode", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetFixedVolumeBootMode(string securityToken, string deviceName, FixedVolumeBootMode newMode);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetFixedVolumeManualOperations", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetFixedVolumeManualOperations(string securityToken, string deviceName, FixedVolumeManualOperations newOperations);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetFixedVolumeAutoDiscardTime", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetFixedVolumeAutoDiscardTime(string securityToken, string deviceName, SystemTime newTime);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetFixedVolumeAutoDiscardWeekdays", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetFixedVolumeAutoDiscardWeekdays(string securityToken, string deviceName, DaysOfWeek newWeekdays);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "SetRemovableVolumeAccessMode", CharSet = CharSet.Unicode)]
        private static extern Int32 _SetRemovableVolumeAccessMode(string securityToken, string deviceName, RemovableVolumeAccessMode newMode);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "GetFixedVolumes")]
        private static extern Int32 _GetFixedVolumes(out FixedVolumeInfoArray volumes, out ushort volumeCount);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "GetRemovableVolumes")]
        private static extern Int32 _GetRemovableVolumes(out RemovableVolumeInfoArray volumes, out ushort volumeCount);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "StartSwapStorageAllocation", CharSet = CharSet.Unicode)]
        private static extern Int32 _StartSwapStorageAllocation(string securityToken, string DeviceName, ref Int64 SwapSize);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "AbortSwapStorageAllocation", CharSet = CharSet.Unicode)]
        private static extern Int32 _AbortSwapStorageAllocation(string securityToken);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "RemoveSwapStorage", CharSet = CharSet.Unicode)]
        private static extern Int32 _RemoveSwapStorage(string securityToken, string deviceName);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "RemoveSwapStorages", CharSet = CharSet.Unicode)]
        private static extern Int32 _RemoveSwapStorages(string securityToken);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "GetSwapStorageInfo", CharSet = CharSet.Unicode)]
        private static extern Int32 _GetSwapStorageInfo(string deviceName, out FixedVolumeSwapStorageInfo info);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "PrepareSystem", CharSet = CharSet.Unicode)]
        private static extern Int32 _PrepareSystem(string securityToken);

        [DllImport("ConfireSherlockApi.dll", EntryPoint = "RebootSystem", CharSet = CharSet.Unicode)]
        private static extern Int32 _RebootSystem(string securityToken);

        #endregion Imports
    }
}
