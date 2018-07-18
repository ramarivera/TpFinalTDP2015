using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Enum;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class SlideTransitionProfile : Profile
    {
        public SlideTransitionProfile()
        {
            CreateMap<Model.Enum.SlideTransition, BusinessLogic.Enum.SlideTransition>()
                .ConstructUsing(EnumConversion.SlideTransition);
        }
    }
}
