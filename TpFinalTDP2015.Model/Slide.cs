﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model.Enum;

namespace MarrSystems.TpFinalTDP2015.Model
{
    [Serializable]
    public class Slide : BaseEntity
    {
        //private tipo iImage;
        private SlideTransition iTransition;
        private int iDuration;

        public Slide() : base()
        {

        }

        /*public virtual tipo Image
        {
            get { return this.iImage; }
            set
            {
                this.UpdateModificationDate();
                this.iImage = value;
            }
        }*/

        public virtual SlideTransition Transition
        {
            get { return this.iTransition; }
            set { this.iTransition = value; }
        }

        public virtual int Duration
        {
            get { return this.iDuration; }
            set { this.iDuration = value; }
        }


    }
}
