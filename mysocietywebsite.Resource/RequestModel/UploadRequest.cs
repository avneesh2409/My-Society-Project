using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Resource.RequestModel
{
    public class UploadRequest
    {
        public List<IFormFile> Files { get; set; }
    }
}
