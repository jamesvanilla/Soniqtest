
var html = $('html, body'),
    winWidth  = $(window).width(),
    winHeight = $(window).height(),
    winTop = 0,
    docHeight = $(document).height(),
    desktop = 1280,
    tablet = 1150,
    mobile = 555,
    navOpen = 0,
    formOpen = 0,
    s;
// -----------------------------------------//
//          CUSTOM SELECTBOX CREATOR        //
//------------------------------------------//
CustomSelect = {
    init: function () {
        // initialize jQuery selectmenu & ignore fulfillment's select box
        $('select').selectmenu();

        this.setDropDownMenu();
    },

    setDropDownMenu: function () {

        // how many select boxes?
        var selectBoxes = $('select').length;

        // loop through each select box and set width of dropdown menu
        for (var i = 0; i < selectBoxes; i++) {

            // ignore fulfillment's select box
            if ($('select').eq(i).attr('id') !== 'fulfillmentSelect') {

                var buttonId = $('select').eq(i).next().find('a.ui-selectmenu').attr('id'),
                menuId = buttonId.replace(/button/g, 'menu'),
                buttonWidth = $('#' + buttonId).width();

                // set width of dropdown menu
                $('#' + menuId).width(buttonWidth + 20);
            }
        }
    }
}; // end of CUSTOM SELECTBOX
// -----------------------------------------//
//             SLIDE NAVIGATION             //
//------------------------------------------//
var SlideNav = {

    init: function() {
        s = this.settings;
        this.bindUIActions();
    },

    bindUIActions: function() {
        // click hamburger icon to open or close
        $('a#navBtn').click(function (e) {
            e.preventDefault()
            //alert(navOpen);
            if (navOpen == 0) SlideNav.openIt();
            else SlideNav.closeIt();

            // close fulfillment form if open
            if (formOpen == 1) FulfillForm.closeIt();

            // prevent closing right after opening
            return false;
        });

        // click page to close nav
        $('#page').click(function() {
            if (navOpen == 1) SlideNav.closeIt();
        });

        // slide in sub menu
        $('#slideNavMain').on('click', 'a.slideNavArrow', function (e) 
        {
            e.preventDefault();

            var linkText = $(this).clone(),
                subMenu  = $(this).siblings().attr('class'),
                parentId = '#' + $(this).parent().attr('id'),
                position = -270;

            // if link has no url remove the <a> from the heading
            if (linkText.attr('href') == '#') 
            {
                var content = linkText.contents();
                linkText = content;
            } 

            SlideNav.slideInSubMenu( linkText, subMenu, parentId, position );
        });

        // slide in sub menu
        $('#slideNavSub').on('click', 'a.slideNavArrow', function (e)
        {
            e.preventDefault();

            var linkText = $(this).clone(),
                subMenu  = $(this).siblings().attr('class'),
                parentId = '#' + $(this).parent().attr('id'),
                position = -540;

            // if link has no url remove the <a> from the heading
            if (linkText.attr('href') == '#') 
            {
                var content = linkText.contents();
                linkText = content;
            }   

            SlideNav.slideInSubSubMenu( linkText, subMenu, parentId, position );
        });
        
        // Anchor Links
        // To prevent the slideNav from staying open when linking to an achor link on the same page
        // first see if the link is pointing at the same page, and if so then close the slideNav and
        // go to the location of the anchor link
        $('#slideNavSub').on('click', 'a', function (e)
        {
            if ( !( $(this).hasClass(".slideNavArrow") ) ) {
                var url = window.location.href;
                var linkUrl = $(this).attr('href');
                linkUrl = linkUrl.substring( 0, linkUrl.indexOf('#') );
            
                if ( url.indexOf( linkUrl ) > 0 ) SlideNav.closeItNoAnim(); 
            }      
        });

        // slide out sub menu
        $('a.slideNavBack').click(function (e) 
        {
            e.preventDefault();
            var parentId = $(this).parents('.slideNavMenu').attr('id');

            SlideNav.slideOutSubMenu(parentId);
        });
    },

    openIt: function ()
    {
        navOpen = 1;
        $('#slideNav').show();
        $('#page').addClass('slideNavOpen').animate({'marginLeft':'270px'}, 300);
        $('#slideNav').animate({'marginLeft':'0'}, 300);
    },

    closeIt: function ()
    {
        navOpen = 0;
        $('#page').animate({'marginLeft':'0'}, 300,
            function () {
                $(this).removeClass('slideNavOpen');
            }
        );

        $('#slideNav').animate({'marginLeft':'-270px'}, 300, function() {
            $('#slideNav').hide();
            $('#page').css({'margin':'auto', 'float':'none'});
        });
    },

    closeItNoAnim: function () 
    {
        navOpen = 0;
        $('#page')
            .css({'margin':'auto', 'float':'none'})
            .removeClass('slideNavOpen');
        $('#slideNav').css({'marginLeft':'-270px'});
        $('#slideNav').hide();
    },

    slideInSubMenu: function (linkText, subMenu, parentId, position) 
    {
        if (subMenu == "slideNavSubLinks") 
        {
            var copiedLinks = $(parentId + ' .slideNavSubLinks').html();

            $('#slideNavSub .slideNavSubListWrapper')
                .find('h2').html(linkText)
                    .end()
                .find('h2 a').removeClass('slideNavArrow')
                    .end()
                .find('.slideNavSubLinks').append(copiedLinks).show();

            // if not on top of page:
            //   - scroll to top
            //   - and then open up sub menu
            // otherwise open up sub menu without scrolling up
            if ($('body,html').scrollTop() > 0) 
            {
                $('body,html').animate({scrollTop: 0}, 400, function () {
                    $('#slideNavWrapper').animate({marginLeft: position}, 300);
                });
            } 
            else 
            {
                $('#slideNavWrapper').animate({marginLeft: position}, 300);
            }
        }
    },

    slideInSubSubMenu: function(linkText, subMenu, parentId, position) 
    {
        if (subMenu == "slideNavSubSubLinks") 
        {
            var copiedLinks = $(parentId + ' .slideNavSubSubLinks').html();

            $('#slideNavSubSub .slideNavSubListWrapper')
                .find('h2').html(linkText)
                    .end()
                .find('h2 a').removeClass('slideNavArrow')
                    .end()
                .find('.slideNavSubSubLinks').append(copiedLinks).show();


            // if not on top of page:
            //   - scroll to top
            //   - and then open up sub menu
            // otherwise open up sub menu without scrolling up
            if ($('body,html').scrollTop() > 0) 
            {
                $('body,html').animate({scrollTop: 0}, 400, function () {
                    $('#slideNavWrapper').animate({marginLeft: -540}, 300);
                });
            } 
            else 
            {
                $('#slideNavWrapper').animate({marginLeft: -540}, 300);
            }  
        }
    },

    slideOutSubMenu: function(parentId) 
    {
        // when closing the mobile menu and the user has scroll below it
        // first let the window scroll back to the top
        // and then slide the menu closed
        var position = parentId == 'slideNavSub' ? 0 : -270,
            timeout  = 0;

        if ($('body, html').scrollTop() > 0) 
        {
            timeout = 300;
            $('body, html').animate({scrollTop: 0}, 300);
        }

        setTimeout(function ()
        {
            $('#slideNavWrapper').animate({marginLeft: position}, 300, function () {
                $('#' + parentId + ' .slideNavSubLinks').empty();
                $('#' + parentId + ' .slideNavSubSubLinks').empty();
            });
        }, timeout);
    }
}; // end of SLIDE NAVIGATION
// -----------------------------------------//
//             HEADER NAVIGATION            //
//------------------------------------------//
var activeDropdown = '';

