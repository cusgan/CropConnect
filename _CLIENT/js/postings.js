import * as main from './main.js';
$(function() {
    apicall("/api/postings","GET",{})
    .then(response => {
        console.log(response);
    }).catch(error=>{
        console.log(error);
        alert(error.message + "\n" + error.response.data);
    });
});