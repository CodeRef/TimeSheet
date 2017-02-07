var Lock = function () {
    return {
        //main function to initiate the module
        init: function () {
            $.backstretch([
                "../../Content/themes/metronic/assets/admin/pages/media/bg/5.jpg",
                "../../Content/themes/metronic/assets/admin/pages/media/bg/6.jpg",
                "../../Content/themes/metronic/assets/admin/pages/media/bg/7.jpg",
                "../../Content/themes/metronic/assets/admin/pages/media/bg/8.jpg",
                "../../Content/themes/metronic/assets/admin/pages/media/bg/9.jpg",
                "../../Content/themes/metronic/assets/admin/pages/media/bg/10.jpg",
                "../../Content/themes/metronic/assets/admin/pages/media/bg/11.jpg"
            ], {
                    fade: 1000,
                    duration: 8000
                });
        }
    };
}();