let doctorContainer = document.getElementById("doctor-container");
let doctorSelect = document.getElementById("doctor-name-select");
let doctorChanger = document.getElementById("doctor-name-change");

doctorChanger.addEventListener("input", filter);

// console.log(doctorContainer);
loadImages();
fillDoctorSelect();
function loadImages() {
  // console.log(doctorContainer.children);
  for (let i = 0; i < doctorContainer.children.length; i++) {
    // console.log(doctorContainer.children[i]);
    let form = doctorContainer.children[i].children[0];
    let employeeId = form.children[0].getAttribute("value");
    form.children[1].setAttribute(
      "src",
      "../images/doctors/" + employeeId + ".jpg"
    );
    // console.log(form.children[1]);
  }
}
function fillDoctorSelect() {
  for (let i = 0; i < doctorContainer.children.length; i++) {
    let doctorName =
      doctorContainer.children[i].children[0].children[2].firstElementChild
        .innerText;
    console.log(doctorName);
    let newOption = document.createElement("option");
    // newOption.innerText = doctorName;
    newOption.setAttribute("value", doctorName);

    doctorSelect.appendChild(newOption);
  }
}

function filter() {
  for (let i = 0; i < doctorContainer.children.length; i++) {
    if (doctorChanger.value === "") {
      doctorContainer.children[i].style.display = "flex";
    } else {
      let doctorName = doctorContainer.children[
        i
      ].children[0].children[2].firstElementChild.innerText.toLowerCase();
      if (doctorName.includes(doctorChanger.value.toLowerCase())) {
        doctorContainer.children[i].style.display = "flex";
      } else doctorContainer.children[i].style.display = "none";
      console.log("Sdadsad".toLowerCase());
    }
  }
}
