namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context
               .Producers
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
                       SongPrice = s.Price,
                       SongWriterName = s.Writer.Name
                   })
                       .OrderByDescending(n => n.SongName)
                       .ThenBy(w => w.SongWriterName)
                       .ToList(),
                   TotalAlbumPrice = a.Price,
               })
                .OrderByDescending(a => a.TotalAlbumPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var album in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.AlbumRealeaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int counter = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb
                        .AppendLine($"---#{counter}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.SongPrice:F2}")
                        .AppendLine($"---Writer: {song.SongWriterName}");
                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
