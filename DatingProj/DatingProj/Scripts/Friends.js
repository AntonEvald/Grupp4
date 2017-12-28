function SendRequest(id) {
    $.ajax({
        url: '/FriendsController/SendFriendRequest',
        type: "POST",
        data: { id: id }
    }).done(function () {
        alert('Added');
    });
}