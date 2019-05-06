const login = document.getElementById("login");
const password = document.getElementById("password");
const error = document.getElementById("error");

let countLog = /^[a-zA-Z0-9]{3,16}$/i;
// const countPass = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,16})/;
const countPass = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!/^_*]{8,16}$/;

document.getElementById("login-btn").addEventListener("click", function (e) {
    e.preventDefault();
    validate();
});

function showError() {
    error.innerText = "";
    error.style.display = "flex";
    if (!countLog.test(login.value)) {
        error.innerText +=
            "Логін введений невірно. Використвовуйте \nлише латинські літери" +
            " та числа.\n";
        return false;
    } else {
        error.style.display = "none";
        error.innerText = "";
    }
    if (!countPass.test(password.value)) {
        error.style.display = "flex";
        error.innerText +=
            "\nПароль введений невірно. Пароль має \n" +
            "містити латинські літери верхнього і\n" +
            "нижнього регістру та числа.";
        error.style.alignContent = "center";
        return false;
    }
    return true;
}

function validate() {
    if (showError()) {
        const data = { userName: login.value, password: password.value };
        let http = new Http();

        http.post("Users/Login", data).then(res => {
            if (res == "ok") {
                window.location = "Users/Create"
            }
            else {
                console.log(res);
                error.innerHTML = res;
                error.style.display = "flex";
            }
        }).catch(res => { console.log(res); });
    }
}
