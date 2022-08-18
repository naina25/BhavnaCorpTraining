// DATA FETCHING USING FAKE APIs

//using xmlhttp
// var request = new XMLHttpRequest();
// request.open('GET', 'https://jsonplaceholder.typicode.com/todos')
// request.send();
// request.onload = ()=>{
//     console.log(JSON.parse(request.response));
// }

//using ajax
// $(document).ready(function(){
//     $.ajax({
//         url: "https://jsonplaceholder.typicode.com/todos",
//         type: "GET",
//         success: function(result){
//             console.log(result);
//         }
//     })
// })

// using fetch()
// fetch('https://jsonplaceholder.typicode.com/todos').then(response =>{
//     return response.json();
// }).then(data =>{
//     console.log(data);
// })

// using axios
axios.get("https://jsonplaceholder.typicode.com/todos")
.then(response =>{
    console.log(response.data);
})