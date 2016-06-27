using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

public partial class addquote : System.Web.UI.Page
{
    SqlConnection connection;
    DataSet ds = new DataSet();
    Dbcon objdb = new Dbcon();
    protected void Page_Load(object sender, EventArgs e)
    {
        //String hiddenFieldValue = tabid.Value;
        //StringBuilder js = new StringBuilder();
        //js.Append("<script type='text/javascript'>");
        //js.Append("var previouslySelectedTab = ");
        //js.Append(hiddenFieldValue);
        //js.Append(";</script>"); 
        //hidtab.Value = Request.Form[hidtab.UniqueID]; 
        //String hiddenFieldValue = hidtab.Value;
        //StringBuilder js = new StringBuilder();
        //js.Append("<script type='text/javascript'>");
        //js.Append("var previouslySelectedTab = ");
        //js.Append(hiddenFieldValue);
        //js.Append(";</script>");
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "acttab", js.ToString());
        //tabid.Value = Request.Form[tabid.UniqueID];
        // string gg = hidtab.Value.ToString();
        // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tor", "javascript:tor('"+gg+"')",true );
        connection = new SqlConnection();
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        if (!IsPostBack)
        {
            droppop();
           
            if (Request.QueryString["iQuoteNumber"] != null)
            {
                string qno = Request.QueryString["iQuoteNumber"].ToString();
                if (qno != string.Empty)
                {

                    quotenotxt.Text = qno;

                    quotenotxt_TextChanged(quotenotxt, EventArgs.Empty);
                }
                
            }
        }
        BindRepeaterData();

        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGOAnoInstalment'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        GOAnoInstalmentsDropDownList.DataSource = ds.Tables[0];
        //        GOAnoInstalmentsDropDownList.DataTextField = "Value";
        //        
        //        GOAnoInstalmentsDropDownList.DataBind();
        //    }
        //}
        // using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGOAwp'"))
        // {
        //     cmd.CommandType = CommandType.Text;
        //     cmd.Connection = connection;
        //     using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //     {
        //         DataSet ds = new DataSet();
        //         sda.Fill(ds);
        //         GOAwpDropDownList.DataSource = ds.Tables[0];
        //         GOAwpDropDownList.DataTextField = "Value";
        //         GOAwpDropDownList.DataValueField = "Field_Name";
        //         GOAwpDropDownList.DataBind();
        //     }
        //}

        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGOApreEx'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        GOApreExDropDownList.DataSource = ds.Tables[0];
        //        GOApreExDropDownList.DataTextField = "Value";
        //        GOApreExDropDownList.DataValueField = "Field_Name";
        //        GOApreExDropDownList.DataBind();
        //    }


