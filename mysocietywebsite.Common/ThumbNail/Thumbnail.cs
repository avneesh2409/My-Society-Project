using mysocietywebsite.Common.Helper;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace mysocietywebsite.Common.ThumbNail
{
    public class Thumbnail
    {
        private static string mediaThumbFolderName = "Thumb";
        public static bool CreateThumbnail(string inputPath, string outputPath, int size) {
            string imgtothumb = string.Format("ffmpeg -i \"{0}\" -ss 00:00:00 -frames:v 1 -s {2}x{3} \"{1}\" ",inputPath,outputPath,size,size);
            string vediotothumb = string.Format("ffmpeg  -itsoffset -1  -i \"{0}\" -vcodec mjpeg -vframes 1 -an -f rawvideo -s {2}x{3} \"{1}\" ", inputPath, outputPath, size, size);
            string ext = FileExtension.GetFileExtension(inputPath);
            ProcessStartInfo startInfo;

            try
            {
                if (Constants.imageExtensions.Where(e => ext.Equals(e, StringComparison.OrdinalIgnoreCase)).Any())
                {
                    startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd.exe",
                        Arguments = "/C " + imgtothumb
                    };
                }
                else
                {
                    startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd.exe",
                        Arguments = "/C " + vediotothumb
                    };
                }
                using (var process = new Process
                {
                    StartInfo = startInfo
                })
                {
                    process.Start();
                    process.WaitForExit(5000);
                }
                    return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
        public static string GetThumbFilePath(Guid id, string filename, int size)
        {
            string ext = FileExtension.GetFileExtension(filename);
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            string thumbPath = "";

            string thumbFolderPath = Path.Combine(Directory.GetCurrentDirectory(), mediaThumbFolderName);
            if (!Directory.Exists(thumbFolderPath))
            {
                Directory.CreateDirectory(thumbFolderPath);
            }
            string thumbFileName;
            if (Constants.imageExtensions.Where(e => ext.Equals(e, StringComparison.OrdinalIgnoreCase)).Any())
            {
                thumbFileName = string.Format("{0}_{1}_{2}.{3}", id, nameWithoutExtension, size, ext);
                thumbPath = Path.Combine(thumbFolderPath, thumbFileName);
            }
            else
            {
                thumbFileName = string.Format("{0}_{1}_{2}.{3}", id, nameWithoutExtension, size, "png");
                thumbPath = Path.Combine(thumbFolderPath, thumbFileName);
            }

            return thumbPath;
        }
    }
}
