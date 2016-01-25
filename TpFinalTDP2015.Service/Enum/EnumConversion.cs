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
        internal static Service.Enum.Days Days(ResolutionContext arg)
        {
            Model.Enum.Days value = (Model.Enum.Days)arg.SourceValue;
            switch (value)
            {
                case Model.Enum.Days.Domingo:
                    return Service.Enum.Days.Domingo;
                case Model.Enum.Days.Lunes:
                    return Service.Enum.Days.Lunes;
                case Model.Enum.Days.Martes:
                    return Service.Enum.Days.Martes;
                case Model.Enum.Days.Miercoles:
                    return Service.Enum.Days.Miercoles;
                case Model.Enum.Days.Jueves:
                    return Service.Enum.Days.Jueves;
                case Model.Enum.Days.Viernes:
                    return Service.Enum.Days.Viernes;
                case Model.Enum.Days.Sabado:
                    return Service.Enum.Days.Sabado;
                default:
                    return Service.Enum.Days.Domingo;
            }
        }

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
