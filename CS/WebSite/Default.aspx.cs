using System;
using System.Data.OleDb;
using System.Web.Configuration;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Init(object sender, EventArgs e) {
        ((GridViewDataColumn)ASPxGridView1.Columns["UnitPrice"]).DataItemTemplate = new CustomTemplate();
    }

    protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        string[] parts = e.Parameters.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

        OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        OleDbCommand updateCommand = new OleDbCommand(string.Format("UPDATE Products SET UnitPrice = {0} WHERE ProductID = {1}", parts[1], parts[0]), connection);

        connection.Open();
        updateCommand.ExecuteScalar();
        connection.Close();
    }
}