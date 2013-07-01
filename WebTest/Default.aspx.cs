using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);

        myDivList.InnerHtml = "<ul>";
        foreach (DataRow drow in dv.Table.Rows)
        {

            myDivList.InnerHtml += "<li type='square'>" + Convert.ToString(drow["ProductName"]) + "</li>";

        }
        myDivList.InnerHtml += "</ul>";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=zxcv123!A");
        con.Open();
        cmd = new SqlCommand("INSERT INTO employer VALUES('" + usrtxt.Text + "', '" + pwdtxt1.Text + "','" + emcl.Text + "','" + comtxt.Text + "','" + contacttxt.Text + "','" + type + "','" + DropDownList1.SelectedItem + "','" + addtxt1.Text + "','" + count1.SelectedValue + "','" + state1.Text + "','" + city1.Text + "','" + pin1.Text + "','" + phno.Text + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
