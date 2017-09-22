"use strict";
app.controller("profileController",
[
    "$scope", "$location", "humanApiService", "fitbitApiService", "localStorageService", "ngAuthSettings",
    function($scope, $location, humanApiService, fitbitApiService, localStorageService, ngAuthSettings) {
        var vm = this;

        vm.HumanApiConnectOptions = [];

        //TO DO : must provide in localStorageService user.Id from authentication And probably global variable (for clientID).
        humanApiService.getUserToken().then(function(results) {
                vm.HumanApiConnectOptions = results.data;
                setUserTokenOptions(vm.HumanApiConnectOptions);
            },
            function(error) {
                alert(error.data.message);
            });

        function setUserTokenOptions(ConnectOptions) {
            vm.optionsHAPI.clientUserId = encodeURIComponent(ConnectOptions.clientUserId);
            vm.optionsHAPI.clientId = ConnectOptions.clientId;
            vm.optionsHAPI.publicToken = ConnectOptions.publicToken;
        }

        vm.optionsHAPI = {
            clientUserId: "",
            clientId: "",
            publicToken: "",
            finish: function(err, sessionTokenObject) {
                //call web API to get and set human API user token
                humanApiService.savePublicTokenForTheUser(sessionTokenObject).then(function(response) {
                        console.log("success");
                        console.log(response);
                        vm.optionsHAPI.publicToken = response.publicToken;
                    },
                    function(response) {
                        var errors = [];
                        for (var key in response.modelState) {
                            errors.push(response.modelState[key]);
                        }
                        $scope.message = "Error humanApi !" + errors.join(" ");
                    });
            },
            close: function() {
                /* Optional callback called when a user closes the popup 
                   without connecting any data sources */
            },
            error: function(err) {
                /* Optional callback called if an error occurs when loading
                   the popup. */
                console.log(err);
                // `err` has fields: `code`, `message`, `detailedMessage`
            }
        };
        vm.openHumanApi = function() {
            HumanConnect.open(vm.optionsHAPI);
        };
        vm.openFitbitApi = function() {

            fitbitApiService.getAuthenticationUrl().then(function(authenticationUrl) {
                window.location.href = authenticationUrl.replace(/"/g, "");
            });
        };
        vm.uploadProfilePhoto = function() {
            var profilePhotoUploadForm = document.getElementById("uploadProfilePhotoForm");

            if (profilePhotoUploadForm != null) {

                var authorizationData = localStorageService.get("authorizationData");

                if (authorizationData != null) {
                    var profilePhotoUrl = ngAuthSettings.apiServiceBaseUri +
                        "account/profile/photo/upload?userName=" +
                        authorizationData.userName;

                    profilePhotoUploadForm.removeAttribute("action");
                    profilePhotoUploadForm.setAttribute("action", profilePhotoUrl);

                    profilePhotoUploadForm.submit();
                }
            }
        };
    }
]);