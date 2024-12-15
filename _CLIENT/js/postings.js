import * as main from './main.js';
var postingsList;
$(function() {
    apicall("/api/postings","GET",{})
    .then(response => {
        postingsList = response;
        console.log(response);
        displayPostings();
    }).catch(error=>{
        console.log(error);
        alert(error.message + "\n" + error.response.data);
    });
});

function displayPostings(){
    fetch('../webcomponents/posting.html')
    .then(response => response.text())
    .then(html => {
        // Create a temporary DOM to parse the HTML
        const template = document.createElement('template');
        template.innerHTML = html;
        // console.log(html);
        // Clone the content of the template into the shadow DOM
        const content = template.content.querySelector('#posting-template').innerHTML;
        // console.log(content);
        // this.append(content);
        var postingsContainer1 = $("#posting-container-1");
        var postingsContainer2 = $("#posting-container-2");
        var postingsContainer3 = $("#posting-container-3");
        var res = "";
        postingsList.forEach(element => {
            console.log(element.productName);
            res += 
            "<div class=\"block mr-[10px]\">" +
                content.replaceAll(
                    "{%TITLE%}",element.productName
                ).replaceAll(
                    "{%SUBTITLE%}",element.additionalInfo
                ).replaceAll(
                    "{%IMAGE%}","data:image/jpeg;base64,"+element.productImage,) + 
            "</div>";
        });
        postingsContainer1.html(res);
        postingsContainer2.html(res);
        postingsContainer3.html(res);
    })
    .catch(error => console.error('Error loading navbar template:', error));
}
