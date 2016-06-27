<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addquote.aspx.cs" Inherits="addquote" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
	<meta charset="UTF-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	<meta name="viewport" content="width=1.0, initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no" />
	<title>Sanlam Group Risk Online Quotes</title>
	<link rel="stylesheet" href="css/normalize.css" />
	<link rel="stylesheet" href="css/fonts.css" />
	<link rel="stylesheet" href="css/global.css" />
	<link rel="stylesheet" href="css/styles.css" />
	<link rel="stylesheet" href="css/desktop.css" media="only screen and (min-width: 1281px)" />
	<link rel="stylesheet" href="css/tablet.css" media="only screen and (max-width: 1150px)" />
	<link rel="stylesheet" href="css/mobile.css" media="only screen and (max-width: 555px)" />
	<link rel="stylesheet" href="css/print.css" media="print" />
	<script type="text/javascript" src="js/vendor/jquery-1.11.3.min.js"></script>
	<script type="text/javascript" src="js/vendor/jquery-ui-1.10.3.custom.min.js"></script>
	<script type="text/javascript" src="js/vendor/modernizr-2.6.2-respond-1.1.0.min.js"></script>
	<script type="text/javascript" src="js/vendor/jquery.ui.selectmenu.js"></script>
    <script type="text/javascript" src="js/vendor/jquery.screwdefaultbuttonsV2.min.js"></script>
   
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"--%>

    <%--<script type="text/javascript">
        //$(function () {
        //    $('#iglapatterndropdown').change(function () {

        //        if ($('#iglapatterndropdown').val() == "Multiple") { $('#iglamultipleTextdiv').show(); }
        //        else
        //        { $('#iglamultipleTextdiv').hide(); }

        //        if ($('#iglapatterndropdown').val() == "Flat") { $('#GLAflatCoverAmtxtdiv').show(); }
        //        else
        //        { $('#GLAflatCoverAmtxtdiv').hide(); }

        //        if ($('#iglapatterndropdown').val() == "AgeBanded") { $('#hiddentable').show(); }
        //        else
        //        { $('#hiddentable').hide(); }


        //    })
        //})


        //$(function () {
        //    $('#PTDpatterndropdown').change(function () {

        //        if ($('#PTDpatterndropdown').val() == "Multiple") { $('#PTDmultipletxtdiv').show(); }
        //        else
        //        { $('#PTDmultipletxtdiv').hide(); }

        //        if ($('#PTDpatterndropdown').val() == "Flat") { $('#PTDflatCoverAmttxtdiv').show(); }
        //        else
        //        { $('#PTDflatCoverAmttxtdiv').hide(); }
        //    })
        //})



        //$(function () {
        //    $('#PHIscaleTypedropdown').change(function () {

        //        if ($('#PHIscaleTypedropdown').val() == "Custom") { $('#phibendiv').show(); }
        //        else
        //        { $('#phibendiv').hide(); }

        //        //if ($('#PHIscaleTypedropdown').val() == "Flat") { $('#PTDflatCoverAmttxtdiv').show(); }
        //        //else
        //        //{ $('#PTDflatCoverAmttxtdiv').hide(); }
        //    })
        //})

        //$(function () {
        //    $('#SGLApatterndropdown').change(function () {

        //        if ($('#SGLApatterndropdown').val() == "Multiple") { $('#iSGLAmultipletxtdiv').show(); }
        //        else
        //        { $('#iSGLAmultipletxtdiv').hide(); }

        //        if ($('#SGLApatterndropdown').val() == "Flat") { $('#iSGLAflatCoverAmttxtdiv').show(); }
        //        else
        //        { $('#iSGLAflatCoverAmttxtdiv').hide(); }


        //    })
        //})

        //$(function () {
        //    $('#iSPTDpatterndropdown').change(function () {

        //        if ($('#iSPTDpatterndropdown').val() == "Multiple") { $('#SPTDmultipletxtdiv').show(); }
        //        else
        //        { $('#SPTDmultipletxtdiv').hide(); }

        //        if ($('#iSPTDpatterndropdown').val() == "Flat") { $('#SPTDflatCoverAmttxtdiv').show(); }
        //        else
        //        { $('#SPTDflatCoverAmttxtdiv').hide(); }


        //    })
        //})

        //$(function () {
        //    $('#iCIIpatterntxtdrop').change(function () {

        //        if ($('#iCIIpatterntxtdrop').val() == "Multiple") { $('#CIImultipletxtdiv').show(); }
        //        else
        //        { $('#CIImultipletxtdiv').hide(); }

        //        if ($('#iCIIpatterntxtdrop').val() == "Flat") { $('#CIIflatCoverAmttxtdiv').show(); }
        //        else
        //        { $('#CIIflatCoverAmttxtdiv').hide(); }


        //    })
        //})

