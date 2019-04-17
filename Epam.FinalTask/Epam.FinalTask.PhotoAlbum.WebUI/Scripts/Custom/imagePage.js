(function () {
    var $imageId = $('#imageId'),
        $btnBanImage = $('#banImage'),
        $btnUnbanImage = $('#unbanImage'),
        $likesCount = $('#likesCount'),
        $btnLike = $('#btnLike'),
        $btnUnlike = $('#btnUnlike'),
        $btnDeleteImage = $('#deleteImage');

    $btnBanImage.on('click', function () {
        var imageId = $imageId.data('imageid');

        $.ajax({
            url: '/Images/BanImage',
            type: 'post',
            data: { imageId: imageId }
        })
            .done(function () {
                window.location.href = `/Images/ImagePage?imageId=${imageId}`;
            })
            .fail(function () {
                alert('Cannot ban this image.');
            })
    })

    $btnUnbanImage.on('click', function () {
        var imageId = $imageId.data('imageid');

        $.ajax({
            url: '/Images/UnbanImage',
            type: 'post',
            data: { imageId: imageId }
        })
            .done(function () {
                window.location.href = `/Images/ImagePage?imageId=${imageId}`;
            })
            .fail(function () {
                alert('Cannot unban this image.');
            })
    })

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

    $btnDeleteImage.on('click', function () {
        var imageId = $imageId.data('imageid');

        if (confirm('Are you sure you want to delete this image? You will not be able to restore it.')) {
            $.ajax({
                url: '/Images/DeleteImage',
                type: 'post',
                data: { imageId: imageId }
            })
                .done(function () {
                    window.location.href = "/Index";
                })
                .fail(function () {
                    alert("Cannot delete image.");
                })
        }
        else {
            return;
        }
    })
})();