play(urls[2]);

playBtn.onclick = function () {
    play(urls[2]);
}

stopBtn.onclick = function () {
    stop();
}

nextBtn.onclick = function () {
    redirect(urls[2]);
}

prevBtn.onclick = function () {
    redirect(urls[0]);
}