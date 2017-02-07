'use strict';

require([
        'angular',
        'app',
        'domReady',
        'controllers/home-controller',
        'controllers/login-controller',
        'controllers/book-controller',
        'services/book-service',
        'services/authInterceptorService',
        'services/authService',
        'bootstrap'
],
    function (angular, app, domReady) {
        var root = require.toUrl('.').split('.')[0];
        app.config([
            '$routeProvider', '$httpProvider', '$sceDelegateProvider', '$locationProvider',
            function ($routeProvider, $httpProvider, $sceDelegateProvider, $locationProvider) {
                // sec
                $sceDelegateProvider.resourceUrlWhitelist(['self', '.*']);

                // route
                $routeProvider.
                when('/', {
                    templateUrl: '/public/js/views/Home/partials/home-index.html',
                    controller: 'HomeCtrl',
                    resolve: {}
                }).
                when('/login', {
                    templateUrl: '/public/js/views/Home/partials/login.html',
                    controller: 'LoginCtrl',
                    resolve: {}
                }).
                when('/books', {
                    templateUrl: '/public/js/views/Home/partials/book.html',
                    controller: 'BookCtrl',
                    resolve: {}
                }).
                otherwise({
                    redirectTo: '/'
                });

                $httpProvider.interceptors.push('authInterceptorService');
            }
        ]).run([
            '$rootScope',
            function ($rootScope) {
                // global variable

                $rootScope.$safeApply = function ($scope, fn) {
                    $scope = $scope || $rootScope;
                    fn = fn || function () { };
                    if ($scope.$$phase) {
                        fn();
                    } else {
                        $scope.$apply(fn);
                    }
                };
            }
        ]).constant('$', $);

        domReady(function () {
            angular.bootstrap(document.body, ['myAngularApp']);

            $('html').addClass('ng-app: myAngularApp');
        });
    }
);