</script>--%>
    
    <%-- for (var i = 1; i <= 3; i++) {
            
           $(document).ready(function () {
            $('#tabs').tabs({
                activate: function () {
                    var newIdx = $('#tabs').tabs('option', 'active');
                    $('#<%=tabid.ClientID%>').val(newIdx);
            }, heightStyle: "auto", active: previouslySelectedTab, show: {
                effect: "fadeIn", duration: 250
            }
            });
        }); 
           
        }--%>

    <script type="text/javascript"> 
    
       
       
       

        //$(function () {
        //    if(fgf==1)
        //    {
        //        document.getElementById('tabCat').className += 'active'  
        //    }
        //    else if(fgf==2)
        //    {
        //        document.getElementById('tabMember').className += 'active'
        //    }
        //    else if(fgf==3)
        //    {
        //        document.getElementById('tabRate').className += 'active'
        //    }
        //    else if(fgf==4)
        //    {
        //        document.getElementById('tabversion').className += 'active'
        //    }

           
        //});


   




        //$.noConflict();
        //jQuery(function () { $('#tabCat').click(function () {
      //  alert("this is");
                             
     //   });
                   
        //    var tabName = jQuery("[id*=tabid]").val() != "" ? jQuery("[id*=tabid]").val() : "tabquote";
        //    jQuery('#tabs a[href="#' + tabName + '"]').tab('show');
        //    jQuery("#tabs a").click(function () {
        //        jQuery("[id*=tabid]").val(jQuery(this).attr("href").replace("#", ""));
        //    });
        //});
        
        //$(document).ready(function () {
           // $('#tabs').tabs({
             //   activate: function () {
                 //   var newIdx = $('#tabs').tabs('option', 'active');
                 //   $('#<=tabid.ClientID>').val(newIdx);
            //    }, heightStyle: "auto",
            //    active: previouslySelectedTab,
            //    show: { effect: "fadeIn", duration: 1000 }
            //});
        // });



        //$.noConflict();
        //var tabid = 1;
        //jQuery(function () {
            
        //    var tabs = jQuery("#tabs").tabs({
        //        select: function (e, i) {
        //            tabid = i.index;
        //        }
        //    });
        //    tabid = jQuery("[idjQuery=tabid]").val() != "" ? parseInt(jQuery("[idjQuery=tabid]").val()) : "tabCat";
        //    tabs.tabs('select', tabid);
           
        //    jQuery("form1").submit(function () {
        //        jQuery("[idjQuery=tabid]").val(tabid);
        //    });
        //});


      
        
        




        //  textforcount.value = msg.d;
       
        //var j = null;
        //function tor( index) {
        //    alert("ff");
        //    $( "#tabs" ).tabs({ active:index  });
            
        //}

        

        //$(function  set() {
        //    $('#tabCat').click(function () {
        //        alert("clicked");
        //        var qu =  document.getElementById("quotenotxt").value;
        //        var setting;
        //        $.ajax({
        //            type: 'POST',
        //            url: 'addquote.aspx/quotenovalidation',
        //            data:"{}",
        //            contentType: 'application/json; charset=utf-8',
        //            dataType: 'json',
        //            success: function(msg) {
        //                j = msg.d;
        //                if(j==true)
        //                {
        //                    alert(qu);
        //                }
        //                else{
        //                    alert("please add Quote Number");
        //                }

        //            }
        //        });

                //$.ajax({
                //    type: 'POST',
                    
                //    url: 'addquote.aspx/quotenovalidation',
                        
                //    data: "{}",
                //    //JSON.stringify(param),
                
                //    contentType: 'application/json; charset=utf-8',
                //    dataType: 'json',
                //    success: function (msg) {
                //        j = msg.d;
                //        if(j=="true")
                //        {
                //            alert(qu);
                //        }
                //        else{
                //            alert("please add Quote Number");
                //        }
                //        alert(msg.d);                       
                         
                //    }

                //});
                

       
       <%--  alert($('#iglapatterndropdown').val()
        function ToggleShowHide() {
        if($(this).val() == "0") {
				$('#iglapatterndropdowndiv').hide();
				$('#iglapatterndropdowndiv').show();
			} else {
				$('#DivFree').hide();
				$('#DivPaid').show();
			}



            var control = document.getElementById("<%= my_control.ClientID %>");
        if (control.style.display == "none") { control.style.display = "block"; }
        else { control.style.display = "none"; }
        return false;
    }--%>
</script>
  
</head>

<body>
   
    <form id="form1" runat="server">

       
        <asp:HiddenField ID="tabid" runat="server" />
   <%-- <script type="text/javascript">

        tor();
    </script>--%>
        <%--  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <!-- MAIN WRAPPER -->
<div id="page" class="soniq" >
	<!-- Sanlam COM - Desktop nav -->
	<div id="overlay"></div>

		<nav id="headerNav" class="noindex">
			<div id="headNavContainer" class="clearfix">
				<a href="#" id="navBtn"></a>
               
				<div id="sanlamLogo">
					<a class="sanlamLogo-logo" href="#">
						<img src="./img/sanlam-logo.png" alt="Sanlam">
					</a>
				</div>
				<ul id="primaryLinks">
					<li id="quotes">
						<a href="#">Quotes</a>
						<div class="dropMenu">
							<div class="dropMenuArrow">
							</div>
							<div class="dropMenuBody">
								<div class="dropMenuClose">
								</div>
								<div class="pad20 marB0 clearfix">
									<div class="colWrapper">
										<div class="col">
											<h2>
												<a href="addquote.aspx">New Quote</a>
											</h2>
											<h2>
												<a href="quotes.aspx">Existing Quotes</a>
											</h2>
										</div>
									</div>
								</div>
							</div>
						</div>
					</li>
					<li id="personal">
						<a class="parentLink" href="#">About Quotes</a>
					</li>
					<li id="businessOwners">
						<a class="parentLink" href="#">FAQ</a>
					</li>
				</ul>
				<ul id="secondaryLinks">
					<li id="institutional">
						<a class="parentLink" href="#">Quotes Contact</a>
					</li>
				</ul>
				<ul id="accountLinks">
					<li id="account">
						<a href="#" target="_blank">
							<span>Login</span>
						</a>
						<div class="dropMenu">
							<div class="dropMenuArrow">
							</div>
							<div class="dropMenuBody">
								<div class="dropMenuClose">
								</div>
								<div class="pad20 marB0 clearfix">
									<div class="colWrapper">
										<div class="col">
											<h2>
												<a href="#" target="_blank">Logout</a>
											</h2>
											<h2>
												<a href="#" target="_blank">Profile</a>
											</h2>
										</div>
									</div>
								</div>
							</div>
						</div>
					</li>
				</ul>
			</div>
		</nav>
		<!-- end of Sanlam COM - Desktop nav -->
		<!-- Sanlam COM - Banner Image -->
		<div class="bannerContainer blog">
			<div class="bannerHolder">
				<div class="bannerHeight">
					<div class="bannerImg">
						<img src="./img/header-image.jpg" alt="One rand Family" class="responsive bg">
					</div>
				</div>

			</div>
			<div class="container">
				<div class="bannerLogo">
			    </div>
            </div>
		</div>
		<!-- end Sanlam COM - Banner Image -->
		<!-- Save POPUP -->
		<div class="screeneroverlay"></div>
          <div class="modal-wrap" id="addQuoteWrapper">
                    <div class="modal-container modal-s-ready modal-inline-holder">
                        <div class="modal-content">
                            <div id="modalBlock" class="gray-popup-block">
                        		<a href="#" class="modal-close-btn"></a>
                            	<div class="catAddContainer">
                            		<h2>Category Added</h2>
	                                <h3 class="marB15">What do you want to do next?</h3>
	                                <a href="#" class="btn">Add a new Category</a><!-- 
	                                <a href="#" class="btn">Duplicate Category</a> -->
	                                
                            	</div>
                            	<div class="catAddContainer" id="dupCategory">
                            		<select>
                            			<option>Select Category</option>
                            			<option>Managers</option>
                            			<option>Staff</option>
                            		</select>     
                            		<a href="#" class="btn" id="duplicateBtn">Duplicate</a>
                            	</div>
                            	<a href="#" class="btn marT40">I`m done adding categories</a>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Save POPUP END -->
		<!-- MONOCRUMB -->
                <div id="utilityRow" class="row toolBar">
                            <div class="container clearfix">
                                <div class="span4 clearfix">
                                    <!-- MONO CRUMB -->
                                    <span class="backBtn"><a href="/">Quotes Home</a></span>
                                </div>
                            </div>
                        </div>
                 <!-- MONOCRUMB -->       
 		<!-- HEADING START -->
		<div class="row padB0">
			<div class="container clearfix">
					<div class="data">
						<h1>New Quote Setup</h1>
						<p>Setup a new Group Risk Quote in three easy steps. Step 1) Complete the Quote Setup tab; Step 2) Add your categories on the Category Setup tab; Step 3) Upload or add your members on the Member Details tab and then click VIEW QUOTE. </p>
					</div>
			</div>
		</div>
		<!-- HEADING END -->
		<!-- QUOTE START -->
		<div class="row padT0 padB20" id="addQuote">
			<div class="container clearfix">
			<div class="saveQuoteTopBtn">
						<%--<a href="#" class="btn" id="saveQuoteBtn">Save Quote</a>     --%>
					</div>
               
             
<div id="tabs" class="tabs">
    <asp:HiddenField ID="hidtab" Value="0"  runat="server" />
				    <ul class="tab-links" runat="server">
				        <li class="active" id="tabquote"><a href="#tab1">Quote Setup<span></span></a></li>
				        <li id="tabCat"  ><a href="#tab2">Category Setup<span></span></a></li>
				        <li id="tabMember"><a href="#tab3">Member Details<span></span></a></li>
				        <li id="tabRate"><a href="#tab4">Rate Discounts<span></span></a></li>
                        <li id="tabversion"><a href="#tab5">Version Control<span></span></a></li>
                        <li id="advancedtab"><a href="#tab6">Overrides<span></span></a></li>
				    </ul>
			 
				    <div class="tab-content grayCell">

				        <div id="tab1" class="grayCell tab active">
                             <%-- <asp:Repeater ID="Repeater2" runat="server">
                                 <ItemTemplate runat="server"> 
                                      </ItemTemplate> 
                                 </asp:Repeater>--%>
                        
	                        <div class="quoteHolder">
				            		<div class="span4 puhs5 marB30">
			                            <div class="col1" id="quoteSelectWrapper">

			                                <div class="selectQuote">
			                                    <select>
			                                        <option>Select Quote</option>
			                                        <option>Quote 1</option>
			                                        <option>Quote 2</option>
			                                    </select>
			                                </div>
			                            </div>
			                            <div class="col2">
			                                <div class="quoteBtn">
			                                    <a href="#" class="btn">Replicate Existing Quote</a>
			                                </div>
			                            </div>
			                        </div>
				                    <div id="Div1" class="span5 puhs5" runat="server">
				                        <div class="col1">
				                            <h3 class="marB20">Quote Details</h3>
				                                <div id="quoteDate">
				                                    <label>Date of quote</label>				                                   <%-- <input  id="quotedatetxt" type="text" class="datepicker dob"></input>--%>

                                                    <asp:TextBox ID="quotedatetxt"  class="datepicker dob" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                                     
				                                </div>
				                                <div>
				                                    <label>Quote Number<abbr rel="tooltip" class="lableTip" title="Add quote number"> <img src="img/question-mark.png"></abbr></label>
				                                    
                                                    <asp:TextBox ID="quotenotxt"  runat="server" AutoPostBack="true" OnTextChanged="quotenotxt_TextChanged"></asp:TextBox>
                                                  
				                        </div>
				                                <div>
				                                    <label>Front Office</label>
                                                 <asp:DropDownList ID="FOnametxtDropDownList" runat="server"></asp:DropDownList>
				                              </div>
                                            <div>
				                                    <label> SUF scheme </label>
                                                 <asp:DropDownList ID="IsSUFquotedropdown" runat="server" OnSelectedIndexChanged="IsSUFquotedropdown_SelectedIndexChanged">
                                                      <asp:ListItem Value="false">No</asp:ListItem>   
                                                     <asp:ListItem  Value="true">Yes</asp:ListItem>
                                                       
                                                 </asp:DropDownList>  
				                                </div>
	
				                        </div>
				                        <div class="col1">
				                            <h3 class="marB20">Client Details</h3>
				                                <div>
				                                    <label>Client Name</label>
				                                   <asp:TextBox ID="companynametxt" runat="server"></asp:TextBox>
				                                </div>
				                                <div>
				                                    <label>Province</label>
                                                    <asp:DropDownList ID="ProvinceDropDown"  runat="server" >
                                                       
                                                 
                                                    </asp:DropDownList>
				                                    <%--<select id="province">
				                                        <option>Please Select</option>
				                                        <option>Western Cape</option>
				                                    </select>--%>
				                                </div>
				                                <div>
				                                    <label>Industry</label>
                                                    <asp:DropDownList ID="IndustryDropDown"   runat="server">
                                                        
                                                          

                                                    </asp:DropDownList>
				                                    <%--<select id="industry">
				                                        <option>Please Select</option>
				                                        <option>Western Cape</option>
				                                    </select>--%>
				                                </div>
				                        </div>
				                        <div class="col1">
				                            <h3 class="marB20">Commission and Fees</h3>
				                                <div>
				                                    <label>Vat on Comission</label>
                                                    <asp:DropDownList ID="vatCommssion" runat="server">
                                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                    </asp:DropDownList>
				                                   
				                                </div>
				                                <div>
				                                    <label>New Scheme Commission</label>
                                                    <asp:DropDownList ID="schemeCommission" runat="server">
                                                           <asp:ListItem Value="false">No</asp:ListItem>
                                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                                     
                                                    </asp:DropDownList>
				                                   
				                                </div>
                                             <div>
				                                    <label>Commission Discount Percentage</label>

                                                 <asp:DropDownList ID="CommonDiscountDropDownList"   runat="server">
                                                   
                                                 </asp:DropDownList>
				                                  <%--   <asp:TextBox ID="commondiscounttxt" runat="server"></asp:TextBox>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Plese insert decimal value" ControlToValidate="commondiscounttxt" ForeColor="Red" ValidationExpression="^(1\d\d|[1-9]\d|\d)\.\d{0,8}[1-9]$">
                    </asp:RegularExpressionValidator>--%>
				                              </div>

                                            <div>
				                                    <label>Binder Fee Percentage</label>
				                                 <input id="BinderFeePerctxt" runat="server" value="10"  text="10" type="text" class=""></input>
                                                 <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Plese insert decimal value" ControlToValidate="BinderFeePerctxt" ForeColor="Red" ValidationExpression="^(1\d\d|[1-9]\d|\d)\.\d{0,8}[1-9]$">
                    </asp:RegularExpressionValidator>--%>
                                                 <asp:CompareValidator ID="CompareValidator19" runat="server" ControlToValidate="BinderFeePerctxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Plese insert Numeric value">  
                                                     </asp:CompareValidator>
				                                </div>
				                              <div>
				                                    <label>Outsource Fee Percentage</label>
				                                     <asp:TextBox ID="outsourcefeetxt" Text="3" runat="server"></asp:TextBox>
                                               <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Plese insert decimal value" ControlToValidate="outsourcefeetxt" ForeColor="Red" ValidationExpression="^(1\d\d|[1-9]\d|\d)\.\d{0,8}[1-9]$">
                    </asp:RegularExpressionValidator>--%>
                                                   <asp:CompareValidator ID="CompareValidator20" runat="server" ControlToValidate="outsourcefeetxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Plese insert Numeric value">  
				                                </asp:CompareValidator>
                                                 <%--  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="outsourcefeetxt" Operator="DataTypeCheck" Type="Decimal(18,6)" ErrorMessage="Input valid Date">  
                </asp:CompareValidator>  --%>                                           
				                                </div>
				                              
				                        </div>
			<%--ValidationGroup="vgSubmit"--%>
                                        <div class="col1">
				                            <h3 class="marB20">&nbsp;</h3>

			                        </div>

                                        <div class="col1" hidden="hidden">
				                            <h3 class="marB20">&nbsp;</h3>
				                             
                                             <div>
				                                    <label> Broker Name </label>
				                                    <input  ID="brokernametxt" type="text" class="" runat="server" />
				                              </div>       
                                             <div>
				                                    <label> Quote Expiry Date </label>
				                                    <input id="datevalidtilltxt" type="text" class="datepicker dob" runat="server" ></input>
				                                </div>                                    
				                        </div>  
                                                                             
                                        <div class="col1" hidden="hidden">
				                            <h3 class="marB20">Advanced Features</h3>

                                             <div>
				                                    <label> PTD Tapering (years) </label>
                                                 <asp:DropDownList ID="GOAtaperingYearsDropDownList" runat="server"></asp:DropDownList>
                                                
				                                </div>
                                          
                                             <div>
				                                    <label>AF Fund</label>
                                                 <asp:DropDownList ID="AFschemeDropDownList" runat="server"></asp:DropDownList>
				                              </div>

                                             <div>
				                                    <label>AF Fund Type</label>
                                                 <asp:DropDownList ID="AFschemeTypeDropDownList" runat="server"></asp:DropDownList>
				                              </div>
                                             <div>
				                                    <label>Renewal Month</label>
				                                    <input id="renewalmonthtxt" runat="server" type="text" class=""></input>
                                                  <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Plese insert decimal value" ControlToValidate="renewalmonthtxt" ForeColor="Red" ValidationExpression="^(1\d\d|[1-9]\d|\d)\.\d{0,8}[1-9]$">
                    </asp:RegularExpressionValidator>--%>
                                                  <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="renewalmonthtxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Plese insert Numeric value">  
				                                </asp:CompareValidator>
				                              </div>                                      				                                
				                        </div>

                                        <div class="col1" hidden="hidden">
                                             <h3 class="marB20">&nbsp;</h3>
				                             <div>
				                                    <label>Next Renewal Date</label>
				                                    <input id="nextrenewaldatetxt" runat="server" type="text" class="datepicker dob"></input>
				                              </div>

                                             <div>
				                                    <label> Participating Employer </label>
				                                    <input id="participatingemployer" runat="server" type="text" class=""></input>
				                                </div>
                                             <div>
				                                    <label> Fund Name </label>
				                                    <input id="fundnametxt" runat="server" type="text" class=""></input>
				                                </div>
                                             <div>
				                                    <label> Fund Year End </label>
				                                    <input id="fundyearend" runat="server" type="text" class=""></input>
				                                </div> 

                                            </div>
				                    </div>
			        		</div>
                                     
				        </div>
				 
				        <div id="tab2" class="tab">
                                                    
           
					    <div id="accordianCAtegory"  runat="server" >                                                                                                                                                                                   
                                
					        	<div style="width:1139px; height:900px;" >
          <div  style="width:200px; float:left;">
              <asp:Table ID="Table2" style="font-weight:600; border-right-style:solid; border-right-color:lightgray; border-right-width:0.5px;"  runat="server"   >
                  <asp:TableRow   style="height:50px; " ID="TableRow64" runat="server" >
                    <asp:TableCell ID="TableCell64" runat="server">
                        
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow181" runat="server">
                    <asp:TableCell ID="TableCell180" runat="server">
                        <asp:Label ID="Label42" runat="server" Text="Label"> Category Name </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow182" runat="server">
                    <asp:TableCell ID="TableCell181" runat="server">
                        <asp:Label ID="Label48" runat="server" Text="Label"> Retirement Age </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  
                      <asp:TableRow   style="height:73px;" ID="TableRow209" runat="server">
                    <asp:TableCell ID="TableCell208" runat="server">
                        <asp:Label ID="Label114" runat="server" Text="Label"> Cover To Age 70  </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:73px;" ID="TableRow1" runat="server">
                    <asp:TableCell ID="TableCell1" runat="server">
                        <asp:Label ID="HasGLAlabel" runat="server" Text="Label"> Life Insurance (GLA) </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow2" runat="server">
                    <asp:TableCell ID="TableCell2" runat="server">
                        <asp:Label ID="iglapatterlabel" runat="server" Text="Label">GLA Cover Format</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow    style="height:71px;" ID="TableRow6" runat="server">
                    <asp:TableCell ID="TableCell6" runat="server">
                        <asp:Label ID="Label1" runat="server" Text="Label">GLA Multiple of Salary</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow7" runat="server">
                    <asp:TableCell ID="TableCell7" runat="server">
                        <asp:Label ID="Label2" runat="server" Text="Label">GLA Flat Cover Amount</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style=" height:50px; " ID="TableRow8" runat="server">
                    <asp:TableCell ID="TableCell8" runat="server" style=" border-right-color:lightgray ">
                        <asp:Label ID="Label4" Font-Bold="true" Font-Size="Small" runat="server" Text="Label">Ages for Bands</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow    style=" height:71px; " ID="TableRow9" runat="server"  >
                    <asp:TableCell ID="TableCell9" runat="server">
                        <asp:Label ID="Label5" runat="server" Text="Label">Age Cut Off: Band 1</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow    ID="TableRow10" runat="server">
                    <asp:TableCell ID="TableCell10" runat="server">
                        <asp:Label ID="Label6" runat="server" Text="Label">Age Cut Off: Band 2</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow    ID="TableRow11" runat="server">
                    <asp:TableCell ID="TableCell11" runat="server">
                        <asp:Label ID="Label7" runat="server" Text="Label">Age Cut Off: Band 3</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow12" runat="server">
                    <asp:TableCell ID="TableCell12" runat="server">
                        <asp:Label ID="Label8" runat="server" Text="Label">Age Cut Off: Band 4</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow13" runat="server">
                    <asp:TableCell ID="TableCell13" runat="server">
                        <asp:Label ID="Label9" runat="server" Text="Label">Age Cut Off: Band 5</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow14" runat="server">
                    <asp:TableCell ID="TableCell14" runat="server">
                        <asp:Label ID="Label10" runat="server" Text="Label">Age Cut Off: Band 6</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow15" runat="server">
                    <asp:TableCell ID="TableCell15" runat="server">
                        <asp:Label ID="Label11" runat="server" Text="Label">Age Cut Off: Band 7</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  
                  
                  <asp:TableRow   style="height:50px;" ID="TableRow18" runat="server">
                    <asp:TableCell ID="TableCell18" runat="server">
                        <asp:Label ID="Label14" runat="server" Text="Label">Life Insurance (GLA) Multiple</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  
                  <asp:TableRow   style="height:71px;" ID="TableRow20" runat="server">
                    <asp:TableCell ID="TableCell20" runat="server">
                        <asp:Label ID="Label16" runat="server" Text="Label">GLA Multiple: Band 1</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow21" runat="server">
                    <asp:TableCell ID="TableCell21" runat="server">
                        <asp:Label ID="Label17" runat="server" Text="Label">GLA Multiple: Band 2</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow22" runat="server">
                    <asp:TableCell ID="TableCell22" runat="server">
                        <asp:Label ID="Label18" runat="server" Text="Label">GLA Multiple: Band 3</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow23" runat="server">
                    <asp:TableCell ID="TableCell23" runat="server">
                        <asp:Label ID="Label19" runat="server" Text="Label">GLA Multiple: Band 4</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow24" runat="server">
                    <asp:TableCell ID="TableCell24" runat="server">
                        <asp:Label ID="Label20" runat="server" Text="Label">GLA Multiple: Band 5</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow25" runat="server">
                    <asp:TableCell ID="TableCell25" runat="server">
                        <asp:Label ID="Label21" runat="server" Text="Label">GLA Multiple: Band 6</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow26" runat="server">
                    <asp:TableCell ID="TableCell26" runat="server">
                        <asp:Label ID="Label22" runat="server" Text="Label">GLA Multiple: Band 7</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow27" runat="server">
                    <asp:TableCell ID="TableCell27" runat="server">
                        <asp:Label ID="Label23" runat="server" Text="Label">GLA Multiple: Band 8</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  
                  <asp:TableRow   style="height:71px;" ID="TableRow29" runat="server">
                    <asp:TableCell ID="TableCell29" runat="server">
                        <asp:Label ID="Label25" runat="server" Text="Label">PTD Multiple: Band 1</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow30" runat="server">
                    <asp:TableCell ID="TableCell30" runat="server">
                        <asp:Label ID="Label26" runat="server" Text="Label">PTD Multiple: Band 2</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow31" runat="server">
                    <asp:TableCell ID="TableCell31" runat="server">
                        <asp:Label ID="Label27" runat="server" Text="Label">PTD Multiple: Band 3</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow32" runat="server">
                    <asp:TableCell ID="TableCell32" runat="server">
                        <asp:Label ID="Label28" runat="server" Text="Label">PTD Multiple: Band 4</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow    style="height:71px;" ID="TableRow33" runat="server">
                    <asp:TableCell ID="TableCell33" runat="server">
                        <asp:Label ID="Label29" runat="server" Text="Label">PTD Multiple: Band 5</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow34" runat="server">
                    <asp:TableCell ID="TableCell34" runat="server">
                        <asp:Label ID="Label30" runat="server" Text="Label">PTD Multiple: Band 6</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow35" runat="server">
                    <asp:TableCell ID="TableCell35" runat="server">
                        <asp:Label ID="Label31" runat="server" Text="Label">PTD Multiple: Band 7</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow36" runat="server">
                    <asp:TableCell ID="TableCell36" runat="server">
                        <asp:Label ID="Label32" runat="server" Text="Label">PTD Multiple: Band 8</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow78" runat="server">
                    <asp:TableCell ID="TableCell78" runat="server">
                        <asp:Label ID="Label33" runat="server" Text="Label">GLA Cover to Continue during Disability</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow79" runat="server">
                    <asp:TableCell ID="TableCell79" runat="server">
                        <asp:Label ID="Label34" runat="server" Text="Label">GLA Growth in Cover during Disability</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  
                  


                  <asp:TableRow   style="height:73px;" ID="TableRow80" runat="server">
                    <asp:TableCell ID="TableCell80" runat="server">
                        <asp:Label ID="Label35" runat="server" Text="Label">Terminal Illness Benefit</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow  style="height:73px;" ID="TableRow81" runat="server">
                    <asp:TableCell ID="TableCell81" runat="server">
                        <asp:Label ID="Label36" runat="server" Text="Label">Tax Replacement Cover</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow  style="height:73px;" ID="TableRow82" runat="server">
                    <asp:TableCell ID="TableCell82" runat="server">
                        <asp:Label ID="Label37" runat="server" Text="Label">GLA Conversion Option</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow  style="height:73px;" ID="TableRow83" runat="server">
                    <asp:TableCell ID="TableCell83" runat="server">
                        <asp:Label ID="Label38" runat="server" Text="Label">GLA Flex Cover</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow  style="height:71px;" ID="TableRow84" runat="server">
                    <asp:TableCell ID="TableCell84" runat="server">
                        <asp:Label ID="Label39" runat="server" Text="Label">GLA Core Cover Multiple</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow85" runat="server">
                    <asp:TableCell ID="TableCell85" runat="server">
                        <asp:Label ID="Label40" runat="server" Text="Label">Universal Education Protector</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  
                  
                  
                   <asp:TableRow   style="height:50px;" ID="TableRow77" runat="server">
                    <asp:TableCell ID="TableCell77" runat="server">
                        <asp:Label ID="Label3" runat="server" Text="Label">Lump Sum Disability</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow92" runat="server">
                    <asp:TableCell ID="TableCell92" runat="server">
                        <asp:Label ID="Label44" runat="server" Text="Label">Lump Sum Disability (PTD) </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow88" runat="server">
                    <asp:TableCell ID="TableCell88" runat="server">
                        <asp:Label ID="Label12" runat="server" Text="Label">PTD Cover Format</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
              


                  <asp:TableRow   style="height:71px;" ID="TableRow89" runat="server">
                    <asp:TableCell ID="TableCell89" runat="server">
                        <asp:Label ID="Label13" runat="server" Text="Label">PTD Multiple of Salary</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow90" runat="server">
                    <asp:TableCell ID="TableCell90" runat="server">
                        <asp:Label ID="Label15" runat="server" Text="Label">PTD Flat Cover Amount</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow91" runat="server">
                    <asp:TableCell ID="TableCell91" runat="server">
                        <asp:Label ID="Label43" runat="server" Text="Label">PTD Convertion Option</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                     <asp:TableRow   style="height:50px;" ID="TableRow54" runat="server">
                    <asp:TableCell ID="TableCell54" runat="server">
                        <asp:Label ID="Label45" runat="server" Text="Label">Accident Benefit</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:73px;" ID="TableRow55" runat="server">
                    <asp:TableCell ID="TableCell55" runat="server">
                        <asp:Label ID="Label46" runat="server" Text="Label">Accident Benefit</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:71px;" ID="TableRow56" runat="server">
                    <asp:TableCell ID="TableCell56" runat="server">
                        <asp:Label ID="Label47" runat="server" Text="Label">Accident Multiple</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow  style="height:73px;" ID="TableRow86" runat="server">
                    <asp:TableCell ID="TableCell86" runat="server">
                        <asp:Label ID="Label41" runat="server" Text="Label">Accident Cover Type</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:50px;" ID="TableRow58" runat="server">
                    <asp:TableCell ID="TableCell58" runat="server">
                        <asp:Label ID="Label49" runat="server" Text="Label">Critical Illness Insurance</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:73px;" ID="TableRow59" runat="server">
                    <asp:TableCell ID="TableCell59" runat="server">
                        <asp:Label ID="Label50" runat="server" Text="Label">Critical Illness Insurance (CII)</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <%--   <asp:TableRow   style="height:73px;" ID="TableRow60" runat="server">
                    <asp:TableCell ID="TableCell60" runat="server">
                        <asp:Label ID="Label51" runat="server" Text="Label">CII Cover Format</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>--%>
                   <asp:TableRow   style="height:71px;" ID="TableRow61" runat="server">
                    <asp:TableCell ID="TableCell61" runat="server">
                        <asp:Label ID="Label52" runat="server" Text="Label">CII Multiple</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:71px;" ID="TableRow62" runat="server">
                    <asp:TableCell ID="TableCell62" runat="server">
                        <asp:Label ID="Label53" runat="server" Text="Label">CII Flat Cover Amount</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:73px;" ID="TableRow63" runat="server">
                    <asp:TableCell ID="TableCell63" runat="server">
                        <asp:Label ID="Label54" runat="server" Text="Label">CII Cover Type</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:73px;" ID="TableRow93" runat="server">
                    <asp:TableCell ID="TableCell93" runat="server">
                        <asp:Label ID="Label55" runat="server" Text="Label">CII Cover to Continue during Disability</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:73px;" ID="TableRow655" runat="server">
                    <asp:TableCell ID="TableCell655" runat="server">
                        <asp:Label ID="Label56" runat="server" Text="Label">CII Growth in Cover during Disability</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <%--     <asp:TableRow   style="height:73px;" ID="TableRow197" runat="server">
                    <asp:TableCell ID="TableCell196" runat="server">
                        <asp:Label ID="Label103" runat="server" Text="Label">iHasCoverTo70</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>--%>




                   <asp:TableRow   style="height:73px;" ID="TableRow66" runat="server">
                    <asp:TableCell ID="TableCell66" runat="server">
                        <asp:Label ID="Label57" runat="server" Text="Label">CII Convertion Option</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  


                  <asp:TableRow   style="height:50px;" ID="TableRow144" runat="server">
                    <asp:TableCell ID="TableCell143" runat="server">
                        <asp:Label ID="Label74" runat="server" Text="Label">Disability Income Insurance</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow117" runat="server">
                    <asp:TableCell ID="TableCell116" runat="server">
                        <asp:Label ID="Label58" runat="server" Text="Label">Disability Income (PHI)</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                     <asp:TableRow   style="height:73px;" ID="TableRow196" runat="server">
                    <asp:TableCell ID="TableCell195" runat="server">
                        <asp:Label ID="Label102" runat="server" Text="Label">PHI Waiver Format</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow118" runat="server">
                    <asp:TableCell ID="TableCell117" runat="server">
                        <asp:Label ID="Label59" runat="server" Text="Label">PHI Scale</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                    
                   

                    <asp:TableRow   style="height:71px;" ID="TableRow119" runat="server">
                    <asp:TableCell ID="TableCell118" runat="server">
                        <asp:Label ID="Label60" runat="server" Text="Label">PHI Benefit Percentage: Tier 1</asp:Label>
                    </asp:TableCell>

                </asp:TableRow>

                   <asp:TableRow   style="height:71px;" ID="TableRow114" runat="server">
                    <asp:TableCell ID="TableCell114" runat="server">
                        <asp:Label ID="Label62" runat="server" Text="Label">PHI Salary Limit: Tier 1</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>


                    <asp:TableRow   style="height:71px;" ID="TableRow120" runat="server">
                    <asp:TableCell ID="TableCell119" runat="server">
                        <asp:Label ID="Label61" runat="server" Text="Label">PHI Benefit Percentage: Tier 2</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:71px;" ID="TableRow122" runat="server">
                    <asp:TableCell ID="TableCell121" runat="server">
                        <asp:Label ID="Label63" runat="server" Text="Label">PHI Salary Limit: Tier 2</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                    <asp:TableRow   style="height:71px;" ID="TableRow123" runat="server">
                    <asp:TableCell ID="TableCell122" runat="server">
                        <asp:Label ID="Label64" runat="server" Text="Label">PHI Benefit Percentage: Tier 3</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow124" runat="server">
                    <asp:TableCell ID="TableCell123" runat="server">
                        <asp:Label ID="Label65" runat="server" Text="Label">PHI Waiting Period</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:71px;" ID="TableRow125" runat="server">
                    <asp:TableCell ID="TableCell124" runat="server">
                        <asp:Label ID="Label66" runat="server" Text="Label">PHI Waiver Percentage</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:71px;" ID="TableRow126" runat="server">
                    <asp:TableCell ID="TableCell125" runat="server">
                        <asp:Label ID="Label67" runat="server" Text="Label">PHI Escalation Percentage</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow127" runat="server">
                    <asp:TableCell ID="TableCell126" runat="server">
                        <asp:Label ID="Label68" runat="server" Text="Label">PHI Convertion Option</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow128" runat="server">
                    <asp:TableCell ID="TableCell127" runat="server">
                        <asp:Label ID="Label69" runat="server" Text="Label">Top-Up Benefit</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow129" runat="server">
                    <asp:TableCell ID="TableCell128" runat="server">
                        <asp:Label ID="Label70" runat="server" Text="Label">Medical Aid Premium Waiver (MAPW)</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                    <asp:TableRow   style="height:71px;" ID="TableRow130" runat="server">
                    <asp:TableCell ID="TableCell129" runat="server">
                        <asp:Label ID="Label71" runat="server" Text="Label">MAPW Payment Term</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow131" runat="server">
                    <asp:TableCell ID="TableCell130" runat="server">
                        <asp:Label ID="Label72" runat="server" Text="Label">Salary Refund (SR)</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow132" runat="server">
                    <asp:TableCell ID="TableCell131" runat="server">
                        <asp:Label ID="Label73" runat="server" Text="Label">SR Benefit Multiple</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>


                      <asp:TableRow   style="height:70px;" ID="TableRow199" runat="server">
                    <asp:TableCell ID="TableCell198" runat="server">
                        <asp:Label ID="Label104" runat="server" Text="Label">Temporary Income Disability</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:73px;" ID="TableRow200" runat="server">
                    <asp:TableCell ID="TableCell199" runat="server">
                        <asp:Label ID="Label105" runat="server" Text="Label">Temporary Income Disability (TTD)</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                       <asp:TableRow   style="height:73px;" ID="TableRow201" runat="server">
                    <asp:TableCell ID="TableCell200" runat="server">
                        <asp:Label ID="Label106" runat="server" Text="Label">TTD Scale</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                  

                     <asp:TableRow   style="height:71px;" ID="TableRow202" runat="server">
                    <asp:TableCell ID="TableCell201" runat="server">
                        <asp:Label ID="Label107" runat="server" Text="Label">TTD Benefit Percentage: Tier 1</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                       <asp:TableRow   style="height:71px;" ID="TableRow203" runat="server">
                    <asp:TableCell ID="TableCell202" runat="server">
                        <asp:Label ID="Label108" runat="server" Text="Label">TTD Salary Limit: Tier1</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>


                     <asp:TableRow   style="height:71px;" ID="TableRow204" runat="server">
                    <asp:TableCell ID="TableCell203" runat="server">
                        <asp:Label ID="Label109" runat="server" Text="Label">TTD Benefit Percentage: Tier 2</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                       <asp:TableRow   style="height:71px;" ID="TableRow205" runat="server">
                    <asp:TableCell ID="TableCell204" runat="server">
                        <asp:Label ID="Label110" runat="server" Text="Label">TTD Salary Limit: Tier2</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                         <asp:TableRow   style="height:71px;" ID="TableRow206" runat="server">
                    <asp:TableCell ID="TableCell205" runat="server">
                        <asp:Label ID="Label111" runat="server" Text="Label">TTD Benefit Percentage: Tier 3</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>


                       <asp:TableRow   style="height:73px;" ID="TableRow163" runat="server">
                    <asp:TableCell ID="TableCell163" runat="server">
                        <asp:Label ID="Label85" runat="server" Text="Label">TTD Waiting Period / Payment Period</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                           <asp:TableRow   style="height:73px;" ID="TableRow207" runat="server">
                    <asp:TableCell ID="TableCell206" runat="server">
                        <asp:Label ID="Label112" runat="server" Text="Label">TTD Waiver Format</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                           <asp:TableRow   style="height:71px;" ID="TableRow208" runat="server">
                    <asp:TableCell ID="TableCell207" runat="server">
                        <asp:Label ID="Label113" runat="server" Text="Label">TTD Waiver Percentage</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>



                    <asp:TableRow   style="height:50px;" ID="TableRow197" runat="server">
                    <asp:TableCell ID="TableCell196" runat="server">
                        <asp:Label ID="Label103" runat="server" Text="Label">Funeral Insurance </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>





                    <asp:TableRow   style="height:73px;" ID="TableRow133" runat="server">
                    <asp:TableCell ID="TableCell132" runat="server">
                        <asp:Label ID="Label75" runat="server" Text="Label">Funeral Benefit (FUN)</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                     


                    <asp:TableRow   style="height:71px;" ID="TableRow134" runat="server">
                    <asp:TableCell ID="TableCell133" runat="server">
                        <asp:Label ID="Label76" runat="server" Text="Label">FUN Cover Amount</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow135" runat="server">
                    <asp:TableCell ID="TableCell134" runat="server">
                        <asp:Label ID="Label77" runat="server" Text="Label">Transport Benefit</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:50px;" ID="TableRow136" runat="server">
                    <asp:TableCell ID="TableCell135" runat="server">
                        <asp:Label ID="Label78" runat="server" Text="Label">Spouses Insurance</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>


                    <asp:TableRow   style="height:73px;" ID="TableRow137" runat="server">
                    <asp:TableCell ID="TableCell136" runat="server">
                        <asp:Label ID="Label79" runat="server" Text="Label">Spouses Life Insurance</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow138" runat="server">
                    <asp:TableCell ID="TableCell137" runat="server">
                        <asp:Label ID="Label80" runat="server" Text="Label">Cover Format</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:71px;" ID="TableRow139" runat="server">
                    <asp:TableCell ID="TableCell138" runat="server">
                        <asp:Label ID="Label81" runat="server" Text="Label">Spouses GLA Multiple</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:71px;" ID="TableRow140" runat="server">
                    <asp:TableCell ID="TableCell139" runat="server">
                        <asp:Label ID="Label82" runat="server" Text="Label">Spouses GLA Flat Cover Amount</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    
                    <asp:TableRow   style="height:73px;" ID="TableRow142" runat="server">
                    <asp:TableCell ID="TableCell141" runat="server">
                        <asp:Label ID="Label84" runat="server" Text="Label">Spouses GLA Convertion Option</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow143" runat="server">
                    <asp:TableCell ID="TableCell142" runat="server">
                        <asp:Label ID="Label385" runat="server" Text="Label">Spouses Lump Sum Disability</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
             <%--     <asp:TableRow   style="height:73px;" ID="TableRow145" runat="server">
                    <asp:TableCell ID="TableCell144" runat="server">
                        <asp:Label ID="Label86" runat="server" Text="Label">Cover Format</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>--%>
                    <asp:TableRow   style="height:71px;" ID="TableRow146" runat="server">
                    <asp:TableCell ID="TableCell145" runat="server">
                        <asp:Label ID="Label87" runat="server" Text="Label">Spouses PTD Multiple</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow   style="height:71px;" ID="TableRow147" runat="server">
                <asp:TableCell ID="TableCell146" runat="server">
                    <asp:Label ID="Label88" runat="server" Text="Label">Spouses PTD Flat Cover Amount</asp:Label>
                </asp:TableCell>
            </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow178" runat="server">
                    <asp:TableCell ID="TableCell177" runat="server">
                        <asp:Label ID="Label101" runat="server" Text="Label">Spouses PTD Convertion Option</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:50px;" ID="TableRow148" runat="server">
                    <asp:TableCell ID="TableCell147" runat="server">
                        <asp:Label ID="Label89" runat="server" Text="Label">Advanced Features</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow149" runat="server">
                    <asp:TableCell ID="TableCell148" runat="server">
                        <asp:Label ID="Label90" runat="server" Text="Label">PTD Waiting Period</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow150" runat="server">
                    <asp:TableCell ID="TableCell149" runat="server">
                        <asp:Label ID="Label91" runat="server" Text="Label">PTD Payable in Instalments</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:71px;" ID="TableRow151" runat="server">
                    <asp:TableCell ID="TableCell150" runat="server">
                        <asp:Label ID="Label92" runat="server" Text="Label">Number of Instalments</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow152" runat="server">
                    <asp:TableCell ID="TableCell151" runat="server">
                        <asp:Label ID="Label93" runat="server" Text="Label">PTD Alternative Pre-Ex Clause</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:71px;" ID="TableRow153" runat="server">
                    <asp:TableCell ID="TableCell152" runat="server">
                        <asp:Label ID="Label94" runat="server" Text="Label">Pre-Ex Clause</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:73px;" ID="TableRow154" runat="server">
                    <asp:TableCell ID="TableCell153" runat="server">
                        <asp:Label ID="Label95" runat="server" Text="Label">PTD Alternative Occupation Definition</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                       <asp:TableRow   style="height:71px;" ID="TableRow155" runat="server">
                    <asp:TableCell ID="TableCell154" runat="server">
                        <asp:Label ID="Label96" runat="server" Text="Label">Occupation Definition</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                   <asp:TableRow   style="height:73px;" ID="TableRow156" runat="server">
                    <asp:TableCell ID="TableCell155" runat="server">
                        <asp:Label ID="Label97" runat="server" Text="Label">PHI Alternative Occupation Definition</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:71px;" ID="TableRow157" runat="server">
                    <asp:TableCell ID="TableCell156" runat="server">
                        <asp:Label ID="Label98" runat="server" Text="Label">Occupation Definition</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow   style="height:73px;" ID="TableRow158" runat="server">
                    <asp:TableCell ID="TableCell157" runat="server">
                        <asp:Label ID="Label99" runat="server" Text="Label">PHI Alternative Escalation</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow   style="height:71px;" ID="TableRow159" runat="server">
                    <asp:TableCell ID="TableCell158" runat="server">
                        <asp:Label ID="Label100" runat="server" Text="Label">Escalation</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                       
                   <asp:TableRow   style="height:71px;" ID="TableRow194" runat="server">
                    <asp:TableCell ID="TableCell193" runat="server">
                        <asp:Label ID="Label24" runat="server" Text="Label">Benefit Scaling Factor</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                     <asp:TableRow   style="height:71px;" ID="TableRow195" runat="server">
                    <asp:TableCell ID="TableCell194" runat="server">
                        <asp:Label ID="Label83" runat="server" Text="Label">Salary Scaling Factor</asp:Label>
                    </asp:TableCell>
                </asp:TableRow>





              </asp:Table>

          </div>

          <div  style="width:939px; overflow-y:hidden;  overflow-x:auto;white-space: nowrap;">
           <div id="divconetnet" runat="server" >
           <asp:Repeater ID="testrepeater" EnableViewState="false"  runat="server"  OnItemDataBound="testrepeater_ItemDataBound" >
                <ItemTemplate >
        <div style="width:250px;  float:left; display:inline; ">           
            <asp:Table ID="Table1" runat="server" style="border-right-style:solid; border-right-color:lightgray; border-right-width:0.5px;"   >
                <asp:TableRow ID="TableRow3"  style="height:50px;" runat="server">
                    <asp:TableCell ID="TableCell3"  runat="server">
                        <asp:Label  ID="categorylabel" style=" font-weight:800;" runat="server" ></asp:Label>
                        <asp:HiddenField ID="categoryno" Value='<%#Eval("iCategoryNumber") %>' runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow75"  style="height:50px;" runat="server">
                    <asp:TableCell ID="TableCell75"   runat="server">
                        <asp:TextBox ID="categorydescrip" Text='<%#Eval("iCategoryDescription") %>' runat="server"   ></asp:TextBox>
                      <%--  <asp:TextBox ID="TextBox1" Text='<%#Eval("iQuoteNumber") %>' runat="server" ></asp:TextBox>--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow180"  style="height:50px;" runat="server">
                    <asp:TableCell ID="TableCell179"   runat="server">
                        <asp:TextBox ID="RetAgetext"  runat="server"  Text='<%#Eval("iRetAge").ToString()==string.Empty?"65":Eval("iRetAge").ToString() %>'  ></asp:TextBox>
                     
                      <%--  <asp:TextBox ID="TextBox1" Text='<%#Eval("iQuoteNumber") %>' runat="server" ></asp:TextBox>--%>
                    </asp:TableCell>
                </asp:TableRow>
                <%-- Life insurence Section start --%>
                <asp:TableRow ID="TableRow183"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell182"   runat="server">
                     
                          <asp:DropDownList ID="iHasCoverTo70drop"  SelectedValue='<%# Eval("iHasCoverTo70").ToString()=="True" || Eval("iHasCoverTo70")=="1"?"true":"false" %>' runat="server">
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>


                <asp:TableRow ID="TableRow4"  style="height:50px;" runat="server">
                    <asp:TableCell ID="TableCell4"   runat="server">
                        <asp:DropDownList ID="HasGladropdown" SelectedValue='<%# Eval("iHasGLA").ToString()=="True"|| Eval("iHasGLA")=="1" ?"true":"false" %>'  runat="server">
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                        </asp:DropDownList>
                      <%--  <asp:TextBox ID="TextBox1" Text='<%#Eval("iQuoteNumber") %>' runat="server" ></asp:TextBox>--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell5"   runat="server">
                        <%--SelectedItem='<%# DataBinder.Eval(Container.DataItem,"iGLApattern").ToString()%>'--%>
                       <%-- <asp:CheckBox checked='<%# Eval("iHasNBComm").ToString()!=string.Empty ? Convert.ToBoolean(Eval("iHasNBComm")) : false   %>' ID ="CheckBox1" runat="server" />--%>
                <asp:DropDownList ID="iglapatterndropdown"    runat="server" >
                            
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow37"    runat="server">
                    <asp:TableCell ID="TableCell37"  runat="server">
                         <%--Enabled='<%# Eval("iGLApattern").Equals("Multiple")?true:false %>'--%>
                        <%--<asp:CheckBox checked='<%# Eval("iHasNBComm").ToString()!=string.Empty ? Convert.ToBoolean(Eval("iHasNBComm")) : false   %>' ID ="CheckBox2" runat="server" />--%>
                      <asp:TextBox ID="iglamultipleText" Text='<%#Eval("iGLAmultiple").ToString()!=string.Empty?Eval("iGLAmultiple"):"3" %>' runat="server"   ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="iglamultipleText" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                         
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow38"   style="height:70px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell38"  runat="server">
                     <%--   Enabled='<%# Eval("iGLApattern").Equals("Flat")?true:false %>'--%>
                         <asp:TextBox ID="GLAflatCoverAmtxt" Text='<%#Eval("iGLAflatCoverAmt") %>'   runat="server" ></asp:TextBox> 
                        <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="GLAflatCoverAmtxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>                      
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow39"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell39"   runat="server">
                       
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow40"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell40"   runat="server">
                        <asp:TextBox ID="AgeCutOff1txt" Text='<%#Eval("iAgeCutOff1") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator23" runat="server" ControlToValidate="AgeCutOff1txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow41"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell41"   runat="server">
                        <asp:TextBox ID="AgeCutOff2txt" Text='<%#Eval("iAgeCutOff2") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator24" runat="server" ControlToValidate="AgeCutOff2txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow42"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell42"   runat="server">
                        <asp:TextBox ID="AgeCutOff3txt" Text='<%#Eval("iAgeCutOff3") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator25" runat="server" ControlToValidate="AgeCutOff3txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow43"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell43"   runat="server">
                        <asp:TextBox ID="AgeCutOff4txt" Text='<%#Eval("iAgeCutOff4") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator26" runat="server" ControlToValidate="AgeCutOff4txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow44"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell44"   runat="server">
                        <asp:TextBox ID="AgeCutOff5txt" Text='<%#Eval("iAgeCutOff5") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator27" runat="server" ControlToValidate="AgeCutOff5txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow45"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell45"   runat="server">
                        <asp:TextBox ID="AgeCutOff6txt" Text='<%#Eval("iAgeCutOff6") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator28" runat="server" ControlToValidate="AgeCutOff6txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow46"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell46"   runat="server">
                        <asp:TextBox ID="AgeCutOff7txt" Text='<%#Eval("iAgeCutOff7") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator29" runat="server" ControlToValidate="AgeCutOff7txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow47"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell47"   runat="server">
                      
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow48"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell48"   runat="server">
                        <asp:TextBox ID="AgeMultGLA1txt" Text='<%#Eval("iAgeMultGLA1") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator30" runat="server" ControlToValidate="AgeMultGLA1txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow49"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell49"   runat="server">
                        <asp:TextBox ID="AgeMultGLA2txt" Text='<%#Eval("iAgeMultGLA2") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator31" runat="server" ControlToValidate="AgeMultGLA2txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow50"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell50"   runat="server">
                        <asp:TextBox ID="AgeMultGLA3txt" Text='<%#Eval("iAgeMultGLA3") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator32" runat="server" ControlToValidate="AgeMultGLA3txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow51"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell51"   runat="server">
                        <asp:TextBox ID="AgeMultGLA4txt" Text='<%#Eval("iAgeMultGLA4") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator33" runat="server" ControlToValidate="AgeMultGLA4txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow52"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell52"   runat="server">
                        <asp:TextBox ID="AgeMultGLA5txt" Text='<%#Eval("iAgeMultGLA5") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator34" runat="server" ControlToValidate="AgeMultGLA5txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow53"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell53"   runat="server">
                        <asp:TextBox ID="AgeMultGLA6txt" Text='<%#Eval("iAgeMultGLA6") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator35" runat="server" ControlToValidate="AgeMultGLA6txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow54"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell54"   runat="server">
                        <asp:TextBox ID="AgeMultGLA7txt" Text='<%#Eval("iAgeMultGLA7") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator36" runat="server" ControlToValidate="AgeMultGLA7txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow55"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell55"   runat="server">
                        <asp:TextBox ID="AgeMultGLA8txt" Text='<%#Eval("iAgeMultGLA8") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator37" runat="server" ControlToValidate="AgeMultGLA8txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow ID="TableRow57"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell57"   runat="server">
                        <asp:TextBox ID="AgeMultPTD1txt" Text='<%#Eval("iAgeMultPTD1") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator38" runat="server" ControlToValidate="AgeMultPTD1txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow58"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell58"   runat="server">
                        <asp:TextBox ID="AgeMultPTD2txt" Text='<%#Eval("iAgeMultPTD2") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator39" runat="server" ControlToValidate="AgeMultPTD2txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow59"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell59"   runat="server">
                        <asp:TextBox ID="AgeMultPTD3txt" Text='<%#Eval("iAgeMultPTD3") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator40" runat="server" ControlToValidate="AgeMultPTD3txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow60"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell60"   runat="server">
                        <asp:TextBox ID="AgeMultPTD4txt" Text='<%#Eval("iAgeMultPTD4") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator41" runat="server" ControlToValidate="AgeMultPTD4txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow61"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell61"   runat="server">
                        <asp:TextBox ID="AgeMultPTD5txt" Text='<%#Eval("iAgeMultPTD5") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator42" runat="server" ControlToValidate="AgeMultPTD5txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow62"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell62"   runat="server">
                        <asp:TextBox ID="AgeMultPTD6txt" Text='<%#Eval("iAgeMultPTD6") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator43" runat="server" ControlToValidate="AgeMultPTD6txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow63"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell63"   runat="server">
                        <asp:TextBox ID="AgeMultPTD7txt" Text='<%#Eval("iAgeMultPTD7") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator44" runat="server" ControlToValidate="AgeMultPTD8txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow16"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell16"   runat="server">
                        <asp:TextBox ID="AgeMultPTD8txt" Text='<%#Eval("iAgeMultPTD8") %>' runat="server" ></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator45" runat="server" ControlToValidate="AgeMultPTD8txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator> 
                    </asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow ID="TableRow17"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell17"   runat="server">                                                 
                        <asp:DropDownList ID="GLAhasCOCcheckdrop" SelectedValue='<%# Eval("iGLAhasCOC").ToString()=="True" || Eval("iGLAhasCOC")=="1"?"true":"false" %>' runat="server">
                            <asp:ListItem Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                        </asp:DropDownList>

                    </asp:TableCell>
                </asp:TableRow>

                  <asp:TableRow ID="TableRow19"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell19"   runat="server">
                     
                          <asp:DropDownList ID="GLAgicdrop"  SelectedValue='<%# Eval("iGLAgic").ToString()=="True" || Eval("iGLAgic")=="1"?"true":"false" %>' runat="server">
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>


                


                  <asp:TableRow ID="TableRow65"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell65"   runat="server">                        
                       <asp:DropDownList ID="GLAhasTIBdrop"  SelectedValue='<%# Eval("iGLAhasTIB").ToString()=="True" || Eval("iGLAhasTIB")=="1"?"true":"false" %>' runat="server">
                              <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                         
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow66"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell66"   runat="server">                                                  
                         <asp:DropDownList ID="HasTaxReplCoverdrop"  SelectedValue='<%# Eval("iHasTaxReplCover").ToString()=="True" || Eval("iGLAhasTIB")=="1"?"true":"false" %>' runat="server">
                             <asp:ListItem  Value="false">No</asp:ListItem>
                              <asp:ListItem  Value="true">Yes</asp:ListItem>
                          
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow67"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell67"   runat="server">
                          
                         <asp:DropDownList ID="GLAhasConverOptiondrop"  SelectedValue='<%# Eval("iGLAhasConverOption").ToString()=="True"  || Eval("iGLAhasConverOption").ToString()=="1"?"true":"false" %>'  runat="server">
                             <asp:ListItem  Value="false">No</asp:ListItem>
                             <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>                      
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow68"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell68"   runat="server">                        										                        
                         <asp:DropDownList ID="GLAisFlexCoverdrop"  SelectedValue='<%# Eval("iGLAhasFlexCover").ToString()=="True" || Eval("iGLAhasFlexCover").ToString()=="1" ?"true":"false" %>' runat="server">
                            <asp:ListItem  Value="false">No</asp:ListItem>
                              <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>  
                       
                    </asp:TableCell>
                </asp:TableRow>
                  
                
                <asp:TableRow ID="TableRow64"  style="height:50px;" runat="server">
                    <asp:TableCell ID="TableCell64"  runat="server">
                       
                        <asp:TextBox ID="glacorecovermulttxt" Text='<%#Eval("iGLAcoreCoverMult").ToString()!=string.Empty?Eval("iGLAcoreCoverMult"):"0" %>' runat="server"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator46" runat="server" ControlToValidate="glacorecovermulttxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow71"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell71"  runat="server">
                       
                           <asp:DropDownList ID="HasUEPdrop"  SelectedValue='<%# Eval("iHasUEP").ToString()=="True"?"true":"false" %>' runat="server">
                           <asp:ListItem  Value="false">No</asp:ListItem>
                                <asp:ListItem  Value="true">Yes</asp:ListItem>
                            
                        </asp:DropDownList>  
                    </asp:TableCell>
                </asp:TableRow>
                 <%--SelectedItem='<%# DataBinder.Eval(Container.DataItem,"iAccBenType") %>'--%>
                
                  <%-- Life insurence Section end --%>
                  <%-- Lump Sum disability PTD Start --%>
                
                  <asp:TableRow ID="TableRow69"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell69"  runat="server">
                     
                    </asp:TableCell>
                </asp:TableRow>                
                  <asp:TableRow ID="TableRow70"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell70"  runat="server">
                      <asp:DropDownList ID="HasPTDdropdown"  SelectedValue='<%# Eval("iHasPTD").ToString()=="True"?"true":"false" %>'  runat="server">
                           <asp:ListItem  Value="false">No</asp:ListItem>
                           <asp:ListItem  Value="true">Yes</asp:ListItem>
                            
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow> 
                  <asp:TableRow ID="TableRow78"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell78"  runat="server">
                      <asp:DropDownList ID="PTDpatterndrop"     runat="server">
                           
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow72"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell72"  runat="server">
                 
                        <asp:TextBox ID="PTDmultipletxt" Text='<%#Eval("iPTDmultiple").ToString()!=string.Empty ?Eval("iPTDmultiple"):"0" %>'  runat="server"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator47" runat="server" ControlToValidate="PTDmultipletxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow73"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell73"  runat="server">
                   
                        <asp:TextBox ID="PTDflatCoverAmttxt" Text='<%#Eval("iPTDflatCoverAmt").ToString()!=string.Empty ?Eval("iPTDflatCoverAmt"):"0" %>'  runat="server"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator48" runat="server" ControlToValidate="PTDflatCoverAmttxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>                 
                  <asp:TableRow ID="TableRow76"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell76"  runat="server">
                    <asp:DropDownList ID="PTDhasConverOptiondrop" SelectedValue='<%# Eval("iPTDhasConverOption").ToString()=="True"?"true":"false" %>'  runat="server">
                           <asp:ListItem  Value="false">No</asp:ListItem>
                         <asp:ListItem  Value="true">Yes</asp:ListItem>
                            
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                  <%--Lump Sum disability PTD end --%>
                  <%--  accidental death Start --%>
                

                 <asp:TableRow ID="TableRow83"   style="height:50px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell83"   runat="server">
                    
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow80"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell80"   runat="server">
                       <asp:DropDownList ID="hasaccbendrop" SelectedValue='<%# Eval("iHasAccBen").ToString()=="True"?"true":"false" %>'  runat="server">
                              <asp:ListItem  Value="false">No</asp:ListItem>
                           <asp:ListItem  Value="true">Yes</asp:ListItem>
                          
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow81"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell81"   runat="server">
                      <asp:TextBox ID="AccBenMultipletext" Text='<%#Eval("iAccBenMultiple").ToString()!=string.Empty ?Eval("iAccBenMultiple"):"0" %>'  runat="server"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator49" runat="server" ControlToValidate="AccBenMultipletext" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow74"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell74" runat="server">
                         <asp:DropDownList ID="AccidentbentypeDrop"   runat="server">
                            
                         </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <%--accidental death end --%>
                  <%--   Critical Illness Start --%>


                 <asp:TableRow ID="TableRow84"   style="height:50px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell84"   runat="server">
                    
                    </asp:TableCell>
                </asp:TableRow>

                 <asp:TableRow ID="TableRow85"   style="height:50px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell85"   runat="server">
                    <asp:DropDownList ID="iHasCIIdrop" SelectedValue='<%# Eval("iHasCII").ToString()=="True"?"true":"false" %>'  runat="server">
                            <asp:ListItem  Value="false">No</asp:ListItem>
                         <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <%--<asp:TableRow ID="TableRow86"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell86"   runat="server">
                    <%-- - SelectedValue='<%# Eval("iHasCII")=="True"?"true":"false" %>'
                       <asp:DropDownList ID="CIIpatterntxtdrop"      runat="server">
                         
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>  --%>           
                 <asp:TableRow ID="TableRow87"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell87"   runat="server">
                       
                          
                        <asp:TextBox ID="CIImultipletxt" Text='<%#Eval("iCIImultiple").ToString()!=string.Empty ?Eval("iCIImultiple"):"0" %>' runat="server"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator50" runat="server" ControlToValidate="CIImultipletxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow88"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell88"   runat="server">
                       
                        <asp:TextBox ID="CIIflatCoverAmttxt" Text='<%#Eval("iCIIflatCoverAmt").ToString()!=string.Empty ?Eval("iCIIflatCoverAmt"):"0" %>' runat="server"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator51" runat="server" ControlToValidate="CIIflatCoverAmttxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow89"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell89"   runat="server">
                       <asp:DropDownList ID="iCIItypedrop"    runat="server">
                          
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow90"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell90"   runat="server">
                       <asp:DropDownList ID="CIIhasCOCdrop" SelectedValue='<%# Eval("iCIIhasCOC").ToString()=="True"?"true":"false" %>'  runat="server">
                             <asp:ListItem  Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow91"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell91"   runat="server">
                       <asp:DropDownList ID="iCIIgicdrop" SelectedValue='<%# Eval("iCIIgic").ToString()=="True"?"true":"false" %>'  runat="server">
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow92"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell   ID="TableCell17899"  runat="server">
                       <asp:DropDownList ID="iCIIhasConverOptiondrop" SelectedValue='<%# Eval("iCIIhasConverOption").ToString()=="True"?"true":"false" %>'  runat="server">
                              <asp:ListItem  Value="false">No</asp:ListItem>
                           <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                 <%--Critical Illness end --%>
                  <%-- Disability Income  Start --%>
                <asp:TableRow ID="TableRow179"   style="height:50px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell178"   runat="server">
                      
                    </asp:TableCell>
                </asp:TableRow>
                
                 <asp:TableRow ID="TableRow933"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell93"   runat="server">
                       <asp:DropDownList ID="hasphidrop"  SelectedValue='<%# Eval("iHasPHI").ToString()=="True"?"true":"false" %>' runat="server">
                            <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>


                <asp:TableRow ID="TableRow160"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell160"   runat="server">
                       <asp:DropDownList ID="iPHIwaiverPatterndrop"  runat="server">
                                                 
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>


                <asp:TableRow ID="TableRow94"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell94"   runat="server">
                       <asp:DropDownList ID="PHIscaleTypedrop"  runat="server">
                                                 
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow95"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell95"   runat="server">
                     
                        <asp:TextBox ID="PHIbenPercTier1txt" Text='<%#Eval("iPHIbenPercTier1") %>'  runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator54" runat="server" ControlToValidate="PHIbenPercTier1txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow96"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell96"   runat="server">
                     
                        <asp:TextBox ID="PHIsalLimitTier1txt11" Text='<%#Eval("iPHIsalLimitTier1") %>' runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator52" runat="server" ControlToValidate="PHIsalLimitTier1txt11" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow97"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell97"   runat="server">
                      
                        <asp:TextBox ID="PHIbenPercTier2txt" Text='<%#Eval("iPHIbenPercTier2") %>' runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator55" runat="server" ControlToValidate="PHIbenPercTier2txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow98"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell98"   runat="server">
                      
                        <asp:TextBox ID="PHIsalLimitTier2txt11" Text='<%#Eval("iPHIsalLimitTier2") %>' runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator53" runat="server" ControlToValidate="PHIsalLimitTier2txt11" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow99"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell99"   runat="server">
                    
                        <asp:TextBox ID="PHIbenPercTier3txt" Text='<%#Eval("iPHIbenPercTier3") %>' runat="server"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator56" runat="server" ControlToValidate="PHIbenPercTier3txt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow100"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell100"   runat="server">
                        
                      

              <asp:DropDownList ID="PHIwaitingPerioddrop"    runat="server">

                         
                           
                        </asp:DropDownList>


                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow101"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell101"   runat="server">
                    
                        <asp:TextBox ID="PHIwaiverPerctxt1" Text='<%#Eval("iPHIwaiverPerc").ToString()!=string.Empty?Eval("iPHIwaiverPerc"):"0" %>' runat="server"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator57" runat="server" ControlToValidate="PHIwaiverPerctxt1" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow102"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell102"   runat="server">
                     
                        <asp:TextBox ID="PHIescPerctxt11" Text='<%#Eval("iPHIescPerc").ToString()!=string.Empty?Eval("iPHIescPerc"):"0" %>' runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator58" runat="server" ControlToValidate="PHIescPerctxt11" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow103"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell103"   runat="server">
                       <asp:DropDownList ID="iPHIhasConverOptiondrop"  SelectedValue='<%# Eval("iPHIhasConverOption").ToString()=="True"?"true":"false" %>'  runat="server">
                             <asp:ListItem  Value="false">No</asp:ListItem>
                           <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow104"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell104"   runat="server">
                       <asp:DropDownList ID="iPHIhasTopUpdrop" SelectedValue='<%# Eval("iHasTopUp").ToString()=="True"?"true":"false" %>'   runat="server">
                            <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow105"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell105"   runat="server">
                       <asp:DropDownList ID="iHasMAPWdrop" SelectedValue='<%# Eval("iHasMAPW").ToString()== "True" ?"true":"false" %>'   runat="server">
                              <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                         
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow106"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell106"   runat="server">
                     
                        <asp:TextBox ID="MAPWPmtTermtxt" Text='<%#Eval("iMAPWPmtTerm").ToString()!=string.Empty?Eval("iMAPWPmtTerm"):"12" %>'  runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator59" runat="server" ControlToValidate="MAPWPmtTermtxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow107"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell107"   runat="server">
                       <asp:DropDownList ID="iHasSalaryRefunddrop"  SelectedValue='<%# Eval("iHasSalaryRefund").ToString()=="True"?"true":"false" %>'  runat="server">
                           <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow108"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell108"   runat="server">                       
                       
                         <asp:DropDownList ID="SRmultipledrop"    runat="server">
                            
                              </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                  
                  <asp:TableRow ID="TableRow198"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell197"   runat="server">
                      Temporary Income Disability                 
                    </asp:TableCell>
                </asp:TableRow>

                  <asp:TableRow ID="TableRow184"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell183"   runat="server">
                       <asp:DropDownList ID="iHasTTDdrop"   SelectedValue='<%# Eval("iHasTTD").ToString()=="True"?"true":"false" %>' runat="server">
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>




              


             
                <asp:TableRow ID="TableRow185"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell184"   runat="server">
                       <asp:DropDownList ID="DropDownList4"   SelectedValue='<%# Eval("iTTDscaleType").ToString()=="True"?"true":"false" %>' runat="server">
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                

                 <asp:TableRow ID="TableRow186"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell185"   runat="server">
                        <asp:TextBox ID="TextBox3" Text='<%# Eval("iTTDbenPercTier1").ToString() %>' runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                 <asp:TableRow ID="TableRow187"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell186"   runat="server">
                        <asp:TextBox ID="TextBox4" Text='<%# Eval("iTTDsalLimitTier1").ToString() %>' runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow188"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell187"   runat="server">
                        <asp:TextBox ID="TextBox5" Text='<%# Eval("iTTDbenPercTier2").ToString() %>' runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
               

                  <asp:TableRow ID="TableRow190"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell189"   runat="server">
                        <asp:TextBox ID="TextBox7" Text='<%# Eval("iTTDsalLimitTier2").ToString() %>' runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow191"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell190"   runat="server">
                        <asp:TextBox ID="TextBox8" Text='<%# Eval("iTTDbenPercTier3").ToString() %>' runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                
                 <asp:TableRow ID="TableRow143"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell142"   runat="server">                                              
                         <asp:DropDownList ID="iTTDwpPPdrop"  AppendDataBoundItems="true"  runat="server">
                            <asp:ListItem >Select..</asp:ListItem>
                              </asp:DropDownList>
                    </asp:TableCell>
                      </asp:TableRow>


                 <asp:TableRow ID="TableRow192"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell191"   runat="server">                                              
                         <asp:DropDownList ID="iTTDwaiverPatterndrop"  AppendDataBoundItems="true"  runat="server">
                            <asp:ListItem >Select..</asp:ListItem>
                              </asp:DropDownList>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow ID="TableRow193"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell192"   runat="server">                                              
                       
                             <asp:TextBox  id="iTTDwaivertext" runat="server"></asp:TextBox>
                         
                    </asp:TableCell>
                </asp:TableRow>

                 <asp:TableRow ID="TableRow189"   style="height:50px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell188"   runat="server">
                      
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow109"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell109"   runat="server">
                       <asp:DropDownList ID="ihasfundrop"   SelectedValue='<%# Eval("iHasFun").ToString()=="True"?"true":"false" %>' runat="server">
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            <asp:ListItem  Value="false">No</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

               
                  
                  

              <%--  value='<%#Eval("iFUNcoverAmt") %>'--%>
                <asp:TableRow ID="TableRow110"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell110"   runat="server">
                      
                        <asp:TextBox ID="FUNcoverAmttxt" Text='<%#Eval("iFUNcoverAmt").ToString()!=string.Empty?Eval("iFUNcoverAmt"):"0" %>'   runat="server"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator60" runat="server" ControlToValidate="FUNcoverAmttxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow111"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell111"   runat="server">
                       <asp:DropDownList ID="iHasFUNtransportBendrop"  SelectedValue='<%# Eval("iHasFUNtransportBen").ToString()=="True"?"true":"false" %>'  runat="server">
                            <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                  <%-- Disability Income end --%>
                  <%-- Spouse Insurence Start --%>
                <asp:TableRow ID="TableRow112"   style="height:50px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell112"   runat="server">
                      
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow113"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell113"   runat="server">
                       <asp:DropDownList ID="HasSGLAdrop" SelectedValue='<%# Eval("iHasSGLA").ToString()=="True"?"true":"false" %>'  runat="server">
                            
                            <asp:ListItem  Value="false">No</asp:ListItem>
                           <asp:ListItem  Value="true">Yes</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow114"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell114"   runat="server">
                       <asp:DropDownList ID="iSGLApatterndrop"     runat="server">
                            
                            
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow115"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell115"   runat="server">
                       
                        <asp:TextBox ID="iSGLAmultipletxt" Text='<%#Eval("iSGLAmultiple").ToString()!=string.Empty ?Eval("iSGLAmultiple"):"1" %>' runat="server"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator61" runat="server" ControlToValidate="iSGLAmultipletxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow116"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell159"   runat="server">
                       
                        <asp:TextBox ID="iSGLAflatCoverAmttxt" Text='<%#Eval("iSGLAflatCoverAmt").ToString()!=string.Empty ?Eval("iSGLAflatCoverAmt"):"0" %>' runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                  
                  <asp:TableRow ID="TableRow161"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell161"   runat="server">
                       <asp:DropDownList ID="iSGLAhasConverOptiondrop" SelectedValue='<%# Eval("iSGLAhasConverOption").ToString()=="True"?"true":"false" %>'  runat="server">
                             <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                          
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow162"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell162"   runat="server">
                       <asp:DropDownList ID="iHasSPTDdrop" SelectedValue='<%# Eval("iHasSPTD").ToString()=="True"?"true":"false" %>'  runat="server">
                           <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                            
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <%--  <asp:TableRow ID="TableRow163"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell163"   runat="server">
                       <asp:DropDownList ID="iSPTDpatterndrop"  AppendDataBoundItems="true"  runat="server">
                            <asp:ListItem>Select..</asp:ListItem>                           
                        </asp:DropDownList>
                    </asp:TableCell>
                    </asp:TableRow>--%>
                   
               
                  <asp:TableRow ID="TableRow164"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell164"   runat="server">                     
                        <asp:TextBox ID="SPTDmultipletxt" Text='<%#Eval("iSPTDmultiple").ToString()!=string.Empty ?Eval("iSPTDflatCoverAmt"):"0" %>' runat="server"></asp:TextBox>


                         <asp:CompareValidator ID="CompareValidator62" runat="server" ControlToValidate="SPTDmultipletxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                  <asp:TableRow ID="TableRow165"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell165"   runat="server">
                       
                        <asp:TextBox ID="SPTDflatCoverAmttxt" Text='<%#Eval("iSPTDflatCoverAmt").ToString()!=string.Empty ?Eval("iSPTDflatCoverAmt"):"0" %>' runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator63" runat="server" ControlToValidate="SPTDflatCoverAmttxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow77"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell77"   runat="server">
                       <asp:DropDownList ID="iSPTDhasConverOptiondrop"  SelectedValue='<%# Eval("iSPTDhasConverOption").ToString()=="True"?"true":"false" %>' runat="server">
                             <asp:ListItem  Value="false">No</asp:ListItem>
                           <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow166"   style="height:50px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell166"   runat="server">
                    
                    </asp:TableCell>
                </asp:TableRow>
                   <%-- Spouse Insurence end --%>
                  <%--  Advanced Features Start --%>
                <asp:TableRow ID="TableRow167"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell92"   runat="server">
                      
                        <asp:TextBox ID="iPTDwptxt" Text='<%#Eval("iPTDwp").ToString()!=string.Empty ?Eval("iPTDwp"):"6" %>' runat="server"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator64" runat="server" ControlToValidate="iPTDwptxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow ID="TableRow168"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell167"   runat="server">
                       <asp:DropDownList ID="iHasPTDinstalmentsdrop" SelectedValue='<%# Eval("iHasPTDinstalments").ToString()=="True"?"true":"false" %>'  runat="server">
                            <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow169"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell168"   runat="server">
                      
                        <asp:TextBox ID="iPTDnoInstalmentstxt" Text='<%#Eval("iPTDnoInstalments") %>' runat="server"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator65" runat="server" ControlToValidate="iPTDwptxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="*">  
                </asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow170"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell169"   runat="server">
                       <asp:DropDownList ID="iHasPTDaltPreExdrop"  SelectedValue='<%# Eval("iHasPTDaltPreEx").ToString()=="True"?"true":"false" %>'  runat="server">
                            <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow171"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell170"   runat="server">
                      
                        <asp:TextBox ID="iPTDpreExtxt" Text='<%#Eval("iPTDpreEx") %>' runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow172"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell171"   runat="server">
                       <asp:DropDownList ID="iHasPTDaltOccDefndrop" SelectedValue='<%# Eval("iHasPTDaltOccDefn").ToString()=="True"?"true":"false" %>'   runat="server">
                            <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow173"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell172"   runat="server">
                       
                        <asp:TextBox ID="iPTDoccDefntxt" Text='<%#Eval("iPTDoccDefn") %>' runat="server"></asp:TextBox>
                        
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow174"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell173"   runat="server">
                       <asp:DropDownList ID="iHasPHIaltOccDefndrop"  SelectedValue='<%# Eval("iHasPHIaltOccDefn").ToString()=="True"?"true":"false" %>' runat="server">
                              <asp:ListItem  Value="false">No</asp:ListItem>
                            <asp:ListItem  Value="true">Yes</asp:ListItem>
                         
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow175"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell174"   runat="server">
                        
                        <asp:TextBox ID="iPHIoccDefntxt"  Text='<%#Eval("iPHIoccDefn") %>' runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow176"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell175"   runat="server">
                       <asp:DropDownList ID="iHasPHIaltEscdrop"  SelectedValue='<%# Eval("iHasPHIaltEsc").ToString()=="True"?"true":"false" %>'  runat="server">
                             <asp:ListItem  Value="false">No</asp:ListItem>
                           <asp:ListItem  Value="true">Yes</asp:ListItem>
                           
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow177"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell176"   runat="server">
                      
                        <asp:TextBox ID="iPHIaltEsctxt"  Text='<%#Eval("iPHIaltEsc") %>' runat="server"></asp:TextBox>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow28"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell28"   runat="server">
                      
                        <asp:TextBox ID="iBenefitScalingFactext"  Text='<%#Eval("iBenefitScalingFac").ToString()!=string.Empty?Eval("iBenefitScalingFac"):"1" %>' runat="server"></asp:TextBox>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow141"   style="height:70px;border-color:black;" runat="server" >
                    <asp:TableCell ID="TableCell140"   runat="server">
                      
                        <asp:TextBox ID="iSalaryScalingFacbox"  Text='<%#Eval("iSalaryScalingFac").ToString()!=string.Empty?Eval("iSalaryScalingFac"):"1" %>' runat="server"></asp:TextBox>

                    </asp:TableCell>
                </asp:TableRow>

                <%--<asp:TableRow ID="TableRow73"  style="height:50px;border-color:black;" runat="server">
                    <asp:TableCell ID="TableCell73"  runat="server">
                         <asp:DropDownList ID="iGLAhasGOBdrop"  AppendDataBoundItems="true" runat="server">
                              <asp:ListItem>Select..</asp:ListItem>
                         </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>--%>
                
            </asp:Table>
             </div>
                    </ItemTemplate>
            </asp:Repeater>
               </div>
        </div>
                                    <div style="margin-top:10px;" >
						            <div class="span4 puhs5 marB30">
				                            <div class="saveCatBtn">				                                   
                                               
                                                <asp:Button CausesValidation="false" ID="savecategorybtn" class="btn" runat="server" text="Save Category" OnClick="savecategorybtn_Click" />
                                                <asp:Button CausesValidation="false" ID="addctgrybtn" runat="server" class="btn" Text="Add Category" OnClick="addctgrybtn_Click" />
				                            </div>
				                    </div>
				                
		                </div>
       
              </div>
                            
			                    <!--  ACCORDIAN ONE END -->
			                   

					        	
                             
                               
                     	</div>
                            </div>
				 		<!-- TAB 3 STARTS -->
				        <div id="tab3" class="tab">
				            <div class="quoteContainer clearfix grayCell">
				            	<div class="span4 puhs5">
		                        	<h3 class="marB10">Member Details</h3>
		                        </div>
		                    </div>               
                            <asp:HiddenField ID="hidquoteNo" runat="server" />
		                        <div class="quoteContainer clearfix grayCell">
			                        <!-- MEMBER FILE UPLOAD -->
			                                                                <div class="fileUpload btn btn-primary">
                                            
                                            <asp:FileUpload ID="uploadFile" runat="server" Enabled="true" on />
                                                                                          
                                        </div>

                                        <div class="uploadBtn">

                                            <asp:Button ID="btnUpload" CausesValidation="false"  OnClick="btnUpload_Click" CssClass="btn" runat="server" Text="Upload" />

                                            <%--  <asp:Button type="submit" runat="server" Text="Upload" CausesValidation="false" CssClass="btn" id="uploadDetails1" OnClick="uploadDetails_Click" ></asp:Button>--%>

                                            <asp:LinkButton ID="LinkButton1" runat="server" class="smallLink downloadLink" href="#" target="_blank">Download member template</asp:LinkButton>
                                            
                                        </div>
                                                                
                            <div style="overflow-x:scroll;width:100%;" runat="server" id="divMemberList" visible="false" >
                                <div>
                                                <asp:RadioButtonList ID="rbtnSelectExistingMembers" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">Replace Existing Members</asp:ListItem>
                                        <asp:ListItem Value="1">Add To Existing Members</asp:ListItem>
                                    </asp:RadioButtonList></div>
                            
                                    <asp:GridView ID="gvmemberList" runat="server"                                                                      
                                        AutoGenerateDeleteButton="false" AutoGenerateColumns="True"
                                        AllowPaging="true" PageSize="5"
                                        OnPageIndexChanging="gvmemberList_PageIndexChanging" OnRowDeleting="gvmemberList_RowDeleting"
                                        OnRowEditing="gvmemberList_RowEditing" PagerSettings-Mode="NumericFirstLast">
                                      
                                            
                                       <%--    <Columns>   <asp:TemplateField HeaderText="Full Name">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliFullName" Text='<%# Eval("iFullName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iDOB">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliDOB" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iGender">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliGender" Text='<%# Eval("iGender") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iRiskClass">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliRiskClass" Text='<%# Eval("iRiskClass") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iAnnualSalary">
                                                <ItemTemplate>
                                                <asp:Label runat="server" ID="lbliAnnualSalary" Text='<%#@Eval("iAnnualSalary") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iCategory">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliCategory" Text='<%#@Eval("iCategory") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iImportedValue">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliImportedValue" Text='<%#Eval("iImportedValue") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iSpouseName">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliSpouseName" Text='<%#Eval("iSpouseName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iGenderSpouse">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliGenderSpouse" Text='<%#Eval("iGenderSpouse") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iDOBspouse">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliDOBspouse" Text='<%#Eval("iDOBspouse") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iLoadingGLA">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliLoadingGLA" Text='<%#Eval("iLoadingGLA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iLoadingCII">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliLoadingCII" Text='<%#Eval("iLoadingCII") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iLoadingPHI">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliLoadingPHI" Text='<%#Eval("iLoadingPHI") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="iLoadingPTD">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbliLoadingPTD" Text='<%#Eval("iLoadingPTD") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>  --%>


                                           
                                       
                                    </asp:GridView>
                                <div id="cancelAccept" style="float:right;">
                                                <%--<div class="submitBtn">--%>
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btn" Text="Cancel"  OnClick="btnCancel_Click" />
                                                <asp:Button ID="btnAccept" runat="server" CausesValidation="false" CssClass="btn" Text="Accept" OnClick="btnAccept_Click" />
                                                <%--</div>--%>
                                            </div>
                                </div>
                                    
			                    </div>

			                    <!-- ADD MEMBER MANUALLY FORM ENDS -->
		                        <div id="memberDetailTable" class="grayCell">


		                        	<div class="viewQuoteContainer">
		                        		<a href="#" class="btn" id="viewMoreQuotes">View more quotes</a>
		                        	</div>
		                        </div>   
	                         <div class="quoteContainer clearfix grayCell">
                                    <div style="overflow-x:scroll; width:100%">
                                        <asp:GridView ID="gvmemberEdit"
                                            DataKeyNames="iQuoteNumber , iCategory , iFullName, Member_ID"
                                            AutoGenerateDeleteButton="false" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="5"
                                            OnPageIndexChanging="gvmemberEdit_PageIndexChanging" OnRowDeleting="gvmemberEdit_RowDeleting"
                                            OnRowEditing="gvmemberEdit_RowEditing"
                                            runat="server">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Quote Number">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliQuoteNumber" Text='<%#@Eval("iQuoteNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Full Name">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliFullName" Text='<%#@Eval("iFullName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Member ID">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="iMemberlabel" Text='<%#@Eval("iMemberNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date Of Birth">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliDOB" Text='<%#@Eval("iDOB") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Gender">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliGender" Text='<%#@Eval("iGender") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Risk Class">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliRiskClass" Text='<%#@Eval("iRiskClass") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Annual Salary">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliAnnualSalary" Text='<%#@Eval("iAnnualSalary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliCategory" Text='<%#@Eval("iCategory") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Imported Value">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliImportedValue" ></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Spouses Name">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliSpouseName" Text='<%#@Eval("iSpouseName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Spouses Gender">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliGenderSpouse" Text='<%#@Eval("iGenderSpouse") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Spouses DOB">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliDOBspouse" Text='<%#@Eval("iDOBspouse") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="GLA Loading">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliLoadingGLA" Text='<%#@Eval("iLoadingGLA") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CII Loading">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliLoadingCII" Text='<%#@Eval("iLoadingCII") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PHI Loading">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliLoadingPHI" Text='<%#@Eval("iLoadingPHI") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PTD Loading">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbliLoadingPTD" Text='<%#@Eval("iLoadingPTD") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <%--                                                    <asp:Button ID="btnEdit" Text="" CommandName="Edit" runat="server" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CssClass="editMemberArrow" CausesValidation="false" />--%>


                                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" runat="server" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CausesValidation="false" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                  
			                        <div class="clearfix marB30">
				                        <div class="span4 marT15">
											<!-- <a href="#" class="btn" id="viewMoreQuotes">View more quotes</a> -->
<%--											<a href="#" class="btn gray" id="addMemberBtn">Add Member Manually</a>--%>
                                             <asp:Button runat="server"  CausesValidation="false" CssClass="btn gray" Text="Add Member Manually" ID="addMemberBtn"></asp:Button>
										</div>
			                        </div>
			                        <!-- MEMBER FILE UPLOAD ENDS -->
			                        <!-- ADD MEMBER MANUALLY FORM -->

			                         <div id="addMember">
                                            <div class="span5 puhs5">
                                                <div class="col1">
                                                    <h3 class="marB20">Member Data</h3>
                                                    <div id="Div4">
                                                        <label>Member Name</label>
                                                        <asp:TextBox ID="txtMemberName" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqMemberName" ControlToValidate="txtMemberName" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>Date of Birth</label>
                                                        <asp:TextBox ID="txtDOB" runat="server" CssClass="datepicker dob" />
                                                        <asp:RequiredFieldValidator ID="rqDOB" ControlToValidate="txtDOB" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>Gender</label>
                                                        <asp:DropDownList ID="gender" runat="server">                                                           
                                                            <asp:ListItem>male</asp:ListItem>
                                                            <asp:ListItem>female</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rqgender" ControlToValidate="gender" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>Annual Salary</label>
                                                        <asp:TextBox ID="txtAnnualSalary" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqAnnualSalary" ControlToValidate="txtAnnualSalary" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col1">
                                                    <h3 class="marB20">&nbsp;</h3>
                                                    <div>
                                                        <label>Category Number</label>
                                                        <asp:TextBox ID="txtCategoryNumber" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqCategoryNumber" ControlToValidate="txtCategoryNumber" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>Risk Class</label>
                                                        <%--                                                        <asp:DropDownList ID="riskClass" runat="server" AppendDataBoundItems="True">
                                                            <asp:ListItem>Please Select</asp:ListItem>
                                                        </asp:DropDownList>--%>
                                                        <asp:TextBox ID="riskClass" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqRiskClass" ControlToValidate="riskClass" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                  <%--  <div>
                                                        <label>Fixed Cover Amount</label>
                                                        <asp:TextBox ID="txtFixedCoverAmout" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqFixedCoverAmount" ControlToValidate="txtFixedCoverAmout" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>--%>
                                                    <div>
                                                        <label>Imported Value</label>
                                                        <asp:TextBox ID="txtiImportedValue" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqimportedValue" ControlToValidate="txtiImportedValue" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col1">
                                                    <h3 class="marB20">Spouse Details</h3>
                                                    <div>
                                                        <label>Spouse Name</label>
                                                        <asp:TextBox ID="txtSpouseName" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqSpouseName" ControlToValidate="txtSpouseName" runat="server">*</asp:RequiredFieldValidator>

                                                    </div>
                                                    <div>
                                                        <label>Spouse Date of Birth</label>
                                                        <asp:TextBox ID="txtSpouseDOB" CssClass="datepicker dob" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqSpouseDOB" ControlToValidate="txtSpouseDOB" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>Gender</label>
                                                        <asp:DropDownList ID="Select6" runat="server">
                                                            <asp:ListItem Selected="True">Please Select</asp:ListItem>
                                                            <asp:ListItem>male</asp:ListItem>
                                                            <asp:ListItem>female</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rqSouseGender" ControlToValidate="Select6" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col1">
                                                    <h3 class="marB20">Loading</h3>
                                                    <div>
                                                        <label>GLA Loading (E.G 50% Enter as 50)</label>
                                                        <asp:TextBox ID="txtGLALoading" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqGLALoading" ControlToValidate="txtGLALoading" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>Critical Illness Loading (E.G 50% Enter as 50)</label>
                                                        <asp:TextBox ID="txtCIILoading" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqCII" ControlToValidate="txtCIILoading" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>PHI Loading (E.G 50% Enter as 50)</label>
                                                        <asp:TextBox ID="txtPHILoading" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqPHI" ControlToValidate="txtPHILoading" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>GOA Loading (E.G 50% Enter as 50)</label>
                                                        <asp:TextBox ID="txtGOALoading" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rqGOA" ControlToValidate="txtGOALoading" runat="server">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                            </div>
                                            <!-- MEMBER SUBMIT DETAILS BUTTON  -->
                                            <div class="span5 puhs5 marR0">
                                                <div class="submitBtn">
                                                    <asp:Button ID="btnSubmitDetails" CausesValidation="false" runat="server" CssClass="btn" OnClick="btnSubmitDetails_Click" Text="Submit Details" />
                                                </div>
                                            </div>
                                            <!-- MEMBER SUBMIT DETAILS END -->
                                        </div>
                                 <asp:Button ID="viequotebtnn" Enabled="false" CausesValidation="false" OnClick="viequotebtnn_Click" runat="server" CssClass="btn" Text="View Quote" />
                                                
		        				</div>
	                    	</div>
				        <!-- TAB 3 ENDS -->
				 		<!-- TAB 4 STARTS -->
				        <div id="tab4" class="tab">
				           <div class="quoteContainer clearfix grayCell">
				            	<div class="span4 puhs5 marB30">
		                        	<h3 class="marB20">Rate Discounts</h3>
		                        </div>
		                        <div class="span5 puhs5 marB30">
		                        	<div id="rateDiscountTable">
		                        		<table id="rateDiscountTableData">
		                        			<tr>
		                        				<th>Benefit</th>
		                        				<th class="categoryColumn">Category</th>
		                        				<th>% Discount</th>
		                        				<th>Set For All Categories</th>
		                        				<th>Reason</th>
		                        			</tr>
		                        			<tr>
		                        				<td>Life Insurance</td>
		                        				<td class="categoryColumn"></td>
		                        				<td><input type="text" class="rateValue"></td>
		                        				<td><input type="checkbox" class="rateCheckBox"></td>
		                        				<td><input type="text" class="rateValueText">
		                        				</td>
		                        			</tr>
		                        			<tr>
												<td>&nbsp;</td>
												<td class="categoryColumn">Category: Management</td>
												<td><input type="text" class="rateValue"></td>
												<td>&nbsp;</td>
												<td><input type="text" class="rateValueText"></td>
											</tr>
		                        			<tr>
		                        				<td>Lump Sum Disability</td>
		                        				<td class="categoryColumn"></td>
		                        				<td><input type="text" class="rateValue"></td>
		                        				<td><input type="checkbox" class="rateCheckBox"></td>
		                        				<td><input type="text" class="rateValueText">
		                        				</td>
		                        			</tr>
		                        			<tr>
		                        				<td>Critical Illness</td>
		                        				<td class="categoryColumn"></td>
		                        				<td><input type="text" class="rateValue"></td>
		                        				<td><input type="checkbox" class="rateCheckBox"></td>
		                        				<td><input type="text" class="rateValueText">
		                        				</td>
		                        			</tr>
		                        			<tr>
		                        				<td>Family Cover</td>
		                        				<td class="categoryColumn"></td>
		                        				<td><input type="text" class="rateValue"></td>
		                        				<td><input type="checkbox" class="rateCheckBox"></td>
		                        				<td><input type="text" class="rateValueText">
		                        				</td>
		                        			</tr>
		                        		</table>
		                        	</div>
		                        </div>
		                    </div>
				        </div>
				        <!-- TAB 4 ENDS -->
                        <!-- TAB 5 BEGINS -->
                        <div id="tab5" class="tab">
	                    <div class="quoteHolder">
				            		
				                    <div class="span5 puhs5">
				                         <div class="col1">
				                        <!--     <h3 class="marB20">Qu</h3>-->
				                                <div id="Div5">
				                                    <label>deAgeFactors</label>
				                                    <input id="agefactorstxt" runat="server" type="text" class=""></input>
                                                     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="agefactorstxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>
				                                <div>
				                                    <label>deSpousesAgeFactors<abbr rel="tooltip" class="lableTip" title="Add quote number"> <img src="img/question-mark.png"></abbr></label>
				                                    <input id="spouseagetxt" runat="server" type="text" class=""></input>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="spouseagetxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
                                                    
				                                </div>
				                                <div>
				                                    <label>deIndustryFactors</label>
				                                    <input id="industryfactorstxt" runat="server" type="text" class=""></input>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="industryfactorstxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>
				                                <div>
				                                    <label>deGenderFactors</label>
				                                    <input id="genderfactxt" runat="server" type="text" class=""></input>
                                                     <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="genderfactxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>
				                                <div>
				                                    <label>deSpousesGenderFac</label>
				                                    <input id="spousegendertxt" runat="server" type="text" class=""></input>
                                                          <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="spousegendertxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>

				                        </div>
				                        <div class="col1">
				                         <!--    <h3 class="marB20">C</h3> -->
				                                <div>
				                                   <label>deFrontOfficeFactors</label>
				                                    <input id="frontofficefactxt" runat="server" type="text" class=""></input>
                                                      <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="frontofficefactxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>
				                                <div>
				                                    <label>deGLAsalIndGenFac</label>
				                                    <input id="glasalindtxt" runat="server" type="text" class=""></input>
                                                       <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="glasalindtxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>
				                                <div>
				                                    <label>deSalaryParms</label>
				                                    <input id="salaryparamstxt" runat="server" type="text" class=""></input>
                                                      <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="salaryparamstxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>
				                                <div>
				                                    <label>deSchemeParameters</label>
				                                    <input id="schemeparamtxt" runat="server" type="text" class=""></input>
                                                      <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="schemeparamtxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>
				                                <div>
				                                    <label>deRegionFactors</label>
				                                    <input id="regionfactxt" runat="server" type="text" class=""></input>
                                                  <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="regionfactxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                                </div>

				                        </div>
				                        <div class="col1">
				                         <!--    <h3 class="marB20">Commission and Fees</h3> -->
                                               <div>
				                                    <label>deConvertionRates</label>
				                                    <input id="convertionratestxt" runat="server" type="text" class=""></input>
                                                   <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="convertionratestxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
                                                 
				                               </div>
                                               <div>
				                                    <label>dePHIgenNRAescWP</label>
				                                    <input id="phigennra" runat="server" type="text" class=""></input>
                                                   <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="phigennra" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
                                                 
				                               </div>
				                               <div>
				                                    <label>dePHIsalFactors</label>
				                                    <input id="phisalfactxt" runat="server" type="text" class=""></input>
                                                   <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="phisalfactxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                               </div>

                                               <div>
				                                    <label>dePHIwpFactors</label>
				                                    <input id="phiwpfactxt" runat="server" type="text" class=""></input>
                                                  <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="phiwpfactxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                               </div>

                                               <div>
				                                    <label>deTopUpRates</label>
				                                    <input id="sratestxt" runat="server" type="text" class=""></input>
                                                   <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="sratestxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                               </div>

				                        </div>				                       
                                        <div class="col1">
				                        <!--     <h3 class="marB20">&nbsp;</h3> -->

				                               <div>
				                                    <label> deCommissionParms </label>
				                                    <input id="commisionparamstxt" runat="server" type="text" class=""></input>
                                                  <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToValidate="commisionparamstxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                               </div>
                                               <div>
				                                    <label> deExpenseParms </label>
				                                    <input id="expenseparamtxt" runat="server" type="text" class=""></input>
                                                    <asp:CompareValidator ID="CompareValidator17" runat="server" ControlToValidate="expenseparamtxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                               </div>
                                               <div>
				                                    <label> deRatingClassFac </label>
				                                    <input id="ratingclasstxt" runat="server" type="text" class=""></input>
                                                   <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToValidate="ratingclasstxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                               </div>
 				                               <div>
				                                    <label> deTTDrates </label>
				                                    <input id="ttdratestxt" runat="server" type="text" class=""></input>
                                                  <asp:CompareValidator ID="CompareValidator66" runat="server" ControlToValidate="ttdratestxt" Operator="DataTypeCheck" ForeColor="Red" Type="integer" ErrorMessage="Input an integer">  
                </asp:CompareValidator>
				                               </div>

                                             
				                        </div>
 

				                    </div>
			        		</div>
				        </div>
                    <!-- TAB 5 ENDS -->
                    <!-- TAB 6 BEGINS -->
                        <div id="tab6" class="tab">
	                        <div class="quoteHolder">
				            		
				                    <div class="span5 puhs5">
		                              <div class="col1">
				                            <h3 class="marB20">&nbsp;</h3>
				                             <div>
				                                    <label>oAccBenCorpExp</label>
				                                    <input id="oaccbencorpexptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oAccBenMemberFee</label>
				                                    <input id="oAccBenMemberFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oAccBenPolicyFee</label>
				                                    <input id="oaccbenpolicyfeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oCIIcorpExp</label>
				                                    <input id="ociicorpexptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oCIImemberFee</label>
				                                    <input id="ociimemberfeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oCIIpolicyFee</label>
				                                    <input id="ociipolicyFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oFUNcorpExp</label>
				                                    <input id="ofuncorpexptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oFUNmemberFee</label>
				                                    <input id="ofunmemberfeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oFUNpolicyFee</label>
				                                    <input id="ofunpolicyfeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oGLAcorpExp</label>
				                                    <input id="oglacorpexptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oGLAmemberFee</label>
				                                    <input id="oglamemberfeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oGLApolicyFee</label>
				                                    <input id="oglapolicyfeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMAPWcorpExp</label>
				                                    <input id="omapwcorpexptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMAPWmemberFee</label>
				                                    <input id="omapwmemberfeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMAPWpolicyFee</label>
				                                    <input id="omapwpolicyfeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxAgeCII</label>
				                                    <input id="omaxageciitxt" type="text" class=""></input>
				                             </div>



      			                        </div>

		                              <div class="col1">
				                            <h3 class="marB20">&nbsp;</h3>
				                             <div>
				                                    <label>oMaxAgeFUN</label>
				                                    <input id="omaxagefuntxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxAgeGLA</label>
				                                    <input id="oMaxAgeGLAtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxAgePHITTD</label>
				                                    <input id="oMaxAgePHITTDtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxAgePTD</label>
				                                    <input id="oMaxAgePTDtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxAgeSGLA</label>
				                                    <input id="oMaxAgeSGLAtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxAgeSPTD</label>
				                                    <input id="oMaxAgeSPTDtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverAccBen</label>
				                                    <input id="oMaxCoverAccBentxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverCII</label>
				                                    <input id="oMaxCoverCIItxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverFUN</label>
				                                    <input id="oMaxCoverFUNtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverGLA</label>
				                                    <input id="oMaxCoverGLAtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverPHI</label>
				                                    <input id="oMaxCoverPHItxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverPHI100</label>
				                                    <input id="oMaxCoverPHI100txt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverPHI100waiver</label>
				                                    <input id="oMaxCoverPHI100waivertxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverPHIwaiver</label>
				                                    <input id="oMaxCoverPHIwaivertxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverPTD</label>
				                                    <input id="oMaxCoverPTDtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMaxCoverSGLA</label>
				                                    <input id="oMaxCoverSGLAtxt" type="text" class=""></input>
				                             </div>



      			                        </div>

		                              <div class="col1">
				                            <h3 class="marB20">&nbsp;</h3>
				                             <div>
				                                    <label>oMaxCoverSPTD</label>
				                                    <input id="oMaxCoverSPTDtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMinCoverFUN</label>
				                                    <input id="oMinCoverFUNtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMPFLvalueCII</label>
				                                    <input id="oMPFLvalueCIItxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMPFLvalueGLA</label>
				                                    <input id="oMPFLvalueGLAtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMPFLvaluePHI</label>
				                                    <input id="oMPFLvaluePHItxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMPFLvalueSGLA</label>
				                                    <input id="oMPFLvalueSGLAtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oMPFLvalueTTD</label>
				                                    <input id="oMPFLvalueTTDtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oPHIcorpExp</label>
				                                    <input id="oPHIcorpExptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oPHImemberFee</label>
				                                    <input id="oPHImemberFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oPHIpolicyFee</label>
				                                    <input id="oPHIpolicyFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oProfitCII</label>
				                                    <input id="oProfitCIItxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oProfitFUN</label>
				                                    <input id="oProfitFUNtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oProfitGLA</label>
				                                    <input id="oProfitGLAtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oProfitPHI</label>
				                                    <input id="oProfitPHItxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oProfitPTD</label>
				                                    <input id="oProfitPTDtxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oPTDcorporateExp</label>
				                                    <input id="oPTDcorporateExptxt" type="text" class=""></input>
				                             </div>



      			                        </div>

		                              <div class="col1">
				                            <h3 class="marB20">&nbsp;</h3>
				                             <div>
				                                    <label>oPTDmemberFee</label>
				                                    <input id="oPTDmemberFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oPTDpolicyFee</label>
				                                    <input id="oPTDpolicyFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oSGLAcorpExp</label>
				                                    <input id="oSGLAcorpExptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oSGLAmemberFee</label>
				                                    <input id="oSGLAmemberFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oSGLApolicyFee</label>
				                                    <input id="oSGLApolicyFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oSPTDcorporateExp</label>
				                                    <input id="oSPTDcorporateExptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oSPTDmemberFee</label>
				                                    <input id="oSPTDmemberFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oSPTDpolicyFee</label>
				                                    <input id="oSPTDpolicyFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oSRcorpExp</label>
				                                    <input id="oSRcorpExptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oTopUpCorpExp</label>
				                                    <input id="oTopUpCorpExptxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oTopUpMemberFee</label>
				                                    <input id="oTopUpMemberFeetxt" type="text" class=""></input>
				                             </div>
				                             <div>
				                                    <label>oTopUpPolicyFee</label>
				                                    <input id="oTopUpPolicyFeetxt" type="text" class=""></input>
				                             </div>


      			                        </div>

                                        
                                  

				                    </div>
			        		</div>
				        </div>
                     <!-- TAB 6 ENDS -->   
				    </div> 
				</div>
			
			</div>
		
		<div class="row padT0" id="btnControls">
			<div class="container clearfix">
				<div class="btnContainer">
				<div class="span2">&nbsp;
						<a href="#" class="btn arrow gray" id="backBtn">Back<span></span></a>
					</div>
					<div class="span2">

                        <asp:Button ID="savequotebtn" CausesValidation="false" class="btn" runat="server" Text="Save Quote" OnClick="savequotebtn_Click" />
                       
                        <%--<a href="#" class="btn" id="A1">Save Quote</a>--%>


					</div>
						<div class="span1">
							<a href="#" class="btn arrow" id="nextBtn">Next<span></span></a>	
							<a href="#" class="btn arrow" id="submitQuoteBtn">Submit<span></span></a>	
						</div>
						
					</div>
			</div>
		</div>

		<div class="row padT0" id="loaderWrapper">
			<div class="container clearfix">
				<div class="loaderContainer">
					<img src="img/Soniq_Loading.gif" border="0" />
					<p>Your quote is under way.....please bear with us for a few seconds.</p>
					<!-- <a href="loggedin.html" class="loadText">Go to next screen</a> -->
				</div>
				
			</div>
		</div>
		<!-- QUOTE END -->
		<!-- DESKTOP FOOTER -->
		<div id="footerDesktop" class="row footerBg">
                        <footer class="container clearfix">
                            <div class="col1">
                                <a href="#" id="footer_Personal">
                                    <h2>About Quotes
                                    </h2>
                                </a>
                            </div>
                            <!--end .col1-->
                            <div class="col1">
                             <a href="#" id="footer_Business">
                                    <h2>FAQ
                                    </h2>
                                </a>
                            </div>
                            <!--end .col1-->
                            <div class="col1">
                                <a href="#" id="footer_About">
                                    <h2>Quotes Contact
                                    </h2>
                                </a>
                            </div>
                            <!--end .col1-->
                            <div class="colLast right">
                            	<h2>Connect</h2>
	                                <ul class="socialMedia">
	                                    <li><a href="https://www.youtube.com/sanlam" target="_blank" class="youtube"></a></li>
	                                    <li><a href="https://twitter.com/sanlam" target="_blank" class="twitter"></a></li>
	                                    <li><a href="http://www.facebook.com/sanlamgroup" target="_blank" class="facebook"></a></li>
	                                    <li><a href="http://www.linkedin.com/company/165844" target="_blank" class="linkedin"></a>
	                                    </li>
	                                </ul>
	                                <ul>     
	                                     <li>
                                        <a href="https://www.sanlam.com/legal/Pages/terms-of-use.aspx">Terms of Use
                                        </a>
                                    </li>
                                    <li>
                                        <a href="https://www.sanlam.com/legal/Pages/sanlams-privacy-policy.aspx">Privacy Policy
                                        </a>
                                    </li>
                                    <li>
                                        <a href="https://www.sanlam.com/legal/Pages/financial-advisory-and-intermediary-services-act.aspx">Financial Advisory and Intermediary Services Act (FAIS)
                                        </a>
                                    </li>

	                                </ul>
                            </div>
                            <!--end .colLast-->
                            <div class="colterms">
                            
                            <br />
                            <br />
                                <p>Copyright © 2016 All rights reserved.Sanlam Life Insurance Limited is a Licensed Financial Services Provider and a Registered Credit Provider
                                
                                
                                </p>
                            </div>
                        </footer>
                    </div>
		<!-- DESKTOP FOOTER END  -->
    <div id="footerDevice" class="row footerBg hidden">
	        <footer class="container clearfix">
	            <div class="span5">
	                <div class="data">
	                    <ul class="socialMedia">
	                        <li>
	                            <a href="https://www.youtube.com/sanlam" target="_blank" class="youtube">
	                            </a>
	                        </li>
	                        <li>
	                            <a href="https://twitter.com/sanlam" target="_blank" class="twitter">
	                            </a>
	                        </li>
	                    </ul>
	                    <img src="img/footerLogo.png" alt="Sanlam">
	                    <ul>
	                        <li class="first">
	                            <a href="https://www.sanlam.com/legal/Pages/terms-of-use.aspx">Terms and Conditions</a>
	                        </li>
	                        <li>
	                            <a href="https://www.sanlam.com/legal/Pages/sanlams-privacy-policy.aspx">Privacy Policy</a>
	                        </li>
	                        <li class="last">
	                            <a href="https://www.sanlam.com/legal/Pages/promotion-of-access-to-information-act.aspx">Accessibility Policy</a>
	                        </li>
	                    </ul>
	                    <p>© 2016 Sanlam. All rights reserved.</p>
                     </div>
	            </div>
	        </footer>
        </div>
    <!-- MOBILE FOOTER END  -->
    </div>
<!-- MAIN WRAPPER END -->
    </div>
<script src="js/scripts.js"></script>
<script type="text/javascript">
    var fgf=0;
    $(function () {
        $("#tabs").tabs({ 
            activate: function () {
                
                var selectedTab = $('#tabs').tabs('option','active');
                $("#<%= hidtab.ClientID %>").val(selectedTab);                     
                },
            active: '<%= hidtab.Value %>'    
          
        });
       
    });
  //  $(function  () {
    //    fgf= '<= hidtab.Value %>';
    //    if(fgf=0)
    //    {
    //        alert("0");
    //    }
    //    else if(fgf=1)
    //    {
    //        alert("1");
    //    }
    //else if(fgf=2)
    //{
    // alert("2");
    //}
    //else if(fgf=3)
    //{
    //     alert("3");
    //}
    //else if(fgf=4)
    //{
    //     alert("4");
    //}
    //});
    $(function () {

        var currentDate = new Date();
        var dateToday = new Date();
        var yrRange = dateToday.getFullYear() + ":" + (dateToday.getFullYear() - 101);
        var getCurrentYear = dateToday.getFullYear();
        var showPicker = false;

        $(".datepicker").datepicker({
            changeMonth: true,
            changeYear: true,
            showOn: "button",
            buttonImage: "img/Calender_icon.png",
            buttonImageOnly: true,
            dateFormat: "dd/mm/yy",
            yearRange: "1915:" + getCurrentYear,
        });

        $(".datepicker").on("mouseenter", function () {

            if (!showPicker) {
                showPicker = true;

                //Reverse the years
                var dropYear = $("select.ui-datepicker-year");

                dropYear.find('option').each(function () {
                    dropYear.prepend(this);
                });

            }

        });

        $("#datepickerField").on("click", function () {
            $('.datepicker').datepicker('show');
        });
    });

</script>
        
    </form>
</body>
</html>
