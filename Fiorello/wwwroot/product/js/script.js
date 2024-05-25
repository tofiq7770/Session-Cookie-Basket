(function($) {
  // $(function() {
  //   $('nav ul li > a:not(:only-child)').click(function(e) {
  //     $(this).siblings('.nav-dropdown').toggle();
  //     $('.nav-dropdown').not($(this).siblings()).hide();

  //     e.stopPropagation();
  //   });
  // });

  const ul = document.querySelector('nav ul');
  const mobileNav = document.querySelector('.mobile-nav');

   document.querySelector('#nav-toggle').addEventListener('click', function() {
     this.classList.toggle('active');
     if(document.querySelector('#nav-toggle').classList.contains('active')){
       ul.style.display = 'none'
       mobileNav.classList.remove('d-none')

     }else{
       if(window.innerWidth > 760){

         ul.style.display = 'flex'
       }
      mobileNav.classList.add('d-none')
     }
   });

  // $('#nav-toggle').click(function() {
  //   $('nav ul').toggle();
  //   $('.nav-dropdown').hide();

  // });

})(jQuery);


$(".fa-search").click(function(){
$(".icon").toggleClass("active");
$("input[type='text']").toggleClass("active");
});

let responsive = ' ';
  const ul = document.querySelector('nav ul');
  const logo = document.querySelector('.brand img');

window.onresize = function(){

  if(window.innerWidth < 992){
    responsive = 'mobile';
    ul.style.display = 'none'
    logo.style.height = '18px'
    logo.style.width = '120px'
  }else if(window.innerWidth > 992 && window.innerWidth < 1200){
    responsive = 'tablet'
    ul.style.display = 'none'
    logo.style.height = '18px'
    logo.style.width = '120px'
  }else if( window.innerWidth > 1201){
    responsive = 'desktop'
    ul.style.display = 'flex'
    logo.style.height = '25px'
    logo.style.width = '205px'
  }else{
    responsive = 'large'
    ul.style.display = 'flex'
  }
}


// sekilleri filter verib secir-----------------------------------------------------------------------------------------

const grid = $('.grid').isotope({
  // options
  itemSelector: '.grid-item',
  layoutMode: 'fitRows'
});

$(document).ready(function(){
  $('.list').click(function(){
    const value = $(this).attr('data-filter');
    if(value=='All'){
      $('.itemBox').show('1000'); 
    }
    else{
      console.log($('.itemBox'));
      $('.itemBox').not('.' + value).hide('1000');
      $('.itemBox').filter('.' + value).show('1000');
    }
    $('.list').click(function(){
      $(this).addClass('active').siblings().removeClass('active')
    })

  })
})



