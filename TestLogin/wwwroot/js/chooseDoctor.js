document.querySelector("#doctor-container").addEventListener("submit", e => {
    e.preventDefault();
    e.target.firstElementChild.setAttribute("name", "EmployeeId");
    e.target.submit();
});
//e.preventDefault();
//const data = {
//    EmployeeId: e.target.firstElementChild.value
//};
//console.log(data);
//let http = new Http();
//http.post("CreateDeclaration", data).then(res => { console.log(res); }).catch(err => { console.log(err); });