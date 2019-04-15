var imageDescription = document.getElementById('description'),
    charCount = document.getElementById('charCount'),
    btnSubmit = document.getElementById('btnSubmit');

imageDescription.oninput = function () {
    var text = imageDescription.value;
    charCount.innerText = 140 - text.length;
    if (text.length > 140) {
        charCount.className = 'charCountNotValid';
        btnSubmit.disabled = true;
    } else {
        charCount.className = 'charCountValid';
        btnSubmit.disabled = false;
    }
}