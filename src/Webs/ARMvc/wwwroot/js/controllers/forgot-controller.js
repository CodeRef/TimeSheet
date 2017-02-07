define(['controllers/controllers'], function (controllers) {
    controllers.controller('FogotPassCtrl', [
        '$scope', '$location', 'authService',
        function($scope, $location, authService) {

            $.backstretch([
                "../../Content/templates/metronic/assets/admin/pages/media/bg/5.jpg",
                "../../Content/templates/metronic/assets/admin/pages/media/bg/6.jpg",
                "../../Content/templates/metronic/assets/admin/pages/media/bg/7.jpg",
                "../../Content/templates/metronic/assets/admin/pages/media/bg/8.jpg",
                "../../Content/templates/metronic/assets/admin/pages/media/bg/9.jpg",
                "../../Content/templates/metronic/assets/admin/pages/media/bg/10.jpg",
                "../../Content/templates/metronic/assets/admin/pages/media/bg/11.jpg"
            ], {
                fade: 1000,
                duration: 8000
            });
            $scope.back = function() {
                $location.path('/login');
            };
            $scope.forgotPassData = {
                Email: ''
            };
            $scope.savedSuccessfully = false;
            var handleForgetPassword = function() {
                $('.forget-form').validate({
                    errorElement: 'span', //default input error message container
                    errorClass: 'help-block', // default input error message class
                    focusInvalid: false, // do not focus the last invalid input
                    ignore: "",
                    rules: {
                        email: {
                            required: true,
                            email: true
                        }
                    },

                    messages: {
                        email: {
                            required: "Email is required."
                        }
                    },

                    invalidHandler: function(event, validator) { //display error alert on form submit   

                    },

                    highlight: function(element) { // hightlight error inputs
                        $(element)
                            .closest('.form-group').addClass('has-error'); // set error class to the control group
                    },

                    success: function(label) {
                        label.closest('.form-group').removeClass('has-error');
                        label.remove();
                    },

                    errorPlacement: function(error, element) {
                        error.insertAfter(element.closest('.input-icon'));
                    },

                    submitHandler: function(form) {
                        //  form.submit();
                        authService.forgotPass($scope.forgotPassData).then(function(response) {
                            // window.location = '/';
                            $scope.savedSuccessfully = true;
                        }, function(err) {
                            $scope.message = err.error_description;
                        });
                    }
                });

                $('.forget-form input').keypress(function(e) {
                    if (e.which === 13) {
                        if ($('.forget-form').validate().form()) {
                            $('.forget-form').submit();
                        }
                    }
                    return false;
                });
            };
            handleForgetPassword();
        }
    ]);
});