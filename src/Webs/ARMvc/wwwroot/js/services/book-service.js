define(['services/services'], function (services) {
    // Book resource
    services.factory('BOOK', ['$resource', function ($resource) {
        var resetUrl = 'http://localhost:31832/api/values/get';//'/api/Book';
        var resource = $resource(resetUrl, {}, { get: { method: 'GET', isArray: true } });

        return resource;
    }]);
    //// MUST ADD TOKEN BEFORE SEND REQUEST TO SERVER.
    //// BookLoader
    //services.factory('BookLoader', ['$q', 'BOOK', function ($q, BOOK) {
    //    return function () {
    //        var delay = $q.defer();
    //        BOOK.get(function (data) {
    //            delay.resolve(data);
    //        }, function (error) {
    //            delay.reject('Unable to fetch Book list');
    //        });
    //        return delay.promise;
    //    };
    //}]);
});