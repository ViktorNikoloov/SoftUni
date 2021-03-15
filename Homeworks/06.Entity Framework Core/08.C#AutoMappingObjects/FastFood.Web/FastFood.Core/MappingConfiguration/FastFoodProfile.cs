namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.Controllers;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Models;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(cm => cm.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();
        }
    }
}
