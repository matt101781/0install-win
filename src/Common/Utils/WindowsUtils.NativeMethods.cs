﻿/*
 * Copyright 2006-2011 Bastian Eicher
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Common.Utils
{
    static partial class WindowsUtils
    {
        [SuppressUnmanagedCodeSecurity]
        private static class SafeNativeMethods
        {
            // Command-line arguments
            [DllImport("shell32", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);


            // Platform
            [DllImport("kernel32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsWow64Process([In] IntPtr hProcess, [Out, MarshalAs(UnmanagedType.Bool)] out bool lpSystemInfo);


            // Foreground window
            [DllImport("user32", SetLastError = true)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);
        }

        [SuppressUnmanagedCodeSecurity]
        private static class UnsafeNativeMethods
        {
            // Command-line arguments
            [DllImport("kernel32")]
            public static extern IntPtr LocalFree(IntPtr hMem);


            // Taskbar
            [DllImport("shell32", SetLastError = true)]
            public static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string appID);


            // Properties
            [DllImport("shell32", SetLastError = true)]
            public static extern int SHGetPropertyStoreForWindow(IntPtr hwnd, ref Guid iid, [Out, MarshalAs(UnmanagedType.Interface)] out IPropertyStore propertyStore);

            [DllImport("ole32", PreserveSig = false)]
            internal extern static void PropVariantClear([In, Out] ref PropertyVariant pvar);


            // Mutex
            [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);

            [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr OpenMutex(UInt32 desiredAccess, bool inheritHandle, string name);

            [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern int CloseHandle(IntPtr hObject);


            // Shell
            [DllImport("shell32", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

            [DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr SendMessageTimeout(IntPtr windowHandle, uint msg, UIntPtr wParam, string lParam, uint flags, uint timeout, out UIntPtr lpdwResult);
        }
    }
}