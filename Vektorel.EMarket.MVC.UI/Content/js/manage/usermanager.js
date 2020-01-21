function OnLoginSuccess(response) {
    if (response.status) {
        $('#username').html('<div class="span6" id="username">Welcome!<strong>' + response.userfullname + '</strong></div>');
        $('#modalClose').click();
        $('#login').remove();
        $('#btnLogin').attr('href', '/logout');
        $('#btnLogin').html('<span class="btn btn-danger">Logout</span>')
        alertify.success(response.message);
    }
    else {
        alertify.error(response.message);
    }
}
