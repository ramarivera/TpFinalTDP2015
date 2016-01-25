﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Service.DTO
{
    class ValueAndDescription
    {
        private string iDescription;
        private int iValue;

        public ValueAndDescription()
        {
            this.Description = String.Empty;
            this.Value = 0;
        }

        public string Description
        {
            get { return this.iDescription; }
            set { this.iDescription = value; }
        }

        public int Value
        {
            get { return this.iValue; }
            set { this.iValue = value; }
        }
    }
}