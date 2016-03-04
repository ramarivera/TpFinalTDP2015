using System;
using System.Collections.Generic;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.RSS
{
    /// <summary>
    /// Implementación de base del lector de RSS.
    /// </summary>
    public abstract class RssReader : IRssReader
    {

        public IEnumerable<RssItem> Read(String pUrl)
        {
            if (String.IsNullOrWhiteSpace(pUrl))
            {
                throw new ArgumentException("pUrl");
            }

            return this.Read(new Uri(pUrl));
        }

        public abstract IEnumerable<RssItem> Read(Uri pUrl);

    }
}
