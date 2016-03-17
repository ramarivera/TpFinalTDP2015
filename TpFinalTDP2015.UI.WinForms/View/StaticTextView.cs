using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using TpFinalTDP2015.UI.Excepciones;

namespace MarrSystems.TpFinalTDP2015.UI.View
{
    public partial class StaticTextView : Form
    {
        public StaticTextView()
        {
            InitializeComponent();
        }

        public void View(StaticTextDTO pStaticText)
        {
            if (pStaticText == null)
            {
                throw new EntidadNulaException("El texto fijo indicado es nulo");
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.txtTitle.Text = pStaticText.Title;
                this.txtDescription.Text = pStaticText.Description;
                this.txtText.Text = pStaticText.Text;
                this.Text = "Texto Fijo: " + pStaticText.Title;
                this.ShowDialog();
            }
        }
    }
}
