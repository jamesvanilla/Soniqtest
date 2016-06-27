using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Welcome : System.Web.UI.Page
{
    SqlConnection connection;
    protected void Page_Load(object sender, EventArgs e)
    {
        connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        if (!IsPostBack)
        {
            DataTable dtQuote = new DataTable();
            DataSet dsCatRate = new DataSet();
            //using (SqlCommand cmd = new SqlCommand("select * from dbo.Category_Input where iQuoteNumber=" + lquoteNumber))
            using (SqlCommand cmd = new SqlCommand("Select Top 4 * from [dbo].[vwQuotes] order by [iDate] Desc"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsCatRate);
                }
            }
            DataTable dtCatRate = new DataTable();
            dtCatRate = dsCatRate.Tables[0];
            latestQuotesTableData.DataSource = dtCatRate;
            latestQuotesTableData.DataBind();
        }
    }
  
    protected void addquotebtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("addquote.aspx");
    }
    protected void viewquotebtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("quotes.aspx");
    }
}