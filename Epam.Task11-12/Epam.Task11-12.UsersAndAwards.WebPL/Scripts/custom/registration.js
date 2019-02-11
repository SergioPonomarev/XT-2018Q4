var passFormat = /[^A-Z-a-z-0-9]/g,
    nameErrorMessage = document.getElementById('nameError'),
    nameOkMessage = document.getElementById('nameOk'),
    passErrorMessage = document.getElementById('passError'),
    passOkMessage = document.getElementById('passOk'),
    repPassErrorMessage = document.getElementById('repPassError'),
    repPassOkMessage = document.getElementById('repPassOk'),
    dateErrorMessage = document.getElementById('dateError'),
    dateOkMessage = document.getElementById('dateOk'),
    nameCheck = false,
    passCheck = false,
    repPassCheck = false,
    dateCheck = false;

document.getElementById('userName').onchange = function () {
    var textName = document.getElementById('userName').value;
    if (textName.length <= 0) {
        nameErrorMessage.innerText = "Wrong input. The name length must be greater than 0 symbols.";
        nameOkMessage.innerText = null;
        nameCheck = false;
        return;
    }
    else {
        nameErrorMessage.innerText = null;
        nameOkMessage.innerText = "The name is ok.";
        nameCheck = true;
        return;
    }
}

document.getElementById('password').onchange = function () {
    var textPass = document.getElementById('password').value;
    if (passFormat.test(textPass)) {
        passErrorMessage.innerText = "Wrong input. There is can be only latin letters and numbers.";
        passOkMessage.innerText = null;
        passCheck = false;
        return;
    }
    if (textPass.length < 6) {
        passErrorMessage.innerText = "The password length must be greater than 6 symbols.";
        passOkMessage.innerText = null;
        passCheck = false;
        return;
    }
    else {
        passErrorMessage.innerText = null;
        passOkMessage.innerText = "The password is ok.";
        passCheck = true;
        return;
    }
}

document.getElementById('repPassword').onchange = function () {
    var textPass = document.getElementById('password').value;
    var textRepPass = document.getElementById('repPassword').value;

    if (textPass !== textRepPass) {
        repPassErrorMessage.innerText = "Passwords don't match.";
        repPassOkMessage.innerText = null;
        repPassCheck = false;
        return;
    }
    else {
        repPassErrorMessage.innerText = null;
        repPassOkMessage.innerText = "The repeated password is ok.";
        repPassCheck = true;
        return;
    }
}

document.getElementById('date').onchange = function () {
    var dateValue = document.getElementById('date').value;
    var inputDate = new Date(dateValue);
    var currentDate = new Date();

    if (inputDate >= currentDate) {
        dateErrorMessage.innerHTML = "Date of birth cannot be greater than today.";
        dateOkMessage.innerHTML = null;
        dateCheck = false;
        return;
    }
    else {
        dateErrorMessage.innerHTML = null;
        dateOkMessage.innerHTML = "Date is ok.";
        dateCheck = true;
        return;
    }
}

document.getElementById('btnSubmit').onclick = function (event) {
    if (nameCheck === false ||
        passCheck === false ||
        repPassCheck === false ||
        dateCheck === false) {
        event.preventDefault();
        event.stopPropagation();
    }
}