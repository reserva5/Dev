(function () {
    'use strict';

    angular.module('http-auth-interceptor', ['http-auth-interceptor-buffer'])

    .factory('authService', ['$rootScope', 'httpBuffer', function ($rootScope, httpBuffer) {
        return {

            loginConfirmed: function (data, configUpdater) {
                var updater = configUpdater || function (config) { return config; };
                $rootScope.$broadcast('event:auth-loginConfirmed', data);
                httpBuffer.retryAll(updater);
            },

            loginCanceled: function(data) {
                $rootScope.$broadcast('event:auth-loginCanceled', data);
                httpBuffer.rejectAll();
            }
        };
    }])

    .config(['$httpProvider', function ($httpProvider) {

        var interceptor = ['$rootScope', '$q', 'httpBuffer', function ($rootScope, $q, httpBuffer) {
            var self = {};

            self.response = function(response) {
                if (response.status === 401 && !response.config.ignoreAuthModule) {
                    var deferred = $q.defer();
                    httpBuffer.append(response, deferred);
                    $rootScope.$broadcast('event:auth-loginRequired');
                    return deferred.promise;
                }

                return response;
            };

            return self;
        }];
        
        $httpProvider.interceptors.push(interceptor);
    }]);

    angular.module('http-auth-interceptor-buffer', [])

    .factory('httpBuffer', ['$injector', function ($injector) {
        var buffer = [];

        var $http;

        function retryHttpRequest(config, deferred) {
            function successCallback(response) {
                deferred.resolve(response);
            }
            function errorCallback(response) {
                deferred.reject(response);
            }
            $http = $http || $injector.get('$http');
            $http(config).then(successCallback, errorCallback);
        }

        return {
            append: function (response, deferred) {
                buffer.push({
                    response: response,
                    deferred: deferred
                });
            },

            retryAll: function (updater) {
                for (var i = 0; i < buffer.length; ++i) {
                    retryHttpRequest(updater(buffer[i].response.config), buffer[i].deferred);
                }
                buffer = [];
            },

            rejectAll: function () {
                for (var i = 0; i < buffer.length; ++i) {
                    buffer[i].deferred.reject(buffer[i].response);
                }
                buffer = [];
            }
        };
    }]);
})();