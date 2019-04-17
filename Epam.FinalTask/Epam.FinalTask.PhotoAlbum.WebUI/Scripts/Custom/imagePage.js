(function () {
    var $imageId = $('#imageId'),
        $likesCount = $('#likesCount'),
        $btnLike = $('#btnLike'),
        $btnUnlike = $('#btnUnlike');

    $btnLike.on('click', function () {
        var visitorId = $btnLike.data('visitorid'),
            imageId = $imageId.data('imageid'),
            likesNum = $likesCount.text();

        $.ajax({
            url: '/Images/LikeImage',
            type: 'post',
            data: {
                imageId: imageId,
                visitorId: visitorId
            }
        })
            .done(function () {
                $btnLike.addClass('hidden');
                $btnUnlike.removeClass('hidden');
                $likesCount.text(+likesNum + 1 + '');
            })
            .fail(function () {
                alert('Impossible to like image.');
            })
    })

    $btnUnlike.on('click', function () {
        var visitorId = $btnLike.data('visitorid'),
            imageId = $imageId.data('imageid'),
            likesNum = $likesCount.text();

        $.ajax({
            url: '/Images/UnlikeImage',
            type: 'post',
            data: {
                imageId: imageId,
                visitorId: visitorId
            }
        })
            .done(function () {
                $btnLike.removeClass('hidden');
                $btnUnlike.addClass('hidden');
                $likesCount.text(+likesNum - 1 + '');
            })
            .fail(function () {
                alert('Impossible to unlike image.');
            })
    })
})();