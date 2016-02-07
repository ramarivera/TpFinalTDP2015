﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Service.Controllers;

namespace TpFinalTDP2015.UI.AdminModePages
{
    [AdminModePageInfo(Name = "Administrador de Textos Fijos")]
    public partial class StaticTextAdministrator : AdminModePage
    {
        StaticTextController iController = new StaticTextController();

        StaticTextDTO staticText;
        public StaticTextAdministrator(): base()
        {
            InitializeComponent();
            //TODO obtener lo que está en la base de datos como una lista mediante fachada y guardar en iSource
            this.dgvStaticText.DataSource = this.dgvStaticText.iSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.staticText = new StaticTextDTO();
            AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
            this.dgvStaticText.Agregar(ventana,this.staticText);
            iController.SaveStaticText(this.staticText);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TODO verificar lista no vaciaa
            List<IDTO> textosAEliminar = new List<IDTO>();
            foreach (DataGridViewRow row in this.dgvStaticText.SelectedRows)
            {
                textosAEliminar.Add((StaticTextDTO)row.DataBoundItem);
            }
            this.dgvStaticText.Eliminar(textosAEliminar);
            foreach  (IDTO text in textosAEliminar)
            {
                iController.DeleteStaticText((StaticTextDTO)text);
            }
        }

        private void dgvStaticText_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvStaticText.CurrentRow;
            this.staticText = (StaticTextDTO)row.DataBoundItem;
            AgregarModificarTextoFijo ventana = new AgregarModificarTextoFijo();
            this.dgvStaticText.Modificar(ventana, this.staticText);
            iController.SaveStaticText(this.staticText);
        }

        private void StaticTextAdministrator_Load(object sender, EventArgs e)
        {
            IList<StaticTextDTO> lList = this.iController.GetStaticTexts();
            foreach (var dto in lList)
            {
                this.dgvStaticText.iSource.Add(dto);
            }
            this.dgvStaticText.DataSource = this.dgvStaticText.iSource;
        }
    }
}
