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
    /// Our list of commands
    /// </summary>
    static class CommandNames
    {
        public const string SetLicenseInfo = "set-licenseInfo";
        public const string SetLicenseInfoFromFile = "set-licenseInfoFromFile";
        public const string GetProtectionMode = "get-protectionMode";
        public const string SetProtectionMode = "set-protectionMode";
        public const string SetAdminPassword = "set-adminPassword";
        public const string SetUserPassword = "set-userPassword";
        public const string GetConfiguration = "get-config";
        public const string SetBootMode = "set-bootMode";
        public const string SetManualOperations = "set-manualOperations";
        public const string SetAutoDiscardTime = "set-autoDiscardTime";
        public const string SetAutoDiscardWeekdays = "set-autoDiscardWeekdays";
        public const string SetHideConfigCommand = "set-hideConfigCommand";
        public const string SetHideRebootCommand = "set-hideRebootCommand";
        public const string SetShowTrayIcon = "set-showTrayIcon";
        public const string SetRemovableVolumesAccessMode = "set-removableVolumesAccessMode";
        public const string SetFixedVolumeProtectionMode = "set-fixedVolumeProtectionMode";
        public const string SetFixedVolumeBootMode = "set-fixedVolumeBootMode";
        public const string SetFixedVolumeBootAction = "set-fixedVolumeBootAction";
        public const string SetFixedVolumeManualOperations = "set-fixedVolumeManualOperations";
        public const string SetFixedVolumeAutoDiscardTime = "set-fixedVolumeAutoDiscardTime";
        public const string SetFixedVolumeAutoDiscardWeekdays = "set-fixedVolumeAutoDiscardWeekdays";
        public const string SetRemovableVolumeAccessMode = "set-removableVolumeAccessMode";
        public const string GetFixedVolumes = "get-fixedVolumes";
        public const string GetRemovableVolumes = "get-removableVolumes";
        public const string AllocateSwapStorage = "allocate-swapStorage";
        public const string RemoveSwapStorage = "remove-swapStorage";
        public const string RemoveSwapStorages = "remove-swapStorages";
        public const string GetSwapStorageInfo = "get-swapStorageInfo";
        public const string PrepareSystem = "prepare-system";
        public const string RebootSystem = "reboot-system";
    }
}
