using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// The UI is block because of using Synchronous code...
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event Handler
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowImage(Image1, "https://http.cat/301");
            ShowImage(Image2, "https://http.cat/404");
            ShowImage(Image3, "https://http.cat/500");
            ShowImage(Image4, "https://http.cat/200");
            ShowImage(Image5, "https://http.cat/403");
            ShowImage(Image6, "https://http.cat/307");
        }

        private void ShowImage(Image image, string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            byte[] imageBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            image.Source = LoadImage(imageBytes);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
