using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Service.Enum
{
    public class EnumConversion
    {

        internal static Service.Enum.SlideTransition SlideTransition(ResolutionContext arg)
        {
            Model.Enum.SlideTransition value = (Model.Enum.SlideTransition)arg.SourceValue;
            switch (value)
            {
                case Model.Enum.SlideTransition.Default:
                    return Service.Enum.SlideTransition.Default;
                case Model.Enum.SlideTransition.FadeIn:
                    return Service.Enum.SlideTransition.FadeIn; 
                case Model.Enum.SlideTransition.FadeOut:
                    return Service.Enum.SlideTransition.FadeOut;
                default:
                    return Service.Enum.SlideTransition.Default;
            }
        }
    }
}
