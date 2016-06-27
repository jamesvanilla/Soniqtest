<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                <div class="modal-wrap" id="quoteModal">
                    	<a href="#" class="modal-close-btn"></a>
                    <div class="modal-container modal-s-ready modal-inline-holder">
                        <div class="modal-content">
                            <div id="modalBlock" class="gray-popup-block">
                            	<div class="catAddContainer">
                            		<h2 class="marB10">Accept Quote</h2>
	                                <p class="marB0"><span class="quoteAcceptText">Quote Number:</span> 123456</p>
	                                <p><span class="quoteAcceptText">Client Name:</span> Johan Smith</p>
                            	</div>
                            	</div>
	                            	<div id="attachDocuments">
	                            		<h3>Attach Documents</h3>
					                        <a href="#" class="clearVal">Remove</a>
					                        <input id="uploadFile" placeholder="" disabled="disabled" value="">
											<div class="fileUpload btn btn-primary">
											    <span>Select File</span>
											    <input id="uploadBtn" type="file" class="upload">
											</div>
	                            		<span class="fileSizeText">*Maximum total file size is 10mb</span>
	                            		<div class="marT30">
		                            		<label>Field</label>
		                            		<input type="text" class="">
	                            		</div>
	                            		<div>
		                            		<label>Field</label>
		                            		<input type="text" class="">
	                            		</div>
	                            		<div>
		                            		<label>Field</label>
		                            		<input type="text" class="">
	                            		</div>
	                            	</div>
	                                <a href="#" class="btn" id="quoteAcceptBtn">Accept and Submit</a>
	                                <a href="#" class="btn" id="quoteAcceptSaveBtn">Save</a>
	                                <a href="#" class="btn gray" id="quoteAcceptCancelBtn">Cancel</a>
                                </div>
                        </div>
                    </div>
                </div>
                <!-- Save POPUP END -->
		<!-- HEADING START -->
		<div class="row">
			<div class="container clearfix">
					<div class="data">
						<h1>Welcome to Group Risk Online Quotes</h1>
						<p>Click NEW QUOTE to start a new quote. Click EXISTING QUOTES to view all your previous quotes or edit a quote or replicate a quote.</p>
					</div>
			</div>
          
		<!-- HEADING END -->
		<!-- LATEST QUOTES LIST -->
		<div class="row padT0">
			
		<div class="container marB30">
			<div class="quoteContainer clearfix grayCell marB30">
				            	<div class="span5 push5 marB15">
		                        	<h2 class="latestHeadline">Your Latest Quotes</h2>
		                        	<div class="latestBtnsContainer">
                                        <asp:Button ID="addquotebtn" class="btn marR12"  runat="server" Text="New Quote" OnClick="addquotebtn_Click"  />
                                          <asp:Button ID="viewquotebtn" class="btn marR12" runat="server" Text="Existing Quotes" OnClick="viewquotebtn_Click" />
                                <!--          <asp:Button ID="viewquotebtn0" class="btn marR12" runat="server" Text="RFriskv100" OnClick="viewquotebtn_Click" PostBackUrl="~/RFriskv100CS.aspx" /></div>
		                        		<a href="addquote.html" class="btn marR12" id="addQuotesBtn">Add a Quote</a>
			                         	<a href="addquote.html" class="btn gray marR12" id="editQuotesBtn">Edit AQuote</a>  
			                        	<a href="quotes.html" class="btn gray" id="viewQuotesBtn">View More Quotes</a>   --> 
		                        	</div>
		                        </div>

		                        	<div id="searchResults" class="grayCell padB35">
	                					<div id="rateDiscountTable">
	                						<%--<table id="latestQuotesTableData">
					                			<tr>
					                				<th>Date</th>
					                				<th>Quote Number</th>
					                				<th>Member Full Name</th>
					                				<th>User</th>
					                				<th>Status</th>
					                				<th>Action</th>
					                				<th>Download</th>
					                			</tr>
					                			<tr>
					                				<td>19/1/2016</td>
					                				<td>201609</td>
					                				<td>Petronella Smith</td>
					                				<td>Tony</td>
					                				<td>Locked</td>
					                				<td>
					                					<select class="selectAction" id="row1">
					                						<option>Select Action</option>
					                						<option>Replicate Quote</option>
					                						<option>Email Quote PDF</option>
					                						<option>Accept Quote</option>
					                					</select>
					                				</td>
					                				<td><a href="#" class="downloadLink"></a></td>
					                			</tr>
					                			<tr>
					                				<td>19/1/2016</td>
					                				<td>201609</td>
					                				<td>Petronella Smith</td>
					                				<td>Tony</td>
					                				<td>Locked</td>
					                				<td>
					                					<select class="selectAction">
					                						<option>Select Action</option>
					                						<option>Replicate Quote</option>
					                						<option>Email Quote PDF</option>
					                						<option>Accept Quote</option>
					                					</select>
					                				</td>
					                				<td><a href="#" class="downloadLink"></a></td>
					                			</tr>
					                			<tr>
					                				<td>19/1/2016</td>
					                				<td>201609</td>
					                				<td>Petronella Smith</td>
					                				<td>Tony</td>
					                				<td>Locked</td>
					                				<td>
					                					<select class="selectAction">
					                						<option>Select Action</option>
					                						<option>Replicate Quote</option>
					                						<option>Email Quote PDF</option>
					                						<option>Accept Quote</option>
					                					</select>
					                				</td>
					                				<td><a href="#" class="downloadLink"></a></td>
					                			</tr>
					                			<tr>
					                				<td>19/1/2016</td>
					                				<td>201609</td>
					                				<td>Petronella Smith</td>
					                				<td>Tony</td>
					                				<td>Locked</td>
					                				<td>
					                					<select class="selectAction">
					                						<option>Select Action</option>
					                						<option>Replicate Quote</option>
					                						<option>Email Quote PDF</option>
					                						<option>Accept Quote</option>
					                					</select>
					                				</td>
					                				<td><a href="#" class="downloadLink"></a></td>
					                			</tr>
	                					</table>--%>
                                            <asp:GridView ID="latestQuotesTableData" runat="server" ></asp:GridView>
				                	</div>
									</div>
		                        </div>
        		</div>
		</div>

		</form>

		<!-- LATEST QUOTES LIST ENDS -->
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
<script src="js/scripts.js"></script>
    </div>
    </form>
</body>
</html>
