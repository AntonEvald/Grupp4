var button = $("#createBtn");
button.click(function (e) {
    e.preventDefault();
    var form = button.parent().parent();
    var data = form.serialize();
    $.post("/api/Book/Create", data, r => console.log("YAY"));
});