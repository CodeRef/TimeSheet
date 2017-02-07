
require.config({
    baseUrl: "/js",
    waitSeconds: 200,
    paths: {
        'angular': '../lib/angular/angular.min',
        'jquery': '../lib/jquery/dist/jquery.min',
        'moment': '../lib/momentjs/min/moment.min',
        'respond': '../lib/respond/dest/respond.src',
        'domReady': '../lib/requirejs-domready/domReady',
        'bootstrap': '../lib/bootstrap/dist/js/bootstrap.min',

        'angular.animate': '../lib/angular-animate/angular-animate.min',
        'angular.cookies': '../lib/angular-cookies/angular-cookies.min',
        'angular.resource': '../lib/angular-resource/angular-resource.min',
        'angular.route': '../lib/angular-route/angular-route.min',
        'angular.sanitize': '../lib/angular-sanitize/angular-sanitize.min',
        'angular-touch': '../lib/angular-touch/angular-touch.min',
        'uiBootstrap': '../lib/angular-ui-bootstrap-bower/ui-bootstrap.min',
        'uiBootstrapTpl': '../lib/angular-ui-bootstrap-bower/ui-bootstrap-tpls.min',
        'localStorageService': '../lib/angular-local-storage/dist/angular-local-storage.min',
       // 'jquery.backstretch': '../lib/jquery-backstretch/jquery.backstretch.min', //'../lib/angular-backstretch/angular-backstretch'
        'jquery.validation':'../lib/jquery-validation/dist/jquery.validate.min'
    },
    shim: {
        'moment': {
            exports: 'moment'
        },
        'angular': {
            deps: ['jquery', 'moment'],
            exports: 'angular'
        },
        'respond': {
            exports: 'respond'
        },

        'bootstrap': {
            deps: ['jquery'],
            exports: 'bootstrap'
        },

        'angular.animate': ['angular'],
        'angular.cookies': ['angular'],
        'angular.resource': ['angular'],
        'angular.route': ['angular'],
        'angular.sanitize': ['angular'],
        'angular-touch': ['angular'],
        'uiBootstrap': { deps: ['angular', 'bootstrap'], exports: 'uiBootstrap' },
        'uiBootstrapTpl': { deps: ['angular', 'uiBootstrap'] },
        'localStorageService': {
            deps: ["angular"],
            exports: "LocalStorageModule"
        },
        //'jquery.backstretch': {
        //    deps: ['jquery']
        //},
        'jquery.validation':{
            deps: ['jquery']
        }
    },
    urlArgs: "bust=" + (new Date()).getTime()
    //urlArgs: "bust=v4"
});