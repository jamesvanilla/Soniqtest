<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewQuote.aspx.cs" Inherits="ViewQuote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8">
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
    <script type="text/javascript">
        function Showdiv(id) {
            document.getElementById('divLifeInsuranceandLumpSumDisability').style.display = 'none';
            document.getElementById(id).style.display = 'block';
        }
    </script>
    <style type="text/css">
        .grids td {
  width : 50%;
   
        }
        .grids1 td {
            width: 20%;
        }
        .grids2 td {
            width: 50%;
        }
          .grids3 td {
            width: 30%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <!-- MAIN WRAPPER -->
<div id="page" class="soniq" style="margin: auto; float: none;">
<div id="overlay"></div>
	<!-- Sanlam COM - Desktop nav -->
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
						<a class="parentLink" href="#">Contact</a>
					</li>
				</ul>
				<ul id="accountLinks">
					<li id="account">
						<a href="#" target="_blank">
							<span>Tony is logged in</span>
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
												<a href="#" >Logout</a>
											</h2>
											<h2>
												<a href="#" >Profile</a>
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
                <div class="modal-wrap" id="userRecordModal">
                    <div class="modal-container modal-s-ready modal-inline-holder">
                        <div class="modal-content">
                            <div id="modalBlock" class="gray-popup-block">
                            	<a href="#" class="modal-close-btn"></a>
	                            	<div class="catAddContainer marB30">
	                            		<h2 class="marB10">User Record</h2>
		                                <p class="marB0"><span class="quoteAcceptText">Date</span> 123456</p>
		                                <p><span class="quoteAcceptText">Full Name</span><input type="text" class="userRecVal" value=""></p>
		                                <p><span class="quoteAcceptText">Email Address</span><input type="text" class="userRecVal" value=""></p>
		                                <p><span class="quoteAcceptText">ID</span><input type="text" class="userRecVal" value=""></p>
		                                <p><span class="quoteAcceptText">Contact</span><input type="text" class="userRecVal" value=""></p>
		                                <p><span class="quoteAcceptText">Company</span><input type="text" class="userRecVal" value=""></p>
		                                <p><span class="quoteAcceptText">User Type</span>
		                                	<select id="userType">
		                                		<option>Admin Level 1</option>
		                                		<option>Admin Level 2</option>
		                                		<option>Supervisor</option>
		                                	</select>
		                                </p>
		                                <p><span class="quoteAcceptText">User Parent</span>
		                                	<select id="userParent">
		                                		<option>Admin Level 1</option>
		                                		<option>Admin Level 2</option>
		                                		<option>Supervisor</option>
		                                	</select>
		                                </p>
		                                <p><span class="quoteAcceptText">Front Office</span>
		                                	<select id="frontOffice">
		                                		<option>Admin Level 1</option>
		                                		<option>Admin Level 2</option>
		                                		<option>Supervisor</option>
		                                	</select>	
		                                </p>
		                                <p><span class="quoteAcceptText">Max Discount Category</span>
		                                	<select id="maxDiscCat">
		                                		<option>Admin Level 1</option>
		                                		<option>Admin Level 2</option>
		                                		<option>Supervisor</option>
		                                	</select>
		                                </p>
	                            	</div>
		                                <a href="#" class="btn" id="userDecline">Decline</a>
		                                <a href="#" class="btn" id="userCancel">Cancel</a>
		                                <a href="#" class="btn" id="userAdd">Add</a>
                            		<div>
	                                	<textarea rows="4" cols="50"></textarea>
	                                </div>
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
    	<!-- HEADING START -->
		<div class="row padB0">
			<div class="container clearfix">
					<div class="data">
						<h1>Quote Outputs</h1>
						<p>Click on the tabs below to view your quote output.</p>
					</div>
			</div>
		</div>
		<div class="container clearfix">
			<div id="quoteOutputContolsBot">
	        	<div class="quoteOutputContols">
	        		<a href="addquote.aspx" class="btn marR12" id="addQuotesBtn">Back to Edit</a>
	            	<a href="quotes.aspx" class="btn marR12" id="editQuotesBtn">Print and Lock Quote</a>
	            	<a href="quotes.aspx" class="btn" id="viewQuotesBtn">Existing Quotes</a>
	        	</div>
	        </div>
        </div>
		<!-- HEADING END -->
		<!-- QUOTES VIEW  LIST -->
		<div class="container clearfix" id="quoteViewContainer">
			<div class="tabs">
			 	<ul class="tab-links">
                      <li class="active"> <a href="#tab1" >Quote Summary</a></li>
			        <li><a href="#tab2">Benefit Details</a></li>
			        <li  ><a href="#tab3">Scheme Costs</a></li>
                      <li><a href="#tab4">Category Costs</a></li>
			        <li><a href="#tab5">Category Summary</a></li>
			        <li><a href="#tab6">Member Covers</a></li>
			        <li><a href="#tab7">Member Costs</a></li>
			        <li><a href="#tab8">Proof Free Limits </a></li>
                       <li><a href="#tab9">Exceptions </a></li>
			    </ul>
               <%-- <div class="tab-content grayCell">--%>
                 
                    <div>
                        
                    </div>
                  <%--  </div>--%>
			    <div class="tab-content grayCell">
                    <div id="tab1"  class="tab active" runat="server" >
                         <asp:GridView runat="server" ID="gvquotesummary1" CssClass="grids" ></asp:GridView>
                     <div style="background-color:DarkGray">
                      <h2 style="margin-bottom:0px">
                          <span style="font-family : 'Cordia New'" runat="server" id="Categories">
                        Categories </span>
                     </h2></div>
                      <asp:GridView runat="server" ID="GridView6" CssClass="grids3">  </asp:GridView>
                    <div style="background-color:DarkGray">
                     <h2 style="margin-bottom:0px">
                          <span style="font-family : 'Cordia New'" runat="server" id="GLILSDPTD">
                       Group Life Insurance and Lump Sum Disability (PTD)</span>
                     </h2></div>
                      <asp:GridView runat="server" ID="GridView1" CssClass="grids">  </asp:GridView>
                      <div style="background-color:DarkGray">
                          <h2 style="margin-bottom:0px">
                             <span style="font-family : 'Cordia New'" runat="server" id="CII"> Critical Illness Insurance </span>
                          </h2></div>
                       <asp:GridView runat="server" ID="GridView2" CssClass="grids3" >  </asp:GridView>
                      <div style="background-color:DarkGray">
                    <h2 style="margin-bottom:0px">
                           <span style="font-family : 'Cordia New'" runat="server" id="GIIMIB">   Group Income Insurance (PHI) / Managed Income Benefit</span>
                          </h2></div>
                       <asp:GridView runat="server" ID="GridView3" CssClass="grids">  </asp:GridView>
                        <div style="background-color:DarkGray">
                          <h2 style="margin-bottom:0px"> <span style="font-family : 'Cordia New'">
                          Group Temporary Income Insurance (TTD)</span>
                          </h2></div>
                       <asp:GridView runat="server" ID="GridView7" CssClass="grids">  </asp:GridView>
                      <div style="background-color:DarkGray">
                          <h2 style="margin-bottom:0px"> <span style="font-family : 'Cordia New'" runat="server" id="SCII">
                            Spouse’s Insurance</span>
                          </h2></div>
                       <asp:GridView runat="server" ID="GridView4" CssClass="grids">  </asp:GridView>
                      <div style="background-color:DarkGray">
                      <h2 style="margin-bottom:0px"> <span style="font-family : 'Cordia New'" runat="server" id="FI">
                            Funeral Insurance</span>
                          </h2></div>
                       <asp:GridView runat="server" ID="GridView5" CssClass="grids3">  </asp:GridView>  
                  </div>
			        <div id="tab2" class="tab" style="overflow-x:scroll">
                         <div id="divLifeInsuranceandLumpSumDisability" visible="true" style=""  runat="server">
                             <asp:GridView runat="server" ID="gvLifeInsuranceLumpSumDisability"></asp:GridView>
                         </div>
                        
                      <div id="divLifeInsuranceandLSDAgeBandedBenefits"  runat="server">
                          <asp:GridView runat="server" ID="gvLifeInsuranceandLSDAgeBandedBenefit"></asp:GridView>
                      </div>
                        <div id="divTaumaInsurance"  runat="server">
 <asp:GridView runat="server" ID="gvTraumaInsurance"></asp:GridView>
                        </div>
                        <div id="divdisabilitybenefit" runat="server">
                            <asp:GridView ID="gvdisabilitybenefit" runat="server"></asp:GridView>
                        </div>
                         <div id="divSpousesLifeInsurance" runat="server">
                             <asp:GridView ID="gvSpousesInsurance" runat="server"></asp:GridView>
                         </div>
                        <div id="divFuneralInsurance"  runat="server">
                            <asp:GridView ID="gvFuneralInsurance" runat="server"></asp:GridView>
                        </div>
			        	<%--<table cellspacing="0" cellpadding="0" class="outputValues">
			        		<tr class="catHeadlines">
			        			<th>&nbsp;</th>
			        			<th>Category 1</th>
			        			<th>Category 2</th>
			        			<th>Category 3</th>
			        			<th>Category 4</th>
			        		</tr>
			        		<tr class="catSubHead">
		        				<td>Life Insurance (incl LSD)</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Cover</td>
		        				<td>3X Salary</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Conversion option</td>
		        				<td>Life and Disability</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Continuation of life cover during disability (PHI)</td>
		        				<td>Yes</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Increasing death benefit during disability (PHI)</td>
		        				<td>Yes</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Terminal Illness Benefit</td>
		        				<td>Yes</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Universal Education Protector</td>
		        				<td>Yes</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Lump sum disability Cover (GOA) - Main member</td>
		        				<td>2x Salary</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Accident Cover</td>
		        				<td>Yes</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr class="catSubHead">
		        				<td>Spouses Insurance</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Life Cover - Spouse</td>
		        				<td>3X Salary</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Conversion option</td>
		        				<td>Life and Disability</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Lump sum disability Cover (GOA) - Main member</td>
		        				<td>2x Salary</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr class="catSubHead">
		        				<td>Trauma Benefit</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Cover</td>
		        				<td>1X Salary</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Trauma Conversion Option</td>
		        				<td>No</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Continuation of trauma cover during disability (PHI)</td>
		        				<td>No</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Increasing trauma benefit during disability</td>
		        				<td>No</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr class="catSubHead">
		        				<td>Family Cover</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Cover</td>
		        				<td>R30,000</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr class="catSubHead">
		        				<td>Disability Income</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Cover</td>
		        				<td>75% of Salary</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Conversion option</td>
		        				<td>75% of Salary</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Cover</td>
		        				<td>No</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Employer waiver</td>
		        				<td>10%</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Escalation</td>
		        				<td>5%</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        	</table>--%>
                        <asp:GridView ID="gridBenefitSummary" HeaderStyle-CssClass="catHeadlines" RowStyle-CssClass="catSubHead"  runat="server"></asp:GridView>
			        </div>
			        <div id="tab3" runat="server" class="tab">
                        <asp:GridView runat="server" ID="gvPremium1"></asp:GridView>
<%--				        <table cellspacing="0" cellpadding="0" class="outputValues">
				        		<tr class="catHeadlines">
				        			<th>&nbsp;</th>
				        			<th>Rate per R1000/R100</th>
				        			<th>Annual Premium</th>
				        			<th>Monthly Premium</th>
				        			<th>Percentage of annual salary</th>
				        		</tr>
				        		<tr class="catSubHead">
			        				<td>Life Insurance (incl LSD)</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Risk Premium</td>
			        				<td>0.170</td>
			        				<td>5,891.17</td>
			        				<td>490.93</td>
			        				<td>0.614%</td>
				        		</tr>
				        		<tr>
			        				<td>Conversion option</td>
			        				<td>0.013</td>
			        				<td>441.84</td>
			        				<td>36.82</td>
			        				<td>0.046%</td>
				        		</tr>
				        		<tr>
			        				<td>Continuation of life cover during disability (PHI)</td>
			        				<td>0.010</td>
			        				<td>329.91</td>
			        				<td>27.49</td>
			        				<td>0.046%</td>
				        		</tr>
				        		<tr>
			        				<td>Increasing death benefit during disability (PHI)</td>
			        				<td>0.010</td>
			        				<td>329.91</td>
			        				<td>27.49</td>
			        				<td>0.046%</td>
				        		</tr>
				        		<tr>
			        				<td>Terminal Illness Benefit</td>
			        				<td>0.010</td>
			        				<td>329.91</td>
			        				<td>27.49</td>
			        				<td>0.046%</td>
				        		</tr>
				        		<tr>
			        				<td>Universal Education Protector</td>
			        				<td>0.010</td>
			        				<td>329.91</td>
			        				<td>27.49</td>
			        				<td>0.046%</td>
				        		</tr>
				        		<tr>
			        				<td>Lump sum disability Cover (GOA) - Main member</td>
			        				<td>0.010</td>
			        				<td>329.91</td>
			        				<td>27.49</td>
			        				<td>0.046%</td>
				        		</tr>
				        		<tr>
			        				<td>Accident Cover</td>
			        				<td>0.010</td>
			        				<td>329.91</td>
			        				<td>27.49</td>
			        				<td>0.046%</td>
				        		</tr>
				        		<tr class="catSubHead">
			        				<td>Spouses Insurance</td>
			        				<td>0.084</td>
			        				<td>1,936.32</td>
			        				<td>161.36</td>
			        				<td>0.202%</td>
				        		</tr>
				        		<tr>
			        				<td>Life Cover - Spouse</td>
			        				<td>0.084</td>
			        				<td>1,936.32</td>
			        				<td>161.36</td>
			        				<td>0.202%</td>
				        		</tr>
				        		<tr>
			        				<td>Conversion option</td>
			        				<td>0.084</td>
			        				<td>1,936.32</td>
			        				<td>161.36</td>
			        				<td>0.202%</td>
				        		</tr>
				        		<tr>
			        				<td>Lump sum disability Cover (GOA) - Main member</td>
			        				<td>0.084</td>
			        				<td>1,936.32</td>
			        				<td>161.36</td>
			        				<td>0.202%</td>
				        		</tr>
				        		<tr class="catSubHead">
			        				<td>Trauma Benefit</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Cover</td>
			        				<td>0.260</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Trauma Conversion Option</td>
			        				<td>0.260</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Continuation of trauma cover during disability (PHI)</td>
			        				<td>0.260</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Increasing trauma benefit during disability</td>
			        				<td>0.260</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr class="catSubHead">
			        				<td>Family Cover</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Cover</td>
			        				<td>0.345</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr class="catSubHead">
			        				<td>Disability Income</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Cover</td>
			        				<td>3.228</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Conversion option</td>
			        				<td>3.228</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Cover</td>
			        				<td>3.228</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Employer waiver</td>
			        				<td>3.228</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
				        		<tr>
			        				<td>Escalation</td>
			        				<td>3.228</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
			        				<td>&nbsp;</td>
				        		</tr>
			        	</table>--%>
			        </div>
                     <div id="tab4" class="tab" runat="server">
                         
                         <asp:GridView runat="server" ID="gvCategoryCost"></asp:GridView>
                         
                     </div>
			        <div id="tab5" class="tab" runat="server">
                         <asp:GridView runat="server" ID="gvcategory1"></asp:GridView>
<%--			        <table cellspacing="0" cellpadding="0" class="outputValues">
			        		<tr class="catHeadlines">
			        			<th>&nbsp;</th>
			        			<th>Category</th>
			        			<th>Rate per R1000/R100</th>
			        			<th>Annual Premium</th>
			        			<th>Monthy Premium</th>
			        			<th>Percentage of annual salary</th>
			        		</tr>
			        		<tr class="catSubHead">
		        				<td>Life Insurance (incl LSD)</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>Risk Premium</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>1</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>2</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>3</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>4</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>5</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>Conversion option</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>1</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>2</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>3</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>4</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>5</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>Continuation of life cover during disability (PHI)</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>1</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>2</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>3</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>4</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>5</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>Increasing death benefit during disability (PHI)</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>1</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>2</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>3</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>4</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>5</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>Terminal Illness Benefit</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
		        				<td>&nbsp;</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>1</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>2</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>3</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>4</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        		<tr>
		        				<td>&nbsp;</td>
		        				<td>5</td>
		        				<td>0.17</td>
		        				<td>5,891.18</td>
		        				<td>490.93</td>
		        				<td>0.61%</td>
			        		</tr>
			        	</table>--%>
			        </div>
			        <div id="tab6" class="tab">
                       
                        <asp:GridView ID="gvMemberCovers" runat="server"></asp:GridView>
			        	 <%--<table cellspacing="0" cellpadding="0" class="outputValues">
			        		<tr class="catHeadlines">
			        			<th>Member Name</th>
			        			<th>Life Cover</th>
			        			<th>Lump Sum Disability Cover</th>
			        			<th>Trauma Cover</th>
			        			<th>Income Disability Cover</th>
			        			<th>Family Benefit Cover</th>
			        			<th>Spouses Life Cover</th>
			        			<th>Spouses Disability Cover</th>
			        		</tr>
			        		<tr>
		        				<td>John Peter Williams Johnson</td>
		        				<td>20 000 000</td>
		        				<td>2 000 000</td>
		        				<td>50 000</td>
		        				<td>3 000 000</td>
		        				<td>4 000 000</td>
		        				<td>30 000 000</td>
		        				<td>1 000 000</td>
			        		</tr>
			        		<tr>
		        				<td>Sarah Johnson</td>
		        				<td>20 000 000</td>
		        				<td>2 000 000</td>
		        				<td>50 000</td>
		        				<td>3 000</td>
		        				<td>4 000 000</td>
		        				<td>30 000 000</td>
		        				<td>1 000 000</td>
			        		</tr>
		        		 </table>--%>
			        </div>
			        <div id="tab7" class="tab">
                        <asp:GridView ID="gvMemberCost" runat="server"></asp:GridView>
			        	<%--<table cellspacing="0" cellpadding="0" class="outputValues">
			        		<tr class="catHeadlines">
			        			<th>Member Name</th>
			        			<th>Life Premium</th>
			        			<th>Lump Sum Disability Premium</th>
			        			<th>Trauma Premium</th>
			        			<th>Income Disability Premium</th>
			        			<th>Family Benefit Premium</th>
			        			<th>Spouses Life Premium</th>
			        			<th>Spouses Disability Premium</th>
			        		</tr>
			        		<tr>
		        				<td>John Peter Williams Johnson</td>
		        				<td>5 000</td>
		        				<td>1 000</td>
		        				<td>800</td>
		        				<td>900</td>
		        				<td>5 000</td>
		        				<td>5 000</td>
		        				<td>8 000</td>
			        		</tr>
			        		<tr>
		        				<td>Sarah Johnson</td>
		        				<td>5 000</td>
		        				<td>1 000</td>
		        				<td>800</td>
		        				<td>900</td>
		        				<td>5 000</td>
		        				<td>5 000</td>
		        				<td>8 000</td>
			        		</tr>
		        		 </table>--%>
			        </div>
			        <div id="tab8" class="tab" runat ="server">
                        <asp:GridView ID="gvFreeCoverLimits" runat="server" CssClass="grids2"></asp:GridView>
			        <%--<table cellspacing="0" cellpadding="0">
			        		<tr>
			        			<th><h2 class="marB0">Free Cover Limits</h2></th>
			        		</tr>
		        		 </table>--%>
			        <%--<table cellspacing="0" cellpadding="0" class="outputValues">
			        		<tr class="catHeadlines">
			        			<th>Main Member</th>
			        			<th>&nbsp;</th>
			        		</tr>
			        		<tr>
			        			<td>Life Cover </td>
		        				<td>R4 000 000</td>
			        		</tr>
			        		<tr>
			        			<td>PHI Cover (per month) </td>
		        				<td>R2 000 000</td>
			        		</tr>
			        		<tr>
			        			<td>Trauma </td>
		        				<td>R1 000 000</td>
			        		</tr>
			        		<tr class="catSubHead">
			        			<td>Spouse</td>
			        			<td>&nbsp;</td>
			        		</tr>
			        		<tr>
			        			<td>Life Cover</td>
			        			<td> R4 00 0000</td>
			        		</tr>
	        		</table>--%>
			        </div>
                    <div id="tab9" class="tab" runat="server">
                         <div style="background-color:DarkGray">
                            <h2 style="margin-bottom:0px">
                                <span style="font-family : 'Cordia New'">
                                     Employees older than Maximum Cover Age: </span>
                            </h2>
                        </div>
                        <div style="background-color:lightgray">
                             <h2 style="margin-bottom:0px">
                                  <span style="font-family : 'Cordia New'">
                                 The members below are excluded from one or more benefits</span>
                             </h2>

                        </div>
                         <asp:GridView runat="server" ID="gvexpectation" CssClass="grids2"></asp:GridView>
                        <div style="background-color:DarkGray">
                            <h2 style="margin-bottom:0px">
                                <span style="font-family : 'Cordia New'">
                                     Group Life Insurance: </span>
                            </h2>

                        </div>
                         <asp:GridView runat="server" ID="gvexpectation1" CssClass="grids1"></asp:GridView>
                         <div style="background-color:DarkGray">
                            <h2 style="margin-bottom:0px">
                                <span style="font-family : 'Cordia New'">
                                     Critical Illness Insurance: </span>
                            </h2>

                        </div>
                         <asp:GridView runat="server" ID="gvexpectation2" CssClass="grids1"></asp:GridView>
                         <div style="background-color:DarkGray">
                            <h2 style="margin-bottom:0px">
                                <span style="font-family : 'Cordia New'">
                                    Group Income Benefit per month (PHI) / Managed Income Benefit per month: </span>
                            </h2>

                        </div>
                         <asp:GridView runat="server" ID="gvexpectation3" CssClass="grids1"></asp:GridView>
                         <div style="background-color:DarkGray">
                            <h2 style="margin-bottom:0px">
                                <span style="font-family : 'Cordia New'">
                                     Group Temporary Income Benefit per month (TTD): </span>
                            </h2>

                        </div>
                         <asp:GridView runat="server" ID="gvexpectation4" CssClass="grids1"></asp:GridView>
                         <div style="background-color:DarkGray">
                            <h2 style="margin-bottom:0px">
                                <span style="font-family : 'Cordia New'">
                                    Spouse of a member: </span>
                            </h2>

                        </div>
                         <asp:GridView runat="server" ID="gvexpectation5" CssClass="grids1"></asp:GridView>
                         <asp:GridView runat="server" ID="gvexpectation6"></asp:GridView>
                    </div>
				</div>
			</div>	
		</div>		        
		<!-- QUOTES VIEW ENDS -->
		<div class="row padT0">
			<div class="container clearfix">
				<div id="Div1">
		        	<div class="quoteOutputContols">
                        <asp:Button ID="viewQuoteEdit" runat="server" CssClass="btn marR12" Text=">Edit quote" OnClick="viewQuoteEdit_Click" />
		            	<a href="addquote.html" class="btn marR12" id="viewQuotesSave">Save quote</a>
		            	<a href="quotes.html" class="btn marR12" id="viewQuotesPrint">Print and lock quote</a>
		            	<a href="quotes.html" class="btn" id="viewQuotesNext">Next</a>
		        	</div>
		        </div>
	        </div>
        </div>
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
                                    <h2>Quotes Contacts
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
</div>
<!-- MAIN WRAPPER END -->
        <script type="text/javascript" src="js/scripts.js"></script>
    </form>
</body>
</html>
