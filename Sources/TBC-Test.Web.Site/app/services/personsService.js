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

    var _saveUpdate = function (person) {

        if (person.id == undefined || person.id == 0) {
            return $http.post(serviceBase + "persons", person).then(function (results) {
                return results;
            });
        } else {
            return $http.put(serviceBase + "persons", person).then(function (results) {
                return results;
            });
        }
    };

    var _deletePerson = function (id) {
        return $http.delete(serviceBase + "persons/" + id).then(function(results) {
             return results;
        });
    }

    personsServiceFactory.getPersons = _getPersons;
    personsServiceFactory.getPerson = _getPerson;
    personsServiceFactory.saveUpdate = _saveUpdate;
    personsServiceFactory.delete = _deletePerson;

    return personsServiceFactory;

}]);