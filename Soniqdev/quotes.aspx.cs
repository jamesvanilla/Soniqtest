using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;


public partial class quotes : System.Web.UI.Page
{
    SqlConnection connection;
    protected void Page_Load(object sender, EventArgs e)
    {
        connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        if (!IsPostBack)
        {
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwQuotes]"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
        }
        if (IsPostBack)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }

    }
    protected void searchbtn_Click(object sender, EventArgs e)
    {
        StringBuilder  whereCondition = new StringBuilder("");
        if ((quoteNotxt.Text != string.Empty) || (clientnametext.Text != string.Empty) || (usertxt.Text != string.Empty) || (statustxt.Text != string.Empty))
        {
            whereCondition.Append("where ");
            if (quoteNotxt.Text != string.Empty)
            {
                whereCondition.Append("iQuoteNumber ="+quoteNotxt.Text.Trim());
                if (clientnametext.Text != string.Empty)
                {
                    whereCondition.Append(" OR iClientName Like '%" + clientnametext.Text.Trim()+"%'");
                }
                if (usertxt.Text != string.Empty)
                {
                    whereCondition.Append(" OR iUser Like '%" + usertxt.Text.Trim() + "%'");
                }
                if (statustxt.Text != string.Empty)
                {
                    whereCondition.Append(" OR iQuoteStatus  Like '%" + statustxt.Text.Trim() + "%'");
                }
            }
            else if (clientnametext.Text != string.Empty)
            {
                whereCondition.Append("iClientName Like '%" + clientnametext.Text.Trim() + "%'");

                if (usertxt.Text != string.Empty)
                {
                    whereCondition.Append(" OR iUser Like '%" + usertxt.Text.Trim() + "%'");
                }
                if (statustxt.Text != string.Empty)
                {
                    whereCondition.Append(" OR iQuoteStatus  Like '%" + statustxt.Text.Trim() + "%'");
                }
            }
            else if (usertxt.Text != string.Empty)
            {
                whereCondition.Append("iUser Like '%" + usertxt.Text.Trim() + "%'");
                if (statustxt.Text != string.Empty)
                {
                    whereCondition.Append(" OR iQuoteStatus  Like '%" + statustxt.Text.Trim() + "%'");
                }
            }
            else if  (statustxt.Text != string.Empty)
            {
                whereCondition.Append(" iQuoteStatus  Like '%" + statustxt.Text.Trim() + "%'");
            }
        }
        
        using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwQuotes] " + whereCondition))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
    }
    protected void actiondropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        DropDownList lb = (DropDownList)sender;
        if (lb.SelectedValue == "Edit Quote")
        {
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            Label lblQno =(Label) gvRow.Cells[1].FindControl("lblQuoteNumber");
            string iQuoteNumber = lblQno.Text.Trim();
            if (iQuoteNumber !=string.Empty)
            Response.Redirect("addquote.aspx?iQuoteNumber=" + iQuoteNumber);
        }
    }
}