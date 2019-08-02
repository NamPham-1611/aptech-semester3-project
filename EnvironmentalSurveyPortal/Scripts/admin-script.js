function requestDeleteUser(uid) {
    Swal.fire({
        title: 'Are you sure you want to delete this user ?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            $.get(
                "/Admin/DeleteUser/" + uid,
                function (res) {
                    window.location.reload();
                }
            );
        }
    });
}