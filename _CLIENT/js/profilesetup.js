
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
async function updateUser3() {
    const formData = new FormData();
    formData.append("Name", nameElem.val());
    formData.append("Bio", bioElem.val());
    formData.append("WorkExperience", workElem.val());
    axios.put(domain+'/api/profile/edit/'+user.Id, formData, {
        headers: {
            'Content-Type': 'multipart/form-data'
        }
    })
    .then(response => {
        console.log(response);
    })
    .catch(error => {
        console.log(error);
    });
    // try {
    //     const response = await axios({
    //         method: "POST",
    //         url: `${domain}/api/profile/edit/${user.Id}`,
    //         data: formData
    //     });
    //     console.log(response);
    //     window.location.href = "browse.html"; // Redirect on success
    // } catch (error) {
    //     console.error(error);
    //     if (error.response && error.response.data) {
    //         const errorMsg = error.response.data.title || error.response.data;
    //         alert(`Error: ${error.message}\n${errorMsg}`);
    //     } else {
    //         alert(`Error: ${error.message}`);
    //     }
    // }
}

async function updateUser2(){
    user.name = nameElem.val();
    user.bio = bioElem.val();
    user.workExperience = workElem.val();
    console.log(user);
    const formData = new FormData();
    // formData.append("account", user.account);
    // formData.append("accountId", user.accountId); 
    formData.append("bio", user.bio); 
    // formData.append("birthDate", user.birthDate); 
    // formData.append("id", user.id); 
    formData.append("name", user.name); 
    // formData.append("profilePicture", user.profilePicture); 
    formData.append("workExperience", user.workExperience); 
    console.log(formData);
    apicall(`/api/profile/edit/${user.Id}`,"PUT",formData)
    .then(response => {
        console.log(response);
        window.location.href = "browse.html";
    }).catch(error=>{
        console.log(error);
        if(error.response.data.title)
            alert(error.message + "\n" + error.response.data.title);
        else
            alert(error.message + "\n" + error.response.data);
    });
    // try {
    //     const response = await axios({
    //         method: "PUT",      // HTTP method (GET, POST, etc.)
    //         url: domain + `/api/profile/edit/${user.Id}`,      // API endpoint
    //         data: formData,        // Data for POST/PUT requests
    //         headers: {
    //             'Content-Type': 'multipart/form-data',  // Adjust if needed
    //         }
    //     });
    //     console.log(response);
    //     window.history.back();
    //     return response; 
    // } catch (error) {
    //     console.log(error);
    //     if(error.response.data.title)
    //         alert(error.message + "\n" + error.response.data.title);
    //     else
    //         alert(error.message + "\n" + error.response.data);     
    // }
}
$(document).on("click", "#btnSave", function() {
    updateUsera();
});
function objectToFormData(obj) {
    const formData = new FormData();
    // formData.append("account", user.account);
    // formData.append("accountId", user.accountId); 
    formData.append("bio", user.bio); 
    // formData.append("birthDate", user.birthDate); 
    // formData.append("id", user.id); 
    formData.append("name", user.name); 
    // formData.append("profilePicture", user.profilePicture); 
    formData.append("workExperience", user.workExperience); 
    return formData;
}


function updateUsera() {
    const user = {
        name: nameElem.val(),
        bio: bioElem.val(),
        workExperience: workElem.val(),
        Id: 1 // Add userId or get it from the page
    };

    const formData = new FormData();
    formData.append("name", user.name);
    formData.append("bio", user.bio);
    formData.append("workExperience", user.workExperience);

    $.ajax({
        url: domain+`/api/profile/edit/${user.Id}`,
        method: "PUT",
        data: formData,
        contentType: false, // Tells jQuery not to set Content-Type (it will be set to multipart/form-data automatically)
        processData: false, // Tells jQuery not to process the data
        headers: {
            // You can add any headers like 'Authorization' if needed
            // 'Authorization': 'Bearer ' + localStorage.getItem('auth_token')
        },
        success: function (response) {
            console.log(response);
            window.location.href = "profile.html";  // Redirect after success
        },
        error: function (xhr, status, error) {
            console.log("Error:", xhr.responseText);
            alert("Error: " + xhr.responseText);
        }
    });
}
