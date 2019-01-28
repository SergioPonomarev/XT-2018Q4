'use strict';

var separators = ["?", "!", ":", ";", ",", ".", " ", "\t"],
    str, 
    arr, 
    letters = {}, 
    start = 0, 
    words = [], 
    result;

document.getElementById('submitButton').onclick = function () {
    str = document.getElementById('inputString').value;
    getWordsFromInput(str);
    findSameLetters();
    getResultString();
    document.getElementById('outputString').value = result;
    event.preventDefault();
}

function getWordsFromInput(string) {
    arr = string.split('');
    arr.forEach(function (letter, i) {
        if (separators.indexOf(letter) != -1) {
            words.push(str.substr(start, i - start));
            start = i + 1;
        }
    });

    words.push(str.substr(start));
}

function findSameLetters() {
    words.forEach(function (word) {
        word.split('').forEach(function (letter, i) {
            if (!letters[letter] && word.indexOf(letter, i + 1) != -1) {
                letters[letter] = true;
            }
        });
    });
}

function getResultString() {
    result = arr.filter(function (check) {
        return !letters[check];
    }).join('');
}