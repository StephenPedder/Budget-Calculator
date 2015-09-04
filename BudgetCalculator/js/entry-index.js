//entry-index.js
var module = angular.module("entryIndex", ['ngRoute']);

module.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "entryController",
        templateUrl: "/templates/entryView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
}]);

module.controller("entryController", function ($scope, $http, dataService) {
    $scope.data = dataService;
    $scope.isBusy = false;

    if (dataService.isReady() == false) {
        $scope.isBusy = true;
        dataService.getBudgets()
        .then(function () {
            // success
        },
        function () {
            // error
            alert("Could not load topics");
        })
        .then(function () {
            $scope.isBusy = false;
        });
    }
});