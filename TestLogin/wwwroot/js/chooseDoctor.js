document.querySelector("#submit").addEventListener("click", e => {
    const data = {
        employee: document.querySelector("#Email").value
    };
    console.log(data);
    let http = new Http();
    http.post("CreateDeclaration", data);
});