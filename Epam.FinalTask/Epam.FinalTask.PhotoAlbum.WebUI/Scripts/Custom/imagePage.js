(function () {
    var $imageId = $('#imageId'),
        $btnBanImage = $('#banImage'),
        $btnUnbanImage = $('#unbanImage'),
        $likesCount = $('#likesCount'),
        $btnLike = $('#btnLike'),
        $btnUnlike = $('#btnUnlike'),
        $btnDeleteImage = $('#deleteImage'),
        $commentsList = $('#commentsList'),
        commentText = document.getElementById('commentText'),
        charCount = document.getElementById('charCount'),
        btnSubmit = document.getElementById('btnSubmit');

    commentText.oninput = function () {
        var text = commentText.value;
        charCount.innerText = 140 - text.length;
        if (text.length > 140) {
            charCount.className = 'charCountNotValid';
            btnSubmit.disabled = true;
        } else {
            charCount.className = 'charCountValid';
            btnSubmit.disabled = false;
        }
    }

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
        } else {
            return;
        }
    })

    $commentsList.on('click', '.btnCommentDelete', function (e) {
        var $target = $(e.target),
            $listItem = $target.closest('li'),
            commentId = $listItem.data('commentid');

        if (confirm('Are you sure you want to delete this comment? You will not be able to restore it.')) {
            $.ajax({
                url: '/Comments/DeleteComment',
                type: 'post',
                data: { commentId: commentId }
            })
                .done(function () {
                    $listItem.remove();
                })
                .fail(function () {
                    alert('Cannot delete this comment');
                })
        } else {
            return;
        }
    })

    $commentsList.on('click', '.btnCommentBan', function (e) {
        var $target = $(e.target),
            $listItem = $target.closest('li'),
            commentId = $listItem.data('commentid'),
            $btnBan = $listItem.find('.btnCommentBan'),
            $btnUnban = $listItem.find('.btnCommentUnban'),
            $textUnbanned = $listItem.children('.textUnbanned'),
            $textBanned = $listItem.children('.textBanned');

        $.ajax({
            url: '/Comments/BanComment',
            type: 'post',
            data: { commentId: commentId }
        })
            .done(function () {
                $btnBan.toggleClass('hidden');
                $btnUnban.toggleClass('hidden');
                $textBanned.removeClass('hidden');
                $textUnbanned.addClass('hidden');
            })
            .fail(function () {
                alert('Cannot ban this comment.');
            })
    })

    $commentsList.on('click', '.btnCommentUnban', function (e) {
        var $target = $(e.target),
            $listItem = $target.closest('li'),
            commentId = $listItem.data('commentid'),
            $btnBan = $listItem.find('.btnCommentBan'),
            $btnUnban = $listItem.find('.btnCommentUnban'),
            $textUnbanned = $listItem.children('.textUnbanned'),
            $textBanned = $listItem.children('.textBanned');

        $.ajax({
            url: '/Comments/UnbanComment',
            type: 'post',
            data: { commentId: commentId }
        })
            .done(function () {
                $btnBan.toggleClass('hidden');
                $btnUnban.toggleClass('hidden');
                $textUnbanned.removeClass('hidden');
                $textBanned.addClass('hidden');
            })
            .fail(function () {
                alert('Cannot unban this comment.');
            })
    })
})();