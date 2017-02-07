
define(['services/services'], function (services) {
    'use strict';
    services.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

        var serviceBase = 'http://localhost:31832/';// ngAuthSettings.apiServiceBaseUri;
        var authServiceFactory = {};

        var authentication = {
            isAuth: false,
            userName: "",
            useRefreshTokens: false
        };

        //var _externalAuthData = {
        //    provider: "",
        //    userName: "",
        //    externalAccessToken: ""
        //};

        var saveRegistration = function (registration) {

          //  _logOut();

            return $http.post(serviceBase + 'api/accounts/register', registration).then(function (response) {
                return response;
            });

        };

        var login = function (loginData) {

            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

            //if (loginData.useRefreshTokens) {
            //    data = data + "&client_id=" + ngAuthSettings.clientId;
            //}

            var deferred = $q.defer();

            $http.post(serviceBase + 'oauth/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                //if (loginData.useRefreshTokens) {
                //    localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
                //}
                //else {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
                //}
                authentication.isAuth = true;
                authentication.userName = loginData.userName;
                authentication.useRefreshTokens = loginData.useRefreshTokens;

                authServiceFactory.authentication = authentication;
                
                //localStorageService.cookie.set('_token', 'oatmeal');

                deferred.resolve(response);

            }).error(function (err, status) {
                 _logOut();
                deferred.reject(err);
            });

            return deferred.promise;

        };

        var _logOut = function () {

            localStorageService.remove('authorizationData');

            authentication.isAuth = false;
            authentication.userName = "";
            authentication.useRefreshTokens = false;

        };

        var fillAuthData = function () {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                authentication.isAuth = true;
                authentication.userName = authData.userName;
                authentication.useRefreshTokens = authData.useRefreshTokens;
            }

        };

        var _forgotPass = function(forgotPass) {
            return $http.post(serviceBase + 'api/accounts/forgotpassword', forgotPass).then(function(response) {
                return response;
            });
        };
        //var _refreshToken = function () {
        //    var deferred = $q.defer();

        //    var authData = localStorageService.get('authorizationData');

        //    if (authData) {

        //        if (authData.useRefreshTokens) {

        //            var data = "grant_type=refresh_token&refresh_token=" + authData.refreshToken + "&client_id=" + ngAuthSettings.clientId;

        //            localStorageService.remove('authorizationData');

        //            $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

        //                localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: response.refresh_token, useRefreshTokens: true });

        //                deferred.resolve(response);

        //            }).error(function (err, status) {
        //                _logOut();
        //                deferred.reject(err);
        //            });
        //        }
        //    }

        //    return deferred.promise;
        //};

        //var _obtainAccessToken = function (externalData) {

        //    var deferred = $q.defer();

        //    $http.get(serviceBase + 'api/account/ObtainLocalAccessToken', { params: { provider: externalData.provider, externalAccessToken: externalData.externalAccessToken } }).success(function (response) {

        //        localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: "", useRefreshTokens: false });

        //        _authentication.isAuth = true;
        //        _authentication.userName = response.userName;
        //        _authentication.useRefreshTokens = false;

        //        deferred.resolve(response);

        //    }).error(function (err, status) {
        //        _logOut();
        //        deferred.reject(err);
        //    });

        //    return deferred.promise;

        //};

        //var _registerExternal = function (registerExternalData) {

        //    var deferred = $q.defer();

        //    $http.post(serviceBase + 'api/account/registerexternal', registerExternalData).success(function (response) {

        //        localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: "", useRefreshTokens: false });

        //        _authentication.isAuth = true;
        //        _authentication.userName = response.userName;
        //        _authentication.useRefreshTokens = false;

        //        deferred.resolve(response);

        //    }).error(function (err, status) {
        //        _logOut();
        //        deferred.reject(err);
        //    });

        //    return deferred.promise;

        //};

        authServiceFactory.saveRegistration = saveRegistration;
        authServiceFactory.login = login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = fillAuthData;
        authServiceFactory.authentication = authentication;
        //authServiceFactory.refreshToken = _refreshToken;

        //authServiceFactory.obtainAccessToken = _obtainAccessToken;
        //authServiceFactory.externalAuthData = _externalAuthData;
        //authServiceFactory.registerExternal = _registerExternal;
        authServiceFactory.forgotPass = _forgotPass;
        return authServiceFactory;
    }]);

});