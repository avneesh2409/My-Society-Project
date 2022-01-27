using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mysocietywebsite.Common.Helper
{
    public class FileExtension
    {
        public static string GetFileExtension(string filePath) {
            string extwithdot = Path.GetExtension(filePath);
            if (extwithdot != null)
            {
                return extwithdot.Replace(".", "");
            }
            else {
                throw new NullReferenceException("extension not find for the file !!");
            }
        }
    }
}
