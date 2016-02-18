using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.UI.View
{
    public partial class RssSourceView : Form
    {
        public RssSourceView()
        {
            InitializeComponent();
        }

        public void View(RssSourceDTO pRSSSource)
        {
            if (pRSSSource == null)
            {
                throw new ArgumentNullException();
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.txtTitle.Text = pRSSSource.Title;
                this.txtDescription.Text = pRSSSource.Description;
                this.txtURL.Text = pRSSSource.URL;
                this.Text = "Fuente Rss: "+ pRSSSource.Title;
                this.ShowDialog();
            }
        }
    }
}
