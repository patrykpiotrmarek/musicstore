using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Models;
using Newtonsoft.Json;

namespace ModelToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var albums = SampleData.GetAlbums(string.Empty, SampleData.Genres, SampleData.Artists);
            var json = JsonConvert.SerializeObject(albums);
            Console.Write(json);
        }
    }
}
