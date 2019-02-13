(function () {
    var $usersList = $('#usersList');

    $usersList.on('click', '.btn_promoteUser', function (e) {
        var $target = $(e.target),
            $listItem = $target.closest('li'),
            userName = $listItem.data('username');

        $.ajax({
            url: '/users/promoteToAdmin',
            type: 'post',
            data: { userName: userName }
        })
            .done(function () {
                window.location.href = "/users/userManagement";
            })
            .fail(function () {
                alert("Cannot promote user.");
            })
    });

    $usersList.on('click', '.btn_demoteUser', function (e) {
        var $target = $(e.target),
            $listItem = $target.closest('li'),
            userName = $listItem.data('username');

        $.ajax({
            url: '/users/demoteToUser',
            type: 'post',
            data: { userName: userName }
        })
            .done(function () {
                window.location.href = "/users/userManagement";
            })
            .fail(function () {
                alert("Cannot demote user.");
            })
    })

    $usersList.on('click', '.btn_deleteUser', function (e) {
        var $target = $(e.target),
            $listItem = $target.closest('li'),
            userId = $listItem.data('userid');

        $.ajax({
            url: '/users/deleteUser',
            type: 'post',
            data: {userId: userId}
        })
            .done(function () {
                $listItem.remove();
            })
            .fail(function () {
                alert("Cannot delete user.");
            })
    });

    $usersList.on('click', '.btn_deleteAwardFromUser', function (e) {
        var $target = $(e.target),
            $listItem = $target.closest('div'),
            userId = $listItem.data('userid'),
            awardId = $listItem.data('awardid');

        $.ajax({
            url: '/users/deleteAwardFromUser',
            type: 'post',
            data: {
                userId: userId,
                awardId: awardId
            }
        })
            .done(function () {
                $listItem.remove();
            })
            .fail(function () {
                alert("Cannot delete award from user.")
            })
    })
})();