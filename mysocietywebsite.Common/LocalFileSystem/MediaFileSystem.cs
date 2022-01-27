using mysocietywebsite.Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mysocietywebsite.Common.LocalFileSystem
{
    public class MediaFileSystem
    {
        private static string mediaFolderName = "Media";
 
        public static string GetMediaFilePath(Guid id, string name)
        {
            string fullAbsolutePath = Path.Combine(Directory.GetCurrentDirectory(), mediaFolderName);
            if (!Directory.Exists(fullAbsolutePath))
            {
                Directory.CreateDirectory(fullAbsolutePath);
            }
            string mediaName = string.Format("{0}_{1}", id, name);

            return Path.Combine(fullAbsolutePath, mediaName);


        }
    }
}
