using System;
using System.Text;
using System.Linq;
using System.Globalization;

using Microsoft.EntityFrameworkCore;

using MusicHub.Data;
using MusicHub.Initializer;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            // int producerId = int.Parse(Console.ReadLine());

            var albumsInfo = ExportAlbumsInfo(context, 9);
            Console.WriteLine(albumsInfo);
        }



        private static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.
                Producers
                .FirstOrDefault(i => i.Id == producerId)
                .Albums
                .Select(a => new
                {
                    AlbumName = a.Name,
                    AlbumRealeaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = $"{s.Price}",
                        SongWriterName = s.Writer.Name
                    })
                        .OrderByDescending(n => n.SongName)
                        .ThenBy(w => w.SongWriterName)
                        .ToList(),
                    TotalAlbumPrice = $"{a.Price}",
                })
                 .OrderByDescending(a => a.TotalAlbumPrice)
                 .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var album in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.AlbumRealeaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}");

                int counter = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb
                        .AppendLine($"---#{counter}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.SongPrice}")
                        .AppendLine($"---Writer: {song.SongWriterName}");
                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}

