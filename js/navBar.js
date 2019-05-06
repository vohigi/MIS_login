// const nav = document.getElementsByTagName("nav");
const nav = document.getElementById("navBar");
const navText = Array.from(document.getElementsByClassName("nav-text"));

nav.addEventListener("mouseover", function(e) {
  navText.forEach(element => {
    element.classList.add("nav-text-open");
    // element.parentElement.classList.add("nav-link-open");
    // element.style.display = "flex";
    // element.style.justifyContent = "center";
    // element.style.alignItems = "center";
    // // element.style.transform = "translateX(0)";
    // element.style.animation = "nav-animation 0.5s forwards linear;";
  });
  nav.style.width = "15%";
  //   navText[0].style.display = "flex";
});
nav.addEventListener("mouseout", function() {
  navText.forEach(element => {
    element.classList.remove("nav-text-open");
    // element.parentElement.classList.remove("nav-link-open");
    // element.classList.add("nav-text-close");
    // element.style.transform = "translateX(-1000px)";
    // element.style.display = "none";
  });
  nav.style.width = "5%";
  //   navText[0].style.display = "none";
});
