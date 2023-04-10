const themeToggle = document.querySelector('#theme-toggle');
const body = document.querySelector('body');

themeToggle.addEventListener('click', function() {
  body.classList.toggle('dark');
});
window.onscroll = function() {
    if (window.pageYOffset > 0) {
      document.querySelector('header').classList.add('sticky');
    } else {
      document.querySelector('header').classList.remove('sticky');
    }
  }