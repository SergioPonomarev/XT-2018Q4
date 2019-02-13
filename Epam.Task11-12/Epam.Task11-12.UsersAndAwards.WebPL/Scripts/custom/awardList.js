(function () {
    var $awardList = $('#awardList'),
        confirmMessage = "Are you sure you want to delete Award? You will not able to restore it and all users will lose this award.";

    $awardList.on('click', '.btn_deleteAward', function (e) {
        if (confirm(confirmMessage)) {
            var $target = $(e.target),
                $listItem = $target.closest('li'),
                awardId = $listItem.data('id');

            $.ajax({
                url: '/awards/deleteAward',
                type: 'post',
                data: { awardId: awardId }
            })
                .done(function () {
                    $listItem.remove();
                })
                .fail(function () {
                    alert("Cannot delete award.");
                })
        }
        else {
            return;
        }
    })
})();