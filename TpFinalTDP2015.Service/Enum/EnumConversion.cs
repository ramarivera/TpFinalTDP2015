using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Enum
{
    public class EnumConversion
    {
        internal static BusinessLogic.Enum.SlideTransition SlideTransition(ResolutionContext arg)
        {
            Model.Enum.SlideTransition value = (Model.Enum.SlideTransition)arg.SourceValue;
            switch (value)
            {
                case Model.Enum.SlideTransition.Default:
                    return BusinessLogic.Enum.SlideTransition.Default;
                case Model.Enum.SlideTransition.FadeIn:
                    return BusinessLogic.Enum.SlideTransition.FadeIn; 
                case Model.Enum.SlideTransition.FadeOut:
                    return BusinessLogic.Enum.SlideTransition.FadeOut;
                default:
                    return BusinessLogic.Enum.SlideTransition.Default;
            }
        }
    }
}
