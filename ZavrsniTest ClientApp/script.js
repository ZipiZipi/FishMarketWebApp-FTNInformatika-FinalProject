var host = "https://localhost:";
var port = "44340/";

var ribarnicaEndpoint = "api/ribarnice/";
var ribaEndpoint = "api/ribe/";

var loginEndpoint = "api/authentication/login";
var registerEndpoint = "api/authentication/register";

var pretragaEndpoint = "api/pretraga";

var formAction = "Create";
var editingId;
var ribarnicaEditingId;
var jwt_token;

function registerUser() {
	var username = document.getElementById("usernameRegister").value;
	var email = document.getElementById("emailRegister").value;
    var password = document.getElementById("passwordRegister").value;
	var cpassword = document.getElementById("confirmPasswordRegister").value;

	if (validateRegisterForm(username,email,password,cpassword)) {
		var url = host + port + registerEndpoint;
		var sendData ={
          "Username": username,
          "Email" : email,
          "Password": password 
        };
		fetch(url, { method: "POST", headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(sendData) })
			.then((response) => {
				if (response.status === 200) {
					console.log("Successful register");
					alert("Successful register");
					clearLoginRegisterForms();
                    showLogin();
					response.json().then(function (data) {
						console.log(data);

					});
				} else {
					console.log("Error occured with code " + response.status);
					console.log(response);
					alert("Desila se greska!");
				}
			})
			.catch(error => console.log(error));
	}
	return false;
}
function loginUser() {
	var username = document.getElementById("usernameLogin").value;
	var password = document.getElementById("passwordLogin").value;

	if (validateLoginForm(username, password)) {
		var url = host + port + loginEndpoint;
		var sendData = { "Username": username, "Password": password };
		fetch(url, { method: "POST", headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(sendData) })
			.then((response) => {
				if (response.status === 200) {
					console.log("Successful login");
					alert("Successful login");
					response.json().then(function (data) {
						console.log(data);
                        document.getElementById("info").innerHTML = "Prijavljen korisnik: <i>" + data.username + "<i/>.";
						document.getElementById("infoLog").style.display = "none";
						document.getElementById("loginForm").style.display = "none";
						document.getElementById("logoutButton").style.display = "block";
						document.getElementById("ribaForm").style.display = "block";
						document.getElementById("loginButton").style.display = "none";
						document.getElementById("registerButton").style.display = "none";
						document.getElementById("pretragaForm").style.display = "block";
						
                        jwt_token = data.token;
						loadRiba();
                        selectRibranice();
						clearLoginRegisterForms();
					});
				} else {
					console.log("Error occured with code " + response.status);
					console.log(response);
					alert("Desila se greska!");
				}
			})
			.catch(error => console.log(error));
	}
	return false;
}

function logout() {
	jwt_token = undefined;
	document.getElementById("info").innerHTML = "";
	document.getElementById("data").style.display = "none";
	document.getElementById("ribaForm").style.display = "none";
	//document.getElementById("prodavnicaForm").style.display = "none";
	document.getElementById("loginForm").style.display = "none";
	document.getElementById("registerForm").style.display = "none";
	document.getElementById("logoutButton").style.display = "none";
	document.getElementById("loginButton").style.display = "initial";
	document.getElementById("registerButton").style.display = "initial";
}

