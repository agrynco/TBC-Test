"use strict";
app.factory("fitbitApiService",
[
    "$http", "$q", "ngAuthSettings", function($http, $q, ngAuthSettings) {

        var serviceBase = ngAuthSettings.apiServiceBaseUri;

        var fitbitApiServiceFactory = {};

        var _getAuthenticationUrl = function() {

            return $http.post(serviceBase + "fitness-services/3/authorise-url").then(function(results) {
                console.log(results.data);
                return results.data.url;
            });
        };

        fitbitApiServiceFactory.getAuthenticationUrl = _getAuthenticationUrl;

        return fitbitApiServiceFactory;
    }
]);