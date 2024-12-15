const domain = "http://localhost:5037";

// $(function() {
//     apicall("/api/guides","GET",{},(response)=>{
//         console.log(response);
//     });
// });

$("#btnBack").on("click", function() {
    alert("going back to the corner");
    window.history.back();
});
async function apicall(endpoint, htype, input) {
    try {
        const response = await axios({
            method: htype,      // HTTP method (GET, POST, etc.)
            url: domain + endpoint,      // API endpoint
            data: input,        // Data for POST/PUT requests
            headers: {
                'Content-Type': 'multipart/form-data',  // Ensure the correct content type for multipart
            },
        });

        return response.data;  // Return the parsed JSON response
    } catch (error) {
        console.error("Error:", error.message);
        throw error;           // Throw the error to handle it outside the function
    }
}
async function apicallh(endpoint, htype, input, headers) {
    try {
        const response = await axios({
            method: htype,      // HTTP method (GET, POST, etc.)
            url: domain + endpoint,      // API endpoint
            data: input,        // Data for POST/PUT requests
            headers: headers
        });

        return response.data;  // Return the parsed JSON response
    } catch (error) {
        console.error("Error:", error.message);
        throw error;           // Throw the error to handle it outside the function
    }
}

function blob2Image(blob) {
    return URL.createObjectURL(blob);
}
function setCookie(name, value) {
    const expires = new Date();
    expires.setTime(expires.getTime() + 3 * 60 * 60 * 1000); // 3 hours from now
    document.cookie = `${name}=${value}; expires=${expires.toUTCString()}; path=/`;
}
function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
    return null; // Return null if the cookie doesn't exist
}
function deleteCookie(name) {
    document.cookie = `${name}=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/`;
}
function clearAllCookies() {
    // Get all cookies
    const cookies = document.cookie.split(";");

    // Loop through all cookies and delete them
    cookies.forEach(function(cookie) {
        const cookieName = cookie.split("=")[0].trim();
        document.cookie = `${cookieName}=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/`;
    });
}
