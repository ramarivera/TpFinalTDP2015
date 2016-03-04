﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;


namespace MarrSystems.TpFinalTDP2015.UI
{
    public interface IAddModifyViewForm
    {
        void Agregar(IDTO pDTO);

        void Modificar(IDTO pDTO);

        DialogResult ShowForm();
       
    }
}
