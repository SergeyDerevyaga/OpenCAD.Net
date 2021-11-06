using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CadCoreLib
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class SortedListTypeEditor<T1, T2> : UITypeEditor
    {
        public SortedListTypeEditor()
        {
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {

            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            SortedList<T1, T2> list = (SortedList<T1, T2>)value;

            if (list == null)
                list = new SortedList<T1, T2>();

            if (edSvc != null)
            {
                SortedListEditor<T1, T2> listEditor = new SortedListEditor<T1, T2>(list, "");
                edSvc.ShowDialog(listEditor);

                if (listEditor.DialogResult == DialogResult.OK)
                    list = listEditor.EditedList;
            }
            return list;
        }
    }

    public class SortedListEditor<T1, T2> : Form
    {
        public SortedList<T1, T2> EditedList { get; set; } = new SortedList<T1, T2>();
        public SortedListEditor(SortedList<T1, T2> list, string text)
        {
            EditedList = list;
            Text = text;
        }
    }
}
