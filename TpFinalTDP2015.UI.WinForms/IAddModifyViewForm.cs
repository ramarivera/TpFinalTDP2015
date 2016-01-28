using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinalTDP2015.Service.DTO;


namespace TpFinalTDP2015.UI
{
    public interface IAddModifyViewForm
    {
        void Agregar(IDTO pDTO);

        void Modificar(IDTO pDTO);

        DialogResult ShowForm();
       
    }
}
