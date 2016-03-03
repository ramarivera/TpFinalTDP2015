using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.BusinessLogic.Enum
{
    public class EnumConversion
    {
        internal static BusinessLogic.Enum.Days ModelDaysToServiceDays(ResolutionContext arg)
        {
            Model.Enum.Days value = (Model.Enum.Days)arg.SourceValue;
            switch (value)
            {
                case Model.Enum.Days.Domingo:
                    return BusinessLogic.Enum.Days.Domingo;
                case Model.Enum.Days.Lunes:
                    return BusinessLogic.Enum.Days.Lunes;
                case Model.Enum.Days.Martes:
                    return BusinessLogic.Enum.Days.Martes;
                case Model.Enum.Days.Miercoles:
                    return BusinessLogic.Enum.Days.Miercoles;
                case Model.Enum.Days.Jueves:
                    return BusinessLogic.Enum.Days.Jueves;
                case Model.Enum.Days.Viernes:
                    return BusinessLogic.Enum.Days.Viernes;
                case Model.Enum.Days.Sabado:
                    return BusinessLogic.Enum.Days.Sabado;
                default:
                    return BusinessLogic.Enum.Days.Domingo;
            }
        }

        internal static Model.Enum.Days ServiceDaysToModelDays(ResolutionContext arg)
        {
            BusinessLogic.Enum.Days value = (BusinessLogic.Enum.Days)arg.SourceValue;
            switch (value)
            {
                case BusinessLogic.Enum.Days.Domingo:
                    return Model.Enum.Days.Domingo;
                case BusinessLogic.Enum.Days.Lunes:
                    return Model.Enum.Days.Lunes;
                case BusinessLogic.Enum.Days.Martes:
                    return Model.Enum.Days.Martes;
                case BusinessLogic.Enum.Days.Miercoles:
                    return Model.Enum.Days.Miercoles;
                case BusinessLogic.Enum.Days.Jueves:
                    return Model.Enum.Days.Jueves;
                case BusinessLogic.Enum.Days.Viernes:
                    return Model.Enum.Days.Viernes;
                case BusinessLogic.Enum.Days.Sabado:
                    return Model.Enum.Days.Sabado;
                default:
                    return Model.Enum.Days.Domingo;
            }
        }

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
