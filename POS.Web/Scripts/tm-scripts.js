function include(scriptUrl) {
    
    document.write('<script src="' + scriptUrl + '"></script>');
}

/* Navbar
 ========================================================*/
;
(function ($) {
    
    include('../Scripts/jquery.rd-navbar.js');
})(jQuery);


//function isIE() {
//    var myNav = navigator.userAgent.toLowerCase();
//    return (myNav.indexOf('msie') != -1) ? parseInt(myNav.split('msie')[1]) : false;
//};

///* cookie.JS
// ========================================================*/
//include('../Scripts/jquery.cookie.js');

///* Easing library
// ========================================================*/
//include('../Scripts/jquery.easing.1.3.js');


///* Stick up menus
// ========================================================*/
//;
//(function ($) {
//    var o = $('html');
//    if (o.hasClass('desktop')) {
//        include('../Scripts/tmstickup.js');

//        $(document).ready(function () {
//            $('#stuck_container').TMStickUp({})
//        });
//    }
//})(jQuery);

/* ToTop
 ========================================================*/
//;
//(function ($) {
//    var o = $('html');
//    if (o.hasClass('desktop')) {
//        include('../Scripts/jquery.ui.totop.js');

//        $(document).ready(function () {
//            $().UItoTop({
//                easingType: 'easeOutQuart',
//                containerClass: 'toTop fa fa-angle-up'
//            });
//        });
//    }
//})(jQuery);

///* EqualHeights
// ========================================================*/
//;
//(function ($) {
//    var o = $('[data-equal-group]');
//    if (o.length > 0) {
//        include('../Scripts/jquery.equalheights.js');
//    }
//})(jQuery);



///* Copyright Year
// ========================================================*/
//;
//(function ($) {
//    var currentYear = (new Date).getFullYear();
//    $(document).ready(function () {
//        $("#copyright-year").text((new Date).getFullYear());
//    });
//})(jQuery);




////;
//(function ($) {
//    function include(url) {
//        document.write('<script src="../Scripts/' + url + '"></script>');
//	return false;
//}
//	include('superfish.js');
//	jQuery(function () {
//})
//})(jQuery);



///* Responsive Tabs
// ========================================================*/
//;
//(function ($) {
//    var o = $('.resp-tabs');
//    if (o.length > 0) {
//        include('../Scripts/jquery.responsive.tabs.js');

//        $(document).ready(function () {
//            o.easyResponsiveTabs();
//        });
//    }
//})(jQuery);







///* JQuery UI Accordion
// ========================================================*/
//;
//(function ($) {
//    var o = $('.accordion');
//    if (o.length > 0) {
//        include('../Scripts/jquery.ui.accordion.min.js');

//        $(document).ready(function () {
//            o.accordion({
//                active: false,
//                header: '.accordion_header',
//                heightStyle: 'content',
//                collapsible: true
//            });
//        });
//    }
//})(jQuery);




///* Google Map
// ========================================================*/
//;
//(function ($) {
//    var o = document.getElementById("google-map");
//    if (o) {
//        include('//maps.google.com/maps/api/js?sensor=false');
//        include('../Scripts/jquery.rd-google-map.js');

//        $(document).ready(function () {
//            var o = $('#google-map');
//            if (o.length > 0) {
//                o.googleMap({styles:[]});
//            }
//        });
//    }
//})
//(jQuery);

///* Owl Carousel
//========================================================*/
//;(function ($) {
//    var o = $('.owl-carousel');
//    if (o.length > 0) {
//        include('../Scripts/owl.carousel.min.js');
//        $(document).ready(function () {
//            o.owlCarousel({
//                margin: 30,
//                smartSpeed: 450,
//                loop: true,
//                dots: false,
//                dotsEach: 1,
//                nav: true,
//                navClass: ['owl-prev fa fa-angle-left', 'owl-next fa fa-angle-right'],
//                responsive: {
//                    0: { items: 1 },
//                    768: { items: 1},
//                    980: { items: 1}
//                }
//            });
//        });
//    }
//})(jQuery);


