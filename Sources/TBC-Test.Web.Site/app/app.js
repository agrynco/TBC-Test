
var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/persons", {
        controller: "personsController",
        templateUrl: "/app/views/persons.html"
    });
    $routeProvider.otherwise({ redirectTo: "/persons" });

});

var serviceBase = document.location.origin + "/api/";


app.run();