        //}

        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iPHIoccDefn'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        PHIoccDefnDropDownList.DataSource = ds.Tables[0];
        //        PHIoccDefnDropDownList.DataTextField = "Value";
        //        PHIoccDefnDropDownList.DataValueField = "Field_Name";
        //        PHIoccDefnDropDownList.DataBind();
        //    }
        //}

    }

    public void droppop()
    {
        connection = new SqlConnection();
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;


        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iCommDiscount'"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                CommonDiscountDropDownList.DataSource = ds.Tables[0];
                CommonDiscountDropDownList.DataTextField = "Value";

                CommonDiscountDropDownList.DataBind();
            }
        }
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iFOname'"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                FOnametxtDropDownList.DataSource = ds.Tables[0];
                FOnametxtDropDownList.DataTextField = "Value";
                FOnametxtDropDownList.DataBind();
            }


        }


        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iIndustry'"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                IndustryDropDown.DataSource = ds.Tables[0];
                IndustryDropDown.DataTextField = "Value";

                IndustryDropDown.DataBind();
            }


        }

        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='íRetAge'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        RetirementAgeDropDownList.DataSource = ds.Tables[0];
        //        RetirementAgeDropDownList.DataTextField = "Value";

        //        RetirementAgeDropDownList.DataBind();
        //    }


        //}

        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iProvince'"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ProvinceDropDown.DataSource = ds.Tables[0];
                ProvinceDropDown.DataTextField = "Value";
                //ProvinceDropDown.DataValueField = "Value";
                ProvinceDropDown.DataBind();
            }


        }
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGOAtaperingYears'"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GOAtaperingYearsDropDownList.DataSource = ds.Tables[0];
                GOAtaperingYearsDropDownList.DataTextField = "Value";

                GOAtaperingYearsDropDownList.DataBind();
            }


        }

        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGOAtype'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        GOAtypeDropDownList.DataSource = ds.Tables[0];
        //        GOAtypeDropDownList.DataTextField = "Value";

        //        GOAtypeDropDownList.DataBind();
        //    }


        //}



        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iAFscheme'"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                AFschemeDropDownList.DataSource = ds.Tables[0];
                AFschemeDropDownList.DataTextField = "Value";

                AFschemeDropDownList.DataBind();
            }
        }
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iAFschemeType'"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                AFschemeTypeDropDownList.DataSource = ds.Tables[0];
                AFschemeTypeDropDownList.DataTextField = "Value";
                AFschemeTypeDropDownList.DataBind();
            }
        }
        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGLApattern'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        iglapatterndropdown.DataSource = ds.Tables[0];
        //        iglapatterndropdown.DataTextField = "Value";

        //        iglapatterndropdown.DataBind();
        //        //iglapatterndropdown.Items.Add("Select..");

        //    }
        //}

        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGOApattern'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        PTDpatterndropdown.DataSource = ds.Tables[0];
        //        PTDpatterndropdown.DataTextField = "Value";

        //        PTDpatterndropdown.DataBind();
        //        //iglapatterndropdown.Items.Add("Select..");

        //    }
        //}


        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iPHIscaleType'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        PHIscaleTypedropdown.DataSource = ds.Tables[0];
        //        PHIscaleTypedropdown.DataTextField = "Value";
        //        PHIscaleTypedropdown.DataBind();
        //        //iglapatterndropdown.Items.Add("Select..");

        //    }
        //}


        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name ='iAccidentBenType'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        AccidentbentypeDropDownList.DataSource = ds.Tables[0];
        //        AccidentbentypeDropDownList.DataTextField = "Value";

        //        AccidentbentypeDropDownList.DataBind();

        //    }
        //}
        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name ='iSGLApattern'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        SGLApatterndropdown.DataSource = ds.Tables[0];
        //        SGLApatterndropdown.DataTextField = "Value";
        //        SGLApatterndropdown.DataBind();

        //    }
        //}
        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name ='iSPTDpattern'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        iSPTDpatterndropdown.DataSource = ds.Tables[0];
        //        iSPTDpatterndropdown.DataTextField = "Value";
        //        iSPTDpatterndropdown.DataBind();

        //  
        //}


    }
   
    protected void BindRepeaterData()
    {
        // SqlConnection connection = new SqlConnection();
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        //SqlCommand cmd1=new SqlCommand ("select  count(iGLApattern) from  Category_Input where iGLApattern='Multiple'",connection);
        // connection.Open();
        //int multcount= Convert.ToInt32( cmd1.ExecuteScalar().ToString());
        //connection.Close();
        //SqlCommand cmd2=new SqlCommand ("select  count(iGLApattern) from  Category_Input where iGLApattern='Flat'",connection);
        // connection.Open();
        // int flatcount = Convert.ToInt32(cmd2.ExecuteScalar().ToString());
        //connection.Close();
        //SqlCommand cmd3=new SqlCommand ("select  count(iGLApattern) from  Category_Input where iGLApattern='AgeBanded'",connection);
        // connection.Open();
        //int agecount= Convert.ToInt32( cmd3.ExecuteScalar().ToString());
        //connection.Close();
        //if (multcount == 0)
        //{
        //   // TableRow6.Attributes["style"] = "height:72px;border-color:black; display:none";

        //       //Table1. TableRow37.Attributes["style"] = "height:70px;border-color:black; display:none";
        //    //TableRow6.Attributes["style"] = "height:72px;border-color:black; ";
        //}
        //else
        //{
        //  //  TableRow6.Attributes["style"] = "height:72px;border-color:black; ";
        //}
        //if (flatcount == 0)
        //{
        //    //TableRow10.Attributes["style"] = "height:71px;border-color:black; display:none";
        //    TableRow10.Attributes["style"] = "height:71px;border-color:black; ";
        //}
        //else
        //{
        //}
        //if (agecount == 0)
        //{
        //}
        //else
        //{           
        //}
        TableRow10.Attributes["style"] = "height:71px;border-color:black; ";
        TableRow11.Attributes["style"] = "height:71px;border-color:black; display:none";
        TableRow11.Attributes["style"] = "height:71px;border-color:black; ";
        string kff = quotenotxt.Text;
        SqlCommand cmd = new SqlCommand("select * from Category_Input where iQuoteNumber='" + quotenotxt.Text + "'", connection);
        connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        int c = dt.Rows.Count;
        //dt.Columns.Add("NewColumn", typeof(System.Nullable));
        //DataRow ddr = dt.NewRow();
        //dt.Rows.Add(ddr);
        c = dt.Rows.Count;
        int widthh = c * 260;
        divconetnet.Attributes["style"] = " width:" + widthh + "px; overflow-x: scroll; display: inline-table;";
        testrepeater.DataSource = dt;
        testrepeater.DataBind();
        //DropDownList GLAgicdropdown = (DropDownList)testrepeater.FindControl("iglapatterndropdown");
        //GLAgicdropdown. = "cf";
        connection.Close();
    }

    #region aa
    protected void savequotebtn_Click(object sender, EventArgs e)
    {
        if (quotenotxt.Text != string.Empty)
        {
            SqlCommand cmd1 = new SqlCommand("select iQuoteNumber from Quote_Input where iQuoteNumber='" + quotenotxt.Text + "'", connection);
            connection.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (!dr.HasRows)
            {
                connection.Close();
                SqlCommand cmd = new SqlCommand("qutoesave_procedure", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@quoteno", SqlDbType.VarChar).Value = quotenotxt.Text;
                cmd.Parameters.Add("@quotestatus", SqlDbType.VarChar).Value = "Tony K";
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = "Tony";
                cmd.Parameters.Add("@province", SqlDbType.VarChar).Value = ProvinceDropDown.SelectedItem.ToString();
                ViewState["ProvinceSelectedItem"] = ProvinceDropDown.SelectedItem.ToString();
                cmd.Parameters.Add("@industry", SqlDbType.VarChar).Value = IndustryDropDown.SelectedItem.ToString();
                ViewState["IndustrySelectedItem"] = IndustryDropDown.SelectedItem.ToString();
                //cmd.Parameters.Add("@bindfee", SqlDbType.Date).Value = BinderFeePerctxt.Value;

                cmd.Parameters.Add("@iClientName", SqlDbType.VarChar).Value = companynametxt.Text;

                if (BinderFeePerctxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@bindfee", SqlDbType.Decimal).Value = decimal.Parse(BinderFeePerctxt.Value, CultureInfo.InvariantCulture);
                }
                if (CommonDiscountDropDownList.SelectedItem.ToString() != "Select..")
                {
                    string fgn = CommonDiscountDropDownList.SelectedItem.ToString();
                    cmd.Parameters.Add("@commondiscount", SqlDbType.Decimal).Value = decimal.Parse(CommonDiscountDropDownList.SelectedItem.ToString(), CultureInfo.InvariantCulture);
                    ViewState["CommonDiscountSelectedItem"] = CommonDiscountDropDownList.SelectedItem.ToString();
                }
                if (quotedatetxt.Text != string.Empty)
                {
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.ParseExact(quotedatetxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                }
                //if (quotedatetxt.Text != string.Empty)
                //{
                //    cmd.Parameters.Add("@expirydate", SqlDbType.Date).Value = DateTime.ParseExact(quotedatetxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //}
                if (GOAtaperingYearsDropDownList.SelectedValue.ToString() != "Select..")
                {
                    cmd.Parameters.Add("@PTDtaperingyears", SqlDbType.Int).Value = Convert.ToInt32(GOAtaperingYearsDropDownList.SelectedItem.ToString());
                    ViewState["GOAtaperingYearsSelectedItem"] = GOAtaperingYearsDropDownList.SelectedItem.ToString();
                }
                cmd.Parameters.Add("@hasnbcommon", SqlDbType.Bit).Value = schemeCommission.SelectedValue.ToString();
                cmd.Parameters.Add("@hasvatoncommon", SqlDbType.Bit).Value = vatCommssion.SelectedValue.ToString(); ;
                cmd.Parameters.Add("@issufquote", SqlDbType.Bit).Value = bool.Parse(IsSUFquotedropdown.SelectedValue.ToString());
                ViewState["IsSUFquoteSelectedItem"] = IsSUFquotedropdown.SelectedItem.ToString();
                if (outsourcefeetxt.Text != string.Empty)
                {
                    cmd.Parameters.Add("@outsourcefee", SqlDbType.Decimal).Value = decimal.Parse(outsourcefeetxt.Text, CultureInfo.InvariantCulture);
                }
                cmd.Parameters.Add("@foname", SqlDbType.VarChar).Value = FOnametxtDropDownList.SelectedItem.ToString();
                ViewState["FOnametxtSelectedItem"] = FOnametxtDropDownList.SelectedItem.ToString();

                cmd.Parameters.Add("@desalaryparamskey", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@decommisionparamskey", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@deexpenseparamskey", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@frontofficefactorskey", SqlDbType.VarChar).Value ="1" + FOnametxtDropDownList.SelectedItem.ToString().Trim();
                cmd.Parameters.Add("@industryfactorskey", SqlDbType.VarChar).Value = "1" + IndustryDropDown.SelectedItem.ToString().Trim();
                cmd.Parameters.Add("@deschemeparamskey", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@ihmsinvolved", SqlDbType.Bit).Value = false;


                cmd.Parameters.Add("@oMaxAgeCII", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgeFUN", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgeGLA", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgePHITTD", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgePTD", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgeSGLA", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgeSPTD", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);





                if (agefactorstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deagefactorsver", SqlDbType.Int).Value = Convert.ToInt32(agefactorstxt.Value);
                }
                if (spouseagetxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@despousagefactors", SqlDbType.Int).Value = Convert.ToInt32(spouseagetxt.Value);
                }
                if (industryfactorstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@industryfactorver", SqlDbType.Int).Value = Convert.ToInt32(industryfactorstxt.Value);
                }
                if (genderfactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@genderfactorsver", SqlDbType.Int).Value = Convert.ToInt32(genderfactxt.Value);
                }
                if (spousegendertxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@spousgenderfactor", SqlDbType.Int).Value = Convert.ToInt32(spousegendertxt.Value);
                }
                if (frontofficefactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@frontofficefactors", SqlDbType.Int).Value = Convert.ToInt32(frontofficefactxt.Value);
                }
                if (glasalindtxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@glasalindfactor", SqlDbType.Int).Value = Convert.ToInt32(glasalindtxt.Value);
                }
                if (salaryparamstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deslaryparamsver", SqlDbType.Int).Value = Convert.ToInt32(salaryparamstxt.Value);
                }
                if (schemeparamtxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deschemeparameterver", SqlDbType.Int).Value = Convert.ToInt32(schemeparamtxt.Value);
                }
                if (regionfactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deregionalfactorsversion", SqlDbType.Int).Value = Convert.ToInt32(regionfactxt.Value);
                }
                if (convertionratestxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deconvertionratesvertion", SqlDbType.Int).Value = Convert.ToInt32(convertionratestxt.Value);
                }
                if (phigennra.Value != string.Empty)
                {
                    cmd.Parameters.Add("@dephigennraesc", SqlDbType.Int).Value = Convert.ToInt32(phigennra.Value);
                }
                if (phisalfactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@phisalfactors", SqlDbType.Int).Value = Convert.ToInt32(phisalfactxt.Value);
                }
                if (phiwpfactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@phiwpfactors", SqlDbType.Int).Value = Convert.ToInt32(phiwpfactxt.Value);
                }
                if (sratestxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@desratever", SqlDbType.Int).Value = Convert.ToInt32(sratestxt.Value);
                }
                if (commisionparamstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@decommisionparam", SqlDbType.Int).Value = Convert.ToInt32(commisionparamstxt.Value);
                }
                if (expenseparamtxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@expenseparamver", SqlDbType.Int).Value = Convert.ToInt32(expenseparamtxt.Value);
                }
                if (ratingclasstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deratingclass", SqlDbType.Int).Value = Convert.ToInt32(ratingclasstxt.Value);
                }
                cmd.Parameters.Add("@afschemetype", SqlDbType.VarChar).Value = AFschemeTypeDropDownList.SelectedItem.ToString();

                cmd.Parameters.Add("@afscheme", SqlDbType.VarChar).Value = AFschemeDropDownList.SelectedItem.ToString();

                cmd.Parameters.Add("@brokername", SqlDbType.VarChar).Value = brokernametxt.Value;

                if (datevalidtilltxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@datevalidtill", SqlDbType.Date).Value = DateTime.ParseExact(datevalidtilltxt.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (renewalmonthtxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@renewalmonth", SqlDbType.Decimal).Value = decimal.Parse(renewalmonthtxt.Value, CultureInfo.InvariantCulture);
                }

                if (nextrenewaldatetxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@nextrenewdate", SqlDbType.Date).Value = DateTime.ParseExact(nextrenewaldatetxt.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                cmd.Parameters.Add("@participatingemployer", SqlDbType.VarChar).Value = participatingemployer.Value;
                cmd.Parameters.Add("@fundname", SqlDbType.VarChar).Value = fundnametxt.Value;
                cmd.Parameters.Add("@fundyearend", SqlDbType.VarChar).Value = fundyearend.Value;
                //cmd.Parameters.Add("@glamaxcover", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@foadminfee", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@maxcovertetgla", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@maxcoveretgoa", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@gracecovmaxnat", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@afmaxfcl", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@afmaxxacccov", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@afmaxgoa", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@fambencoveramt6", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@fambencoveramt1", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@fambencoveramt0", SqlDbType.Decimal).Value = quotedatetxt.Text;
                //cmd.Parameters.Add("@fambencoeramts", SqlDbType.Decimal).Value = quotedatetxt.Text;       
                //connection.Open();
            cmd.ExecuteNonQuery();
                connection.Close();

            }


            else
            {

                connection.Close();
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "quoteinputupdate_procedure";
                cmd.Parameters.Add("@QuoteNumber", SqlDbType.Int).Value = Convert.ToInt32(quotenotxt.Text);
                cmd.Parameters.Add("@QuoteStatus", SqlDbType.VarChar).Value = "updation";
                if (quotedatetxt.Text != string.Empty)
                {
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.ParseExact(quotedatetxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = "Tony";
                cmd.Parameters.Add("@Province", SqlDbType.VarChar).Value = ProvinceDropDown.SelectedItem.ToString();
                // string djfnd = ProvinceDropDown.;
                ViewState["ProvinceSelectedItem"] = ProvinceDropDown.SelectedItem.ToString();

                cmd.Parameters.Add("@Industry", SqlDbType.VarChar).Value = IndustryDropDown.SelectedItem.ToString();

                cmd.Parameters.Add("@iClientName", SqlDbType.VarChar).Value = companynametxt.Text;

                if (BinderFeePerctxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@BinderFeePerc", SqlDbType.Decimal).Value = decimal.Parse(BinderFeePerctxt.Value, CultureInfo.InvariantCulture);
                }
                if (CommonDiscountDropDownList.SelectedItem.ToString() != "Select..")
                {
                    cmd.Parameters.Add("@CommDiscount", SqlDbType.Decimal).Value = decimal.Parse(CommonDiscountDropDownList.SelectedItem.ToString(), CultureInfo.InvariantCulture);
                }

                //if (quotedatetxt.Text != string.Empty)
                //{
                //    cmd.Parameters.Add("@expirydate", SqlDbType.Date).Value = DateTime.ParseExact(quotedatetxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //}

                if (GOAtaperingYearsDropDownList.SelectedValue.ToString() != "Select..")
                {
                    cmd.Parameters.Add("@PTDtaperingYears", SqlDbType.Int).Value = Convert.ToInt32(GOAtaperingYearsDropDownList.SelectedItem.ToString());
                }
                cmd.Parameters.Add("@HasNBComm", SqlDbType.Bit).Value = schemeCommission.SelectedValue.ToString();
                cmd.Parameters.Add("@HasVatOnComm", SqlDbType.Bit).Value = vatCommssion.SelectedValue.ToString();
                cmd.Parameters.Add("@IsSUFquote", SqlDbType.Bit).Value = bool.Parse(IsSUFquotedropdown.SelectedValue);
                if (outsourcefeetxt.Text != string.Empty)
                {
                    cmd.Parameters.Add("@OutsourceFeePerc", SqlDbType.Decimal).Value = decimal.Parse(outsourcefeetxt.Text, CultureInfo.InvariantCulture);
                }
                cmd.Parameters.Add("@Foname", SqlDbType.VarChar).Value = FOnametxtDropDownList.SelectedValue.ToString();
                cmd.Parameters.Add("@deSalaryParmsKey", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@deCommissionParmsKey", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@deExpenseParmsKey", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@deFrontOfficeFactorsKey", SqlDbType.VarChar).Value = "1" + FOnametxtDropDownList.SelectedValue.ToString().Trim();
               cmd.Parameters.Add("@deIndustryFactorsKey", SqlDbType.VarChar).Value = "1" + IndustryDropDown.SelectedItem.ToString().Trim();
                cmd.Parameters.Add("@deSchemeParmsKey", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@iHMSinvolved", SqlDbType.Bit).Value = false;



                cmd.Parameters.Add("@oMaxAgeCII", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgeFUN", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgeGLA", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgePHITTD", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgePTD", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgeSGLA", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);
                cmd.Parameters.Add("@oMaxAgeSPTD", SqlDbType.Int).Value = 0; //Convert.ToInt32(MAPWPmtTermtxtbox.Text);


                if (agefactorstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deAgeFactorsVer", SqlDbType.Int).Value = Convert.ToInt32(agefactorstxt.Value);
                }
                if (spouseagetxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deSpousesAgeFactorsVer", SqlDbType.Int).Value = Convert.ToInt32(spouseagetxt.Value);
                }
                if (industryfactorstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deIndustryFactorsVer", SqlDbType.Int).Value = Convert.ToInt32(industryfactorstxt.Value);
                }
                if (genderfactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deGenderFactorsVer", SqlDbType.Int).Value = Convert.ToInt32(genderfactxt.Value);
                }
                if (spousegendertxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deSpousesGenderFacVer", SqlDbType.Int).Value = Convert.ToInt32(spousegendertxt.Value);
                }
                if (frontofficefactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deFrontOfficeFactorsVer", SqlDbType.Int).Value = Convert.ToInt32(frontofficefactxt.Value);
                }
                if (glasalindtxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deGLAsalIndGenFacVer", SqlDbType.Int).Value = Convert.ToInt32(glasalindtxt.Value);
                }
                if (salaryparamstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deSalaryParmsVer", SqlDbType.Int).Value = Convert.ToInt32(salaryparamstxt.Value);
                }
                if (schemeparamtxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deSchemeParametersVer", SqlDbType.Int).Value = Convert.ToInt32(schemeparamtxt.Value);
                }
                if (regionfactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deRegionFactorsVer", SqlDbType.Int).Value = Convert.ToInt32(regionfactxt.Value);
                }
                if (convertionratestxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deConvertionRatesVer", SqlDbType.Int).Value = Convert.ToInt32(convertionratestxt.Value);
                }
                if (phigennra.Value != string.Empty)
                {
                    cmd.Parameters.Add("@dePHIgenNRAescWPVer", SqlDbType.Int).Value = Convert.ToInt32(phigennra.Value);
                }
                if (phisalfactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@dePHIsalFactorsVer", SqlDbType.Int).Value = Convert.ToInt32(phisalfactxt.Value);
                }
                if (phiwpfactxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@dePHIwpFactorsVer", SqlDbType.Int).Value = Convert.ToInt32(phiwpfactxt.Value);
                }
                if (sratestxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deSRratesVer", SqlDbType.Int).Value = Convert.ToInt32(sratestxt.Value);
                }
                if (commisionparamstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deCommissionParmsVer", SqlDbType.Int).Value = Convert.ToInt32(commisionparamstxt.Value);
                }
                if (expenseparamtxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deExpenseParmsVer", SqlDbType.Int).Value = Convert.ToInt32(expenseparamtxt.Value);
                }
                if (ratingclasstxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@deRatingClassFacVer", SqlDbType.Int).Value = Convert.ToInt32(ratingclasstxt.Value);
                }
                cmd.Parameters.Add("@AFscheme", SqlDbType.VarChar).Value = AFschemeTypeDropDownList.SelectedItem.ToString();

                cmd.Parameters.Add("@AFschemeType", SqlDbType.VarChar).Value = AFschemeDropDownList.SelectedItem.ToString();

                cmd.Parameters.Add("@BrokerName", SqlDbType.VarChar).Value = brokernametxt.Value;

                if (datevalidtilltxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@DateValidTill", SqlDbType.Date).Value = DateTime.ParseExact(datevalidtilltxt.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (renewalmonthtxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@RenewalMonth", SqlDbType.VarChar).Value = renewalmonthtxt.Value.ToString(); 
                }

                if (nextrenewaldatetxt.Value != string.Empty)
                {
                    cmd.Parameters.Add("@NextRenewalDate", SqlDbType.Date).Value = DateTime.ParseExact(nextrenewaldatetxt.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                cmd.Parameters.Add("@ParticipatingEmployer", SqlDbType.VarChar).Value = participatingemployer.Value;
                cmd.Parameters.Add("@FundName", SqlDbType.VarChar).Value = fundnametxt.Value;
                cmd.Parameters.Add("@FundYearEnd", SqlDbType.VarChar).Value = fundyearend.Value;


                cmd.Connection = connection;
                //connection.Open();
                cmd.ExecuteNonQuery();
                //try
                //{
                //    con.Open();                  
                //  lblMessage.Text = "Record updated successfully";
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
                //finally
                //{
                //    con.Close();
                //    con.Dispose();
                // }   

            }
            //if (ViewState["CommonDiscountSelectedItem"] != null)
            //{
            //    if (CommonDiscountDropDownList.Items.Count != 0)
            //    {
            //        string df = ViewState["CommonDiscountSelectedItem"].ToString(); ;
            //        CommonDiscountDropDownList.SelectedItem.Text = df;

            //    }
            //}

        }
        else
        {


        }




    }
    
    protected void IsSUFquotedropdown_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //protected void iglapatterndropdown_SelectedIndexChanged1(object sender, EventArgs e)
    //{
    //    if (iglapatterndropdown.SelectedItem.ToString().Trim() == "Multiple")
    //    {
    //        iglamultipleText.Visible = true;
    //    }
    //}

    private void BindgvMemberEdit(string Quotenumber)
    {
        using (SqlCommand cmd = new SqlCommand("select * from Member_Input where iQuoteNumber='"+quotenotxt.Text +"'"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                gvmemberEdit.DataSource = ds.Tables[0];
                gvmemberEdit.DataBind();
            }
        }
    }

    protected void btnSubmitDetails_Click(object sender, EventArgs e)
    {
        try
        {


            SqlCommand cmd = new SqlCommand("memberInputSave_procedure", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.Add("@i_QuoteNumber", SqlDbType.Int).Value = "4564";
            //cmd.Parameters.Add("@CategoryNumber", SqlDbType.Int).Value = Convert.ToInt32( 66);
            SqlCommand cmd1 = new SqlCommand("select count(iMemberNumber) from Member_Input where iQuoteNumber='" + quotenotxt.Text + "' AND iCategory=" + txtCategoryNumber.Text.Trim(), connection);
            connection.Open();
            int Membercount = 0;
            if (cmd1.ExecuteScalar() != DBNull.Value)
            {
                 Membercount = Convert.ToInt32(cmd1.ExecuteScalar());
            }           
            connection.Close();
            SqlCommand cmd2 = new SqlCommand("select   iRetAge from  Category_Input  where iCategoryNumber='" + Convert.ToInt32(txtCategoryNumber.Text.Trim()) + "' and iQuoteNumber='"+ Convert.ToInt32(quotenotxt.Text)+"'", connection);
            connection.Open();
            int retage = 0;
            if (cmd2.ExecuteScalar() != DBNull.Value )
            {
                 retage = Convert.ToInt32(cmd2.ExecuteScalar());
            }           
            connection.Close();
            SqlCommand cmd3 = new SqlCommand("select   iPHIescPerc from  Category_Input  where iCategoryNumber='" + Convert.ToInt32(txtCategoryNumber.Text.Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
            connection.Open();
            int phisec = 0;
            if (cmd3.ExecuteScalar() != DBNull.Value)
            {
               phisec = Convert.ToInt32(cmd3.ExecuteScalar()) * 10;
            }           
            connection.Close();
            SqlCommand cmd4 = new SqlCommand("select   iPHIwaitingPeriod from  Category_Input  where iCategoryNumber='" + Convert.ToInt32(txtCategoryNumber.Text.Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
            connection.Open();
            int waiting = 0;
            if (cmd4.ExecuteScalar() != DBNull.Value)
            {
                waiting  = Convert.ToInt32(cmd4.ExecuteScalar());
            } 
             connection.Close();
             SqlCommand cmd5 = new SqlCommand(" select iHasTopUp   from Category_Input where iCategoryNumber='" + Convert.ToInt32(txtCategoryNumber.Text.Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
            connection.Open();
            bool hastopup = false;
            if (cmd5.ExecuteScalar() != DBNull.Value)
            {
                hastopup = Convert.ToBoolean(cmd5.ExecuteScalar());
            }
            connection.Close();
            SqlCommand cmd6 = new SqlCommand(" select iHasTopUp   from Category_Input where iCategoryNumber='" + Convert.ToInt32(txtCategoryNumber.Text.Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
            connection.Open();
            bool hasttd = false;
            if (cmd6.ExecuteScalar() != DBNull.Value)
            {
                hasttd = Convert.ToBoolean(cmd6.ExecuteScalar());
            }            
            cmd.Parameters.Add("@i_QuoteNumber", SqlDbType.Int).Value = Convert.ToInt32(quotenotxt.Text);
            cmd.Parameters.Add("@i_Category", SqlDbType.Int).Value = Convert.ToInt32(txtCategoryNumber.Text.Trim());
            cmd.Parameters.Add("@i_MemberNumber", SqlDbType.Int).Value = Membercount + 1;
            cmd.Parameters.Add("@i_FullName", SqlDbType.VarChar).Value = txtMemberName.Text.Trim();
            int age=0;
            DateTime nextbirthday = DateTime.Today;
            if (txtDOB.Text != string.Empty)
            {
                string strDOB = txtDOB.Text.Substring(0, 10);
                cmd.Parameters.Add("@i_DOB", SqlDbType.DateTime).Value = DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture);
               // int g = DateTime.Now.Subtract(DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture));
               // TimeSpan d =  DateTime.Today.Month - DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture).Month ;
                DateTime today = DateTime.Today;
                 age = today.Year - DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

                 if (DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture) > today.AddYears(-age))
                 {
                     age--;
                 }
                  nextbirthday = DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddYears(age);
               // Double gg = t.TotalDays;
               // birthday = DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddYears(Convert.ToInt32(age + 1));
            }
           

            if (gender.SelectedIndex > 0)
            {
                cmd.Parameters.Add("@i_Gender", SqlDbType.VarChar).Value = gender.SelectedValue;
            }


            if (txtAnnualSalary.Text != string.Empty)
            {
                cmd.Parameters.Add("@i_AnnualSalary", SqlDbType.Decimal).Value = decimal.Parse(txtAnnualSalary.Text, CultureInfo.InvariantCulture);
            }

            if (riskClass.Text != string.Empty)
            {
                cmd.Parameters.Add("@i_RiskClass", SqlDbType.Int).Value = Convert.ToInt32(riskClass.Text);
            }
            //if (txtiImportedValue.Text != string.Empty)
            //{
            //    cmd.Parameters.Add("@i_ImportedAmt", SqlDbType.Decimal).Value = decimal.Parse(txtiImportedValue.Text, CultureInfo.InvariantCulture);
            //}
            if (txtSpouseName.Text != string.Empty)
            {
                cmd.Parameters.Add("@i_SpouseName", SqlDbType.VarChar).Value = txtSpouseName.Text;
            }
            int spouseage = 0;
            if (txtSpouseDOB.Text != string.Empty)
            {
                string strDOBspopuse = txtSpouseDOB.Text.Substring(0, 10);
                cmd.Parameters.Add("@i_DOBspouse", SqlDbType.DateTime).Value = DateTime.ParseExact(strDOBspopuse, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                spouseage = (DateTime.Now).Year - DateTime.ParseExact(strDOBspopuse, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

                if (DateTime.ParseExact(strDOBspopuse, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.Now).AddYears(-spouseage))
                {
                    spouseage--;
                }

            }
            if (Select6.SelectedIndex > 0)
            {
                cmd.Parameters.Add("@i_GenderSpouse", SqlDbType.VarChar).Value = Select6.SelectedValue;
            }
            if (txtGLALoading.Text != string.Empty)
            {
                cmd.Parameters.Add("@i_LoadingGLA", SqlDbType.Decimal).Value = decimal.Parse(txtGLALoading.Text, CultureInfo.InvariantCulture);
            }
            if (txtCIILoading.Text != string.Empty)
            {
                cmd.Parameters.Add("@i_LoadingCII", SqlDbType.Decimal).Value = decimal.Parse(txtCIILoading.Text, CultureInfo.InvariantCulture);
            }
            if (txtPHILoading.Text != string.Empty)
            {
                cmd.Parameters.Add("@i_LoadingPHI", SqlDbType.Decimal).Value = decimal.Parse(txtPHILoading.Text, CultureInfo.InvariantCulture);
            }
            if (txtGOALoading.Text != string.Empty)
            {
                cmd.Parameters.Add("@i_LoadingPTD", SqlDbType.Decimal).Value = decimal.Parse(txtGOALoading.Text, CultureInfo.InvariantCulture);
            }
              cmd.Parameters.Add("@dePHIsalFactorsKey", SqlDbType.Int).Value =1;
              if (Convert.ToInt32(riskClass.Text) > 21 || riskClass.Text == null)
              {
                  cmd.Parameters.Add("@DeRatingClassFacKey", SqlDbType.Int).Value = 13;
              }
              else
              {
                  cmd.Parameters.Add("@DeRatingClassFacKey", SqlDbType.Int).Value = Convert.ToInt32(" 1" + (riskClass.Text));
              }
              cmd.Parameters.Add("@DeRegionFactorsKey", SqlDbType.VarChar).Value = "1" + ProvinceDropDown.SelectedItem.ToString();
              cmd.Parameters.Add("@DeGLAsalIndGenFacKey", SqlDbType.VarChar).Value = "1" + IndustryDropDown.SelectedItem.ToString();
              if (gender.SelectedItem.ToString() != "Please Select")
              {
                  cmd.Parameters.Add("@DeGenderFactorsKey", SqlDbType.VarChar).Value = "1" + gender.SelectedValue;
              }
              else
              {
                  cmd.Parameters.Add("@DeGenderFactorsKey", SqlDbType.VarChar).Value = "1male";
              }
              if (Select6.SelectedItem.ToString() != "Please Select")
              {
                  cmd.Parameters.Add("@DeSpousesGenderFacKey", SqlDbType.VarChar).Value = "1" + Select6.SelectedValue.ToString();
              }
              else
              {
                    cmd.Parameters.Add("@DeSpousesGenderFacKey", SqlDbType.VarChar).Value ="1female";
              }
              if (age < 17 || age > 70)
              {
                  cmd.Parameters.Add("@DeAgeFactorsKey", SqlDbType.Int).Value = 151;
              }
              else
              {
                  cmd.Parameters.Add("@DeAgeFactorsKey", SqlDbType.Int).Value = Convert.ToInt32("1" + (age + 1));
              }
              if (spouseage < 17 || spouseage > 70)
              {
                  cmd.Parameters.Add("@DeSpousesAgeFactorsKey", SqlDbType.Int).Value = 148;

              }
              else
              {
                  cmd.Parameters.Add("@DeSpousesAgeFactorsKey", SqlDbType.Int).Value = Convert.ToInt32("1" + (spouseage + 1));
              }
              if (hasttd)
              {
                  if (gender.SelectedValue.ToString() == "male")
                  {
                      cmd.Parameters.Add("@deTTDrates", SqlDbType.Int).Value = 110016;
                  }
                  else
                  {
                      cmd.Parameters.Add("@deTTDrates", SqlDbType.Int).Value = 110116;
                  }
              }
              else
              {
                  cmd.Parameters.Add("@deTTDrates", SqlDbType.Int).Value = 110016;
              }
             
              if (gender.SelectedValue.ToString() == "male")
              {
                  cmd.Parameters.Add("@DePHIgenNRAescWPfacKey", SqlDbType.VarChar).Value ="1100" + retage.ToString() + phisec.ToString() + waiting.ToString();
              }
              else if (gender.SelectedValue.ToString() == "female")
              {
                  cmd.Parameters.Add("@DePHIgenNRAescWPfacKey", SqlDbType.VarChar).Value = "1101" + retage.ToString() + phisec.ToString() + waiting.ToString();
              }
              else
              {
                  cmd.Parameters.Add("@DePHIgenNRAescWPfacKey", SqlDbType.VarChar).Value = "110065503";
              }
              if (hastopup)
              {
                  cmd.Parameters.Add("@deTopUpRatesKey", SqlDbType.Int).Value = Convert.ToInt32("1" + waiting.ToString() + phisec.ToString() + (age + 1).ToString());
              }
              else
              {
                  cmd.Parameters.Add("@deTopUpRatesKey", SqlDbType.Int).Value = 135051;
              }
         

            
            cmd.ExecuteNonQuery();
            connection.Close();
            BindgvMemberEdit(hidquoteNo.Value);
        }
        catch (SqlException ex)
        {
            throw ex;
        }

    }


    private void Import_To_Grid(string FilePath, string Extension, string p)
    {
        try
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                             .ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                              .ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, p);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            DataTable dt1 = new DataTable();
            //DataTable dt2 = new DataTable();
            foreach (DataRow row in dt.Rows)
            {
                if (row.ItemArray != null)
                {
                    if (!(!row.ItemArray.All(x => x == null || (x != null && string.IsNullOrWhiteSpace(x.ToString())))))
                    {
                        row.Delete();
                    }
                    //if (row != null)
                    //{
                    //    foreach (var value in row.ItemArray)
                    //    {
                    //        if (value != null)
                    //        {
                    //            dt2.ImportRow(row);
                    //            break;
                    //        }
                    //    }
                        
                    //}
                  
                  
                }
            }
            dt.AcceptChanges();
          //  oda.Fill(dt);
            
            connExcel.Close();
            Session["Table"] = dt;
            //Bind Data to GridView
            //gvmemberList.Caption = Path.GetFileName(FilePath);
            gvmemberList.DataSource = dt;
            gvmemberList.DataBind();
        }
        catch (OleDbException ex) { throw ex; }
    }



    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (uploadFile.HasFile)
        {
            divMemberList.Visible = true;
            if (rbtnSelectExistingMembers.SelectedValue == "0")
            {
                string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
                string Extension = Path.GetExtension(uploadFile.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);
                uploadFile.SaveAs(FilePath);
                Import_To_Grid(FilePath, Extension, "Yes");
            }
            else
            {
                string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
                string Extension = Path.GetExtension(uploadFile.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);
                uploadFile.SaveAs(FilePath);
                Append_To_Grid(FilePath, Extension, "Yes");
            }
        }

    }

    private void Append_To_Grid(string FilePath, string Extension, string p)
    {
        try
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                             .ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                              .ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, p);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            DataTable dt1 = new DataTable();          
            foreach (DataRow row in dt.Rows)
                if (row.ItemArray != null)
                    if (!(!row.ItemArray.All(x => x == null || (x != null && string.IsNullOrWhiteSpace(x.ToString())))))
                    {
                        row.Delete();
                    }
                    //if (row == null)
                    //{
                    //    dt2.Rows.Add(row);
                    //}
                    //else
                    //{
                    //    foreach(var value in row.ItemArray)
                    //    {
                    //     if (value != null)
                    //     {
                    //       dt2.Rows.Add(row);
                    //     }
                    //    }                                             
                    //}
            dt.AcceptChanges();
            connExcel.Close();
            dt1 = (DataTable)Session["Table"];
            if (dt1.Rows.Count > 0)
            {
                dt1.Merge(dt);
                Session["Table"] = dt1;
                //Bind Data to GridView
                //gvmemberList.Caption = Path.GetFileName(FilePath);
                gvmemberList.DataSource = dt1;
                gvmemberList.DataBind();
            }

        }
        catch (OleDbException ex) { throw ex; }
    }
    protected void gvmemberList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvmemberList.PageIndex = e.NewPageIndex;
        gvmemberList.DataSource = (DataTable)Session["Table"];
        gvmemberList.DataBind();
    }

    //protected void gvmemberList_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Edit")
    //    {
    //        //int QuoteNumber= (int)e.CommandArgument;
    //        Button btn = (Button)e.CommandSource;
    //        GridViewRow grdrow = ((GridViewRow)btn.NamingContainer);
    //        Label iFullName = (Label)grdrow.FindControl("lbliFullName");
    //        txtMemberName.Text = iFullName.Text;
    //        Label iDOB = (Label)grdrow.FindControl("lbliDOB");
    //        txtDOB.Text = iDOB.Text;
    //        Label iGender = (Label)grdrow.FindControl("lbliGender");
    //        string strGender = iGender.Text.Trim();
    //        if (strGender.ToLower() == "f")
    //            gender.SelectedItem.Text = "female";
    //        else if (strGender.ToLower() == "m")
    //            gender.SelectedItem.Text = "male";
    //        Label iAnnualSalary = (Label)grdrow.FindControl("lbliAnnualSalary");
    //        txtAnnualSalary.Text = iAnnualSalary.Text;
    //        Label icategoryNumber = (Label)grdrow.FindControl("lbliCategory");
    //        txtCategoryNumber.Text = icategoryNumber.Text;
    //        Label iriskClass = (Label)grdrow.FindControl("lbliRiskClass");
    //        riskClass.Text = iriskClass.Text;
    //        Label iImportedValue = (Label)grdrow.FindControl("lbliImportedValue");
    //        txtiImportedValue.Text = iImportedValue.Text;
    //        Label iSpouseName = (Label)grdrow.FindControl("lbliSpouseName");
    //        txtSpouseName.Text = iSpouseName.Text;
    //        Label iDOBspouse = (Label)grdrow.FindControl("lbliDOBspouse");
    //        txtSpouseDOB.Text = iDOBspouse.Text;
    //        Label iGenderSpouse = (Label)grdrow.FindControl("lbliGenderSpouse");
    //        string strSGender = iGenderSpouse.Text.Trim();
    //        if (strSGender.ToLower() == "f")
    //            gender.SelectedItem.Text = "female";
    //        else if (strSGender.ToLower() == "m")
    //            gender.SelectedItem.Text = "male";
    //        Label lbliLoadingGLA = (Label)grdrow.FindControl("lbliLoadingGLA");
    //        txtGLALoading.Text = lbliLoadingGLA.Text;
    //        Label lbliLoadingCII = (Label)grdrow.FindControl("lbliLoadingCII");
    //        txtCIILoading.Text = lbliLoadingCII.Text;
    //        Label lbliLoadingPHI = (Label)grdrow.FindControl("lbliLoadingPHI");
    //        txtPHILoading.Text = lbliLoadingPHI.Text;
    //        Label lbliLoadingPTD = (Label)grdrow.FindControl("lbliLoadingPTD");
    //        txtGOALoading.Text = lbliLoadingPTD.Text;
    //    }

    //}
    protected void gvmemberList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvmemberList.EditIndex = e.NewEditIndex;
        DataTable dtTable = new DataTable();
        dtTable = (DataTable)Session["Table"];
        gvmemberList.DataSource = dtTable;
        gvmemberList.DataBind();
        // Page.ClientScript.RegisterStartupScript(GetType(), "Script", "javscript:setvisiblediv('addMember');");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DataTable dtTable = new DataTable();
        Session["Table"] = dtTable;
        gvmemberList.DataSource = dtTable;
        gvmemberList.DataBind();
        //Page.ClientScript.RegisterStartupScript(GetType(), "Script", "javscript:Hidediv('cancelAccept');");
        divMemberList.Visible = false;
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtTable = new DataTable();
            dtTable = (DataTable)Session["Table"];
            connection.Close();
            int f = dtTable.Rows.Count;
            foreach (DataColumn col in dtTable.Columns)
            {
                col.ColumnName = col.ColumnName.Trim();
            }
               
            foreach (DataRow dr in dtTable.Rows)
            {
                SqlCommand cmd = new SqlCommand("memberInputSave_procedure", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.Add("@i_QuoteNumber", SqlDbType.Int).Value = "4564";
                //cmd.Parameters.Add("@CategoryNumber", SqlDbType.Int).Value = Convert.ToInt32( 66);iCategory,iCategory
                int cc = dtTable.Columns.IndexOf(@"iCategory");
               // int dd = Convert.ToInt32(dr[cc]);
                //SqlCommand cmd1 = new SqlCommand("select count(iMemberNumber) from Member_Input where iQuoteNumber='" + quotenotxt.Text + "' AND iCategory='"+ Convert.ToInt32(dr["iCategory"])+"'", connection);

                //connection.Open();
                //int Membercount = Convert.ToInt32(cmd1.ExecuteScalar());
               SqlCommand cmd1 = new SqlCommand("select count(iMemberNumber) from Member_Input where iQuoteNumber='" + quotenotxt.Text + "' AND iCategory=" + dr[cc].ToString().Trim(), connection);
                connection.Open();
                int Membercount = 0;
                if (cmd1.ExecuteScalar() != DBNull.Value)
                {
                    Membercount = Convert.ToInt32(cmd1.ExecuteScalar());
                }
                connection.Close();
                SqlCommand cmd2 = new SqlCommand("select   iRetAge from  Category_Input  where iCategoryNumber='" + Convert.ToInt32(dr[cc].ToString().Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
                connection.Open();
                int retage = 0;
                if (cmd2.ExecuteScalar() != DBNull.Value)
                {
                    retage = Convert.ToInt32(cmd2.ExecuteScalar());
                }
                connection.Close();
                SqlCommand cmd3 = new SqlCommand("select   iPHIescPerc from  Category_Input  where iCategoryNumber='" + Convert.ToInt32(dr[cc].ToString().Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
                connection.Open();
                int phisec = 0;
                if (cmd3.ExecuteScalar() != DBNull.Value)
                {
                    phisec = Convert.ToInt32(cmd3.ExecuteScalar()) * 10;
                }
                connection.Close();
                SqlCommand cmd4 = new SqlCommand("select   iPHIwaitingPeriod from  Category_Input  where iCategoryNumber='" + Convert.ToInt32(dr[cc].ToString().Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
                connection.Open();
                int waiting = 0;
                if (cmd4.ExecuteScalar() != DBNull.Value)
                {
                    waiting = Convert.ToInt32(cmd4.ExecuteScalar());
                }
                connection.Close();
                SqlCommand cmd5 = new SqlCommand(" select iHasTopUp   from Category_Input where iCategoryNumber='" + Convert.ToInt32(dr[cc].ToString().Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
                connection.Open();
                bool hastopup = false;
                if (cmd5.ExecuteScalar() != DBNull.Value)
                {
                    hastopup = Convert.ToBoolean(cmd5.ExecuteScalar());
                }
                connection.Close();
                SqlCommand cmd6 = new SqlCommand(" select iHasTopUp   from Category_Input where iCategoryNumber='" + Convert.ToInt32(dr[cc].ToString().Trim()) + "' and iQuoteNumber='" + Convert.ToInt32(quotenotxt.Text) + "'", connection);
                connection.Open();
                bool hasttd = false;
                if (cmd6.ExecuteScalar() != DBNull.Value)
                {
                    hasttd = Convert.ToBoolean(cmd6.ExecuteScalar());
                }            


                cmd.Parameters.Add("@i_QuoteNumber", SqlDbType.Int).Value = Convert.ToInt32(quotenotxt.Text);
                cmd.Parameters.Add("@i_Category", SqlDbType.Int).Value = Convert.ToInt32(dr[cc].ToString());
                cmd.Parameters.Add("@i_MemberNumber", SqlDbType.Int).Value = Membercount + 1;
                cmd.Parameters.Add("@i_FullName", SqlDbType.VarChar).Value = dr["iFullName"].ToString();
                DateTime nextbirthday = DateTime.Today;
                int age = 0;
                if (dr["iDOB"].ToString() != string.Empty)
                {
                    string strDOB = dr["iDOB"].ToString().Substring(0,9);

                    string[] dat = strDOB.Split('/');
                    if (dat[0].Length < 2)
                    {
                        dat[0] ="0"+dat[0].ToString();
                    }
                    if (dat[1].Length < 2)
                    {
                        dat[1] = "0" + dat[1].ToString();
                    }
                    string formatteddate=string.Empty;
                    foreach (string ff in dat)
                    {
                        formatteddate = formatteddate +"/"+ ff;
                    }
                    formatteddate = formatteddate.Remove(0,1);
                    cmd.Parameters.Add("@i_DOB", SqlDbType.Date).Value = Convert.ToDateTime(formatteddate);
                   // cmd.Parameters.Add("@i_DOB", SqlDbType.Date).Value = DateTime.ParseExact(formatteddate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    // int g = DateTime.Now.Subtract(DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    // TimeSpan d =  DateTime.Today.Month - DateTime.ParseExact(strDOB, "dd/MM/yyyy", CultureInfo.InvariantCulture).Month ;
                    DateTime today = DateTime.Today;
                    age = today.Year - Convert.ToDateTime(formatteddate).Year;

                    if (Convert.ToDateTime(formatteddate) > today.AddYears(-age))
                    {
                        age--;
                    }
                    nextbirthday = Convert.ToDateTime(formatteddate).AddYears(age);                        
                    //, "mm/dd/yyyy", CultureInfo.InvariantCulture);
                }
                if (dr["iGender"].ToString() != string.Empty)
                {
                         if(dr["iGender"].ToString() =="F" || dr["iGender"].ToString()=="Female" || dr["iGender"].ToString()=="female")
                         {
                              cmd.Parameters.Add("@i_Gender", SqlDbType.VarChar).Value ="female";
                         }

                         else if(dr["iGender"].ToString() =="M"  || dr["iGender"].ToString() =="Male" ||  dr["iGender"].ToString()=="male")
                         {
                              cmd.Parameters.Add("@i_Gender", SqlDbType.VarChar).Value ="male";
                         }
                                        
                   
                }
                if (dr["iAnnualSalary"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@i_AnnualSalary", SqlDbType.Decimal).Value = decimal.Parse(dr["iAnnualSalary"].ToString(), CultureInfo.InvariantCulture);
                }

                if (dr["iRiskClass"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@i_RiskClass", SqlDbType.Int).Value = Convert.ToInt32(dr["iRiskClass"].ToString());
                }
                if (dr["iImportedValue"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@i_ImportedAmt", SqlDbType.Decimal).Value = decimal.Parse(dr["iImportedValue"].ToString(), CultureInfo.InvariantCulture);
                }
                if (dr["iSpouseName"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@i_SpouseName", SqlDbType.VarChar).Value = dr["iSpouseName"].ToString();
                }
                int spouseage = 0;
                if (dr["iDOBspouse"].ToString() != string.Empty)
                {
                    string strDOBspopuse = dr["iDOBspouse"].ToString().Substring(0, 9);
                    cmd.Parameters.Add("@i_DOBspouse", SqlDbType.Date).Value = Convert.ToDateTime(strDOBspopuse);
                    spouseage = (DateTime.Now).Year - Convert.ToDateTime(strDOBspopuse).Year;
                    
                    if (Convert.ToDateTime(strDOBspopuse) > (DateTime.Now).AddYears(-spouseage))
                    {
                        spouseage--;
                    }                   
                }
                if (dr["iGenderSpouse"].ToString() != string.Empty)
                {


                    if (dr["iGenderSpouse"].ToString() == "F" || dr["iGenderSpouse"].ToString() == "Female" || dr["iGenderSpouse"].ToString() == "female")
                    {
                        cmd.Parameters.Add("@i_GenderSpouse", SqlDbType.VarChar).Value = "female";
                    }

                    else if (dr["iGenderSpouse"].ToString() == "M" || dr["iGenderSpouse"].ToString() == "Male" || dr["iGenderSpouse"].ToString() == "male")
                    {
                        cmd.Parameters.Add("@i_GenderSpouse", SqlDbType.VarChar).Value = "male";
                    }
                   
                }
                if (dr["iLoadingGLA"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@i_LoadingGLA", SqlDbType.Decimal).Value = decimal.Parse(dr["iLoadingGLA"].ToString(), CultureInfo.InvariantCulture);
                }
                if (dr["iLoadingCII"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@i_LoadingCII", SqlDbType.Decimal).Value = decimal.Parse(dr["iLoadingCII"].ToString(), CultureInfo.InvariantCulture);
                }
                 if (dr["iLoadingPHI"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@i_LoadingPHI", SqlDbType.Decimal).Value = decimal.Parse(dr["iLoadingPHI"].ToString(), CultureInfo.InvariantCulture);
                }
                if (dr["iLoadingPTD"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@i_LoadingPTD", SqlDbType.Decimal).Value = decimal.Parse(dr["iLoadingPTD"].ToString(), CultureInfo.InvariantCulture);
                }


                cmd.Parameters.Add("@dePHIsalFactorsKey", SqlDbType.Int).Value = 1;
                if (Convert.ToInt32(dr["iRiskClass"].ToString()) > 21 || dr["iRiskClass"].ToString() == null)
                {
                    cmd.Parameters.Add("@DeRatingClassFacKey", SqlDbType.Int).Value = 13;
                }
                else
                {
                    cmd.Parameters.Add("@DeRatingClassFacKey", SqlDbType.Int).Value = Convert.ToInt32(" 1" + (dr["iRiskClass"].ToString()));
                }
                cmd.Parameters.Add("@DeRegionFactorsKey", SqlDbType.VarChar).Value = "1" + ProvinceDropDown.SelectedItem.ToString();
                cmd.Parameters.Add("@DeGLAsalIndGenFacKey", SqlDbType.VarChar).Value = "1" + IndustryDropDown.SelectedItem.ToString();
                if (dr["iGender"].ToString() != string.Empty) 
                {
                    cmd.Parameters.Add("@DeGenderFactorsKey", SqlDbType.VarChar).Value = "1" + (dr["iGender"].ToString());
                }
                else
                {
                    cmd.Parameters.Add("@DeGenderFactorsKey", SqlDbType.VarChar).Value = "1male";
                }
                if (dr["iGenderSpouse"].ToString() != string.Empty)
                {
                    cmd.Parameters.Add("@DeSpousesGenderFacKey", SqlDbType.VarChar).Value = "1" + dr["iGenderSpouse"].ToString();
                }
                else
                {
                    cmd.Parameters.Add("@DeSpousesGenderFacKey", SqlDbType.VarChar).Value = "1female";
                }
                if (age < 17 || age > 70)
                {
                    cmd.Parameters.Add("@DeAgeFactorsKey", SqlDbType.Int).Value = 151;
                }
                else
                {
                    cmd.Parameters.Add("@DeAgeFactorsKey", SqlDbType.Int).Value = Convert.ToInt32("1" + (age + 1));
                }
                if (spouseage < 17 || spouseage > 70)
                {
                    cmd.Parameters.Add("@DeSpousesAgeFactorsKey", SqlDbType.Int).Value = 148;

                }
                else
                {
                    cmd.Parameters.Add("@DeSpousesAgeFactorsKey", SqlDbType.Int).Value = Convert.ToInt32("1" + (spouseage + 1));
                }
                if (hasttd)
                {
                    if (gender.SelectedValue.ToString() == "male")
                    {
                        cmd.Parameters.Add("@deTTDrates", SqlDbType.Int).Value = 110016;
                    }
                    else
                    {
                        cmd.Parameters.Add("@deTTDrates", SqlDbType.Int).Value = 110116;
                    }
                }
                else
                {
                    cmd.Parameters.Add("@deTTDrates", SqlDbType.Int).Value = 110016;
                }


                if (gender.SelectedValue.ToString() == "male")
                {
                    cmd.Parameters.Add("@DePHIgenNRAescWPfacKey", SqlDbType.VarChar).Value = "1100" + retage.ToString() + phisec.ToString() + waiting.ToString();
                }
                else if (gender.SelectedValue.ToString() == "female")
                {
                    cmd.Parameters.Add("@DePHIgenNRAescWPfacKey", SqlDbType.VarChar).Value = "1101" + retage.ToString() + phisec.ToString() + waiting.ToString();
                }
                else
                {
                    cmd.Parameters.Add("@DePHIgenNRAescWPfacKey", SqlDbType.VarChar).Value = "110065503";
                }
                if (hastopup)
                {
                    cmd.Parameters.Add("@deTopUpRatesKey", SqlDbType.Int).Value = Convert.ToInt32("1" + waiting.ToString() + phisec.ToString() + (age + 1).ToString());
                }
                else
                {
                    cmd.Parameters.Add("@deTopUpRatesKey", SqlDbType.Int).Value = 135051;
                }
         


                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }

        divMemberList.Visible = false;
        BindgvMemberEdit(quotenotxt.Text);

    }
    protected void gvmemberList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DataTable dt = (DataTable)Session["Table"];

        DataRow dr = dt.Rows[e.RowIndex];

        dt.Rows.Remove(dr);

        gvmemberList.EditIndex = -1;
        gvmemberList.DataSource = dt;
        Session["Table"] = dt;
        gvmemberList.DataBind();

    }

    protected void gvmemberEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvmemberEdit.PageIndex = e.NewPageIndex;
        BindgvMemberEdit(quotenotxt.Text);
    }

    protected void gvmemberEdit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //DataTable dt = (DataTable)Session["Table"];

        //DataRow dr = dt.Rows[e.RowIndex];

        //dt.Rows.Remove(dr);
        string quoteno = gvmemberEdit.DataKeys[e.RowIndex].Values["iQuoteNumber"].ToString();
        string categoryno = gvmemberEdit.DataKeys[e.RowIndex].Values["iCategory"].ToString();
        string member_id = gvmemberEdit.DataKeys[e.RowIndex].Values["Member_ID"].ToString();
        connection.Open();
        SqlCommand cmd = new SqlCommand("delete from Member_Input where Member_ID=" + member_id, connection);
        int result = cmd.ExecuteNonQuery();
        connection.Close();
        if (result == 1)
        {
            BindgvMemberEdit(quoteno.ToString());

        }

        gvmemberEdit.DataBind();
    }

    protected void gvmemberEdit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvmemberList.EditIndex = e.NewEditIndex;
        BindgvMemberEdit(hidquoteNo.Value);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // string VGG;
    }
    # endregion

    protected void HasGLAcheck1_DataBinding(object sender, EventArgs e)
    {

        CheckBox ck = (CheckBox)(sender);


        //     // Now that the items are all there, set the selected property
        bool ff = Eval("iIndustry").ToString() != string.Empty ? Convert.ToBoolean(Eval("iHasNBComm")) : false;
        ck.Checked = ff;
    }

    protected void testrepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int q = (e.Item.ItemIndex) + 1;
        ((Label)e.Item.FindControl("categorylabel")).Text = ("Category" + q).ToString();
         DataTable dt = new DataTable();
            dt = (DataTable)testrepeater.DataSource;
        int itemcount=testrepeater.Items.Count;
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGLApattern'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);           
             int c=dt.Columns.IndexOf("iGLApattern");           
            if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("iglapatterndropdown")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("iglapatterndropdown")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("iglapatterndropdown")).DataBind();
                
                //li=( ListItem)((DropDownList)e.Item.FindControl("iglapatterndropdown")).DataSource;

                for(int i=0;i<=itemcount;i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();
                    
                         foreach (ListItem lii in  ((DropDownList)e.Item.FindControl("iglapatterndropdown")).Items)
                          {
                             lii.Selected = false;
                             if (lii.Value == dt.Rows[i][c].ToString())
                             {
                              lii.Selected = true;
                             }
                         }
    
                }
                // dropDo)wnList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iAccidentBenType'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            int c = dt.Columns.IndexOf("iAccBenType");
                                    
            if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("AccidentbentypeDrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("AccidentbentypeDrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("AccidentbentypeDrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("AccidentbentypeDrop")).Items)
                    {
                        lii.Selected = false;
                        if (lii.Value == dt.Rows[i][c].ToString())
                        {
                            lii.Selected = true;
                        }
                    }

                }
               
                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iGOApattern'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iPTDpattern");
            if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("PTDpatterndrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("PTDpatterndrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("PTDpatterndrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("PTDpatterndrop")).Items)
                    {
                        lii.Selected = false;
                        if (lii.Value == dt.Rows[i][c].ToString())
                        {
                            lii.Selected = true;
                        }
                    }

                }
               
                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iSRmultiple'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iSRmultiple");
            if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("SRmultipledrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("SRmultipledrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("SRmultipledrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("SRmultipledrop")).Items)
                    {
                        lii.Selected = false;
                        if (dt.Rows[i][c] != System.DBNull.Value)
                        {
                        if ((lii.Value).Trim() == (Convert.ToDouble(dt.Rows[i][c])).ToString())
                        {
                            lii.Selected = true;
                        }
                        }
                    }

                }

                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iPHIwaiverPattern'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iPHIwaiverPattern");
            if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("iPHIwaiverPatterndrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("iPHIwaiverPatterndrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("iPHIwaiverPatterndrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("iPHIwaiverPatterndrop")).Items)
                    {
                        lii.Selected = false;
                        if (dt.Rows[i][c] != System.DBNull.Value)
                        {
                            if ((lii.Value).Trim() == dt.Rows[i][c].ToString().Trim())
                            {
                                lii.Selected = true;
                            }
                        }
                    }

                }

                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();
        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name ='iCIIpattern'"))
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        iCIIpatterntxtdrop.DataSource = ds.Tables[0];
        //        iCIIpatterntxtdrop.DataTextField = "Value";
        //        iCIIpatterntxtdrop.DataBind();

        //    }
        //}
        //if (iCIIpatterntxtdropdown.SelectedItem.ToString() == "Flat")
        //{
        //    cmd.Parameters.Add("@iCIIisFlatAmt", SqlDbType.Bit).Value = true;
        //}
        //else if (iCIIpatterntxtdropdown.SelectedItem.ToString() == "Multiple")
        //{
        //    cmd.Parameters.Add("@iCIIisFlatAmt", SqlDbType.Bit).Value = false;
        //}

        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iCIIpattern'"))
        //{
        //    connection = new SqlConnection();
        //    connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;

        //    connection.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    int c = dt.Columns.IndexOf("iCIIisFlatAmt");
        //    if (e.Item.ItemType == ListItemType.Item ||
        // e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        ((DropDownList)e.Item.FindControl("iCIIpatterntxtdrop")).DataSource = ds.Tables[0];
        //        ((DropDownList)e.Item.FindControl("iCIIpatterntxtdrop")).DataTextField = "Value";//Or any other datasource.
        //        ((DropDownList)e.Item.FindControl("iCIIpatterntxtdrop")).DataBind();
        //        for (int i = 0; i <= itemcount; i++)
        //        {
        //            //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

        //            //foreach (ListItem lii in ((DropDownList)e.Item.FindControl("iCIIpatterntxtdrop")).Items)
        //          //  {
        //               // lii.Selected = false;
        //                if ( dt.Rows[i][c].ToString()== "true")
        //                {
        //                     ((DropDownList)e.Item.FindControl("iCIIpatterntxtdrop")).SelectedItem.e
        //                }
        //          //  }

        //        }
        //        // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
        //    }


        //}
        //connection.Close();


        

        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iPHIscaleType'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iPHIscaleType");
            if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("PHIscaleTypedrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("PHIscaleTypedrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("PHIscaleTypedrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("PHIscaleTypedrop")).Items)
                    {
                        lii.Selected = false;
                        if (lii.Value == dt.Rows[i][c].ToString())
                        {
                            lii.Selected = true;
                        }
                    }

                }
                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();

        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iPHIwaitingPeriod'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iPHIwaitingPeriod");
            if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("PHIwaitingPerioddrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("PHIwaitingPerioddrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("PHIwaitingPerioddrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("PHIwaitingPerioddrop")).Items)
                    {
                        lii.Selected = false;
                        
                        if (lii.Value == dt.Rows[i][c].ToString())
                        {
                            lii.Selected = true;
                        }
                    }
                }
                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();

        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iCIItype'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iCIItype");
            if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("iCIItypedrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("iCIItypedrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("iCIItypedrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("iCIItypedrop")).Items)
                    {
                        lii.Selected = false;
                        if (lii.Value == dt.Rows[i][c].ToString())
                        {
                            lii.Selected = true;
                        }
                    }

                }
                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();


        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iTTDwpPP'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iTTDwpPP");
            if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("iTTDwpPPdrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("iTTDwpPPdrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("iTTDwpPPdrop")).DataBind();
                //for (int i = 0; i <= itemcount; i++)
                //{
                //    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                //    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("iTTDwpPPdrop")).Items)
                //    {
                //        lii.Selected = false;
                //        if (lii.Value == dt.Rows[i][c].ToString())
                //        {
                //            lii.Selected = true;
                //        }
                //    }

                //}
                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();
        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iTTDwaiverPattern'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iTTDwaiverPattern");
            if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("iTTDwaiverPatterndrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("iTTDwaiverPatterndrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("iTTDwaiverPatterndrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("iTTDwaiverPatterndrop")).Items)
                    {
                        lii.Selected = false;
                        if (lii.Value == dt.Rows[i][c].ToString())
                        {
                            lii.Selected = true;
                        }
                    }

                }
                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();

        using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iSGLApattern'"))
        {
            connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            int c = dt.Columns.IndexOf("iSGLAisFlatAmt");
            if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ((DropDownList)e.Item.FindControl("iSGLApatterndrop")).DataSource = ds.Tables[0];
                ((DropDownList)e.Item.FindControl("iSGLApatterndrop")).DataTextField = "Value";//Or any other datasource.
                ((DropDownList)e.Item.FindControl("iSGLApatterndrop")).DataBind();
                for (int i = 0; i <= itemcount; i++)
                {
                    //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

                    foreach (ListItem lii in ((DropDownList)e.Item.FindControl("iSGLApatterndrop")).Items)
                    {
                        lii.Selected = false;
                        if ((dt.Rows[i][c].ToString()).Trim() =="true" & lii.Value.ToString()=="Flat")
                        {
                            lii.Selected = true;
                        }
                        else if ((dt.Rows[i][c].ToString()).Trim() == "false" & lii.Value.ToString() == "Multiple")
                        {
                            lii.Selected = true;
                        }
                    }

                }
                // dropDow
                // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
            }


        }
        connection.Close();

        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iCIIpattern'"))
        //{
        //    connection = new SqlConnection();
        //    connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;

        //    connection.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    int c = dt.Columns.IndexOf("iCIIpattern");
        //    if (e.Item.ItemType == ListItemType.Item ||
        //    e.Item.ItemType == ListItemType.AlternatingItem)
        //    {

        //        ((DropDownList)e.Item.FindControl("CIIpatterntxtdrop")).DataSource = ds.Tables[0];
        //        ((DropDownList)e.Item.FindControl("CIIpatterntxtdrop")).DataTextField = "Value";//Or any other datasource.
        //        ((DropDownList)e.Item.FindControl("CIIpatterntxtdrop")).DataBind();
        //        for (int i = 0; i <= itemcount; i++)
        //        {
        //            //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

        //            foreach (ListItem lii in ((DropDownList)e.Item.FindControl("CIIpatterntxtdrop")).Items)
        //            {
        //                lii.Selected = false;
        //                if ((lii.Value).Trim() == (dt.Rows[i][c].ToString()).Trim())
        //                {
        //                    lii.Selected = true;
        //                }
        //            }

        //        }
        //        // dropDow
        //        // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
        //    }


        //}
        //connection.Close();
        //using (SqlCommand cmd = new SqlCommand("select * from Lookup_lists where Field_Name='iSPTDpattern'"))
        //{
        //    connection = new SqlConnection();
        //    connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = connection;

        //    connection.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    int c = dt.Columns.IndexOf("iSPTDpattern");
        //    if (e.Item.ItemType == ListItemType.Item ||
        //    e.Item.ItemType == ListItemType.AlternatingItem)
        //    {

        //        ((DropDownList)e.Item.FindControl("iSPTDpatterndrop")).DataSource = ds.Tables[0];
        //        ((DropDownList)e.Item.FindControl("iSPTDpatterndrop")).DataTextField = "Value";//Or any other datasource.
        //        ((DropDownList)e.Item.FindControl("iSPTDpatterndrop")).DataBind();

        //        for (int i = 0; i <= itemcount; i++)
        //        {
        //            //((DropDownList)e.Item.FindControl("iglapatterndropdown")). = dt.Rows[i][c].ToString();

        //            foreach (ListItem lii in ((DropDownList)e.Item.FindControl("iSPTDpatterndrop")).Items)
        //            {
        //                lii.Selected = false;
        //                if (lii.Value == dt.Rows[i][c].ToString())
        //                {
        //                    lii.Selected = true;
        //                }
        //            }

        //        }
        //        // dropDownList.SelectedIndexChanged += DropDownListSelectedIndexChanged;
        //    }


        //}
        //connection.Close();

    }
   
    protected void testrepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        //DropDownList MyList = (DropDownList)e.Item.FindControl("iglapatterndropdown");
        //MyList.SelectedIndexChanged += iglapatterndropdown_SelectedIndexChanged;
    }

    protected void savecategorybtn_Click(object sender, EventArgs e)
    {
        updatecategory();

        BindRepeaterData();
        ////////////////////////////////       
        //TextBox iglamultipleTexbox = (TextBox)item.FindControl("iglamultipleText");

    }

    protected void addctgrybtn_Click(object sender, EventArgs e)
    {
        //DataTable dt = new DataTable();

        //dt = (DataTable)testrepeater.DataSource;
        //DataRow ddr = dt.NewRow();
        //dt.Rows.Add(ddr);

        //int c = dt.Rows.Count;
        ////dt.Columns.Add("NewColumn", typeof(System.Nullable));            
        //int widthh = c * 260;
        //divconetnet.Attributes["style"] = " width:" + widthh + "px; overflow-x: scroll; display: inline-table;";        
        //testrepeater.DataSource = dt;
        //testrepeater.DataBind();
        if (quotenotxt.Text != string.Empty)
        {


            SqlCommand cmd1 = new SqlCommand("select count(iCategoryNumber) from Category_Input where iQuoteNumber='" + quotenotxt.Text + "'", connection);
            connection.Open();
            int countofpreviouscategoris = Convert.ToInt32(cmd1.ExecuteScalar());
            connection.Close();
            if (countofpreviouscategoris != 0)
            {
                updatecategory();
            }

            int ff = testrepeater.Items.Count;


            // HiddenField categorynohid = (HiddenField)testrepeater.Items[ff - 1].FindControl("categoryno");
            //if (categorynohid.Value.ToString() == string.Empty)



            SqlCommand cmd = new SqlCommand("categorysave_procedure", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            // cmd.Parameters.Add("@i_QuoteNumber", SqlDbType.Int).Value = "4564";
            //cmd.Parameters.Add("@CategoryNumber", SqlDbType.Int).Value = Convert.ToInt32( 66);
            //select MAX(iCategoryNumber) from Category_Input     
            if (quotenotxt.Text != string.Empty)
            { }
            cmd.Parameters.Add("@i_QuoteNumber", SqlDbType.Int).Value = Convert.ToInt32(quotenotxt.Text); //Convert.ToInt32(hidquoteNo.Value);
            cmd.Parameters.Add("@i_CategoryNumber", SqlDbType.Int).Value = countofpreviouscategoris + 1;


            cmd.ExecuteNonQuery();
            connection.Close();


            if (countofpreviouscategoris == 0)
            {
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
                string kff = quotenotxt.Text;
                SqlCommand cmd3 = new SqlCommand("select * from Category_Input where iQuoteNumber='" + quotenotxt.Text + "'", connection);
                connection.Open();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
                da1.Fill(dt1);
                int c = dt1.Rows.Count;
                int widthh = c * 260;
                divconetnet.Attributes["style"] = " width:" + widthh + "px; overflow-x: scroll; display: inline-table;";
                testrepeater.DataSource = dt1;
                testrepeater.DataBind();
                connection.Close();
            }
            else
            {


                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
                string kff = quotenotxt.Text;
                SqlCommand cmd3 = new SqlCommand("select * from Category_Input where iQuoteNumber='" + quotenotxt.Text + "'", connection);
                connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                da.Fill(dt);
                int c = dt.Rows.Count;
                int widthh = c * 260;
                divconetnet.Attributes["style"] = " width:" + widthh + "px; overflow-x: scroll; display: inline-table;";
                testrepeater.DataSource = dt;
                testrepeater.DataBind();
                connection.Close();
                //DataTable dt = new DataTable();
                //dt = (DataTable)testrepeater.DataSource;
                //DataRow ddr = dt.NewRow();
                //dt.Rows.Add(ddr);
                //int c = dt.Rows.Count;
                //int widthh = c * 260;
                //divconetnet.Attributes["style"] = " width:" + widthh + "px; overflow-x: scroll; display: inline-table;";
                //testrepeater.DataSource = dt;
                //testrepeater.DataBind();
            }


            // int  dff = testrepeater.Items.Count;


        }
        else
        {

        }



    }

    protected void quotenotxt_TextChanged(object sender, EventArgs e)
    {
       if( quotenotxt.Text!=  string.Empty )
       {
       // droppop();
        BindRepeaterData();
        BindgvMemberEdit(quotenotxt.Text);
        fetchquote();
        viequotebtnn.Enabled = true;
       }
      
       
    }

    public void updatecategory()
    {
        DataTable dt = new DataTable();
        dt = (DataTable)testrepeater.DataSource;
        int ff = dt.Rows.Count;
        //  int countof=0;
        //using (SqlCommand cmdc = new SqlCommand("select count(iQuoteNumber) from Category_Input where iQuoteNumber='"+quotenotxt.Text+"'"))
        //{
        //    connection = new SqlConnection();
        //    connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        //    cmdc.CommandType = CommandType.Text;
        //    cmdc.Connection = connection;
        //    connection.Open();
        //    countof = Convert.ToInt32(cmdc.ExecuteScalar().ToString());                    
        //}
        // connection.Close();
        // int dif = ff - countof;
        for (int i = ff; i > 0; i--)
        {
            DropDownList HasGladropdowndrop = (DropDownList)testrepeater.Items[ff - i].FindControl("HasGladropdown");
            DropDownList iglapatterndropdowndrop = (DropDownList)testrepeater.Items[ff - i].FindControl("iglapatterndropdown");
            DropDownList iTTDwpPPdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iTTDwpPPdrop");
            DropDownList iHasCoverTo70dropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasCoverTo70drop");
            
            
            TextBox iglamultipleTextbox = (TextBox)testrepeater.Items[ff - i].FindControl("iglamultipleText");
            TextBox GLAflatCoverAmtxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("GLAflatCoverAmtxt");
            TextBox AgeCutOff1txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeCutOff1txt");
            TextBox AgeCutOff2txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeCutOff2txt");
            TextBox AgeCutOff3txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeCutOff3txt");
            TextBox AgeCutOff4txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeCutOff4txt");
            TextBox AgeCutOff5txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeCutOff5txt");
            TextBox AgeCutOff6txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeCutOff6txt");
            TextBox AgeCutOff7txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeCutOff7txt");
            TextBox AgeMultGLA1txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultGLA1txt");
            TextBox AgeMultGLA2txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultGLA2txt");
            TextBox AgeMultGLA3txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultGLA3txt");
            TextBox AgeMultGLA4txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultGLA4txt");
            TextBox AgeMultGLA5txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultGLA5txt");
            TextBox AgeMultGLA6txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultGLA6txt");
            TextBox AgeMultGLA7txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultGLA7txt");
            TextBox AgeMultGLA8txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultGLA8txt");
            TextBox AgeMultPTD1txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultPTD1txt");
            TextBox AgeMultPTD2txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultPTD2txt");
            TextBox AgeMultPTD3txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultPTD3txt");
            TextBox AgeMultPTD4txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultPTD4txt");
            TextBox AgeMultPTD5txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultPTD5txt");
            TextBox AgeMultPTD6txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultPTD6txt");
            TextBox AgeMultPTD7txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultPTD7txt");
            TextBox AgeMultPTD8txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("AgeMultPTD8txt");
            DropDownList GLAhasCOCcheckdropdrop = (DropDownList)testrepeater.Items[ff - i].FindControl("GLAhasCOCcheckdrop");
            DropDownList GLAgicdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("GLAgicdrop");
            DropDownList GLAhasTIBdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("GLAhasTIBdrop");
            DropDownList HasTaxReplCoverdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("HasTaxReplCoverdrop");
            DropDownList GLAhasConverOptiondropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("GLAhasConverOptiondrop");
            DropDownList GLAisFlexCoverdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("GLAisFlexCoverdrop");
            DropDownList PHIwaitingPerioddropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("PHIwaitingPerioddrop");
            DropDownList iCIIpatterntxtdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("CIIpatterntxtdrop");
          //DropDownList GLAisFlexCoverdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("HasTaxReplCoverdrop");
            TextBox glacorecovermulttxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("glacorecovermulttxt");           
            TextBox PTDmultipletxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("PTDmultipletxt");
            TextBox PTDflatCoverAmttxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("PTDflatCoverAmttxt");
            TextBox CIImultipletxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("CIImultipletxt");
            TextBox CIIflatCoverAmttxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("CIIflatCoverAmttxt");
            TextBox PHIbenPercTier1txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("PHIbenPercTier1txt");
            TextBox PHIsalLimitTier1txt11box = (TextBox)testrepeater.Items[ff - i].FindControl("PHIsalLimitTier1txt11");
            TextBox PHIbenPercTier2txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("PHIbenPercTier2txt");
            TextBox PHIsalLimitTier2txt11box = (TextBox)testrepeater.Items[ff - i].FindControl("PHIsalLimitTier2txt11");
            TextBox PHIbenPercTier3txtbox = (TextBox)testrepeater.Items[ff - i].FindControl("PHIbenPercTier3txt");            
            TextBox PHIwaiverPerctxt1box = (TextBox)testrepeater.Items[ff - i].FindControl("PHIwaiverPerctxt1");
            TextBox PHIescPerctxt11box = (TextBox)testrepeater.Items[ff - i].FindControl("PHIescPerctxt11");
            TextBox MAPWPmtTermtxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("MAPWPmtTermtxt");         
            TextBox FUNcoverAmttxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("FUNcoverAmttxt");
            TextBox iSGLAmultipletxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iSGLAmultipletxt");
            TextBox iSGLAflatCoverAmttxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iSGLAflatCoverAmttxt");
            TextBox SPTDmultipletxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("SPTDmultipletxt");

            TextBox SPTDflatCoverAmttxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("SPTDflatCoverAmttxt");
            TextBox iPTDwptxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iPTDwptxt");
            TextBox iPTDnoInstalmentstxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iPTDnoInstalmentstxt");
            TextBox iPTDpreExtxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iPTDpreExtxt");
            TextBox iPTDoccDefntxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iPTDoccDefntxt");
            TextBox iPHIoccDefntxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iPHIoccDefntxt");
            TextBox iPHIaltEsctxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iPHIaltEsctxt");
            TextBox categorydescriptextbox = (TextBox)testrepeater.Items[ff - i].FindControl("categorydescrip");
            TextBox RetAgetextbox = (TextBox)testrepeater.Items[ff - i].FindControl("RetAgetext");
            TextBox AccBenMultipletextbox = (TextBox)testrepeater.Items[ff - i].FindControl("AccBenMultipletext");
            TextBox iSalaryScalingFacboxtext = (TextBox)testrepeater.Items[ff - i].FindControl("iSalaryScalingFacbox");

            TextBox iBenefitScalingFactextbox = (TextBox)testrepeater.Items[ff - i].FindControl("iBenefitScalingFactext"); 

            TextBox iTTDwaivertextbox = (TextBox)testrepeater.Items[ff - i].FindControl("iTTDwaivertext"); 
            
            //TextBox iPTDwptxtbox = (TextBox)testrepeater.Items[ff - i].FindControl("iPTDwptxt");

            DropDownList HasUEPdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("HasUEPdrop");
            DropDownList AccidentbentypeDropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("AccidentbentypeDrop");
            DropDownList HasPTDdropdowndown = (DropDownList)testrepeater.Items[ff - i].FindControl("HasPTDdropdown");
            DropDownList PTDpatterndropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("PTDpatterndrop");
            DropDownList PTDhasConverOptiondropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("PTDhasConverOptiondrop");
            DropDownList hasaccbendropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("hasaccbendrop");
            DropDownList accbenmultipledown = (DropDownList)testrepeater.Items[ff - i].FindControl("accbenmultiple");
            DropDownList accbentypedropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("accbentype");
            DropDownList iHasCIIdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasCIIdrop");
            DropDownList iCIIFlatamtdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iCIIFlatamtdrop");
            DropDownList iCIItypedropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iCIItypedrop");
            DropDownList CIIhasCOCdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("CIIhasCOCdrop");
            DropDownList iCIIgicdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iCIIgicdrop");
            DropDownList iCIIhasConverOptiondropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iCIIhasConverOptiondrop");
            DropDownList hasphidropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("hasphidrop");
            DropDownList PHIscaleTypedropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("PHIscaleTypedrop");
            DropDownList iPHIhasConverOptiondropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iPHIhasConverOptiondrop");
            DropDownList iPHIhasTopUpdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iPHIhasTopUpdrop");
            DropDownList iHasMAPWdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasMAPWdrop");
            DropDownList iHasSalaryRefunddropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasSalaryRefunddrop");
            DropDownList ihasfundropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("ihasfundrop");
            DropDownList iHasFUNtransportBendropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasFUNtransportBendrop");
            DropDownList HasSGLAdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("HasSGLAdrop");
            DropDownList iSGLApatterndropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iSGLApatterndrop");
            //DropDownList iSGLAhasTermIllBendropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iSGLAhasTermIllBendrop");
            DropDownList iSGLAhasConverOptiondropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iSGLAhasConverOptiondrop");
            DropDownList iHasSPTDdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasSPTDdrop");
            DropDownList iSPTDpatterndropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iSPTDpatterndrop");
            DropDownList iSPTDhasConverOptiondropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iSPTDhasConverOptiondrop");
            DropDownList iHasPTDinstalmentsdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasPTDinstalmentsdrop");
            DropDownList iHasPTDaltPreExdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasPTDaltPreExdrop");
            DropDownList iHasPTDaltOccDefndropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasPTDaltOccDefndrop");
            DropDownList iHasPHIaltOccDefndropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasPHIaltOccDefndrop");
            DropDownList iHasPHIaltEscdropdown = (DropDownList)testrepeater.Items[ff - i].FindControl("iHasPHIaltEscdrop");
            DropDownList SRmultipledropbox = (DropDownList)testrepeater.Items[ff - i].FindControl("SRmultipledrop");
            HiddenField categorynohid = (HiddenField)testrepeater.Items[ff - i].FindControl("categoryno");
            SqlCommand cmd = new SqlCommand("Categoryinput_update_procedure", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.Add("@i_QuoteNumber", SqlDbType.Int).Value = "4564";
            //cmd.Parameters.Add("@CategoryNumber", SqlDbType.Int).Value = Convert.ToInt32( 66);
            //select MAX(iCategoryNumber) from Category_Input
            SqlCommand cmd1 = new SqlCommand("select count(iCategoryNumber) from Category_Input where iQuoteNumber='" + quotenotxt.Text + "'", connection);
            connection.Open();
            int countofpreviouscategoris = Convert.ToInt32(cmd1.ExecuteScalar());
            int Membercount = Convert.ToInt32(cmd1.ExecuteScalar());
            if (quotenotxt.Text != string.Empty)
            { }
            cmd.Parameters.Add("@iQuoteNumber", SqlDbType.Int).Value = Convert.ToInt32(quotenotxt.Text); //Convert.ToInt32(hidquoteNo.Value);

            if (iTTDwpPPdropdown.SelectedItem.ToString() != "Select..")
            {

                string[] twofiled = iTTDwpPPdropdown.SelectedItem.ToString().Split('/');
                string iTTDwaitingPeriods = twofiled[0].ToString().Trim().Remove(0, 2).ToString();

                string iTTDpaymentPeriods = twofiled[1].ToString().Trim().Remove(0, 2).ToString();

                cmd.Parameters.Add("@iTTDwaitingPeriod", SqlDbType.Int).Value = Convert.ToInt32(iTTDwaitingPeriods);
                cmd.Parameters.Add("@iTTDpaymentPeriod", SqlDbType.Int).Value = Convert.ToInt32(iTTDpaymentPeriods);


            }

            cmd.Parameters.Add("@iCategoryNumber", SqlDbType.Int).Value =  Convert.ToInt32(categorynohid.Value.ToString());
            if (AccidentbentypeDropdown.SelectedItem.ToString() != "Select..")
            {
                cmd.Parameters.Add("@iAccBenType ", SqlDbType.VarChar).Value = AccidentbentypeDropdown.SelectedItem.ToString();
            }
            //if (accidentperofglatxtbox.Text != string.Empty)
            //{
            //    cmd.Parameters.Add("@iAccPercOfGLA ", SqlDbType.Decimal).Value = decimal.Parse(accidentperofglatxtbox.Text, CultureInfo.InvariantCulture);
            //}
            if (FUNcoverAmttxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iFUNcoverAmt", SqlDbType.Decimal).Value = decimal.Parse(FUNcoverAmttxtbox.Text, CultureInfo.InvariantCulture);
            }
            if (glacorecovermulttxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iGLAcoreCoverMult", SqlDbType.Decimal).Value = decimal.Parse(glacorecovermulttxtbox.Text, CultureInfo.InvariantCulture);
            }
            cmd.Parameters.Add("@iGLAgic", SqlDbType.Bit).Value = Convert.ToBoolean(GLAgicdropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iGLAhasTIB", SqlDbType.Bit).Value = Convert.ToBoolean(GLAhasTIBdropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iGLAhasCOC", SqlDbType.Bit).Value = Convert.ToBoolean(GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            if (!iglapatterndropdowndrop.SelectedItem.ToString().Equals("Select.."))
            {
                cmd.Parameters.Add("@iGLApattern", SqlDbType.VarChar).Value = iglapatterndropdowndrop.SelectedItem.ToString();
            }
            cmd.Parameters.Add("@iPTDpattern ", SqlDbType.VarChar).Value = PTDpatterndropdown.SelectedItem.ToString();
            cmd.Parameters.Add("@iCategoryDescription ", SqlDbType.VarChar).Value = categorydescriptextbox.Text;
            //cmd.Parameters.Add("@iGLAcoversImported", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedItem.ToString());       
            if (GLAflatCoverAmtxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iGLAflatCoverAmt ", SqlDbType.Decimal).Value = decimal.Parse(GLAflatCoverAmtxtbox.Text, CultureInfo.InvariantCulture);
            }
            cmd.Parameters.Add("@iGLAhasConverOption", SqlDbType.Bit).Value = Convert.ToBoolean(GLAhasConverOptiondropdown.SelectedValue.ToString());
            //cmd.Parameters.Add("@iGLAhasPTD", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedItem.ToString());
            //cmd.Parameters.Add("@iGLAisFlatAmt", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedItem.ToString());
            cmd.Parameters.Add("@iGLAhasFlexCover", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAisFlexCoverdropdown.SelectedValue.ToString());
            if (iglamultipleTextbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iGLAmultiple ", SqlDbType.Decimal).Value = decimal.Parse(iglamultipleTextbox.Text, CultureInfo.InvariantCulture);
            }

         
            //if (iCIIpatterntxtdropdown.Text != "Select..")
            //{
            //    cmd.Parameters.Add("@iCIIpattern", SqlDbType.VarChar).Value = iCIIpatterntxtdropdown.SelectedItem.ToString();
            //}
            //  if (iSPTDpatterndropdown.Text != "Select..")
            //{
            //    cmd.Parameters.Add("@iSPTDpattern", SqlDbType.VarChar).Value = iSPTDpatterndropdown.SelectedItem.ToString();
            //}
           //if (iSGLApatterndropdown.Text != "Select..")
           // {
           //     cmd.Parameters.Add("@iSGLApattern ", SqlDbType.VarChar).Value = iSGLApatterndropdown.SelectedItem.ToString();
           // }

            //cmd.Parameters.Add("@íPTDisFlatAmt", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            //cmd.Parameters.Add("@iHasTopUp", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            //cmd.Parameters.Add("@iHasSCII", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            if (PTDflatCoverAmttxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPTDflatCoverAmt ", SqlDbType.Decimal).Value = decimal.Parse(PTDflatCoverAmttxtbox.Text, CultureInfo.InvariantCulture);
            }
            cmd.Parameters.Add("@iPTDhasConverOption", SqlDbType.Bit).Value = Convert.ToBoolean(PTDhasConverOptiondropdown.SelectedValue.ToString());

            if (PTDmultipletxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPTDmultiple ", SqlDbType.Decimal).Value = decimal.Parse(PTDmultipletxtbox.Text, CultureInfo.InvariantCulture);
            }
            cmd.Parameters.Add("@iHasAccBen", SqlDbType.Bit).Value = Convert.ToBoolean(hasaccbendropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasFUN", SqlDbType.Bit).Value = Convert.ToBoolean(ihasfundropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasGLA", SqlDbType.Bit).Value = Convert.ToBoolean(HasGladropdowndrop.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasPTD", SqlDbType.Bit).Value = Convert.ToBoolean(HasPTDdropdowndown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasMAPW", SqlDbType.Bit).Value = Convert.ToBoolean(iHasMAPWdropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasPHI", SqlDbType.Bit).Value = Convert.ToBoolean(hasphidropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasSalaryRefund", SqlDbType.Bit).Value = Convert.ToBoolean(iHasSalaryRefunddropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasSGLA", SqlDbType.Bit).Value = Convert.ToBoolean(HasSGLAdropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasSPTD", SqlDbType.Bit).Value = Convert.ToBoolean(iHasSPTDdropdown.SelectedValue.ToString());

            cmd.Parameters.Add("@iHasTaxReplCover", SqlDbType.Bit).Value = Convert.ToBoolean(HasTaxReplCoverdropdown.SelectedValue.ToString());

            cmd.Parameters.Add("@iHasCII", SqlDbType.Bit).Value = Convert.ToBoolean(iHasCIIdropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasUEP", SqlDbType.Bit).Value = Convert.ToBoolean(HasUEPdropdown.SelectedValue.ToString());
            if (MAPWPmtTermtxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iMAPWPmtTerm", SqlDbType.Int).Value = Convert.ToInt32(MAPWPmtTermtxtbox.Text);
            }
            if (PHIbenPercTier1txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPHIbenPercTier1 ", SqlDbType.Decimal).Value = decimal.Parse(PHIbenPercTier1txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (PHIbenPercTier2txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPHIbenPercTier2 ", SqlDbType.Decimal).Value = decimal.Parse(PHIbenPercTier2txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (PHIbenPercTier3txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPHIbenPercTier3 ", SqlDbType.Decimal).Value = decimal.Parse(PHIbenPercTier3txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (PHIescPerctxt11box.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPHIescPerc ", SqlDbType.Decimal).Value = decimal.Parse(PHIescPerctxt11box.Text, CultureInfo.InvariantCulture);
            }
            cmd.Parameters.Add("@iPHIhasConverOption", SqlDbType.Bit).Value = Convert.ToBoolean(iPHIhasConverOptiondropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasTopUp", SqlDbType.Bit).Value = Convert.ToBoolean(iPHIhasTopUpdropdown.SelectedValue.ToString());
            if (PHIsalLimitTier1txt11box.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPHIsalLimitTier1 ", SqlDbType.Decimal).Value = decimal.Parse(PHIsalLimitTier1txt11box.Text, CultureInfo.InvariantCulture);
            }
            if (PHIsalLimitTier2txt11box.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPHIsalLimitTier2 ", SqlDbType.Decimal).Value = decimal.Parse(PHIsalLimitTier2txt11box.Text, CultureInfo.InvariantCulture);
            }
            if (PHIscaleTypedropdown.SelectedItem.ToString() != "Select..")
            {
                cmd.Parameters.Add("@iPHIscaleType ", SqlDbType.VarChar).Value = PHIscaleTypedropdown.SelectedItem.ToString();
            }
            if (PHIwaitingPerioddropdown.SelectedItem.ToString() != "Select..")
            {
                cmd.Parameters.Add("@iPHIwaitingPeriod", SqlDbType.Int).Value = Convert.ToInt32(PHIwaitingPerioddropdown.SelectedItem.ToString());
            }
            if (PHIwaiverPerctxt1box.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPHIwaiverPerc ", SqlDbType.Decimal).Value = decimal.Parse(PHIwaiverPerctxt1box.Text, CultureInfo.InvariantCulture);
            }
            if (RetAgetextbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iRetAge", SqlDbType.Int).Value = Convert.ToInt32(RetAgetextbox.Text);
            }

            cmd.Parameters.Add("@iHasCoverTo70", SqlDbType.Bit).Value = Convert.ToBoolean(iHasCoverTo70dropdown.SelectedValue.ToString());

            //if (iSGLApatterndropdown.SelectedItem.ToString() != string.Empty)
            //{
            //    cmd.Parameters.Add("@iSGLAcoreCoverMult ", SqlDbType.Decimal).Value = decimal.Parse(iSGLApatterndropdown.SelectedItem.ToString(), CultureInfo.InvariantCulture);
            //}
            //if (iSGLApatterndropdown.SelectedItem.ToString() != "Select..")
            //{
            //    cmd.Parameters.Add("@iSGLApattern", SqlDbType.VarChar).Value = iSGLApatterndropdown.SelectedItem.ToString();
            //}
            //if (accidentperofglatxtbox.Text != string.Empty)
            //{
            //    //cmd.Parameters.Add("@iSalaryAdjFac ", SqlDbType.Decimal).Value = decimal.Parse(PTDmultipletxtbox.Text, CultureInfo.InvariantCulture);
            //}
            if (iSGLApatterndropdown.SelectedItem.ToString() == "Flat")
            {
                cmd.Parameters.Add("@iSGLAisFlatAmt", SqlDbType.Bit).Value = true ;
            }
            else if (iSGLApatterndropdown.SelectedItem.ToString() == "Multiple")
            {
                cmd.Parameters.Add("@iSGLAisFlatAmt", SqlDbType.Bit).Value = false ;
            }
           
          //  cmd.Parameters.Add("@iSGLAisFlexCover", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            //cmd.Parameters.Add("@iSGLAisStandAlone", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            if (iSGLAflatCoverAmttxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iSGLAflatCoverAmt ", SqlDbType.Decimal).Value = decimal.Parse(iSGLAflatCoverAmttxtbox.Text, CultureInfo.InvariantCulture);
            }
            cmd.Parameters.Add("@iSGLAhasConverOption", SqlDbType.Bit).Value = Convert.ToBoolean(iSGLAhasConverOptiondropdown.SelectedValue.ToString());
        // cmd.Parameters.Add("@iSGLAhasTIB", SqlDbType.Bit).Value = Convert.ToBoolean(iSGLAhasTermIllBendropdown.SelectedValue.ToString());

            if (iSGLAmultipletxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iSGLAmultiple ", SqlDbType.Decimal).Value = decimal.Parse(iSGLAmultipletxtbox.Text, CultureInfo.InvariantCulture);
            }
            if (SPTDflatCoverAmttxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iSPTDflatCoverAmt ", SqlDbType.Decimal).Value = decimal.Parse(SPTDflatCoverAmttxtbox.Text, CultureInfo.InvariantCulture);
            }

            cmd.Parameters.Add("@iSPTDhasConverOption", SqlDbType.Bit).Value = Convert.ToBoolean(iSPTDhasConverOptiondropdown.SelectedValue.ToString());
            //if (iSPTDpatterndropdown.SelectedItem.ToString() != "Select..")
            //{
            //    cmd.Parameters.Add("@iSPTDtype ", SqlDbType.VarChar).Value = iSPTDpatterndropdown.SelectedItem.ToString();
            //}

            // cmd.Parameters.Add("@iPTDtaperingYears ", SqlDbType.VarChar).Value =5;
            //if (iSPTDpatterndropdown.SelectedItem.ToString()== "Flat")
            //{
            //    cmd.Parameters.Add("@iSPTDisFlatAmt", SqlDbType.Bit).Value = true;
            //}
            //else if(iSPTDpatterndropdown.SelectedItem.ToString()== "Multiple")
            //{
            //    cmd.Parameters.Add("@iSPTDisFlatAmt", SqlDbType.Bit).Value = false;
            //}
           // cmd.Parameters.Add("@íSPTDisFlatAmt", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            //cmd.Parameters.Add("@iSCIIgic", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            //cmd.Parameters.Add("@iSPTDisStandAlone", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            //if (accidentperofglatxtbox.Text != string.Empty)
            //{
           // cmd.Parameters.Add("@iSCIIflatCoverAmt ", SqlDbType.Decimal).Value = 0;
            //}




          //  cmd.Parameters.Add("@iSCIIhasConverOption", SqlDbType.Bit).Value = false; ;
            //cmd.Parameters.Add("@iSCIIhasCOC", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
           // cmd.Parameters.Add("@iSCIIisFlatAmt", SqlDbType.Bit).Value = false ;
            //cmd.Parameters.Add("@iSCIIisStandAlone", SqlDbType.Bit).Value =  Convert.ToBoolean( GLAhasCOCcheckdropdrop.SelectedValue.ToString());
            //if (accidentperofglatxtbox.Text != string.Empty)
            //{
          //  cmd.Parameters.Add("@iSCIImultiple ", SqlDbType.Decimal).Value = 0;
            
                cmd.Parameters.Add("@ISalaryScalingFac ", SqlDbType.Decimal).Value = decimal.Parse(iSalaryScalingFacboxtext.Text, CultureInfo.InvariantCulture);
            
            
            //}
        //    cmd.Parameters.Add("@iSCIItype ", SqlDbType.VarChar).Value = "Standard";
            cmd.Parameters.Add("@iCIIhasCOC", SqlDbType.Bit).Value =  Convert.ToBoolean( CIIhasCOCdropdown.SelectedValue.ToString());

            //if (iCIIpatterntxtdropdown.SelectedItem.ToString()== "Flat")
            //{
            //cmd.Parameters.Add("@iCIIisFlatAmt", SqlDbType.Bit).Value = true;
            //}
            //else if(iCIIpatterntxtdropdown.SelectedItem.ToString()=="Multiple")
            //{
            //    cmd.Parameters.Add("@iCIIisFlatAmt", SqlDbType.Bit).Value =false ;
            //}
           // cmd.Parameters.Add("@iGLAhasFlexCover", SqlDbType.Bit).Value =  ;
            cmd.Parameters.Add("@deConversionRatesKey", SqlDbType.Int).Value = 1 + RetAgetextbox.Text.ToString() ; 

            cmd.Parameters.Add("@iTTDwaiverPattern", SqlDbType.VarChar).Value = "Multiple";
           
                cmd.Parameters.Add("@IBenefitScalingFac", SqlDbType.Decimal).Value = iBenefitScalingFactextbox.Text;
            
           
            cmd.Parameters.Add("@iHasTTD", SqlDbType.Bit).Value = false;
            
                cmd.Parameters.Add("@iPHIwaiverPattern", SqlDbType.VarChar).Value = "Multiple";
            
            if (SPTDmultipletxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iSPTDmultiple", SqlDbType.Decimal).Value = decimal.Parse(SPTDmultipletxtbox.Text, CultureInfo.InvariantCulture);
            }
            if (SRmultipledropbox.SelectedItem.ToString() != "Select..")
            {
                cmd.Parameters.Add("@iSRmultiple", SqlDbType.Decimal).Value = decimal.Parse(SRmultipledropbox.SelectedItem.ToString(), CultureInfo.InvariantCulture);
            }


            cmd.Parameters.Add("@iCIIgic", SqlDbType.Bit).Value = Convert.ToBoolean(iCIIgicdropdown.SelectedValue.ToString());
            if (CIIflatCoverAmttxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iCIIflatCoverAmt", SqlDbType.Decimal).Value = decimal.Parse(CIIflatCoverAmttxtbox.Text, CultureInfo.InvariantCulture);
            }
            cmd.Parameters.Add("@iCIIhasConverOption", SqlDbType.Bit).Value = Convert.ToBoolean(iCIIhasConverOptiondropdown.SelectedValue.ToString());

            if (CIImultipletxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iCIImultiple", SqlDbType.Decimal).Value = decimal.Parse(CIImultipletxtbox.Text, CultureInfo.InvariantCulture);
            }
            cmd.Parameters.Add("@iCIItype", SqlDbType.VarChar).Value = iCIItypedropdown.SelectedItem.ToString();
           // cmd.Parameters.Add("@iCiipattern", SqlDbType.VarChar).Value = iCIIpatterntxtdropdown.SelectedItem.ToString();
            //if (accidentperofglatxtbox.Text != string.Empty)
            //{
            if (hasphidropdown.SelectedItem.ToString()  == "No")
            {
                cmd.Parameters.Add("@dePHIwpFactorsKey", SqlDbType.Int).Value = 13;
            }
            else
            {
                cmd.Parameters.Add("@dePHIwpFactorsKey", SqlDbType.Int).Value = 1 + PHIwaitingPerioddropdown.SelectedItem.ToString();
            }
            cmd.Parameters.Add("@IHasMPHI", SqlDbType.Int).Value = false ;
            //}
            //if (CIImultipletxtbox.Text != string.Empty)
            //{
            cmd.Parameters.Add("@iVolRateDiscFUN ", SqlDbType.Decimal).Value = 0;
            //}
            //if (CIImultipletxtbox.Text != string.Empty)
            //{
            cmd.Parameters.Add("@iVolRateDiscGLA ", SqlDbType.Decimal).Value =0;
            //}
            //if (CIImultipletxtbox.Text != string.Empty)
            //{
            cmd.Parameters.Add("@iVolRateDiscPTD ", SqlDbType.Decimal).Value = 0;
            //}
            //if (CIImultipletxtbox.Text != string.Empty)
            //{
            cmd.Parameters.Add("@iVolRateDiscPHI ", SqlDbType.Decimal).Value = 0;
            //}
            //if (CIImultipletxtbox.Text != string.Empty)
            //{
            cmd.Parameters.Add("@iVolRateDiscSGLA ", SqlDbType.Decimal).Value = 0;
            //}
            //if (CIImultipletxtbox.Text != string.Empty)
            //{

            cmd.Parameters.Add("@iVolRateDiscSPTD ", SqlDbType.Decimal).Value = 0;
            //}
            //if (CIImultipletxtbox.Text != string.Empty)
            //{
            cmd.Parameters.Add("@iVolRateDiscCII ", SqlDbType.Decimal).Value =0;
            //}

            if (AgeCutOff1txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeCutOff1", SqlDbType.Int).Value = Convert.ToInt32(AgeCutOff1txtbox.Text);
            }
            if (AgeCutOff2txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeCutOff2", SqlDbType.Int).Value = Convert.ToInt32(AgeCutOff2txtbox.Text);
            }
            if (AgeCutOff3txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeCutOff3", SqlDbType.Int).Value = Convert.ToInt32(AgeCutOff3txtbox.Text);
            }
            if (AgeCutOff4txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeCutOff4", SqlDbType.Int).Value = Convert.ToInt32(AgeCutOff4txtbox.Text);
            }
            if (AgeCutOff5txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeCutOff5", SqlDbType.Int).Value = Convert.ToInt32(AgeCutOff5txtbox.Text);
            }
            if (AgeCutOff6txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeCutOff6", SqlDbType.Int).Value = Convert.ToInt32(AgeCutOff6txtbox.Text);
            }
            if (AgeCutOff7txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeCutOff7", SqlDbType.Int).Value = Convert.ToInt32(AgeCutOff7txtbox.Text);
            }
            if (AgeMultGLA1txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultGLA1 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultGLA1txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultGLA2txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultGLA2 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultGLA2txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultGLA3txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultGLA3 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultGLA3txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultGLA4txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultGLA4 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultGLA4txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultGLA5txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultGLA5 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultGLA5txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultGLA6txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultGLA6 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultGLA6txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultGLA7txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultGLA7 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultGLA7txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultGLA8txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultGLA8 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultGLA8txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultPTD1txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultPTD1 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultPTD1txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultPTD2txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultPTD2 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultPTD2txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultPTD3txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultPTD3 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultPTD3txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultPTD4txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultPTD4 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultPTD4txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultPTD5txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultPTD5 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultPTD5txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultPTD6txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultPTD6 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultPTD6txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultPTD7txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultPTD7 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultPTD7txtbox.Text, CultureInfo.InvariantCulture);
            }
            if (AgeMultPTD8txtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAgeMultPTD8 ", SqlDbType.Decimal).Value = decimal.Parse(AgeMultPTD8txtbox.Text, CultureInfo.InvariantCulture);
            }



            cmd.Parameters.Add("@iHasFUNtransportBen", SqlDbType.Bit).Value = Convert.ToBoolean(iHasFUNtransportBendropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iHasPTDinstalments", SqlDbType.Bit).Value = Convert.ToBoolean(iHasPTDinstalmentsdropdown.SelectedValue.ToString());
            if (iPTDnoInstalmentstxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPTDnoInstalments", SqlDbType.Int).Value =  Convert.ToInt32( iPTDnoInstalmentstxtbox.Text );

            }
            if (iPTDwptxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPTDwp", SqlDbType.Int).Value = Convert.ToInt32(iPTDwptxtbox.Text);
            }
            cmd.Parameters.Add("@iHasPTDaltPreEx", SqlDbType.Bit).Value = Convert.ToBoolean(iHasPTDaltPreExdropdown.SelectedValue.ToString());
            if (iPTDpreExtxtbox.Text != string.Empty)
            {
            cmd.Parameters.Add("@iPTDpreEx ", SqlDbType.VarChar).Value = iPTDpreExtxtbox.Text;
            }
            cmd.Parameters.Add("@iHasPTDaltOccDefn", SqlDbType.Bit).Value = Convert.ToBoolean(iHasPTDaltOccDefndropdown.SelectedValue.ToString());
            if (iPTDoccDefntxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPTDoccDefn ", SqlDbType.VarChar).Value = iPTDoccDefntxtbox.Text;
            }
            cmd.Parameters.Add("@iHasPHIaltOccDefn", SqlDbType.Bit).Value = Convert.ToBoolean(iHasPHIaltOccDefndropdown.SelectedValue.ToString());
            if (iPHIoccDefntxtbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iPHIoccDefn ", SqlDbType.VarChar).Value = iPHIoccDefntxtbox.Text;
            }
            cmd.Parameters.Add("@iHasPHIaltEsc", SqlDbType.Bit).Value = Convert.ToBoolean(iHasPHIaltEscdropdown.SelectedValue.ToString());
            cmd.Parameters.Add("@iPHIaltEsc ", SqlDbType.VarChar).Value = iPHIaltEsctxtbox.Text;

            cmd.Parameters.Add("@iTTDbenPercTier1 ", SqlDbType.Decimal).Value =0;
            cmd.Parameters.Add("@iTTDbenPercTier2 ", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@iTTDbenPercTier3 ", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@iTTDsalLimitTier1 ", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@iTTDsalLimitTier2 ", SqlDbType.Decimal).Value = 0;
            if (iTTDwaivertextbox.Text.ToString() == "0.000000" || iTTDwaivertextbox.Text.ToString() == string.Empty )
            {
                cmd.Parameters.Add("@iTTDwaiverPerc ", SqlDbType.Decimal).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@iTTDwaiverPerc ", SqlDbType.Decimal).Value = decimal.Parse(iTTDwaivertextbox.Text, CultureInfo.InvariantCulture);
            
            }
          
            cmd.Parameters.Add("@iTTDscaleType ", SqlDbType.VarChar).Value = "75% Flat";

            if (AccBenMultipletextbox.Text != string.Empty)
            {
                cmd.Parameters.Add("@iAccBenMultiple ", SqlDbType.Decimal).Value = decimal.Parse(AccBenMultipletextbox.Text, CultureInfo.InvariantCulture);
            }
            //cmd.Parameters.Add("@iVolDiscPTDmotiv ", SqlDbType.VarChar).Value =
            //cmd.Parameters.Add("@iVolDiscGLAmotiv ", SqlDbType.VarChar).Value =
            //cmd.Parameters.Add("@iVolDiscPHImotiv ", SqlDbType.VarChar).Value =
            //cmd.Parameters.Add("@iVolDiscSGLAmotiv ", SqlDbType.VarChar).Value =
            //cmd.Parameters.Add("@iVolDiscSPTDmotiv ", SqlDbType.VarChar).Value =
            //cmd.Parameters.Add("@iVolDiscCIImotiv ", SqlDbType.VarChar).Value =



            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }

    //protected void uploadFile_Load(object sender, EventArgs e)
    //{
    //    btnUpload.Enabled = true;
    //}

    protected void viequotebtnn_Click(object sender, EventArgs e)
    {
        Response.Redirect("RFriskv100CS.aspx?iQuoteNumber="+quotenotxt.Text.Trim());
    }

    public void fetchquote()
    {

        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;
        string kff = quotenotxt.Text;
        SqlCommand cmd = new SqlCommand("select * from Quote_Input where iQuoteNumber='" + quotenotxt.Text + "'", connection);
        connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow drr = dt.Rows[0];
                if (drr["iDate"].ToString() != string.Empty )
                {
                quotedatetxt.Text = Convert.ToDateTime(drr["iDate"].ToString()).ToString("dd/MM/yyyy");
                }
                string fdfg = drr["iFOname"].ToString();
                FOnametxtDropDownList.Items.FindByText((drr["iFOname"].ToString()).Trim()).Selected = true;

                companynametxt.Text = drr["iClientName"].ToString();
                string d = drr["iIndustry"].ToString();

                if (drr["iProvince"].ToString() != string.Empty)
                {
                    ProvinceDropDown.ClearSelection();
                    ProvinceDropDown.Items.FindByText(drr["iProvince"].ToString().Trim()).Selected = true;
                }
                if (drr["iIndustry"].ToString() != string.Empty)
                {
                    IndustryDropDown.ClearSelection();
                    IndustryDropDown.Items.FindByText(drr["iIndustry"].ToString().Trim()).Selected = true;
                }
                if (drr["iHasVatOnComm"].ToString() == "True")
                {
                    vatCommssion.ClearSelection();
                    vatCommssion.Items.FindByValue("true").Selected = true;
                }
                else
                {
                    vatCommssion.ClearSelection();
                    vatCommssion.Items.FindByValue("false").Selected = true;
                }
                if (drr["iHasNBComm"].ToString() == "True")
                {
                    schemeCommission.ClearSelection();
                    schemeCommission.Items.FindByValue("true").Selected = true;
                }
                else
                {
                    schemeCommission.ClearSelection();
                    schemeCommission.Items.FindByValue("false").Selected = true;
                }
                BinderFeePerctxt.Value = drr["iBinderFeePerc"].ToString();
                outsourcefeetxt.Text = drr["iOutsourceFeePerc"].ToString();

                if (drr["iCommDiscount"].ToString() != string.Empty)
                {
                    CommonDiscountDropDownList.ClearSelection();
                    CommonDiscountDropDownList.Items.FindByValue(Convert.ToInt32(drr["iCommDiscount"]).ToString()).Selected = true;
                }


                if (drr["iIsSUFquote"].ToString() == "True")
                {
                    IsSUFquotedropdown.ClearSelection();
                    IsSUFquotedropdown.Items.FindByValue("true").Selected = true;
                }
                else
                {
                    IsSUFquotedropdown.ClearSelection();
                    IsSUFquotedropdown.Items.FindByValue("false").Selected = true;
                }
                brokernametxt.Value = drr["iBrokerName"].ToString();
                datevalidtilltxt.Value = drr["iDateValidTill"].ToString();




                agefactorstxt.Value = drr["deAgeFactorsVer"].ToString();
                spouseagetxt.Value = drr["deSpousesAgeFactorsVer"].ToString();
                industryfactorstxt.Value = drr["deIndustryFactorsVer"].ToString();
                genderfactxt.Value = drr["deGenderFactorsVer"].ToString();
                spousegendertxt.Value = drr["deSpousesGenderFacVer"].ToString();
                frontofficefactxt.Value = drr["deFrontOfficeFactorsVer"].ToString();
                glasalindtxt.Value = drr["deGLAsalIndGenFacVer"].ToString();
                salaryparamstxt.Value = drr["deSalaryParmsVer"].ToString();
                schemeparamtxt.Value = drr["deSchemeParametersVer"].ToString();
                regionfactxt.Value = drr["deRegionFactorsVer"].ToString();
                convertionratestxt.Value = drr["deConvertionRatesVer"].ToString();
                phigennra.Value = drr["dePHIgenNRAescWPVer"].ToString();
                phisalfactxt.Value = drr["dePHIsalFactorsVer"].ToString();
                phiwpfactxt.Value = drr["dePHIwpFactorsVer"].ToString();
                sratestxt.Value = drr["deSRratesVer"].ToString();
                commisionparamstxt.Value = drr["deCommissionParmsVer"].ToString();
                expenseparamtxt.Value = drr["deExpenseParmsVer"].ToString();
                ratingclasstxt.Value = drr["deRatingClassFacVer"].ToString();
            }
        }
        connection.Close();

    }
}