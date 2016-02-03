using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Collections;

namespace Novaly.Windows.Forms.DesignerSupport
{
    /// <summary>
    ///  This class is a slightly modified version of System.Windows.Forms.Design.EditorServiceContext (System.Design.dll)
    /// </summary>
    internal class EditorServiceContext : IWindowsFormsEditorService, ITypeDescriptorContext, IServiceProvider
    {
        private IComponentChangeService _componentChangeSvc;

        private ComponentDesigner _designer;

        private PropertyDescriptor _targetProperty;

        private IComponentChangeService ChangeService
        {
            get
            {
                if (this._componentChangeSvc == null)
                {
                    this._componentChangeSvc = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
                }
                return this._componentChangeSvc;
            }
        }

        IContainer System.ComponentModel.ITypeDescriptorContext.Container
        {
            get
            {
                if (this._designer.Component.Site == null)
                {
                    return null;
                }
                else
                {
                    return this._designer.Component.Site.Container;
                }
            }
        }

        object System.ComponentModel.ITypeDescriptorContext.Instance
        {
            get
            {
                return this._designer.Component;
            }
        }

        PropertyDescriptor System.ComponentModel.ITypeDescriptorContext.PropertyDescriptor
        {
            get
            {
                return this._targetProperty;
            }
        }

        internal EditorServiceContext(ComponentDesigner designer)
        {
            this._designer = designer;
        }

        internal EditorServiceContext(ComponentDesigner designer, PropertyDescriptor prop)
        {
            this._designer = designer;
            this._targetProperty = prop;
            if (prop == null)
            {
                prop = TypeDescriptor.GetDefaultProperty(designer.Component);
                if (prop != null && typeof(ICollection).IsAssignableFrom(prop.PropertyType))
                {
                    this._targetProperty = prop;
                }
            }
        }

        internal EditorServiceContext(ComponentDesigner designer, PropertyDescriptor prop, string newVerbText)
            : this(designer, prop)
        {
            this._designer.Verbs.Add(new DesignerVerb(newVerbText, OnEditItems));
        }

        public static object EditValue(ComponentDesigner designer, object objectToChange, string propName)
        {
            PropertyDescriptor item = TypeDescriptor.GetProperties(objectToChange)[propName];
            EditorServiceContext editorServiceContext = new EditorServiceContext(designer, item);
            UITypeEditor editor = item.GetEditor(typeof(UITypeEditor)) as UITypeEditor;
            object @value = item.GetValue(objectToChange);
            object obj = editor.EditValue(editorServiceContext, editorServiceContext, @value);
            if (obj != @value)
            {
                try
                {
                    item.SetValue(objectToChange, obj);
                }
                catch (CheckoutException)
                {
                }
            }
            return obj;
        }

        private void OnEditItems(object sender, EventArgs e)
        {
            object @value = this._targetProperty.GetValue(this._designer.Component);
            if (@value != null)
            {
                CollectionEditor editor = TypeDescriptor.GetEditor(@value, typeof(UITypeEditor)) as CollectionEditor;
                if (editor != null)
                {
                    editor.EditValue(this, this, @value);
                }
                return;
            }
            else
            {
                return;
            }
        }

        void System.ComponentModel.ITypeDescriptorContext.OnComponentChanged()
        {
            this.ChangeService.OnComponentChanged(this._designer.Component, this._targetProperty, null, null);
        }

        bool System.ComponentModel.ITypeDescriptorContext.OnComponentChanging()
        {
            bool flag;
            try
            {
                this.ChangeService.OnComponentChanging(this._designer.Component, this._targetProperty);
                return true;
            }
            catch (CheckoutException checkoutException1)
            {
                CheckoutException checkoutException = checkoutException1;
                if (checkoutException != CheckoutException.Canceled)
                {
                    throw;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(ITypeDescriptorContext) || serviceType == typeof(IWindowsFormsEditorService))
            {
                return this;
            }
            else
            {
                if (this._designer.Component.Site == null)
                {
                    return null;
                }
                else
                {
                    return this._designer.Component.Site.GetService(serviceType);
                }
            }
        }

        void System.Windows.Forms.Design.IWindowsFormsEditorService.CloseDropDown()
        {
        }

        void System.Windows.Forms.Design.IWindowsFormsEditorService.DropDownControl(Control control)
        {
        }

        DialogResult System.Windows.Forms.Design.IWindowsFormsEditorService.ShowDialog(Form dialog)
        {
            IUIService service = (IUIService)this.GetService(typeof(IUIService));
            if (service == null)
            {
                return dialog.ShowDialog(this._designer.Component as IWin32Window);
            }
            else
            {
                return service.ShowDialog(dialog);
            }
        }
    }
}
