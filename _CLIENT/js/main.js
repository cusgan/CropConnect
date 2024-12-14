require
$(function() {
    useapi("/api/guides","GET")
        .then(response => {
            console.log(response);
        });
    console.log();
});
const domain = "http://localhost:5037";
// function useapi(endpoint, htype, input = {}){
//     var res = null;
//     $.ajax({
//         type: htype,
//         url: "http://localhost:5037/api/guides",
//         data: input,
//         dataType: "html",
//         success: function(result) {
//             res = JSON.parse(result);
//         }}); 
//     return res;
// }
async function useapi(endpoint, htype, input = {}) {
    try {
        const response = await axios({
            method: htype,      // HTTP method (GET, POST, etc.)
            url: domain + endpoint,      // API endpoint
            data: input,        // Data for POST/PUT requests
        });

        return response.data;  // Return the parsed JSON response
    } catch (error) {
        console.error("Error:", error.message);
        throw error;           // Throw the error to handle it outside the function
    }
}
