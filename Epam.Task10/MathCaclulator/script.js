'use strict';

var str,
    result = 0,
    mathRegex = /\s*(\d+\.?\d*)\s*/,
    arithmeticComponents;

function validation(arr) {
    if (arr[arr.length - 1] !== '=') {
        return false;
    }

    if (typeof(+arr[arr.length - 2]) !== 'number') {
        return false;
    }

    return true;
}

function getExpressionSign(arr) {
    if (arr[0] === '-') {
        result = -arr[1];
    }
    else if (arr[0] === '+' || arr[0] === '') {
        result = +arr[1];
    }
    else {
        result = 'Wrong input';
    }
}

function calculate(arr) {
    for (var i = 2; i < arr.length - 2; i += 2) {
        switch (arr[i]) {
            case '+':
            result += +arr[i + 1];
            break;

            case '-':
            result -= +arr[i + 1];
            break;

            case '*':
            result *= +arr[i + 1];
            break;

            case '/':
            result /= +arr[i + 1];
            break;

            case '=':
            break;

            default:
            result = 'Wrong input';
            return;
        }
    }
}

document.getElementById('submitButton').onclick = function () {
    str = document.getElementById('inputString').value;
    arithmeticComponents = str.split(mathRegex);

    if (!validation(arithmeticComponents)) {
        result = 'Wrong input';
    }
    else {
        getExpressionSign(arithmeticComponents);
        calculate(arithmeticComponents);
        if (result != 'Wrong input')
        {
            result = result.toFixed(2);
        }
    }
    document.getElementById('outputString').value = result;
    event.preventDefault();
}