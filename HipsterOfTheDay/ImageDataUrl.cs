using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HipsterOfTheDay
{
    public interface IImageDataUrl
    {
        byte[] Bytes { get; }
        string MimeType { get; set; }
        string Format { get; }
        string SaveTo(string folder);
    }

    public class ImageDataUrl : IImageDataUrl
    {
        public ImageDataUrl(string dataUrl)
        {
            var match = _regex.Match(dataUrl);
            MimeType = match.Groups["mimeType"].Value;
            Format = match.Groups["mimeSubType"].Value;
            Bytes = Convert.FromBase64String(match.Groups["data"].Value);
        }

        public byte[] Bytes { get; protected set; }
        public string MimeType { get; set; }
        public string Format { get; protected set; }

        public string SaveTo(string folder)
        {
            var fileName = Guid.NewGuid().ToString() + "." + Format;
            var fullPath = Path.Combine(folder, fileName);

            using (var file = File.OpenWrite(fullPath))
            {
                file.Write(Bytes, 0, Bytes.Length);
            }
            return fileName;
        }

        private static readonly Regex _regex = new Regex(
            @"data:(?<mimeType>[\w]+)/(?<mimeSubType>[\w]+);\w+,(?<data>.*)",
            RegexOptions.Compiled
        );
    }
}