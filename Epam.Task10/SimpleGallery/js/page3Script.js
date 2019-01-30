play(urls[3]);

playBtn.onclick = function () {
    play(urls[3]);
}

stopBtn.onclick = function () {
    stop();
}

nextBtn.onclick = function () {
    redirect(urls[3]);
}

prevBtn.onclick = function () {
    redirect(urls[1]);
}