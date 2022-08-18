// implementing using arrow function
let calculateFact = (val) => {
    if(val == 1) return 1;
    else return val * calculateFact(val-1);
}
let printFact = () => {
    let factInputVal = document.getElementById("factInput").value;
    document.getElementById("factP").innerHTML = calculateFact(factInputVal);
}


// implementing function using new keyword (Using Function Constructor)
let greetUser = new Function ("userName", "userEmail", `return alert("Hi "+ userName + ". Your entered email id is: " + userEmail)`);

let getAlert = () => {
    let name = document.getElementById("nameInp").value;
    let email = document.getElementById("emailInp").value;
    if(name != "" && email != ""){
        greetUser(name, email);
    }
    else{
        return alert("Please fill out both of the fields")
    }
}

// Closure function
let showFeedback = () => {
        let feedbackText = document.getElementById("textArea").value;
        let returnText = ((text) => {
            return function () {
                console.log(text);
                return text;
            }
        });
        let returnTextVal = returnText(feedbackText);
        console.log(feedbackText);
        document.getElementById("feedback").innerText = returnTextVal();
}
 