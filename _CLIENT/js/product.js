var postingsList;

$(document).on("click", "#btnConfirm", function() {
    checkout();
});

function checkout(){
    const formData = new FormData();
    var quantity = $("#buyQuantity").val();
    formData.append("quantity", quantity);
    $.ajax({
        url: domain+`/api/postings/buy/${getCookie("currentViewId")}`,
        method: "PUT",
        contentType: false, // Tells jQuery not to set Content-Type (it will be set to multipart/form-data automatically)
        processData: false, // Tells jQuery not to process the data
        data: formData,
        headers: {
            // You can add any headers like 'Authorization' if needed
            // 'Authorization': 'Bearer ' + localStorage.getItem('auth_token')
        },
        success: function (response) {
            console.log(response);
            var product=response;
            // $("#email").html(product.posterId);
            // $("#work").html("farma");
            alert("Bought "+quantity+" item(s) successfuly");
            window.location.href = "#";
        },
        error: function (xhr, status, error) {
            console.log("Error:", xhr.responseText);
            alert("Error: " + xhr.responseText);
        }
    });
}

$(function() {
    $.ajax({
        url: domain+`/api/postings/getone/${getCookie("currentViewId")}`,
        method: "GET",
        contentType: false, // Tells jQuery not to set Content-Type (it will be set to multipart/form-data automatically)
        processData: false, // Tells jQuery not to process the data
        headers: {
            // You can add any headers like 'Authorization' if needed
            // 'Authorization': 'Bearer ' + localStorage.getItem('auth_token')
        },
        success: function (response) {
            console.log(response);
            var product=response;
            // $("#email").html(product.posterId);
            // $("#work").html("farma");
            $("#productName").html(product.productName);
            $("#type").val("Type: "+convertProductType(product.productType));
            $("#kg").val("Sold by: "+convertUnitType(product.unitType));
            getUser2(product.posterId);
            // $("#headingImage").html("data:image/jpeg;base64,"+guide.headingImage);
            $("#coverimage").attr('src', "data:image/jpeg;base64,"+product.productImage);
            $("#stock").val("Stock: "+product.stock);
            $("#price").val("Price: "+product.price);
            $("#info").val(product.additionalInfo);
            $("#desc").html(product.productDescription);
        },
        error: function (xhr, status, error) {
            console.log("Error:", xhr.responseText);
            alert("Error: " + xhr.responseText);
        }
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
function convertUnitType(unitType){
    const UnitType = [
        "Piece",
        "Kilogram",
        "Liter",
        "Pack",
        "Other"
    ];
    return UnitType[unitType];
}
function convertProductType(index){
    const ProductType = [
        "Crop",
        "Dairy",
        "Seeds",
        "Meat",
        "Livestock",
        "Processed",
        "Misc"
    ];
    return ProductType[index];
}
// async function getUser(userId){
//     try {
//         const response = await axios({
//             method: "GET",      // HTTP method (GET, POST, etc.)
//             url: domain + `/api/profile/${userId}/profile`,      // API endpoint
//             data: {},        // Data for POST/PUT requests
//             headers: {
//                 'Content-Type': 'application/json',  // Adjust if needed
//                 // Add other headers like 'Authorization' if necessary
//             }
//         });
//         user = response.data;
//         // console.log(response.data);
//         // nameElem.val(response.data.name);
//         // bioElem.html(response.data.bio);
//         // workElem.val(response.data.workExperience);
//         $("#email").html(response.data.name);
//         $("#work").html(response.data.workExperience);
//         return response.data;  // Return the parsed JSON response
//     } catch (error) {
//         console.error("Error:", error.message);
//         throw error;           // Throw the error to handle it outside the function
//     }
// }
function getUser(userId){
    $.ajax({
        url: domain+`/api/profile/${userId}/profile`,
        method: "GET",
        contentType: false, // Tells jQuery not to set Content-Type (it will be set to multipart/form-data automatically)
        processData: false, // Tells jQuery not to process the data
        headers: {
            // You can add any headers like 'Authorization' if needed
            // 'Authorization': 'Bearer ' + localStorage.getItem('auth_token')
        },
        success: function (response) {
            console.log(response);
            var product=response;
            // $("#email").html(product.posterId);
            // $("#work").html("farma");
            
            $("#email").html(response.data.name);
            $("#work").html(response.data.workExperience);
        },
        error: function (xhr, status, error) {
            console.log("Error:", xhr.responseText);
            alert("Error: " + xhr.responseText);
        }
    });
}
async function getUser2(userId){
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
        $("#email").html(response.data.name);
        $("#work").html(response.data.workExperience);
        return response.data;  // Return the parsed JSON response
    } catch (error) {
        console.error("Error:", error.message);
        throw error;           // Throw the error to handle it outside the function
    }
}
