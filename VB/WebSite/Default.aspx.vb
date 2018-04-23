Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Web.Configuration
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		CType(ASPxGridView1.Columns("UnitPrice"), GridViewDataColumn).DataItemTemplate = New CustomTemplate()
	End Sub

	Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim parts() As String = e.Parameters.Split(New Char() { "|"c }, StringSplitOptions.RemoveEmptyEntries)

		Dim connection As New OleDbConnection(WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
		Dim updateCommand As New OleDbCommand(String.Format("UPDATE Products SET UnitPrice = {0} WHERE ProductID = {1}", parts(1), parts(0)), connection)

		connection.Open()
		updateCommand.ExecuteScalar()
		connection.Close()
	End Sub
End Class