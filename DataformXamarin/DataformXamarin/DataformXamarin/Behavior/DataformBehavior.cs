using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DataformXamarin
{
    public class DataformBehavior : Behavior<SfDataForm>
    {
        SfDataForm dataForm;
        protected override void OnAttachedTo(SfDataForm bindable)
        {
            dataForm = bindable;
            dataForm.DataObject = new DynamicDataModel().ExpandoObject;
            base.OnAttachedTo(bindable);
            this.WireEvents();
        }
        private void WireEvents()
        {
            this.dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;
        }
        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null && e.DataFormItem.Name == "DateOfBirth")
                e.DataFormItem.Editor = "Date";
        }
        protected override void OnDetachingFrom(SfDataForm bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }
        private void UnWireEvents()
        {
            this.dataForm.AutoGeneratingDataFormItem -= DataForm_AutoGeneratingDataFormItem;
        }
    }
}



    






