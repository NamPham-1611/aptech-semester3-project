function requestLogin(form, event) {
    event.preventDefault();
    var formData = new FormData(form);

    $.ajax('/Home/CheckLogin', {
        type: "POST",
        processData: false,
        contentType: false,
        data: formData,
        statusCode: {
            200: function (responseObject, textStatus, jqXHR) {
                window.location.reload();
            },
            201: function (res, textStatus, errorThrown) {
                $("#loginModal .m-modal-body").html(res);
            }
        }
    });
}

function requestRegister(form, event) {
    event.preventDefault();
    var formData = new FormData(form);

    $.ajax('/Home/CheckRegister', {
        type: "POST",
        processData: false,
        contentType: false,
        data: formData,
        statusCode: {
            200: function (responseObject, textStatus, jqXHR) {
                $("#registerModal").hide();

                Swal.fire({
                    title: 'Successful account registration !',
                    type: 'success',
                    showCancelButton: false,
                    confirmButtonText: 'Close'
                });

            },
            201: function (res, textStatus, errorThrown) {
                $("#registerModal .m-modal-body").html(res);
            }
        }
    });
}