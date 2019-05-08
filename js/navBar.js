// const nav = document.getElementsByTagName("nav");
const nav = document.getElementById("navBar");
const navText = Array.from(document.getElementsByClassName("nav-text"));

nav.addEventListener("mouseover", function(e) {
  nav.style.width = "15%";
  navText.forEach(element => {
    element.style.transform = "translateX(0)";
  });
  //   navText[0].style.display = "flex";
});
nav.addEventListener("mouseout", function() {
  nav.style.width = "5%";
  navText.forEach(element => {
    element.style.transform = "translateX(0)";
  });
  //   navText[0].style.display = "none";
});
