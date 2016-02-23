/* main: startup script creates the 'app' module */

(function (window, angular, toastr) {
    'use strict';
    
    //#region configure toastr
    toastr.options.closeButton = true;
    toastr.options.newestOnTop = false;
    toastr.options.positionClass = 'toast-bottom-right';
    //#endregion

    window.app = angular.module('app', [

        //ng modules
        'ngRoute',
        'ngAnimate',
        'ngResource',

        //custom modules
        'services',
        'directives',
        'controllers',
        'http-auth-interceptor',
        'interceptors',

        //Auth0
        'auth0',
        'angular-storage',
        'angular-jwt'

    ]).config(function (authProvider) {
        authProvider.init({
            domain: 'reserva5.auth0.com',
            clientID: 'qbWAkM7t2sojJOuLBTBrc4r1U7patqtq'
        });
    }).run(function(auth) {
        // This hooks al auth events to check everything as soon as the app starts
        auth.hookEvents();
    });

    var exceptionHandler = function (e) {
        toastr.error(e.message || e);
    };

    // Angular dependency injection
    // http://www.youtube.com/watch?feature=player_embedded&v=1CpiB3Wk25U#t=2253s

    app.value('$exceptionHandler', exceptionHandler);

    //#region Configure routes
    app.config(['$routeProvider', '$locationProvider', 
        function($routeProvider, $locationProvider) {
            $routeProvider.
                when('/home', { templateUrl: 'App/views/home.html', controller: 'HomeCtrl' }).
                //when('/todos',
                //    {
                //        templateUrl: 'App/views/todos.html',
                //        controller: 'TodosCtrl',
                //        resolve: {
                //            authentication: ['$http', function ($http) {
                //                return $http.get('api/Account/Ping');
                //            }]
                //        }
                //    }).
                //when('/about', { templateUrl: 'App/views/about.html', controller: 'AboutCtrl' }).
                //when('/settings',
                //    {
                //        templateUrl: 'App/views/settings.html',
                //        controller: 'SettingsCtrl',
                //        resolve: {
                //            authentication: ['$http', function($http) {
                //                return $http.get('api/Account/Ping');
                //            }]
                //        }
                //    }).
                //when('/logs', { templateUrl: 'App/views/logs.html', controller: 'LogsCtrl' }).
                otherwise({ redirectTo: '/home' });

            $locationProvider.html5Mode(false).hashPrefix('!');
        }]);
    //#endregion

    app.run(['$rootScope', '$location', '$window', '$auth',
        function($rootScope, $location, $window, $auth) {
            $rootScope.today = new Date();

            $auth.loadSaved().then(function (data) {
                $rootScope.userName = data.userName;
            });

            $rootScope.$on('$routeChangeError', function(event, current, previous) {
                if (previous) {
                    $location.path(previous.originalPath);
                } else {
                    $window.location.reload();
                }
            });
        }]);

    //app.config(function (authProvider, $routeProvider, $httpProvider, jwtInterceptorProvider) {
    //    // ...

    //    // We're annotating this function so that the `store` is injected correctly when this file is minified
    //    jwtInterceptorProvider.tokenGetter = ['store', function (store) {
    //        // Return the saved token
    //        return store.get('token');
    //    }];

    //    $httpProvider.interceptors.push('jwtInterceptor');
    //    // ...
    //});

})(window, angular, toastr);