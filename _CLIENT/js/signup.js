import * as main from './main.js';
$("#btnSignUp").on("click", function() {
    var email = $("#email").val();
    var password = $("#password").val();
    var name = $("#name").val();
    var birthdate = $("#default-datepicker").val();
    console.log(email+" "+password+" "+name+" "+birthdate);
    const formData = new FormData();
    formData.append("email", email);
    formData.append("password", password); 
    formData.append("name", name); 
    formData.append("birthdate", birthdate); 
    apicall("/api/accounts/register","POST",formData)
    .then(response => {
        console.log(response);
        alert("success");
        window.location.href = "login.html";
    }).catch(error=>{
        console.log(error);
        if(error.response.data.title)
            alert(error.message + "\n" + error.response.data.title);
        else
            alert(error.message + "\n" + error.response.data);
    });
});