var HeaderNav = {

    init: function() {
        s = this.settings;

        this.bindUIActions();
    },

    bindUIActions: function() {
            
        // The 'Login' link is a dropdown on desktop, and a link on tablet/mobile
        $('#headerNav #account > a').click(function (e) {
            if ( winWidth > tablet && $('#headerNav #account .dropMenu').length ) { e.preventDefault(); }
        });

        // Header link drop-downs
        $('#headerNav a').not('a#navBtn').click(function(e) {

            // Open the link's drop-down menu only if:
            //  - if on desktop
            //  - and if the arrow was clicked 
            //    or if the logo was clicked on the home page
            //    or if it's not the sanlam logo
            if ( 
                winWidth > tablet && 
                ( ($(this).is('.sanlamLogo-logo') && $(this).hasClass('showDropdownOnClick')) || !$(this).is('.sanlamLogo-logo') )
            ) {
                var thisDropdown = $(this).parent().find('.dropMenu');
    
                // if linked link has a dropdown menu and if it's not already visible
                if (thisDropdown.length > 0 && thisDropdown.css('display') === 'none') {
                
                    // if no drop down is open
                    if (activeDropdown === '') {
                        // store clicked link id
                        activeDropdown = '#' + $(this).parent().attr('id');
                        HeaderNav.openDropdown();
                        $('#overlay').fadeIn(300);
                    } 
                    else {
                        HeaderNav.closeDropdown();
                        // update variable
                        activeDropdown = '#' + $(this).parent().attr('id');
                        setTimeout(function () {
                            HeaderNav.openDropdown();
                        }, 200);
                    }
                }
            }
            
            // Prevent the links default event only if:
            //  - it has the 'showDropdownOnClick' class
            //  - and it's on desktop
            if ( $(this).hasClass('showDropdownOnClick') && winWidth > tablet ) {
                e.preventDefault();
            }
        });

        // click overlay or X to close drop-down
        $('#overlay, .dropMenuClose').click(function (e) {
            e.preventDefault();

            HeaderNav.closeDropdown(activeDropdown);
            $('#overlay').fadeOut(300);
        });
        
        // when anchor linking on smae page, close dropmenu and overlay
        $('.dropMenu a').click(function () {
            HeaderNav.closeDropdown(activeDropdown);
            $('#overlay').fadeOut(300);
        });
        
        //GLOBE CLICK EVENT
        $('#sanlamGlobe').click(function () {
           $(this).parent().addClass('globeNavActive');
           $('.globeNavActive').find('.dropMenuArrow').addClass('globeActive');
           $('.globeNavActive').find('.dropMenu').addClass('globeActive');

        });

        // switch between english and afrikaans 
        $('#language a').click(function (e) {
            e.preventDefault();
            var clickedLanguage = $(this).attr('id');
            HeaderNav.language(clickedLanguage);
            $('#overlay').fadeOut(300);
        });
    },

    openDropdown: function () {
        // if on desktop
        if (winWidth >= tablet) {

            $('#headerNav ' + activeDropdown + ' > a').addClass('activeLink');
            $('#headerNav ' + activeDropdown + ' .dropMenu').show();
            $('#headerNav ' + activeDropdown + ' .dropMenu').animate({
                opacity: 1, top: 69 + 'px'
            }, 200);
        }

        // when opening search drop-down focus on field
        if ($('#search .dropMenu').css('display') === 'block') {
            $('#search .dropMenu input').focus();
        }

        if (winWidth > mobile) HeaderNav.dynamicMenuColHeight();
    },

    closeDropdown: function () {
        var dropdown = activeDropdown;

        $('#headerNav '+dropdown+' > a').removeClass('activeLink');

        // animate drop down closing
        $('#headerNav '+dropdown+' .dropMenu').animate({
            opacity: 0, top: 55+'px'
        }, 150, function () {
            $('#headerNav '+dropdown+' .dropMenu').hide();
            $('#headerNav '+dropdown+' .dropMenu').removeClass('globeActive');
            $('#headerNav '+dropdown+' .dropMenuArrow').removeClass('globeActive');
            $('#sanlamLogo').removeClass('globeNavActive');

        });

        activeDropdown = '';
    },

    dynamicMenuColHeight: function () {
        var listItems    = $('#headerNav .activeLink').parent().find('.listItems'),
            maxListItems = listItems .length;

        if (maxListItems > 0) {
            // check item heights
            var item1Height = listItems.eq(0).height(),
                item2Height = listItems.eq(1).height(),
                item3Height = listItems.eq(2).height(),
                item4Height = listItems.eq(3).height(),
                item5Height = listItems.eq(4).height();

            // find heighest listItem
            var maxHeight = Math.max(
                item1Height, item2Height, item3Height, item4Height, item5Height
            );

            // set all listItems height
            for (var i = 0, j = maxListItems; i < j; i++) {
                listItems.eq(i).height(maxHeight);
            }
        }
    },

    locations: function (clickedLocation) {
        $('#currentLocation').text(clickedLocation.toUpperCase());
        HeaderNav.closeDropdown(activeDropdown);
        $('#overlay').fadeOut(300);
    },

    language: function (clickedLanguage) {
        if (clickedLanguage == "english") {
            $('#afrikaans').removeClass('currentLanguage');
            $('#english').addClass('currentLanguage');
        } else {
            $('#english').removeClass('currentLanguage');
            $('#afrikaans').addClass('currentLanguage');
        }
    }
}; // end of HEADER NAVIGATION
// -----------------------------------------//
//                 ACCORDION                //
//------------------------------------------//
function accordion_constructor() {
    this.active = null;
}

