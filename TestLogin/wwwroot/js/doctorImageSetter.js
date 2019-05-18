let doctorContainer = document.getElementById("doctor-container");

console.log(doctorContainer);
loadImages();
function loadImages() {
  console.log(doctorContainer.children);
  for (let i = 0; i < doctorContainer.children.length; i++) {
    // console.log(doctorContainer.children[i]);
    let form = doctorContainer.children[i].children[0];
    let employeeId = form.children[0].getAttribute("value");
    form.children[1].setAttribute(
      "src",
      "../images/doctors/" + employeeId + ".jpg"
    );
    console.log(form.children[1]);
  }
}
