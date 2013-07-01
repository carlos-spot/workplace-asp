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
}
