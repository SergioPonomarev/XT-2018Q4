(function () {
    var $deleteBtn = $('#deleteBtn');

    $deleteBtn.on('click', function () {
        if (confirm("Are you sure you want to delete your profile? You will not be able to restore it.")) {
            var userId = $deleteBtn.data('id');

            $.ajax({
                url: '/users/deleteProfile',
                type: 'post',
                data: { userId: userId }
            })
                .done(function () {
                    window.location.href = "/users";
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