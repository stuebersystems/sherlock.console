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
using System.Threading;

namespace ConfireSherlockConsole
{
    class Program
    {
        /// <summary>
        /// The main entry point for this application.
        /// </summary>
        static void Main(string[] args)
        {
            // Display infos about this app
            Console.WriteLine(AssemblyInfo.GetTitle());
            Console.WriteLine(AssemblyInfo.GetCopyright());
            Console.WriteLine(AssemblyInfo.GetVersion());
            Console.WriteLine();

            // Create command line object
            var commandLine = new CommandLine(args);

            // If command line has no args display help
            if (!commandLine.HasArgs())
            {
                Console.WriteLine("Syntax:");
                Console.WriteLine("   cfs <command> [<parameters>...]");
                Console.WriteLine();
                Console.WriteLine("Commands and their parameters:");
                Console.WriteLine("   set-licenseInfo <User name> <User site> <Key>");
                Console.WriteLine("   set-licenseInfoFromFile <File name>");
                Console.WriteLine("   get-protectionMode");
                Console.WriteLine("   set-protectionMode {Off|On} <Api-Token>");
                Console.WriteLine("   set-adminPassword <New password> <Api-Token>");
                Console.WriteLine("   set-userPassword <New password> <Api-Token>");
                Console.WriteLine("   get-config");
                Console.WriteLine("   set-bootMode {DiscardChanges|KeepChanges|Inherited} <Api-Token>");
                Console.WriteLine("   set-manualOperations {None|DiscardChanges|ApplyChanges} <Api-Token>");
                Console.WriteLine("   set-autoDiscardTime <Time> <Api-Token>");
                Console.WriteLine("   set-autoDiscardWeekdays {Everyday|{Sun,Mon,Tue,Wed,Thu,Fri,Sat}} <Api-Token>");
                Console.WriteLine("   set-hideConfigCommand {false|true} <Api-Token>");
                Console.WriteLine("   set-hideRebootCommand {false|true} <Api-Token>");
                Console.WriteLine("   set-showTrayIcon {false|true} <Api-Token>");
                Console.WriteLine("   set-removableVolumesAccessMode {ReadWrite|ReadOnly|Invisible} <Api-Token>");
                Console.WriteLine("   set-fixedVolumeProtectionMode <Off|On> <NewMode> <Api-Token>");
                Console.WriteLine("   set-fixedVolumeBootMode <Device name> {DiscardChanges|KeepChanges|Inherited} <Api-Token>");
                Console.WriteLine("   set-fixedVolumeBootAction <Device name> {NoAction|DiscardChanges|ApplyChanges} <Api-Token>");
                Console.WriteLine("   set-fixedVolumeManualOperations <Device name> {None|{DiscardChanges,ApplyChanges}} <Api-Token>");
                Console.WriteLine("   set-fixedVolumeAutoDiscardTime <Device name> <Time> <Api-Token>");
                Console.WriteLine("   set-fixedVolumeAutoDiscardWeekdays <Device name> {Everyday|{Sun,Mon,Tue,Wed,Thu,Fri,Sat}} <Api-Token>");
                Console.WriteLine("   set-removableVolumeAccessMode <Device name> {ReadWrite|ReadOnly|Invisible|Inherited} <Api-Token>");
                Console.WriteLine("   get-fixedVolumes");
                Console.WriteLine("   get-removableVolumes");
                Console.WriteLine("   allocate-swapStorage <Device name> <Size in MB> <Api-Token>");
                Console.WriteLine("   remove-swapStorage <Device name> <Api-Token>");
                Console.WriteLine("   remove-swapStorages <Api-Token>");
                Console.WriteLine("   get-swapStorageInfo <Device name>");
                Console.WriteLine("   prepare-system <Api-Token>");
                Console.WriteLine("   reboot-system <Api-Token>");
                Console.WriteLine();
                Console.WriteLine("Press a key . . .");
                Console.ReadLine();
            }
            else
            {
                try
                {
                    // Process args
                    switch (commandLine.GetArgAsString(0))
                    {
                        case CommandNames.SetLicenseInfo:
                            {
                                var userName = commandLine.GetArgAsString(1);
                                var userSite = commandLine.GetArgAsString(2);
                                var key = commandLine.GetArgAsString(3);

                                Api.SetLicenseInfo(userName, userSite, key);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetLicenseInfoFromFile:
                            {
                                var fileName = commandLine.GetArgAsString(1);

                                Api.SetLicenseInfoFromFile(fileName);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.GetProtectionMode :
                            {
                                ProtectionMode mode;
                            
                                Api.GetProtectionMode(out mode);

                                Console.WriteLine(Output.Generate(mode));

                                break;
                            };
                        case CommandNames.SetProtectionMode :
                            {
                                var protectionMode = commandLine.GetArgAsProtectionMode(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetProtectionMode(securityToken, protectionMode);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetAdminPassword :
                            {
                                var newPassword = commandLine.GetArgAsString(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetAdminPassword(securityToken, newPassword);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetUserPassword :
                            {
                                var newPassword = commandLine.GetArgAsString(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetUserPassword(securityToken, newPassword);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.GetConfiguration :
                            {
                                Configuration configuration;

                                Api.GetConfiguration(out configuration);

                                Console.Write(Output.Generate(configuration));
                            
                                break;
                            };
                        case CommandNames.SetBootMode :
                            {
                                var bootMode = commandLine.GetArgAsFixedVolumeBootMode(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetBootMode(securityToken, bootMode);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetManualOperations :
                            {
                                var manualOperations = commandLine.GetArgAsFixedVolumeManualOperations(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetManualOperations(securityToken, manualOperations);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetAutoDiscardTime :
                            {
                                var timeStamp = commandLine.GetArgAsSystemTime(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetAutoDiscardTime(securityToken, timeStamp);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetAutoDiscardWeekdays :
                            {
                                var daysOfWeek = commandLine.GetArgAsDaysOfWeek(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetAutoDiscardWeekdays(securityToken, daysOfWeek);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetHideConfigCommand :
                            {
                                var hideConfigCommand = commandLine.GetArgAsBool(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetHideRebootCommand(securityToken, hideConfigCommand);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetHideRebootCommand :
                            {
                                var hideRebootCommand = commandLine.GetArgAsBool(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetHideRebootCommand(securityToken, hideRebootCommand);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetShowTrayIcon :
                            {
                                var showTrayIcon = commandLine.GetArgAsBool(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.SetShowTrayIcon(securityToken, showTrayIcon);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetRemovableVolumesAccessMode :
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var accessMode = commandLine.GetArgAsRemovableVolumeAccessMode(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.SetRemovableVolumeAccessMode(securityToken, deviceName, accessMode);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetFixedVolumeProtectionMode :
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var protectionMode = commandLine.GetArgAsFixedVolumeProtectionMode(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.SetFixedVolumeProtectionMode(securityToken, deviceName, protectionMode);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetFixedVolumeBootMode:
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var bootMode = commandLine.GetArgAsFixedVolumeBootMode(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.SetFixedVolumeBootMode(securityToken, deviceName, bootMode);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetFixedVolumeBootAction :
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var bootAction = commandLine.GetArgAsFixedVolumeBootAction(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.SetFixedVolumeBootAction(securityToken, deviceName, bootAction);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetFixedVolumeManualOperations :
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var manualOperations = commandLine.GetArgAsFixedVolumeManualOperations(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.SetFixedVolumeManualOperations(securityToken, deviceName, manualOperations);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetFixedVolumeAutoDiscardTime :
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var timeStamp = commandLine.GetArgAsSystemTime(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.SetFixedVolumeAutoDiscardTime(securityToken, deviceName, timeStamp);

                                break;
                            };
                        case CommandNames.SetFixedVolumeAutoDiscardWeekdays :
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var daysOfWeek = commandLine.GetArgAsDaysOfWeek(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.SetFixedVolumeAutoDiscardWeekdays(securityToken, deviceName, daysOfWeek);
                                
                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.SetRemovableVolumeAccessMode :
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var accessMode = commandLine.GetArgAsRemovableVolumeAccessMode(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.SetRemovableVolumeAccessMode(securityToken, deviceName, accessMode);
                                
                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.GetFixedVolumes :
                            {
                                FixedVolumeInfoArray volumes;
                                ushort volumeCount;

                                Api.GetFixedVolumes(out volumes, out volumeCount);

                                Console.Write(Output.Generate(volumes, volumeCount));

                                break;
                            };
                        case CommandNames.GetRemovableVolumes :
                            {
                                RemovableVolumeInfoArray volumes;
                                ushort volumeCount;

                                Api.GetRemovableVolumes(out volumes, out volumeCount);

                                Console.Write(Output.Generate(volumes, volumeCount));

                                break;
                            };
                        case CommandNames.AllocateSwapStorage:
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var storageSize = commandLine.GetArgAsInt64(2);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(3);

                                Api.StartSwapStorageAllocation(securityToken, deviceName, ref storageSize);

                                Console.Write("Allocating... ");

                                FixedVolumeSwapStorageInfo swapStorageInfo;

                                using (var progress = new ProgressBar())
                                {
                                    do 
                                    { 
                                        Api.GetSwapStorageInfo(deviceName, out swapStorageInfo);
                                        
                                        progress.Report((double)swapStorageInfo.size / (storageSize * 1024 * 1024));
                                        
                                        Thread.Sleep(50);
                                    }
                                    while (swapStorageInfo.status == FixedVolumeSwapStorageStatus.Allocating);                                    
                                }

                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.WriteLine("Success                             ");

                                break;
                            };
                        case CommandNames.RemoveSwapStorage :
                            {
                                var deviceName = commandLine.GetArgAsString(1);
                                var securityToken = commandLine.GetArgAsStringOrEmpty(2);

                                Api.RemoveSwapStorage(securityToken, deviceName);
                                
                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.RemoveSwapStorages :
                            {
                                var deviceName = commandLine.GetArgAsString(1);

                                Api.RemoveSwapStorages(deviceName);
                                
                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.GetSwapStorageInfo :
                            {
                                var deviceName = commandLine.GetArgAsString(1);

                                FixedVolumeSwapStorageInfo swapStorageInfo;

                                Api.GetSwapStorageInfo(deviceName, out swapStorageInfo);
                                
                                Console.Write(Output.Generate(swapStorageInfo));

                                break;
                            };
                        case CommandNames.PrepareSystem:
                            {
                                var securityToken = commandLine.GetArgAsStringOrEmpty(1);

                                Api.PrepareSystem(securityToken);

                                Console.WriteLine("Success");

                                break;
                            };
                        case CommandNames.RebootSystem :
                            {
                                var securityToken = commandLine.GetArgAsStringOrEmpty(1);

                                Api.RebootSystem(securityToken);
                                
                                Console.WriteLine("Success");

                                break;
                            };

                        default:
                            {
                                throw new Exception("Unknown command");
                            };
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(Output.Generate(exception));
                }
            }
        }
    }
}