var accordions = {};

var accordion_module = 
{
    init: function () 
    {
        s = this.settings;
        this.createInstances();
    },
    createInstances: function () 
    {
        $('.accordion').each(function() 
        {
            if ( $(this).hasClass("hasInit") == false )
            {
                // has initialized
                $(this).addClass("hasInit");

                var name  = $(this).attr('id'),
                    items = $('#' + name).find('.categoryListItem').length;

                // assign index number to each accordion item
                for (var i = 0; i < items; i++) 
                {
                    $('#' + name).find('.categoryListItem').eq(i).attr('data-index', i);
                }

                // create object instance
                accordions[name] = new accordion_constructor();

                // have first item open
                if ($(this).find('.categoryListItem').eq(0).hasClass('active'))
                {
                    $(this).find('.categoryListItem').eq(0).find('.accordionText').show();
                    accordions[name].active = 0;
                }

                accordion_module.bindUIActions(name);
            }
        });
    },
    bindUIActions: function(name) 
    {
        $('#'+name+' .accordionTitle a').click(function(e) 
        { 
            e.preventDefault();

            // get parent id and index number
            var name  = $(this).parents('.accordion').attr('id'),
                index = $(this).parents('.categoryListItem').attr('data-index');

            if ($(this).parents('.categoryListItem').hasClass('active')) 
            {
                accordion_module.closeIt(name, index);
            }  
            else 
            {
                if (accordions[name].active !== null)
                {
                    accordion_module.closeIt(name, accordions[name].active);
                }

                accordion_module.openIt(name, index);
            }
        });
    },
    openIt: function(name, index) 
    {
        $('#' + name).find('.categoryListItem').eq(index)
            .addClass('active')
            .find('.accordionText').slideDown(350);

        accordions[name].active = index;
    },
    closeIt: function (name, index)
    {
        $('#' + name).find('.categoryListItem').eq(index)
            .removeClass('active')
            .find('.accordionText').slideUp(350);

        accordions[name].active = null;
    }
}; // end of ACCORDION
//TOOLTIP CODE
function toolTip() {
      //TOOLTIP 
        var targets = $( '[rel~=tooltip]' ),
            target  = false,
            tooltip = false,
            title   = false;
     
        targets.bind( 'mouseenter', function()
        {
            target  = $( this );
            tip     = target.attr( 'title' );
            tooltip = $( '<div id="tooltip"></div>' );
     
            if( !tip || tip == '' )
                return false;
     
            target.removeAttr( 'title' );
            tooltip.css( 'opacity', 0 )
                   .html( tip )
                   .appendTo( 'body' );
     
            var init_tooltip = function()
            {
                if( $( window ).width() < tooltip.outerWidth() * 1.5 )
                    tooltip.css( 'max-width', $( window ).width() / 2 );
                else
                    tooltip.css( 'max-width', 300 );
     
                var pos_left = target.offset().left + ( target.outerWidth() / 2 ) - ( tooltip.outerWidth() / 2 ),
                    pos_top  = target.offset().top - tooltip.outerHeight() - 20;
     
                if( pos_left < 0 )
                {
                    pos_left = target.offset().left + target.outerWidth() / 2 - 20;
                    tooltip.addClass( 'left' );
                }
                else
                    tooltip.removeClass( 'left' );
     
                if( pos_left + tooltip.outerWidth() > $( window ).width() )
                {
                    pos_left = target.offset().left - tooltip.outerWidth() + target.outerWidth() / 2 + 20;
                    tooltip.addClass( 'right' );
                }
                else
                    tooltip.removeClass( 'right' );
     
                if( pos_top < 0 )
                {
                    var pos_top  = target.offset().top + target.outerHeight();
                    tooltip.addClass( 'top' );
                }
                else
                    tooltip.removeClass( 'top' );
     
                tooltip.css( { left: pos_left, top: pos_top } )
                       .animate( { top: '+=10', opacity: 1 }, 50 );
            };
     
            init_tooltip();
            $( window ).resize( init_tooltip );
     
            var remove_tooltip = function()
            {
                tooltip.animate( { top: '-=10', opacity: 0 }, 50, function()
                {
                    $( this ).remove();
                });
     
                target.attr( 'title', tip );
            };
     
            target.bind( 'mouseleave', remove_tooltip );
            tooltip.bind( 'click', remove_tooltip );
        });


}
function acceptQuote() {
    $('.selectAction').on('change', function() {
        
            var acceptQuote = $(this).find('option:selected').text();
            if (acceptQuote === 'Accept Quote') {
                
                    $('.screeneroverlay').fadeIn(800);
                    $('.modal-wrap').fadeIn(800);
                }
            });
        $('#quoteAcceptBtn, #quoteAcceptSaveBtn, #quoteAcceptCancelBtn').on('click', function () {
            $('.screeneroverlay, .modal-wrap').fadeOut();
        });


}

