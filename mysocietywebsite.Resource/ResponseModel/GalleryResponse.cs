using mysocietywebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Resource.ResponseModel
{
    public class GalleryResponse:BaseEntity
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string ImageUrl { get; set; }
        public Guid UserId { get; set; }
    }
}
