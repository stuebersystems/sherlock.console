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
using System.Text;

namespace ConfireSherlockConsole
{
    /// <summary>
    /// Output generator for various data.
    /// </summary>
    static class Output
    {
        public static string Generate(ProtectionMode mode)
        {
            return mode.ToString();
        }

        public static string Generate(Configuration configuration)
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("  Protection mode................: {0}", configuration.protectionMode.ToString()));
            sb.AppendLine(String.Format("  Boot mode......................: {0}", configuration.bootOptions.mode.ToString()));
            sb.AppendLine(String.Format("  Auto discard weekdays..........: {0}", configuration.bootOptions.autoDiscardWeekdays.ToString()));
            sb.AppendLine(String.Format("  Auto discard time..............: {0}", configuration.bootOptions.autoDiscardTime.ToString("hh:mm:ss")));
            sb.AppendLine(String.Format("  Next discard timepoint.........: {0}", configuration.bootOptions.nextDiscardTS.ToString("hh:mm:ss")));
            sb.AppendLine(String.Format("  Allowed manual operations......: {0}", configuration.bootOptions.manualOperations.ToString()));
            sb.AppendLine(String.Format("  Has admin password.............: {0}", configuration.hasAdminPassword.ToString()));
            sb.AppendLine(String.Format("  Has user password..............: {0}", configuration.hasUserPassword.ToString()));
            sb.AppendLine(String.Format("  Hide config command............: {0}", configuration.hideConfigCommand.ToString()));
            sb.AppendLine(String.Format("  Hide reboot command............: {0}", configuration.hideRebootCommand.ToString()));
            sb.AppendLine(String.Format("  Show tray icon.................: {0}", configuration.showTrayIcon.ToString()));
            sb.AppendLine();

            for (int i = 0; i < configuration.fixedVolumeCount; i++)
            {
                sb.AppendLine();
                sb.AppendLine(String.Format("Fixed device {0}: {1}", i + 1, configuration.fixedVolumes[i].deviceName));
                sb.AppendLine();
                sb.AppendLine(String.Format("  Protection mode................: {0}", configuration.fixedVolumes[i].protectionMode.ToString()));
                sb.AppendLine(String.Format("  Boot mode......................: {0}", configuration.fixedVolumes[i].bootOptions.mode.ToString()));
                sb.AppendLine(String.Format("  Auto discard weekdays..........: {0}", configuration.fixedVolumes[i].bootOptions.autoDiscardWeekdays.ToString()));
                sb.AppendLine(String.Format("  Auto discard time..............: {0}", configuration.fixedVolumes[i].bootOptions.autoDiscardTime.ToString("hh:mm:ss")));
                sb.AppendLine(String.Format("  Allowed manual operations......: {0}", configuration.fixedVolumes[i].bootOptions.manualOperations.ToString()));
            }

            for (int i = 0; i < configuration.removableVolumeCount; i++)
            {
                sb.AppendLine();
                sb.AppendLine(String.Format("Removable device {0}: {1}", i + 1, configuration.removableVolumes[i].deviceName));
                sb.AppendLine();
                sb.AppendLine(String.Format("  Access mode....................: {0}", configuration.removableVolumes[i].accessMode.ToString()));
            }

            return sb.ToString();
        }

        public static string Generate(FixedVolumeInfoArray volumes, ushort volumeCount)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < volumeCount; i++)
            {
                sb.AppendLine(String.Format("Fixed device {0}: {1}", i+1, volumes.info[i].deviceName));
                sb.AppendLine();
                sb.AppendLine(String.Format("  Drive letter...................: {0}", volumes.info[i].driveLetter));
                sb.AppendLine(String.Format("  Drive type.....................: {0}", volumes.info[i].driveType.ToString()));
                sb.AppendLine(String.Format("  Drive size.....................: {0}", volumes.info[i].totalNumberOfBytes.ToString()));
                sb.AppendLine(String.Format("  Drive free size................: {0}", volumes.info[i].totalNumberOfFreeBytes.ToString()));
                sb.AppendLine(String.Format("  Swap storage status............: {0}", volumes.info[i].swapStorageInfo.status.ToString()));
                sb.AppendLine(String.Format("  Swap storage min size..........: {0}", volumes.info[i].swapStorageInfo.minSize.ToString()));
                sb.AppendLine(String.Format("  Swap storage max size..........: {0}", volumes.info[i].swapStorageInfo.maxSize.ToString()));
                sb.AppendLine(String.Format("  Swap storage recommended size..: {0}", volumes.info[i].swapStorageInfo.recommendedSize.ToString()));
                sb.AppendLine(String.Format("  Swap storage reported free size: {0}", volumes.info[i].swapStorageInfo.reportedFreeSpace.ToString()));
                sb.AppendLine(String.Format("  Swap storage size..............: {0}", volumes.info[i].swapStorageInfo.size.ToString()));
                sb.AppendLine(String.Format("  Swap storage free space........: {0}", volumes.info[i].swapStorageInfo.freeSpace.ToString()));
                sb.AppendLine(String.Format("  Swap storage used space........: {0}", volumes.info[i].swapStorageInfo.usedSpace.ToString()));
            }
            return sb.ToString();
        }

        public static string Generate(RemovableVolumeInfoArray volumes, ushort volumeCount)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < volumeCount; i++)
            {
                sb.AppendLine(String.Format("Removable device {0}: {1}", i + 1, volumes.info[i].deviceName));
                sb.AppendLine();
                sb.AppendLine(String.Format("  Drive letter...................: {0}", volumes.info[i].driveLetter));
                sb.AppendLine(String.Format("  Drive type.....................: {0}", volumes.info[i].driveType.ToString()));
                sb.AppendLine(String.Format("  Drive size.....................: {0}", volumes.info[i].totalNumberOfBytes.ToString()));
                sb.AppendLine(String.Format("  Drive free size................: {0}", volumes.info[i].totalNumberOfFreeBytes.ToString()));
            }
            return sb.ToString();
        }

        public static string Generate(FixedVolumeSwapStorageInfo swapStorageInfo)
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("  Swap storage status............: {0}", swapStorageInfo.status.ToString()));
            sb.AppendLine(String.Format("  Swap storage min size..........: {0}", swapStorageInfo.minSize.ToString()));
            sb.AppendLine(String.Format("  Swap storage max size..........: {0}", swapStorageInfo.maxSize.ToString()));
            sb.AppendLine(String.Format("  Swap storage recommended size..: {0}", swapStorageInfo.recommendedSize.ToString()));
            sb.AppendLine(String.Format("  Swap storage reported free size: {0}", swapStorageInfo.reportedFreeSpace.ToString()));
            sb.AppendLine(String.Format("  Swap storage size..............: {0}", swapStorageInfo.size.ToString()));
            sb.AppendLine(String.Format("  Swap storage free space........: {0}", swapStorageInfo.freeSpace.ToString()));
            sb.AppendLine(String.Format("  Swap storage used space........: {0}", swapStorageInfo.usedSpace.ToString()));

            return sb.ToString();
        }

        public static string Generate(Exception exception)
        {
            return String.Format("Error: {0}", exception.Message);
        }
    }
}
