'use strict';
app.factory('personsService', ['$http', function ($http) {

    var personsServiceFactory = {};

    var _getPersons = function () {

        return $http.get(serviceBase + 'persons').then(function (results) {
            return results;
        });
    };

    var _getPerson = function (personalNumber) {

        return $http.get(serviceBase + "persons/" + personalNumber).then(function (results) {
            return results;
        });
    };

    var _saveUpdate = function(person) {
        if (person.personalNumber == undefined) {
            return $http.post(serviceBase + "person", person).then(function(results) {
                return results;
            });
        } else {
            return $http.put(serviceBase + "person", person).then(function(results) {
                return results;
            });
        }
    };

    personsServiceFactory.getPersons = _getPersons;
    personsServiceFactory.getPerson = _getPerson;
    personsServiceFactory.saveUpdate = _saveUpdate;

    return personsServiceFactory;

}]);