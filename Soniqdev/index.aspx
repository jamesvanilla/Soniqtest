<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=1.0, initial-scale=1, maximum-scale=1, minimum-scale=1, user-scalable=no" />
    <title>Sanlam Soniq</title>
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
        <!-- MOBILE NAV -->
        <nav id="slideNav" class="noindex">
            <div id="slideNavWrapper">
                <div class="slideNavMenu" id="slideNavMain">
                    <div id="slideNavPrimaryLinks">
                        <h2>Sanlam
                                
                                
                        </h2>
                        <ul>

                            <li id="slideNavHome">
                                <a href="/Pages/default.aspx">Home
                                        
                                        
                                </a>

                            </li>
                            <li id="slideNavQuote">
                                <a href="#" class="slideNavArrow" class="slideNavArrow">Quotes
                                        
                                        
                                </a>
                                <ul class="slideNavSubLinks">
                                    <li>
                                        <a href="#">Add Quote
                                                
                                                
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">Edit Quote
                                                
                                                
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li id="slideNavAboutSoniq">
                                <a href="#">About Soniq
                                        
                                        
                                </a>
                            </li>
                            <li id="slideNavFAQ">
                                <a href="#">FAQ
                                        
                                        
                                </a>
                            </li>
                            <li id="slideNavContact">
                                <a href="#">Contact
                                        
                                        
                                </a>
                            </li>
                        </ul>
                    </div>
                    <hr />
                    <div id="slideNavAccountLinks">
                        <ul>
                            <li id="slideNavLogin">
                                <a href="#" class="slideNavArrow">Login
                                        
                                        
                                </a>
                                <ul class="slideNavSubLinks">
                                    <li>
                                        <a href="#" target="_blank">Log Out
                                                
                                                
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" target="_blank">Edit Profile
                                                
                                                
                                        </a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <!--  end #slideNavMain -->
                <div class="slideNavMenu" id="slideNavSub">
                    <a href="#" class="slideNavBack">Back
                            
                            
                            
                            
                    </a>
                    <div class="slideNavSubListWrapper">
                        <h2>
                            <!-- updated dynamically -->
                        </h2>
                        <ul class="slideNavSubLinks">
                        </ul>
                    </div>
                    <a href="#" class="slideNavBack">Back
                            
                            
                            
                            
                    </a>
                </div>
                <!--  end #slideNavSub -->
                <div class="slideNavMenu" id="slideNavSubSub">
                    <a href="#" class="slideNavBack">Back
                            
                            
                            
                            
                    </a>
                    <div class="slideNavSubListWrapper">
                        <h2>
                            <!-- updated dynamically -->
                        </h2>
                        <ul class="slideNavSubSubLinks">
                        </ul>
                    </div>
                    <a href="#" class="slideNavBack">Back
                            
                            
                            
                            
                    </a>
                </div>
                <!--  end #slideNavSub -->
            </div>
            <!-- end #slideNavWrapper -->
        </nav>
        <!-- MOBILE NAV -->
        <!-- MAIN WRAPPER -->
        <div id="page" class="soniq soniqHome" style="margin: auto; float: none;">
            <div id="overlay"></div>
            <!-- Sanlam COM - Desktop nav -->
            <nav id="headerNav" class="noindex">
                <div id="headNavContainer" class="clearfix">
                    <a href="http://www-admin-dev.sanlam.co.za/personal/insurance/personal-and-family-insurance/Pages/lorraine-story.aspx#" id="navBtn"></a>
                    <div id="sanlamLogo">
                        <a class="sanlamLogo-logo" href="http://www-admin-dev.sanlam.co.za/Pages/default.aspx">
                            <img src="./img/sanlam-logo.png" alt="Sanlam">
                        </a>
                    </div>
                    <ul id="primaryLinks">
                        <li id="personal">
                            <a class="parentLink" href="http://www-admin-dev.sanlam.co.za/personal/insurance/personal-and-family-insurance/Pages/lorraine-story.aspx#">About SONIQ</a>
                        </li>
                        <li id="businessOwners">
                            <a class="parentLink" href="http://www-admin-dev.sanlam.co.za/personal/insurance/personal-and-family-insurance/Pages/lorraine-story.aspx#">FAQ</a>
                        </li>
                    </ul>
                    <ul id="secondaryLinks">
                        <li id="institutional">
                            <a class="parentLink" href="http://www-admin-dev.sanlam.co.za/personal/insurance/personal-and-family-insurance/Pages/lorraine-story.aspx#">Contact</a>
                        </li>
                    </ul>
                    <ul id="accountLinks">
                        <li id="account">
                            <a href="https://cp.sanlam.co.za/" target="_blank">
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

                        <a class="logo logoText" href="/Pages/default.aspx" style="margin: 0px 0 0px 0px">SONIQ
			            <!-- <img src="Style_Library/img/private-wealth-v2.png" alt="Private Wealth" style="width: 200px"> -->
                        </a>

                        <input type="text" placeholder="Username" id="awezers">
                        <input type="text" placeholder="Password" id="Text1">

                        <a href="#" class="btn" style="width: 75px; margin-bottom: 6px;">register</a>
                        <a href="#" class="btn" style="width: 70px; margin-bottom: 6px;">login</a>

                        <a href="#" style="text-decoration: none; margin: 0 2px 25px 0; text-align: right; display: block">Forgot Password</a>

                    </div>
                </div>
            </div>
            <!-- end Sanlam COM - Banner Image -->
            <!-- HEADING START -->
            <div class="row">
                <div class="container clearfix">
                    <div class="data">
                        <h1>Welcome to SONIQ</h1>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    </div>
                </div>
            </div>
            <div class="row grayCell">
                <div class="container clearfix">
                    <div class="data">
                        <h2>Registration</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    </div>
                </div>
            </div>
            <!-- HEADING END -->
            <div id="footerDesktop" class="row footerBg">
                <footer class="container clearfix">
                    <div class="col1">
                        <a href="#" id="footer_Personal">
                            <h2>About Soniq
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
                            <h2>Contact SONIQ
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
                        <p>
                            Copyright © 2016 All rights reserved.Sanlam Life Insurance Limited is a Licensed Financial Services Provider and a Registered Credit Provider
                                
                                
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
                                    <a href="https://www.youtube.com/sanlam" target="_blank" class="youtube"></a>
                                </li>
                                <li>
                                    <a href="https://twitter.com/sanlam" target="_blank" class="twitter"></a>
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
    </form>
    <script src="js/scripts.js"></script>
</body>
</html>
