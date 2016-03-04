using Common.Logging;
using System;
using System.Collections.Generic;
using System.Xml;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.RSS
{
    /// <summary>
    /// Lector de RSS que procesa directamente el XML en bruto de la fuente.
    /// </summary>
    public class RawXmlRssReader : RssReader
    {

        /// <summary>
        /// Definición de logger para todas las instancias de la clase.
        /// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger<RawXmlRssReader>();

        public override IEnumerable<RssItem> Read(Uri pUrl)
        {
            if (pUrl == null)
            {
                throw new ArgumentNullException("pUrl");
            }

            // Se recupera el XML desde la URL, y se parsea el mismo para obtener los diferentes ítems. El modelo de XML
            // utilizado es el siguiente (http://www.w3schools.com/xml/xml_rss.asp):
            //<?xml version="1.0" encoding="UTF-8"?>
            //<rss version = "2.0">
            //  <channel>
            //    <title> W3Schools Home Page</title>
            //    <link> http://www.w3schools.com</link>
            //    <description> Free web building tutorials </description>
            //    <item>
            //        <title>RSS Tutorial</title>
            //        <link>http://www.w3schools.com/xml/xml_rss.asp</link>
            //        <description> New RSS tutorial on W3Schools</ description >
            //    </item>
            //    <item>
            //    <title>XML Tutorial</title>
            //        <link>http://www.w3schools.com/xml</link>
            //        <description> New XML tutorial on W3Schools</description>
            //    </item>
            //  </channel>
            //</rss>

            XmlTextReader mXmlReader = new XmlTextReader(pUrl.AbsoluteUri);

            XmlDocument mRssXmlDocument = new XmlDocument();

            cLogger.Info("Obteniendo feeds...");
            cLogger.DebugFormat("Obteniendo feeds desde {0}...", pUrl.AbsoluteUri);

            mRssXmlDocument.Load(mXmlReader);

            cLogger.Info("Ha finalizado la obtención de feeds.");
            cLogger.Debug(pLogger => pLogger("Se ha obtenido el siguiente XML: {0}", mRssXmlDocument.OuterXml));
            IList<RssItem> mRssItems = new List<RssItem>();

            cLogger.Info("Adaptando feeds...");
            foreach (XmlNode bRssXmlItem in mRssXmlDocument.SelectNodes("//channel/item"))
            {
                mRssItems.Add(new RssItem
                {
                    Title = RawXmlRssReader.GetXmlNodeValue<String>(bRssXmlItem, "title"),
                    Description = RawXmlRssReader.GetXmlNodeValue<String>(bRssXmlItem, "description"),
                    URL = RawXmlRssReader.GetXmlNodeValue<String>(bRssXmlItem, "link"),
                    PublicationDate = RawXmlRssReader.GetXmlNodeValue<DateTime?>(bRssXmlItem, "pubDate")
                });
            }

            cLogger.Info("Devolviendo feeds adaptados...");
            return mRssItems;
        }

        private static TResult GetXmlNodeValue<TResult>(XmlNode pParentNode, String pChildNodeName)
        {
            if (pParentNode == null)
            {
                throw new ArgumentNullException("pParentNode");
            }

            if (String.IsNullOrWhiteSpace(pChildNodeName))
            {
                throw new ArgumentException("pChildNodeName");
            }
            
            // Inicialmente se devuelve el valor por defecto del tipo genérico. Si es un objeto, este valor es null, en caso contrario depende del tipo.
            TResult mResult = default(TResult);

            // Tipo utilizado para la conversión final. Por defecto va a ser el mismo tipo genérico indicado.
            Type mConvertToType = typeof(TResult);

            XmlNode mChildNode = pParentNode.SelectSingleNode(pChildNodeName);

            // Si el nodo existe, entonces se obtiene el valor del texto del mismo para convertirlo al tipo genérico indicado.
            if (mChildNode != null)
            {
                // Se comprueba si el tipo es Nullable, ya que en dicho caso se debe convertir al tipo subyacente y no directamente al Nullable.
                if (Nullable.GetUnderlyingType(mConvertToType) != null)
                {
                    mConvertToType = Nullable.GetUnderlyingType(mConvertToType);
                }

                // Se realiza la conversión del texto del nodo al tipo adecuado, ya sea el tipo genérico indicado o bien al tipo subyacente del Nullable.
                mResult = (TResult)Convert.ChangeType(mChildNode.InnerText.Trim(), mConvertToType);
            }

            return mResult;
        }

    }
}
