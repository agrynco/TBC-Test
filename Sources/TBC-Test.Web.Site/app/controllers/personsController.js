"use strict";
app.controller("personsController",
[
    "$scope", "personsService", function($scope, personsService) {

        $scope.persons = [];

        personsService.getPersons().then(function(results) {

            $scope.persons = results.data;

            },
            function(error) {
                console.log(error);
                //alert(error.data.message);
            });

    }
]);