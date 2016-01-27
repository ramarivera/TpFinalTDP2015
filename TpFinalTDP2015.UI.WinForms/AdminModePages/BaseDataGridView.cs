using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpFinalTDP2015.UI
{
    public partial class BaseDataGridView: UserControl
    {
        BindingSource source = new BindingSource();
        public BaseDataGridView()
        {
            InitializeComponent();
            this.dgv.DataSource = source;
        }

        public DataGridViewSelectedRowCollection SelectedRows
        {
            get { return this.dgv.SelectedRows; }
        }
    }
}
