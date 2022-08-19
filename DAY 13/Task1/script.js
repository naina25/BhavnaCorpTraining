let usd_btc_btn = document.getElementById("usd-btc-btn");

usd_btc_btn.addEventListener("click", (e) => {
	e.preventDefault();
	let usd_inp = document.getElementById("usd-inp").value;
	$("#btc-dis").val(usd_inp * 0.000046);
});

let btc_usd_btn = document.getElementById("btc-usd-btn");

btc_usd_btn.addEventListener("click", (e) => {
	e.preventDefault();
	let btc_inp = document.getElementById("btc-inp").value;
	$("#usd-dis").val(btc_inp * 21505.38);
});