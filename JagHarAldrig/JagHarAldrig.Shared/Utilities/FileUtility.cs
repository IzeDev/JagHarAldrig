using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Linq;
using System.IO;

namespace JagHarAldrig.Utilities
{
    public static class FileUtility
    {
        static string preinstalledFileName;
        static StorageFolder preinstalledStorageFolder;

        static string appRuntimeFileName;
        static StorageFolder appRuntimeStorageFolder;

        static FileUtility()
        {
            preinstalledFileName = @"Assets\Files\Default.txt";
            preinstalledStorageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            appRuntimeFileName = "userStatements.txt";
            appRuntimeStorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        }

        public static async Task<List<string>> ReadBothDefaultAndUserStatementsAsync()
        {
            List<string> tempList = await ReadDefaultStatementsAsync();
            tempList.AddRange(await ReadUserStatementsAsync());
            return tempList;
        }


        public static async Task<List<string>> ReadDefaultStatementsAsync()
        {
            var file = await preinstalledStorageFolder.GetFileAsync(preinstalledFileName);
            IList<string> tempList = await Windows.Storage.FileIO.ReadLinesAsync(file);
            return tempList.ToList();
        }

        public static async Task<List<string>> ReadUserStatementsAsync()
        {
            List<string> userStatements = new List<string>();
            try
            {
                var file = await appRuntimeStorageFolder.GetFileAsync(appRuntimeFileName);
                if (file == null)
                {
                    string oldVersionName = "newStrings.txt";
                    file = await appRuntimeStorageFolder.GetFileAsync(oldVersionName);
                }
                if (file != null)
                {
                    IList<string> tempList = await Windows.Storage.FileIO.ReadLinesAsync(file);
                    userStatements.AddRange(tempList.ToList());                   
                }                
            }
            catch {}
            return userStatements;
        }

        public static async Task SaveUserStatementsAsync(List<string> statements)
        {
            var option = CreationCollisionOption.ReplaceExisting;
            var file = await appRuntimeStorageFolder.CreateFileAsync(appRuntimeFileName, option);
            await Windows.Storage.FileIO.WriteLinesAsync(file, statements);
        }
    }
}
