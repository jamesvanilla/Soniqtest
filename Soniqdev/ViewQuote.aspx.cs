using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;


public partial class ViewQuote : System.Web.UI.Page
{
    //RFriskv100Client lRFriskv100Client;
    SqlConnection connection;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Messages lMessagesType;
            string lstrServiceName = "RFriskv100";
            string lstrServiceVersion = null;
            DateTime lDateTimeServiceDate = DateTime.Now;
            bool lbServiceDateSpecified = true;
            string lstrUsage = null;
            string lquoteNumber = "902";
             if (Request.QueryString["iQuoteNumber"] != null)
                lquoteNumber = Request.QueryString["iQuoteNumber"].ToString();// string.Empty;
           
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;


            #region  Benefits.

            DataSet ds = new DataSet();
            DataTable dtben = new DataTable();
            //using (SqlCommand cmd = new SqlCommand("select * from dbo.Category_Input where iQuoteNumber=" + lquoteNumber))
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwBenfits] where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(ds);
                }
            }
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            DataTable dtTranspose = GenerateTransposedTable(dt);
            int indx = dtTranspose.Rows.Count;
            dtTranspose.Rows[indx - 1].Delete();
            dtTranspose.AcceptChanges();
            dtben.Merge(dtTranspose);
            dtben.AcceptChanges();
            //gvLifeInsuranceLumpSumDisability.DataSource = dtTranspose;
            //gvLifeInsuranceLumpSumDisability.DataBind();
            DataSet ds1 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwAgeBanded] where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(ds1);
                }
            }

            DataTable dt1 = new DataTable();
            dt1 = ds1.Tables[0];

            DataTable dtTransposeAgeBanded = GenerateTransposedTableForAgeBanded(dt1);
            indx = dtTransposeAgeBanded.Rows.Count;
            dtTransposeAgeBanded.Rows[indx - 1].Delete();
            dtTransposeAgeBanded.AcceptChanges();
            //gvLifeInsuranceandLSDAgeBandedBenefit.DataSource = dtTransposeAgeBanded;
            //gvLifeInsuranceandLSDAgeBandedBenefit.DataBind();
            dtben.Merge(dtTransposeAgeBanded);
            dtben.AcceptChanges();

            DataSet ds2 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwTraumaInsurance] where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(ds2);
                }
            }

            DataTable dt2 = new DataTable();
            dt2 = ds2.Tables[0];

            DataTable dtTraumaInsurance = GenerateTransposedTableforTrauma(dt2);
            indx = dtTraumaInsurance.Rows.Count;
            dtTraumaInsurance.Rows[indx - 1].Delete();
            dtTraumaInsurance.AcceptChanges();
            //gvTraumaInsurance.DataSource = dtTraumaInsurance;
            //gvTraumaInsurance.DataBind();
            dtben.Merge(dtTraumaInsurance);
            dtben.AcceptChanges();
            DataSet ds3 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwDisabilityBenefit] where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(ds3);
                }
            }

            DataTable dt3 = new DataTable();
            dt3 = ds3.Tables[0];

            DataTable dtdisabilitybenefit = GenerateTransposedTablefordtdisabilitybenefit(dt3);
            indx = dtdisabilitybenefit.Rows.Count;
            dtdisabilitybenefit.Rows[indx - 1].Delete();
            dtdisabilitybenefit.AcceptChanges();
            //gvdisabilitybenefit.DataSource = dtdisabilitybenefit;
            //gvdisabilitybenefit.DataBind();

            dtben.Merge(dtdisabilitybenefit);
            dtben.AcceptChanges();

            DataSet ds33 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwGroupTemporaryIncome] where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(ds33);
                }
            }

            DataTable dt33 = new DataTable();
            dt33 = ds33.Tables[0];

            DataTable dtdisabilitybenefitt = GenerateTransposedTablefordtdisabilitybenefit(dt33);
            indx = dtdisabilitybenefitt.Rows.Count;
            dtdisabilitybenefitt.Rows[indx - 1].Delete();
            dtdisabilitybenefitt.AcceptChanges();

            dtben.Merge(dtdisabilitybenefitt);
            dtben.AcceptChanges();

            DataSet ds4 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwSpousesInsurance] where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(ds4);
                }
            }

            DataTable dt4 = new DataTable();
            dt4 = ds4.Tables[0];

            DataTable dtSpousesInsurance = GenerateTransposedTableforSpousesInsurance(dt4);
            indx = dtSpousesInsurance.Rows.Count;
            dtSpousesInsurance.Rows[indx - 1].Delete();
            dtSpousesInsurance.AcceptChanges();
            //gvSpousesInsurance.DataSource = dtSpousesInsurance;
            //gvSpousesInsurance.DataBind(); 
            dtben.Merge(dtSpousesInsurance);
            dtben.AcceptChanges();

            DataSet ds5 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwFuneralInsurance]where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(ds5);
                }
            }

            DataTable dt5 = new DataTable();
            dt5 = ds5.Tables[0];

            DataTable dtFuneralInsurance = GenerateTransposedTableforFuneralInsurance(dt5);
            indx = dtFuneralInsurance.Rows.Count;
            dtFuneralInsurance.Rows[indx - 1].Delete();
            dtFuneralInsurance.AcceptChanges();
            //gvFuneralInsurance.DataSource = dtFuneralInsurance;
            //gvFuneralInsurance.DataBind(); 
            dtben.Merge(dtFuneralInsurance);
            dtben.AcceptChanges();
            gvLifeInsuranceLumpSumDisability.DataSource = dtben;
            gvLifeInsuranceLumpSumDisability.DataBind();
            gvLifeInsuranceLumpSumDisability.Rows[0].BackColor = System.Drawing.Color.DarkGray;
            string dfggd = dtben.Rows[1][0].ToString();

            for (int i = 0; i < dtben.Rows.Count; i++)
            {

                if ((dtben.Rows[i][0].ToString() == "Life Insurance and Lump Sum Disability Age Banded Benefits") || (dtben.Rows[i][0].ToString() == "Group Income Insurance / Group IncomeCare (PHI)") || (dtben.Rows[i][0].ToString() == "Group Temporary Income Insurance (TTD)") || (dtben.Rows[i][0].ToString() == "Trauma Insurance") || (dtben.Rows[i][0].ToString() == "Group Income Insurance / Group IncomeCare (disability benefit)") || (dtben.Rows[i][0].ToString() == "Spouses Insurance") || (dtben.Rows[i][0].ToString() == "Funeral Insurance"))
                {
                    gvLifeInsuranceLumpSumDisability.Rows[i].BackColor = System.Drawing.Color.DarkGray;
                }
            }
            #endregion

            #region Quote summary

            DataTable dtquoteSummary = new DataTable();
            DataTable dtqsummaryy9 = new DataTable();
            DataSet dsqsummaryy9 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select i.iClientName as 'Client Name',CONVERT(VARCHAR(10), i.iDate, 111) as 'Quotation Date',CONVERT(VARCHAR(10), i.iDateValidTill, 111) as 'Quote Valid Until',i.iProvince as 'Province',i.iIndustry as 'Industry',cast(ROUND(i.iBinderFeePerc,2) as numeric(18,2)) as 'Binder Fee (%)',cast(ROUND(i.iOutsourceFeePerc,2) as numeric(18,2)) as 'Outsourcing Fee (%)', i.iHasNBComm as 'New Business Commission Applies',i.iHasVatOnComm as 'Vat on Commission Applies',cast(ROUND(i.iCommDiscount,2) as numeric(18,2)) as 'Commission Discount (%)',i.iIsSUFquote as 'SUF scheme',c.cTotNumberMembers as 'Number of members',c.cTotNumberSpouses as 'Number of spouses',cast(ROUND(c.cAvgAge,2) as numeric(18,2)) as 'Average age of members',cast(ROUND(c.cAvgAgeSpouses,2) as numeric(18,2)) as 'Average age of spouses',cast(ROUND(c.cTotAnnualSalary,2) as numeric(18,2)) as 'Total annual salaries',cast(ROUND(c.cTotPremIncCommBind,2) as numeric(18,2)) as 'Estimated total annual premium' from Quote_Input as i INNER JOIN Quote_Output AS c ON i.iQuoteNumber = c.Quoteoutput_ID where i.iQuoteNumber =" + lquoteNumber))
            {
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtqsummaryy9);
                }
            }
            //DataTable dtqsummaryy9= new DataTable();
            //dtqsummaryy9= dsqsummaryy9.Tables[0];

            DataTable dtqsummaryTranspose9 = GenerateTransposedTableforQuoteSummary(dtqsummaryy9);
            int idxC1 = dtqsummaryTranspose9.Rows.Count;
            dtqsummaryTranspose9.Rows[idxC1 - 1].Delete();
            dtqsummaryTranspose9.AcceptChanges();
            dtquoteSummary.Merge(dtqsummaryTranspose9);
            dtquoteSummary.AcceptChanges();



            DataSet dsqsummary6 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select i.iCategoryNumber as 'Category Number' ,i.iCategoryDescription as 'Category Description',cast(ROUND(c.cTotNumberMembers,0) as numeric(18,0)) as 'No. of Members'  from Category_Input as i LEFT JOIN Category_Output AS c ON i.iQuoteNumber = c.iQuoteNumber AND i.iCategoryNumber = c.iCategoryNumber where i.iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsqsummary6);
                }
            }
            DataTable dtqsummary6 = new DataTable();
            //dtqsummary6.Columns.Add("Category Number");
            //dtqsummary6.Columns.Add("Category Description");
            //dtqsummary6.Columns.Add("No. of Members");
            dtqsummary6 = dsqsummary6.Tables[0];

            GridView6.DataSource = dtqsummary6;
            GridView6.DataBind();

            //DataTable dtqsummaryTranspose6 = GenerateTransposedTableforCategoryRates(dtqsummary6);
            //int idx1 = dtqsummaryTranspose6.Rows.Count;
            //dtqsummaryTranspose6.Rows[idx1 - 1].Delete();
            //dtqsummaryTranspose6.AcceptChanges();
            //DataRow dqs = dtqsummary6.NewRow();
            //dqs[1] = "Categories";
            //dtqsummary6.Rows.InsertAt(dqs, 0);


            //            foreach (DataRow dr in dtqsummary6.Rows) {

            //        dtquoteSummary.Rows.Add(dr.ItemArray);
            //}
            //dtquoteSummary.Merge(dtqsummary6);
            // dtquoteSummary.AcceptChanges();

            DataSet dsqsummary1 = new DataSet();

            int f = 0, f1 = 0, f2 = 0, f3 = 0, f4 = 0;

            ////Group Life Insurance (death benefit) and Lump Sum Disability 

            //SqlDataAdapter adptr;
            //using (SqlCommand cmd1 = new SqlCommand("select iHasGLA,iHasPTD from Category_Input where iQuoteNumber="+lquoteNumber))
            //{

            //    cmd1.CommandType = CommandType.Text;
            //    cmd1.Connection = connection;
            //    cmd1.ExecuteNonQuery();
            //    adptr = new SqlDataAdapter(cmd1);
            //    DataTable dts = new DataTable();
            //    adptr.Fill(dts);

            //    foreach (DataRow c in dts.Rows)
            //    {
            //        if (c[0].Equals("True") || (c[1].Equals("True")))
            //        {
            //            f = 1;
            //        }
            //    }
            //}
            //if (f == 1)
            //{
            using (SqlCommand cmd = new SqlCommand("select cast(ROUND(cTotCountGLA,0) as numeric(18,0)) as 'Number of members (Life)',cast(ROUND(cTotCountPTD,0) as numeric(18,0)) as 'Number of members (PTD)',cast(ROUND(cTotAnnSalLife,2) as numeric(18,2)) as 'Total annual salaries',cast(ROUND(cTotCoverGLA,2) as numeric(18,2)) as 'Total life cover',cast(ROUND(cTotCoverPTD,2) as numeric(18,2)) as 'Total disability cover (PTD)',cast(ROUND(cTotLifePremIncBindProv,2) as numeric(18,2))as 'Estimated annual premium' from Quote_Output where Quoteoutput_ID=" + lquoteNumber))
                {
                    //connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dsqsummary1);
                    }
                }
                DataTable dtqsummary1 = new DataTable();
                dtqsummary1 = dsqsummary1.Tables[0];
                DataRow dqs1 = dtqsummary1.NewRow();
                //dqs1[0] = "Group Life Insurance (death benefit) and Lump Sum Disability  ";
                //dtqsummary1.Rows.InsertAt(dqs1, 0);
                DataTable dtqsummaryTranspose = GenerateTransposedTableforQuoteSummary(dtqsummary1);
                int idxx1 = dtqsummaryTranspose.Rows.Count;
                //dtqsummaryTranspose.Rows[idxx1 - 1].Delete();

                GridView1.DataSource = dtqsummaryTranspose;
                GridView1.DataBind();

                //dtqsummaryTranspose.AcceptChanges();
                //dtquoteSummary.Merge(dtqsummaryTranspose);
                //dtquoteSummary.AcceptChanges();
            //}
            //else
            //{
            //    GLILSDPTD.Visible = false;

            //}

            //DataTable dtt = new DataTable();
            //dtt.Columns.Add("Group Life Insurance (death benefit) and Lump Sum Disability");
            //DataRow dr = dtt.NewRow();
            //dr[0] = "Group Life Insurance (death benefit) and Lump Sum Disability  ";
            //dtquoteSummary.Merge(dtt);
            //dtquoteSummary.AcceptChanges();
            //Critical Illness Insurance

            DataSet dsqsummary2 = new DataSet();
            //using (SqlCommand cmd2 = new SqlCommand("select iHasCII from Category_Input  where iQuoteNumber="+lquoteNumber)
            //{
            //    cmd2.CommandType = CommandType.Text;
            //    cmd2.Connection = connection;
            //    cmd2.ExecuteNonQuery();
            //    SqlDataAdapter adptr1 = new SqlDataAdapter(cmd2);
            //    DataTable dts1 = new DataTable();
            //    adptr.Fill(dts1);
            //    foreach (DataRow c in dts1.Rows)
            //    {
            //        if (c[0].Equals("T"))
            //        {
            //            f = 1;
            //        }
            //    }
            //}
            //if(f==1)
            //{
            using (SqlCommand cmd = new SqlCommand("select cTotCountCII as 'Number of members',cast(ROUND(cTotAnnSalCII,2) as numeric(18,2)) as 'Total annual salaries',cast(ROUND(cTotCoverCII,2) as numeric(18,2)) as 'Total Critical Illness insurance',cast(ROUND(cTotCIIpremIncCommBind,2) as numeric(18,2)) as 'Estimated annual premium' from Category_Output where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsqsummary2);
                }
            }
            DataTable dtqsummary2 = new DataTable();
            dtqsummary2 = dsqsummary2.Tables[0];
            DataRow dqs2 = dtqsummary2.NewRow();
            //dqs2[0] = "Critical Illness Insurance ";
            //dtqsummary2.Rows.InsertAt(dqs2, 0);
            DataTable dtqsummaryTranspose1 = GenerateTransposedTableforQuoteSummary(dtqsummary2);
            int idxc1 = dtqsummaryTranspose1.Rows.Count;
            //dtqsummaryTranspose1.Rows[idxc1 - 1].Delete();
            dtqsummaryTranspose1.AcceptChanges();
            GridView2.DataSource = dtqsummaryTranspose1;
            GridView2.DataBind();
            //dtquoteSummary.Merge(dtqsummaryTranspose1);
            //dtquoteSummary.AcceptChanges();
            // }
            //DataTable dtt1 = new DataTable();
            //dtt1.Columns.Add("Critical Illness Insurance ");
            //DataRow dr1 = dtt.NewRow();
            //dr1[0] = "Critical Illness Insurance   ";
            ////dtquoteSummary.Merge(dtt1);
            ////dtquoteSummary.AcceptChanges();

            ////Group Income Insurance / Group IncomeCare (disability benefit)

            DataSet dsqsummary5 = new DataSet();
            //using (SqlCommand cmd2 = new SqlCommand("select iHasPHI,iHasTTD from Category_Input"))
            //{
            //    cmd2.CommandType = CommandType.Text;
            //    cmd2.Connection = connection;
            //    cmd2.ExecuteNonQuery();
            //    SqlDataAdapter adptr1 = new SqlDataAdapter(cmd2);
            //    DataTable dts1 = new DataTable();
            //    adptr.Fill(dts1);
            //    foreach (DataRow c in dts1.Rows)
            //    {
            //        if (c[0].Equals("T") || c[0].Equals("T"))
            //        {
            //            f = 1;
            //        }
            //    }
            //}
            //if (f == 1)
            //{
            using (SqlCommand cmd = new SqlCommand("select cast(ROUND(cTotCountPHI,0) as numeric(18,0)) as 'Number of members',cast(ROUND(cTotAnnSalIncDis,2) as numeric(18,2)) as 'Total annual salaries',cast(ROUND(cTotCoverPHI,2) as numeric(18,2)) as 'Total income insurance (excl waiver)',cast(ROUND(cTotCoverTTDwaiver,2) as numeric(18,2)) as 'Total employer waiver',cast(ROUND(cTotIncDisPremIncCommBind,2) as numeric(18,2)) as 'Estimated annual premium' from Quote_Output where  Quoteoutput_ID=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsqsummary5);
                }
            }
            DataTable dtqsummary5 = new DataTable();
            dtqsummary5 = dsqsummary5.Tables[0];
            DataRow dqs3 = dtqsummary5.NewRow();
            // dqs3[0] = "Group Income Insurance / Group IncomeCare (disability benefit) ";
            // dtqsummary5.Rows.InsertAt(dqs3, 0);
            DataTable dtqsummaryTranspose5 = GenerateTransposedTableforQuoteSummary(dtqsummary5);
            int idxv1 = dtqsummaryTranspose5.Rows.Count;
            //dtqsummaryTranspose5.Rows[idxv1 - 1].Delete();

            GridView3.DataSource = dtqsummaryTranspose5;
            GridView3.DataBind();
            //dtqsummaryTranspose5.AcceptChanges();
            //dtquoteSummary.Merge(dtqsummaryTranspose5);
            //dtquoteSummary.AcceptChanges();
            //// }
            //DataTable dtt2 = new DataTable();
            //dtt2.Columns.Add("Group Income Insurance / Group IncomeCare (disability benefit) ");
            //DataRow dr2 = dtt.NewRow();
            //dr2[0] = "Group Income Insurance / Group IncomeCare (disability benefit)  ";
            //dtquoteSummary.Merge(dtt2);
            //dtquoteSummary.AcceptChanges();
            //Spouse’s Insurance


            DataTable dtqsummary9 = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select cTotCountTTD as 'Number of members',cast(ROUND(cTotAnnSalTIncDis,2) as numeric(18,2)) as 'Total annual salaries',cast(ROUND(cTotCoverTTD,2) as numeric(18,2)) as 'Total income insurance (excl waiver)',cast(ROUND(cTotCoverTTDwaiver,2) as numeric(18,2)) as 'Total employer waiver',cast(ROUND(cTotTIncDisPremIncCommBind,2) as numeric(18,2)) as 'Estimated annual premium' from Quote_Output where  Quoteoutput_ID=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtqsummary9);
                }
            }
            
            DataTable dtqsummaryTranspose0 = GenerateTransposedTableforQuoteSummary(dtqsummary9);
            GridView7.DataSource = dtqsummaryTranspose0;
            GridView7.DataBind();




            DataSet dsqsummary4 = new DataSet();
            //using (SqlCommand cmd4 = new SqlCommand("select iHasFamBen from Category_Input"))
            //{
            //cmd4.ExecuteNonQuery();
            //SqlDataAdapter adptr3 = new SqlDataAdapter(cmd4);
            //DataTable dts3 = new DataTable();
            //adptr.Fill(dts3);
            //foreach (DataRow c in dts3.Rows)
            //{
            //    if (c[0].Equals("T"))
            //    {
            //        f = 1;
            //    }
            //}
            //}
            //if (f == 1)
            //{
            using (SqlCommand cmd = new SqlCommand("select cTotNumberSpouses as 'Number of spouses',cast(ROUND(cTotAnnSalSpouses,2) as numeric(18,2)) as 'Total annual salaries (of member’s)',cast(ROUND(cTotCoverSGLA,2) as numeric(18,2)) as 'Total spouse’s life cover',cast(ROUND(cTotCoverSGLA,2) as numeric(18,2))  as 'Total spouse’s lump sum disability cover',cast(ROUND(cTotSpousesPremIncCommBind,2) as numeric(18,2)) as 'Estimated annual premium' from Quote_Output  where  Quoteoutput_ID=" + lquoteNumber))
            {

                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsqsummary4);
                }
            }
            DataTable dtqsummary4 = new DataTable();
            dtqsummary4 = dsqsummary4.Tables[0];
            DataRow dqs4 = dtqsummary4.NewRow();
            //dqs4 = "Spouse’s Insurance";
            //dtqsummary4.Rows.InsertAt(dqs4, 0);
            DataTable dtqsummaryTranspose3 = GenerateTransposedTableforQuoteSummary(dtqsummary4);
            int idx11 = dtqsummaryTranspose3.Rows.Count;
            GridView4.DataSource = dtqsummaryTranspose3;
            GridView4.DataBind();

            //dtqsummaryTranspose3.Rows[idx11 - 1].Delete();
            //dtqsummaryTranspose3.AcceptChanges();
            //dtquoteSummary.Merge(dtqsummaryTranspose3);
            //dtquoteSummary.AcceptChanges();

            //DataTable dtt3 = new DataTable();
            //dtt3.Columns.Add("Spouse’s Insurance ");
            //DataRow dr3 = dtt.NewRow();
            //dr3[0] = "Spouse’s Insurance ";
            ////dtquoteSummary.Merge(dtt3);
            ////dtquoteSummary.AcceptChanges();

            ////Funeral’s Insurance

            DataSet dsqsummaryy3 = new DataSet();
            //using (SqlCommand cmd3 = new SqlCommand("select iHasFamBen from Category_Input"))
            //{
            //    cmd3.CommandType = CommandType.Text;
            //    cmd3.Connection = connection;
            //cmd3.ExecuteNonQuery();
            //SqlDataAdapter adptr2 = new SqlDataAdapter(cmd3);
            //DataTable dts2 = new DataTable();
            //adptr.Fill(dts2);
            //foreach (DataRow c in dts2.Rows)
            //{
            //    if (c[0].Equals("T"))
            //    {
            //        f = 1;
            //    }
            //}
            //}
            //if (f == 1)
            //{
            using (SqlCommand cmd = new SqlCommand("select  cast(ROUND(o.cTotCountFUN,0) as numeric(18,0)) as 'Number of members',cast(ROUND(o.cTotAnnSalFUN,2) as numeric(18,2))  as 'Total annual salaries',cast(ROUND(c.cTotCoverFUN,2) as numeric(18,2))  as 'Total funeral cover',cast(ROUND(o.cTotFUNpremIncCommBind,2) as numeric(18,2)) as 'Estimated annual premium'  from Quote_Output as o INNER JOIN Category_Output as c ON c.iQuoteNumber = o.Quoteoutput_ID where c.iQuoteNumber= " + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsqsummaryy3);
                }
            }
            DataTable dtqsummary3 = new DataTable();
            dtqsummary3 = dsqsummaryy3.Tables[0];
            DataRow dqs5 = dtqsummary3.NewRow();
            //   dqs5[0] = "Funeral’s Insurance";
            //  dtqsummary3.Rows.InsertAt(dqs5, 0);
            DataTable dtqsummaryTranspose2 = GenerateTransposedTableforQuoteSummary(dtqsummary3);
            int idx21 = dtqsummaryTranspose2.Rows.Count;

            GridView5.DataSource = dtqsummaryTranspose2;
            GridView5.DataBind();

            //dtqsummaryTranspose2.Rows[idx21 - 1].Delete();
            //dtqsummaryTranspose2.AcceptChanges();
            //dtquoteSummary.Merge(dtqsummaryTranspose2);
            //dtquoteSummary.AcceptChanges();

            //DataTable dtt4 = new DataTable();
            //dtt4.Columns.Add("Funeral’s Insurance ");
            //DataRow dr4 = dtt.NewRow();
            //dr4[0] = "Funeral’s Insurance ";
            ////dtquoteSummary.Merge(dtt4);
            ////dtquoteSummary.AcceptChanges();

            //// }
            //connection.Close();
            gvquotesummary1.DataSource = dtquoteSummary;
            gvquotesummary1.DataBind();
            //GridView1.DataSource = dtqsummary6;
            //GridView1.DataBind();
            //for (int i = 0; i < dtquoteSummary.Rows.Count; i++)
            //{

            //    if ((dtquoteSummary.Rows[i][0].ToString() == "Total"))
            //    {
            //        gvquotesummary1.Rows[i].BackColor = System.Drawing.Color.LightGray;
            //    }
            //    if ((dtquoteSummary.Rows[i][0].ToString() == "Life Insurance and Lump Sum Disability") || (dtquoteSummary.Rows[i][0].ToString() == "Trauma Insurance") || (dtquoteSummary.Rows[i][0].ToString() == "Group Income Insurance / Group IncomeCare (disability benefit)") || (dtquoteSummary.Rows[i][0].ToString() == "Spouse's Insurance") || (dtquoteSummary.Rows[i][0].ToString() == "Funeral Insurance"))
            //    {
            //        gvquotesummary1.Rows[i].BackColor = System.Drawing.Color.DarkGray;
            //    }
            //}

            #endregion

            #region Premium Tabs

            DataTable dtPrem = new DataTable();
            DataSet dsPremLSD1 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("SP_LifeInsuranceAndLSD"))
            {
                cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsPremLSD1);
                }
            }

            DataTable dtPrem1 = new DataTable();
            dtPrem1 = dsPremLSD1.Tables[0];
            DataRow drr = dtPrem1.NewRow();
            drr[0] = "Life Insurance and Lump Sum Disability";
            dtPrem1.Rows.InsertAt(drr, 0);

            dtPrem.Merge(dtPrem1);
            dtPrem.AcceptChanges();

            DataSet dsPremLSD2 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("SP_getTraumaInsurance"))
            {
                cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsPremLSD2);
                }
            }

            DataTable dtPrem2 = new DataTable();
            dtPrem2 = dsPremLSD2.Tables[0];
            DataRow drr2 = dtPrem2.NewRow();
            drr2[0] = "Trauma Insurance";
            dtPrem2.Rows.InsertAt(drr2, 0);

            dtPrem.Merge(dtPrem2);
            dtPrem.AcceptChanges();

            DataSet dsPremLSD3 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("SP_getDisabilityBenefit"))
            {
                cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsPremLSD3);
                }
            }

            DataTable dtPrem3 = new DataTable();
            dtPrem3 = dsPremLSD3.Tables[0];
            DataRow drr3 = dtPrem3.NewRow();
            drr3[0] = "Group Income Insurance / Group IncomeCare (PHI)";
            dtPrem3.Rows.InsertAt(drr3, 0);

            dtPrem.Merge(dtPrem3);
            dtPrem.AcceptChanges();


            DataSet dsPremLSD6 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("SP_getTemporaryIncomeInsurance"))
            {
                cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsPremLSD6);
                }
            }

            DataTable dtPrem6 = new DataTable();
            dtPrem6 = dsPremLSD6.Tables[0];
            DataRow drr6 = dtPrem6.NewRow();
            drr6[0] = "Group Temporary Income Insurance (TTD)";
            dtPrem6.Rows.InsertAt(drr6, 0);

            dtPrem.Merge(dtPrem6);
            dtPrem.AcceptChanges();


            DataSet dsPremLSD4 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("SP_getSpousesInsurance"))
            {
                cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsPremLSD4);
                }
            }

            DataTable dtPrem4 = new DataTable();
            dtPrem4 = dsPremLSD4.Tables[0];
            DataRow drr4 = dtPrem4.NewRow();
            drr4[0] = "Spouse's Insurance";
            dtPrem4.Rows.InsertAt(drr4, 0);

            dtPrem.Merge(dtPrem4);
            dtPrem.AcceptChanges();

            DataSet dsPremLSD5 = new DataSet();
            using (SqlCommand cmd = new SqlCommand("SP_getFuneralInsurance"))
            {
                cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsPremLSD5);
                }
            }

            DataTable dtPrem5 = new DataTable();
            dtPrem5 = dsPremLSD5.Tables[0];
            DataRow dr5 = dtPrem5.NewRow();
            dr5[0] = "Funeral Insurance";
            dtPrem5.Rows.InsertAt(dr5, 0);

            dtPrem.Merge(dtPrem5);
            dtPrem.AcceptChanges();

            //for (int i = 0; i < dtPrem.Rows.Count; i++)
            //{
            //    for (int k = 0; k < dtPrem.Columns.Count; k++)
            //    {
            //        object value = dtPrem.Rows[i][k];

            //        if ((value == DBNull.Value))
            //        {

            //            dtPrem.Rows[i][k] = 0.00;
            //        }
            //    }
            //}



            gvPremium1.DataSource = dtPrem;
            gvPremium1.DataBind();

            for (int i = 0; i < dtPrem.Rows.Count; i++)
            {

                if ((dtPrem.Rows[i][0].ToString() == "Total"))
                {
                    gvPremium1.Rows[i].BackColor = System.Drawing.Color.LightGray;
                }
                if ((dtPrem.Rows[i][0].ToString() == "Life Insurance and Lump Sum Disability") || (dtPrem.Rows[i][0].ToString() == "Trauma Insurance") || (dtPrem.Rows[i][0].ToString() == "Group Income Insurance / Group IncomeCare (PHI)") || (dtPrem.Rows[i][0].ToString() == "Group Temporary Income Insurance (TTD)") || (dtPrem.Rows[i][0].ToString() == "Spouse's Insurance") || (dtPrem.Rows[i][0].ToString() == "Funeral Insurance"))
                {
                    gvPremium1.Rows[i].BackColor = System.Drawing.Color.DarkGray;
                }
            }

          

            #endregion PremiumTab


            #region category cost tab

            DataTable dtcCost = new DataTable();
            int ii = 0;
            using (SqlCommand cmd = new SqlCommand("select COUNT(iCategoryNumber) from Category_Output where iQuoteNumber= " + lquoteNumber))
            {
                //connection.Open();

                cmd.Connection = connection;
                ii = Convert.ToInt32(cmd.ExecuteScalar());
            }



            for (int p = 0; p < ii; p++)
            {



                DataSet dscCost1 = new DataSet();
                using (SqlCommand cmd = new SqlCommand("SP_cLifeInsuranceAndLSD"))
                {
                    cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dscCost1);
                    }
                }

                DataTable dtcCost1 = new DataTable();
                dtcCost1 = dscCost1.Tables[0];
                DataRow dct33 = dtcCost1.NewRow();
                dct33[0] = "Category " + (p+1);
                dtcCost1.Rows.InsertAt(dct33, 0);
                DataRow drrc = dtcCost1.NewRow();
                drrc[0] = "Life Insurance and Lump Sum Disability";
                dtcCost1.Rows.InsertAt(drrc, 1);

                dtcCost.Merge(dtcCost1);
                dtcCost.AcceptChanges();

                DataSet dscCost2 = new DataSet();
                using (SqlCommand cmd = new SqlCommand("SP_cgetTraumaInsurance"))
                {
                    cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dscCost2);
                    }
                }
                DataTable dtcCost2 = new DataTable();
                dtcCost2 = dscCost2.Tables[0];

                DataRow drrs1 = dtcCost2.NewRow();

                drrs1[0] = "Trauma Insurance";
                dtcCost2.Rows.InsertAt(drrs1, 0);

                dtcCost.Merge(dtcCost2);
                dtcCost.AcceptChanges();

                DataSet dscCost3 = new DataSet();
                using (SqlCommand cmd = new SqlCommand("SP_cgetDisabilityBenefit"))
                {
                    cmd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dscCost3);
                    }


                    DataTable dtcCost3 = new DataTable();
                    dtcCost3 = dscCost3.Tables[0];
                    DataRow dct1 = dtcCost3.NewRow();
                    dct1[0] = "Group Income Insurance / Group IncomeCare (disability benefit)";
                    dtcCost3.Rows.InsertAt(dct1, 0);

                    dtcCost.Merge(dtcCost3);
                    dtcCost.AcceptChanges();


                    DataSet dsPremLSD66 = new DataSet();
                    using (SqlCommand cmdd = new SqlCommand("SP_cgetTemporaryIncomeInsurance"))
                    {
                        cmdd.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Connection = connection;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmdd))
                        {

                            sda.Fill(dsPremLSD66);
                        }
                    }

                    DataTable dtPrem66 = new DataTable();
                    dtPrem66 = dsPremLSD66.Tables[0];
                    DataRow drr66 = dtPrem66.NewRow();
                    drr66[0] = "Group Temporary Income Insurance (TTD)";
                    dtPrem66.Rows.InsertAt(drr66, 0);

                    dtcCost.Merge(dtPrem66);
                    dtcCost.AcceptChanges();


                    DataSet dscCost4 = new DataSet();
                    using (SqlCommand cmd1 = new SqlCommand("SP_cgetSpousesInsurance"))
                    {
                        cmd1.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Connection = connection;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                        {

                            sda.Fill(dscCost4);
                        }
                    }

                    DataTable dtcCost4 = new DataTable();
                    dtcCost4 = dscCost4.Tables[0];
                    DataRow dct2 = dtcCost4.NewRow();
                    dct2[0] = "Spouse's Insurance";
                    dtcCost4.Rows.InsertAt(dct2, 0);

                    dtcCost.Merge(dtcCost4);
                    dtcCost.AcceptChanges();

                    DataSet dscCost5 = new DataSet();
                    using (SqlCommand cmd1 = new SqlCommand("SP_cgetFuneralInsurance"))
                    {
                        //connection.Open();
                        cmd1.Parameters.Add("@_Quoteoutput_ID", SqlDbType.Int).Value = lquoteNumber;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Connection = connection;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                        {

                            sda.Fill(dscCost5);
                        }
                    }

                    DataTable dtcCost5 = new DataTable();
                    dtcCost5 = dscCost5.Tables[0];
                    DataRow dct3 = dtcCost5.NewRow();
                    dct3[0] = "Funeral Insurance";
                    dtcCost5.Rows.InsertAt(dct3, 0);

                    DataRow dct3_1 = dtcCost5.NewRow();
                    dct3_1[0]=" ";
                    
                    dtcCost5.Rows.InsertAt(dct3_1, 8);
                    
                    dtcCost.Merge(dtcCost5);
                    dtcCost.AcceptChanges();



                    gvCategoryCost.DataSource = dtcCost;
                    gvCategoryCost.DataBind();

