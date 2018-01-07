using System;
using System.IO;
using System.Runtime.InteropServices;
using Inshapardaz.Desktop.Common;

namespace Inshapardaz.Desktop.Api.Helpers
{
    public class UserSettings : IProvideUserSettings
    {
        public string UserDataFolder
        {
            get
            {
                var userFolder = Environment.GetEnvironmentVariable(
                                        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                                            "localappdata" : "HOME");
                return EnsureDirectory(Path.Combine(userFolder, ".Inshapardaz"));
            }
        }
        public string DictionariesFolder => EnsureDirectory(Path.Combine(UserDataFolder, "Dictionaries"));
        public string DataFolder => EnsureDirectory(Path.Combine(UserDataFolder, "Data"));

        private string EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

    }
}
