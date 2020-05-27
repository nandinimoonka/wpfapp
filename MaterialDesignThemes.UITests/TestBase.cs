﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace MaterialDesignThemes.UITests
{
    public class TestBase
    {
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        protected WindowsDriver<WindowsElement> Driver { get; private set; }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        private bool AppHasLaunched { get; set; }

        protected async Task LaunchApplication()
        {
            if (AppHasLaunched) return;

            IntPtr mainWindowHandle = await StartApp();

            StartWinAppDriver();

            var appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");
            appOptions.AddAdditionalCapability("appTopLevelWindow", mainWindowHandle.ToInt32().ToString("x"));

            Driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);

            WindowsElement? element = Driver.FindElementByName("Material Design In XAML Toolkit");

            Assert.NotNull(element);

            AppHasLaunched = true;
        }

        private static async Task<IntPtr> StartApp()
        {
            string workingDirectory = Path.GetFullPath(@"..\..\..\..\MainDemo.Wpf\bin\Debug\netcoreapp3.1\");
            var processInfo = new ProcessStartInfo
            {
                WorkingDirectory = workingDirectory,
                FileName = Path.Combine(workingDirectory, "MaterialDesignDemo.exe")
            };

            Process appProcess = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processInfo.FileName))
                .FirstOrDefault(x => !x.HasExited && x.MainWindowHandle != IntPtr.Zero);
            if (appProcess is null)
            {
                if (!File.Exists(Path.Combine(processInfo.WorkingDirectory, processInfo.FileName)))
                {
                    throw new FileNotFoundException($"{processInfo.FileName} was not in expected directory: {processInfo.WorkingDirectory}");
                }
                appProcess = Process.Start(processInfo);

                //Forcing the the driver to wait for the application
                await Task.Delay(TimeSpan.FromSeconds(2));
            }

            return appProcess.MainWindowHandle;
        }

        private static void StartWinAppDriver()
        {
            Process[] winappProcess = Process.GetProcessesByName("WinAppDriver");
            if (winappProcess.Length == 0)
            {
                //Search default install location on all drives
                foreach(var drive in Environment.GetLogicalDrives())
                {
                    var path = @$"{drive}Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                        return;
                    }
                }
                throw new InvalidOperationException("WinAppDriver was not found.");
            }
        }
    }
}
