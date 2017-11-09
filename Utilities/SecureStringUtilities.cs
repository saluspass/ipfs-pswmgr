﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace ipfs_pswmgr
{
    internal static class SecureStringUtilities
    {
        public static string ConvertToUnsecureString(this SecureString secureString)
        {
            if (secureString == null)
                throw new ArgumentNullException("secureString");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static SecureString ConvertToSecureString(this string unsecureString)
        {
            if (unsecureString == null)
                throw new ArgumentNullException("unsecureString");

            SecureString ss = new SecureString();
            foreach(char c in unsecureString)
            {
                ss.AppendChar(c);
            }

            return ss;
        }
    }
}
