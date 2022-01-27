using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mysocietywebsite.Attributes;
using mysocietywebsite.Common.LocalFileSystem;
using mysocietywebsite.Model.Entities;
using mysocietywebsite.Service.Gallery;
using mysocietywebsite.Service.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using mysocietywebsite.Common.ThumbNail;
using System.Linq;
using mysocietywebsite.Common;
using AutoMapper;
using mysocietywebsite.Resource.ResponseModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mysocietywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IGalleryService _galleryService;
        private readonly IRespository.IRepository<User> _userContext;
        private readonly IMapper _mapper;

        public MediaController(IMapper mapper, IGalleryService galleryService, Service.interfaces.IRespository.IRepository<User> userContext)
        {
            _galleryService = galleryService;
            _userContext = userContext;
            _mapper = mapper;
        }

        [HttpGet("gallery")]
        [Authorize]
        public IEnumerable<GalleryResponse> GetAll()
        {
            var user = (Model.Entities.User)HttpContext.Items["User"];
            var gallery = _galleryService.GetAllImageFromGallery(user.Id);
            var result = _mapper.Map<List<GalleryResponse>>(gallery);
            var response = result.Select(s =>
            {
                s.Thumbnail = string.Format("/api/media/file?id={0}&filename={1}&size={2}",s.UserId, s.Name, (int)ThumbnailSize.T72);
                s.ImageUrl = string.Format("/api/media/file?id={0}&filename={1}",s.UserId, s.Name);
                return s;
            });
            return response;
        }

        // POST api/<MediaController>
        [HttpPost("upload/")]
        [AuthorizeAttribute]
        public ObjectResult Post(List<IFormFile> files)
        {
            try
            {
                IEnumerable<Model.Entities.Gallery> gallery = new List<Model.Entities.Gallery>();
                var user = (Model.Entities.User)HttpContext.Items["User"];
                foreach (var file in files)
                {
                    if (file == null || file.Length == 0)
                        return new ObjectResult(new { message = "failed", status = false });

                    var path = MediaFileSystem.GetMediaFilePath(user.Id, file.FileName);
                    string outputThumnailPath = Thumbnail.GetThumbFilePath(user.Id, file.FileName, (int)ThumbnailSize.T72);
                    bool thumnailfilepath = false;
                    if (!System.IO.File.Exists(path))
                    {

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        if (!System.IO.File.Exists(outputThumnailPath))
                        {
                            thumnailfilepath = Thumbnail.CreateThumbnail(path, outputThumnailPath, (int)ThumbnailSize.T72);
                        }
                        var result = _galleryService.SaveImageToGallery(user.Id, file.FileName);
                        gallery.Append(result);

                    }

                }
                return new ObjectResult(new { status = true, mesage = "success", payload = gallery });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { message = ex.Message, status = false });
            }
        }


        [HttpGet("file")]
        public IActionResult Download(Guid id, string filename, int? size)
        {
            if (filename == null)
                return Content("filename not present");
            var user = _userContext.Get(id);

            if (user != null)
            {
                if (size.HasValue && size > 50)
                {
                    string path = Thumbnail.GetThumbFilePath(user.Id, filename,size.Value);
                    if (!System.IO.File.Exists(path)) {
                        return BadRequest("Resource Not Found !!");
                    }
                        var memory = new MemoryStream();
                        using (var stream = new FileStream(path, FileMode.Open))
                        {
                            stream.CopyToAsync(memory);
                        }
                        memory.Position = 0;
                        return File(memory, GetContentType(path), Path.GetFileName(path));
                   
                }
                else
                {

                    var path = MediaFileSystem.GetMediaFilePath(user.Id, filename);

                    if (System.IO.File.Exists(path))
                    {
                        var memory = new MemoryStream();
                        using (var stream = new FileStream(path, FileMode.Open))
                        {
                            stream.CopyToAsync(memory);
                        }
                        memory.Position = 0;
                        return File(memory, GetContentType(path), Path.GetFileName(path));
                    }
                    else
                    {
                        return BadRequest("Resource not available !!");
                    }
                }


            }
            else
            {
                return BadRequest("Invalid Media Request !!");
            }
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
