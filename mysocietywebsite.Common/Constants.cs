using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Common
{
    public class Constants
    {
        public const string DefaultConnection = "DefaultConnection";
        public const string SECRET_KEY = "AppSettings";

        public static string[] imageExtensions = new string[] {"JPG",
                                            "PNG",
                                            "GIF",
                                            "WEBP",
                                            "TIFF",
                                            "PSD",
                                            "RAW",
                                            "BMP" };

        
    }
    public enum ThumbnailSize { 
        T260 = 260,
        T72 = 72,
        T120 = 120,
        T240 = 240,
        T320 = 320,
        T450 = 450,
        T600 = 600
    }
}
