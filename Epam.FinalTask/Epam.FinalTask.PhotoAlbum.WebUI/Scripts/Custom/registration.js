var passFormat = /[^A-Za-z0-9]/g,
    userNameInput = document.getElementById('userName'),
    passwordInput = document.getElementById('password'),
    repPasswordInput = document.getElementById('repPassword'),
    submitButton = document.getElementById('btnSubmit'),
    nameErrorMessage = document.getElementById('nameError'),
    nameOkMessage = document.getElementById('nameOk'),
    passErrorMessage = document.getElementById('passError'),
    passOkMessage = document.getElementById('passOk'),
    repPassErrorMessage = document.getElementById('repPassError'),
    repPassOkMessage = document.getElementById('repPassOk'),
    nameCheck = false,
    passCheck = false,
    repPassCheck = false;

userNameInput.onchange = function () {
    var textName = userNameInput.value.trim();
    if (textName.length <= 0) {
        nameErrorMessage.innerText = "Wrong input. The name length must be greater than 0 symbols.";
        nameOkMessage.innerText = null;
        nameCheck = false;
        return;
    } else {
        nameErrorMessage.innerText = null;
        nameOkMessage.innerText = "The name is Ok.";
        nameCheck = true;
        return;
    }
}

passwordInput.onchange = function () {
    var textPass = document.getElementById('password').value;
    if (passFormat.test(textPass)) {
        passErrorMessage.innerText = "Wrong input. There is can be only latin letters and numbers.";
        passOkMessage.innerText = null;
        passCheck = false;
        return;
    } else if (textPass.length < 6) {
        passErrorMessage.innerText = "The password length must be greater than 6 symbols.";
        passOkMessage.innerText = null;
        passCheck = false;
        return;
    } else {
        passErrorMessage.innerText = null;
        passOkMessage.innerText = "The password is Ok.";
        passCheck = true;
        return;
    }
}

repPasswordInput.onchange = function () {
    var textPass = passwordInput.value;
    var textRepPass = repPasswordInput.value;

    if (textPass !== textRepPass) {
        repPassErrorMessage.innerText = "Passwords don't match.";
        repPassOkMessage.innerText = null;
        repPassCheck = false;
        return;
    } else {
        repPassErrorMessage.innerText = null;
        repPassOkMessage.innerText = "The repeated password is ok.";
        repPassCheck = true;
        return;
    }
}

submitButton.onclick = function (event) {
    if (!nameCheck || !passCheck || !repPassCheck) {
        event.preventDefault();
        event.stopPropagation();
    }
}