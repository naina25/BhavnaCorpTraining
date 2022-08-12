let registerForm = document.getElementById("register-form");
let modalPara = document.getElementById("modal-para");

let form = `<div id="register-form-div"><form name="register-form" id="registerForm">
<div class="form-group">
  <label for="exampleInputName">Full Name</label>
  <input type="text" name="Name" class="form-control" id="exampleInputName" placeholder="Your Name Here">
</div>
<div class="form-group">
  <label for="exampleInputEmail1">Email address</label>
  <input type="email" name="Email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
  <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
</div>
<div class="form-group">
  <label for="exampleInputPassword1">Password</label>
  <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
</div>
<div class="form-check">
  <input type="checkbox" class="form-check-input" id="exampleCheck1">
  <label class="form-check-label" for="exampleCheck1">Check me out</label>
</div>
<button type="submit" data-target="#register-modal" data-toggle="modal" class="btn btn-primary">Register</button>
</form></div>`;

function openForm() {
    registerForm.innerHTML = form;
    document.getElementById("registerForm").addEventListener("submit", function(event){
        console.log(event);
        event.preventDefault();
        modalPara.innerText = "Congratulations!! "+ event.target[0].value +", You're successfully registered!!";
    })
}



