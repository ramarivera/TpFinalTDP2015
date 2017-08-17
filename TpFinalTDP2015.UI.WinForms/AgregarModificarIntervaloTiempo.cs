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
    public partial class AgregarModificarIntervaloTiempo : BaseForm, IAddModifyViewForm
    {
        private ScheduleEntryDTO iOriginalTimeInterval = new ScheduleEntryDTO();
        private readonly IControllerFactory iFactory;

        public ScheduleEntryDTO TimeInterval
        {
            get { return this.iOriginalTimeInterval; }
        }
        public AgregarModificarIntervaloTiempo(IControllerFactory pFactory)
        {
            InitializeComponent();
            this.iFactory = pFactory;
        }

        void IAddModifyViewForm.Add(IDTO pNewTimeInterval)
        {
            this.dtpStartTime.Value = DateTime.Now;
            this.dtpEndTime.Value = DateTime.Now;
            this.Text = "Agregar nuevo Intervalo";
            this.iOriginalTimeInterval = (ScheduleEntryDTO)pNewTimeInterval;
        }

        void IAddModifyViewForm.Modify(IDTO pTimeInterval)
        {
            if (pTimeInterval == null)
            {
                throw new EntidadNulaException("El intervalo de tiempo indicado es nulo");
                //TODO excepcion argumentexception creo
            }
            else
            {
                this.iOriginalTimeInterval = (ScheduleEntryDTO)pTimeInterval;
                this.dtpStartTime.Value = DateTime.MinValue + iOriginalTimeInterval.StartTime;
                this.dtpEndTime.Value = DateTime.MinValue + iOriginalTimeInterval.EndTime;
                this.Text = "Modificar Intervalo";
            }      
        }

        DialogResult IAddModifyViewForm.ShowForm()
        {
            return this.ShowDialog();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.iOriginalTimeInterval.StartTime = this.dtpStartTime.Value.TimeOfDay;
            this.iOriginalTimeInterval.EndTime = this.dtpEndTime.Value.TimeOfDay;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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
}
