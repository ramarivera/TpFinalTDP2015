using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.UI.View;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using TpFinalTDP2015.UI.Excepciones;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Intervalos de Fechas")]
    public partial class IntervalAdministrator : AdminModePage
    {
        private GenericDGV<ScheduleDTO> dgvDateInterval;
        private GenericDGV<ScheduleEntryDTO> dgvTimeInterval;


        public IntervalAdministrator(IControllerFactory pFactory) : base(pFactory)
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageScheduleHandler>())
                {
                    bool acepted = new bool();
                    ScheduleDTO dateInterval = new ScheduleDTO();
                    AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha(this.iFactory);
                    this.dgvDateInterval.Add(ventana, dateInterval, acepted);
                    if (acepted)
                    {
                        controller.AddSchedule(dateInterval);
                        this.CargarDateDataGrid();
                    }                  
                }
                    
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageScheduleHandler>())
                {
                    IList<ScheduleDTO> intervalosAEliminar = new List<ScheduleDTO>();
                    foreach (DataGridViewRow row in this.dgvDateInterval.SelectedRows)
                    {
                        intervalosAEliminar.Add(dgvDateInterval.GetItem(row.Index));
                    }
                    if (intervalosAEliminar.Count == 0)
                    {
                        MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.dgvDateInterval.Delete(intervalosAEliminar);
                        foreach (ScheduleDTO sche in intervalosAEliminar)
                        {
                            controller.DeleteSchedule(sche);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvDateInterval_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageScheduleHandler>())
                {
                    DataGridViewRow row = dgvDateInterval.CurrentRow;
                    ScheduleDTO dateInterval = dgvDateInterval.GetItem(row.Index);
                    AgregarModificarIntervaloFecha ventana = new AgregarModificarIntervaloFecha(this.iFactory);
                    this.dgvDateInterval.Modify(ventana, dateInterval);
                    controller.ModifySchedule(dateInterval);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void IntervalAdministrator_Load(object sender, EventArgs e)
        {
            this.CargarDateDataGrid();
            this.CargarTimeDataGrid();
        }

        private void CargarDateDataGrid()
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageScheduleHandler>())
                {
                    this.dgvDateInterval.SetSource(controller.ListSchedules());
                }
                    
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarTimeDataGrid()
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageScheduleHandler>())
                {
                    ScheduleDTO dateInterval = dgvDateInterval.GetItem(0);
                    if (dateInterval != null)
                    {
                        this.dgvTimeInterval.SetSource(dateInterval.ActiveHours);
                    }
                }
            }
            catch
            {
                throw;
            }
            
        }

        //TODO estos dos metodos son muy similares. No podes por ej cuando se carga todo setear el dgvDate en index 0 cosa de que se dispare auto el segundo metodo?
        private void dgvDateInterval_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageScheduleHandler>())
                {
                    DataGridViewRow row = dgvDateInterval.CurrentRow;
                    ScheduleDTO dateInterval = dgvDateInterval.GetItem(row.Index);
                    this.dgvTimeInterval.SetSource(dateInterval.ActiveHours);
                }
            }
            catch
            {
                throw;
            }
            
        }

        private void btnAddTimeInterval_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageScheduleHandler>())
                {
                    DataGridViewRow row = dgvDateInterval.CurrentRow;
                    ScheduleDTO dateInterval = dgvDateInterval.GetItem(row.Index);
                    ScheduleEntryDTO timeInterval = new ScheduleEntryDTO();
                    IAddModifyViewForm ventana = new AgregarModificarIntervaloTiempo(this.iFactory);
                    ventana.Add((IDTO)timeInterval);
                    DialogResult resultado = ventana.ShowForm();
                    if (resultado == DialogResult.OK)
                    {
                        dateInterval.ActiveHours.Add(timeInterval);
                    }
                }
            }
            catch
            {
                throw;
            }
            
            //TODO revisar esto
        }

        private void btnDeleteTimeInterval_Click(object sender, EventArgs e)
        {
            try
            {
                using (var controller = this.iFactory.GetController<ManageScheduleHandler>())
                {
                    IList<ScheduleEntryDTO> intervalosAEliminar = new List<ScheduleEntryDTO>();
                    foreach (DataGridViewRow row in this.dgvTimeInterval.SelectedRows)
                    {
                        intervalosAEliminar.Add(dgvTimeInterval.GetItem(row.Index));
                    }
                    if (intervalosAEliminar.Count == 0)
                    {
                        MessageBox.Show("No hay elementos para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.dgvTimeInterval.Delete(intervalosAEliminar);
                        foreach (ScheduleEntryDTO interval in intervalosAEliminar)
                        {
                            //controller.DeleteSchedule(interval);
                            //TODO ver esto
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvDateInterval.CurrentRow;
                ScheduleDTO dateInterval = dgvDateInterval.GetItem(row.Index);
                DateIntervalView ventana = new DateIntervalView();
                ventana.View(dateInterval);
            }
            catch (EntidadNulaException ex)
            {
                MessageBox.Show(ex.Message, "Entidad nula", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
