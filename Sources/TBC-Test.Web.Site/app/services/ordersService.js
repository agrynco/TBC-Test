'use strict';
app.factory('ordersService', ['$http', function ($http) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var ordersServiceFactory = {};

    var _getOrders = function () {

        return $http.get(serviceBase + 'orders').then(function (results) {
            return results;
        });
    };

    ordersServiceFactory.getOrders = _getOrders;

    return ordersServiceFactory;

}]);