function validateLoginForm(username, password) {
	if (username.length === 0) {
		alert("Username field can not be empty.");
		return false;
	} else if (password.length === 0) {
		alert("Password field can not be empty.");
		return false;
	}
	return true;
}
function validateRegisterForm(username,email,password,cpassword) {
	if (username.length === 0) {
		alert("Username field can not be empty.");
		return false;
	} else if (email.length === 0) {
		alert("email field can not be empty.");
		return false;
	}else if (password.length === 0) {
		alert("Password field can not be empty.");
		return false;
	}else if (cpassword.value !== password.value) {
		alert("Sifre se ne poklapaju");
		return false;
	}
	return true;
}
function clearLoginRegisterForms(){
	//register
	document.getElementById("usernameRegister").value = "";
	document.getElementById("emailRegister").value = "";
	document.getElementById("passwordRegister").value = "";
	document.getElementById("confirmPasswordRegister").value = "";
	//login
	document.getElementById("usernameLogin").value = "";
	document.getElementById("passwordLogin").value = "";
}
function odustajanjeButton(){
	document.getElementById("infoLog").innerHTML = "Korisnik nije prijavljen"
	document.getElementById("loginButton").style.display = "block";
    document.getElementById("registerButton").style.display = "block";
	document.getElementById("loginForm").style.display = "none";
	document.getElementById("registerForm").style.display = "none";
	document.getElementById("logoutButton").style.display = "none";
}
function showLogin() {
	document.getElementById("infoLog").innerHTML = "Prijava korisnika"
	document.getElementById("loginButton").style.display = "none";
    document.getElementById("registerButton").style.display = "none";
	document.getElementById("loginForm").style.display = "block";
	document.getElementById("registerForm").style.display = "none";
	document.getElementById("logoutButton").style.display = "none";
}
function showRegister() {
	document.getElementById("infoLog").innerHTML = "Registracija korisnika"
	document.getElementById("loginButton").style.display = "none";
    document.getElementById("registerButton").style.display = "none";
	document.getElementById("loginForm").style.display = "none";
	document.getElementById("registerForm").style.display = "block";
	document.getElementById("logoutButton").style.display = "none";
}
function loadRiba() {
	if(!jwt_token){
		document.getElementById("infoLog").innerHTML = "Korisnik nije prijavljen"
	}
	document.getElementById("data").style.display = "block";
	document.getElementById("loginForm").style.display = "none";
	document.getElementById("registerForm").style.display = "none";

	var requestUrl = host + port + ribaEndpoint;
	console.log("URL zahteva: " + requestUrl);
	var headers = {};
	if (jwt_token) {
		headers.Authorization = 'Bearer ' + jwt_token;
	}
	console.log(headers);
	fetch(requestUrl, { headers: headers })
		.then((response) => {
			if (response.status === 200) {
				response.json().then(setRiba);
			} else {
				console.log("Error occured with code " + response.status);
				showError();
			}
		})
		.catch(error => console.log(error));
};
loadRiba();

