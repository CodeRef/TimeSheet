'use strict';

require([
        'angular',
        'app',
        'domReady',
        'controllers/shelf-controller',
        'controllers/createshelf-controller',
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
                    templateUrl: '/public/js/views/Shelf/partials/index.html',
                    controller: 'ShelfCtrl',
                    resolve: {}
                }).
                when('/create', {
                    templateUrl: '/public/js/views/Shelf/partials/create.html',
                    controller: 'CreateShelfCtrl',
                    resolve: {}
                }).
                //when('/books', {
                //    templateUrl: '/public/js/views/Home/partials/book.html',
                //    controller: 'BookCtrl',
                //    resolve: {}
                //}).
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