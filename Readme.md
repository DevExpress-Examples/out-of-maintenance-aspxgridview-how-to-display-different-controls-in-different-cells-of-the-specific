<!-- default file list -->
*Files to look at*:

* [CustomTemplate.cs](./CS/WebSite/App_Code/CustomTemplate.cs) (VB: [CustomTemplate.vb](./VB/WebSite/App_Code/CustomTemplate.vb))
* **[Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))**
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to display different controls in different cells of the specific column
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e5130/)**
<!-- run online end -->


<p><strong>Problem:</strong><br />
I have two columns in my ASPxGridView. The first column contains values. The second column should contain different controls/editors depending on the values in the first column.</p><p><strong>Solution:</strong><br />
In this scenario you need to generate a template for the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewGridViewDataColumn_DataItemTemplatetopic"><u>GridViewDataColumn.DataItemTemplate Property</u></a> dynamically by implementing the <a href="http://msdn.microsoft.com/en-us/library/system.web.ui.itemplate.aspx"><u>ITemplate Interface</u></a>. For instance:<br />
</p>

```cs
    protected void Page_Init(object sender, EventArgs e) {
        ((GridViewDataColumn)ASPxGridView1.Columns["UnitPrice"]).DataItemTemplate = new CustomTemplate();
    }

```



```cs
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

```

<p>Here we display a simple label if the "UnitsOnOrder" field value is zero. Otherwise, we display a spin edit control with the editing capability.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/KA18834">General information about Template containers</a></p>

<br/>


