!function (t) {
    "use strict";
    t("#sidebarToggle, #sidebarToggleTop").on("click", function (o) {
        t("body").toggleClass("sidebar-toggled"), t(".sidebar").toggleClass("toggled"), t(".sidebar").hasClass("toggled") && t(".sidebar .collapse").collapse("hide")
    }), t(window).resize(function () {
        t(window).width() < 768 && t(".sidebar .collapse").collapse("hide")
    }), t("body.fixed-nav .sidebar").on("mousewheel DOMMouseScroll wheel", function (o) {
        if (768 < t(window).width()) {
            var e = o.originalEvent,
                l = e.wheelDelta || -e.detail;
            this.scrollTop += 30 * (l < 0 ? 1 : -1), o.preventDefault()
        }
    }), t(document).on("scroll", function () {
        100 < t(this).scrollTop() ? t(".scroll-to-top").fadeIn() : t(".scroll-to-top").fadeOut()
    }), t(document).on("click", "a.scroll-to-top", function (o) {
        var e = t(this);
        t("html, body").stop().animate({
            scrollTop: 0
        }), o.preventDefault()
    }), t(document).on("click", "img.logout", function () {
        Swal.fire({
            title: 'Are you sure you want to sign out',
            text: 'Select "Logout" below if you are ready to end your current session',
            type: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Logout'
        }).then((result) => {
            if (result.value) {
                $.get(
                    "/Admin/Logout/",
                    function (res) {
                        window.location.reload();
                    }
                );
            }
        });
    });

}(jQuery);