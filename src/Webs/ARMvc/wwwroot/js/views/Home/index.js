'use strict';

require([
        'angular',
        'app',
        'domReady',
        'controllers/home/home',
        'controllers/home/login',
        'controllers/home/map',
        'controllers/home/zone',
        'services/authInterceptorService',
        'services/authService',
        'services/book-service',
        'services/map-service',
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
                    templateUrl: '/js/views/Home/partials/index.html',
                    controller: 'HomeCtrl',
                    resolve: {}
                }).
                when('/login', {
                    templateUrl: '/js/views/Home/partials/login.html',
                    controller: 'LoginCtrl',
                    resolve: {}
                }).
                when('/map', {
                    templateUrl: '/js/views/Home/partials/map.html',
                    controller: 'MapCtrl',
                    resolve: {}
                }).
                when('/zone', {
                    templateUrl: '/js/views/Home/partials/zone.html',
                    controller: 'ZoneCtrl',
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