const email = document.getElementById("email");
const fName = document.getElementById("first-name");
const sName = document.getElementById("second-name");
const mName = document.getElementById("middle-name");
const password = document.getElementById("password");
const passwordRepeat = document.getElementById("second-password");
const gender = document.getElementById("gender");
const adress = document.getElementById("adress");
const dateOfBirth = document.getElementById("date-of-birth");
const phone = document.getElementById("phone");
const identifical = document.getElementById("ident-code");
const employeeId = document.getElementById("EmployeeId");

const successForm = document.getElementById("success-form");
const okButton = document.getElementById("submit-declaration");

let today = new Date().toISOString().substr(0, 10);

const error = document.getElementById("error");

//all regular expressions for validation
const regLog = /^[a-zA-Z0-9]{3,16}$/i;
const regEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
const regPass = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!/^_*]+$/;
const regName = /^[а-яі-ї]{3,16}$/i;
const regPhone = /^\+?([3])\)?([8])\)?([0])\)?([0-9]{9})$/;
const regIdent = /^\d{10}$/;

dateOfBirth.setAttribute("max", today); //setting max date as today

//calling validate function to send ajax if everything is filled
document.getElementById("register-btn").addEventListener("click", function(e) {
  e.preventDefault();
  validate();
});
//onclick event which calls when everyting is correctly filled
okButton.addEventListener("click", function() {
  window.location = "/";
});

//function for fields validation
function showError() {
  error.innerText = "";
  error.style.display = "flex";
  if (
    !regName.test(fName.value) ||
    !regName.test(sName.value) ||
    !regName.test(mName.value)
  ) {
    error.innerText += "Ім'я, прізвище або по-батькові введені не правильно";
    return false;
  }
  if (!regPhone.test(phone.value)) {
    error.innerText += "Введіть номер телефону у форматі +380XXXXXXXXX";
    return false;
  }
  if (password.value === passwordRepeat.value) {
    if (!regPass.test(password.value)) {
      error.innerText +=
        "Пароль має містити числа, літери верхнього та нижнього \n" +
        "регістру та входити в проміжок від 8 до 16 символів";
      return false;
    }
  } else {
    error.innerText += "Паролі не збігаються";
    return false;
  }
  if (gender.value === "not-chosen") {
    error.innerText += "Стать не вибрана";
    return false;
  }
  if (adress.value === "") {
    error.innerText += "Заповніть поле адреси";
    return false;
  }
  if (!regIdent.test(identifical.value)) {
    error.innerText += "Ідентифікаційний код має складатися з 10 чисел";
    return false;
  }
  if (!regEmail.test(email.value)) {
    error.innerText += "Електронна пошта введена не правильно";
    return false;
  }
  if (dateOfBirth.value === "") {
    error.innerText += "Дата народження не вибрана";
    return false;
  }

  error.style.display = "none";
  return true;
}

function validate() {
  if (showError()) {
    const data = {
      Password: password.value,
      declaration: {
        patient: {
          FirstName: fName.value,
          MiddleName: mName.value,
          LastName: sName.value,
          Phone: phone.value,
          Email: email.value,
          Address: adress.value,
          Gender: gender.value,
          BirthDate: dateOfBirth.value,
          TaxID: identifical.value
        },
        CreateDate: today,
        msp: {},
        employee: {
          EmployeeId: employeeId.value
        }
      }
    };
    sendData(data); //calling ajax
  }
}
function sendData(data) {
  let http = new Http();
  http
    .post("CreateDeclaration1", data)
    .then(res => {
      console.log(res);
      if (JSON.parse(res).value === "ok") {
        successForm.style.display = "flex"; //showing hidden form which tells that validation is successful
      }
      // error.innerHTML = res;
    })
    .catch(error => {
      alert("Suka ne rabotaet blyat nahoy");
    });
}
