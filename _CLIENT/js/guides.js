import * as main from './main.js';
$(function() {
    apicall("/api/guides","GET",{})
    .then(response => {
        console.log(response);
    }).catch(error=>{
        alert(error.message + "\n" + error.response.data.title);
    });
});