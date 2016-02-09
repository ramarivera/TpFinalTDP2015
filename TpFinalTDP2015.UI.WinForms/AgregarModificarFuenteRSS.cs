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

namespace TpFinalTDP2015.UI
{
    public partial class AgregarModificarFuenteRSS : BaseForm, IAddModifyViewForm
    {
        private RssSourceDTO iOriginalRSSSource = new RssSourceDTO();

        public RssSourceDTO RSSSource
        {
            get { return this.iOriginalRSSSource; }
        }
        public AgregarModificarFuenteRSS()
        {
            InitializeComponent();
        }

        void IAddModifyViewForm.Agregar(IDTO pNewRSSSource)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtURL.Text = String.Empty;
            this.Text = "Agregar nueva FuenteRSS";
            this.iOriginalRSSSource = (RssSourceDTO)pNewRSSSource;
        }

        void IAddModifyViewForm.Modificar(IDTO pRSSSource)
        {
            if (pRSSSource == null)
            {
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.iOriginalRSSSource = (RssSourceDTO)pRSSSource;
                this.txtTitle.Text = iOriginalRSSSource.Title;
                this.txtDescription.Text = iOriginalRSSSource.Description;
                this.txtURL.Text = iOriginalRSSSource.URL;
                this.Text = "Modificar FuenteRSS";
            }   
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrWhiteSpace(this.txtTitle.Text)))
            {
                MessageBox.Show("Complete el campo 'Título'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((String.IsNullOrWhiteSpace(this.txtDescription.Text)))
            {
                MessageBox.Show("Complete el campo 'Descripción'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((String.IsNullOrWhiteSpace(this.txtURL.Text)))
            {
                MessageBox.Show("Complete el campo 'URL'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.iOriginalRSSSource.Title = this.txtTitle.Text;
                this.iOriginalRSSSource.Description = this.txtDescription.Text;
                this.iOriginalRSSSource.URL = this.txtURL.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show(
                                        "¿Desea salir sin guardar los cambios?",
                                        "Salir",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            switch (opcion)
            {
                case DialogResult.Yes:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
