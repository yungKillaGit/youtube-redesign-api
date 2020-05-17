using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Youtube.Api.Infrastructure.Services
{
    public static class FileEncoder
    {
        public static string EncodeFile(string relativePath, string webRootPath)
        {
            string filePath = GetPhysicalPathFromRelativeUrl(relativePath, webRootPath);
            return Convert.ToBase64String(File.ReadAllBytes(filePath));
        }

        private static string GetPhysicalPathFromRelativeUrl(string url, string webRootPath)
        {
            var path = Path.Combine(webRootPath, url.TrimStart('/').Replace("/", "\\"));
            return path;
        }
    }
}