function showError() {
	var container = document.getElementById("data");
	container.innerHTML = "";

	var div = document.createElement("div");
	var h1 = document.createElement("h1");
	var errorText = document.createTextNode("Greska prilikom preuzimanja Autora!");

	h1.appendChild(errorText);
	div.appendChild(h1);
	container.append(div);
}
function setRiba(data) {
	var container = document.getElementById("data");
	container.innerHTML = "";

	console.log(data);

	// ispis naslova
	var div = document.createElement("div");
	var h1 = document.createElement("h1");
	var headingText = document.createTextNode("Ribe na prodaju");
	h1.appendChild(headingText);
	div.appendChild(h1);

	// ispis tabele
	var table = document.createElement("table");

	var header = createHeader();
	table.classList.add("table", "table-bordered");
	header.classList.add("table-info")
	table.append(header);


	var tableBody = document.createElement("tbody");

	for (var i = 0; i < data.length; i++)
	{
		// prikazujemo novi red u tabeli
		var row = document.createElement("tr");
		// prikaz podataka
		row.appendChild(createTableCell(data[i].sorta));
		row.appendChild(createTableCell(data[i].cena));
        row.appendChild(createTableCell(data[i].ribarnicaNaziv));
		row.appendChild(createTableCell(data[i].kolicina));
        if(jwt_token){
            row.appendChild(createTableCell(data[i].mesto));
		// prikaz dugmadi za izmenu i brisanje
            var stringId = data[i].id.toString();

            var buttonDelete = document.createElement("button");
            buttonDelete.classList.add("btn", "btn-danger", "btn-sm");
            buttonDelete.name = stringId;
            buttonDelete.addEventListener("click", deleteRiba);
            var buttonDeleteText = document.createTextNode("Obrisi");
            buttonDelete.appendChild(buttonDeleteText);
            var buttonDeleteCell = document.createElement("td");
            buttonDeleteCell.appendChild(buttonDelete);
            row.appendChild(buttonDeleteCell);
        }

		tableBody.appendChild(row);		
	}

	table.appendChild(tableBody);
	div.appendChild(table);

	// prikaz forme
    if(jwt_token){
		//document.getElementById("prodavnicaForm").style.display = "none";
        document.getElementById("ribaForm").style.display = "block";
        //selectProdavnice();
    }
	// ispis novog sadrzaja
	container.appendChild(div);
};
function createHeader() {
	var thead = document.createElement("thead");
	var row = document.createElement("tr");
	row.appendChild(createTableCell("Sorta"));
	row.appendChild(createTableCell("Cena (din/kg)"));
	row.appendChild(createTableCell("Ribranica"));
	row.appendChild(createTableCell("Kolicina (kg)"));
    if(jwt_token){
        row.appendChild(createTableCell("Mesto ulova"));
        row.appendChild(createTableCell("Akcija"));
    }

	thead.appendChild(row);
	return thead;
}
function createTableCell(text) {
	var cell = document.createElement("td");
	var cellText = document.createTextNode(text);
	cell.appendChild(cellText);
	return cell;
}
function deleteRiba() {
	// izvlacimo {id}
	var deleteID = this.name;
	// saljemo zahtev 
	var url = host + port + ribaEndpoint + deleteID.toString();
	var headers = { 'Content-Type': 'application/json' };
	if (jwt_token) {
		headers.Authorization = 'Bearer ' + jwt_token;
	}
	fetch(url, { method: "DELETE", headers: headers})
		.then((response) => {
			if (response.status === 204) {
				console.log("Successful action");
				refreshTable();
			} else {
				console.log("Error occured with code " + response.status);
				alert("Desila se greska!");
			}
		})
		.catch(error => console.log(error));
};
function refreshTable() {
	// cistim formu
    /*document.getElementById("imeProdavca").value = "";
    document.getElementById("prezimeProdavca").value = "";
    document.getElementById("godineProdavca").value = "";
    document.getElementById("prodavnicaProdavca").value = "";
	// osvezavam
	document.getElementById("prodavacButton").click();*/
	loadRiba();
};
function odustajanjeDodavanjaRibe(){
	document.getElementById("sortaRibe").value = "";
    document.getElementById("mestoUlovaRibe").value = "";
    document.getElementById("cenaRibe").value = "";
    document.getElementById("ukupnaKolicinaRibe").value = "";
}
function selectRibranice()
{	
    var requestUrl = host + port + ribarnicaEndpoint;
    console.log("URL zahteva: " + requestUrl);
    fetch(requestUrl)
      .then((response) => {
        if (response.status === 200) {
          response.json().then(napraviSelect);
        } else {
          console.log("Error occured with code " + response.status);
          showError();
        }
      })
      .catch((error) => console.log(error));
}
function napraviSelect(data){
    document.getElementById("ribranicaRibe").innerHTML = "";
    var select = document.getElementById("ribranicaRibe");
    for (var i = 0; i < data.length; i++) {
      var option = document.createElement("option");
      option.value = data[i].id;
      option.text = data[i].naziv;
  
      if (formAction === "Update" && data[i].Id === ribarnicaEditingId) {
        option.selected = true;
      }
      select.appendChild(option);
    }
}
function submitRibaForm(){
	var sortaRibe = document.getElementById("sortaRibe").value;
    var mestoUlovaRibe = document.getElementById("mestoUlovaRibe").value;
    var cenaRibe = document.getElementById("cenaRibe").value;
    var ukupnaKolicinaRibe = document.getElementById("ukupnaKolicinaRibe").value;
	var ribranicaRibe = document.getElementById("ribranicaRibe").value;
    if(!validateRibaForm(sortaRibe,mestoUlovaRibe,cenaRibe,ukupnaKolicinaRibe)){
        return false;
    }
	var httpAction;
	var sendData;
	var url;

	// u zavisnosti od akcije pripremam objekat
	if (formAction === "Create") {
		httpAction = "POST";
		url = host + port + ribaEndpoint;
		sendData = {
			"Sorta": sortaRibe,
            "Mesto": mestoUlovaRibe,
            "Cena" : cenaRibe,
			"Kolicina" : ukupnaKolicinaRibe,
            "RibarnicaId" : ribranicaRibe
		};
	}
	else {
		/*httpAction = "PUT";
		url = host + port + prodavacEndpoint + editingId.toString();
		sendData = {
			"Id": editingId,
			"Ime": imeProdavca,
            "Prezime": prezimeProdavca,
            "GodinaRodjenja" : godineProdavca,
            "ProdavnicaId" : prodavnicaProdavca
		};*/
	}

	console.log("Objekat za slanje");
	console.log(sendData);
	var headers = { 'Content-Type': 'application/json' };
	if (jwt_token) {
		headers.Authorization = 'Bearer ' + jwt_token;		// headers.Authorization = 'Bearer ' + sessionStorage.getItem(data.token);
	}
	fetch(url, { method: httpAction, headers: headers, body: JSON.stringify(sendData) })
		.then((response) => {
			if (response.status === 200 || response.status === 201) {
				console.log("Successful action");
				formAction = "Create";
				refreshTable();
			} else {
				console.log("Error occured with code " + response.status);
				alert("Desila se greska!");
			}
		})
		.catch(error => console.log(error));
	return false;
}
function validateRibaForm(sortaRibe,mestoUlovaRibe,cenaRibe,ukupnaKolicinaRibe){
	if (!(sortaRibe.length >= 2 && sortaRibe.length <= 30)) {
		alert("Ime sorte mora biti izmedju 2 i 30 karaktera");
		return false;
	} else if (!(mestoUlovaRibe.length >= 3 && mestoUlovaRibe.length <= 120)) {
		alert("Ime mesta mora biti izmedju 3 i 120 karaktera");
		return false;
	}/*else if (!(cenaRibe.length >= 100 && cenaRibe.length <= 10000)) {
		alert("Cena mora biti veca od 100 a manja od 1000");
		return false;
    }else if (!(ukupnaKolicinaRibe.length >= 1 && ukupnaKolicinaRibe.length <= 1000)) {
		alert("Kolicina mora biti veca od 1 a manja od 1000");
		return false;
    }*/
	return true;
}
function pretraga(){
	var najmanje = document.getElementById("najmanje").value;
    var najvise = document.getElementById("najvise").value;

	var httpAction;
	var sendData;
	var url;

	httpAction = "POST";
	url = host + port + pretragaEndpoint;
	sendData = {
		"Najmanje": najmanje,
		"Najvise": najvise
	};

	console.log("Objekat za slanje");
	console.log(sendData);
	var headers = { 'Content-Type': 'application/json' };
	if (jwt_token) {
		headers.Authorization = 'Bearer ' + jwt_token;		// headers.Authorization = 'Bearer ' + sessionStorage.getItem(data.token);
	}
	fetch(url, { method: httpAction, headers: headers, body: JSON.stringify(sendData) })
		.then((response) => {
			if (response.status === 200 || response.status === 201) {
				response.json().then(setProdavnice);
				refreshTable();
			} else {
				console.log("Error occured with code " + response.status);
				alert("Desila se greska!");
			}
		})
		.catch(error => console.log(error));
	return false;
}