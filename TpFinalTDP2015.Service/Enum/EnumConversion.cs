namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Enum
{
    public class EnumConversion
    {
        public static BusinessLogic.Enum.SlideTransition SlideTransition(Model.Enum.SlideTransition source)
        {
            switch (source)
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
