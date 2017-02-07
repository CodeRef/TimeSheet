"use strict";

require([
        "jquery",
        "angular",
        "app",
        "domReady",
        "controllers/register-controller",
        "controllers/login-controller",
        "controllers/forgot-controller",
        "services/authInterceptorService",
        "services/authService",
        "bootstrap",
        "jquery.backstretch",
        "jquery.validation"
    ],
    function($, angular, app, domReady) {
        var root = require.toUrl(".").split(".")[0];
        app.config([
            "$routeProvider", "$httpProvider", "$sceDelegateProvider", "$locationProvider",
            function($routeProvider, $httpProvider, $sceDelegateProvider, $locationProvider) {
                // sec
                $sceDelegateProvider.resourceUrlWhitelist(["self", ".*"]);

                // route
                $routeProvider.when("/",
                {
                    templateUrl: "/public/js/views/Account/partials/login.html",
                    controller: "LoginCtrl",
                    resolve: {}
                }).when("/register",
                {
                    templateUrl: "/public/js/views/Account/partials/register.html",
                    controller: "RegisterCtrl"
                }).when("/forgotpass",
                {
                    templateUrl: "/public/js/views/Account/partials/forgot-pass.html",
                    controller: "FogotPassCtrl"
                }).otherwise({
                    redirectTo: "/"
                });

                $httpProvider.interceptors.push("authInterceptorService");
            }
        ]).run([
            "$rootScope",
            function($rootScope) {
                // global variable

                $rootScope.$safeApply = function($scope, fn) {
                    $scope = $scope || $rootScope;
                    fn = fn || function() {};
                    if ($scope.$$phase) {
                        fn();
                    } else {
                        $scope.$apply(fn);
                    }
                };
            }
        ]).constant("$", $);

        domReady(function() {
            angular.bootstrap(document.body, ["myAngularApp"]);

            $("html").addClass("ng-app: myAngularApp");
        });
    }
);