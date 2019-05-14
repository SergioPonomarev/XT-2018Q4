(function () {
    var $userName = $('#deleteBtn').data('name'),
        $deleteBtn = $('#deleteBtn');

    $deleteBtn.on('click', function () {
        if (confirm("Are you sure you want to delete your profile? You will not be able to restore it.")) {
            $.ajax({
                url: '/User/DeleteProfile',
                type: 'post',
                data: { userName: $userName }
            })
                .done(function () {
                    window.location.href = "/Home/Index";
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