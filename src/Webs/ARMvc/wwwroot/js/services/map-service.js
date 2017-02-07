define(['services/services'], function (services) {
    // Book resource
    services.factory('MAP', ['$resource', function ($resource) {
        var resetUrl = 'http://localhost:31832/api/map/:id';//'/api/Book';
        var resource = $resource(resetUrl);
        return resource;
    }]);
});