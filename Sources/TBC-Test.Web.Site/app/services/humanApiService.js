'use strict';
app.factory('humanApiService', ['$http', '$q', 'ngAuthSettings', function ($http, $q, ngAuthSettings) {
   
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var humanApiServiceFactory = {};

    var _getUserToken = function () {

        return $http.get(serviceBase + 'humanapi/get-user-token').then(function (results) {
            return results;
        });
    };

    var _savePublicTokenForTheUser = function (sessionToken) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'humanapi/save-user-token', sessionToken)
        .success(function (response) {
            deferred.resolve(response);
        })
        .error(function (err, status) {
            deferred.reject(err);
        });

        return deferred.promise;
    }

    humanApiServiceFactory.getUserToken = _getUserToken;
    humanApiServiceFactory.savePublicTokenForTheUser = _savePublicTokenForTheUser;

    return humanApiServiceFactory;
}
]);
