prevBtn.onclick = function () {
    redirect(urls[2]);
}

startAgainBtn.onclick = function () {
    redirect(urls[0]);
}

closeBtn.onclick = function () {
    open(location, '_self').close();
}