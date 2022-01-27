using AutoMapper;
using mysocietywebsite.Model.Entities;
using mysocietywebsite.Resource.ResponseModel;
using System.Collections.Generic;

namespace mysocietywebsite.Automapper
{
    public class ObjectMapper : Profile
    {
        public ObjectMapper()
        {
            CreateMap<GalleryResponse, Gallery>();
            CreateMap<Gallery, GalleryResponse>();
        }
    }
}
