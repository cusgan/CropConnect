
var nameElem = $("#name");
var bioElem = $("#bio");
var workElem = $("#work_experience");
var user = null;

$(function () {
    nameElem = $("#name");
    bioElem = $("#bio");
    workElem = $("#work_experience");
    getUser(getCookie("userId"));
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
        user = response.data;
        console.log(response.data);
        nameElem.val(response.data.name);
        bioElem.html(response.data.bio);
        workElem.val(response.data.workExperience);
        return response.data;  // Return the parsed JSON response
    } catch (error) {
        console.error("Error:", error.message);
        throw error;           // Throw the error to handle it outside the function
    }
}

async function updateUser(){
    user.name = nameElem.val();
    user.bio = bioElem.val();
    user.workExperience = workElem.val();
    console.log(user);
    try {
        const response = await axios({
            method: "PUT",      // HTTP method (GET, POST, etc.)
            url: domain + `/api/profile/edit/${user.Id}`,      // API endpoint
            data: objectToFormData(user),        // Data for POST/PUT requests
            headers: {
                'Content-Type': 'multipart/form-data',  // Adjust if needed
                // Add other headers like 'Authorization' if necessary
            }
        });
        console.log(response);
        window.history.back();
        return response; 
    } catch (error) {
        console.log(error);
        if(error.response.data.title)
            alert(error.message + "\n" + error.response.data.title);
        else
            alert(error.message + "\n" + error.response.data);     
    }
}
$(document).on("click", "#btnSave", function() {
    updateUser();
});
function objectToFormData(obj) {
    const formData = new FormData();
    // formData.append("account", user.account);
    formData.append("accountId", user.accountId); 
    formData.append("bio", user.bio); 
    formData.append("birthDate", user.birthDate); 
    formData.append("id", user.id); 
    formData.append("name", user.name); 
    // formData.append("profilePicture", user.profilePicture); 
    formData.append("workExperience", user.workExperience); 
    return formData;
}


