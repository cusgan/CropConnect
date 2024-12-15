// import * as main from './main.js';
// $(function() {
//     apicall("/api/profile","GET",{id:1},(response)=>{
//         console.log(response);
//     }).catch(error=>{
//         console.log(error);
//         if(error.response.data.title)
//             alert(error.message + "\n" + error.response.data.title);
//         else
//             alert(error.message + "\n" + error.response.data);
//     });
// });
const config = {
    headers: {
        'Content-Type': 'application/json',  // Adjust if needed
        // Add other headers like 'Authorization' if necessary
    }
};
const headers= {
    'Content-Type': 'application/json',  // Adjust if needed
    // Add other headers like 'Authorization' if necessary
}
$(function(){
    var user = getUser(getCookie("userId"));
});
async function getUser(userId){
    try {
        const response = await axios({
            method: "GET",      // HTTP method (GET, POST, etc.)
            url: domain + `/api/profile/${userId}/profile`,      // API endpoint
            data: {},        // Data for POST/PUT requests
            headers: {
                'Content-Type': 'application/json',  // Adjust if needed
                // Add other headers like 'Authorization' if necessary
            }
        });
        console.log(response.data);
        setUserDisplay(response.data);
        return response.data;  // Return the parsed JSON response
    } catch (error) {
        console.error("Error:", error.message);
        throw error;           // Throw the error to handle it outside the function
    }
}
function setUserDisplay(data){
    // const eprofilePicture = ($(".profile_picture"));
    // eprofilePicture[0].src = data.profilePicture;
    // ($(".biography")).forEach(element => {
    //     element.src = data.bio;
    // });
    $("#biography").html(data.bio);
    $("#work_experience").html(data.workExperience);
    $("#username").html(data.name);
    $("#profile_picture").attr("src",("data:image/jpeg;base64,"+data.profilePicture));
}