//PAGE REDIRECT AFTER QUOTE SUMBITTED
function loaderPageRedirect() {

    setTimeout(function() {
        window.location.href = 'viewquotes.html';
    }, 3000);
}

$(document).ready(function() { 

CustomSelect.init();

accordion_module.init();
HeaderNav.init();
acceptQuote();
SlideNav.init();
toolTip();
/* {
            sortList: [ [0, 0]],
            widgets: [ 'zebra' ]
        } */
// CLICK EVENTS FOR TABS
$('.tabs .tab-links a').on('click', function(e)  {
        var currentAttrValue = $(this).attr('href');
 
        // Show/Hide Tabs
        $('.tabs ' + currentAttrValue).show().siblings().hide();
        //$('.tabs ' + currentAttrValue).show().siblings().hide().append('<span class="addTickMark"></span>');
 
        // Change/remove current tab to active
        $(this).parent('li').addClass('active').siblings().removeClass('active');
        
        if (winWidth < tablet) {
           $('.tab-links > .active').prev('li').find('a').addClass('completeStep');
           $('.tab-links > .active').prev('li').find('span').removeClass('addTickMark');
           
        } else {
            $('.tab-links > .active').prev('li').find('span').addClass('addTickMark');
            $('.tab-links > .active').prev('li').find('a').removeClass('completeStep');
        }

        e.preventDefault();
    });


// CLICK EVENTS FOR CHECKBOXES
$("<div class='special-checkbox'></div>").insertAfter(".catOptions");
$("<div class='special-ratecheckbox'></div>").insertAfter(".rateCheckBox");
$("<div class='special-subcheckbox'></div>").insertAfter(".subcatOptions");

$("body").on("click",".special-checkbox",function(){
    $(this).toggleClass("activated-checkbox");
    if ($(this).hasClass('activated-checkbox')) {
        $(this).parent().find(".categoryContainer").slideDown(150);
        $('.subCategoryWrapper').show();
    } 
        else {
         $(this).parent().find(".categoryContainer").slideUp(150);
         $('.subCategoryWrapper').hide();
    }
        
});

$("body").on("click",".special-subcheckbox",function(){
    $(this).toggleClass("activated-checkbox");
    if ($(this).hasClass('activated-checkbox')) {
        $(this).parent().find(".subCategory, .subCategoryWrapper").slideDown(150);
    } 
        else {
        $(this).parent().find(".subCategory, .subCategoryWrapper").slideUp(150);
    }
        
});

$("body").on("click",".special-ratecheckbox",function(){
    $(this).toggleClass("activated-checkbox");
    $(this).parent().addClass('allCategoriesSelect');
    
    if ($(this).parent().hasClass('allCategoriesSelect')) {
        $(this).closest('tr').next().remove();

        $('.categoryColumn').hide();
    }
        
});

// CLICK EVENTS FOR SCREENOVERLAY AND MODAL POPUP
 $('#duplicateBtn').on('click', function () {
                        $('.screeneroverlay, .modal-wrap').fadeOut();
                        var catOne = $('.categoryListItem').html();
                        $(catOne).append('#tab2');
                    });

 $('#saveCatBtn').on('click', function(){
    $('.screeneroverlay').fadeIn(800);
    $('.modal-wrap').fadeIn(800);

 });

$('.modal-close-btn').on('click', function(e) {
            e.preventDefault();
            
            $('.screeneroverlay').fadeOut(800);
            $('.modal-wrap').fadeOut(800);
        });
$('.clearVal').on('click', function(e) {
    e.preventDefault();
    $('#uploadFile').val('');

});



// UPLOAD BUTTON GET VALUE
if ($('#page').hasClass('fileUpload')) {
    document.getElementById("uploadBtn").onchange = function () {
        document.getElementById("uploadFile").value = this.value;
    };  
}



//ADD MEMEBER TABLE FADE IN
$('#addMemberBtn').on('click', function(e){
    e.preventDefault();
    $('#addMember').fadeIn(800);
    setTimeout(function(){

        CustomSelect.init();
    }, 1000);

});

$('#uploadDetails').on('click', function(e){
    e.preventDefault();
    $('#memberDetailTable').fadeIn(800);

});
//SUBMIT MEMEBER DETAILS FORM CLICK EVENT
$('.submitDetails').on('click', function(e){
    e.preventDefault();

    $('#addMember').fadeIn(800);
    //$('#viewMoreQuotes').fadeIn(800);

});

//NEXT BUTTON CLICK EVENT
$('#nextBtn').on('click', function(e) {
    e.preventDefault();
    $('.tab-links > .active').next('li').find('a').trigger('click');
    $('#backBtn').show().css('display', 'inline-block');
    if($('#tab4').is(':visible')){
        $('#nextBtn').hide();
        $('#submitQuoteBtn').show().css('display', 'inline-block');
    }
    $('html, body').animate({scrollTop: $('.saveQuoteTopBtn').offset().top}, 800);
        return false;
});
$('#viewQuotesNext').on('click', function(e) {
    e.preventDefault();
    $('.tab-links > .active').next('li').find('a').trigger('click');
    if($('#tab6').is(':visible')){
        $('#viewQuotesNext').hide();
    }
    $('html, body').animate({scrollTop: $('#quoteViewContainer').offset().top}, 800);
        return false;
});
//BACK BUTTON CLICK EVENT
$('#backBtn').on('click', function(e) {
    e.preventDefault();
    $('.tab-links > .active').prev('li').find('a').trigger('click');
    if($('#tab1').is(':visible') || $('#tab3').is(':visible')){
        $('#backBtn').hide();
    }
    if($('#tab3').is(':visible')) {
        $('#submitQuoteBtn').hide();
        $('#nextBtn').show();
        $('#backBtn').show();
    }

    //REMOVE TICK IF ACTIVE
    if ($('.tab-links li').hasClass('active')) {
       $('.tab-links .active').find('.addTickMark').removeClass('addTickMark');

    }
     $('html, body').animate({scrollTop: $('.saveQuoteTopBtn').offset().top}, 800);
        return false;
});
// SUBMIT QUOTE CLICK EVENT
    $('#submitQuoteBtn').on('click', function(e) {
        e.preventDefault();
        $('#addQuote, #btnControls').hide();
        $('#loaderWrapper').show();
        loaderPageRedirect();
    });

    $('.processBtn').on('click', function(e) {
            e.preventDefault();
            $('.screeneroverlay').fadeIn(800);
            $('.modal-wrap').fadeIn(800);
             setTimeout(function(){

                CustomSelect.init();
            }, 1000);
         $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
        });

});

$(window).resize(function () { 

    var winWidth = $(window).width();
    var tablet = 1150; 
    if (winWidth > tablet) {
        CustomSelect.init();
        SlideNav.closeItNoAnim();
    }

});