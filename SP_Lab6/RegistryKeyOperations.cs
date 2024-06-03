using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Lab6
{
    internal static class RegistryKeyOperations
    {
        public static string GetPath(string registryKeyPath) => registryKeyPath[(registryKeyPath.IndexOf('\\') + 1)..];

        public static RegistryHive GetBaseKeyFromSubKey(string registryKeyPath)
        {
            string hiveName = registryKeyPath.IndexOf('\\') != -1 ? registryKeyPath[..registryKeyPath.IndexOf('\\')] : registryKeyPath;

            return hiveName switch
            {
                "HKEY_CLASSES_ROOT" => RegistryHive.ClassesRoot,
                "HKEY_CURRENT_USER" => RegistryHive.CurrentUser,
                "HKEY_LOCAL_MACHINE" => RegistryHive.LocalMachine,
                "HKEY_USERS" => RegistryHive.Users,
                "HKEY_CURRENT_CONFIG" => RegistryHive.CurrentConfig,
            };
        }

        public static string GetRegistryValue(object value, RegistryValueKind type)
        {
            string result = string.Empty;

            if (type == RegistryValueKind.Binary || type == RegistryValueKind.None)
            {
                byte[] bytes = value as byte[];

                foreach (var @byte in bytes)
                {
                    result = string.Concat(result, @byte.ToString("D2"), " ");
                }

                if (result.Length == 0) return result;
                return result[..^1];
            }

            if (type == RegistryValueKind.DWord)
            {
                int dwordValue = (int)value;
                return string.Concat("0x", dwordValue.ToString("X8").ToLower(), " ", $"({dwordValue})");
            }

            if (type == RegistryValueKind.QWord)
            {
                long qwordValue = (long)value;
                return string.Concat("0x", qwordValue.ToString("X8").ToLower(), " ", $"({qwordValue})");
            }

            return value.ToString();
        }

        public static string GetRegistryType(RegistryValueKind type) => type switch
        {
            RegistryValueKind.String => "REG_SZ",
            RegistryValueKind.ExpandString => "REG_EXPAND_SZ",
            RegistryValueKind.Binary => "REG_BINARY",
            RegistryValueKind.DWord => "REG_DWORD",
            RegistryValueKind.MultiString => "REG_MULTI_SZ",
            RegistryValueKind.QWord => "REG_QWORD",
            RegistryValueKind.Unknown => "REG_RESOURCE_LIST",
            _ => "REG_NONE",
        };
    }
}
