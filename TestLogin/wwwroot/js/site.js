// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#submit").click(function (e) {
    e.preventDefault();
    var url = "Users/Index";
    $.ajax({
        url: url,
        method:"POST",
        success: function (result) {
            alert(result);
            $('#error').html(result);
        },
        error: function () {
            alert("Error occured");
        }
    });
})
//document.getElementById("submit").addEventListener("click", submit);
//function Http() {
//    this.http = new XMLHttpRequest();
//}
//let http = new Http();

//Http.prototype.post=function(url, data) {
//    return new Promise((resolve, reject) => {
//        this.http.open("POST", url, true);
//        //this.http.setRequestHeader(
//        //  "Content-type",
//        //  "application/x-www-form-urlencoded"
//         );
//        this.http.setRequestHeader("Content-type", "application/json");
//        let self = this;
//        this.http.onload = () => {
//            if (self.http.status === 200) {
//                resolve(self.http.responseText);
//            } else {
//                reject("Error: " + self.http.status);
//            }
//        };
//        this.http.onerror = () => {
//            reject("Network Error");
//        };
//        this.http.send(JSON.stringify(data));
//         //this.http.send(data);
//    });
//}
//function submit(e) {
//    const error = document.getElementById("error");
//    const login = document.getElementById("input-login").value;
//    const password = document.getElementById("input-password").value;
//    if (validateLogin(login) && validatePass(password)) {
//        //const data ="userName") + "=" + encodeURIComponent(login) + "&" + encodeURIComponent("password") + "=" + encodeURIComponent(password);
//        const data = JSON.parse({ userName: login, password: password });
//        http.post("Index", data).then(res => { error.innerHTML = res.html });

//    }
//    else {
//        e.preventDefault();
//    }
//}
function validateLogin(login) {
    let reg = /[a-z]/;
    if (reg.test(login)) return true;
    else return false;
}
function validatePass(pass) {
    return true;
    //let reg = /{8-16}/;
    //if (reg.test(pass)) return true;
    //else return false;
}