var seconds = 5,
    playFlag = false,
    startBtn = document.getElementById('start'),
    stopBtn = document.getElementById('stop'),
    playBtn = document.getElementById('play'),
    prevBtn = document.getElementById('prev'),
    nextBtn = document.getElementById('next'),
    startAgainBtn = document.getElementById('startAgain'),
    closeBtn = document.getElementById('close'),
    counter = document.getElementById('counter'),
    urls = ['page1.html', 'page2.html', 'page3.html', 'page4.html'];

function play(url) {
    go = true;
    countDown(url);
}

function stop() {
    go = false;
}

function countDown(url) {
    if (!go) {
        return;
    }

    counter.innerText = seconds;
    seconds--;
    if (seconds < 0) {
        redirect(url);
    }

    setTimeout(countDown, 1000, url);
}

function redirect(url) {
    location = url;
}