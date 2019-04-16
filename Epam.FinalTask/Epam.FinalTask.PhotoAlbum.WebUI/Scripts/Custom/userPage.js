(function () {
    var $userName = $('#userName').data('name'),
        $deleteBtn = $('#deleteBtn'),
        $banUserBtn = $('#banUser'),
        $unbanUserBtn = $('#unbanUser');

    $deleteBtn.on('click', function () {
        if (confirm("Are you sure you want to delete your profile? You will not be able to restore it.")) {
            $.ajax({
                url: '/Users/DeleteProfile',
                type: 'post',
                data: { userName: $userName }
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

    $banUserBtn.on('click', function () {
        $.ajax({
            url: '/Users/BanUser',
            type: 'post',
            data: { userName: $userName }
        })
            .done(function () {
                window.location.href = `/Users/UserPage?name=${$userName}`;
            })
            .fail(function () {
                alert("Cannot ban this user.");
            })
    })

    $unbanUserBtn.on('click', function () {
        $.ajax({
            url: '/Users/UnbanUser',
            type: 'post',
            data: { userName: $userName }
        })
            .done(function () {
                window.location.href = `/Users/UserPage?name=${$userName}`;
            })
            .fail(function () {
                alert("Cannot unban this user.");
            })
    })
})();