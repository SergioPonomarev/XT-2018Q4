(function () {
    var $userName = $('#username').data('name'),
        $deleteBtn = $('#deleteBtn'),
        $banUserBtn = $('#banUser'),
        $unbanUserBtn = $('#unbanUser'),
        $promoteUserBtn = $('#promoteUser'),
        $demoteUserBtn = $('#demoteUser');

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

    $banUserBtn.on('click', function () {
        $.ajax({
            url: '/User/BanUser',
            type: 'post',
            data: { userName: $userName }
        })
            .done(function () {
                window.location.href = `/User/UserPage?userName=${$userName}`;
            })
            .fail(function () {
                alert("Cannot ban this user.");
            })
    })

    $unbanUserBtn.on('click', function () {
        $.ajax({
            url: '/User/UnbanUser',
            type: 'post',
            data: { userName: $userName }
        })
            .done(function () {
                window.location.href = `/User/UserPage?userName=${$userName}`;
            })
            .fail(function () {
                alert("Cannot unban this user.");
            })
    })

    $promoteUserBtn.on('click', function () {
        $.ajax({
            url: '/User/PromoteToAdmin',
            type: 'post',
            data: { userName: $userName }
        })
            .done(function () {
                window.location.href = `/User/UserPage?userName=${$userName}`;
            })
            .fail(function () {
                alert("Cannot promote this user.");
            })
    })

    $demoteUserBtn.on('click', function () {
        $.ajax({
            url: '/User/DemoteToUser',
            type: 'post',
            data: { userName: $userName }
        })
            .done(function () {
                window.location.href = `/User/UserPage?userName=${$userName}`;
            })
            .fail(function () {
                alert("Cannot demote this user.");
            })
    })
})();