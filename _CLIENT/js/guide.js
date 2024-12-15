$(function() {
    apicall("/api/guides/"+getCookie("currentViewId"),"GET",{})
    .then(response => {
        console.log(response);
        var guide=response;
        $("#title").html(guide.title);
        $("#postedOn").html("Uploaded "+convert(guide.datePosted));
        $("#updatedOn").html("Last Updated "+convert(guide.lastUpdated));
        $("#content").html(guide.content);
        // $("#headingImage").html("data:image/jpeg;base64,"+guide.headingImage);
        $("#headingImage").attr('src', "data:image/jpeg;base64,"+guide.headingImage);
        $("#authorName").html(guide.author.email);
        $("#workExperience").html("farma");
    }).catch(error=>{
        console.log(error);
        alert(error.message + "\n" + error.response.data);
    });
});

function convert(timestamp) {
    // parse the timestamp into a date object   
    const date = new Date(timestamp);

    // define options for the date format
    const options = { year: 'numeric', month: 'long', day: 'numeric' };

    // use toLocaleDateString to format the date
    return date.toLocaleDateString('en-US', options);
}


