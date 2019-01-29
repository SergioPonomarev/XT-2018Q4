'use strict';

var availableField = document.getElementById('available'),
    selectedField = document.getElementById('selected'),
    allToSelected = document.getElementById('allToSelected'),
    toSelected = document.getElementById('toSelected'),
    toAvailable = document.getElementById('toAvailable'),
    allToAvailable = document.getElementById('allToAvailable');

allToSelected.onclick = function () {
    allToSelOrAv(availableField, selectedField);
}

allToAvailable.addEventListener('click', function () {
    allToSelOrAv(selectedField, availableField);
});

toSelected.addEventListener('click', function () {
    toSelOrAv(availableField, selectedField);
});

toAvailable.addEventListener('click', function () {
    toSelOrAv(selectedField, availableField);
});

function displayErrorMessage() {
    if (availableField.selectedIndex == -1 &&
        selectedField.selectedIndex == -1) {
            alert('Choose an element form the list.');
        }
}

function allToSelOrAv(field1, field2) {
    while (field1.options.length > 0) {
        field2.appendChild(field1.options[0]);
    }
}

function toSelOrAv(field1, field2) {
    displayErrorMessage();
    if (field1.options.length > 0) {
        field2.appendChild(field1.options[field1.selectedIndex]);
    }

    field2.selectedIndex = -1;
}