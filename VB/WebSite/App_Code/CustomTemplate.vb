Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Public Class CustomTemplate
	Implements ITemplate
	Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
		Dim gcontainer As GridViewDataItemTemplateContainer = CType(container, GridViewDataItemTemplateContainer)
		Dim units As Integer = Convert.ToInt32(DataBinder.Eval(gcontainer.DataItem, "UnitsOnOrder"))

		If units = 0 Then
			Dim label As New ASPxLabel()
			label.ID = "label1"
			gcontainer.Controls.Add(label)
			label.Text = DataBinder.Eval(gcontainer.DataItem, "UnitPrice").ToString()
			label.Width = 100
		Else
			Dim button As New ASPxSpinEdit()
			button.ID = "spinEdit1"
			gcontainer.Controls.Add(button)
			button.Value = DataBinder.Eval(gcontainer.DataItem, "UnitPrice").ToString()
			button.Width = 100
			button.ClientSideEvents.LostFocus = String.Format("function(s, e) {{ grid.PerformCallback('{0}|' + s.GetValue()); }}", gcontainer.KeyValue)
		End If
	End Sub
End Class