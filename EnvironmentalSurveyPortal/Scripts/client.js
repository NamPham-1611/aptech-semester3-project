function requestLogin(form, event) {
    event.preventDefault();
    var formData = new FormData(form);

    jQuery.ajax('/Home/CheckLogin', {
        type: "POST",
        processData: false,
        contentType: false,
        data: formData,
        success: function (res) {
            $("#loginModal .m-modal-body").html(res);
        }
    });
}

function requestRegister(form, event) {
    event.preventDefault();
    var formData = new FormData(form);

    jQuery.ajax('/Home/CheckRegister', {
        type: "POST",
        processData: false,
        contentType: false,
        data: formData,
        success: function (res) {
            $("#registerModal .m-modal-body").html(res);
        }
    });
}