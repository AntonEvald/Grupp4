function SendRequest(id) {
    $.ajax({
        url: '/FriendsController/SendFriendRequest',
        data: { id: id }
    }).done(function () {
        alert('Added');
    });
}