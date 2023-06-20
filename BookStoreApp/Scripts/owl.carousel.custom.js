$('.owl-carousel').owlCarousel({
    loop:true,
    margin:30,
    nav:true,
    loop:true,
    autoplay: true,
    autoplayTimeout: 2500,
    autoplayHoverPause: true,
    dots: false,
    nav: false,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:4
        }
    }
})