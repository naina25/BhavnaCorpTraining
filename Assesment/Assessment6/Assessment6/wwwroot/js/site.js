// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let submitFeedbackBtn = document.getElementById("feedbackBtn");
let inputFields = document.getElementsByClassName("form-control");
let buyBtn = document.getElementsByClassName("buy");

//Items added to cart display message
for (let i = 0; i < 6; i++) {
    buyBtn[i].addEventListener("click", (e) => {
        e.preventDefault();
        prompt("Enter the quantity of the plant you want to add-");
        alert("Selected item added to the cart successfully!");
    })
}

//feedback sent alert
submitFeedbackBtn.addEventListener("click", (e) => {
    e.preventDefault();
    for (let i = 0; i < 3; i++){
        inputFields[i].value = "";
    }
    alert("Thanks for your valuable feedback!");
})

