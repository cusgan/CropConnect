import * as main from './main.js';
// $(function() {
//     alert(getCookie("userId"));
//     apicall("/api/guides","GET",{},(response)=>{
//         console.log(response);
//     });
// });
$("#btnLogin").on("click", function() {
    var email = $("#email").val();
    var password = $("#password").val();
    const formData = new FormData();
    formData.append("email", email);
    formData.append("password", password); 
    apicall("/api/accounts/login","POST",formData)
    .then(response => {
        console.log(response);
        setCookie("userId",response.userId);
        window.location.href = "browse.html";
    }).catch(error=>{
        console.log(error);
        if(error.response.data.title)
            alert(error.message + "\n" + error.response.data.title);
        else
            alert(error.message + "\n" + error.response.data);
    });
});





