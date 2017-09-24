"use strict";
app.controller("personsController",
    [
        "$scope", "personsService", function ($scope, personsService) {

            $scope.persons = [];

            var getPersons = function() {

                personsService.getPersons().then(function(results) {

                        $scope.persons = results.data;

                    },
                    function(error) {
                        console.log(error);
                        //alert(error.data.message);
                    });
            };

            getPersons();

            $scope.getPerson = function(personalNumber) {
                personsService.getPerson(personalNumber).then(function(results) {
                        $scope.personalNumber = results.data.personalNumber;
                        $scope.firstName = results.data.firstName;
                        $scope.lastName = results.data.lastName;
                        $scope.birthdate = results.data.birthdate;
                        $scope.gender = results.data.gender;
                        $scope.salary = results.data.salary;
                        $scope.id = results.data.id;
                    },
                    function(error) {
                        console.log(error);
                        //alert(error.data.message);
                    });
            };

            $scope.saveUpdate = function() {
                var person = {
                    personalNumber: $scope.personalNumber,
                    firstName: $scope.firstName,
                    lastName: $scope.lastName,
                    birthdate: $scope.birthdate,
                    gender: $scope.gender,
                    salary: $scope.salary,
                    id: ($scope.id == undefined || $scope.id === "") ? 0 : $scope.id
                }

                personsService.saveUpdate(person).then(function() {
                    getPersons();
                });
            };

            $scope.deletePerson = function (id) {
                if (confirm("Are you sure want to delete person?")) {
                    personsService.delete(id).then(function() {
                        getPersons();
                    });
                }
            }
        }
    ]);