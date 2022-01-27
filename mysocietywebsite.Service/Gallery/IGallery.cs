using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Service.Gallery
{
    public interface IGalleryService
    {
        Model.Entities.Gallery SaveImageToGallery(Guid userId, string path);
        Model.Entities.Gallery GetImageFromGallery(Guid id);

        List<Model.Entities.Gallery> GetAllImageFromGallery(Guid id);
    }
}
