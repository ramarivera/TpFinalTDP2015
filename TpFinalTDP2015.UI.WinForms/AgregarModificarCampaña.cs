using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Comparers;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.UI
{
    public partial class AgregarModificarCampaña : Form, IAddModifyViewForm
    {
        DateIntervalController dateIntervalController;
        //TODO ajustar ventana para poder agregar intervalos y slides
        private CampaignDTO iOriginalCampaign = new CampaignDTO();

        public CampaignDTO Campaign
        {
            get { return this.iOriginalCampaign; }
            //TODO Para que se usa esta propiedad? o quedo para usarse en algun momento jaja? porque es public?
        }

        
        public AgregarModificarCampaña()
        {
            InitializeComponent();
        }

        private DateIntervalController DateIntervalController
        {
            get
            {
                return (DateIntervalController)
                    ServiceFactory.
                    GetService<DateIntervalDTO>();
            }
        }

        void IAddModifyViewForm.Agregar(IDTO pNewCampaign)
        {
            this.txtTitle.Text = String.Empty;
            this.txtDescription.Text = String.Empty;
            this.Text = "Agregar nueva Campaña";
            this.iOriginalCampaign = (CampaignDTO)pNewCampaign;
        }

        void IAddModifyViewForm.Modificar(IDTO pCampaign)
        {
            if (pCampaign == null)
            {
                throw new ArgumentNullException();
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.iOriginalCampaign = (CampaignDTO)pCampaign;
                this.txtTitle.Text = iOriginalCampaign.Name;
                this.txtDescription.Text = iOriginalCampaign.Description;
                this.Text = "Modificar Campaña";
            }
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrWhiteSpace(this.txtTitle.Text)))
            {
                MessageBox.Show("Complete el campo 'Título'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((String.IsNullOrWhiteSpace(this.txtDescription.Text)))
            {
                MessageBox.Show("Complete el campo 'Descripción'", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.iOriginalCampaign.Name = this.txtTitle.Text;
                this.iOriginalCampaign.Description = this.txtDescription.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void btnAddSlide_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (this.dateIntervalController = this.DateIntervalController)
                {
                    //TODO ponerle a los campos el prefijo i
                    iOriginalCampaign.ActiveIntervals = new List<DateIntervalDTO>();
                    for (int i = 0; i < this.chlInterval.Items.Count; i++)
                    {
                        if (this.chlInterval.GetItemChecked(i))
                        {
                            string lName = this.chlInterval.Items[i].ToString();
                            IEnumerable<DateIntervalDTO> query =
                                from lInterval in this.dateIntervalController.GetAll()
                                where lInterval.Name == lName
                                select lInterval;
                            foreach (DateIntervalDTO dto in query)
                            {
                                this.iOriginalCampaign.ActiveIntervals.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AgregarModificarCampaña_Load(object sender, EventArgs e)
        {
            try
            {
                using (this.dateIntervalController = this.DateIntervalController)
                {
                    //TODO ponerle a los campos el prefijo i
                    int i = 0;
                    IList<DateIntervalDTO> lIntervals = this.dateIntervalController.GetAll();
                    IList<DateIntervalDTO> lCampaignIntervals = this.iOriginalCampaign.ActiveIntervals;
                    foreach (DateIntervalDTO lInterval in lIntervals)
                    {
                        this.chlInterval.Items.Add(lInterval.Name);
                        if (lCampaignIntervals != null)
                        {
                            if (lCampaignIntervals.Contains(lInterval, new DateIntervalDTOComparer()))
                            {
                                this.chlInterval.SetItemChecked(i, true);
                            }
                            i++;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
}
