using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;



public partial class RFriskv100CS : System.Web.UI.Page
{
    SqlConnection connection;
    FrontOffice lFrontOffice = new FrontOffice();
    MPFL lMPFL = new MPFL();
    ParametersCommission lParametersCommission = new ParametersCommission();
    ParametersExpenses lParametersExpenses = new ParametersExpenses();
    ParametersOther lParametersOther = new ParametersOther();
    deSalaryParms ldeSalaryParms = new deSalaryParms();
    deSchemeParms ldeSchemeParms = new deSchemeParms();
    deIndustryFactors ldeIndustryFactors = new deIndustryFactors();
    deCommissionParms ldeCommissionParms = new deCommissionParms();
    deExpenseParms ldeExpenseParms = new deExpenseParms();
    deFrontOfficeFactors ldeFrontOfficeFactors = new deFrontOfficeFactors();
    dePHIwpFactors ldePHIwpFactors = new dePHIwpFactors();
    deConversionRates ldeConversionRates = new deConversionRates();

    protected void Page_Load(object sender, EventArgs e)
    {
        connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        NewBusQuoteDecisionService lRFriskv100 = new NewBusQuoteDecisionService();
        lRFriskv100.Url = ConfigurationManager.AppSettings.Get("CORTICON_ASPNET_URL");

        Quote lquote = new Quote();
        Company lcomp = new Company();
        DataSet ds1 = new DataSet();
        string iQuoteNumber = string.Empty;
        if (Request.QueryString["iQuoteNumber"] != null)
            iQuoteNumber = Request.QueryString["iQuoteNumber"].ToString();
        using (SqlCommand cmd = new SqlCommand("select * from [dbo].[Quote_Input] where [iQuoteNumber] =" + iQuoteNumber))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {

                sda.Fill(ds1);
            }
        }
        //
        DataTable dtQoute = new DataTable();
        dtQoute = ds1.Tables[0];
        if (dtQoute != null)
            if (dtQoute.Rows.Count > 0)
            {
                DataRow drQuote = dtQoute.Rows[0];
                lcomp.iIndustry = (drQuote["iIndustry"].ToString() != DBNull.Value.ToString()) ? drQuote["iIndustry"].ToString().Trim() : string.Empty;// "Construction";
                lcomp.iProvince = (drQuote["iProvince"].ToString() != DBNull.Value.ToString()) ? drQuote["iProvince"].ToString().Trim() : string.Empty; //"Limpopo";
                lcomp.iProvinceSpecified = true;
                lcomp.iHMSinvolved = (drQuote["iHMSinvolved"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(drQuote["iHMSinvolved"].ToString() == "False" ? "false" : drQuote["iHMSinvolved"].ToString() == "True" ? "true" : "false") : false; //false;
                lcomp.iHMSinvolvedSpecified = true;



                lcomp.category = getCategory(iQuoteNumber);



                lquote.iBinderFeePerc = (drQuote["iBinderFeePerc"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(drQuote["iBinderFeePerc"].ToString().Trim()) : 0.000000M; //7;
                lquote.iBinderFeePercSpecified = true;
                lquote.iCommDiscount = (drQuote["iCommDiscount"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(drQuote["iCommDiscount"].ToString().Trim()) : 0.000000M;// 0.000000M;
                lquote.iCommDiscountSpecified = true;
                lquote.iDate = (drQuote["iDate"].ToString() != DBNull.Value.ToString()) ? Convert.ToDateTime(drQuote["iDate"].ToString().Trim()) : DateTime.Now;
                lquote.iDateSpecified = true;
                lquote.iPTDtaperingYears = (drQuote["iPTDtaperingYears"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(drQuote["iPTDtaperingYears"].ToString().Trim()) : 0;// 5;
                lquote.iPTDtaperingYearsSpecified = true;
                lquote.iHasNBComm = (drQuote["iHasNBComm"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(drQuote["iHasNBComm"].ToString().Trim()) : false;// true;
                lquote.iHasNBCommSpecified = true;
                lquote.iHasVatOnComm = (drQuote["iHasVatOnComm"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(drQuote["iHasVatOnComm"].ToString().Trim()) : false;// true;
                lquote.iHasVatOnCommSpecified = true;


                lquote.iIsSUFquote = (drQuote["iIsSUFquote"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(drQuote["iIsSUFquote"].ToString().Trim()) : false;// true;
                lquote.iIsSUFquoteSpecified = true;
                lquote.iOutsourceFeePerc = (drQuote["iOutsourceFeePerc"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(drQuote["iOutsourceFeePerc"].ToString().Trim()) : 0.000000M; //2.000000M;
                lquote.iOutsourceFeePercSpecified = true;

                lquote.oMaxAgeCII = (drQuote["oMaxAgeCII"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt32(drQuote["oMaxAgeCII"].ToString().Trim()) : 0;
                lquote.oMaxAgeFUN = (drQuote["oMaxAgeFUN"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt32(drQuote["oMaxAgeFUN"].ToString().Trim()) : 0;
                lquote.oMaxAgeGLA = (drQuote["oMaxAgeGLA"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt32(drQuote["oMaxAgeGLA"].ToString().Trim()) : 0;
                lquote.oMaxAgePHITTD = (drQuote["oMaxAgePHITTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt32(drQuote["oMaxAgePHITTD"].ToString().Trim()) : 0;
                lquote.oMaxAgePTD = (drQuote["oMaxAgePTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt32(drQuote["oMaxAgePTD"].ToString().Trim()) : 0;
                lquote.oMaxAgeSGLA = (drQuote["oMaxAgeSGLA"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt32(drQuote["oMaxAgeSGLA"].ToString().Trim()) : 0;
                lquote.oMaxAgeSPTD = (drQuote["oMaxAgeSPTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt32(drQuote["oMaxAgeSPTD"].ToString().Trim()) : 0;
                lquote.oMaxAgeCIISpecified = true;
                lquote.oMaxAgeFUNSpecified = true;
                lquote.oMaxAgeGLASpecified = true;
                lquote.oMaxAgePHITTDSpecified = true;
                lquote.oMaxAgePTDSpecified = true;
                lquote.oMaxAgeSGLASpecified = true;
                lquote.oMaxAgeSPTDSpecified = true;



                ldeSchemeParms.daKey = (drQuote["deSchemeParmsKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(drQuote["deSchemeParmsKey"].ToString().Trim()) : 0;// 1;
                ldeSchemeParms.daKeySpecified = true;
                ldeCommissionParms.daKey = (drQuote["deCommissionParmsKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(drQuote["deCommissionParmsKey"].ToString().Trim()) : 0;// 1;
                ldeCommissionParms.daKeySpecified = true;
                ldeExpenseParms.daKey = (drQuote["deExpenseParmsKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(drQuote["deExpenseParmsKey"].ToString().Trim()) : 0;// 1;
                ldeExpenseParms.daKeySpecified = true;
                ldeFrontOfficeFactors.daName = (drQuote["deFrontOfficeFactorsKey"].ToString() != DBNull.Value.ToString()) ? drQuote["deFrontOfficeFactorsKey"].ToString().Trim() : string.Empty;//"1AlexForbes";
                ldeSalaryParms.daKey = (drQuote["deSalaryParmsKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(drQuote["deSalaryParmsKey"].ToString().Trim()) : 0; //1;
                ldeSalaryParms.daKeySpecified = true;
                lFrontOffice.iFOname = (drQuote["deSalaryParmsKey"].ToString() != DBNull.Value.ToString()) ? drQuote["iFOname"].ToString().Trim() : string.Empty;// "AlexForbes";
                ldeIndustryFactors.daIndustry = (drQuote["deIndustryFactorsKey"].ToString() != DBNull.Value.ToString()) ? drQuote["deIndustryFactorsKey"].ToString().Trim() : string.Empty; //"1Construction";
            }
        WorkDocuments lworkdocuments = new WorkDocuments();
        lworkdocuments.Items = new object[] {                    
                lcomp,
                ldeCommissionParms,
                ldeExpenseParms,
                ldeFrontOfficeFactors,
                ldeIndustryFactors,
                ldeSalaryParms,
                ldeSchemeParms,
                lFrontOffice,               
                lParametersCommission,
                lParametersExpenses,
                lParametersOther,
                lquote,
                lMPFL           
            };
        StringBuilder sb = new StringBuilder("");
        sb.Append(CreateXML(lworkdocuments));
        string QuoteInput = sb.ToString();
        string lstrServiceName = "RFriskv101";
        string lstrServiceVersion = null;
        DateTime lDateTimeServiceDate = DateTime.Now;
        bool lbServiceDateSpecified = true;
        string lstrUsage = null;
        Messages lMessagesType;



        Response.Write("Calling service " + lstrServiceName + " using ASP.NET (ASMX) interface...");
        try
        {
            lMessagesType = lRFriskv100.processRequest(
                ref lworkdocuments,
                ref lstrServiceName,
                ref lstrServiceVersion,
                ref lDateTimeServiceDate,
                ref lbServiceDateSpecified

                );

            var llistReturnMessages = new List<string>();
            StringBuilder sb1 = new StringBuilder("");
            sb1.Append(CreateXML(lworkdocuments));
            string QuoteOutput = sb1.ToString();

            SaveQuote(lworkdocuments, iQuoteNumber);

            //Company CompanyType = new Company();
            //CompanyType = (Company)lworkdocuments.Items[0];
            //XmlSerializer serializer = new XmlSerializer(lcomp.GetType());

            //using (TextWriter writer = new StreamWriter(@"C:\Users\james_000\Downloads\XmlCompany.xml"))
            //{
            //    serializer.Serialize(writer, lcomp);

            //}
            //deCommissionParms objDeCommissionParms = new deCommissionParms();
            //objDeCommissionParms = (deCommissionParms)lworkdocuments.Items[1];
            //XmlSerializer serializer1 = new XmlSerializer(objDeCommissionParms.GetType());
            //using (TextWriter writer = new StreamWriter(@"C:\Users\james_000\Downloads\XmldeCommissionParms.xml"))
            //{
            //    serializer1.Serialize(writer, objDeCommissionParms);

            //}

            XmlSerializer serializer = new XmlSerializer(lworkdocuments.GetType());

            //using (TextWriter writer = new StreamWriter(@"C:\Users\james_000\Downloads\Xmlworkdocuments.xml"))
            //{
            //    serializer.Serialize(writer, lworkdocuments);

            //}
            if(lMessagesType.Message!=null)
            Array.ForEach(lMessagesType.Message,
                message => llistReturnMessages.Add(String.Format("{0} for {1}", message.text, message.entityReference.href)));

            Response.Write("--Messages Returned From Service--");

            if(llistReturnMessages.Count > 0)
            foreach (var item in llistReturnMessages)
                Response.Write(item);

            Response.Redirect("ViewQuote.aspx?iQuoteNumber=" + iQuoteNumber);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            return;

        }
        finally
        {
            connection.Close();
        }

    }

    private void SaveQuote(WorkDocuments lWorkDocuments, string iQuoteNumber)
    {
        Company lCompany = new Company();
        Quote lQuote = new Quote();
        MPFL lMPFL = new MPFL();
        foreach (object obj in lWorkDocuments.Items)
        {
            if (obj is Company)
            {
                lCompany = (Company)obj;
            }
            if (obj is Quote)
            {
                lQuote = (Quote)obj;
            }
            if (obj is MPFL)
            {
                lMPFL = (MPFL)obj;
            }
        }
        try
        {
            connection.Close();
            SqlCommand cmd1 = new SqlCommand("Select Quoteoutput_ID from dbo.Quote_Output where Quoteoutput_ID =" + iQuoteNumber, connection);
            connection.Open();
            cmd1.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd1.ExecuteReader();
            string i_quoteNumber = string.Empty;
            while (rdr.Read())
            {
                i_quoteNumber = rdr["Quoteoutput_ID"].ToString();
            }
            connection.Close();
            if ((i_quoteNumber != string.Empty) && (i_quoteNumber.Equals(iQuoteNumber)))
            {
                SqlCommand cmd2 = new SqlCommand("Delete from dbo.Quote_Output where Quoteoutput_ID=" + iQuoteNumber, connection);
                connection.Open();
                cmd2.CommandType = CommandType.Text;
                int FlagQuote = cmd2.ExecuteNonQuery();
                connection.Close();
                if (FlagQuote > 0)
                {
                    SqlCommand cmd3 = new SqlCommand("Delete from dbo.Category_Output where iQuoteNumber=" + iQuoteNumber, connection);
                    connection.Open();
                    cmd3.CommandType = CommandType.Text;
                    int FlagCat = cmd3.ExecuteNonQuery();
                    connection.Close();
                    if (FlagCat > 0)
                    {
                        SqlCommand cmd4 = new SqlCommand("Delete from dbo.Member_Output where iQuoteNumber=" + iQuoteNumber, connection);
                        connection.Open();
                        cmd4.CommandType = CommandType.Text;
                        cmd4.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }

            SqlCommand cmd = new SqlCommand("[dbo].[quoteOutputSave_Procedure]", connection);
            connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Quoteoutput_ID", SqlDbType.Int).Value = Convert.ToInt32(iQuoteNumber);

            if (lCompany.cAccBenGrossPremMille != null) { cmd.Parameters.Add("@cAccBenGrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cAccBenGrossPremMille); }
            if (lCompany.cAccBenGrossPremRate != null) { cmd.Parameters.Add("@cAccBenGrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cAccBenGrossPremRate); }
            if (lCompany.cAvgAge != null) { cmd.Parameters.Add("@cAvgAge", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cAvgAge); }
            if (lCompany.cAvgAgeSpouses != null) { cmd.Parameters.Add("@cAvgAgeSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cAvgAgeSpouses); }
            if (lCompany.cBinderAmtFUN != null) { cmd.Parameters.Add("@cBinderAmtFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cBinderAmtFUN); }
            if (lCompany.cBinderAmtIncDis != null) { cmd.Parameters.Add("@cBinderAmtIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cBinderAmtIncDis); }
            if (lCompany.cBinderAmtLife != null) { cmd.Parameters.Add("@cBinderAmtLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cBinderAmtLife); }
            if (lCompany.cBinderAmtSpouses != null) { cmd.Parameters.Add("@cBinderAmtSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cBinderAmtSpouses); }
            if (lCompany.cBinderAmtTotal != null) { cmd.Parameters.Add("@cBinderAmtTotal", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cBinderAmtTotal); }
            if (lCompany.cBinderAmtCII != null) { cmd.Parameters.Add("@cBinderAmtCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cBinderAmtCII); }
            if (lCompany.cCommAmtFUN != null) { cmd.Parameters.Add("@cCommAmtFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommAmtFUN); }
            if (lCompany.cCommAmtIncDis != null) { cmd.Parameters.Add("@cCommAmtIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommAmtIncDis); }
            if (lCompany.cCommAmtLife != null) { cmd.Parameters.Add("@cCommAmtLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommAmtLife); }
            if (lCompany.cCommAmtSpouses != null) { cmd.Parameters.Add("@cCommAmtSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommAmtSpouses); }
            if (lCompany.cCommAmtTotal != null) { cmd.Parameters.Add("@cCommAmtTotal", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommAmtTotal); }
            if (lCompany.cCommAmtCII != null) { cmd.Parameters.Add("@cCommAmtCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommAmtCII); }
            if (lCompany.cCommPercFUN != null) { cmd.Parameters.Add("@cCommPercFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommPercFUN); }
            if (lCompany.cCommPercIncDis != null) { cmd.Parameters.Add("@cCommPercIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommPercIncDis); }
            if (lCompany.cCommPercLife != null) { cmd.Parameters.Add("@cCommPercLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommPercLife); }
            if (lCompany.cCommPercSpouses != null) { cmd.Parameters.Add("@cCommPercSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommPercSpouses); }
            if (lCompany.cCommPercCII != null) { cmd.Parameters.Add("@cCommPercCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommPercCII); }
            //if (lCompany.cFUNgrossPremMille != null) { cmd.Parameters.Add("@cFUNgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNgrossPremMille); }
            //if (lCompany.cFUNgrossPremRate != null) { cmd.Parameters.Add("@cFUNgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNgrossPremRate); }
            if (lCompany.cGLAgicPremMille != null) { cmd.Parameters.Add("@cGLAgicPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAgicPremMille); }
            if (lCompany.cGLAgicPremRate != null) { cmd.Parameters.Add("@cGLAgicPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAgicPremRate); }
            if (lCompany.cGLAcocPremMille != null) { cmd.Parameters.Add("@cGLAcocPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAcocPremMille); }
            if (lCompany.cGLAcocPremRate != null) { cmd.Parameters.Add("@cGLAcocPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAcocPremRate); }
            //if (lCompany.cGLAgrossPremMille != null) { cmd.Parameters.Add("@cGLAgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAgrossPremMille); }
            //if (lCompany.cGLAgrossPremRate != null) { cmd.Parameters.Add("@cGLAgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAgrossPremRate); }
            if (lCompany.cGLAinsPremMille != null) { cmd.Parameters.Add("@cGLAinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAinsPremMille); }
            if (lCompany.cGLAinsPremRate != null) { cmd.Parameters.Add("@cGLAinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAinsPremRate); }
            if (lCompany.cGLAoptionPremMille != null) { cmd.Parameters.Add("@cGLAoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAoptionPremMille); }
            if (lCompany.cGLAoptionPremRate != null) { cmd.Parameters.Add("@cGLAoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAoptionPremRate); }
            if (lCompany.cGLAtibPremMille != null) { cmd.Parameters.Add("@cGLAtibPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAtibPremMille); }
            if (lCompany.cGLAtibPremRate != null) { cmd.Parameters.Add("@cGLAtibPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAtibPremRate); }
            //if (lCompany.cPTDgrossPremMille != null) { cmd.Parameters.Add("@cPTDgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDgrossPremMille); }
            //if (lCompany.cPTDgrossPremRate != null) { cmd.Parameters.Add("@cPTDgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDgrossPremRate); }
            if (lCompany.cPTDoptionPremMille != null) { cmd.Parameters.Add("@cPTDoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDoptionPremMille); }
            if (lCompany.cPTDoptionPremRate != null) { cmd.Parameters.Add("@cPTDoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDoptionPremRate); }
            if (lCompany.cMAPWgrossPremMille != null) { cmd.Parameters.Add("@cMAPWgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMAPWgrossPremMille); }
            if (lCompany.cMAPWgrossPremRate != null) { cmd.Parameters.Add("@cMAPWgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMAPWgrossPremRate); }
            if (lCompany.cOutsourceAmtFUN != null) { cmd.Parameters.Add("@cOutsourceAmtFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cOutsourceAmtFUN); }
            if (lCompany.cOutsourceAmtIncDis != null) { cmd.Parameters.Add("@cOutsourceAmtIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cOutsourceAmtIncDis); }
            if (lCompany.cOutsourceAmtLife != null) { cmd.Parameters.Add("@cOutsourceAmtLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cOutsourceAmtLife); }
            if (lCompany.cOutsourceAmtSpouses != null) { cmd.Parameters.Add("@cOutsourceAmtSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cOutsourceAmtSpouses); }
            if (lCompany.cOutsourceAmtTotal != null) { cmd.Parameters.Add("@cOutsourceAmtTotal", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cOutsourceAmtTotal); }
            if (lCompany.cOutsourceAmtCII != null) { cmd.Parameters.Add("@cOutsourceAmtCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cOutsourceAmtCII); }
            //if (lCompany.cPHIgrossPremMille != null) { cmd.Parameters.Add("@cPHIgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIgrossPremMille); }
            //if (lCompany.cPHIgrossPremRate != null) { cmd.Parameters.Add("@cPHIgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIgrossPremRate); }
            if (lCompany.cPHIgrowthPremMille != null) { cmd.Parameters.Add("@cPHIgrowthPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIgrowthPremMille); }
            if (lCompany.cPHIgrowthPremRate != null) { cmd.Parameters.Add("@cPHIgrowthPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIgrowthPremRate); }
            if (lCompany.cPHIinsPremMille != null) { cmd.Parameters.Add("@cPHIinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIinsPremMille); }
            if (lCompany.cPHIinsPremRate != null) { cmd.Parameters.Add("@cPHIinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIinsPremRate); }
            if (lCompany.cPHIinsWaiverPremMille != null) { cmd.Parameters.Add("@cPHIinsWaiverPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIinsWaiverPremMille); }
            if (lCompany.cPHIinsWaiverPremRate != null) { cmd.Parameters.Add("@cPHIinsWaiverPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIinsWaiverPremRate); }
            if (lCompany.cPHIoptionPremMille != null) { cmd.Parameters.Add("@cPHIoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIoptionPremMille); }
            if (lCompany.cPHIoptionPremRate != null) { cmd.Parameters.Add("@cPHIoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIoptionPremRate); }
            //if (lCompany.cSGLAgrossPremMille != null) { cmd.Parameters.Add("@cSGLAgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAgrossPremMille); }
            //if (lCompany.cSGLAgrossPremRate != null) { cmd.Parameters.Add("@cSGLAgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAgrossPremRate); }
            if (lCompany.cSGLAoptionPremMille != null) { cmd.Parameters.Add("@cSGLAoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAoptionPremMille); }
            if (lCompany.cSGLAoptionPremRate != null) { cmd.Parameters.Add("@cSGLAoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAoptionPremRate); }
            //if (lCompany.cSPTDgrossPremMille != null) { cmd.Parameters.Add("@cSPTDgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDgrossPremMille); }
            //if (lCompany.cSPTDgrossPremRate != null) { cmd.Parameters.Add("@cSPTDgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDgrossPremRate); }
            if (lCompany.cSPTDoptionPremMille != null) { cmd.Parameters.Add("@cSPTDoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDoptionPremMille); }
            if (lCompany.cSPTDoptionPremRate != null) { cmd.Parameters.Add("@cSPTDoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDoptionPremRate); }
            //if (lCompany.cSCIIgicPremMille != null) { cmd.Parameters.Add("@cSCIIgicPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIgicPremMille); }
            //if (lCompany.cSCIIgicPremRate != null) { cmd.Parameters.Add("@cSCIIgicPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIgicPremRate); }
            //if (lCompany.cSCIIcocPremMille != null) { cmd.Parameters.Add("@cSCIIcocPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIcocPremMille); }
            //if (lCompany.cSCIIcocPremRate != null) { cmd.Parameters.Add("@cSCIIcocPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIcocPremRate); }
            //if (lCompany.cSCIIgrossPremMille != null) { cmd.Parameters.Add("@cSCIIgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIgrossPremMille); }
            //if (lCompany.cSCIIgrossPremRate != null) { cmd.Parameters.Add("@cSCIIgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIgrossPremRate); }
            //if (lCompany.cSCIIinsPremMille != null) { cmd.Parameters.Add("@cSCIIinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIinsPremMille); }
            //if (lCompany.cSCIIinsPremRate != null) { cmd.Parameters.Add("@cSCIIinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIinsPremRate); }
            //if (lCompany.cSCIIoptionPremMille != null) { cmd.Parameters.Add("@cSCIIoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIoptionPremMille); }
            //if (lCompany.cSCIIoptionPremRate != null) { cmd.Parameters.Add("@cSCIIoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSCIIoptionPremRate); }
            if (lCompany.cSRgrossPremMille != null) { cmd.Parameters.Add("@cSRgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSRgrossPremMille); }
            if (lCompany.cSRgrossPremRate != null) { cmd.Parameters.Add("@cSRgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSRgrossPremRate); }
            if (lCompany.cTopUpGrossPremMille != null) { cmd.Parameters.Add("@cTopUpGrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpGrossPremMille); }
            if (lCompany.cTopUpGrossPremRate != null) { cmd.Parameters.Add("@cTopUpGrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpGrossPremRate); }
            if (lCompany.cTopUpGrowthPremMille != null) { cmd.Parameters.Add("@cTopUpGrowthPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpGrowthPremMille); }
            if (lCompany.cTopUpGrowthPremRate != null) { cmd.Parameters.Add("@cTopUpGrowthPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpGrowthPremRate); }
            if (lCompany.cTotAccBenGrossPrem != null) { cmd.Parameters.Add("@cTotAccBenGrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAccBenGrossPrem); }
            if (lCompany.cTotAnnualSalary != null) { cmd.Parameters.Add("@cTotAnnualSalary", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnualSalary); }
            if (lCompany.cTotCountPHI != null) { cmd.Parameters.Add("@cTotCountPHI", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCountPHI); }
            if (lCompany.cTotCountCII != null) { cmd.Parameters.Add("@cTotCountCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCountCII); }
            if (lCompany.cTotCoverFUN != null) { cmd.Parameters.Add("@cTotCoverFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverFUN); }
            if (lCompany.cTotCoverGLA != null) { cmd.Parameters.Add("@cTotCoverGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverGLA); }
            if (lCompany.cTotCoverPTD != null) { cmd.Parameters.Add("@cTotCoverPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverPTD); }
            if (lCompany.cTotCoverPHI != null) { cmd.Parameters.Add("@cTotCoverPHI", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverPHI); }
            if (lCompany.cTotCoverPHIincWaiver != null) { cmd.Parameters.Add("@cTotCoverPHIincWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverPHIincWaiver); }
            if (lCompany.cTotCoverPHIwaiver != null) { cmd.Parameters.Add("@cTotCoverPHIwaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverPHIwaiver); }
            if (lCompany.cTotCoverSGLA != null) { cmd.Parameters.Add("@cTotCoverSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverSGLA); }
            if (lCompany.cTotCoverSPTD != null) { cmd.Parameters.Add("@cTotCoverSPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverSPTD); }
            //if (lCompany.cTotCoverSCII != null) { cmd.Parameters.Add("@cTotCoverSCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverSCII); }
            if (lCompany.cTotCoverCII != null) { cmd.Parameters.Add("@cTotCoverCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverCII); }
            if (lCompany.cTotFUNgrossPrem != null) { cmd.Parameters.Add("@cTotFUNgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNgrossPrem); }
            if (lCompany.cTotFUNpremExCommBind != null) { cmd.Parameters.Add("@cTotFUNpremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNpremExCommBind); }
            if (lCompany.cTotFUNpremIncBindProv != null) { cmd.Parameters.Add("@cTotFUNpremIncBindProv", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNpremIncBindProv); }
            if (lCompany.cTotFUNpremIncCommBind != null) { cmd.Parameters.Add("@cTotFUNpremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNpremIncCommBind); }
            if (lCompany.cTotFUNpremPA != null) { cmd.Parameters.Add("@cTotFUNpremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNpremPA); }
            if (lCompany.cTotGLAgicPrem != null) { cmd.Parameters.Add("@cTotGLAgicPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAgicPrem); }
            if (lCompany.cTotGLAcocPrem != null) { cmd.Parameters.Add("@cTotGLAcocPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAcocPrem); }
            if (lCompany.cTotGLAgrossPrem != null) { cmd.Parameters.Add("@cTotGLAgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAgrossPrem); }
            if (lCompany.cTotGLAinsPrem != null) { cmd.Parameters.Add("@cTotGLAinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAinsPrem); }
            if (lCompany.cTotGLAoptionPrem != null) { cmd.Parameters.Add("@cTotGLAoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAoptionPrem); }
            if (lCompany.cTotGLAtibPrem != null) { cmd.Parameters.Add("@cTotGLAtibPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAtibPrem); }
            if (lCompany.cTotPTDgrossPrem != null) { cmd.Parameters.Add("@cTotPTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPTDgrossPrem); }
            if (lCompany.cTotPTDoptionPrem != null) { cmd.Parameters.Add("@cTotPTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPTDoptionPrem); }
            if (lCompany.cTotIncDisPremExCommBind != null) { cmd.Parameters.Add("@cTotIncDisPremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotIncDisPremExCommBind); }
            if (lCompany.cTotIncDisPremIncBindProv != null) { cmd.Parameters.Add("@cTotIncDisPremIncBindProv", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotIncDisPremIncBindProv); }
            if (lCompany.cTotIncDisPremIncCommBind != null) { cmd.Parameters.Add("@cTotIncDisPremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotIncDisPremIncCommBind); }
            if (lCompany.cTotIncDisPremPA != null) { cmd.Parameters.Add("@cTotIncDisPremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotIncDisPremPA); }
            if (lCompany.cTotLifePremExCommBind != null) { cmd.Parameters.Add("@cTotLifePremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotLifePremExCommBind); }
            if (lCompany.cTotLifePremIncBindProv != null) { cmd.Parameters.Add("@cTotLifePremIncBindProv", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotLifePremIncBindProv); }
            if (lCompany.cTotLifePremIncCommBind != null) { cmd.Parameters.Add("@cTotLifePremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotLifePremIncCommBind); }
            if (lCompany.cTotLifePremPA != null) { cmd.Parameters.Add("@cTotLifePremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotLifePremPA); }
            if (lCompany.cTotMAPWgrossPrem != null) { cmd.Parameters.Add("@cTotMAPWgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotMAPWgrossPrem); }
            if (lCompany.cTotNumberMembers != null) { cmd.Parameters.Add("@cTotNumberMembers", SqlDbType.Int).Value = Convert.ToInt32(lCompany.cTotNumberMembers); }
            //if (lCompany.cTotNumberS != null) { cmd.Parameters.Add("@cTotNumberS", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotNumberS); }
            if (lCompany.cTotPHIgrossPrem != null) { cmd.Parameters.Add("@cTotPHIgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIgrossPrem); }
            if (lCompany.cTotPHIgrowthPrem != null) { cmd.Parameters.Add("@cTotPHIgrowthPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIgrowthPrem); }
            if (lCompany.cTotPHIinsPrem != null) { cmd.Parameters.Add("@cTotPHIinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIinsPrem); }
            if (lCompany.cTotPHIinsPremWaiver != null) { cmd.Parameters.Add("@cTotPHIinsPremWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIinsPremWaiver); }
            if (lCompany.cTotPHIoptionPrem != null) { cmd.Parameters.Add("@cTotPHIoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIoptionPrem); }
            if (lCompany.cTotPremIncCommBind != null) { cmd.Parameters.Add("@cTotPremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremIncCommBind); }
            if (lCompany.cTotSGLAgrossPrem != null) { cmd.Parameters.Add("@cTotSGLAgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSGLAgrossPrem); }
            if (lCompany.cTotSGLAoptionPrem != null) { cmd.Parameters.Add("@cTotSGLAoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSGLAoptionPrem); }
            if (lCompany.cTotSPTDgrossPrem != null) { cmd.Parameters.Add("@cTotSPTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSPTDgrossPrem); }
            if (lCompany.cTotSPTDoptionPrem != null) { cmd.Parameters.Add("@cTotSPTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSPTDoptionPrem); }
            if (lCompany.cTotSpousesPremExCommBind != null) { cmd.Parameters.Add("@cTotSpousesPremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSpousesPremExCommBind); }
            if (lCompany.cTotSpousesPremIncBindProv != null) { cmd.Parameters.Add("@cTotSpousesPremIncBindProv", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSpousesPremIncBindProv); }
            if (lCompany.cTotSpousesPremIncCommBind != null) { cmd.Parameters.Add("@cTotSpousesPremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSpousesPremIncCommBind); }
            if (lCompany.cTotSpousesPremPA != null) { cmd.Parameters.Add("@cTotSpousesPremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSpousesPremPA); }
            //if (lCompany.cTotSCIIgicPrem != null) { cmd.Parameters.Add("@cTotSCIIgicPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSCIIgicPrem); }
            //if (lCompany.cTotSCIIcocPrem != null) { cmd.Parameters.Add("@cTotSCIIcocPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSCIIcocPrem); }
            //if (lCompany.cTotSCIIgrossPrem != null) { cmd.Parameters.Add("@cTotSCIIgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSCIIgrossPrem); }
            //if (lCompany.cTotSCIIinsPrem != null) { cmd.Parameters.Add("@cTotSCIIinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSCIIinsPrem); }
            //if (lCompany.cTotSCIIoptionPrem != null) { cmd.Parameters.Add("@cTotSCIIoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSCIIoptionPrem); }
            if (lCompany.cTotSRgrossPrem != null) { cmd.Parameters.Add("@cTotSRgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSRgrossPrem); }
            if (lCompany.cTotTopUpGrossPrem != null) { cmd.Parameters.Add("@cTotTopUpGrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTopUpGrossPrem); }
            if (lCompany.cTotTopUpGrowthPrem != null) { cmd.Parameters.Add("@cTotTopUpGrowthPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTopUpGrowthPrem); }
            if (lCompany.cTotCIIgicPrem != null) { cmd.Parameters.Add("@cTotCIIgicPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIgicPrem); }
            if (lCompany.cTotCIIcocPrem != null) { cmd.Parameters.Add("@cTotCIIcocPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIcocPrem); }
            if (lCompany.cTotCIIgrossPrem != null) { cmd.Parameters.Add("@cTotCIIgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIgrossPrem); }
            if (lCompany.cTotCIIinsPrem != null) { cmd.Parameters.Add("@cTotCIIinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIinsPrem); }
            if (lCompany.cTotCIIoptionPrem != null) { cmd.Parameters.Add("@cTotCIIoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIoptionPrem); }
            if (lCompany.cTotCIIpremExCommBind != null) { cmd.Parameters.Add("@cTotCIIpremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIpremExCommBind); }
            if (lCompany.cTotCIIpremIncBindProv != null) { cmd.Parameters.Add("@cTotCIIpremIncBindProv", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIpremIncBindProv); }
            if (lCompany.cTotCIIpremIncCommBind != null) { cmd.Parameters.Add("@cTotCIIpremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIpremIncCommBind); }
            if (lCompany.cTotCIIpremPA != null) { cmd.Parameters.Add("@cTotCIIpremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIpremPA); }
            if (lCompany.cTotUEPgrossPrem != null) { cmd.Parameters.Add("@cTotUEPgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotUEPgrossPrem); }
            if (lCompany.cCIIgicPremMille != null) { cmd.Parameters.Add("@cCIIgicPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIgicPremMille); }
            if (lCompany.cCIIgicPremRate != null) { cmd.Parameters.Add("@cCIIgicPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIgicPremRate); }
            if (lCompany.cCIIcocPremMille != null) { cmd.Parameters.Add("@cCIIcocPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIcocPremMille); }
            if (lCompany.cCIIcocPremRate != null) { cmd.Parameters.Add("@cCIIcocPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIcocPremRate); }
            //if (lCompany.cCIIgrossPremMille != null) { cmd.Parameters.Add("@cCIIgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIgrossPremMille); }
            //if (lCompany.cCIIgrossPremRate != null) { cmd.Parameters.Add("@cCIIgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIgrossPremRate); }
            if (lCompany.cCIIinsPremMille != null) { cmd.Parameters.Add("@cCIIinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIinsPremMille); }
            if (lCompany.cCIIinsPremRate != null) { cmd.Parameters.Add("@cCIIinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIinsPremRate); }
            if (lCompany.cCIIoptionPremMille != null) { cmd.Parameters.Add("@cCIIoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIoptionPremMille); }
            if (lCompany.cCIIoptionPremRate != null) { cmd.Parameters.Add("@cCIIoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIoptionPremRate); }
            if (lCompany.cUEPgrossPremMille != null) { cmd.Parameters.Add("@cUEPgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cUEPgrossPremMille); }
            if (lCompany.cUEPgrossPremRate != null) { cmd.Parameters.Add("@cUEPgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cUEPgrossPremRate); }
            //if (lCompany.cMPFLvalueGLA != null) { cmd.Parameters.Add("@cMPFLvalueGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMPFLvalueGLA); }
            //if (lCompany.cMPFLvaluePHI != null) { cmd.Parameters.Add("@cMPFLvaluePHI", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMPFLvaluePHI); }
            //if (lCompany.cMPFLvalueSGLA != null) { cmd.Parameters.Add("@cMPFLvalueSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMPFLvalueSGLA); }
            //if (lCompany.cMPFLvalueCII != null) { cmd.Parameters.Add("@cMPFLvalueCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMPFLvalueCII); }
            //if (lCompany.cTotCountGLAPTD != null) { cmd.Parameters.Add("@cTotCountGLAPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCountGLAPTD); }
            if (lCompany.cTotCountFUN != null) { cmd.Parameters.Add("@cTotCountFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCountFUN); }
            //if (lCompany.cTotAnnualSalaryGLAPTD != null) { cmd.Parameters.Add("@cTotAnnualSalaryGLAPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnualSalaryGLAPTD); }
            //if (lCompany.cTotAnnualSalaryCII != null) { cmd.Parameters.Add("@cTotAnnualSalaryCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnualSalaryCII); }
            //if (lCompany.cTotAnnualSalaryPHI != null) { cmd.Parameters.Add("@cTotAnnualSalaryPHI", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnualSalaryPHI); }
            //if (lCompany.cTotAnnualSalaryFUN != null) { cmd.Parameters.Add("@cTotAnnualSalaryFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnualSalaryFUN); }
            if (lCompany.cGLAtrcPremMille != null) { cmd.Parameters.Add("@cGLAtrcPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAtrcPremMille); }
            if (lCompany.cGLAtrcPremRate != null) { cmd.Parameters.Add("@cGLAtrcPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAtrcPremRate); }
            if (lCompany.cTotPTDinsPrem != null) { cmd.Parameters.Add("@cTotPTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPTDinsPrem); }
            if (lCompany.cIncDisBindPremMille != null) { cmd.Parameters.Add("@cIncDisBindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cIncDisBindPremMille); }
            if (lCompany.cIncDisBindPremRate != null) { cmd.Parameters.Add("@cIncDisBindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cIncDisBindPremRate); }
            if (lCompany.cIncDisCommPremMille != null) { cmd.Parameters.Add("@cIncDisCommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cIncDisCommPremMille); }
            if (lCompany.cIncDisCommPremRate != null) { cmd.Parameters.Add("@cIncDisCommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cIncDisCommPremRate); }
            if (lCompany.cIncDisOutsPremMille != null) { cmd.Parameters.Add("@cIncDisOutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cIncDisOutsPremMille); }
            if (lCompany.cIncDisOutsPremRate != null) { cmd.Parameters.Add("@cIncDisOutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cIncDisOutsPremRate); }
            if (lCompany.cLifeBindPremMille != null) { cmd.Parameters.Add("@cLifeBindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cLifeBindPremMille); }
            if (lCompany.cLifeBindPremRate != null) { cmd.Parameters.Add("@cLifeBindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cLifeBindPremRate); }
            if (lCompany.cLifeCommPremMille != null) { cmd.Parameters.Add("@cLifeCommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cLifeCommPremMille); }
            if (lCompany.cLifeCommPremRate != null) { cmd.Parameters.Add("@cLifeCommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cLifeCommPremRate); }
            if (lCompany.cLifeOutsPremMille != null) { cmd.Parameters.Add("@cLifeOutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cLifeOutsPremMille); }
            if (lCompany.cLifeOutsPremRate != null) { cmd.Parameters.Add("@cLifeOutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cLifeOutsPremRate); }
            if (lCompany.cFUNbindPremMille != null) { cmd.Parameters.Add("@cFUNbindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNbindPremMille); }
            if (lCompany.cFUNbindPremRate != null) { cmd.Parameters.Add("@cFUNbindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNbindPremRate); }
            if (lCompany.cFUNcommPremMille != null) { cmd.Parameters.Add("@cFUNcommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNcommPremMille); }
            if (lCompany.cFUNcommPremRate != null) { cmd.Parameters.Add("@cFUNcommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNcommPremRate); }
            if (lCompany.cFUNoutsPremMille != null) { cmd.Parameters.Add("@cFUNoutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNoutsPremMille); }
            if (lCompany.cFUNoutsPremRate != null) { cmd.Parameters.Add("@cFUNoutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNoutsPremRate); }
            if (lCompany.cSpousesBindPremMille != null) { cmd.Parameters.Add("@cSpousesBindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSpousesBindPremMille); }
            if (lCompany.cSpousesBindPremRate != null) { cmd.Parameters.Add("@cSpousesBindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSpousesBindPremRate); }
            if (lCompany.cSpousesCommPremMille != null) { cmd.Parameters.Add("@cSpousesCommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSpousesCommPremMille); }
            if (lCompany.cSpousesCommPremRate != null) { cmd.Parameters.Add("@cSpousesCommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSpousesCommPremRate); }
            if (lCompany.cSpousesOutsPremMille != null) { cmd.Parameters.Add("@cSpousesOutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSpousesOutsPremMille); }
            if (lCompany.cSpousesOutsPremRate != null) { cmd.Parameters.Add("@cSpousesOutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSpousesOutsPremRate); }
            if (lCompany.cCIIbindPremMille != null) { cmd.Parameters.Add("@cCIIbindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIbindPremMille); }
            if (lCompany.cCIIbindPremRate != null) { cmd.Parameters.Add("@cCIIbindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIbindPremRate); }
            if (lCompany.cCIIcommPremMille != null) { cmd.Parameters.Add("@cCIIcommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIcommPremMille); }
            if (lCompany.cCIIcommPremRate != null) { cmd.Parameters.Add("@cCIIcommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIcommPremRate); }
            if (lCompany.cCIIoutsPremMille != null) { cmd.Parameters.Add("@cCIIoutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIoutsPremMille); }
            if (lCompany.cCIIoutsPremRate != null) { cmd.Parameters.Add("@cCIIoutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIoutsPremRate); }
            if (lCompany.cTotGLAtrcPrem != null) { cmd.Parameters.Add("@cTotGLAtrcPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAtrcPrem); }
            //if (lCompany.cIncDisTotalPremMille != null) { cmd.Parameters.Add("@cIncDisTotalPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cIncDisTotalPremMille); }
            //if (lCompany.cIncDisTotalPremRate != null) { cmd.Parameters.Add("@cIncDisTotalPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cIncDisTotalPremRate); }
            //if (lCompany.cLifeTotalPremMille != null) { cmd.Parameters.Add("@cLifeTotalPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cLifeTotalPremMille); }
            //if (lCompany.cLifeTotalPremRate != null) { cmd.Parameters.Add("@cLifeTotalPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cLifeTotalPremRate); }
            //if (lCompany.cFUNtotalPremMille != null) { cmd.Parameters.Add("@cFUNtotalPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNtotalPremMille); }
            //if (lCompany.cFUNtotalPremRate != null) { cmd.Parameters.Add("@cFUNtotalPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNtotalPremRate); }
            //if (lCompany.cSpousesTotalPremMille != null) { cmd.Parameters.Add("@cSpousesTotalPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSpousesTotalPremMille); }
            //if (lCompany.cSpousesTotalPremRate != null) { cmd.Parameters.Add("@cSpousesTotalPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSpousesTotalPremRate); }
            //if (lCompany.cCIItotalPremMille != null) { cmd.Parameters.Add("@cCIItotalPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIItotalPremMille); }
            //if (lCompany.cCIItotalPremRate != null) { cmd.Parameters.Add("@cCIItotalPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIItotalPremRate); }
            //if (lCompany.cTotLifePrem != null) { cmd.Parameters.Add("@cTotLifePrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotLifePrem); }
            //if (lCompany.cTotIncDisPrem != null) { cmd.Parameters.Add("@cTotIncDisPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotIncDisPrem); }
            //if (lCompany.cTotSpousesPrem != null) { cmd.Parameters.Add("@cTotSpousesPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSpousesPrem); }
            //if (lCompany.cTotFUNprem != null) { cmd.Parameters.Add("@cTotFUNprem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNprem); }
            //if (lCompany.cTotCIIprem != null) { cmd.Parameters.Add("@cTotCIIprem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIprem); }
            //if (lCompany.cFUNtotalPremPmpm != null) { cmd.Parameters.Add("@cFUNtotalPremPmpm", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNtotalPremPmpm); }
            if (lCompany.cBinderAmtTIncDis != null) { cmd.Parameters.Add("@cBinderAmtTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cBinderAmtTIncDis); }
            if (lCompany.cCommAmtTIncDis != null) { cmd.Parameters.Add("@cCommAmtTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommAmtTIncDis); }
            if (lCompany.cCommPercTIncDis != null) { cmd.Parameters.Add("@cCommPercTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCommPercTIncDis); }
            if (lCompany.cFUNinsPremMille != null) { cmd.Parameters.Add("@cFUNinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNinsPremMille); }
            if (lCompany.cFUNinsPremRate != null) { cmd.Parameters.Add("@cFUNinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNinsPremRate); }
            if (lCompany.cFUNpremMille != null) { cmd.Parameters.Add("@cFUNpremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNpremMille); }
            if (lCompany.cFUNtransportPremMille != null) { cmd.Parameters.Add("@cFUNtransportPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNtransportPremMille); }
            if (lCompany.cFUNtransportPremRate != null) { cmd.Parameters.Add("@cFUNtransportPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNtransportPremRate); }
            if (lCompany.cOutsourceAmtTIncDis != null) { cmd.Parameters.Add("@cOutsourceAmtTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cOutsourceAmtTIncDis); }
            if (lCompany.cPHIsizeFactor != null) { cmd.Parameters.Add("@cPHIsizeFactor", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIsizeFactor); }
            if (lCompany.cPTDinsPremMille != null) { cmd.Parameters.Add("@cPTDinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDinsPremMille); }
            if (lCompany.cPTDinsPremRate != null) { cmd.Parameters.Add("@cPTDinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDinsPremRate); }
            if (lCompany.cSGLAinsPremMille != null) { cmd.Parameters.Add("@cSGLAinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAinsPremMille); }
            if (lCompany.cSGLAinsPremRate != null) { cmd.Parameters.Add("@cSGLAinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAinsPremRate); }
            if (lCompany.cSPTDinsPremMille != null) { cmd.Parameters.Add("@cSPTDinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDinsPremMille); }
            if (lCompany.cSPTDinsPremRate != null) { cmd.Parameters.Add("@cSPTDinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDinsPremRate); }
            if (lCompany.cStampDutyRate != null) { cmd.Parameters.Add("@cStampDutyRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cStampDutyRate); }
            if (lCompany.cTIncDisBindPremMille != null) { cmd.Parameters.Add("@cTIncDisBindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTIncDisBindPremMille); }
            if (lCompany.cTIncDisBindPremRate != null) { cmd.Parameters.Add("@cTIncDisBindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTIncDisBindPremRate); }
            if (lCompany.cTIncDisCommPremMille != null) { cmd.Parameters.Add("@cTIncDisCommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTIncDisCommPremMille); }
            if (lCompany.cTIncDisCommPremRate != null) { cmd.Parameters.Add("@cTIncDisCommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTIncDisCommPremRate); }
            if (lCompany.cTIncDisOutsPremMille != null) { cmd.Parameters.Add("@cTIncDisOutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTIncDisOutsPremMille); }
            if (lCompany.cTIncDisOutsPremRate != null) { cmd.Parameters.Add("@cTIncDisOutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTIncDisOutsPremRate); }
            if (lCompany.cTopUpInsPremMille != null) { cmd.Parameters.Add("@cTopUpInsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpInsPremMille); }
            if (lCompany.cTopUpInsPremRate != null) { cmd.Parameters.Add("@cTopUpInsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpInsPremRate); }
            if (lCompany.cTotCountTTD != null) { cmd.Parameters.Add("@cTotCountTTD", SqlDbType.Int).Value = Convert.ToInt32(lCompany.cTotCountTTD); }
            if (lCompany.cTotCoverTTD != null) { cmd.Parameters.Add("@cTotCoverTTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverTTD); }
            if (lCompany.cTotCoverTTDincWaiver != null) { cmd.Parameters.Add("@cTotCoverTTDincWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverTTDincWaiver); }
            if (lCompany.cTotCoverTTDwaiver != null) { cmd.Parameters.Add("@cTotCoverTTDwaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCoverTTDwaiver); }
            if (lCompany.cTotFUNinsPrem != null) { cmd.Parameters.Add("@cTotFUNinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNinsPrem); }
            if (lCompany.cTotFUNtransportPrem != null) { cmd.Parameters.Add("@cTotFUNtransportPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNtransportPrem); }
            if (lCompany.cTotNumberSpouses != null) { cmd.Parameters.Add("@cTotNumberSpouses", SqlDbType.Int).Value = Convert.ToInt32(lCompany.cTotNumberSpouses); }
            if (lCompany.cTotPremCIImille != null) { cmd.Parameters.Add("@cTotPremCIImille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremCIImille); }
            if (lCompany.cTotPremCIIrate != null) { cmd.Parameters.Add("@cTotPremCIIrate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremCIIrate); }
            if (lCompany.cTotPremFUNmille != null) { cmd.Parameters.Add("@cTotPremFUNmille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremFUNmille); }
            if (lCompany.cTotPremFUNrate != null) { cmd.Parameters.Add("@cTotPremFUNrate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremFUNrate); }
            if (lCompany.cTotPremIncDisMille != null) { cmd.Parameters.Add("@cTotPremIncDisMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremIncDisMille); }
            if (lCompany.cTotPremIncDisRate != null) { cmd.Parameters.Add("@cTotPremIncDisRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremIncDisRate); }
            if (lCompany.cTotPremLifeMille != null) { cmd.Parameters.Add("@cTotPremLifeMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremLifeMille); }
            if (lCompany.cTotPremLifeRate != null) { cmd.Parameters.Add("@cTotPremLifeRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremLifeRate); }
            if (lCompany.cTotPremRate != null) { cmd.Parameters.Add("@cTotPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremRate); }
            if (lCompany.cTotPremSpousesMille != null) { cmd.Parameters.Add("@cTotPremSpousesMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremSpousesMille); }
            if (lCompany.cTotPremSpousesRate != null) { cmd.Parameters.Add("@cTotPremSpousesRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremSpousesRate); }
            if (lCompany.cTotPremTIncDisMille != null) { cmd.Parameters.Add("@cTotPremTIncDisMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremTIncDisMille); }
            if (lCompany.cTotPremTIncDisRate != null) { cmd.Parameters.Add("@cTotPremTIncDisRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPremTIncDisRate); }
            //if (lCompany.cTotSCIIpremPA != null) { cmd.Parameters.Add("@cTotSCIIpremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSCIIpremPA); }
            if (lCompany.cTotSGLAinsPrem != null) { cmd.Parameters.Add("@cTotSGLAinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSGLAinsPrem); }
            if (lCompany.cTotSPTDinsPrem != null) { cmd.Parameters.Add("@cTotSPTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSPTDinsPrem); }
            if (lCompany.cTotTIncDisPremExCommBind != null) { cmd.Parameters.Add("@cTotTIncDisPremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTIncDisPremExCommBind); }
            if (lCompany.cTotTIncDisPremIncBindProv != null) { cmd.Parameters.Add("@cTotTIncDisPremIncBindProv", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTIncDisPremIncBindProv); }
            if (lCompany.cTotTIncDisPremIncCommBind != null) { cmd.Parameters.Add("@cTotTIncDisPremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTIncDisPremIncCommBind); }
            if (lCompany.cTotTIncDisPremPA != null) { cmd.Parameters.Add("@cTotTIncDisPremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTIncDisPremPA); }
            if (lCompany.cTotTopUpInsPrem != null) { cmd.Parameters.Add("@cTotTopUpInsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTopUpInsPrem); }
            if (lCompany.cTotTTDgrossPrem != null) { cmd.Parameters.Add("@cTotTTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTTDgrossPrem); }
            if (lCompany.cTotTTDinsPrem != null) { cmd.Parameters.Add("@cTotTTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTTDinsPrem); }
            if (lCompany.cTotTTDinsPremWaiver != null) { cmd.Parameters.Add("@cTotTTDinsPremWaiver", SqlDbType.Int).Value = Convert.ToInt32(lCompany.cTotTTDinsPremWaiver); }
            if (lCompany.cTotTTDoptionPrem != null) { cmd.Parameters.Add("@cTotTTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTTDoptionPrem); }
            //if (lCompany.cTTDgrossPremMille != null) { cmd.Parameters.Add("@cTTDgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDgrossPremMille); }
            //if (lCompany.cTTDgrossPremRate != null) { cmd.Parameters.Add("@cTTDgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDgrossPremRate); }
            if (lCompany.cTTDinsPremMille != null) { cmd.Parameters.Add("@cTTDinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDinsPremMille); }
            if (lCompany.cTTDinsPremRate != null) { cmd.Parameters.Add("@cTTDinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDinsPremRate); }
            if (lCompany.cTTDinsWaiverPremMille != null) { cmd.Parameters.Add("@cTTDinsWaiverPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDinsWaiverPremMille); }
            if (lCompany.cTTDinsWaiverPremRate != null) { cmd.Parameters.Add("@cTTDinsWaiverPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDinsWaiverPremRate); }
            //if (lCompany.cMPFLvalueTTD != null) { cmd.Parameters.Add("@cMPFLvalueTTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMPFLvalueTTD); }
            if (lCompany.cAccBenGrossPremMille_if != null) { cmd.Parameters.Add("@cAccBenGrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cAccBenGrossPremMille_if); }
            if (lCompany.cAccBenGrossPremRate_if != null) { cmd.Parameters.Add("@cAccBenGrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cAccBenGrossPremRate_if); }
            if (lCompany.cCIIcocPremMille_if != null) { cmd.Parameters.Add("@cCIIcocPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIcocPremMille_if); }
            if (lCompany.cCIIcocPremRate_if != null) { cmd.Parameters.Add("@cCIIcocPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIcocPremRate_if); }
            if (lCompany.cCIIgicPremMille_if != null) { cmd.Parameters.Add("@cCIIgicPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIgicPremMille_if); }
            if (lCompany.cCIIgicPremRate_if != null) { cmd.Parameters.Add("@cCIIgicPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIgicPremRate_if); }
            if (lCompany.cCIIinsPremMille_if != null) { cmd.Parameters.Add("@cCIIinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIinsPremMille_if); }
            if (lCompany.cCIIinsPremRate_if != null) { cmd.Parameters.Add("@cCIIinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIinsPremRate_if); }
            if (lCompany.cCIIoptionPremMille_if != null) { cmd.Parameters.Add("@cCIIoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIoptionPremMille_if); }
            if (lCompany.cCIIoptionPremRate_if != null) { cmd.Parameters.Add("@cCIIoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cCIIoptionPremRate_if); }
            if (lCompany.cFUNinsPremMille_if != null) { cmd.Parameters.Add("@cFUNinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNinsPremMille_if); }
            if (lCompany.cFUNinsPremRate_if != null) { cmd.Parameters.Add("@cFUNinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNinsPremRate_if); }
            if (lCompany.cFUNtransportPremMille_if != null) { cmd.Parameters.Add("@cFUNtransportPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNtransportPremMille_if); }
            if (lCompany.cFUNtransportPremRate_if != null) { cmd.Parameters.Add("@cFUNtransportPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cFUNtransportPremRate_if); }
            if (lCompany.cGLAcocPremMille_if != null) { cmd.Parameters.Add("@cGLAcocPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAcocPremMille_if); }
            if (lCompany.cGLAcocPremRate_if != null) { cmd.Parameters.Add("@cGLAcocPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAcocPremRate_if); }
            if (lCompany.cGLAgicPremMille_if != null) { cmd.Parameters.Add("@cGLAgicPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAgicPremMille_if); }
            if (lCompany.cGLAgicPremRate_if != null) { cmd.Parameters.Add("@cGLAgicPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAgicPremRate_if); }
            if (lCompany.cGLAinsPremMille_if != null) { cmd.Parameters.Add("@cGLAinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAinsPremMille_if); }
            if (lCompany.cGLAinsPremRate_if != null) { cmd.Parameters.Add("@cGLAinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAinsPremRate_if); }
            if (lCompany.cGLAoptionPremMille_if != null) { cmd.Parameters.Add("@cGLAoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAoptionPremMille_if); }
            if (lCompany.cGLAoptionPremRate_if != null) { cmd.Parameters.Add("@cGLAoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAoptionPremRate_if); }
            if (lCompany.cGLAtibPremMille_if != null) { cmd.Parameters.Add("@cGLAtibPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAtibPremMille_if); }
            if (lCompany.cGLAtibPremRate_if != null) { cmd.Parameters.Add("@cGLAtibPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAtibPremRate_if); }
            if (lCompany.cGLAtrcPremMille_if != null) { cmd.Parameters.Add("@cGLAtrcPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAtrcPremMille_if); }
            if (lCompany.cGLAtrcPremRate_if != null) { cmd.Parameters.Add("@cGLAtrcPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cGLAtrcPremRate_if); }
            if (lCompany.cMAPWgrossPremMille_if != null) { cmd.Parameters.Add("@cMAPWgrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMAPWgrossPremMille_if); }
            if (lCompany.cMAPWgrossPremRate_if != null) { cmd.Parameters.Add("@cMAPWgrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMAPWgrossPremRate_if); }
            if (lCompany.cPHIgrowthPremMille_if != null) { cmd.Parameters.Add("@cPHIgrowthPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIgrowthPremMille_if); }
            if (lCompany.cPHIgrowthPremRate_if != null) { cmd.Parameters.Add("@cPHIgrowthPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIgrowthPremRate_if); }
            if (lCompany.cPHIinsPremMille_if != null) { cmd.Parameters.Add("@cPHIinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIinsPremMille_if); }
            if (lCompany.cPHIinsPremRate_if != null) { cmd.Parameters.Add("@cPHIinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIinsPremRate_if); }
            if (lCompany.cPHIinsWaiverPremMille_if != null) { cmd.Parameters.Add("@cPHIinsWaiverPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIinsWaiverPremMille_if); }
            if (lCompany.cPHIinsWaiverPremRate_if != null) { cmd.Parameters.Add("@cPHIinsWaiverPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIinsWaiverPremRate_if); }
            if (lCompany.cPHIoptionPremMille_if != null) { cmd.Parameters.Add("@cPHIoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIoptionPremMille_if); }
            if (lCompany.cPHIoptionPremRate_if != null) { cmd.Parameters.Add("@cPHIoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPHIoptionPremRate_if); }
            if (lCompany.cPTDinsPremMille_if != null) { cmd.Parameters.Add("@cPTDinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDinsPremMille_if); }
            if (lCompany.cPTDinsPremRate_if != null) { cmd.Parameters.Add("@cPTDinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDinsPremRate_if); }
            if (lCompany.cPTDoptionPremMille_if != null) { cmd.Parameters.Add("@cPTDoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDoptionPremMille_if); }
            if (lCompany.cPTDoptionPremRate_if != null) { cmd.Parameters.Add("@cPTDoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDoptionPremRate_if); }
            if (lCompany.cSGLAinsPremMille_if != null) { cmd.Parameters.Add("@cSGLAinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAinsPremMille_if); }
            if (lCompany.cSGLAinsPremRate_if != null) { cmd.Parameters.Add("@cSGLAinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAinsPremRate_if); }
            if (lCompany.cSGLAoptionPremMille_if != null) { cmd.Parameters.Add("@cSGLAoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAoptionPremMille_if); }
            if (lCompany.cSGLAoptionPremRate_if != null) { cmd.Parameters.Add("@cSGLAoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSGLAoptionPremRate_if); }
            if (lCompany.cSPTDinsPremMille_if != null) { cmd.Parameters.Add("@cSPTDinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDinsPremMille_if); }
            if (lCompany.cSPTDinsPremRate_if != null) { cmd.Parameters.Add("@cSPTDinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDinsPremRate_if); }
            if (lCompany.cSPTDoptionPremMille_if != null) { cmd.Parameters.Add("@cSPTDoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDoptionPremMille_if); }
            if (lCompany.cSPTDoptionPremRate_if != null) { cmd.Parameters.Add("@cSPTDoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSPTDoptionPremRate_if); }
            if (lCompany.cSRgrossPremMille_if != null) { cmd.Parameters.Add("@cSRgrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSRgrossPremMille_if); }
            if (lCompany.cSRgrossPremRate_if != null) { cmd.Parameters.Add("@cSRgrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cSRgrossPremRate_if); }
            if (lCompany.cTopUpGrowthPremMille_if != null) { cmd.Parameters.Add("@cTopUpGrowthPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpGrowthPremMille_if); }
            if (lCompany.cTopUpGrowthPremRate_if != null) { cmd.Parameters.Add("@cTopUpGrowthPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpGrowthPremRate_if); }
            if (lCompany.cTopUpInsPremMille_if != null) { cmd.Parameters.Add("@cTopUpInsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpInsPremMille_if); }
            if (lCompany.cTopUpInsPremRate_if != null) { cmd.Parameters.Add("@cTopUpInsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTopUpInsPremRate_if); }
            if (lCompany.cTotAccBenGrossPrem_if != null) { cmd.Parameters.Add("@cTotAccBenGrossPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAccBenGrossPrem_if); }
            if (lCompany.cTotCIIcocPrem_if != null) { cmd.Parameters.Add("@cTotCIIcocPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIcocPrem_if); }
            if (lCompany.cTotCIIgicPrem_if != null) { cmd.Parameters.Add("@cTotCIIgicPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIgicPrem_if); }
            if (lCompany.cTotCIIinsPrem_if != null) { cmd.Parameters.Add("@cTotCIIinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIinsPrem_if); }
            if (lCompany.cTotCIIoptionPrem_if != null) { cmd.Parameters.Add("@cTotCIIoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCIIoptionPrem_if); }
            if (lCompany.cTotCountGLA != null) { cmd.Parameters.Add("@cTotCountGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCountGLA); }
            if (lCompany.cTotCountPTD != null) { cmd.Parameters.Add("@cTotCountPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCountPTD); }
            if (lCompany.cTotCountSGLA != null) { cmd.Parameters.Add("@cTotCountSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCountSGLA); }
            if (lCompany.cTotCountSPTD != null) { cmd.Parameters.Add("@cTotCountSPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotCountSPTD); }
            if (lCompany.cTotFUNinsPrem_if != null) { cmd.Parameters.Add("@cTotFUNinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNinsPrem_if); }
            if (lCompany.cTotFUNpremPMPM != null) { cmd.Parameters.Add("@cTotFUNpremPMPM", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNpremPMPM); }
            if (lCompany.cTotFUNtransportPrem_if != null) { cmd.Parameters.Add("@cTotFUNtransportPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotFUNtransportPrem_if); }
            if (lCompany.cTotGLAcocPrem_if != null) { cmd.Parameters.Add("@cTotGLAcocPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAcocPrem_if); }
            if (lCompany.cTotGLAgicPrem_if != null) { cmd.Parameters.Add("@cTotGLAgicPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAgicPrem_if); }
            if (lCompany.cTotGLAinsPrem_if != null) { cmd.Parameters.Add("@cTotGLAinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAinsPrem_if); }
            if (lCompany.cTotGLAoptionPrem_if != null) { cmd.Parameters.Add("@cTotGLAoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAoptionPrem_if); }
            if (lCompany.cTotGLAtibPrem_if != null) { cmd.Parameters.Add("@cTotGLAtibPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAtibPrem_if); }
            if (lCompany.cTotGLAtrcPrem_if != null) { cmd.Parameters.Add("@cTotGLAtrcPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotGLAtrcPrem_if); }
            if (lCompany.cTotMAPWgrossPrem_if != null) { cmd.Parameters.Add("@cTotMAPWgrossPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotMAPWgrossPrem_if); }
            if (lCompany.cTotPHIgrowthPrem_if != null) { cmd.Parameters.Add("@cTotPHIgrowthPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIgrowthPrem_if); }
            if (lCompany.cTotPHIinsPrem_if != null) { cmd.Parameters.Add("@cTotPHIinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIinsPrem_if); }
            if (lCompany.cTotPHIinsPremWaiver_if != null) { cmd.Parameters.Add("@cTotPHIinsPremWaiver_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIinsPremWaiver_if); }
            if (lCompany.cTotPHIoptionPrem_if != null) { cmd.Parameters.Add("@cTotPHIoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPHIoptionPrem_if); }
            if (lCompany.cTotPTDinsPrem_if != null) { cmd.Parameters.Add("@cTotPTDinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPTDinsPrem_if); }
            if (lCompany.cTotPTDoptionPrem_if != null) { cmd.Parameters.Add("@cTotPTDoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotPTDoptionPrem_if); }
            if (lCompany.cTotSGLAinsPrem_if != null) { cmd.Parameters.Add("@cTotSGLAinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSGLAinsPrem_if); }
            if (lCompany.cTotSGLAoptionPrem_if != null) { cmd.Parameters.Add("@cTotSGLAoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSGLAoptionPrem_if); }
            if (lCompany.cTotSPTDinsPrem_if != null) { cmd.Parameters.Add("@cTotSPTDinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSPTDinsPrem_if); }
            if (lCompany.cTotSPTDoptionPrem_if != null) { cmd.Parameters.Add("@cTotSPTDoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSPTDoptionPrem_if); }
            if (lCompany.cTotSRgrossPrem_if != null) { cmd.Parameters.Add("@cTotSRgrossPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotSRgrossPrem_if); }
            if (lCompany.cTotTopUpGrowthPrem_if != null) { cmd.Parameters.Add("@cTotTopUpGrowthPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTopUpGrowthPrem_if); }
            if (lCompany.cTotTopUpInsPrem_if != null) { cmd.Parameters.Add("@cTotTopUpInsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTopUpInsPrem_if); }
            if (lCompany.cTotTTDinsPrem_if != null) { cmd.Parameters.Add("@cTotTTDinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTTDinsPrem_if); }
            if (lCompany.cTotTTDinsPremWaiver_if != null) { cmd.Parameters.Add("@cTotTTDinsPremWaiver_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTTDinsPremWaiver_if); }
            if (lCompany.cTotTTDoptionPrem_if != null) { cmd.Parameters.Add("@cTotTTDoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotTTDoptionPrem_if); }
            if (lCompany.cTotUEPgrossPrem_if != null) { cmd.Parameters.Add("@cTotUEPgrossPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotUEPgrossPrem_if); }
            if (lCompany.cTTDinsPremMille_if != null) { cmd.Parameters.Add("@cTTDinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDinsPremMille_if); }
            if (lCompany.cTTDinsPremRate_if != null) { cmd.Parameters.Add("@cTTDinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDinsPremRate_if); }
            if (lCompany.cTTDinsWaiverPremMille_if != null) { cmd.Parameters.Add("@cTTDinsWaiverPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDinsWaiverPremMille_if); }
            if (lCompany.cTTDinsWaiverPremRate_if != null) { cmd.Parameters.Add("@cTTDinsWaiverPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTTDinsWaiverPremRate_if); }
            if (lCompany.cUEPgrossPremMille_if != null) { cmd.Parameters.Add("@cUEPgrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cUEPgrossPremMille_if); }
            if (lCompany.cUEPgrossPremRate_if != null) { cmd.Parameters.Add("@cUEPgrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cUEPgrossPremRate_if); }
            if (lCompany.cTotAnnSalLife != null) { cmd.Parameters.Add("@cTotAnnSalLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnSalLife); }
            if (lCompany.cTotAnnSalCII != null) { cmd.Parameters.Add("@cTotAnnSalCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnSalCII); }
            if (lCompany.cTotAnnSalFUN != null) { cmd.Parameters.Add("@cTotAnnSalFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnSalFUN); }
            if (lCompany.cTotAnnSalSpouses != null) { cmd.Parameters.Add("@cTotAnnSalSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnSalSpouses); }
            if (lCompany.cTotAnnSalIncDis != null) { cmd.Parameters.Add("@cTotAnnSalIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnSalIncDis); }
            if (lCompany.cTotAnnSalTIncDis != null) { cmd.Parameters.Add("@cTotAnnSalTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cTotAnnSalTIncDis); }
            if (lCompany.cPolicyFeeLife != null) { cmd.Parameters.Add("@cPolicyFeeLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPolicyFeeLife); }
            if (lCompany.cPolicyFeeCII != null) { cmd.Parameters.Add("@cPolicyFeeCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPolicyFeeCII); }
            if (lCompany.cPolicyFeeSpouses != null) { cmd.Parameters.Add("@cPolicyFeeSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPolicyFeeSpouses); }
            if (lCompany.cPolicyFeeFUN != null) { cmd.Parameters.Add("@cPolicyFeeFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPolicyFeeFUN); }
            //if (lCompany.cPolicyFeeSGLA != null) { cmd.Parameters.Add("@cPolicyFeeSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPolicyFeeSGLA); }
            //if (lCompany.cPolicyFeeSPTD != null) { cmd.Parameters.Add("@cPolicyFeeSPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPolicyFeeSPTD); }
            //if (lCompany.cPTDgrossPremMille_if != null) { cmd.Parameters.Add("@cPTDgrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDgrossPremMille_if); }
            //if (lCompany.cPTDgrossPremRate_if != null) { cmd.Parameters.Add("@cPTDgrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cPTDgrossPremRate_if); }


            /************************************ From Quote Object *************************************/



            cmd.ExecuteNonQuery();
            connection.Close();
            //if (lCompany.cMPFLvalueTTD!= null) { cmd.Parameters.Add("@cMPFLvalueTTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lCompany.cMPFLvalueTTD); } 
            if (lCompany.category.Length > 0)
            {
                SaveCategory(lCompany.category, iQuoteNumber);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();

        }

    }


    private void SaveCategory(Category[] lcategory, string iQuoteNumber)
    {
        try
        {

            foreach (Category lcat in lcategory)
            {


                SqlCommand cmd = new SqlCommand("Category_OutputSaveProcedure", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlCommand cmd1 = new SqlCommand("select count(iCategoryNumber) from Category_Output where iQuoteNumber=" + iQuoteNumber, connection);
                connection.Open();
                int CategoryCount = Convert.ToInt32(cmd1.ExecuteScalar());

                cmd.Parameters.Add("@_iQuoteNumber", SqlDbType.Int).Value = Convert.ToInt32(iQuoteNumber);
                cmd.Parameters.Add("@_iCategoryNumber", SqlDbType.Int).Value = CategoryCount + 1;
              
                if (lcat.cAccBenGrossPremMille != null) { cmd.Parameters.Add("@_cAccBenGrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cAccBenGrossPremMille); }
                if (lcat.cAccBenGrossPremRate != null) { cmd.Parameters.Add("@_cAccBenGrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cAccBenGrossPremRate); }
                if (lcat.cAvgAge != null) { cmd.Parameters.Add("@_cAvgAge", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cAvgAge); }
                if (lcat.cAvgAgeSpouses != null) { cmd.Parameters.Add("@_cAvgAgeSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cAvgAgeSpouses); }
                if (lcat.cBinderAmtFUN != null) { cmd.Parameters.Add("@_cBinderAmtFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cBinderAmtFUN); }
                if (lcat.cBinderAmtIncDis != null) { cmd.Parameters.Add("@_cBinderAmtIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cBinderAmtIncDis); }
                if (lcat.cBinderAmtLife != null) { cmd.Parameters.Add("@_cBinderAmtLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cBinderAmtLife); }
                if (lcat.cBinderAmtSpouses != null) { cmd.Parameters.Add("@_cBinderAmtSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cBinderAmtSpouses); }
                if (lcat.cBinderAmtTotal != null) { cmd.Parameters.Add("@_cBinderAmtTotal", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cBinderAmtTotal); }
                if (lcat.cBinderAmtCII != null) { cmd.Parameters.Add("@_cBinderAmtCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cBinderAmtCII); }
                if (lcat.cCommAmtFUN != null) { cmd.Parameters.Add("@_cCommAmtFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCommAmtFUN); }
                if (lcat.cCommAmtIncDis != null) { cmd.Parameters.Add("@_cCommAmtIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCommAmtIncDis); }
                if (lcat.cCommAmtLife != null) { cmd.Parameters.Add("@_cCommAmtLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCommAmtLife); }
                if (lcat.cCommAmtSpouses != null) { cmd.Parameters.Add("@_cCommAmtSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCommAmtSpouses); }
                if (lcat.cCommAmtTotal != null) { cmd.Parameters.Add("@_cCommAmtTotal", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCommAmtTotal); }
                if (lcat.cCommAmtCII != null) { cmd.Parameters.Add("@_cCommAmtCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCommAmtCII); }
                if (lcat.cFUNbindPremMille != null) { cmd.Parameters.Add("@_cFUNbindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNbindPremMille); }
                if (lcat.cFUNbindPremRate != null) { cmd.Parameters.Add("@_cFUNbindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNbindPremRate); }
                if (lcat.cFUNcommPremMille != null) { cmd.Parameters.Add("@_cFUNcommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNcommPremMille); }
                if (lcat.cFUNcommPremRate != null) { cmd.Parameters.Add("@_cFUNcommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNcommPremRate); }
                if (lcat.cFUNoutsPremMille != null) { cmd.Parameters.Add("@_cFUNoutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNoutsPremMille); }
                if (lcat.cFUNoutsPremRate != null) { cmd.Parameters.Add("@_cFUNoutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNoutsPremRate); }
                if (lcat.cGLAgicPremMille != null) { cmd.Parameters.Add("@_cGLAgicPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAgicPremMille); }
                if (lcat.cGLAgicPremRate != null) { cmd.Parameters.Add("@_cGLAgicPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAgicPremRate); }
                if (lcat.cGLAcocPremMille != null) { cmd.Parameters.Add("@_cGLAcocPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAcocPremMille); }
                if (lcat.cGLAcocPremRate != null) { cmd.Parameters.Add("@_cGLAcocPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAcocPremRate); }
                if (lcat.cGLAinsPremMille != null) { cmd.Parameters.Add("@_cGLAinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAinsPremMille); }
                if (lcat.cGLAinsPremRate != null) { cmd.Parameters.Add("@_cGLAinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAinsPremRate); }
                if (lcat.cGLAoptionPremMille != null) { cmd.Parameters.Add("@_cGLAoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAoptionPremMille); }
                if (lcat.cGLAoptionPremRate != null) { cmd.Parameters.Add("@_cGLAoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAoptionPremRate); }
                if (lcat.cGLAtibPremMille != null) { cmd.Parameters.Add("@_cGLAtibPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAtibPremMille); }
                if (lcat.cGLAtibPremRate != null) { cmd.Parameters.Add("@_cGLAtibPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAtibPremRate); }
                if (lcat.cPTDoptionPremMille != null) { cmd.Parameters.Add("@_cPTDoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPTDoptionPremMille); }
                if (lcat.cPTDoptionPremRate != null) { cmd.Parameters.Add("@_cPTDoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPTDoptionPremRate); }
                if (lcat.cIncDisBindPremMille != null) { cmd.Parameters.Add("@_cIncDisBindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cIncDisBindPremMille); }
                if (lcat.cIncDisBindPremRate != null) { cmd.Parameters.Add("@_cIncDisBindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cIncDisBindPremRate); }
                if (lcat.cIncDisCommPremMille != null) { cmd.Parameters.Add("@_cIncDisCommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cIncDisCommPremMille); }
                if (lcat.cIncDisCommPremRate != null) { cmd.Parameters.Add("@_cIncDisCommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cIncDisCommPremRate); }
                if (lcat.cIncDisOutsPremMille != null) { cmd.Parameters.Add("@_cIncDisOutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cIncDisOutsPremMille); }
                if (lcat.cIncDisOutsPremRate != null) { cmd.Parameters.Add("@_cIncDisOutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cIncDisOutsPremRate); }
                if (lcat.cLifeBindPremMille != null) { cmd.Parameters.Add("@_cLifeBindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cLifeBindPremMille); }
                if (lcat.cLifeBindPremRate != null) { cmd.Parameters.Add("@_cLifeBindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cLifeBindPremRate); }
                if (lcat.cLifeCommPremMille != null) { cmd.Parameters.Add("@_cLifeCommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cLifeCommPremMille); }
                if (lcat.cLifeCommPremRate != null) { cmd.Parameters.Add("@_cLifeCommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cLifeCommPremRate); }
                if (lcat.cLifeOutsPremMille != null) { cmd.Parameters.Add("@_cLifeOutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cLifeOutsPremMille); }
                if (lcat.cLifeOutsPremRate != null) { cmd.Parameters.Add("@_cLifeOutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cLifeOutsPremRate); }
                if (lcat.cMAPWgrossPremMille != null) { cmd.Parameters.Add("@_cMAPWgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMAPWgrossPremMille); }
                if (lcat.cMAPWgrossPremRate != null) { cmd.Parameters.Add("@_cMAPWgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMAPWgrossPremRate); }
                if (lcat.cOutsourceAmtFUN != null) { cmd.Parameters.Add("@_cOutsourceAmtFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cOutsourceAmtFUN); }
                if (lcat.cOutsourceAmtIncDis != null) { cmd.Parameters.Add("@_cOutsourceAmtIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cOutsourceAmtIncDis); }
                if (lcat.cOutsourceAmtLife != null) { cmd.Parameters.Add("@_cOutsourceAmtLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cOutsourceAmtLife); }
                if (lcat.cOutsourceAmtSpouses != null) { cmd.Parameters.Add("@_cOutsourceAmtSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cOutsourceAmtSpouses); }
                if (lcat.cOutsourceAmtTotal != null) { cmd.Parameters.Add("@_cOutsourceAmtTotal", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cOutsourceAmtTotal); }
                if (lcat.cOutsourceAmtCII != null) { cmd.Parameters.Add("@_cOutsourceAmtCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cOutsourceAmtCII); }
                if (lcat.cPHIgrowthPremMille != null) { cmd.Parameters.Add("@_cPHIgrowthPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIgrowthPremMille); }
                if (lcat.cPHIgrowthPremRate != null) { cmd.Parameters.Add("@_cPHIgrowthPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIgrowthPremRate); }
                if (lcat.cPHIinsPremMille != null) { cmd.Parameters.Add("@_cPHIinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIinsPremMille); }
                if (lcat.cPHIinsPremRate != null) { cmd.Parameters.Add("@_cPHIinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIinsPremRate); }
                if (lcat.cPHIinsWaiverPremMille != null) { cmd.Parameters.Add("@_cPHIinsWaiverPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIinsWaiverPremMille); }
                if (lcat.cPHIinsWaiverPremRate != null) { cmd.Parameters.Add("@_cPHIinsWaiverPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIinsWaiverPremRate); }
                if (lcat.cPHIoptionPremMille != null) { cmd.Parameters.Add("@_cPHIoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIoptionPremMille); }
                if (lcat.cPHIoptionPremRate != null) { cmd.Parameters.Add("@_cPHIoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIoptionPremRate); }
                if (lcat.cSpousesBindPremMille != null) { cmd.Parameters.Add("@_cSpousesBindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSpousesBindPremMille); }
                if (lcat.cSpousesBindPremRate != null) { cmd.Parameters.Add("@_cSpousesBindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSpousesBindPremRate); }
                if (lcat.cSpousesCommPremMille != null) { cmd.Parameters.Add("@_cSpousesCommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSpousesCommPremMille); }
                if (lcat.cSpousesCommPremRate != null) { cmd.Parameters.Add("@_cSpousesCommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSpousesCommPremRate); }
                if (lcat.cSGLAoptionPremMille != null) { cmd.Parameters.Add("@_cSGLAoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSGLAoptionPremMille); }
                if (lcat.cSGLAoptionPremRate != null) { cmd.Parameters.Add("@_cSGLAoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSGLAoptionPremRate); }
                if (lcat.cSPTDoptionPremMille != null) { cmd.Parameters.Add("@_cSPTDoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSPTDoptionPremMille); }
                if (lcat.cSPTDoptionPremRate != null) { cmd.Parameters.Add("@_cSPTDoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSPTDoptionPremRate); }
                if (lcat.cSpousesOutsPremMille != null) { cmd.Parameters.Add("@_cSpousesOutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSpousesOutsPremMille); }
                if (lcat.cSpousesOutsPremRate != null) { cmd.Parameters.Add("@_cSpousesOutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSpousesOutsPremRate); }
                if (lcat.cSRgrossPremMille != null) { cmd.Parameters.Add("@_cSRgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSRgrossPremMille); }
                if (lcat.cSRgrossPremRate != null) { cmd.Parameters.Add("@_cSRgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSRgrossPremRate); }
                if (lcat.cTopUpGrowthPremMille != null) { cmd.Parameters.Add("@_cTopUpGrowthPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTopUpGrowthPremMille); }
                if (lcat.cTopUpGrowthPremRate != null) { cmd.Parameters.Add("@_cTopUpGrowthPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTopUpGrowthPremRate); }
                if (lcat.cTotAccBenGrossPrem != null) { cmd.Parameters.Add("@_cTotAccBenGrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAccBenGrossPrem); }
                if (lcat.cTotAnnualSalary != null) { cmd.Parameters.Add("@_cTotAnnualSalary", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAnnualSalary); }
                if (lcat.cTotCountCII != null) { cmd.Parameters.Add("@_cTotCountCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCountCII); }
                if (lcat.cTotCoverFUN != null) { cmd.Parameters.Add("@_cTotCoverFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverFUN); }
                if (lcat.cTotCoverGLA != null) { cmd.Parameters.Add("@_cTotCoverGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverGLA); }
                if (lcat.cTotCoverPTD != null) { cmd.Parameters.Add("@_cTotCoverPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverPTD); }
                if (lcat.cTotCoverPHI != null) { cmd.Parameters.Add("@_cTotCoverPHI", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverPHI); }
                if (lcat.cTotCoverPHIincWaiver != null) { cmd.Parameters.Add("@_cTotCoverPHIincWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverPHIincWaiver); }
                if (lcat.cTotCoverSPTD != null) { cmd.Parameters.Add("@_cTotCoverSPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverSPTD); }
                if (lcat.cTotFUNpremExCommBind != null) { cmd.Parameters.Add("@_cTotFUNpremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNpremExCommBind); }
                if (lcat.cTotFUNpremIncCommBind != null) { cmd.Parameters.Add("@_cTotFUNpremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNpremIncCommBind); }
                if (lcat.cTotFUNpremPA != null) { cmd.Parameters.Add("@_cTotFUNpremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNpremPA); }
                if (lcat.cTotGLAgicPrem != null) { cmd.Parameters.Add("@_cTotGLAgicPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAgicPrem); }
                if (lcat.cTotGLAcocPrem != null) { cmd.Parameters.Add("@_cTotGLAcocPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAcocPrem); }
                if (lcat.cTotGLAinsPrem != null) { cmd.Parameters.Add("@_cTotGLAinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAinsPrem); }
                if (lcat.cTotPTDgrossPrem != null) { cmd.Parameters.Add("@_cTotPTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPTDgrossPrem); }
                if (lcat.cTotPTDoptionPrem != null) { cmd.Parameters.Add("@_cTotPTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPTDoptionPrem); }
                if (lcat.cTotIncDisPremExCommBind != null) { cmd.Parameters.Add("@_cTotIncDisPremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotIncDisPremExCommBind); }
                if (lcat.cTotIncDisPremIncCommBind != null) { cmd.Parameters.Add("@_cTotIncDisPremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotIncDisPremIncCommBind); }
                if (lcat.cTotIncDisPremPA != null) { cmd.Parameters.Add("@_cTotIncDisPremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotIncDisPremPA); }
                if (lcat.cTotLifePremExCommBind != null) { cmd.Parameters.Add("@_cTotLifePremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotLifePremExCommBind); }
                if (lcat.cTotLifePremIncCommBind != null) { cmd.Parameters.Add("@_cTotLifePremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotLifePremIncCommBind); }
                if (lcat.cTotLifePremPA != null) { cmd.Parameters.Add("@_cTotLifePremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotLifePremPA); }
                if (lcat.cTotMAPWgrossPrem != null) { cmd.Parameters.Add("@_cTotMAPWgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotMAPWgrossPrem); }
                if (lcat.cTotNumberMembers != null) { cmd.Parameters.Add("@_cTotNumberMembers", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotNumberMembers); }
                if (lcat.cTotNumberSpouses != null) { cmd.Parameters.Add("@_cTotNumberSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotNumberSpouses); }
                if (lcat.cTotPHIinsPrem != null) { cmd.Parameters.Add("@_cTotPHIinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIinsPrem); }
                if (lcat.cTotPHIinsPremWaiver != null) { cmd.Parameters.Add("@_cTotPHIinsPremWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIinsPremWaiver); }
                if (lcat.cTotPremIncCommBind != null) { cmd.Parameters.Add("@_cTotPremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremIncCommBind); }
                if (lcat.cTotSGLAgrossPrem != null) { cmd.Parameters.Add("@_cTotSGLAgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSGLAgrossPrem); }
                if (lcat.cTotSGLAoptionPrem != null) { cmd.Parameters.Add("@_cTotSGLAoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSGLAoptionPrem); }
                if (lcat.cTotSPTDgrossPrem != null) { cmd.Parameters.Add("@_cTotSPTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSPTDgrossPrem); }
                if (lcat.cTotSPTDoptionPrem != null) { cmd.Parameters.Add("@_cTotSPTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSPTDoptionPrem); }
                if (lcat.cTotSpousesPremExCommBind != null) { cmd.Parameters.Add("@_cTotSpousesPremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSpousesPremExCommBind); }
                if (lcat.cTotSpousesPremIncCommBind != null) { cmd.Parameters.Add("@_cTotSpousesPremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSpousesPremIncCommBind); }
                if (lcat.cTotSpousesPremPA != null) { cmd.Parameters.Add("@_cTotSpousesPremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSpousesPremPA); }
                if (lcat.cTotSRgrossPrem != null) { cmd.Parameters.Add("@_cTotSRgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSRgrossPrem); }
                if (lcat.cTotTopUpGrossPrem != null) { cmd.Parameters.Add("@_cTotTopUpGrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTopUpGrossPrem); }
                if (lcat.cTotTopUpGrowthPrem != null) { cmd.Parameters.Add("@_cTotTopUpGrowthPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTopUpGrowthPrem); }
                if (lcat.cTotCIIgicPrem != null) { cmd.Parameters.Add("@_cTotCIIgicPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIgicPrem); }
                if (lcat.cTotCIIcocPrem != null) { cmd.Parameters.Add("@_cTotCIIcocPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIcocPrem); }
                if (lcat.cTotCIIpremExCommBind != null) { cmd.Parameters.Add("@_cTotCIIpremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIpremExCommBind); }
                if (lcat.cTotCIIpremIncCommBind != null) { cmd.Parameters.Add("@_cTotCIIpremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIpremIncCommBind); }
                if (lcat.cTotCIIpremPA != null) { cmd.Parameters.Add("@_cTotCIIpremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIpremPA); }
                if (lcat.cTotUEPgrossPrem != null) { cmd.Parameters.Add("@_cTotUEPgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotUEPgrossPrem); }
                if (lcat.cCIIcommPremRate != null) { cmd.Parameters.Add("@_cCIIcommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIcommPremRate); }
                if (lcat.cCIIgicPremMille != null) { cmd.Parameters.Add("@_cCIIgicPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIgicPremMille); }
                if (lcat.cCIIoptionPremMille != null) { cmd.Parameters.Add("@_cCIIoptionPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIoptionPremMille); }
                if (lcat.cUEPgrossPremMille != null) { cmd.Parameters.Add("@_cUEPgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cUEPgrossPremMille); }
                if (lcat.cUEPgrossPremRate != null) { cmd.Parameters.Add("@_cUEPgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cUEPgrossPremRate); }
                if (lcat.cGLAtrcPremRate != null) { cmd.Parameters.Add("@_cGLAtrcPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAtrcPremRate); }
                if (lcat.cTotGLAtrcPrem != null) { cmd.Parameters.Add("@_cTotGLAtrcPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAtrcPrem); }
                if (lcat.cSPTDinsPremMille != null) { cmd.Parameters.Add("@_cSPTDinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSPTDinsPremMille); }
                if (lcat.cSPTDinsPremRate != null) { cmd.Parameters.Add("@_cSPTDinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSPTDinsPremRate); }
                if (lcat.cTIncDisOutsPremMille != null) { cmd.Parameters.Add("@_cTIncDisOutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTIncDisOutsPremMille); }
                if (lcat.cTIncDisOutsPremRate != null) { cmd.Parameters.Add("@_cTIncDisOutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTIncDisOutsPremRate); }
                if (lcat.cTopUpInsPremMille != null) { cmd.Parameters.Add("@_cTopUpInsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTopUpInsPremMille); }
                if (lcat.cTopUpInsPremRate != null) { cmd.Parameters.Add("@_cTopUpInsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTopUpInsPremRate); }
                if (lcat.cTotCoverTTD != null) { cmd.Parameters.Add("@_cTotCoverTTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverTTD); }
                if (lcat.cTotCoverTTDincWaiver != null) { cmd.Parameters.Add("@_cTotCoverTTDincWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverTTDincWaiver); }
                if (lcat.cTotCoverTTDwaiver != null) { cmd.Parameters.Add("@_cTotCoverTTDwaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverTTDwaiver); }
                if (lcat.cTotPremCIImille != null) { cmd.Parameters.Add("@_cTotPremCIImille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremCIImille); }
                if (lcat.cTotPremCIIrate != null) { cmd.Parameters.Add("@_cTotPremCIIrate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremCIIrate); }
                if (lcat.cTotPremFUNmille != null) { cmd.Parameters.Add("@_cTotPremFUNmille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremFUNmille); }
                if (lcat.cTotPremFUNrate != null) { cmd.Parameters.Add("@_cTotPremFUNrate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremFUNrate); }
                if (lcat.cTotPremIncDisMille != null) { cmd.Parameters.Add("@_cTotPremIncDisMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremIncDisMille); }
                if (lcat.cTotPremIncDisRate != null) { cmd.Parameters.Add("@_cTotPremIncDisRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremIncDisRate); }
                if (lcat.cTotPremLifeMille != null) { cmd.Parameters.Add("@_cTotPremLifeMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremLifeMille); }
                if (lcat.cTotPremLifeRate != null) { cmd.Parameters.Add("@_cTotPremLifeRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremLifeRate); }
                if (lcat.cTotPremRate != null) { cmd.Parameters.Add("@_cTotPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremRate); }
                if (lcat.cTotPremSpousesMille != null) { cmd.Parameters.Add("@_cTotPremSpousesMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremSpousesMille); }
                if (lcat.cTotPremSpousesRate != null) { cmd.Parameters.Add("@_cTotPremSpousesRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremSpousesRate); }
                if (lcat.cTotPremTIncDisMille != null) { cmd.Parameters.Add("@_cTotPremTIncDisMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremTIncDisMille); }
                if (lcat.cTotPremTIncDisRate != null) { cmd.Parameters.Add("@_cTotPremTIncDisRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPremTIncDisRate); }
                if (lcat.cTotSPTDinsPrem != null) { cmd.Parameters.Add("@_cTotSPTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSPTDinsPrem); }
                if (lcat.cTotTIncDisPremExCommBind != null) { cmd.Parameters.Add("@_cTotTIncDisPremExCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTIncDisPremExCommBind); }
                if (lcat.cTotTIncDisPremIncCommBind != null) { cmd.Parameters.Add("@_cTotTIncDisPremIncCommBind", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTIncDisPremIncCommBind); }
                if (lcat.cTotTIncDisPremPA != null) { cmd.Parameters.Add("@_cTotTIncDisPremPA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTIncDisPremPA); }
                if (lcat.cTotTopUpInsPrem != null) { cmd.Parameters.Add("@_cTotTopUpInsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTopUpInsPrem); }
                if (lcat.cTotTTDinsPrem != null) { cmd.Parameters.Add("@_cTotTTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTTDinsPrem); }
                //if (lcat.cTTDgrossPremMille != null) { cmd.Parameters.Add("@_cTTDgrossPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDgrossPremMille); }
                //if (lcat.cTTDgrossPremRate != null) { cmd.Parameters.Add("@_cTTDgrossPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDgrossPremRate); }
                if (lcat.cTTDinsPremMille != null) { cmd.Parameters.Add("@_cTTDinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDinsPremMille); }
                if (lcat.cTTDinsPremRate != null) { cmd.Parameters.Add("@_cTTDinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDinsPremRate); }
                if (lcat.cTTDinsWaiverPremMille != null) { cmd.Parameters.Add("@_cTTDinsWaiverPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDinsWaiverPremMille); }
                if (lcat.cTTDinsWaiverPremRate != null) { cmd.Parameters.Add("@_cTTDinsWaiverPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDinsWaiverPremRate); }
                if (lcat.cGLAinsPremMille_if != null) { cmd.Parameters.Add("@_cGLAinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAinsPremMille_if); }
                if (lcat.cGLAinsPremRate_if != null) { cmd.Parameters.Add("@_cGLAinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAinsPremRate_if); }
                if (lcat.cGLAoptionPremMille_if != null) { cmd.Parameters.Add("@_cGLAoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAoptionPremMille_if); }
                if (lcat.cGLAoptionPremRate_if != null) { cmd.Parameters.Add("@_cGLAoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAoptionPremRate_if); }
                if (lcat.cGLAtibPremMille_if != null) { cmd.Parameters.Add("@_cGLAtibPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAtibPremMille_if); }
                if (lcat.cGLAtibPremRate_if != null) { cmd.Parameters.Add("@_cGLAtibPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAtibPremRate_if); }
                if (lcat.cGLAtrcPremMille_if != null) { cmd.Parameters.Add("@_cGLAtrcPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAtrcPremMille_if); }
                if (lcat.cGLAtrcPremRate_if != null) { cmd.Parameters.Add("@_cGLAtrcPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAtrcPremRate_if); }
                if (lcat.cMAPWgrossPremMille_if != null) { cmd.Parameters.Add("@_cMAPWgrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMAPWgrossPremMille_if); }
                if (lcat.cMAPWgrossPremRate_if != null) { cmd.Parameters.Add("@_cMAPWgrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMAPWgrossPremRate_if); }
                if (lcat.cMaxAgeCII != null) { cmd.Parameters.Add("@_cMaxAgeCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMaxAgeCII); }
                if (lcat.cMaxAgeFUN != null) { cmd.Parameters.Add("@_cMaxAgeFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMaxAgeFUN); }
                if (lcat.cMaxAgeGLA != null) { cmd.Parameters.Add("@_cMaxAgeGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMaxAgeGLA); }
                if (lcat.cMaxAgePHITTD != null) { cmd.Parameters.Add("@_cMaxAgePHITTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMaxAgePHITTD); }
                if (lcat.cMaxAgePTD != null) { cmd.Parameters.Add("@_cMaxAgePTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMaxAgePTD); }
                if (lcat.cMaxAgeSGLA != null) { cmd.Parameters.Add("@_cMaxAgeSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMaxAgeSGLA); }
                if (lcat.cMaxAgeSPTD != null) { cmd.Parameters.Add("@_cMaxAgeSPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cMaxAgeSPTD); }
                if (lcat.cPHIgrowthPremMille_if != null) { cmd.Parameters.Add("@_cPHIgrowthPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIgrowthPremMille_if); }
                if (lcat.cPHIgrowthPremRate_if != null) { cmd.Parameters.Add("@_cPHIgrowthPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIgrowthPremRate_if); }
                if (lcat.cPHIinsPremMille_if != null) { cmd.Parameters.Add("@_cPHIinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIinsPremMille_if); }
                if (lcat.cPHIinsPremRate_if != null) { cmd.Parameters.Add("@_cPHIinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIinsPremRate_if); }
                if (lcat.cPHIinsWaiverPremMille_if != null) { cmd.Parameters.Add("@_cPHIinsWaiverPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIinsWaiverPremMille_if); }
                if (lcat.cPHIinsWaiverPremRate_if != null) { cmd.Parameters.Add("@_cPHIinsWaiverPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIinsWaiverPremRate_if); }
                if (lcat.cPHIoptionPremMille_if != null) { cmd.Parameters.Add("@_cPHIoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIoptionPremMille_if); }
                if (lcat.cPHIoptionPremRate_if != null) { cmd.Parameters.Add("@_cPHIoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPHIoptionPremRate_if); }
                if (lcat.cPTDinsPremMille_if != null) { cmd.Parameters.Add("@_cPTDinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPTDinsPremMille_if); }
                if (lcat.cPTDinsPremRate_if != null) { cmd.Parameters.Add("@_cPTDinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPTDinsPremRate_if); }
                if (lcat.cPTDoptionPremMille_if != null) { cmd.Parameters.Add("@_cPTDoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPTDoptionPremMille_if); }
                if (lcat.cPTDoptionPremRate_if != null) { cmd.Parameters.Add("@_cPTDoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPTDoptionPremRate_if); }
                if (lcat.cSGLAinsPremMille_if != null) { cmd.Parameters.Add("@_cSGLAinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSGLAinsPremMille_if); }
                if (lcat.cSGLAinsPremRate_if != null) { cmd.Parameters.Add("@_cSGLAinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSGLAinsPremRate_if); }
                if (lcat.cSGLAoptionPremMille_if != null) { cmd.Parameters.Add("@_cSGLAoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSGLAoptionPremMille_if); }
                if (lcat.cSGLAoptionPremRate_if != null) { cmd.Parameters.Add("@_cSGLAoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSGLAoptionPremRate_if); }
                if (lcat.cSPTDinsPremMille_if != null) { cmd.Parameters.Add("@_cSPTDinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSPTDinsPremMille_if); }
                if (lcat.cSPTDinsPremRate_if != null) { cmd.Parameters.Add("@_cSPTDinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSPTDinsPremRate_if); }
                if (lcat.cSPTDoptionPremMille_if != null) { cmd.Parameters.Add("@_cSPTDoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSPTDoptionPremMille_if); }
                if (lcat.cSPTDoptionPremRate_if != null) { cmd.Parameters.Add("@_cSPTDoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSPTDoptionPremRate_if); }
                if (lcat.cSRgrossPremMille_if != null) { cmd.Parameters.Add("@_cSRgrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSRgrossPremMille_if); }
                if (lcat.cSRgrossPremRate_if != null) { cmd.Parameters.Add("@_cSRgrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSRgrossPremRate_if); }
                if (lcat.cTopUpGrowthPremMille_if != null) { cmd.Parameters.Add("@_cTopUpGrowthPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTopUpGrowthPremMille_if); }
                if (lcat.cTopUpGrowthPremRate_if != null) { cmd.Parameters.Add("@_cTopUpGrowthPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTopUpGrowthPremRate_if); }
                if (lcat.cTopUpInsPremMille_if != null) { cmd.Parameters.Add("@_cTopUpInsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTopUpInsPremMille_if); }
                if (lcat.cTopUpInsPremRate_if != null) { cmd.Parameters.Add("@_cTopUpInsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTopUpInsPremRate_if); }
                if (lcat.cTotAccBenGrossPrem_if != null) { cmd.Parameters.Add("@_cTotAccBenGrossPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAccBenGrossPrem_if); }
                if (lcat.cTotCIIcocPrem_if != null) { cmd.Parameters.Add("@_cTotCIIcocPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIcocPrem_if); }
                if (lcat.cTotCIIgicPrem_if != null) { cmd.Parameters.Add("@_cTotCIIgicPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIgicPrem_if); }
                if (lcat.cTotCIIgrossPrem != null) { cmd.Parameters.Add("@_cTotCIIgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIgrossPrem); }
                if (lcat.cTotCIIinsPrem_if != null) { cmd.Parameters.Add("@_cTotCIIinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIinsPrem_if); }
                if (lcat.cTotCIIoptionPrem_if != null) { cmd.Parameters.Add("@_cTotCIIoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIoptionPrem_if); }
                if (lcat.cTotFUNinsPrem_if != null) { cmd.Parameters.Add("@_cTotFUNinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNinsPrem_if); }
                if (lcat.cTotFUNpremPMPM != null) { cmd.Parameters.Add("@_cTotFUNpremPMPM", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNpremPMPM); }
                if (lcat.cTotFUNtransportPrem_if != null) { cmd.Parameters.Add("@_cTotFUNtransportPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNtransportPrem_if); }
                if (lcat.cTotGLAcocPrem_if != null) { cmd.Parameters.Add("@_cTotGLAcocPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAcocPrem_if); }
                if (lcat.cTotGLAgicPrem_if != null) { cmd.Parameters.Add("@_cTotGLAgicPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAgicPrem_if); }
                if (lcat.cTotGLAinsPrem_if != null) { cmd.Parameters.Add("@_cTotGLAinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAinsPrem_if); }
                if (lcat.cTotGLAoptionPrem_if != null) { cmd.Parameters.Add("@_cTotGLAoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAoptionPrem_if); }
                if (lcat.cTotGLAtibPrem_if != null) { cmd.Parameters.Add("@_cTotGLAtibPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAtibPrem_if); }
                if (lcat.cTotGLAtrcPrem_if != null) { cmd.Parameters.Add("@_cTotGLAtrcPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAtrcPrem_if); }
                if (lcat.cTotMAPWgrossPrem_if != null) { cmd.Parameters.Add("@_cTotMAPWgrossPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotMAPWgrossPrem_if); }
                if (lcat.cTotPHIgrowthPrem_if != null) { cmd.Parameters.Add("@_cTotPHIgrowthPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIgrowthPrem_if); }
                if (lcat.cTotPHIinsPrem_if != null) { cmd.Parameters.Add("@_cTotPHIinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIinsPrem_if); }
                if (lcat.cTotPHIinsPremWaiver_if != null) { cmd.Parameters.Add("@_cTotPHIinsPremWaiver_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIinsPremWaiver_if); }
                if (lcat.cTotPHIoptionPrem_if != null) { cmd.Parameters.Add("@_cTotPHIoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIoptionPrem_if); }
                if (lcat.cTotPTDinsPrem_if != null) { cmd.Parameters.Add("@_cTotPTDinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPTDinsPrem_if); }
                if (lcat.cTotPTDoptionPrem_if != null) { cmd.Parameters.Add("@_cTotPTDoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPTDoptionPrem_if); }
                if (lcat.cTotSGLAinsPrem != null) { cmd.Parameters.Add("@_cTotSGLAinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSGLAinsPrem); }
                if (lcat.cTotSGLAinsPrem_if != null) { cmd.Parameters.Add("@_cTotSGLAinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSGLAinsPrem_if); }
                if (lcat.cTotSGLAoptionPrem_if != null) { cmd.Parameters.Add("@_cTotSGLAoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSGLAoptionPrem_if); }
                if (lcat.cTotSPTDinsPrem_if != null) { cmd.Parameters.Add("@_cTotSPTDinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSPTDinsPrem_if); }
                if (lcat.cTotSPTDoptionPrem_if != null) { cmd.Parameters.Add("@_cTotSPTDoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSPTDoptionPrem_if); }
                if (lcat.cTotSRgrossPrem_if != null) { cmd.Parameters.Add("@_cTotSRgrossPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotSRgrossPrem_if); }
                if (lcat.cTotTopUpGrowthPrem_if != null) { cmd.Parameters.Add("@_cTotTopUpGrowthPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTopUpGrowthPrem_if); }
                if (lcat.cTotTopUpInsPrem_if != null) { cmd.Parameters.Add("@_cTotTopUpInsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTopUpInsPrem_if); }
                if (lcat.cTotTTDinsPrem_if != null) { cmd.Parameters.Add("@_cTotTTDinsPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTTDinsPrem_if); }
                if (lcat.cTotTTDinsPremWaiver_if != null) { cmd.Parameters.Add("@_cTotTTDinsPremWaiver_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTTDinsPremWaiver_if); }
                if (lcat.cTotTTDoptionPrem_if != null) { cmd.Parameters.Add("@_cTotTTDoptionPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTTDoptionPrem_if); }
                if (lcat.cTotUEPgrossPrem_if != null) { cmd.Parameters.Add("@_cTotUEPgrossPrem_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotUEPgrossPrem_if); }
                if (lcat.cTTDinsPremMille_if != null) { cmd.Parameters.Add("@_cTTDinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDinsPremMille_if); }
                if (lcat.cTTDinsPremRate_if != null) { cmd.Parameters.Add("@_cTTDinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDinsPremRate_if); }
                if (lcat.cTTDinsWaiverPremMille_if != null) { cmd.Parameters.Add("@_cTTDinsWaiverPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDinsWaiverPremMille_if); }
                if (lcat.cTTDinsWaiverPremRate_if != null) { cmd.Parameters.Add("@_cTTDinsWaiverPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTTDinsWaiverPremRate_if); }
                if (lcat.cUEPgrossPremMille_if != null) { cmd.Parameters.Add("@_cUEPgrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cUEPgrossPremMille_if); }
                if (lcat.cUEPgrossPremRate_if != null) { cmd.Parameters.Add("@_cUEPgrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cUEPgrossPremRate_if); }
                if (lcat.cTotCIIinsPrem != null) { cmd.Parameters.Add("@_cTotCIIinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIinsPrem); }
                if (lcat.cTotCountFUN != null) { cmd.Parameters.Add("@_cTotCountFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCountFUN); }
                if (lcat.cTotCountGLA != null) { cmd.Parameters.Add("@_cTotCountGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCountGLA); }
                if (lcat.cTotCountPTD != null) { cmd.Parameters.Add("@_cTotCountPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCountPTD); }
                if (lcat.cTotCountSGLA != null) { cmd.Parameters.Add("@_cTotCountSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCountSGLA); }
                if (lcat.cTotCountSPTD != null) { cmd.Parameters.Add("@_cTotCountSPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCountSPTD); }
                if (lcat.cTotCoverPHIwaiver != null) { cmd.Parameters.Add("@_cTotCoverPHIwaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverPHIwaiver); }
                if (lcat.cTotCoverSGLA != null) { cmd.Parameters.Add("@_cTotCoverSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverSGLA); }
                if (lcat.cTotGLAgrossPrem != null) { cmd.Parameters.Add("@_cTotGLAgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAgrossPrem); }
                if (lcat.cTotPHIgrowthPrem != null) { cmd.Parameters.Add("@_cTotPHIgrowthPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIgrowthPrem); }
                if (lcat.cTotPTDinsPrem != null) { cmd.Parameters.Add("@_cTotPTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPTDinsPrem); }
                if (lcat.cTotTTDgrossPrem != null) { cmd.Parameters.Add("@_cTotTTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTTDgrossPrem); }
                if (lcat.cTotTTDoptionPrem != null) { cmd.Parameters.Add("@_cTotTTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotTTDoptionPrem); }
                if (lcat.cTotAnnSalLife != null) { cmd.Parameters.Add("@_cTotAnnSalLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAnnSalLife); }
                if (lcat.cTotAnnSalCII != null) { cmd.Parameters.Add("@_cTotAnnSalCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAnnSalCII); }
                if (lcat.cTotAnnSalFUN != null) { cmd.Parameters.Add("@_cTotAnnSalFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAnnSalFUN); }
                if (lcat.cTotAnnSalSpouses != null) { cmd.Parameters.Add("@_cTotAnnSalSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAnnSalSpouses); }
                if (lcat.cTotAnnSalIncDis != null) { cmd.Parameters.Add("@_cTotAnnSalIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAnnSalIncDis); }
                if (lcat.cTotAnnSalTIncDis != null) { cmd.Parameters.Add("@_cTotAnnSalTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotAnnSalTIncDis); }
                if (lcat.cTotGLAoptionPrem != null) { cmd.Parameters.Add("@_cTotGLAoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAoptionPrem); }
                if (lcat.cPTDinsPremRate != null) { cmd.Parameters.Add("@_cPTDinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPTDinsPremRate); }
                if (lcat.cTotGLAtibPrem != null) { cmd.Parameters.Add("@_cTotGLAtibPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotGLAtibPrem); }
                if (lcat.cGLAtrcPremMille != null) { cmd.Parameters.Add("@_cGLAtrcPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAtrcPremMille); }
                if (lcat.cPTDinsPremMille != null) { cmd.Parameters.Add("@_cPTDinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cPTDinsPremMille); }
                if (lcat.cTotCoverCII != null) { cmd.Parameters.Add("@_cTotCoverCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCoverCII); }
                if (lcat.cAccBenGrossPremMille_if != null) { cmd.Parameters.Add("@_cAccBenGrossPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cAccBenGrossPremMille_if); }
                if (lcat.cAccBenGrossPremRate_if != null) { cmd.Parameters.Add("@_cAccBenGrossPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cAccBenGrossPremRate_if); }
                if (lcat.cBinderAmtTIncDis != null) { cmd.Parameters.Add("@_cBinderAmtTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cBinderAmtTIncDis); }
                if (lcat.cCIIbindPremMille != null) { cmd.Parameters.Add("@_cCIIbindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIbindPremMille); }
                if (lcat.cCIIbindPremRate != null) { cmd.Parameters.Add("@_cCIIbindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIbindPremRate); }
                if (lcat.cCIIcocPremMille != null) { cmd.Parameters.Add("@_cCIIcocPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIcocPremMille); }
                if (lcat.cCIIcocPremMille_if != null) { cmd.Parameters.Add("@_cCIIcocPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIcocPremMille_if); }
                if (lcat.cCIIcocPremRate != null) { cmd.Parameters.Add("@_cCIIcocPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIcocPremRate); }
                if (lcat.cCIIcocPremRate_if != null) { cmd.Parameters.Add("@_cCIIcocPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIcocPremRate_if); }
                if (lcat.cCIIcommPremMille != null) { cmd.Parameters.Add("@_cCIIcommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIcommPremMille); }
                if (lcat.cCIIgicPremMille_if != null) { cmd.Parameters.Add("@_cCIIgicPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIgicPremMille_if); }
                if (lcat.cCIIgicPremRate != null) { cmd.Parameters.Add("@_cCIIgicPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIgicPremRate); }
                if (lcat.cCIIgicPremRate_if != null) { cmd.Parameters.Add("@_cCIIgicPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIgicPremRate_if); }
                if (lcat.cCIIinsPremMille != null) { cmd.Parameters.Add("@_cCIIinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIinsPremMille); }
                if (lcat.cCIIinsPremMille_if != null) { cmd.Parameters.Add("@_cCIIinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIinsPremMille_if); }
                if (lcat.cCIIinsPremRate != null) { cmd.Parameters.Add("@_cCIIinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIinsPremRate); }
                if (lcat.cCIIinsPremRate_if != null) { cmd.Parameters.Add("@_cCIIinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIinsPremRate_if); }
                if (lcat.cCIIoptionPremMille_if != null) { cmd.Parameters.Add("@_cCIIoptionPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIoptionPremMille_if); }
                if (lcat.cCIIoptionPremRate != null) { cmd.Parameters.Add("@_cCIIoptionPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIoptionPremRate); }
                if (lcat.cCIIoptionPremRate_if != null) { cmd.Parameters.Add("@_cCIIoptionPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIoptionPremRate_if); }
                if (lcat.cCIIoutsPremMille != null) { cmd.Parameters.Add("@_cCIIoutsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIoutsPremMille); }
                if (lcat.cCIIoutsPremRate != null) { cmd.Parameters.Add("@_cCIIoutsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCIIoutsPremRate); }
                if (lcat.cCommAmtTIncDis != null) { cmd.Parameters.Add("@_cCommAmtTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cCommAmtTIncDis); }
                if (lcat.cFUNinsPremMille != null) { cmd.Parameters.Add("@_cFUNinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNinsPremMille); }
                if (lcat.cFUNinsPremMille_if != null) { cmd.Parameters.Add("@_cFUNinsPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNinsPremMille_if); }
                if (lcat.cFUNinsPremRate != null) { cmd.Parameters.Add("@_cFUNinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNinsPremRate); }
                if (lcat.cFUNinsPremRate_if != null) { cmd.Parameters.Add("@_cFUNinsPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNinsPremRate_if); }
                if (lcat.cFUNtransportPremMille != null) { cmd.Parameters.Add("@_cFUNtransportPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNtransportPremMille); }
                if (lcat.cFUNtransportPremMille_if != null) { cmd.Parameters.Add("@_cFUNtransportPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNtransportPremMille_if); }
                if (lcat.cFUNtransportPremRate != null) { cmd.Parameters.Add("@_cFUNtransportPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNtransportPremRate); }
                if (lcat.cFUNtransportPremRate_if != null) { cmd.Parameters.Add("@_cFUNtransportPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cFUNtransportPremRate_if); }
                if (lcat.cGLAcocPremMille_if != null) { cmd.Parameters.Add("@_cGLAcocPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAcocPremMille_if); }
                if (lcat.cGLAcocPremRate_if != null) { cmd.Parameters.Add("@_cGLAcocPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAcocPremRate_if); }
                if (lcat.cGLAgicPremMille_if != null) { cmd.Parameters.Add("@_cGLAgicPremMille_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAgicPremMille_if); }
                if (lcat.cGLAgicPremRate_if != null) { cmd.Parameters.Add("@_cGLAgicPremRate_if", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cGLAgicPremRate_if); }
                if (lcat.cOutsourceAmtTIncDis != null) { cmd.Parameters.Add("@_cOutsourceAmtTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cOutsourceAmtTIncDis); }
                if (lcat.cSGLAinsPremMille != null) { cmd.Parameters.Add("@_cSGLAinsPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSGLAinsPremMille); }
                if (lcat.cSGLAinsPremRate != null) { cmd.Parameters.Add("@_cSGLAinsPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cSGLAinsPremRate); }
                if (lcat.cTIncDisBindPremMille != null) { cmd.Parameters.Add("@_cTIncDisBindPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTIncDisBindPremMille); }
                if (lcat.cTIncDisBindPremRate != null) { cmd.Parameters.Add("@_cTIncDisBindPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTIncDisBindPremRate); }
                if (lcat.cTIncDisCommPremMille != null) { cmd.Parameters.Add("@_cTIncDisCommPremMille", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTIncDisCommPremMille); }
                if (lcat.cTIncDisCommPremRate != null) { cmd.Parameters.Add("@_cTIncDisCommPremRate", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTIncDisCommPremRate); }
                if (lcat.cTotCIIoptionPrem != null) { cmd.Parameters.Add("@_cTotCIIoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCIIoptionPrem); }
                if (lcat.cTotCountPHI != null) { cmd.Parameters.Add("@_cTotCountPHI", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCountPHI); }
                if (lcat.cTotCountTTD != null) { cmd.Parameters.Add("@_cTotCountTTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotCountTTD); }
                if (lcat.cTotFUNgrossPrem != null) { cmd.Parameters.Add("@_cTotFUNgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNgrossPrem); }
                if (lcat.cTotFUNinsPrem != null) { cmd.Parameters.Add("@_cTotFUNinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNinsPrem); }
                if (lcat.cTotFUNtransportPrem != null) { cmd.Parameters.Add("@_cTotFUNtransportPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotFUNtransportPrem); }
                if (lcat.cTotPHIgrossPrem != null) { cmd.Parameters.Add("@_cTotPHIgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIgrossPrem); }
                if (lcat.cTotPHIoptionPrem != null) { cmd.Parameters.Add("@_cTotPHIoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lcat.cTotPHIoptionPrem); }


                cmd.ExecuteNonQuery();
                connection.Close();
                SaveMember(lcat.member, iQuoteNumber);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }
    private void SaveMember(Member[] lmember, string iQuoteNumber)
    {
        try
        {

            foreach (Member lMem in lmember)
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Member_OutputSaveProcedure]", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlCommand cmd1 = new SqlCommand("select count(iMemberNumber) from Member_Output where iQuoteNumber=" + iQuoteNumber, connection);

                connection.Open();
                int Membercount = Convert.ToInt32(cmd1.ExecuteScalar());

                cmd.Parameters.Add("@iQuoteNumber", SqlDbType.Int).Value = Convert.ToInt32(iQuoteNumber);

                cmd.Parameters.Add("@iMemberNumber", SqlDbType.Int).Value = Membercount + 1;

                
                if (lMem.cAgeNextBday != null) { cmd.Parameters.Add("@cAgeNextBday", SqlDbType.Int).Value = Convert.ToInt32(lMem.cAgeNextBday); }
                if (lMem.cSpouseInd != null) { cmd.Parameters.Add("@cSpouseInd", SqlDbType.Int).Value = Convert.ToInt32(lMem.cSpouseInd); }
                if (lMem.cTotCountPHI != null) { cmd.Parameters.Add("@cTotCountPHI", SqlDbType.Int).Value = Convert.ToInt32(lMem.cTotCountPHI); }
                if (lMem.cTotCountTTD != null) { cmd.Parameters.Add("@cTotCountTTD", SqlDbType.Int).Value = Convert.ToInt32(lMem.cTotCountTTD); }
                if (lMem.cAgeNextBdaySpouse != null) { cmd.Parameters.Add("@cAgeNextBdaySpouse", SqlDbType.Int).Value = Convert.ToInt32(lMem.cAgeNextBdaySpouse); }
                if (lMem.cTotAccBenGrossPrem != null) { cmd.Parameters.Add("@cTotAccBenGrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotAccBenGrossPrem); }
                if (lMem.cTotCoverFUN != null) { cmd.Parameters.Add("@cTotCoverFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverFUN); }
                if (lMem.cTotCoverGLA != null) { cmd.Parameters.Add("@cTotCoverGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverGLA); }
                if (lMem.cTotCoverPTD != null) { cmd.Parameters.Add("@cTotCoverPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverPTD); }
                if (lMem.cTotCoverPHI != null) { cmd.Parameters.Add("@cTotCoverPHI", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverPHI); }
                if (lMem.cTotCoverPHIincWaiver != null) { cmd.Parameters.Add("@cTotCoverPHIincWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverPHIincWaiver); }
                if (lMem.cTotCoverPHIwaiver != null) { cmd.Parameters.Add("@cTotCoverPHIwaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverPHIwaiver); }
                if (lMem.cTotCoverSGLA != null) { cmd.Parameters.Add("@cTotCoverSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverSGLA); }
                if (lMem.cTotCoverSPTD != null) { cmd.Parameters.Add("@cTotCoverSPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverSPTD); }
                if (lMem.cTotCoverCII != null) { cmd.Parameters.Add("@cTotCoverCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverCII); }
                if (lMem.cTotFUNgrossPrem != null) { cmd.Parameters.Add("@cTotFUNgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotFUNgrossPrem); }
                if (lMem.cTotGLAgrossPrem != null) { cmd.Parameters.Add("@cTotGLAgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotGLAgrossPrem); }
                if (lMem.cTotPTDgrossPrem != null) { cmd.Parameters.Add("@cTotPTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPTDgrossPrem); }
                if (lMem.cTotMAPWgrossPrem != null) { cmd.Parameters.Add("@cTotMAPWgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotMAPWgrossPrem); }
                if (lMem.cTotPHIgrossPrem != null) { cmd.Parameters.Add("@cTotPHIgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPHIgrossPrem); }
                if (lMem.cTotSGLAgrossPrem != null) { cmd.Parameters.Add("@cTotSGLAgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotSGLAgrossPrem); }
                if (lMem.cTotSPTDgrossPrem != null) { cmd.Parameters.Add("@cTotSPTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotSPTDgrossPrem); }
                if (lMem.cTotSRgrossPrem != null) { cmd.Parameters.Add("@cTotSRgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotSRgrossPrem); }
                if (lMem.cTotTopUpGrossPrem != null) { cmd.Parameters.Add("@cTotTopUpGrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotTopUpGrossPrem); }
                if (lMem.cTotUEPgrossPrem != null) { cmd.Parameters.Add("@cTotUEPgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotUEPgrossPrem); }
                if (lMem.cTotCoverTTD != null) { cmd.Parameters.Add("@cTotCoverTTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverTTD); }
                if (lMem.cTotCoverTTDincWaiver != null) { cmd.Parameters.Add("@cTotCoverTTDincWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverTTDincWaiver); }
                if (lMem.cTotCoverTTDwaiver != null) { cmd.Parameters.Add("@cTotCoverTTDwaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCoverTTDwaiver); }
                if (lMem.cTotFUNinsPrem != null) { cmd.Parameters.Add("@cTotFUNinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotFUNinsPrem); }
                if (lMem.cTotFUNtransportPrem != null) { cmd.Parameters.Add("@cTotFUNtransportPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotFUNtransportPrem); }
                if (lMem.cTotGLAcocPrem != null) { cmd.Parameters.Add("@cTotGLAcocPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotGLAcocPrem); }
                if (lMem.cTotGLAgicPrem != null) { cmd.Parameters.Add("@cTotGLAgicPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotGLAgicPrem); }
                if (lMem.cTotGLAinsPrem != null) { cmd.Parameters.Add("@cTotGLAinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotGLAinsPrem); }
                if (lMem.cTotGLAoptionPrem != null) { cmd.Parameters.Add("@cTotGLAoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotGLAoptionPrem); }
                if (lMem.cTotGLAtibPrem != null) { cmd.Parameters.Add("@cTotGLAtibPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotGLAtibPrem); }
                if (lMem.cTotGLAtrcPrem != null) { cmd.Parameters.Add("@cTotGLAtrcPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotGLAtrcPrem); }
                if (lMem.cTotPHIgrowthPrem != null) { cmd.Parameters.Add("@cTotPHIgrowthPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPHIgrowthPrem); }
                if (lMem.cTotPHIinsPrem != null) { cmd.Parameters.Add("@cTotPHIinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPHIinsPrem); }
                if (lMem.cTotPHIinsPremWaiver != null) { cmd.Parameters.Add("@cTotPHIinsPremWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPHIinsPremWaiver); }
                if (lMem.cTotPHIoptionPrem != null) { cmd.Parameters.Add("@cTotPHIoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPHIoptionPrem); }
                if (lMem.cTotPTDinsPrem != null) { cmd.Parameters.Add("@cTotPTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPTDinsPrem); }
                if (lMem.cTotPTDoptionPrem != null) { cmd.Parameters.Add("@cTotPTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPTDoptionPrem); }
                if (lMem.cTotSGLAinsPrem != null) { cmd.Parameters.Add("@cTotSGLAinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotSGLAinsPrem); }
                if (lMem.cTotSGLAoptionPrem != null) { cmd.Parameters.Add("@cTotSGLAoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotSGLAoptionPrem); }
                if (lMem.cTotSPTDinsPrem != null) { cmd.Parameters.Add("@cTotSPTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotSPTDinsPrem); }
                if (lMem.cTotSPTDoptionPrem != null) { cmd.Parameters.Add("@cTotSPTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotSPTDoptionPrem); }
                if (lMem.cTotTopUpGrowthPrem != null) { cmd.Parameters.Add("@cTotTopUpGrowthPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotTopUpGrowthPrem); }
                if (lMem.cTotTopUpInsPrem != null) { cmd.Parameters.Add("@cTotTopUpInsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotTopUpInsPrem); }
                if (lMem.cTotTTDgrossPrem != null) { cmd.Parameters.Add("@cTotTTDgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotTTDgrossPrem); }
                if (lMem.cTotTTDinsPrem != null) { cmd.Parameters.Add("@cTotTTDinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotTTDinsPrem); }
                if (lMem.cTotTTDinsPremWaiver != null) { cmd.Parameters.Add("@cTotTTDinsPremWaiver", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotTTDinsPremWaiver); }
                if (lMem.cTotTTDoptionPrem != null) { cmd.Parameters.Add("@cTotTTDoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotTTDoptionPrem); }
                if (lMem.cExceedsMaxAge != null) { cmd.Parameters.Add("@cExceedsMaxAge", SqlDbType.Bit).Value = Convert.ToBoolean(lMem.cExceedsMaxAge); }
                if (lMem.cExceedsMinAge != null) { cmd.Parameters.Add("@cExceedsMinAge", SqlDbType.Bit).Value = Convert.ToBoolean(lMem.cExceedsMinAge); }
                if (lMem.cExceedsMPFLcii != null) { cmd.Parameters.Add("@cExceedsMPFLcii", SqlDbType.Bit).Value = Convert.ToBoolean(lMem.cExceedsMPFLcii); }
                if (lMem.cExceedsMPFLgla != null) { cmd.Parameters.Add("@cExceedsMPFLgla", SqlDbType.Bit).Value = Convert.ToBoolean(lMem.cExceedsMPFLgla); }
                if (lMem.cExceedsMPFLphi != null) { cmd.Parameters.Add("@cExceedsMPFLphi", SqlDbType.Bit).Value = Convert.ToBoolean(lMem.cExceedsMPFLphi); }
                if (lMem.cExceedsMPFLsgla != null) { cmd.Parameters.Add("@cExceedsMPFLsgla", SqlDbType.Bit).Value = Convert.ToBoolean(lMem.cExceedsMPFLsgla); }
                if (lMem.cExceedsMPFLttd != null) { cmd.Parameters.Add("@cExceedsMPFLttd", SqlDbType.Bit).Value = Convert.ToBoolean(lMem.cExceedsMPFLttd); }
                if (lMem.cTotCIIinsPrem != null) { cmd.Parameters.Add("@cTotCIIinsPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCIIinsPrem); }
                if (lMem.cTotCIIoptionPrem != null) { cmd.Parameters.Add("@cTotCIIoptionPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCIIoptionPrem); }
                if (lMem.cTotCountFUN != null) { cmd.Parameters.Add("@cTotCountFUN", SqlDbType.Int).Value = Convert.ToInt32(lMem.cTotCountFUN); }
                if (lMem.cTotCountGLA != null) { cmd.Parameters.Add("@cTotCountGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCountGLA); }
                if (lMem.cTotCountPTD != null) { cmd.Parameters.Add("@cTotCountPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCountPTD); }
                if (lMem.cTotCountSGLA != null) { cmd.Parameters.Add("@cTotCountSGLA", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCountSGLA); }
                if (lMem.cTotCountSPTD != null) { cmd.Parameters.Add("@cTotCountSPTD", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCountSPTD); }
                if (lMem.cTotPremCII_cr != null) { cmd.Parameters.Add("@cTotPremCII_cr", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPremCII_cr); }
                if (lMem.cTotPremFUN_cr != null) { cmd.Parameters.Add("@cTotPremFUN_cr", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPremFUN_cr); }
                if (lMem.cTotPremIncDis_cr != null) { cmd.Parameters.Add("@cTotPremIncDis_cr", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPremIncDis_cr); }
                if (lMem.cTotPremLife_cr != null) { cmd.Parameters.Add("@cTotPremLife_cr", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPremLife_cr); }
                if (lMem.cTotPremSpouses_cr != null) { cmd.Parameters.Add("@cTotPremSpouses_cr", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPremSpouses_cr); }
                if (lMem.cTotPremTIncDis_cr != null) { cmd.Parameters.Add("@cTotPremTIncDis_cr", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotPremTIncDis_cr); }
                if (lMem.cTotAnnSalLife != null) { cmd.Parameters.Add("@cTotAnnSalLife", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotAnnSalLife); }
                if (lMem.cTotAnnSalCII != null) { cmd.Parameters.Add("@cTotAnnSalCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotAnnSalCII); }
                if (lMem.cTotAnnSalFUN != null) { cmd.Parameters.Add("@cTotAnnSalFUN", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotAnnSalFUN); }
                if (lMem.cTotAnnSalSpouses != null) { cmd.Parameters.Add("@cTotAnnSalSpouses", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotAnnSalSpouses); }
                if (lMem.cTotAnnSalIncDis != null) { cmd.Parameters.Add("@cTotAnnSalIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotAnnSalIncDis); }
                if (lMem.cTotAnnSalTIncDis != null) { cmd.Parameters.Add("@cTotAnnSalTIncDis", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotAnnSalTIncDis); }
                if (lMem.cExceedsMaxAgeIncWP != null) { cmd.Parameters.Add("@cExceedsMaxAgeIncWP", SqlDbType.Bit).Value = Convert.ToBoolean(lMem.cExceedsMaxAgeIncWP); }
                if (lMem.cAge != null) { cmd.Parameters.Add("@cAge", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cAge); }
                if (lMem.cAgeSpouse != null) { cmd.Parameters.Add("@cAgeSpouse", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cAgeSpouse); }
                if (lMem.cGLAoptCoreRatio != null) { cmd.Parameters.Add("@cGLAoptCoreRatio", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cGLAoptCoreRatio); }
                if (lMem.cGLAoptCovLoading != null) { cmd.Parameters.Add("@cGLAoptCovLoading", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cGLAoptCovLoading); }
                if (lMem.cTotCIIcocPrem != null) { cmd.Parameters.Add("@cTotCIIcocPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCIIcocPrem); }
                if (lMem.cTotCIIgicPrem != null) { cmd.Parameters.Add("@cTotCIIgicPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCIIgicPrem); }
                if (lMem.cTotCIIgrossPrem != null) { cmd.Parameters.Add("@cTotCIIgrossPrem", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCIIgrossPrem); }
                if (lMem.cTotCountCII != null) { cmd.Parameters.Add("@cTotCountCII", SqlDbType.Decimal).Value = Convert.ToDecimal(lMem.cTotCountCII); }



                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }
        catch (Exception ex) { throw ex; }
        finally { connection.Close(); }

    }

    private Category[] getCategory(string lQuoteNumber)
    {

        DataSet ds = new DataSet();
        using (SqlCommand cmd = new SqlCommand("select  * from [dbo].[Category_Input] where [iQuoteNumber] =" + lQuoteNumber))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {

                sda.Fill(ds);
            }
        }
        Category[] lcategory;


        DataTable dtCat = ds.Tables[0];



        lcategory = new Category[dtCat.Rows.Count];
        string lCategoryNumber = null;
        if (dtCat != null)
        {

            for (int i = 0; i < dtCat.Rows.Count; i++)
            {

                lCategoryNumber = dtCat.Rows[i]["iCategoryNumber"].ToString();
                if (getMember(lQuoteNumber, lCategoryNumber).Length <= 0)
                {
                    continue;
                }
                else
                {
                    lcategory[i] = new Category();
                    if (dtCat.Rows[i]["iAccBenMultiple"].ToString() != DBNull.Value.ToString())
                    {
                        lcategory[i].iAccBenMultiple = Convert.ToDecimal(dtCat.Rows[i]["iAccBenMultiple"].ToString());// 1;
                    }
                    else
                    {
                        lcategory[i].iAccBenMultiple = 0.000000M;
                    }
                    lcategory[i].iAccBenMultipleSpecified = true;
                    if (dtCat.Rows[i]["iAccBenType"].ToString() != DBNull.Value.ToString())
                    {
                        lcategory[i].iAccBenType = dtCat.Rows[i]["iAccBenType"].ToString().Trim(); //"Death";
                    }
                    else
                    {
                        lcategory[i].iAccBenType = null;
                    }
                    if (dtCat.Rows[i]["iAgeCutOff1"].ToString() != DBNull.Value.ToString())
                        lcategory[i].iAgeCutOff1 = Convert.ToInt64(dtCat.Rows[i]["iAgeCutOff1"].ToString());
                    else
                        lcategory[i].iAgeCutOff1 = 0;
                    lcategory[i].iAgeCutOff1Specified = true;
                    if (dtCat.Rows[i]["iAgeCutOff2"].ToString() != DBNull.Value.ToString())
                        lcategory[i].iAgeCutOff2 = Convert.ToInt64(dtCat.Rows[i]["iAgeCutOff2"].ToString());
                    else
                        lcategory[i].iAgeCutOff2 = 0;
                    lcategory[i].iAgeCutOff2Specified = true;
                    if (dtCat.Rows[i]["iAgeCutOff3"].ToString() != DBNull.Value.ToString())
                        lcategory[i].iAgeCutOff3 = Convert.ToInt64(dtCat.Rows[i]["iAgeCutOff3"].ToString());
                    else
                        lcategory[i].iAgeCutOff3 = 0;

                    lcategory[i].iAgeCutOff3Specified = true;
                    if (dtCat.Rows[i]["iAgeCutOff4"].ToString() != DBNull.Value.ToString())
                        lcategory[i].iAgeCutOff4 = Convert.ToInt64(dtCat.Rows[i]["iAgeCutOff4"].ToString());
                    else
                        lcategory[i].iAgeCutOff4 = 0;
                    lcategory[i].iAgeCutOff4Specified = true;
                    if (dtCat.Rows[i]["iAgeCutOff5"].ToString() != DBNull.Value.ToString())
                        lcategory[i].iAgeCutOff5 = Convert.ToInt64(dtCat.Rows[i]["iAgeCutOff5"].ToString());
                    else
                        lcategory[i].iAgeCutOff5 = 0;
                    lcategory[i].iAgeCutOff5Specified = true;
                    if (dtCat.Rows[i]["iAgeCutOff6"].ToString() != DBNull.Value.ToString())
                        lcategory[i].iAgeCutOff6 = Convert.ToInt64(dtCat.Rows[i]["iAgeCutOff6"].ToString());
                    else
                        lcategory[i].iAgeCutOff6 = 0;
                    lcategory[i].iAgeCutOff6Specified = true;
                    if (dtCat.Rows[i]["iAgeCutOff7"].ToString() != DBNull.Value.ToString())
                        lcategory[i].iAgeCutOff7 = Convert.ToInt64(dtCat.Rows[i]["iAgeCutOff7"].ToString());
                    else
                        lcategory[i].iAgeCutOff7 = 0;
                    lcategory[i].iAgeCutOff7Specified = true;

                    lcategory[i].iAgeMultGLA1 = (dtCat.Rows[i]["iAgeMultGLA1"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultGLA1"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultGLA1Specified = true;
                    lcategory[i].iAgeMultGLA2 = (dtCat.Rows[i]["iAgeMultGLA2"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultGLA2"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultGLA2Specified = true;
                    lcategory[i].iAgeMultGLA3 = (dtCat.Rows[i]["iAgeMultGLA3"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultGLA3"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultGLA3Specified = true;
                    lcategory[i].iAgeMultGLA4 = (dtCat.Rows[i]["iAgeMultGLA4"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultGLA4"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultGLA4Specified = true;
                    lcategory[i].iAgeMultGLA5 = (dtCat.Rows[i]["iAgeMultGLA5"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultGLA5"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultGLA5Specified = true;
                    lcategory[i].iAgeMultGLA6 = (dtCat.Rows[i]["iAgeMultGLA6"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultGLA6"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultGLA6Specified = true;
                    lcategory[i].iAgeMultGLA7 = (dtCat.Rows[i]["iAgeMultGLA7"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultGLA7"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultGLA7Specified = true;
                    lcategory[i].iAgeMultGLA8 = (dtCat.Rows[i]["iAgeMultGLA8"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultGLA8"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultGLA8Specified = true;

                    lcategory[i].iAgeMultPTD1 = (dtCat.Rows[i]["iAgeMultPTD1"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultPTD1"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultPTD1Specified = true;
                    lcategory[i].iAgeMultPTD2 = (dtCat.Rows[i]["iAgeMultPTD2"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultPTD2"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultPTD2Specified = true;
                    lcategory[i].iAgeMultPTD3 = (dtCat.Rows[i]["iAgeMultPTD3"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultPTD3"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultPTD3Specified = true;
                    lcategory[i].iAgeMultPTD4 = (dtCat.Rows[i]["iAgeMultPTD4"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultPTD4"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultPTD4Specified = true;
                    lcategory[i].iAgeMultPTD5 = (dtCat.Rows[i]["iAgeMultPTD5"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultPTD5"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultPTD5Specified = true;
                    lcategory[i].iAgeMultPTD6 = (dtCat.Rows[i]["iAgeMultPTD6"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultPTD6"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultPTD6Specified = true;
                    lcategory[i].iAgeMultPTD7 = (dtCat.Rows[i]["iAgeMultPTD7"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultPTD7"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultPTD7Specified = true;
                    lcategory[i].iAgeMultPTD8 = (dtCat.Rows[i]["iAgeMultPTD8"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iAgeMultPTD8"].ToString().Trim()) : 0.000000M;
                    lcategory[i].iAgeMultPTD8Specified = true;

                    lcategory[i].iFUNcoverAmt = (dtCat.Rows[i]["iFUNcoverAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iFUNcoverAmt"].ToString().Trim()) : 0.000000M;// 30000;
                    lcategory[i].iFUNcoverAmtSpecified = true;
                    lcategory[i].iGLAcoreCoverMult = (dtCat.Rows[i]["iGLAcoreCoverMult"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iGLAcoreCoverMult"].ToString().Trim()) : 0.000000M;  //0.000000M;
                    lcategory[i].iGLAcoreCoverMultSpecified = true;

                    lcategory[i].iGLAgic = (dtCat.Rows[i]["iGLAgic"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iGLAgic"].ToString().Trim()) : false; //true;
                    lcategory[i].iGLAgicSpecified = true;
                    lcategory[i].iGLAflatCoverAmt = (dtCat.Rows[i]["iGLAflatCoverAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iGLAflatCoverAmt"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iGLAflatCoverAmtSpecified = true;
                    lcategory[i].iGLAhasConverOption = (dtCat.Rows[i]["iGLAhasConverOption"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iGLAhasConverOption"].ToString().Trim()) : false; // true;
                    lcategory[i].iGLAhasConverOptionSpecified = true;
                    lcategory[i].iGLAhasFlexCover = (dtCat.Rows[i]["iGLAhasFlexCover"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iGLAhasFlexCover"].ToString().Trim()) : false;// false;
                    lcategory[i].iGLAhasFlexCoverSpecified = true;

                    lcategory[i].iGLAhasCOC = (dtCat.Rows[i]["iGLAhasCOC"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iGLAhasCOC"].ToString().Trim()) : false;// true;
                    lcategory[i].iGLAhasCOCSpecified = true;
                    lcategory[i].iGLAhasTIB = (dtCat.Rows[i]["iGLAhasTIB"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iGLAhasTIB"].ToString().Trim()) : false;// false;
                    lcategory[i].iGLAhasTIBSpecified = true;
                    lcategory[i].iGLAmultiple = (dtCat.Rows[i]["iGLAmultiple"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iGLAmultiple"].ToString().Trim()) : 0.000000M;// 3.000000M;
                    lcategory[i].iGLAmultipleSpecified = true;

                    lcategory[i].iGLApattern = (dtCat.Rows[i]["iGLApattern"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iGLApattern"].ToString().Trim() : null;//"Multiple";
                    //lcategory[i].iGLApatternSpecified = true;
                    lcategory[i].iPTDflatCoverAmt = (dtCat.Rows[i]["iPTDflatCoverAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPTDflatCoverAmt"].ToString().Trim()) : 0.000000M; //0.000000M;
                    lcategory[i].iPTDflatCoverAmtSpecified = true;
                    lcategory[i].iPTDhasConverOption = (dtCat.Rows[i]["iPTDhasConverOption"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iPTDhasConverOption"].ToString().Trim()) : false;// true;
                    lcategory[i].iPTDhasConverOptionSpecified = true;
                    lcategory[i].iPTDmultiple = (dtCat.Rows[i]["iPTDmultiple"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPTDmultiple"].ToString().Trim()) : 0.000000M;// 2.000000M;
                    lcategory[i].iPTDmultipleSpecified = true;
                    lcategory[i].iPTDnoInstalments = (dtCat.Rows[i]["iPTDnoInstalments"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtCat.Rows[i]["iPTDnoInstalments"].ToString().Trim()) : 0;// 0;
                    lcategory[i].iPTDnoInstalmentsSpecified = true;
                    lcategory[i].iPTDoccDefn = (dtCat.Rows[i]["iPTDoccDefn"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPTDoccDefn"].ToString().Trim() : null;// "Own Occupation";
                    lcategory[i].iPTDpattern = (dtCat.Rows[i]["iPTDpattern"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPTDpattern"].ToString().Trim() : null; //"Multiple";
                    //lcategory[i].iPTDpatternSpecified = true;
                    lcategory[i].iPTDpreEx = (dtCat.Rows[i]["iPTDpreEx"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPTDpreEx"].ToString().Trim() : null;// "12 / 12";
                    lcategory[i].iPTDwp = (dtCat.Rows[i]["iPTDwp"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtCat.Rows[i]["iPTDwp"].ToString().Trim()) : 0;// 6;
                    lcategory[i].iPTDwpSpecified = true;
                    lcategory[i].iHasAccBen = (dtCat.Rows[i]["iHasAccBen"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasAccBen"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasAccBenSpecified = true;
                    lcategory[i].iHasCII = (dtCat.Rows[i]["iHasCII"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasCII"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasCIISpecified = true;

                    lcategory[i].iHasFUN = (dtCat.Rows[i]["iHasFUN"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasFUN"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasFUNSpecified = true;
                    lcategory[i].iHasFUNtransportBen = (dtCat.Rows[i]["iHasFUNtransportBen"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasFUNtransportBen"].ToString().Trim()) : false;// false;
                    lcategory[i].iHasFUNtransportBenSpecified = true;
                    lcategory[i].iHasGLA = (dtCat.Rows[i]["iHasGLA"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasGLA"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasGLASpecified = true;

                    lcategory[i].iHasPTD = (dtCat.Rows[i]["iHasPTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasPTD"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasPTDSpecified = true;
                    lcategory[i].iHasPTDaltOccDefn = (dtCat.Rows[i]["iHasPTDaltOccDefn"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasPTDaltOccDefn"].ToString().Trim()) : false; //false;
                    lcategory[i].iHasPTDaltOccDefnSpecified = true;
                    lcategory[i].iHasPTDaltPreEx = (dtCat.Rows[i]["iHasPTDaltPreEx"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasPTDaltPreEx"].ToString().Trim()) : false;// false;
                    lcategory[i].iHasPTDaltPreExSpecified = true;
                    lcategory[i].iHasPTDinstalments = (dtCat.Rows[i]["iHasPTDinstalments"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasPTDinstalments"].ToString().Trim()) : false; //false;
                    lcategory[i].iHasPTDinstalmentsSpecified = true;
                    lcategory[i].iHasMAPW = (dtCat.Rows[i]["iHasMAPW"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasMAPW"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasMAPWSpecified = true;
                    lcategory[i].iHasMPHI = (dtCat.Rows[i]["iHasMPHI"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasMPHI"].ToString().Trim()) : false; //false;
                    lcategory[i].iHasMPHISpecified = true;

                    lcategory[i].iHasPHI = (dtCat.Rows[i]["iHasPHI"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasPHI"].ToString().Trim()) : false;//true;
                    lcategory[i].iHasPHISpecified = true;
                    lcategory[i].iHasPHIaltEsc = (dtCat.Rows[i]["iHasPHIaltEsc"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasPHIaltEsc"].ToString().Trim()) : false; //false;
                    lcategory[i].iHasPHIaltEscSpecified = true;
                    lcategory[i].iHasPHIaltOccDefn = (dtCat.Rows[i]["iHasPHIaltOccDefn"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasPHIaltOccDefn"].ToString().Trim()) : false;// false;
                    lcategory[i].iHasPHIaltOccDefnSpecified = true;
                    lcategory[i].iHasSalaryRefund = (dtCat.Rows[i]["iHasSalaryRefund"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasSalaryRefund"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasSalaryRefundSpecified = true;
                    lcategory[i].iHasSGLA = (dtCat.Rows[i]["iHasSGLA"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasSGLA"].ToString().Trim()) : false; //true;
                    lcategory[i].iHasSGLASpecified = true;
                    lcategory[i].iHasSPTD = (dtCat.Rows[i]["iHasSPTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasSPTD"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasSPTDSpecified = true;
                    //lcategory[i].iHasSCII = false;// (dtCat.Rows[i]["iHasSCII"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasSCII"].ToString().Trim()) : false;// false;
                    //lcategory[i].iHasSCIISpecified = true;
                    lcategory[i].iHasTaxReplCover = (dtCat.Rows[i]["iHasTaxReplCover"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasTaxReplCover"].ToString().Trim()) : false;// false;
                    lcategory[i].iHasTaxReplCoverSpecified = true;
                    lcategory[i].iHasTopUp = (dtCat.Rows[i]["iHasTopUp"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasTopUp"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasTopUpSpecified = true;
                    lcategory[i].iHasTTD = (dtCat.Rows[i]["iHasTTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasTTD"].ToString().Trim()) : false; //false;
                    lcategory[i].iHasTTDSpecified = true;

                    lcategory[i].iHasUEP = (dtCat.Rows[i]["iHasUEP"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasUEP"].ToString().Trim()) : false;// true;
                    lcategory[i].iHasUEPSpecified = true;

                    lcategory[i].iMAPWPmtTerm = (dtCat.Rows[i]["iMAPWPmtTerm"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtCat.Rows[i]["iMAPWPmtTerm"].ToString().Trim()) : 0; //12;
                    lcategory[i].iMAPWPmtTermSpecified = true;
                    lcategory[i].iPHIaltEsc = (dtCat.Rows[i]["iPHIaltEsc"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPHIaltEsc"].ToString().Trim() : null;//"0 in first year, 10 thereafter";
                    lcategory[i].iPHIbenPercTier1 = (dtCat.Rows[i]["iPHIbenPercTier1"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPHIbenPercTier1"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iPHIbenPercTier1Specified = true;
                    lcategory[i].iPHIbenPercTier2 = (dtCat.Rows[i]["iPHIbenPercTier2"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPHIbenPercTier2"].ToString().Trim()) : 0.000000M; //0.000000M;
                    lcategory[i].iPHIbenPercTier2Specified = true;
                    lcategory[i].iPHIbenPercTier3 = (dtCat.Rows[i]["iPHIbenPercTier3"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPHIbenPercTier3"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iPHIbenPercTier3Specified = true;
                    lcategory[i].iPHIescPerc = (dtCat.Rows[i]["iPHIescPerc"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPHIescPerc"].ToString().Trim()) : 0.000000M;// 5.000000M;
                    lcategory[i].iPHIescPercSpecified = true;
                    lcategory[i].iPHIhasConverOption = (dtCat.Rows[i]["iPHIhasConverOption"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iPHIhasConverOption"].ToString().Trim()) : false;// true;
                    lcategory[i].iPHIhasConverOptionSpecified = true;
                    lcategory[i].iPHIoccDefn = (dtCat.Rows[i]["iPHIoccDefn"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPHIoccDefn"].ToString().Trim() : null;// "Own or Suited throughout";
                    lcategory[i].iPHIsalLimitTier1 = (dtCat.Rows[i]["iPHIsalLimitTier1"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPHIsalLimitTier1"].ToString().Trim()) : 0.000000M;// 0;
                    lcategory[i].iPHIsalLimitTier1Specified = true;
                    lcategory[i].iPHIsalLimitTier2 = (dtCat.Rows[i]["iPHIsalLimitTier2"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPHIsalLimitTier2"].ToString().Trim()) : 0.000000M;// 0;
                    lcategory[i].iPHIsalLimitTier2Specified = true;
                    lcategory[i].iPHIscaleType = (dtCat.Rows[i]["iPHIscaleType"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPHIscaleType"].ToString().Trim() : null;// "75% Flat";
                    lcategory[i].iPHIwaitingPeriod = (dtCat.Rows[i]["iPHIwaitingPeriod"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtCat.Rows[i]["iPHIwaitingPeriod"].ToString().Trim()) : 0;// 3;
                    lcategory[i].iPHIwaitingPeriodSpecified = true;
                    lcategory[i].iPHIwaiverPattern = (dtCat.Rows[i]["iPHIwaiverPattern"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPHIwaiverPattern"].ToString().Trim() : null; // "Multiple";
                    //lcategory[i].iPHIwaiverPatternSpecified = true;
                    lcategory[i].iPHIwaiverPerc = (dtCat.Rows[i]["iPHIwaiverPerc"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iPHIwaiverPerc"].ToString().Trim()) : 0.000000M;// 10.000000M;
                    lcategory[i].iPHIwaiverPercSpecified = true;
                    lcategory[i].iRetAge = (dtCat.Rows[i]["iRetAge"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtCat.Rows[i]["iRetAge"].ToString().Trim()) : 0;// 65;
                    lcategory[i].iRetAgeSpecified = true;
                    lcategory[i].iSalaryScalingFac = (dtCat.Rows[i]["iSalaryScalingFac"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iSalaryScalingFac"].ToString().Trim()) : 0.000000M; //1.000000M;
                    lcategory[i].iSalaryScalingFacSpecified = true;

                    lcategory[i].iSGLAflatCoverAmt = (dtCat.Rows[i]["iSGLAflatCoverAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iSGLAflatCoverAmt"].ToString().Trim()) : 0.000000M; // 0.000000M;
                    lcategory[i].iSGLAflatCoverAmtSpecified = true;
                    lcategory[i].iSGLAhasConverOption = (dtCat.Rows[i]["iSGLAhasConverOption"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iSGLAhasConverOption"].ToString().Trim()) : false;// true;
                    lcategory[i].iSGLAhasConverOptionSpecified = true;
                    lcategory[i].iSGLAisFlatAmt = (dtCat.Rows[i]["iSGLAisFlatAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iSGLAisFlatAmt"].ToString().Trim()) : false;// false;
                    lcategory[i].iSGLAisFlatAmtSpecified = true;

                    lcategory[i].iSGLAmultiple = (dtCat.Rows[i]["iSGLAmultiple"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iSGLAmultiple"].ToString().Trim()) : 0.000000M; //2;
                    lcategory[i].iSGLAmultipleSpecified = true;
                    lcategory[i].iSPTDhasConverOption = (dtCat.Rows[i]["iSPTDhasConverOption"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iSPTDhasConverOption"].ToString().Trim()) : false;// true;
                    lcategory[i].iSPTDhasConverOptionSpecified = true;
                    //lcategory[i].iSCIIflatCoverAmt = 0;// (dtCat.Rows[i]["iSCIIflatCoverAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iSCIIflatCoverAmt"].ToString().Trim()) : 0.000000M; // 0;
                    //lcategory[i].iSCIIflatCoverAmtSpecified = true;
                    //lcategory[i].iSCIIisFlatAmt = false;// (dtCat.Rows[i]["iSCIIisFlatAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iSCIIisFlatAmt"].ToString().Trim()) : false;// true; false;
                    //lcategory[i].iSCIIisFlatAmtSpecified = true;

                    //lcategory[i].iSCIImultiple = 0;// (dtCat.Rows[i]["iSCIImultiple"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iSCIImultiple"].ToString().Trim()) : 0.000000M; // 0;
                    //lcategory[i].iSCIImultipleSpecified = true;
                    //lcategory[i].iSCIItype = "Standard";// (dtCat.Rows[i]["iSCIItype"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iSCIItype"].ToString().Trim() : null;// 
                    lcategory[i].iSRmultiple = (dtCat.Rows[i]["iSRmultiple"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iSRmultiple"].ToString().Trim()) : 0.000000M;// 1.100000M;
                    lcategory[i].iSRmultipleSpecified = true;
                    lcategory[i].iTTDbenPercTier1 = (dtCat.Rows[i]["iTTDbenPercTier1"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iTTDbenPercTier1"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iTTDbenPercTier1Specified = true;
                    lcategory[i].iTTDbenPercTier2 = (dtCat.Rows[i]["iTTDbenPercTier2"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iTTDbenPercTier2"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iTTDbenPercTier2Specified = true;
                    lcategory[i].iTTDbenPercTier3 = (dtCat.Rows[i]["iTTDbenPercTier3"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iTTDbenPercTier3"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iTTDbenPercTier3Specified = true;
                    //lcatego[i]ry.iTTDpaymentPeriod = Convert.ToInt64(dtCat.Rows[i]["iTTDpaymentPeriod"].ToString());// 6;
                    //lcatego[i]ry.iTTDpaymentPeriodSpecified = true;
                    lcategory[i].iTTDsalLimitTier1 = (dtCat.Rows[i]["iTTDsalLimitTier1"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iTTDsalLimitTier1"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iTTDsalLimitTier1Specified = true;
                    lcategory[i].iTTDsalLimitTier2 = (dtCat.Rows[i]["iTTDsalLimitTier2"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iTTDsalLimitTier2"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iTTDsalLimitTier2Specified = true;
                    lcategory[i].iTTDscaleType = (dtCat.Rows[i]["iTTDscaleType"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iTTDscaleType"].ToString().Trim() : null; //"75% Flat";
                    lcategory[i].iTTDwaiverPattern = (dtCat.Rows[i]["iTTDwaiverPattern"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iTTDwaiverPattern"].ToString().Trim() : null;// "Multiple";
                    lcategory[i].iTTDwaiverPerc = (dtCat.Rows[i]["iTTDwaiverPerc"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iTTDwaiverPerc"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iTTDwaiverPercSpecified = true;
                    //lcatego[i]ry.iTTDwaitingPeriod = Convert.ToInt64(dtCat.Rows[i]["iTTDwaitingPeriod"].ToString());// 3;
                    //lcatego[i]ry.iTTDwaitingPeriodSpecified = true;
                    lcategory[i].iSPTDflatCoverAmt = (dtCat.Rows[i]["iSPTDflatCoverAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iSPTDflatCoverAmt"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iSPTDflatCoverAmtSpecified = true;
                    lcategory[i].iSPTDisFlatAmt = (dtCat.Rows[i]["iSPTDisFlatAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iSPTDisFlatAmt"].ToString().Trim()) : false;// false;
                    lcategory[i].iSPTDisFlatAmtSpecified = true;
                    lcategory[i].iSPTDmultiple = (dtCat.Rows[i]["iSPTDmultiple"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iSPTDmultiple"].ToString().Trim()) : 0.000000M;// 2.000000M;
                    lcategory[i].iSPTDmultipleSpecified = true;
                    //lcategory[i].iSCIIhasConverOption = false;// (dtCat.Rows[i]["iSCIIhasConverOption"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iSCIIhasConverOption"].ToString().Trim()) : false; // false;
                    //lcategory[i].iSCIIhasConverOptionSpecified = true;
                    lcategory[i].iCIIgic = (dtCat.Rows[i]["iCIIgic"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iCIIgic"].ToString().Trim()) : false; //true;
                    lcategory[i].iCIIgicSpecified = true;
                    lcategory[i].iCIIflatCoverAmt = (dtCat.Rows[i]["iCIIflatCoverAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iCIIflatCoverAmt"].ToString().Trim()) : 0.000000M; //0.000000M;
                    lcategory[i].iCIIflatCoverAmtSpecified = true;
                    lcategory[i].iCIIhasConverOption = (dtCat.Rows[i]["iCIIhasConverOption"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iCIIhasConverOption"].ToString().Trim()) : false;
                    lcategory[i].iCIIhasConverOptionSpecified = true;

                    lcategory[i].iCIIhasCOC = (dtCat.Rows[i]["iCIIhasCOC"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iCIIhasCOC"].ToString().Trim()) : false; //true;
                    lcategory[i].iCIIhasCOCSpecified = true;
                    lcategory[i].iCIIisFlatAmt = (dtCat.Rows[i]["iCIIisFlatAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iCIIisFlatAmt"].ToString().Trim()) : false;//true;
                    lcategory[i].iCIIisFlatAmtSpecified = true;

                    lcategory[i].iCIImultiple = (dtCat.Rows[i]["iCIImultiple"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtCat.Rows[i]["iCIImultiple"].ToString().Trim()) : 0;// 1;
                    lcategory[i].iCIImultipleSpecified = true;
                    lcategory[i].iCIItype = (dtCat.Rows[i]["iCIItype"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iCIItype"].ToString().Trim() : null;// "Standard";
                    lcategory[i].iVolRateDiscFUN = (dtCat.Rows[i]["iVolRateDiscFUN"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iVolRateDiscFUN"].ToString().Trim()) : 0.000000M; // 0.000000M;
                    lcategory[i].iVolRateDiscFUNSpecified = true;
                    lcategory[i].iVolRateDiscGLA = (dtCat.Rows[i]["iVolRateDiscGLA"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iVolRateDiscGLA"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iVolRateDiscGLASpecified = true;
                    lcategory[i].iVolRateDiscPTD = (dtCat.Rows[i]["iVolRateDiscPTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iVolRateDiscPTD"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iVolRateDiscPTDSpecified = true;
                    lcategory[i].iVolRateDiscPHI = (dtCat.Rows[i]["iVolRateDiscPHI"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iVolRateDiscPHI"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iVolRateDiscPHISpecified = true;
                    lcategory[i].iVolRateDiscSGLA = (dtCat.Rows[i]["iVolRateDiscSGLA"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iVolRateDiscSGLA"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iVolRateDiscSGLASpecified = true;
                    lcategory[i].iVolRateDiscSPTD = (dtCat.Rows[i]["iVolRateDiscSPTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iVolRateDiscSPTD"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iVolRateDiscSPTDSpecified = true;
                    lcategory[i].iVolRateDiscCII = (dtCat.Rows[i]["iVolRateDiscCII"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iVolRateDiscCII"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iVolRateDiscCIISpecified = true;
                    lcategory[i].iBenefitScalingFac = (dtCat.Rows[i]["iBenefitScalingFac"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iBenefitScalingFac"].ToString().Trim()) : 0.000000M;// 1;
                    lcategory[i].iBenefitScalingFacSpecified = true;



                    lcategory[i].iCIIisFlatAmt = (dtCat.Rows[i]["iCIIisFlatAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iCIIisFlatAmt"].ToString().Trim()) : false;
                    lcategory[i].iCIIisFlatAmtSpecified = true;
                    lcategory[i].iCIImultiple = (dtCat.Rows[i]["iCIImultiple"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iCIImultiple"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iCIImultipleSpecified = true;
                    lcategory[i].iGLApattern = (dtCat.Rows[i]["iGLApattern"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iGLApattern"].ToString().Trim() : null;
                    lcategory[i].iHasCoverTo70 = (dtCat.Rows[i]["iHasCoverTo70"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasCoverTo70"].ToString().Trim()) : false;
                    lcategory[i].iHasCoverTo70Specified = true;
                    lcategory[i].iHasGLA = (dtCat.Rows[i]["iHasGLA"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iHasGLA"].ToString().Trim()) : false;
                    lcategory[i].iHasGLASpecified = true;
                    lcategory[i].iPHIwaiverPattern = (dtCat.Rows[i]["iPHIwaiverPattern"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPHIwaiverPattern"].ToString().Trim() : null;
                    lcategory[i].iPTDpattern = (dtCat.Rows[i]["iPTDpattern"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iPTDpattern"].ToString().Trim() : null;
                    lcategory[i].iSGLAisFlatAmt = (dtCat.Rows[i]["iSGLAisFlatAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iSGLAisFlatAmt"].ToString().Trim()) : false;
                    lcategory[i].iSGLAisFlatAmtSpecified = true;
                    lcategory[i].iSPTDisFlatAmt = (dtCat.Rows[i]["iSPTDisFlatAmt"].ToString() != DBNull.Value.ToString()) ? Convert.ToBoolean(dtCat.Rows[i]["iSPTDisFlatAmt"].ToString().Trim()) : false;
                    lcategory[i].iSPTDisFlatAmtSpecified = true;
                    lcategory[i].iTTDescPerc = (dtCat.Rows[i]["iTTDescPerc"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtCat.Rows[i]["iTTDescPerc"].ToString().Trim()) : 0.000000M;// 0.000000M;
                    lcategory[i].iTTDescPercSpecified = true;
                    lcategory[i].iTTDwaiverPattern = (dtCat.Rows[i]["iTTDwaiverPattern"].ToString() != DBNull.Value.ToString()) ? dtCat.Rows[i]["iTTDwaiverPattern"].ToString().Trim() : null;






                    ldePHIwpFactors.daWP = (dtCat.Rows[i]["dePHIwpFactorsKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtCat.Rows[i]["dePHIwpFactorsKey"].ToString().Trim()) : 0;// 13;
                    ldePHIwpFactors.daWPSpecified = true;
                    ldeConversionRates.daRetAge = (dtCat.Rows[i]["deConversionRatesKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtCat.Rows[i]["deConversionRatesKey"].ToString().Trim()) : 0;// 165;
                    ldeConversionRates.daRetAgeSpecified = true;
                    lcategory[i].dePHIwpFactors = new dePHIwpFactors[] { ldePHIwpFactors };
                    lcategory[i].deConversionRates = new deConversionRates[] { ldeConversionRates };


                    lcategory[i].member = getMember(lQuoteNumber, lCategoryNumber);
                }
            }
        }
        return lcategory;
    }

    private Member[] getMember(string lQuoteNumber, string lCategoryNumber)
    {

        DataSet ds = new DataSet();
        using (SqlCommand cmd = new SqlCommand("select  * from [dbo].[Member_Input] where [iQuoteNumber] =" + lQuoteNumber + " AND [iCategory] =" + lCategoryNumber))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {

                sda.Fill(ds);
            }
        }
        DataTable dtMember = new DataTable();
        dtMember = ds.Tables[0];
        Member[] lmember;
        lmember = new Member[dtMember.Rows.Count];
        if (dtMember != null)
        {

            for (int i = 0; i < dtMember.Rows.Count; i++)
            {
                lmember[i] = new Member();
                lmember[i].iAnnualSalary = (dtMember.Rows[i]["iAnnualSalary"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtMember.Rows[i]["iAnnualSalary"].ToString().Trim()) : 0.000000M;
                lmember[i].iAnnualSalarySpecified = true;
                lmember[i].iDOB = (dtMember.Rows[i]["iDOB"].ToString() != DBNull.Value.ToString()) ? Convert.ToDateTime(dtMember.Rows[i]["iDOB"].ToString().Trim()) : DateTime.Now;
                lmember[i].iDOBSpecified = true;
                lmember[i].iDOBspouse = (dtMember.Rows[i]["iDOBspouse"].ToString() != DBNull.Value.ToString()) ? Convert.ToDateTime(dtMember.Rows[i]["iDOBspouse"].ToString().Trim()) : DateTime.Now;
                lmember[i].iDOBspouseSpecified = true;
                lmember[i].iGender = (dtMember.Rows[i]["iGender"].ToString() != DBNull.Value.ToString()) ? dtMember.Rows[i]["iGender"].ToString().Trim() : null;
                lmember[i].iGenderSpouse = (dtMember.Rows[i]["iGenderSpouse"].ToString() != DBNull.Value.ToString()) ? dtMember.Rows[i]["iGenderSpouse"].ToString().Trim() : null;

                lmember[i].iLoadingGLA = (dtMember.Rows[i]["iLoadingGLA"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtMember.Rows[i]["iLoadingGLA"].ToString().Trim()) : 0.000000M;
                lmember[i].iLoadingGLASpecified = true;
                lmember[i].iLoadingPTD = (dtMember.Rows[i]["iLoadingPTD"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtMember.Rows[i]["iLoadingPTD"].ToString().Trim()) : 0.000000M;
                lmember[i].iLoadingPTDSpecified = true;
                lmember[i].iLoadingPHI = (dtMember.Rows[i]["iLoadingPHI"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtMember.Rows[i]["iLoadingPHI"].ToString().Trim()) : 0.000000M;
                lmember[i].iLoadingPHISpecified = true;
                lmember[i].iLoadingCII = (dtMember.Rows[i]["iLoadingCII"].ToString() != DBNull.Value.ToString()) ? Convert.ToDecimal(dtMember.Rows[i]["iLoadingCII"].ToString().Trim()) : 0.000000M;
                lmember[i].iLoadingCIISpecified = true;
                lmember[i].iCategory = (dtMember.Rows[i]["iLoadingCII"].ToString() != DBNull.Value.ToString()) ? dtMember.Rows[i]["iCategory"].ToString().Trim() : null;
                lmember[i].iRiskClass = (dtMember.Rows[i]["iRiskClass"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtMember.Rows[i]["iRiskClass"].ToString().Trim()) : 0;
                lmember[i].iRiskClassSpecified = true;
                deTTDrates ldeTTDrates = new deTTDrates();

                ldeTTDrates.daCode = (dtMember.Rows[i]["deTTDrates"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtMember.Rows[i]["deTTDrates"].ToString().Trim()) : 0;
                ldeTTDrates.daCodeSpecified = true;


                lmember[i].deTTDrates = new deTTDrates[] { ldeTTDrates };

                deGenderFactors ldeGenderFactors = new deGenderFactors();

                ldeGenderFactors.daGender = (dtMember.Rows[i]["deGenderFactorsKey"].ToString() != DBNull.Value.ToString()) ? dtMember.Rows[i]["deGenderFactorsKey"].ToString().Trim() : null; ;


                lmember[i].deGenderFactors = new deGenderFactors[] { ldeGenderFactors };
                //SpousesCII lspousesCII = new SpousesCII();
                //lmember[i].spousesCII = lspousesCII;
                MAPW lMAPW = new MAPW();
                PHI lPHI = new PHI();
                SalaryRefund lSalaryRefund = new SalaryRefund();
                SpousesGLA lSpousesGLA = new SpousesGLA();
                SpousesPTD lSpousesPTD = new SpousesPTD();
                AccidentBen laccben = new AccidentBen();
                lmember[i].mAPW = lMAPW;
                lmember[i].pHI = lPHI;
                lmember[i].salaryRefund = lSalaryRefund;
                lmember[i].spousesGLA = lSpousesGLA;
                lmember[i].spousesPTD = lSpousesPTD;
                lmember[i].accidentBen = laccben;
                deAgeFactors ldeAgeFactors = new deAgeFactors();
                ldeAgeFactors.daAge = (dtMember.Rows[i]["deAgeFactorsKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtMember.Rows[i]["deAgeFactorsKey"].ToString().Trim()) : 0;
                ldeAgeFactors.daAgeSpecified = true;
                GLA lGLA = new GLA();
                PTD lPTD = new PTD();
                deGLAsalIndGenFac ldeGLAsalIndGenFac = new deGLAsalIndGenFac();
                ldeGLAsalIndGenFac.daIndCat = (dtMember.Rows[i]["deGLAsalIndGenFacKey"].ToString() != DBNull.Value.ToString()) ? dtMember.Rows[i]["deGLAsalIndGenFacKey"].ToString().Trim() : null;
                dePHIgenNRAescWPfac ldePHIgenNRAescWPfac = new dePHIgenNRAescWPfac();
                ldePHIgenNRAescWPfac.daCode = (dtMember.Rows[i]["dePHIgenNRAescWPfacKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtMember.Rows[i]["dePHIgenNRAescWPfacKey"].ToString().Trim()) : 0;
                ldePHIgenNRAescWPfac.daCodeSpecified = true;
                dePHIsalFactors ldePHIsalFactors = new dePHIsalFactors();
                ldePHIsalFactors.daSalCat = (dtMember.Rows[i]["dePHIsalFactorsKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtMember.Rows[i]["dePHIsalFactorsKey"].ToString().Trim()) : 0;
                ldePHIsalFactors.daSalCatSpecified = true;


                deRatingClassFac ldeRatingClassFac = new deRatingClassFac();
                ldeRatingClassFac.daKey = (dtMember.Rows[i]["deRatingClassFacKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtMember.Rows[i]["deRatingClassFacKey"].ToString().Trim()) : 0;
                ldeRatingClassFac.daKeySpecified = true;
                deRegionFactors ldeRegionFactors = new deRegionFactors();
                ldeRegionFactors.daRegion = (dtMember.Rows[i]["deRegionFactorsKey"].ToString() != DBNull.Value.ToString()) ? dtMember.Rows[i]["deRegionFactorsKey"].ToString().Trim() : null;
                deSpousesAgeFactors ldeSpousesAgeFactors = new deSpousesAgeFactors();
                ldeSpousesAgeFactors.daAge = (dtMember.Rows[i]["deSpousesAgeFactorsKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtMember.Rows[i]["deSpousesAgeFactorsKey"].ToString().Trim()) : 0;
                ldeSpousesAgeFactors.daAgeSpecified = true;
                deSpousesGenderFac ldeSpousesGenderFac = new deSpousesGenderFac();
                ldeSpousesGenderFac.daGender = (dtMember.Rows[i]["deSpousesGenderFacKey"].ToString() != DBNull.Value.ToString()) ? dtMember.Rows[i]["deSpousesGenderFacKey"].ToString().Trim() : null;
                FUN lFUN = new FUN();
                TopUp ltopup = new TopUp();
                CII lCII = new CII();
                TTD lTTD = new TTD();
                deTopUpRates ldeTopUpRates = new deTopUpRates();


                ldeTopUpRates.daCode = (dtMember.Rows[i]["deTopUpRatesKey"].ToString() != DBNull.Value.ToString()) ? Convert.ToInt64(dtMember.Rows[i]["deTopUpRatesKey"].ToString().Trim()) : 0;
                ldeTopUpRates.daCodeSpecified = true;



                lmember[i].deAgeFactors = new deAgeFactors[] { ldeAgeFactors };

                lmember[i].gLA = lGLA;
                lmember[i].pTD = lPTD;

                lmember[i].deGLAsalIndGenFac = new deGLAsalIndGenFac[] { ldeGLAsalIndGenFac };
                lmember[i].dePHIgenNRAescWPfac = new dePHIgenNRAescWPfac[] { ldePHIgenNRAescWPfac };
                lmember[i].dePHIsalFactors = new dePHIsalFactors[] { ldePHIsalFactors };
                lmember[i].deRatingClassFac = new deRatingClassFac[] { ldeRatingClassFac };
                lmember[i].deRegionFactors = new deRegionFactors[] { ldeRegionFactors };
                lmember[i].deSpousesAgeFactors = new deSpousesAgeFactors[] { ldeSpousesAgeFactors };
                lmember[i].deSpousesGenderFac = new deSpousesGenderFac[] { ldeSpousesGenderFac };

                lmember[i].fUN = lFUN;
                lmember[i].topUp = ltopup;
                lmember[i].cII = lCII;
                lmember[i].tTD = lTTD;

                lmember[i].deTopUpRates = new deTopUpRates[] { ldeTopUpRates };
            }
        }
        return lmember;
    }

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
}