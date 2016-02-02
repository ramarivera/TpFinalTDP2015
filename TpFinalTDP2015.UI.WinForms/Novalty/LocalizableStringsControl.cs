using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Collections;
using Novaly.Windows.Forms.DesignerSupport;

namespace Novaly.Windows.Forms.LocalizableStrings
{
    [
        Localizable(true),
        DefaultProperty("Strings"),
        Designer(typeof(LocalizableStringsDesigner))
    ]
    public partial class LocalizableStringsControl : Component
    {
        List<LocalizableString> strings = new List<LocalizableString>();

        [
          Category("Data"),
          Description("Strings"),
          DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
          Editor(typeof(CollectionEditor), typeof(UITypeEditor)),
          Browsable(true),
          Localizable(true)
        ]
        public List<LocalizableString> Strings
        {
            get { return strings; }
        }

        public LocalizableStringsControl()
        {
            InitializeComponent();
        }



        public class LocalizableStringsDesigner : ComponentDesigner
        {
            private DesignerActionListCollection actionLists;
            private LocalizableStringsActionList actionList;

            public override DesignerActionListCollection ActionLists
            {
                get
                {
                    if (actionLists == null)
                    {
                        actionLists = new DesignerActionListCollection();
                        actionLists.Add(actionList = new LocalizableStringsActionList(this));
                    }
                    return actionLists;
                }
            }

            public override System.Collections.ICollection AssociatedComponents
            {
                get
                {
                    return ((LocalizableStringsControl)Component).Strings;
                }
            }


            public override void DoDefaultAction()
            {
                try
                {
                    actionList.InvokeStringsDialog();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private class LocalizableStringsActionList : DesignerActionList
        {
            ComponentDesigner designer;

            public LocalizableStringsActionList(ComponentDesigner designer) :
                base(designer.Component)
            {
                this.designer = designer;
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
                designerActionItemCollection.Add(new DesignerActionMethodItem(
                    this, "InvokeStringsDialog", "Edit Strings", "Properties", "Edit Strings", true));
                return designerActionItemCollection;
            }

            public void InvokeStringsDialog()
            {
                EditorServiceContext.EditValue(designer, Component, "Strings");
            }
        }
    }
}
