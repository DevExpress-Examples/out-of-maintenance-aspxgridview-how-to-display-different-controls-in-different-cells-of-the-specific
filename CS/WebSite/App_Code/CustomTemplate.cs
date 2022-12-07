using System;
using System.Web.UI;
using DevExpress.Web;

public class CustomTemplate : ITemplate {
    public void InstantiateIn(Control container) {
        GridViewDataItemTemplateContainer gcontainer = (GridViewDataItemTemplateContainer)container;
        int units = Convert.ToInt32(DataBinder.Eval(gcontainer.DataItem, "UnitsOnOrder"));

        if (units == 0) {
            ASPxLabel label = new ASPxLabel();
            label.ID = "label1";
            gcontainer.Controls.Add(label);
            label.Text = DataBinder.Eval(gcontainer.DataItem, "UnitPrice").ToString();
            label.Width = 100;
        }
        else {
            ASPxSpinEdit button = new ASPxSpinEdit();
            button.ID = "spinEdit1";
            gcontainer.Controls.Add(button);
            button.Value = DataBinder.Eval(gcontainer.DataItem, "UnitPrice").ToString();
            button.Width = 100;
            button.ClientSideEvents.LostFocus = string.Format("function(s, e) {{ grid.PerformCallback('{0}|' + s.GetValue()); }}", gcontainer.KeyValue);
        }
    }
}