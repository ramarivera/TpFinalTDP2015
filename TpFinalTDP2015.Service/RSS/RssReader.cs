using System;
using System.Collections.Generic;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.RSS
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
