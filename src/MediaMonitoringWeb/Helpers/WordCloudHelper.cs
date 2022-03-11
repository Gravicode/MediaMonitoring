using System.Drawing;

namespace MediaMonitoringWeb.Helpers
{
    public class WordCloudHelper
    {
        public static byte[] GetWordCloud(List<String> words, List<int> freqs,int Width=800,int Height=600)
        {
            // Install NuGet WordCloud 1.0.0.3
            // include using for WordCloud and System.Drawing.
            WordCloud.WordCloud wc = new WordCloud.WordCloud(Width,Height, true);
            Image img = wc.Draw(words, freqs);
            MemoryStream oMemoryStream = new MemoryStream();
            img.Save(oMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] oBytes = oMemoryStream.GetBuffer();
            return oBytes;
           
        }

        public static string GetWordCloudBase64(List<String> words, List<int> freqs, int Width = 800, int Height = 600)
        {
            var temp = GetWordCloud(words,freqs, Width,  Height);
            string base64String = Convert.ToBase64String(temp, 0, temp.Length);
            var generated = "data:image/png;base64," + base64String;
            return generated;
        }
    }
}