//                  DataGridViewCell cell=null;
//// Get a cell you need here
//cell.Style = new DataGridViewCellStyle()
//{
//        BackColor = Color.White,
//        Font = new Font("Tahoma", 8F),
//        ForeColor = SystemColors.WindowText,
//        SelectionBackColor = Color.Red,
//        SelectionForeColor = SystemColors.HighlightText
//};

                    for (int i = 0; i < dtcCost.Rows.Count; i++)
                    {
                        if ((dtcCost.Rows[i][0].ToString() == "Category 1") || (dtcCost.Rows[i][0].ToString() == "Category 2"))
                        {
                           //.Font.Size = ;
                            gvCategoryCost.Rows[i].Font.Size = 22;
                            gvCategoryCost.Rows[i].Style.Add("font-family", "Cordia New");
                          
                        }
                        if ((dtcCost.Rows[i][0].ToString().Equals(' ')))
                        {
                            gvCategoryCost.Rows[i].BackColor = System.Drawing.Color.Black;
                        }

                        if ((dtcCost.Rows[i][0].Equals(' ')))
                        {
                            gvCategoryCost.Rows[i].BackColor = System.Drawing.Color.Black;
                        }


                        if ((dtcCost.Rows[i][0].ToString() == "Total"))
                        {
                            gvCategoryCost.Rows[i].BackColor = System.Drawing.Color.LightGray;
                        }
                        if ((dtcCost.Rows[i][0].ToString() == "Life Insurance and Lump Sum Disability") || (dtcCost.Rows[i][0].ToString() == "Group Temporary Income Insurance (TTD)") || (dtcCost.Rows[i][0].ToString() == "Category " + (p+1)) || (dtcCost.Rows[i][0].ToString() == "Trauma Insurance") || (dtcCost.Rows[i][0].ToString() == "Group Income Insurance / Group IncomeCare (disability benefit)") || (dtcCost.Rows[i][0].ToString() == "Spouse's Insurance") || (dtcCost.Rows[i][0].ToString() == "Funeral Insurance"))
                        {
                            gvCategoryCost.Rows[i].BackColor = System.Drawing.Color.DarkGray;
                        }
                    }

                }
            }

            #endregion category cost tab


            #region Category Rates

            DataTable dtben1 = new DataTable();
            DataSet dsCatRate = new DataSet();
            //using (SqlCommand cmd = new SqlCommand("select * from dbo.Category_Input where iQuoteNumber=" + lquoteNumber))
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwCatRatesBenfits] where iQuoteNumber="+lquoteNumber))
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
            int idx;
            DataTable dtCatRateTranspose = GenerateTransposedTableforCategoryRates(dtCatRate);
            idx = dtCatRateTranspose.Rows.Count;
            dtCatRateTranspose.Rows[idx - 1].Delete();
            dtCatRateTranspose.AcceptChanges();
            dtben1.Merge(dtCatRateTranspose);
            dtben1.AcceptChanges();


            DataSet dsCatRate1 = new DataSet();
            //using (SqlCommand cmd = new SqlCommand("select * from dbo.Category_Input where iQuoteNumber=" + lquoteNumber))
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwCatRatesTraumaInsurance] where iQuoteNumber="+lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsCatRate1);
                }
            }
            DataTable dtCatRate1 = new DataTable();
            dtCatRate1 = dsCatRate1.Tables[0];

            DataTable dtCatRateTranspose1 = GenerateTransposedTableforCategoryRates(dtCatRate1);
            idx = dtCatRateTranspose1.Rows.Count;
            dtCatRateTranspose1.Rows[idx - 1].Delete();
            dtCatRateTranspose1.AcceptChanges();
            dtben1.Merge(dtCatRateTranspose1);
            dtben1.AcceptChanges();




            DataSet dsCatRate2 = new DataSet();
            //using (SqlCommand cmd = new SqlCommand("select * from dbo.Category_Input where iQuoteNumber=" + lquoteNumber))
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwCatRatesDisabilityBenefit] where iQuoteNumber="+lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsCatRate2);
                }
            }
            DataTable dtCatRate2 = new DataTable();
            dtCatRate2 = dsCatRate2.Tables[0];

            DataTable dtCatRateTranspose2 = GenerateTransposedTableforCategoryRates(dtCatRate2);
            idx = dtCatRateTranspose2.Rows.Count;
            dtCatRateTranspose2.Rows[idx - 1].Delete();
            dtCatRateTranspose2.AcceptChanges();
            dtben1.Merge(dtCatRateTranspose2);
            dtben1.AcceptChanges();

            //vwCatRatesDisabilityBenefit


            DataSet dsCatRate33 = new DataSet();
            //using (SqlCommand cmd = new SqlCommand("select * from dbo.Category_Input where iQuoteNumber=" + lquoteNumber))
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwCatRatesGroupIncome] where iQuoteNumber=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsCatRate33);
                }
            }
            DataTable dtCatRate33 = new DataTable();
            dtCatRate33 = dsCatRate33.Tables[0];

            DataTable dtCatRateTranspose33 = GenerateTransposedTableforCategoryRates(dtCatRate33);
            idx = dtCatRateTranspose33.Rows.Count;
            dtCatRateTranspose33.Rows[idx - 1].Delete();
            dtCatRateTranspose33.AcceptChanges();
            dtben1.Merge(dtCatRateTranspose33);
            dtben1.AcceptChanges();




            DataSet dsCatRate3 = new DataSet();
            //using (SqlCommand cmd = new SqlCommand("select * from dbo.Category_Input where iQuoteNumber=" + lquoteNumber))
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwCatRatesSpousesInsurance] where iQuoteNumber="+lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsCatRate3);
                }
            }
            DataTable dtCatRate3 = new DataTable();
            dtCatRate3 = dsCatRate3.Tables[0];

            DataTable dtCatRateTranspose3 = GenerateTransposedTableforCategoryRates(dtCatRate3);
            idx = dtCatRateTranspose3.Rows.Count;
            dtCatRateTranspose3.Rows[idx - 1].Delete();
            dtCatRateTranspose3.AcceptChanges();
            dtben1.Merge(dtCatRateTranspose3);
            dtben1.AcceptChanges();




            DataSet dsCatRate4 = new DataSet();
            //using (SqlCommand cmd = new SqlCommand("select * from dbo.Category_Input where iQuoteNumber=" + lquoteNumber))
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[vwCatRatesFueralInsurance] where Quoteoutput_ID=" + lquoteNumber))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsCatRate4);
                }
            }
            DataTable dtCatRate4 = new DataTable();
            dtCatRate4 = dsCatRate4.Tables[0];

            DataTable dtCatRateTranspose4 = GenerateTransposedTableforCategoryRates(dtCatRate4);
            idx = dtCatRateTranspose4.Rows.Count;
            dtCatRateTranspose4.Rows[idx - 1].Delete();
            dtCatRateTranspose4.AcceptChanges();
            dtben1.Merge(dtCatRateTranspose4);
            dtben1.AcceptChanges();



            gvcategory1.DataSource = dtben1;
            gvcategory1.DataBind();

            for (int i = 0; i < dtben1.Rows.Count; i++)
            {

                if ((dtben1.Rows[i][0].ToString() == "TOTAL"))
                {
                    gvcategory1.Rows[i].BackColor = System.Drawing.Color.LightGray;
                }
                if ((dtben1.Rows[i][0].ToString() == "Life Insurance and Lump Sum Disability") || (dtben1.Rows[i][0].ToString() == "Group Temporary Income Insurance (TTD)") || (dtben1.Rows[i][0].ToString() == "Group Income Insurance / Group IncomeCare (PHI)") || (dtben1.Rows[i][0].ToString() == "Trauma Insurance") || (dtben1.Rows[i][0].ToString() == "Group Income Insurance / Group IncomeCare (disability benefit)") || (dtben1.Rows[i][0].ToString() == "Spouses Insurance") || (dtben1.Rows[i][0].ToString() == "Funeral Insurance"))
                {
                    gvcategory1.Rows[i].BackColor = System.Drawing.Color.DarkGray;
                }
            }
            //gvcategory1
           

            #endregion

            #region MEMBER Covers tab

            DataSet dsmembercover = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select c.iFullName as 'Name', cast(ROUND(o.cTotCoverGLA,2) as numeric(18,2))  as 'Life ',cast(ROUND(o.cTotCoverPTD,2) as numeric(18,2))  as 'Lump Sum Disability',cast(ROUND(o.cTotCoverCII,2) as numeric(18,2))   as 'Critical Illness',cast(ROUND(o.cTotCoverPHI,2) as numeric(18,2))  as 'PHI (incl Waiver)', cast(ROUND(o.cTotCoverTTD,2) as numeric(18,2))  as 'TTD (incl Waiver)',cast(ROUND(o.cTotCoverFUN,2) as numeric(18,2))  as 'Funeral',cast(ROUND(o.cTotCoverSGLA,2) as numeric(18,2))  as 'Spouses Life',cast(ROUND(o.cTotCoverSPTD,2) as numeric(18,2))  as 'Spouses Lump Sum Disability'  from Member_Output as o INNER JOIN Member_Input  as c ON c.iQuoteNumber = o.iQuoteNumber AND c.iMemberNumber = o.iMemberNumber where o.iQuoteNumber= " + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsmembercover);
                }
            }
            DataTable dtsmembercover = new DataTable();
            dtsmembercover = dsmembercover.Tables[0];

            DataRow dqss5 = dtsmembercover.NewRow();
          //  dqss5[0] = "MEMBER CoverS tab";
           // dtsmembercover.Rows.InsertAt(dqss5, 0);


            gvMemberCovers.DataSource = dtsmembercover;
            gvMemberCovers.DataBind();
            
            #endregion MEMBER Covers tab

            #region MEMBER COSTS tab

            DataSet dsmembercost = new DataSet();
            using (SqlCommand cmd = new SqlCommand("select c.iFullName as 'Name',cast(ROUND(i.cTotPremLife_cr,2) as numeric(18,2))  as 'Life & Lump Sum Disability' ,cast(ROUND(i.cTotPremCII_cr,2) as numeric(18,2))  as 'Critical Illness', cast(ROUND(i.cTotPremIncDis_cr ,2) as numeric(18,2)) as 'PHI (incl Waiver)' ,cast(ROUND(i.cTotPremTIncDis_cr ,2) as numeric(18,2))  as 'TTD (incl Waiver)',cast(ROUND(i.cTotPremFUN_cr ,2) as numeric(18,2)) as 'Funeral' ,cast(ROUND(i.cTotPremSpouses_cr ,2) as numeric(18,2))  as 'Spouses'  from Member_Input as c LEFT JOIN Member_Output as i ON c.iQuoteNumber = i.iQuoteNumber AND c.iMemberNumber = i.iMemberNumber where c.iQuoteNumber= " + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dsmembercost);
                }
            }
            DataTable dtsmembercost = new DataTable();

           

            dtsmembercost.Columns.Add("Name");
            dtsmembercost.Columns.Add("Life & Lump Sum Disability");
            dtsmembercost.Columns.Add("Critical Illness");
            dtsmembercost.Columns.Add("PHI (incl Waiver)");
            dtsmembercost.Columns.Add("TTD (incl Waiver)");
            dtsmembercost.Columns.Add("Funeral");
            dtsmembercost.Columns.Add("Spouses");

            dtsmembercost = dsmembercost.Tables[0];

            gvMemberCost.DataSource = dtsmembercost;
            gvMemberCost.DataBind();
            

            #endregion MEMBER COSTS tab


            #region Free cover limits

            DataTable dtFreeCoverLimits = new DataTable();

            DataTable dtf1 = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select cMPFLvalueGLA as 'Medical Proof Free Limit' from Quote_Output where Quoteoutput_ID=" + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtf1);
                }
            }

          
            dtf1.AcceptChanges();
            DataTable dtff1 = GenerateTransposedTableforQuoteSummary(dtf1);
            dtff1.AcceptChanges();

            DataTable dtf_1 = new DataTable();
            dtf_1.Columns.Add("Life Insurance ");

            //DataTable dtff1_1 = GenerateTransposedTableforQuoteSummary(dtf_1);
            //dtff1_1.AcceptChanges();

            //DataRow dqs44 = dtff1.NewRow();
            //dqs4 = "Spouse’s Insurance";
            //dtqsummary4.Rows.InsertAt(dqs4, 0);


            dtFreeCoverLimits.Merge(dtf_1);
            dtFreeCoverLimits.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff1);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtf2 = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select cMPFLvalueCII as 'Medical Proof Free Limit' from Quote_Output where Quoteoutput_ID=" + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtf2);
                }
            }


            DataTable dtf_2 = new DataTable();
            dtf_2.Columns.Add("Trauma Insurance");

            DataTable dtff1_2 = GenerateTransposedTableforQuoteSummary(dtf_2);
            dtff1_2.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff1_2);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtff2 = GenerateTransposedTableforQuoteSummary(dtf2);
            dtff2.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff2);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtf3 = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select cMPFLvaluePHI as 'Medical Proof Free Limit' from Quote_Output where Quoteoutput_ID=" + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtf3);
                }
            }

            DataTable dtf_3 = new DataTable();
            dtf_3.Columns.Add("Group Income Benefit (disability benefit)");

            DataTable dtff1_3 = GenerateTransposedTableforQuoteSummary(dtf_3);
            dtff1_3.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff1_3);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtff3 = GenerateTransposedTableforQuoteSummary(dtf3);
            dtff3.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff3);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtf4 = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select cMPFLvaluePHI as 'Medical Proof Free Limit' from Quote_Output where Quoteoutput_ID=" + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtf4);
                }
            }

            DataTable dtf_4 = new DataTable();
            dtf_4.Columns.Add("Group Income Benefit (disability benefit)");

            DataTable dtff1_4 = GenerateTransposedTableforQuoteSummary(dtf_4);
            dtff1_4.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff1_4);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtff4 = GenerateTransposedTableforQuoteSummary(dtf4);
            dtff4.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff4);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtf5 = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select cMPFLvalueTTD as 'Medical Proof Free Limit' from Quote_Output where Quoteoutput_ID=" + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtf5);
                }
            }
            DataTable dtf_5 = new DataTable();
            dtf_5.Columns.Add("Group Temporary Income Benefit (TTD)");

            DataTable dtff1_5 = GenerateTransposedTableforQuoteSummary(dtf_5);
            dtff1_5.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff1_5);
            dtFreeCoverLimits.AcceptChanges();


            DataTable dtff5 = GenerateTransposedTableforQuoteSummary(dtf5);
            dtff5.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff5);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtf6 = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select cMPFLvalueTTD as 'Medical Proof Free Limit' from Quote_Output where Quoteoutput_ID=" + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtf6);
                }
            }

            DataTable dtf_6 = new DataTable();
            dtf_6.Columns.Add("Group Temporary Income Benefit (TTD)");

            DataTable dtff1_6 = GenerateTransposedTableforQuoteSummary(dtf_6);
            dtff1_6.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff1_6);
            dtFreeCoverLimits.AcceptChanges();
            DataTable dtff6 = GenerateTransposedTableforQuoteSummary(dtf6);
            dtff6.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff6);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtf7 = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select cMPFLvalueSGLA as 'Medical Proof Free Limit' from Quote_Output where Quoteoutput_ID=" + lquoteNumber))
            {
                //connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    sda.Fill(dtf7);
                }
            }

            DataTable dtf_7 = new DataTable();
            dtf_7.Columns.Add("Spouses Insurance");

            DataTable dtff1_7 = GenerateTransposedTableforQuoteSummary(dtf_7);
            dtff1_7.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff1_7);
            dtFreeCoverLimits.AcceptChanges();

            DataTable dtff7 = GenerateTransposedTableforQuoteSummary(dtf7);
            dtff7.AcceptChanges();

            dtFreeCoverLimits.Merge(dtff7);
            dtFreeCoverLimits.AcceptChanges();

            for (int i = 0; i < dtFreeCoverLimits.Rows.Count; i++)
            {
                for (int k = 0; k < dtFreeCoverLimits.Columns.Count; k++)
                {
                    object value = dtFreeCoverLimits.Rows[i][k];

                    if ((value == DBNull.Value))
                    {

                        dtFreeCoverLimits.Rows[i][k] = 0.00;
                    }
                }
            }


            gvFreeCoverLimits.DataSource = dtFreeCoverLimits;
            gvFreeCoverLimits.DataBind();

           
            for (int i = 0; i < dtFreeCoverLimits.Rows.Count; i++)
            {

                if ((dtFreeCoverLimits.Rows[i][0].ToString() == "Life Insurance ") || (dtFreeCoverLimits.Rows[i][0].ToString() == "Trauma Insurance") || (dtFreeCoverLimits.Rows[i][0].ToString() == "Group Income Benefit (disability benefit)") || (dtFreeCoverLimits.Rows[i][0].ToString() == "Group Temporary Income Benefit (TTD)") || (dtFreeCoverLimits.Rows[i][0].ToString() == "Spouses Insurance"))
                {
                    gvFreeCoverLimits.Rows[i].BackColor = System.Drawing.Color.DarkGray;
                }
            }

            #endregion  Free cover limits


            #region expectation

            DataTable dsexpectation = new DataTable();

            using (SqlCommand cmd = new SqlCommand("select iFullName as 'Name',iDOB as 'Date of Birth' from Member_Input where iQuoteNumber = " + lquoteNumber))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dsexpectation);
                    }
                }

                gvexpectation.DataSource = dsexpectation;
                gvexpectation.DataBind();

                DataTable dsexpectation1 = new DataTable();

                using (SqlCommand cmd = new SqlCommand("select i.iFullName as 'Name',i.iDOB as 'Date of Birth',i.iAnnualSalary as 'Salary',cast(ROUND(o.cTotCoverGLA,2) as numeric(18,2))  as 'Cover',o.cMPFLvalueGLA as 'Medical Proof Free Limit' from Quote_Output as o INNER JOIN Member_Input as i ON o.Quoteoutput_ID = i.iQuoteNumber Where i.iQuoteNumber = " + lquoteNumber))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dsexpectation1);
                    }
                }

                gvexpectation1.DataSource = dsexpectation1;
                gvexpectation1.DataBind();

                DataTable dsexpectation2 = new DataTable();

                using (SqlCommand cmd = new SqlCommand("select i.iFullName as 'Name',i.iDOB as 'Date of Birth',i.iAnnualSalary as 'Salary',cast(ROUND(o.cTotCoverCII,2) as numeric(18,2))  as 'Cover (incl Waiver)',o.cMPFLvaluePHI as 'Medical Proof Free Limit' from Quote_Output as o INNER JOIN Member_Input as i ON o.Quoteoutput_ID = i.iQuoteNumber Where i.iQuoteNumber = " + lquoteNumber))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dsexpectation2);
                    }
                }

                gvexpectation2.DataSource = dsexpectation2;
                gvexpectation2.DataBind();

                DataTable dsexpectation3 = new DataTable();

                using (SqlCommand cmd = new SqlCommand("select i.iFullName as 'Name',i.iDOB as 'Date of Birth',i.iAnnualSalary as 'Salary',cast(ROUND(o.cTotCoverPHIincWaiver,2) as numeric(18,2))  as 'Cover (incl Waiver)',o.cMPFLvaluePHI as 'Medical Proof Free Limit' from Quote_Output as o INNER JOIN Member_Input as i ON o.Quoteoutput_ID = i.iQuoteNumber Where i.iQuoteNumber = " + lquoteNumber))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dsexpectation3);
                    }
                }

                gvexpectation3.DataSource = dsexpectation3;
                gvexpectation3.DataBind();

                DataTable dsexpectation4 = new DataTable();

                using (SqlCommand cmd = new SqlCommand("select i.iFullName as 'Name',i.iDOB as 'Date of Birth',i.iAnnualSalary as 'Salary',cast(ROUND(o.cTotCoverTTDincWaiver,2) as numeric(18,2))  as 'Cover (incl Waiver)',o.cMPFLvaluePHI as 'Medical Proof Free Limit' from Quote_Output as o INNER JOIN Member_Input as i ON o.Quoteoutput_ID = i.iQuoteNumber Where i.iQuoteNumber = " + lquoteNumber))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dsexpectation4);
                    }
                }

                gvexpectation4.DataSource = dsexpectation4;
                gvexpectation4.DataBind();

                DataTable dsexpectation5 = new DataTable();

                using (SqlCommand cmd = new SqlCommand("select i.iFullName as 'Name',i.iDOB as 'Date of Birth',i.iAnnualSalary as 'Member Salary',cast(ROUND(o.cTotCoverSGLA,2) as numeric(18,2))  as 'Spouses Cover',o.cMPFLvalueSGLA as 'Medical Proof Free Limit' from Quote_Output as o INNER JOIN Member_Input as i ON o.Quoteoutput_ID = i.iQuoteNumber Where i.iQuoteNumber = " + lquoteNumber))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dsexpectation5);
                    }
                }

                gvexpectation5.DataSource = dsexpectation5;
                gvexpectation5.DataBind();

                //DataTable dsexpectation6 = new DataTable();

                //using (SqlCommand cmd = new SqlCommand("select cTotCountPHI as 'Number of members (PHI)',cTotCountTTD as 'Number of members (TTD)',cTotAnnualSalaryPHI as 'Total annual salaries',cTotCoverPHI as 'Total income insurance (excl waiver) (PHI)',cTotCoverTTD as 'Total income insurance (excl waiver) (TTD)',cTotCoverPHIwaiver as 'Total employer waiver (PHI)',cTotCoverTTDwaiver as 'Total employer waiver (TTD)',cTotIncDisPremIncCommBind as 'Estimated annual premium' from CategorQuote_Outputy_Output "))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    cmd.Connection = connection;
                //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                //    {

                //        sda.Fill(dsexpectation6);
                //    }
                //}

                //gvexpectation5.DataSource = dsexpectation6;
                //gvexpectation5.DataBind();

                //DataTable dsexpectation6 = new DataTable();

                //using (SqlCommand cmd = new SqlCommand("select iFullName as 'Name',iDOB as 'Date of Birth', from Member_Input "))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    cmd.Connection = connection;
                //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                //    {

                //        sda.Fill(dsexpectation6);
                //    }
                //}

                //gvexpectation6.DataSource = dsexpectation6;
                //gvexpectation6.DataBind();


            #endregion expectation
            
            
            }
        }
      
    





    private DataTable GenerateTransposedTableforFuneralInsurance(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows


        //outputTable.Columns.Add("iQuoteNumber", typeof(Int32));
        outputTable.Columns.Add("BenefitName", typeof(string));

        // Header row's first column is same as in inputTable
        //outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        int i = 1;
        foreach (DataRow inRow in inputTable.Rows)
        {
            // string newColName = inRow[0].ToString();
            outputTable.Columns.Add("Category" + i.ToString(), typeof(string));
            i++;

        }

        // Add rows by looping columns        
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }

        return outputTable;
    }

    private DataTable GenerateTransposedTablefordtdisabilitybenefit(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows


        //outputTable.Columns.Add("iQuoteNumber", typeof(Int32));
        outputTable.Columns.Add("BenefitName", typeof(string));

        // Header row's first column is same as in inputTable
        //outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        int i = 1;
        foreach (DataRow inRow in inputTable.Rows)
        {
            // string newColName = inRow[0].ToString();
            outputTable.Columns.Add("Category" + i.ToString(), typeof(string));
            i++;

        }

        // Add rows by looping columns        
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }

        return outputTable;
    }

    private DataTable GenerateTransposedTableforSpousesInsurance(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows


        //outputTable.Columns.Add("iQuoteNumber", typeof(Int32));
        outputTable.Columns.Add("BenefitName", typeof(string));

        // Header row's first column is same as in inputTable
      //  //outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        int i = 1;
        foreach (DataRow inRow in inputTable.Rows)
        {
            // string newColName = inRow[0].ToString();
            outputTable.Columns.Add("Category" + i.ToString(), typeof(string));
            i++;

        }

        // Add rows by looping columns        
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }

        return outputTable;
    }

    private DataTable GenerateTransposedTableforQuoteSummary(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows


        //outputTable.Columns.Add("iQuoteNumber", typeof(Int32));
        outputTable.Columns.Add("BenefitName", typeof(string));

        // Header row's first column is same as in inputTable
        //outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        int i = 1;
        foreach (DataRow inRow in inputTable.Rows)
        {
            // string newColName = inRow[0].ToString();
            outputTable.Columns.Add(" ", typeof(string));
            i++;

        }

        // Add rows by looping columns        
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }

        return outputTable;
    }

    private DataTable GenerateTransposedTableforCategoryRates(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows


        //outputTable.Columns.Add("iQuoteNumber", typeof(Int32));
        outputTable.Columns.Add("BenefitName", typeof(string));

        // Header row's first column is same as in inputTable
        //outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        int i = 1;
        foreach (DataRow inRow in inputTable.Rows)
        {
            // string newColName = inRow[0].ToString();
            outputTable.Columns.Add("Category " + i.ToString() + " : Premium as % of qualifying members’ salaries", typeof(string));
            i++;

        }

        // Add rows by looping columns        
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }

        return outputTable;
    }
    

    //private void PopulateBenSummary(Quote lQuote, Category[] lcat)
    //{
        
    //    #region /* Second Table */
    //    int k = 1;
    //    foreach (Category lcategory in lcat)
    //    {
    //        if ((lcategory[i].iGLApattern == "AgeBanded") || (lcategory[i].iPTDpattern == "AgeBanded"))
    //        {
    //            k = 1;
    //        }
    //    }
    //    if (k == 1)
    //    {


    //        StringBuilder sb1 = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'><tr class='catHeadlines'>");
    //        sb1.Append("<th>Life Insurance and Lump Sum Disability Age Banded Benefits</th>");
    //        i = 1;
    //        foreach (Category lcategory in lcat)
    //        {

    //            // divLifeInsuranceandLSDAgeBandedBenefits.Visible = true;
    //            sb1.Append("<th>Category " + i + "</th>");

    //            i++;
    //        }
    //        sb1.Append("</tr>");

    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern != "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>1st Age Cut Off</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeCutOff1 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }

    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern != "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>2nd Age Cut Off</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeCutOff2 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }

    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern != "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>3rd Age Cut Off</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeCutOff3 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }

    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern != "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>4th Age Cut Off</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeCutOff4 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }

    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern != "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>5th Age Cut Off</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeCutOff5 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }

    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern != "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>6th Age Cut Off</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeCutOff6 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }

    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern != "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>7th Age Cut Off</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeCutOff7 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }

    //        //    //j = 0;
    //        //    //foreach (Category lcategory in lcat)
    //        //    //{
    //        //    //    if (lcategory[i].iGLApattern != "AgeBanded")
    //        //    //    {
    //        //    //        j = 1;
    //        //    //    }
    //        //    //}
    //        //    //if (j == 1)
    //        //    //{
    //        //sb1.Append("<tr>");
    //        //sb1.Append("<td>Tax Replacement Cover</td>");
    //        //foreach (Category lcategory in lcat)
    //        //{
    //        //    sb1.Append("<td>" + lcategory[i].iHasTaxReplCover + "</td>");
    //        //}
    //        //sb1.Append("</tr>");
    //        //    //}
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern == "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr class='catSubHead'>");
    //        sb1.Append("<td>Life Cover Band 1</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeMultGLA1 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern == "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>Life Cover Band 2</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeMultGLA2 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern == "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>Life Cover Band 3</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeMultGLA3 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern == "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>Life Cover Band 4</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeMultGLA4 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern == "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>Life Cover Band 5</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeMultGLA5 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern == "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>Life Cover Band 6</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeMultGLA6 + "</td>");
    //        }
    //        //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern == "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>Life Cover Band 7</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeMultGLA7 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //    {
    //        //        if (lcategory[i].iGLApattern == "AgeBanded")
    //        //        {
    //        //            j = 1;
    //        //        }
    //        //    }
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>Life Cover Band 8</td>");
    //        foreach (Category lcategory in lcat)
    //        {
    //            sb1.Append("<td>" + lcategory[i].iAgeMultGLA8 + "</td>");
    //        }
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //        if (lcategory[i].iPTDpattern == "AgeBanded")
    //        //            j = 1;
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr class='catSubHead'>");
    //        sb1.Append("<td>LSD Cover Band 1</td>");
    //        foreach (Category lcategory in lcat)
    //            sb1.Append("<td>" + lcategory[i].iAgeMultPTD1 + "</td>");
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //        if (lcategory[i].iPTDpattern == "AgeBanded")
    //        //            j = 1;
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>LSD Cover Band 2</td>");
    //        foreach (Category lcategory in lcat)
    //            sb1.Append("<td>" + lcategory[i].iAgeMultPTD2 + "</td>");
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //        if (lcategory[i].iPTDpattern == "AgeBanded")
    //        //            j = 1;
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>LSD Cover Band 3</td>");
    //        foreach (Category lcategory in lcat)
    //            sb1.Append("<td>" + lcategory[i].iAgeMultPTD3 + "</td>");
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //        if (lcategory[i].iPTDpattern == "AgeBanded")
    //        //            j = 1;
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>LSD Cover Band 4</td>");
    //        foreach (Category lcategory in lcat)
    //            sb1.Append("<td>" + lcategory[i].iAgeMultPTD4 + "</td>");
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //        if (lcategory[i].iPTDpattern == "AgeBanded")
    //        //            j = 1;
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>LSD Cover Band 5</td>");
    //        foreach (Category lcategory in lcat)
    //            sb1.Append("<td>" + lcategory[i].iAgeMultPTD5 + "</td>");
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //        if (lcategory[i].iPTDpattern == "AgeBanded")
    //        //            j = 1;
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>LSD Cover Band 6</td>");
    //        foreach (Category lcategory in lcat)
    //            sb1.Append("<td>" + lcategory[i].iAgeMultPTD6 + "</td>");
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //        if (lcategory[i].iPTDpattern == "AgeBanded")
    //        //            j = 1;
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>LSD Cover Band 7</td>");
    //        foreach (Category lcategory in lcat)
    //            sb1.Append("<td>" + lcategory[i].iAgeMultPTD7 + "</td>");
    //        sb1.Append("</tr>");
    //        //    }
    //        //    j = 0;
    //        //    foreach (Category lcategory in lcat)
    //        //        if (lcategory[i].iPTDpattern == "AgeBanded")
    //        //            j = 1;
    //        //    if (j == 1)
    //        //    {
    //        sb1.Append("<tr>");
    //        sb1.Append("<td>LSD Cover Band 8</td>");
    //        foreach (Category lcategory in lcat)
    //            sb1.Append("<td>" + lcategory[i].iAgeMultPTD8 + "</td>");
    //        sb1.Append("</tr>");
    //        //    }

    //        sb1.Append("</table>");
    //        divLifeInsuranceandLSDAgeBandedBenefits.InnerHtml = sb1.ToString();
    //        sb1.Clear();
    //    }
    //    #endregion
    //        #region  /*third table*/
    //    //    k = 0;
    //    //    foreach (Category lcategory in lcat)
    //    //    {
    //    //        if (Convert.ToBoolean(lcategory[i].iHasCII))
    //    //        {
    //    //            k = 1;
    //    //        }
    //    //    }
    //    //    if (k == 1)
    //    //    {
    //    StringBuilder sb2 = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'>");
    //    sb2.Append("<tr class='catHeadlines'><th>Trauma Insurance</th>");
    //    i = 1;
    //    foreach (Category lcategory in lcat)
    //    {

    //        // divLifeInsuranceandLSDAgeBandedBenefits.Visible = true;
    //        sb2.Append("<th>Category " + i + "</th>");

    //        i++;
    //    }
    //    //        sb2.Append("</tr>");

    //    //        j = 0;
    //    //        foreach (Category lcategory in lcat)
    //    //        {
    //    //            if (!Convert.ToBoolean(lcategory[i].iCIIisFlatAmt))
    //    //            {
    //    //                j = 1;
    //    //            }
    //    //        }
    //    //        if (j == 1)
    //    //        {
    //    sb2.Append("<tr>");
    //    sb2.Append("<td>Trauma Insurance</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb2.Append("<td>" + lcategory[i].iCIImultiple + "</td>");
    //    }
    //    sb2.Append("</tr>");
    //    //        }
    //    //        j = 0;
    //    //        foreach (Category lcategory in lcat)
    //    //        {
    //    //            if (Convert.ToBoolean(lcategory[i].iCIIisFlatAmt))
    //    //            {
    //    //                j = 1;
    //    //            }
    //    //        }
    //    //        if (j == 1)
    //    //        {
    //    sb2.Append("<tr>");
    //    sb2.Append("<td>Trauma Insurance</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb2.Append("<td>" + lcategory[i].iCIIflatCoverAmt + "</td>");
    //    }
    //    sb2.Append("</tr>");
    //    //        }

    //            sb2.Append("<tr>");
    //            sb2.Append("<td>Trauma Type</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb2.Append("<td>" + lcategory[i].iCIItype + "</td>");
    //            }
    //            sb2.Append("</tr>");

    //            sb2.Append("<tr>");
    //            sb2.Append("<td>Conversion Option</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb2.Append("<td>" + lcategory[i].iCIIhasConverOption + "</td>");
    //            }
    //            sb2.Append("</tr>");

    //            sb2.Append("<tr>");
    //            sb2.Append("<td>Continuation of Trauma Cover during Disability</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb2.Append("<td>" + lcategory[i].iCIIhasCOC + "</td>");
    //            }
    //            sb2.Append("</tr>");

    //            sb2.Append("<tr>");
    //            sb2.Append("<td>Growth in Trauma Benefit while Disabled</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb2.Append("<td>" + lcategory[i].iCIIgic + "</td>");
    //            }
    //            sb2.Append("</tr>");

    //            sb2.Append("</table>");
    //            divTaumaInsurance.InnerHtml = sb2.ToString();
    //            sb2.Clear();
    //        //}s
    //        #endregion
    //    #region /* table 4 */
    //    //    k = 0;
    //    //    foreach (Category lcategory in lcat)
    //    //    {
    //    //        if (Convert.ToBoolean(lcategory[i].iHasPHI))
    //    //        {
    //    //            k = 1;
    //    //        }
    //    //    }
    //    //    if (k == 1)
    //    //    {


    //            StringBuilder sb3 = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'><tr class='catHeadlines'>");
    //            sb3.Append("<th>Group Income Insurance / Group IncomeCare (disability benefit)</th>");
    //            i = 1;
    //            foreach (Category lcategory in lcat)
    //            {

    //                // divLifeInsuranceandLSDAgeBandedBenefits.Visible = true;
    //                sb3.Append("<th>Category " + i + "</th>");

    //                i++;
    //            }
    //            sb3.Append("</tr>");


    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Benefit Scale</td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iPHIscaleType + "</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Waiting Period</td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iPHIwaitingPeriod + " months</td>");
    //            sb3.Append("</tr>");

    //    //        j = 0;
    //    //        foreach (Category lcategory in lcat)
    //    //        {
    //    //            if (!(Convert.ToBoolean(lcategory[i].iHasPHIaltEsc)))
    //    //            {
    //    //                j = 1;
    //    //            }
    //    //        }
    //    //        if (j == 1)
    //    //        {
    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Benefit Escalation</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb3.Append("<td>" + lcategory[i].iPHIescPerc + " %</td>");
    //            }
    //            sb3.Append("</tr>");
    //    //        }
    //    //        j = 0;
    //    //        foreach (Category lcategory in lcat)
    //    //        {
    //    //            if (Convert.ToBoolean(lcategory[i].iHasPHIaltEsc))
    //    //            {
    //    //                j = 1;
    //    //            }
    //    //        }
    //    //        if (j == 1)
    //    //        {
    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Benefit Escalation</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb3.Append("<td>" + lcategory[i].iPHIaltEsc + "</td>");
    //            }
    //            sb3.Append("</tr>");
    //    //        }
    //    //        sb3.Append("<tr>");
    //    //        sb3.Append("<td>Employer Waiver</td>");
    //    //        foreach (Category lcategory in lcat)
    //    //            sb3.Append("<td>" + lcategory[i].iPHIwaiverPerc + "</td>");
    //    //        sb3.Append("</tr>");
    //    //        j = 0;
    //    //        foreach (Category lcategory in lcat)
    //    //        {
    //    //            if (Convert.ToBoolean(lcategory[i].iHasPHIaltOccDefn))
    //    //            {
    //    //                j = 1;
    //    //            }
    //    //        }
    //    //        if (j == 1)
    //    //        {
    //            sb3.Append("<tr>");
    //            sb3.Append("<td>PHI Occupation Definition</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb3.Append("<td>" + lcategory[i].iPHIoccDefn + "</td>");
    //            }
    //            sb3.Append("</tr>");
    //    //        }

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Conversion Option</td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iPHIhasConverOption + "</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Medical Aid Premium Waiver </td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iHasMAPW + "</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Medical Aid Premium Waiver </td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iHasMAPW + "</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Medical Aid Premium Waiver </td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iHasMAPW + "</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Medical Aid Premium Waiver Term </td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iMAPWPmtTerm + " months</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Salary Refund </td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iHasSalaryRefund + "</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Salary Refund Multiple </td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iHasSalaryRefund + "</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("<tr>");
    //            sb3.Append("<td>Top-Up </td>");
    //            foreach (Category lcategory in lcat)
    //                sb3.Append("<td>" + lcategory[i].iHasTopUp + "</td>");
    //            sb3.Append("</tr>");

    //            sb3.Append("</table>");
    //            divdisabilitybenefit.InnerHtml = sb3.ToString();
    //            sb3.Clear();
    //        //}
    //        #endregion

    //        //#region /* table-5 */
    //        //k = 0;
    //        //foreach (Category lcategory in lcat)
    //        //{
    //        //    if (Convert.ToBoolean(lcategory[i].iHasSGLA) || Convert.ToBoolean(lcategory[i].iHasSPTD))
    //        //    {
    //        //        k = 1;
    //        //    }
    //        //}
    //        //if (k == 1)
    //        //{


    //    //        StringBuilder sb5 = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'><tr class='catHeadlines'>");
    //    //        sb5.Append("<th></th>");
    //    //        i = 1;
    //    //        foreach (Category lcategory in lcat)
    //    //        {

    //    //            // divLifeInsuranceandLSDAgeBandedBenefits.Visible = true;
    //    //            sb5.Append("<th>Category " + i + "</th>");

    //    //            i++;
    //    //        }
    //    //        sb5.Append("</tr>");
    //    //        sb5.Append("<tr>");
    //    //        sb5.Append("<td>Disability Benefit </td>");
    //    //        foreach (Category lcategory in lcat)
    //    //            sb5.Append("<td></td>");
    //    //        sb5.Append("/<tr>");

    //    //        sb5.Append("<tr>");
    //    //        sb5.Append("<td>Medical Aid Premium Waiver Term </td>");
    //    //        foreach (Category lcategory in lcat)
    //    //            sb5.Append("<td>" + lcategory[i].iMAPWPmtTerm + " months</td>");
    //    //        sb5.Append("/<tr>");

    //    //        sb5.Append("<tr>");
    //    //        sb5.Append("<td>Salary Refund </td>");
    //    //        foreach (Category lcategory in lcat)
    //    //            sb5.Append("<td>" + lcategory[i].iHasSalaryRefund + "</td>");
    //    //        sb5.Append("/<tr>");

    //    //        sb5.Append("<tr>");
    //    //        sb5.Append("<td>Salary Refund Multiple </td>");
    //    //        foreach (Category lcategory in lcat)
    //    //            sb5.Append("<td>" + lcategory[i].iHasSalaryRefund + "</td>");
    //    //        sb5.Append("/<tr>");

    //    //        sb5.Append("<tr>");
    //    //        sb5.Append("<td>Top-Up </td>");
    //    //        foreach (Category lcategory in lcat)
    //    //            sb5.Append("<td>" + lcategory[i].iHasTopUp + "</td>");
    //    //        sb5.Append("/<tr>");

    //    //        sb5.Append("</table>");
    //    //        divTaumaInsurance.InnerHtml = sb5.ToString();
    //    //        sb5.Clear();
    //    ////    }
    //        //#endregion
    //        #region /* table-6 */
    //    //    k = 0;
    //    //    foreach (Category lcategory in lcat)
    //    //    {
    //    //        if (Convert.ToBoolean(lcategory[i].iHasSGLA) || Convert.ToBoolean(lcategory[i].iHasSPTD))
    //    //        {
    //    //            k = 1;
    //    //        }
    //    //    }
    //    //    if (k == 1)
    //    //    {


    //            StringBuilder sb6 = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'><tr class='catHeadlines'>");
    //            sb6.Append("<th>Spouse’s Insurance</th>");
    //            i = 1;
    //            foreach (Category lcategory in lcat)
    //            {

    //                // divLifeInsuranceandLSDAgeBandedBenefits.Visible = true;
    //                sb6.Append("<th>Category " + i + "</th>");

    //                i++;
    //            }
    //            sb6.Append("</tr>");



    //            //j = 0;
    //            //foreach (Category lcategory in lcat)
    //            //    if (!(Convert.ToBoolean(lcategory[i].iSGLAisFlatAmt)))
    //            //        j = 1;

    //            //if (j == 1)
    //            //{
    //                sb6.Append("<tr>");
    //                sb6.Append("<td>Spouses Life Insurance</td>");
    //                foreach (Category lcategory in lcat)
    //                    sb6.Append("<td>" + lcategory[i].iSGLAmultiple + " %</td>");
    //                sb6.Append("</tr>");
    //            //}
    //            //j = 0;
    //            //foreach (Category lcategory in lcat)
    //            //    if ((Convert.ToBoolean(lcategory[i].iSGLAisFlatAmt)))
    //            //        j = 1;

    //            //if (j == 1)
    //            //{
    //                sb6.Append("<tr>");
    //                sb6.Append("<td>Spouses Life Insurance</td>");
    //                foreach (Category lcategory in lcat)
    //                    sb6.Append("<td>" + lcategory[i].iSGLAmultiple + " %</td>");
    //                sb6.Append("</tr>");
    //            //}
    //            sb6.Append("<tr>");
    //            sb6.Append("<td>Conversion Option</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb6.Append("<td>" + lcategory[i].iSGLAhasConverOption + "</td>");
    //            }
    //            sb6.Append("</tr>");

    //            //j = 0;
    //            //foreach (Category lcategory in lcat)
    //            //    if ((Convert.ToBoolean(lcategory[i].iSGOAisFlatAmt)))
    //            //        j = 1;

    //            //if (j == 1)
    //            //{
    //            sb6.Append("<tr>");
    //            sb6.Append("<td>Spouses LSD Insurance</td>");
    //            foreach (Category lcategory in lcat)
    //                sb6.Append("<td>" + lcategory[i].iSPTDflatCoverAmt + "</td>");

    //            sb6.Append("</tr>");
    //            //}

    //            sb6.Append("<tr>");
    //            sb6.Append("<td>Conversion Option</td>");
    //            foreach (Category lcategory in lcat)
    //            {
    //                sb6.Append("<td>" + lcategory[i].iSPTDhasConverOption + "</td>");
    //            }
    //            sb6.Append("</tr>");



    //            sb6.Append("</table>");
    //            divSpousesLifeInsurance.InnerHtml = sb6.ToString();
    //            sb6.Clear();
    //        //}
    //        #endregion
    //    #region table7
    //    //    //k = 0;
    //    //    //foreach (Category lcategory in lcat)
    //    //    //{
    //    //    //    if (Convert.ToBoolean(lcategory[i].iHasFamBen))
    //    //    //    {
    //    //    //        k = 1;
    //    //    //    }
    //    //    //}
    //    //    //if (k == 1)
    //    //    //{


    //            StringBuilder sb7 = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'><tr class='catHeadlines'>");
    //            sb7.Append("<th>Funeral Insurance</th>");
    //            i = 1;
    //            foreach (Category lcategory in lcat)
    //            {

    //                // divLifeInsuranceandLSDAgeBandedBenefits.Visible = true;
    //                sb7.Append("<th>Category " + i + "</th>");

    //                i++;
    //            }
    //            sb7.Append("</tr>");



                
    //                sb7.Append("<tr>");
    //                sb7.Append("<td>Funeral Benefit</td>");
    //                foreach (Category lcategory in lcat)
    //                    sb7.Append("<td>" + lcategory[i].iFUNcoverAmt + "</td>");
    //                sb7.Append("</tr>");
                
               
    //                sb7.Append("<tr>");
    //                sb7.Append("<td>Transport Benefit</td>");
    //                foreach (Category lcategory in lcat)
    //                    sb7.Append("<td>" + lcategory[i].iHasFUNtransportBen + "</td>");
    //                sb7.Append("</tr>");


    //            sb7.Append("</table>");
    //            divSpousesLifeInsurance.InnerHtml = sb7.ToString();
    //            sb7.Clear();

    //    //}
    //    #endregion

        
    //}

    //private void PopulatePremiums(Quote lQuote, Category[] lcat, Company lComp)
    //{
    //    #region table1
    //    decimal cTotLifePrem, cLifeTotalPremMille, cLifeTotalPremRate;
    //    cTotLifePrem = 0.000000M; cLifeTotalPremMille = 0.000000M; cLifeTotalPremRate = 0.000000M;
    //    StringBuilder sb = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'>");
    //    sb.Append("<tr class='catHeadlines'><th>Benefit</th>");


    //    sb.Append("<th>Monthly premium</th>");
    //    sb.Append("<th>Average monthly contribution rate per R1000 cover</th>");
    //    sb.Append("<th>Premium as % of salaries</th>");


    //    sb.Append("</tr>");

    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td>Life Insurance </td>");

    //    sb.Append("<td>" + lComp.cTotGLAinsPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotGLAinsPrem;
    //    sb.Append("<td>" + lComp.cGLAinsPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cGLAinsPremMille;
    //    sb.Append("<td>" + lComp.cGLAinsPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cGLAinsPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Continuation of Life Cover during Disability </td>");

    //    sb.Append("<td>" + lComp.cTotGLAcocPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotGLAcocPrem;
    //    sb.Append("<td>" + lComp.cGLAcocPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cGLAcocPremMille;
    //    sb.Append("<td>" + lComp.cGLAcocPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cGLAcocPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Growth in Death Benefit while Disabled</td>");

    //    sb.Append("<td>" + lComp.cTotGLAgicPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotGLAgicPrem;
    //    sb.Append("<td>" + lComp.cGLAgicPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cGLAgicPremMille;
    //    sb.Append("<td>" + lComp.cGLAgicPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cGLAgicPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Conversion Option</td>");

    //    sb.Append("<td>" + lComp.cTotGLAoptionPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotGLAoptionPrem;
    //    sb.Append("<td>" + lComp.cGLAoptionPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cGLAoptionPremMille;
    //    sb.Append("<td>" + lComp.cGLAoptionPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cGLAoptionPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Accident Benefit</td>");

    //    sb.Append("<td>" + lComp.cTotAccBenGrossPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotAccBenGrossPrem;
    //    sb.Append("<td>" + lComp.cAccBenGrossPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cAccBenGrossPremMille;
    //    sb.Append("<td>" + lComp.cAccBenGrossPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cAccBenGrossPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Lump Sum Disability</td>");

    //    sb.Append("<td>" + lComp.cTotPTDinsPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotPTDinsPrem;
    //    sb.Append("<td>" + lComp.cPTDgrossPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cPTDgrossPremMille;
    //    sb.Append("<td>" + lComp.cPTDgrossPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cPTDgrossPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>LSD Conversion</td>");

    //    sb.Append("<td>" + lComp.cTotPTDoptionPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotPTDoptionPrem;
    //    sb.Append("<td>" + lComp.cPTDoptionPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cPTDoptionPremMille;
    //    sb.Append("<td>" + lComp.cPTDoptionPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cPTDoptionPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Universal Education Protector</td>");

    //    sb.Append("<td>" + lComp.cTotUEPgrossPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotUEPgrossPrem;
    //    sb.Append("<td>" + lComp.cUEPgrossPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cUEPgrossPremMille;
    //    sb.Append("<td>" + lComp.cUEPgrossPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cUEPgrossPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Terminal Illness Benefit</td>");

    //    sb.Append("<td>" + lComp.cTotGLAtibPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotGLAtibPrem;
    //    sb.Append("<td>" + lComp.cGLAtibPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cGLAtibPremMille;
    //    sb.Append("<td>" + lComp.cGLAtibPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cGLAtibPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Tax Replacement cover</td>");

    //    sb.Append("<td>" + lComp.cTotGLAtrcPrem + "</td>"); cTotLifePrem += (decimal)lComp.cTotGLAtrcPrem;
    //    sb.Append("<td>" + lComp.cGLAtrcPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cGLAtrcPremMille;
    //    sb.Append("<td>" + lComp.cGLAtrcPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cGLAtrcPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Commission</td>");

    //    sb.Append("<td>" + lComp.cCommAmtLife + "</td>"); cTotLifePrem += (decimal)lComp.cCommAmtLife;
    //    sb.Append("<td>" + lComp.cLifeCommPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cLifeCommPremMille;
    //    sb.Append("<td>" + lComp.cLifeCommPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cLifeCommPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Binder Fee   </td>");

    //    sb.Append("<td>" + lComp.cBinderAmtLife + "</td>"); cTotLifePrem += (decimal)lComp.cBinderAmtLife;
    //    sb.Append("<td>" + lComp.cLifeBindPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cLifeBindPremMille;
    //    sb.Append("<td>" + lComp.cLifeBindPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cLifeBindPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing F   </td>");

    //    sb.Append("<td>" + lComp.cOutsourceAmtLife + "</td>"); cTotLifePrem += (decimal)lComp.cOutsourceAmtLife;
    //    sb.Append("<td>" + lComp.cLifeOutsPremMille + "</td>"); cLifeTotalPremMille += (decimal)lComp.cLifeOutsPremMille;
    //    sb.Append("<td>" + lComp.cLifeOutsPremRate + "%</td>"); cLifeTotalPremRate += (decimal)lComp.cLifeOutsPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr  class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");

    //    sb.Append("<td><b>" + cTotLifePrem + "</b></td>");
    //    sb.Append("<td><b>" + cLifeTotalPremMille + "</b></td>");
    //    sb.Append("<td><b>" + cLifeTotalPremRate + "% </b></td>");

    //    sb.Append("</tr>");
    //    #region Trauma Insurance
    //    decimal CTotCIIprem = 0.000000M;
    //    decimal cCIItotalPremMille = 0.000000M;
    //    decimal cCIItotalPremRate = 0.000000M;
    //    sb.Append("<tr class='catHeadlines'><th>Trauma Insurance</th>");


    //    sb.Append("<th></th>");
    //    sb.Append("<th></th>");
    //    sb.Append("<th></th>");


    //    sb.Append("</tr>");

    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td>Trauma Insurance </td>");

    //    sb.Append("<td>" + lComp.cTotCIIinsPrem + "</td>"); CTotCIIprem += (decimal)lComp.cTotCIIinsPrem;
    //    sb.Append("<td>" + lComp.cCIIinsPremMille + "</td>"); cCIItotalPremMille += (decimal)lComp.cCIIinsPremMille;
    //    sb.Append("<td>" + lComp.cCIIinsPremRate + "%</td>"); cCIItotalPremRate += (decimal)lComp.cCIIinsPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Continuation of Trauma Cover during Disability</td>");

    //    sb.Append("<td>" + lComp.cTotCIIcocPrem + "</td>"); CTotCIIprem += (decimal)lComp.cTotCIIcocPrem;
    //    sb.Append("<td>" + lComp.cCIIcocPremMille + "</td>"); cCIItotalPremMille += (decimal)lComp.cCIIcocPremMille;
    //    sb.Append("<td>" + lComp.cCIIcocPremRate + "%</td>"); cCIItotalPremRate += (decimal)lComp.cCIIcocPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Growth in Death Benefit while Disabled</td>");

    //    sb.Append("<td>" + lComp.cTotCIIgicPrem + "</td>"); CTotCIIprem += (decimal)lComp.cTotCIIgicPrem;
    //    sb.Append("<td>" + lComp.cCIIgicPremMille + "</td>"); cCIItotalPremMille += (decimal)lComp.cCIIgicPremMille;
    //    sb.Append("<td>" + lComp.cCIIgicPremRate + "%</td>"); cCIItotalPremRate += (decimal)lComp.cCIIgicPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Conversion Option</td>");

    //    sb.Append("<td>" + lComp.cTotCIIoptionPrem + "</td>"); CTotCIIprem += (decimal)lComp.cTotCIIoptionPrem;
    //    sb.Append("<td>" + lComp.cCIIoptionPremMille + "</td>"); cCIItotalPremMille += (decimal)lComp.cCIIoptionPremMille;
    //    sb.Append("<td>" + lComp.cCIIoptionPremRate + "%</td>"); cCIItotalPremRate += (decimal)lComp.cCIIoptionPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Commission</td>");

    //    sb.Append("<td>" + lComp.cCommAmtCII + "</td>"); CTotCIIprem += (decimal)lComp.cCommAmtCII;
    //    sb.Append("<td>" + lComp.cCIIcommPremMille + "</td>"); cCIItotalPremMille += (decimal)lComp.cCIIcommPremMille;
    //    sb.Append("<td>" + lComp.cCIIcommPremRate + "%</td>"); cCIItotalPremRate += (decimal)lComp.cCIIcommPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Binder Fee   </td>");

    //    sb.Append("<td>" + lComp.cBinderAmtCII + "</td>"); CTotCIIprem += (decimal)lComp.cBinderAmtCII;
    //    sb.Append("<td>" + lComp.cCIIbindPremMille + "</td>"); cCIItotalPremMille += (decimal)lComp.cCIIbindPremMille;
    //    sb.Append("<td>" + lComp.cCIIbindPremRate + "%</td>"); cCIItotalPremRate += (decimal)lComp.cCIIbindPremRate;

    //    sb.Append("</tr>");
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing Fee </td>");

    //    sb.Append("<td>" + lComp.cOutsourceAmtCII + "</td>"); CTotCIIprem += (decimal)lComp.cOutsourceAmtCII;
    //    sb.Append("<td>" + lComp.cCIIoutsPremMille + "</td>"); cCIItotalPremMille += (decimal)lComp.cCIIoutsPremMille;
    //    sb.Append("<td>" + lComp.cCIIoutsPremRate + "%</td>"); cCIItotalPremRate += (decimal)lComp.cCIIoutsPremRate;

    //    sb.Append("</tr>");


    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b> </td>");

    //    sb.Append("<td><b>" + CTotCIIprem + "</b></td>");
    //    sb.Append("<td><b>" + cCIItotalPremMille + "</b></td>");
    //    sb.Append("<td><b>" + cCIItotalPremRate + "%</b></td>");

    //    sb.Append("</tr>");
    //    #endregion
    //    #region Group Income Insurance
    //    decimal CTotIncDisPrem = 0.000000M;
    //    decimal cIncDisTotalPremMille = 0.000000M;
    //    decimal cIncDisTotalPremRate = 0.000000M;
    //    sb.Append("<tr class='catHeadlines'><th>Group Income Insurance / Group IncomeCare (disability benefit)</th>");


    //    sb.Append("<th></th>");
    //    sb.Append("<th></th>");
    //    sb.Append("<th></th>");


    //    sb.Append("</tr>");

    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td>PHI Benefit</td>");

    //    sb.Append("<td>" + lComp.cTotPHIinsPrem + "</td>"); CTotIncDisPrem += (decimal)lComp.cTotPHIinsPrem;
    //    sb.Append("<td>" + lComp.cPHIinsPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cPHIinsPremMille;
    //    sb.Append("<td>" + lComp.cPHIinsPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cPHIinsPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Employer Waiver</td>");

    //    sb.Append("<td>" + lComp.cTotPHIinsPremWaiver + "</td>"); CTotIncDisPrem += (decimal)lComp.cTotPHIinsPremWaiver;
    //    sb.Append("<td>" + lComp.cPHIinsWaiverPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cPHIinsWaiverPremMille;
    //    sb.Append("<td>" + lComp.cPHIinsWaiverPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cPHIinsWaiverPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Conversion Option</td>");

    //    sb.Append("<td>" + lComp.cTotPHIoptionPrem + "</td>"); CTotIncDisPrem += (decimal)lComp.cTotPHIoptionPrem;
    //    sb.Append("<td>" + lComp.cPHIoptionPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cPHIoptionPremMille;
    //    sb.Append("<td>" + lComp.cPHIoptionPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cPHIoptionPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Medical Aid Premium Waiver</td>");

    //    sb.Append("<td>" + lComp.cTotMAPWgrossPrem + "</td>"); CTotIncDisPrem += (decimal)lComp.cTotMAPWgrossPrem;
    //    sb.Append("<td>" + lComp.cMAPWgrossPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cMAPWgrossPremMille;
    //    sb.Append("<td>" + lComp.cMAPWgrossPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cMAPWgrossPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Salary Refund</td>");

    //    sb.Append("<td>" + lComp.cTotSRgrossPrem + "</td>"); CTotIncDisPrem += (decimal)lComp.cTotSRgrossPrem;
    //    sb.Append("<td>" + lComp.cSRgrossPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cSRgrossPremMille;
    //    sb.Append("<td>" + lComp.cSRgrossPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cSRgrossPremRate;

    //    sb.Append("</tr>");


    //    sb.Append("<tr>");
    //    sb.Append("<td>Top-Up</td>");

    //    sb.Append("<td>" + lComp.cTotTopUpGrossPrem + "</td>"); CTotIncDisPrem += (decimal)lComp.cTotTopUpGrossPrem;
    //    sb.Append("<td>" + lComp.cTopUpGrossPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cTopUpGrossPremMille;
    //    sb.Append("<td>" + lComp.cTopUpGrossPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cTopUpGrossPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Top-Up Growth</td>");

    //    sb.Append("<td>" + lComp.cTotTopUpGrowthPrem + "</td>"); CTotIncDisPrem += (decimal)lComp.cTotSRgrossPrem;
    //    sb.Append("<td>" + lComp.cTopUpGrowthPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cTopUpGrowthPremMille;
    //    sb.Append("<td>" + lComp.cTopUpGrowthPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cTopUpGrowthPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Commission</td>");

    //    sb.Append("<td>" + lComp.cCommAmtIncDis + "</td>"); CTotIncDisPrem += (decimal)lComp.cCommAmtIncDis;
    //    sb.Append("<td>" + lComp.cIncDisCommPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cIncDisCommPremMille;
    //    sb.Append("<td>" + lComp.cIncDisCommPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cIncDisCommPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Binder Fee  </td>");

    //    sb.Append("<td>" + lComp.cBinderAmtIncDis + "</td>"); CTotIncDisPrem += (decimal)lComp.cBinderAmtIncDis;
    //    sb.Append("<td>" + lComp.cIncDisBindPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cIncDisBindPremMille;
    //    sb.Append("<td>" + lComp.cIncDisBindPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cIncDisBindPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing Fee</td>");

    //    sb.Append("<td>" + lComp.cOutsourceAmtIncDis + "</td>"); CTotIncDisPrem += (decimal)lComp.cOutsourceAmtIncDis;
    //    sb.Append("<td>" + lComp.cIncDisOutsPremMille + "</td>"); cIncDisTotalPremMille += (decimal)lComp.cIncDisOutsPremMille;
    //    sb.Append("<td>" + lComp.cIncDisOutsPremRate + "%</td>"); cIncDisTotalPremRate += (decimal)lComp.cIncDisOutsPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");

    //    sb.Append("<td><b>" + CTotIncDisPrem + "</b></td>");
    //    sb.Append("<td><b>" + cIncDisTotalPremMille + "</b></td>");
    //    sb.Append("<td><b>" + cIncDisTotalPremRate + "%</b></td>");

    //    sb.Append("</tr>");
    //    #endregion
    //    #region Spouse’s Insurance
    //    decimal CTotSpousesPrem = 0.000000M;
    //    decimal cSpousesTotalPremMille = 0.000000M;
    //    decimal cSpousesTotalPremRate = 0.000000M;

    //    sb.Append("<tr class='catHeadlines'><th>Spouse’s Insurance</th>");


    //    sb.Append("<th></th>");
    //    sb.Append("<th></th>");
    //    sb.Append("<th></th>");


    //    sb.Append("</tr>");

    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td>Spouses Life Cover</td>");

    //    sb.Append("<td>" + lComp.cTotSGLAgrossPrem + "</td>"); CTotSpousesPrem += (decimal)lComp.cTotSGLAgrossPrem;
    //    sb.Append("<td>" + lComp.cSGLAgrossPremMille + "</td>"); cSpousesTotalPremMille += (decimal)lComp.cSGLAgrossPremMille;
    //    sb.Append("<td>" + lComp.cSGLAgrossPremRate + "%</td>"); cSpousesTotalPremRate += (decimal)lComp.cSGLAgrossPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Conversion Option</td>");

    //    sb.Append("<td>" + lComp.cTotSGLAoptionPrem + "</td>"); CTotSpousesPrem += (decimal)lComp.cTotSGLAoptionPrem;
    //    sb.Append("<td>" + lComp.cSGLAoptionPremMille + "</td>"); cSpousesTotalPremMille += (decimal)lComp.cSGLAoptionPremMille;
    //    sb.Append("<td>" + lComp.cSGLAoptionPremRate + "%</td>"); cSpousesTotalPremRate += (decimal)lComp.cSGLAoptionPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Spouse’s Lump Sum Disability</td>");

    //    sb.Append("<td>" + lComp.cTotSPTDgrossPrem + "</td>"); CTotSpousesPrem += (decimal)lComp.cTotSPTDgrossPrem;
    //    sb.Append("<td>" + lComp.cSPTDgrossPremMille + "</td>"); cSpousesTotalPremMille += (decimal)lComp.cSPTDgrossPremMille;
    //    sb.Append("<td>" + lComp.cSPTDgrossPremRate + "%</td>"); cSpousesTotalPremRate += (decimal)lComp.cSPTDgrossPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Spouse’s LSD Conversion</td>");

    //    sb.Append("<td>" + lComp.cTotSPTDoptionPrem + "</td>"); CTotSpousesPrem += (decimal)lComp.cTotSPTDoptionPrem;
    //    sb.Append("<td>" + lComp.cSPTDoptionPremMille + "</td>"); cSpousesTotalPremMille += (decimal)lComp.cSPTDoptionPremMille;
    //    sb.Append("<td>" + lComp.cSPTDoptionPremRate + "%</td>"); cSpousesTotalPremRate += (decimal)lComp.cSPTDoptionPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Commission</td>");

    //    sb.Append("<td>" + lComp.cCommAmtSpouses + "</td>"); CTotSpousesPrem += (decimal)lComp.cCommAmtSpouses;
    //    sb.Append("<td>" + lComp.cSpousesCommPremMille + "</td>"); cSpousesTotalPremMille += (decimal)lComp.cSpousesCommPremMille;
    //    sb.Append("<td>" + lComp.cSpousesCommPremRate + "%</td>"); cSpousesTotalPremRate += (decimal)lComp.cSpousesCommPremRate;

    //    sb.Append("</tr>");


    //    sb.Append("<tr>");
    //    sb.Append("<td>Binder Fee  </td>");

    //    sb.Append("<td>" + lComp.cBinderAmtSpouses + "</td>"); CTotSpousesPrem += (decimal)lComp.cBinderAmtSpouses;
    //    sb.Append("<td>" + lComp.cSpousesBindPremMille + "</td>"); cSpousesTotalPremMille += (decimal)lComp.cSpousesBindPremMille;
    //    sb.Append("<td>" + lComp.cSpousesBindPremRate + "%</td>"); cSpousesTotalPremRate += (decimal)lComp.cSpousesBindPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing Fee   </td>");

    //    sb.Append("<td>" + lComp.cOutsourceAmtSpouses + "</td>"); CTotSpousesPrem += (decimal)lComp.cOutsourceAmtSpouses;
    //    sb.Append("<td>" + lComp.cSpousesOutsPremMille + "</td>"); cSpousesTotalPremMille += (decimal)lComp.cSpousesOutsPremMille;
    //    sb.Append("<td>" + lComp.cSpousesOutsPremRate + "%</td>"); cSpousesTotalPremRate += (decimal)lComp.cSpousesOutsPremRate;

    //    sb.Append("</tr>");


    //    sb.Append("<tr  class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");

    //    sb.Append("<td><b>" + CTotSpousesPrem + "</b></td>");
    //    sb.Append("<td><b>" + cSpousesTotalPremMille + "</b></td>");
    //    sb.Append("<td><b>" + cSpousesTotalPremRate + " % </b></td>");

    //    sb.Append("</tr>");
    //    #endregion
    //    #region Funeral Insurance

    //    decimal CTotFUNprem = 0.000000M;
    //    decimal cFUNtotalPremMille = 0.000000M;
    //    decimal cFUNtotalPremRate = 0.000000M;

    //    sb.Append("<tr class='catHeadlines'><th>Funeral Insurance</th>");


    //    sb.Append("<th></th>");
    //    sb.Append("<th></th>");
    //    sb.Append("<th></th>");


    //    sb.Append("</tr>");

    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td>Funeral Benefit</td>");

    //    sb.Append("<td>" + lComp.cTotFUNgrossPrem + "</td>"); CTotFUNprem += (decimal)lComp.cTotFUNgrossPrem;
    //    sb.Append("<td>" + lComp.cFUNgrossPremMille + "</td>"); cFUNtotalPremMille += (decimal)lComp.cFUNgrossPremMille;
    //    sb.Append("<td>" + lComp.cFUNgrossPremRate + "%</td>"); cFUNtotalPremRate += (decimal)lComp.cFUNgrossPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr >");
    //    sb.Append("<td>Commission</td>");

    //    sb.Append("<td>" + lComp.cCommAmtFUN + "</td>"); CTotFUNprem += (decimal)lComp.cCommAmtFUN;
    //    sb.Append("<td>" + lComp.cFUNcommPremMille + "</td>"); cFUNtotalPremMille += (decimal)lComp.cFUNcommPremMille;
    //    sb.Append("<td>" + lComp.cFUNcommPremRate + "%</td>"); cFUNtotalPremRate += (decimal)lComp.cFUNcommPremRate;

    //    sb.Append("</tr>");


    //    sb.Append("<tr >");
    //    sb.Append("<td>Binder Fee  </td>");

    //    sb.Append("<td>" + lComp.cBinderAmtFUN + "</td>"); CTotFUNprem += (decimal)lComp.cBinderAmtFUN;
    //    sb.Append("<td>" + lComp.cFUNbindPremMille + "</td>"); cFUNtotalPremMille += (decimal)lComp.cFUNbindPremMille;
    //    sb.Append("<td>" + lComp.cFUNbindPremRate + "%</td>"); cFUNtotalPremRate += (decimal)lComp.cFUNbindPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr >");
    //    sb.Append("<td>Outsourcing Fee   </td>");

    //    sb.Append("<td>" + lComp.cOutsourceAmtFUN + "</td>"); CTotFUNprem += (decimal)lComp.cOutsourceAmtFUN;
    //    sb.Append("<td>" + lComp.cFUNoutsPremMille + "</td>"); cFUNtotalPremMille += (decimal)lComp.cFUNoutsPremMille;
    //    sb.Append("<td>" + lComp.cFUNoutsPremRate + "%</td>"); cFUNtotalPremRate += (decimal)lComp.cFUNoutsPremRate;

    //    sb.Append("</tr>");

    //    sb.Append("<tr  class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");

    //    sb.Append("<td><b>" + CTotFUNprem + "</b></td>");
    //    sb.Append("<td><b>" + cFUNtotalPremMille + "</b></td>");
    //    sb.Append("<td><b>" + cFUNtotalPremRate + " % </b></td>");

    //    sb.Append("</tr>");
    //    #endregion
    //    sb.Append("</table>");
    //    tab2.InnerHtml = sb.ToString();
    //    sb.Clear();
    //    #endregion


    //}
    //private void PopulateCategoryRates(Quote lQuote, Category[] lcat, Company lComp)
    //{
    //    #region table1
    //    StringBuilder sb = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'>");
    //    sb.Append("<tr class='catHeadlines'><th>Benefit</th>");
    //    int i = 1;
    //    //int d = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if ((lcategory[i].iHasGLA == true) || (lcategory[i].iHasPTD == true))
    //    //    {
    //    //        d = 1;
    //    //    }
    //    //}
    //    //if (d == 1)
    //    //{
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<th>Category " + i + ": Premium as % of qualifying members’ salaries</th>");
    //        i++;

    //    }
    //    sb.Append("</tr>");
    //    //}


    //    //int j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (lcategory[i].iGLApattern == "Multiple")
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td>Life Insurance </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cGLAinsPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (lcategory[i].iGLApattern == "Flat")
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>Continuation of Life Cover during Disability </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cGLAcocPremRate + "%</td>");


    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (lcategory[i].iGLApattern == "AgeBanded")
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr>");
    //    sb.Append("<td>Growth in Death Benefit while Disabled </td>");
    //    foreach (Category lcategory in lcat)
    //    {

    //        sb.Append("<td>" + lcategory[i].cGLAgicPremRate + "%</td>");


    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (Convert.ToBoolean(lcategory[i].iGLAhasConverOption))
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>Conversion Option</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cGLAoptionPremRate + "%</td>");
    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (lcategory[i].iPTDpattern == "Multiple")
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>Accident Benefit </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cAccBenGrossPremRate + " %</td>");

    //    }

    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (lcategory[i].iPTDpattern == "Flat")
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>Lump Sum Disability </td>");
    //    foreach (Category lcategory in lcat)
    //    {

    //        sb.Append("<td>" + lcategory[i].cPTDgrossPremRate + " %</td>");

    //    }
    //    sb.Append("</tr>");
    //    //}

    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (lcategory[i].iPTDpattern == "Imported")
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>LSD Conversion </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cPTDoptionPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (Convert.ToBoolean(lcategory[i].iHasPTDinstalments))
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>Universal Education Protector </td>");
    //    foreach (Category lcategory in lcat)
    //    {

    //        sb.Append("<td>" + lcategory[i].cUEPgrossPremRate + " %</td>");

    //    }

    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (Convert.ToBoolean(lcategory[i].iHasPTDinstalments))
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>Terminal Illness Benefit</td>");
    //    foreach (Category lcategory in lcat)
    //    {


    //        sb.Append("<td>" + lcategory[i].cGLAtibPremRate + " %</td>");


    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (Convert.ToBoolean(lcategory[i].iHasPTDinstalments))
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr>");
    //    sb.Append("<td>Tax Replacement Cover</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cGLAtrcPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (Convert.ToBoolean(lcategory[i].iHasPTDaltPreEx))
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>Commission</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cLifeCommPremRate + "%</td>");
    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (Convert.ToBoolean(lcategory[i].iHasPTDaltOccDefn))
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr >");
    //    sb.Append("<td>Binder Fee </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cLifeBindPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (Convert.ToBoolean(lcategory[i].iHasPTDaltOccDefn))
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing F</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cLifeOutsPremRate + "</td>");
    //    }
    //    sb.Append("</tr>");
    //    //}
    //    //j = 0;
    //    //foreach (Category lcategory in lcat)
    //    //{
    //    //    if (Convert.ToBoolean(lcategory[i].iHasPTDaltOccDefn))
    //    //    {
    //    //        j = 1;
    //    //    }
    //    //}
    //    //if (j == 1)
    //    //{
    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cTotPremLifeRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    //}
    //    #region Trauma Insurance

    //    sb.Append("<tr class='catHeadlines' >");
    //    sb.Append("<th ><b>Trauma Insurance</b></th>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<th></th>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Trauma Insurance </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cCIIinsPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Continuation of Trauma Cover during Disability </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cCIIcocPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Growth in Trauma Benefit while Disabled </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cCIIgicPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Conversion Option </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cCIIoptionPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Commission </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cCIIcommPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Binder Fee </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cCIIbindPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing Fee</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cCIIoutsPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");


    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cTotPremCIIrate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    #endregion
    //    #region Group Income Insurance / Group IncomeCare (disability benefit)
    //    sb.Append("<tr class='catHeadlines' >");
    //    sb.Append("<th ><div style='height=10 px;overflow:auto;'><b> Group Income Insurance / Group IncomeCare (disability benefit)</b></div></th>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<th></th>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>PHI Benefit </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cPHIinsPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Employer Waiver </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cPHIinsWaiverPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Conversion Option </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cPHIoptionPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Medical Aid Premium Waiver</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cMAPWgrossPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Salary Refund</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cSRgrossPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Top-Up</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cTopUpGrossPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Top-Up Growth</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cTopUpGrowthPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Commission</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cIncDisCommPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Binder Fee   </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cIncDisBindPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing Fee   </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cIncDisOutsPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cTotPremIncDisRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    #endregion
    //    #region Spouses Insurance
    //    sb.Append("<tr class='catHeadlines' >");
    //    sb.Append("<th ><b>Spouses Insurance</b></th>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<th></th>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Spouses Life Cover</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cSGLAgrossPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Conversion Option</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cSGLAoptionPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Spouse’s Lump Sum Disability</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cSPTDgrossPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Spouse’s LSD Conversion</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cSPTDoptionPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Commission</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cSpousesCommPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Binder Fee </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cSpousesBindPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing Fee</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cSpousesOutsPremRate + " %</td>");
    //    }
    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cTotPremSpousesRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    #endregion
    //    #region Funeral Insurance
    //    sb.Append("<tr class='catHeadlines' >");
    //    sb.Append("<th ><b> Funeral Insurance </b></th>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<th></th>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Funeral Benefit</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cFUNgrossPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Commission</td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cFUNcommPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Binder Fee   </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cFUNbindPremRate + " %</td>");
    //    }
    //    sb.Append("</tr>");
    //    sb.Append("<tr>");
    //    sb.Append("<td>Outsourcing Fee </td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cFUNoutsPremRate + " %</td>");
    //    }

    //    sb.Append("<tr class='catSubHead'>");
    //    sb.Append("<td><b>TOTAL</b></td>");
    //    foreach (Category lcategory in lcat)
    //    {
    //        sb.Append("<td>" + lcategory[i].cTotPremSpousesRate + " %</td>");
    //    }
    //    sb.Append("</tr>");

    //    #endregion
    //    sb.Append("</table>");
    //    tab3.InnerHtml = sb.ToString();
    //    sb.Clear();
    //    #endregion
    //}
    //private void PopulateFreeCoverLimits(MPFL lMPFL)
    //{
    //    #region table1
    //    StringBuilder sb = new StringBuilder("<table cellspacing='0' cellpadding='0' class='outputValues'>");
    //    sb.Append("<tr class='catSubHead'><td  colspan='2'>Life Insurance </td>");


    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Death benefit (member):</td>");

    //    sb.Append("<td>" + lMPFL.cMPFLvalueGLA + " </td>");

    //    sb.Append("</tr>");

    //    sb.Append("<tr  class='catSubHead' >");
    //    sb.Append("<td colspan='2'>Trauma Insurance</td>");




    //    sb.Append("</tr>");

    //    sb.Append("<tr>");
    //    sb.Append("<td>Trauma benefit: </td>");

    //    sb.Append("<td>" + lMPFL.cMPFLvalueCII + "</td>");



    //    sb.Append("</tr>");

    //    sb.Append("<tr  class='catSubHead'>");
    //    sb.Append("<td colspan='2'>Group Income Benefit (disability benefit)</td>");
    //    sb.Append("</tr>");

    //    sb.Append("<tr >");
    //    sb.Append("<td>Disability income benefit / IncomeCare:</td>");

    //    sb.Append("<td>" + lMPFL.cMPFLvaluePHI + " </td>");


    //    sb.Append("</tr>");

    //    sb.Append("<tr  class='catSubHead'>");
    //    sb.Append("<td colspan='2'>Spouses Insurance</td>");



    //    sb.Append("<tr >");
    //    sb.Append("<td>Spouse of a member: </td>");

    //    sb.Append("<td>" + lMPFL.cMPFLvalueSGLA + " </td>");

    //    sb.Append("</tr>");

    //    sb.Append("</table>");
    //    tab6.InnerHtml = sb.ToString();
    //    sb.Clear();
    //    #endregion
    //}


    public string CreateXML(Object ClassObject)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ClassObject.GetType());
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = new XmlTextWriter(sw);
            xmlSerializer.Serialize(tw, ClassObject);
            return sw.ToString();
        }
        catch (Exception ex)
        {
            //Handle Exception Code 
            return ex.ToString();
        }


    }

    protected void viewQuoteEdit_Click(object sender, EventArgs e)
    {

    }
    private DataTable GenerateTransposedTable(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows


        //outputTable.Columns.Add("iQuoteNumber", typeof(Int32));
        outputTable.Columns.Add("BenefitName", typeof(string));

        // Header row's first column is same as in inputTable
        //outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        int i = 1;
        foreach (DataRow inRow in inputTable.Rows)
        {
            // string newColName = inRow[0].ToString();
            outputTable.Columns.Add("Category" + i.ToString(), typeof(string));
            i++;

        }

        // Add rows by looping columns        
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }

        return outputTable;
    }

    private DataTable GenerateTransposedTableForAgeBanded(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows


        //outputTable.Columns.Add("iQuoteNumber", typeof(Int32));
        outputTable.Columns.Add("BenefitName", typeof(string));

        // Header row's first column is same as in inputTable
        //outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        int i = 1;
        foreach (DataRow inRow in inputTable.Rows)
        {
            // string newColName = inRow[0].ToString();
            outputTable.Columns.Add("Category" + i.ToString(), typeof(string));
            i++;

        }

        // Add rows by looping columns        
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }

        return outputTable;
    }

    private DataTable GenerateTransposedTableforTrauma(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();

        // Add columns by looping rows


        //outputTable.Columns.Add("iQuoteNumber", typeof(Int32));
        outputTable.Columns.Add("BenefitName", typeof(string));

        // Header row's first column is same as in inputTable
        //outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        // Header row's second column onwards, 'inputTable's first column taken
        int i = 1;
        foreach (DataRow inRow in inputTable.Rows)
        {
            // string newColName = inRow[0].ToString();
            outputTable.Columns.Add("Category" + i.ToString(), typeof(string));
            i++;

        }

        // Add rows by looping columns        
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();

            // First column is inputTable's Header row's second column
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }

        return outputTable;
    }

}
