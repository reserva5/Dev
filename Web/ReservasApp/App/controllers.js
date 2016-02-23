(function (angular) {
    'use strict';

    var controllers = angular.module('controllers', []);

    //#region HomeCtrl
    controllers.controller('HomeCtrl', ['$scope', function ($scope) {
        $scope.title = 'Home';
    }]);
    //#endregion

    //#region NavCtrl
    controllers.controller('NavCtrl', ['$scope', '$location',
        function ($scope, $location) {
            $scope.getClass = function (button) {
                var path = $location.path();
                if (path.indexOf(button) === 0) {
                    return 'active';
                } else {
                    return '';
                }
            };
        }]);
    //#endregion

    //#region LoginCtrl
    controllers.controller('LoginCtrl', ['$scope', '$http', 'auth', 'store', '$location',
    function ($scope, $http, auth, store, $location) {
        $scope.login = function () {
            auth.signin({}, function (profile, token) {
                // Success callback
                store.set('profile', profile);
                store.set('token', token);
                $location.path('/');
            }, function () {
                // Error callback
            });
        }
    },
    function ($scope, $http, auth, store, $location) {
        $scope.logout = function () {
            auth.signout();
            store.remove('profile');
            store.remove('token');
        }
    }
    ]);
    //controllers.controller('LoginCtrl', ['$scope', '$safeApply', 'authService', '$rootScope', '$auth',
    //    function($scope, $safeApply, authService, $rootScope, $auth) {
    //        $scope.userName = '';
    //        $scope.password = '';
    //        $scope.rememberMe = false;

    //        $scope.signIn = function() {
    //            $auth.login($scope.userName, $scope.password, $scope.rememberMe)
    //                .then(function (data) {
    //                    $safeApply($scope, function() {
    //                        $rootScope.userName = data.userName;
    //                    });
    //                    authService.loginConfirmed({
    //                            user: data.userName
    //                        },
    //                        function(config) {
    //                            config.headers.Authorization = data.Authorization;
    //                            return config;
    //                        });
    //                });
    //        };

    //        $scope.cancel = function() {
    //            authService.loginCanceled();
    //        };

    //    }]);
    //#endregion

})(window.angular);
    

