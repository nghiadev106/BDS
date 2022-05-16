'use strict';
//--------------------- slider function -------------------------//  
$('#nivoparrallax').nivoSlider({
    slices: 15,
    boxCols: 8,
    boxRows: 4,
    startSlide: 0,
    controlNavThumbs: false,
    pauseOnHover: true,
    manualAdvance: false,
    effect: 'fade',
    animSpeed: 500,
    pauseTime: 30000,
    controlNav: 1,
    directionNav: 1,
});
//--------------------- / slider function -------------------------//
/* featured product ******************/
$('.featured-product,.new-product,.related-product').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 2,
            margin: 17
        }
        , 768: {
            items: 3
        }
        , 992: {
            items: 4
        }
        , 1200: {
            items: 4
        }
    }
    , margin: 29, //padding: 10 
});

/***************** related left column product ******************/
$('.related-product2').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 2,
            margin: 17
        }
        , 768: {
            items: 2,
            margin: 17
        }
        , 992: {
            items: 3
        }
        , 1200: {
            items: 3
        }
    }
    , margin: 29, //padding: 10 
});
/* del product product ******************/
$('.deal-slide').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 1
        }
        , 768: {
            items: 1,
            margin: 0
        }
        , 992: {
            items: 2,
            margin: 10
        }
        , 1200: {
            items: 2
        }
    }
    , margin: 30, //padding: 10 
});
/**********latest  blog slider ******************/
$('.latest-blog-slide').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 1
        }
        , 768: {
            items: 1
        }
        , 992: {
            items: 2,
            margin: 20
        }
        , 1200: {
            items: 2
        }
    }
    , margin: 30, //padding: 10 
});
// Countdown Start
if ($().countdown) {
    var austDay = new Date();
    austDay = new Date(austDay.getFullYear() + 1, 1 - 1, 26);
    $('.countbox').countdown({until: austDay});
}
// Countdown End 
/****************brand slider ******************/
$('#brand-logo').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 2,
            margin: 10
        }
        , 480: {
            items: 4,
            margin: 10
        }
        , 768: {
            items: 5
        }
        , 992: {
            items: 6
        }
        , 1200: {
            items: 6
        }
    }
    , margin: 30, //padding: 10 
});
/****************tab mini product slider ******************/
$('.mini-products-slide').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 2,
            margin: 15
        }
        , 768: {
            items: 2
        }
        , 992: {
            items: 3,
            margin: 15

        }
        , 1200: {
            items: 4
        }
    }
    , margin: 30, //padding: 10 
});
/****************featured product slider ******************/
$('.featured-product2').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 2,
            margin: 17
        }
        , 768: {
            items: 2,
            margin: 17
        }
        , 992: {
            items: 3
        }
        , 1200: {
            items: 4
        }
    }
    , margin: 29, //padding: 10 
});
/****************featured product slider ******************/
$('.new-product2').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 2,
            margin: 16
        }
        , 768: {
            items: 2,
            margin: 17
        }
        , 992: {
            items: 3
        }
        , 1200: {
            items: 3
        }
    }
    , margin: 29, //padding: 10 
});
/****************featured product slider ******************/
$('.testimonial').owlCarousel({
    autoplay: true,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 1
        }
        , 768: {
            items: 1
        }
        , 992: {
            items: 1
        }
        , 1200: {
            items: 1
        }
    }
    //padding: 10 
});
/****************onstore product slider ******************/
$('.onstore-product-slide,.bestsale-product').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    loop: true,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 2,
            margin: 16
        }
        , 768: {
            items: 1
        }
        , 992: {
            items: 1

        }
        , 1200: {
            items: 1
        }
    }
    // , padding: 2,
});
//about team Carousel
$('.our-team-inner').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        }
        , 480: {
            items: 2
        }
        , 768: {
            items: 3
        }
        , 992: {
            items: 4
        }
        , 1200: {
            items: 5
        }
    }
    , margin: 29 //padding: 10 
});
//end about team Carousel   
/* ***************** page scroll bottom to top *****************/
$(window).scroll(function() {
    if ($(this).scrollTop() > 100) {
        $('#top-buttom').fadeIn();
    } else {
        $('#top-buttom').fadeOut();
    }
});
//Click event to scroll to top
$('#top-buttom').click(function() {
    $('html, body').animate({scrollTop: 0}, 800);
    return false;
});
/**************** could zoome and light box ******************/
if (window.matchMedia('(min-width: 992px)').matches) {
    /* light box */
    $('.mini-hover a,.quickview').magnificPopup({
        type: 'iframe'
    });
    jQuery("#zoom_image").elevateZoom({
        cursor: 'crosshair',
        borderColour: "#e4dddd",
        zoomType: "window",
        lensShape: "round",
        lensSize: 200,
        lensOpacity: 0,
        gallery: 'more',
        galleryActiveClass: 'active',
        imageCrossfade: true,
        easing: false,
        loadingIcon: "assets/image/loader.gif"
    });
}
;
/* light box */
$('.colorbox').magnificPopup({
    type: 'image',
    delegate: 'a',
    gallery: {
        enabled: true
    }
});
/* thamvanil products */
// start brand logo functin
$('#more').owlCarousel({
    autoplay: false,
    autoplaySpeed: 600,
    nav: true,
    dots: false,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 3
        }
        , 480: {
            items: 4
        }
        , 768: {
            items: 4
        }
        , 992: {
            items: 3
        }
        , 1200: {
            items: 3
        }
    }
    , margin: 7 //padding: 10 
});
/************* list view grid view **************/
$("#listview").click(function() {
    $("#products-grid").fadeOut("slow");
    $("#products-list").fadeIn("slow");
    $('#listview').addClass('active');
    $('#gridview').removeClass('active');
});
$("#gridview").click(function() {
    $("#products-grid").fadeIn("3000");
    $("#products-list").fadeOut("slow");
    $('#gridview').addClass('active');
    $('#listview').removeClass('active');
});

/*************** mobile menu *****************/
$('.toggle-icon').click(function(e) {
    $(".mobile-main-menu").slideToggle();
    return false;
});
$('.clicksearch').click(function(e) {
    $(".header-search").slideToggle();
});
$('.clickshipping').click(function(e) {
    $(".slider-shipping-msg").slideToggle();
});
//end about team Carousel    
