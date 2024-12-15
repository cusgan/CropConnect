import * as main from './main.js';
var postingsList;

$(document).on("click", "#btnSearch", function() {
    search();
});


function search() {
    const formData = new FormData();
    var query = $("#simple-search").val();
    $.ajax({
        url: domain+`/api/guides/query?query=`+query,
        method: "GET",
        contentType: false, // Tells jQuery not to set Content-Type (it will be set to multipart/form-data automatically)
        processData: false, // Tells jQuery not to process the data
        headers: {
            // You can add any headers like 'Authorization' if needed
            // 'Authorization': 'Bearer ' + localStorage.getItem('auth_token')
        },
        success: function (response) {
            console.log(response);
            postingsList = response;
            displayPostingsD();
        },
        error: function (xhr, status, error) {
            console.log("Error:", xhr.responseText);
            alert("Error: " + xhr.responseText);
        }
    });
};  

function displayPostingsD(){
    fetch('../webcomponents/guidepost.html')
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
        var res1 = "";
        var res2 = "";
        var ctr = 0;
        postingsList.forEach(element => {
            console.log(element.productName);
            var temp = 
            "<div class=\"block mr-[10px]\">" +
                content.replaceAll(
                    "{%TITLE%}",element.title
                ).replaceAll(
                    "{%SUBTITLE%}",element.author.email
                ).replaceAll(
                    "{%ID%}",element.id
                ).replaceAll(
                    "{%IMAGE%}","data:image/jpeg;base64,"+element.headingImage,) + 
            "</div>";
            if(ctr % 2 == 0){
                res1+=temp;
            } else {
                res2+=temp;
            }
            ctr += 1;
        });
        postingsContainer1.html(res1);
        postingsContainer2.html(res2);
    })
    .catch(error => console.error('Error loading navbar template:', error));
}
