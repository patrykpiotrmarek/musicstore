using System;
using System.IO;
using System.Reflection;
using MusicStore.Models;
using Newtonsoft.Json;

namespace ModelToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteJsonToFile(SampleData.GetAlbums(string.Empty, SampleData.Genres, SampleData.Artists), "albums.json");
            WriteJsonToFile(SampleData.Genres.Values, "genres.json");
            WriteJsonToFile(SampleData.Artists.Values, "artists.json");
        }

        private static void WriteJsonToFile(object modelToSerialize, string fileName)
        {
            var json = JsonConvert.SerializeObject(modelToSerialize);

            using (var writer = new StreamWriter(GetPathToSave(fileName)))
            {
                writer.Write(json);
            }
        }

        private static string TargetDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                // debug -> bin -> ModelToJson -> MusicStoreModel -> musicstore
                return Directory.GetParent(path).Parent.Parent.Parent.Parent.FullName;
            }
        }

        private static string GetPathToSave(string fileName)
        {
            return string.Format(@"{0}\{1}", TargetDirectory, fileName);
        }
    }
}
