'use strict';
app.factory('personsService', ['$http', function ($http) {

    var personsServiceFactory = {};

    var _getPersons = function () {

        return $http.get(serviceBase + 'persons').then(function (results) {
            return results;
        });
    };

    personsServiceFactory.getPersons = _getPersons;

    return personsServiceFactory;

}]);