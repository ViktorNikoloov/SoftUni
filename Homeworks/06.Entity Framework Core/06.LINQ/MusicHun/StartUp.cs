using MusicHub.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new MusicHubDbContext();
            //dbContext.Database.EnsureCreated();
           // int producerId = int.Parse(Console.ReadLine());

            var albumsInfo = ExportAlbumsInfo(db, 9);
            Console.WriteLine(albumsInfo);
        }


        private static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.Albums
                 .Where(p => p.ProducerId == producerId)
                 .Select(a => new
                 {
                     AlbumName = a.Name,
                     AlbumRealeaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                     ProducerName = a.Producer.Name,
                     AlbumSongs = a.Songs.Select(s => new
                     {
                         SongName = s.Name,
                         SongPrice = $"{s.Price:F2}",
                         SongWriterName = s.Writer.Name
                     })
                        .OrderByDescending(n => n.SongName)
                        .ThenBy(w => w.SongWriterName)
                        .ToList(),
                     TotalAlbumPrice = $"{a.Price:F2}",
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

                sb
                    .AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
