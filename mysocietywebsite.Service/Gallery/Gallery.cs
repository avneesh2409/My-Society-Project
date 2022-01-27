using mysocietywebsite.Common.LocalFileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static mysocietywebsite.Service.interfaces.IRespository;

namespace mysocietywebsite.Service.Gallery
{
    public class GalleryService : IGalleryService
    {
        private readonly IRepository<Model.Entities.Gallery> _gallery;

        public GalleryService(IRepository<Model.Entities.Gallery> gallery)
        {
            _gallery = gallery;
        }

        public List<Model.Entities.Gallery> GetAllImageFromGallery(Guid id)
        {
            return _gallery.GetAll().Where(e=>e.UserId.Equals(id)).ToList();
        }

        public Model.Entities.Gallery GetImageFromGallery(Guid id)
        {
            throw new NotImplementedException();
        }

        public Model.Entities.Gallery SaveImageToGallery(Guid userId,string path)
        {
            var gal = _gallery.Insert(new Model.Entities.Gallery
            {
                Id=Guid.NewGuid(),
                Name = path,
                CreatedBy = userId,
                ModifiedBy = userId,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                IsActive = true,
                IsDeleted= false,
                UserId = userId
            });
            _gallery.Save();
            return gal;
        }
    }
}
