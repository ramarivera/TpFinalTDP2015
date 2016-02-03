using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;

namespace Novaly.Windows.Forms.LocalizableStrings
{
    [DesignTimeVisible(false)]
    public class LocalizableString : Component
    {
        private string text;

        [Localizable(true)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor))]
        public string Text
        {
            get { return text; }
            set { this.text = value; }
        }

        public override string ToString()
        {
            return text;
        }
    }
}
