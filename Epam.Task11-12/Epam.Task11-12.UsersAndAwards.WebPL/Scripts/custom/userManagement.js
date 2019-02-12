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
                $listItem.remove();
            })
            .fail(function () {
                alert("Cannot promote user.");
            })
    });
})();