var $ = jQuery.noConflict();

jQuery(document).ready(function($){

/*==========================*/ 
/* sliders */ 
/*==========================*/
if($('._hero_slider').length > 0){
jQuery('._hero_slider').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  dots: true,
  arrows: false, 
  autoplay: true,
  autoplaySpeed: 3000,
  speed: 500,
  infinite: true, 
  centerMode: false, 
  fade: true,
  responsive: [
    {
      breakpoint: 767,
      settings: {
        arrows: false,
      }
    }
  ]
   
});
}

 if($('.testimonial_slider').length > 0){
jQuery('.testimonial_slider').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  dots: false,
  arrows: false, 
  autoplay: true,
  autoplaySpeed: 3000,
  speed: 500,
  infinite: true, 
  centerMode: false, 
  fade: false,
  responsive: [
    {
      breakpoint: 767,
      settings: {
        arrows: false,
      }
    }
  ]
   
});
}
 if($('.review_slider').length > 0){
jQuery('.review_slider').slick({
  slidesToShow: 3,
  slidesToScroll: 1,
  dots: false,
  arrows: true, 
  // autoplay: true,
  autoplaySpeed: 3000,
  speed: 500,
  infinite: true, 
  centerMode: false, 
  fade: false,
  responsive: [
    {
      breakpoint: 767,
      settings: {
        arrows: false,
        dots: true,
      }
    }
  ]
   
});
}

/*==========================*/  
/* Mobile Slider */  
/*==========================*/ 
if($('.mobile-slider').length > 0){
jQuery('.mobile-slider').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  dots: true,
  arrows: false, 
  infinite: true, 
  centerMode: false, 
  responsive: [
    {
      breakpoint: 5000,
      settings: "unslick"
    },
    {
      breakpoint: 768,
      settings: {
        arrows: false,
        slidesToShow: 1,
        slidesToScroll: 1,
        dots: true,  
        adaptiveHeight: false
      }
    }
  ]
});
}
 

/*==========================*/  
/* Scroll on animate */  
/*==========================*/
function onScrollInit( items, trigger ) {
  items.each( function() {
    var osElement = $(this),
        osAnimationClass = osElement.attr('data-os-animation'),
        osAnimationDelay = osElement.attr('data-os-animation-delay');
        osElement.css({
          '-webkit-animation-delay':  osAnimationDelay,
          '-moz-animation-delay':     osAnimationDelay,
          'animation-delay':          osAnimationDelay
        });
        var osTrigger = ( trigger ) ? trigger : osElement;
        osTrigger.waypoint(function() {
          osElement.addClass('animated').addClass(osAnimationClass);
          },{
              triggerOnce: true,
              offset: '95%',
        });
// osElement.removeClass('fadeInUp');
  });
}
onScrollInit( $('.os-animation') );
onScrollInit( $('.staggered-animation'), $('.staggered-animation-container'));


/*==========================*/
/* Header fix */
/*==========================*/
var scroll = $(window).scrollTop();
if (scroll >= 10) {
    $("body").addClass("fixed");
} else {
    $("body").removeClass("fixed");
}


});


$(window).scroll(function() {
    var scroll = $(window).scrollTop();
    if (scroll >= 10) {
        $("body").addClass("fixed");
    } else {
        $("body").removeClass("fixed");
    }
});


 window.onscroll = function() {scrollFunction()};

        function scrollFunction() {
            if (document.body.scrollTop > 200 || document.documentElement.scrollTop > 200) {
                document.getElementById("myBtn").style.display = "block";
            } else {
                document.getElementById("myBtn").style.display = "none";
            }
           
        }

        // When the user clicks on the button, scroll to the top of the document
        function topFunction() {
             $('html, body').animate({scrollTop:0}, 'slow');
        }