///* WOW
// ========================================================*/
//;
//(function ($) {
//    var o = $('html');

//    if ((navigator.userAgent.toLowerCase().indexOf('msie') == -1 ) || (isIE() && isIE() > 9)) {
//        if (o.hasClass('desktop')) {
//            include('../Scripts/wow.js');

//            $(document).ready(function () {
//                new WOW().init();
//            });
//        }
//    }
//})(jQuery);



///* Orientation tablet fix
// ========================================================*/
//$(function () {
//    // IPad/IPhone
//    var viewportmeta = document.querySelector && document.querySelector('meta[name="viewport"]'),
//        ua = navigator.userAgent,

//        gestureStart = function () {
//            viewportmeta.content = "width=device-width, minimum-scale=0.25, maximum-scale=1.6, initial-scale=1.0";
//        },

//        scaleFix = function () {
//            if (viewportmeta && /iPhone|iPad/.test(ua) && !/Opera Mini/.test(ua)) {
//                viewportmeta.content = "width=device-width, minimum-scale=1.0, maximum-scale=1.0";
//                document.addEventListener("gesturestart", gestureStart, false);
//            }
//        };

//    scaleFix();
//    // Menu Android
//    if (window.orientation != undefined) {
//        var regM = /ipod|ipad|iphone/gi,
//            result = ua.match(regM);
//        if (!result) {
//            $('.sf-menus li').each(function () {
//                if ($(">ul", this)[0]) {
//                    $(">a", this).toggle(
//                        function () {
//                            return false;
//                        },
//                        function () {
//                            window.location.href = $(this).attr("href");
//                        }
//                    );
//                }
//            })
//        }
//    }
//});
//var ua = navigator.userAgent.toLocaleLowerCase(),
//    regV = /ipod|ipad|iphone/gi,
//    result = ua.match(regV),
//    userScale = "";
//if (!result) {
//    userScale = ",user-scalable=0"
//}
//document.write('<meta name="viewport" content="width=device-width,initial-scale=1.0' + userScale + '">');

///* Camera
//========================================================*/
//;(function ($) {
//var o = $('#camera');
//    if (o.length > 0) {
//        if (!(isIE() && (isIE() > 9))) {
//            include('../Scripts/jquery.mobile.customized.min.js');
//        }

//        include('../Scripts/camera.js');

//        $(document).ready(function () {
//            o.camera({
//                autoAdvance: true,
//                height: '40.17094017094017%',
//                minHeight: '300px',
//                pagination: true,
//                thumbnails: false,
//                playPause: false,
//                hover: false,
//                loader: 'none',
//                navigation: false,
//                navigationHover: true,
//                mobileNavHover: false,
//                fx: 'simpleFade'
//            })
//        });
//    }
//})(jQuery);

///* Search.js
// ========================================================*/
//;
//(function ($) {
//    var o = $('.search-form');
//    if (o.length > 0) {
//        include('../Scripts/TMSearch.js');
//    }
//})(jQuery);  





///* Mailform
//=============================================*/
//;(function ($) {
//    include('../Scripts/mailform/jquery.form.min.js');
//    include('../Scripts/mailform/jquery.rd-mailform.min.js');
//})(jQuery); 








///* FancyBox
//========================================================*/
//;(function ($) {
//    var o = $('.thumb');
//    if (o.length > 0) {
//        include('../Scripts/jquery.fancybox.js');
//        include('../Scripts/jquery.fancybox-media.js');
//        include('../Scripts/jquery.fancybox-buttons.js');
//        $(document).ready(function () {
//            o.fancybox();
//        });
//    }
//})(jQuery);

///* Parallax
//=============================================*/
//;(function ($) {
//    include('../Scripts/jquery.rd-parallax.js');
//})(jQuery); 



