function create_guide(){
    const formData = new FormData();
    formData.append("authorId", getCookie("userId"));
        formData.append("title", $("#inpt-guide-title").val());
        formData.append("content", $("#inpt-guide-cont").val());
        formData.append("HeadingImage", $("#inpt-cover-img")[0].files[0]);

    $.ajax({
        url: domain+`/api/guides/post`,
        method: "POST",
        data: formData,
        contentType: false, // Tells jQuery not to set Content-Type (it will be set to multipart/form-data automatically)
        processData: false, // Tells jQuery not to process the data
        headers: {
            // You can add any headers like 'Authorization' if needed
            // 'Authorization': 'Bearer ' + localStorage.getItem('auth_token')
        },
        success: function (response) {
            console.log(response);
            window.location.href = "browse.html";  // Redirect after success
        },
        error: function (xhr, status, error) {
            console.log("Error:", xhr.responseText);
            alert("Error: " + xhr.responseText);
        }
    });
};

$(document).on("click", "#btnCreateGuide", function() {
    create_guide();
});