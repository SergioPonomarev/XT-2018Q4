(function () {
    var $deleteBtn = $('#deleteBtn');

    $deleteBtn.on('click', function () {
        if (confirm("Are you sure you want to delete your profile? You will not be able to restore it.")) {
            var userName = $deleteBtn.data('name');

            $.ajax({
                url: '/Users/DeleteProfile',
                type: 'post',
                data: { userName: userName }
            })
                .done(function () {
                    window.location.href = "/Index";
                })
                .fail(function () {
                    alert("Cannot delete profile.");
                })
        }
        else {
            return;
        }
    })
})();