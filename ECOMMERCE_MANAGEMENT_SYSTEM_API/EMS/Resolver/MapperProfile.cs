using AutoMapper;

namespace ECommerce.HOST.Resolver
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            #region Product Map

            CreateMap<DAL.Entity.Product, HOST.Modals.Request.AddProduct>().ReverseMap();
            CreateMap<DAL.Entity.Product, HOST.Modals.Request.UpdateProduct>().ReverseMap();
            CreateMap<DAL.Entity.Product, HOST.Modals.Response.Product>().ReverseMap();

            #endregion

            #region Category Map

            CreateMap<DAL.Entity.Category, HOST.Modals.Response.Category>().ReverseMap();
            
            #endregion
        }
    }
}
