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
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.UI
{
    public partial class AgregarModificarFuenteRSS : BaseForm, IAddModifyViewForm
    {
        private RssSourceDTO iOriginalRSSSource = new RssSourceDTO();
        private readonly IControllerFactory iFactory;

        public RssSourceDTO RSSSource
        {
            get { return this.iOriginalRSSSource; }
        }
        public AgregarModificarFuenteRSS(IControllerFactory pFactory)
        {
            InitializeComponent();
            this.iFactory = pFactory;
        }

        void IAddModifyViewForm.Add(IDTO pNewRSSSource)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.txtURL.Text = String.Empty;
            this.Text = "Agregar nueva FuenteRSS";
            this.iOriginalRSSSource = (RssSourceDTO)pNewRSSSource;
        }

        void IAddModifyViewForm.Modify(IDTO pRSSSource)
        {
            if (pRSSSource == null)
            {
                throw new EntidadNulaException("La fuente RSS indicada es nula");
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
            try
            {
                if ((String.IsNullOrWhiteSpace(this.txtTitle.Text)))
                {
                    throw new CampoNuloOVacioException("Complete el campo 'Título'");
                }
                else if ((String.IsNullOrWhiteSpace(this.txtDescription.Text)))
                {
                    throw new CampoNuloOVacioException("Complete el campo 'Descripción'");
                }
                else if ((String.IsNullOrWhiteSpace(this.txtURL.Text)))
                {
                    throw new CampoNuloOVacioException("Complete el campo 'URL'");
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
            catch (CampoNuloOVacioException ex)
            {
                MessageBox.Show(ex.Message, "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*
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
            } */  
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
