(function () {

    var app = angular.module('MyApp', []);

    app.controller('TaxiFareController', function ($scope) {
        $scope.Submit = function ()
        {
            $scope.Total = $scope.DistanceTraveledUnder6Mph * 10;
        }
        $scope.Clear = function () {
            $scope.DistanceTraveledUnder6Mph = "";
            $scope.DistanceTraveledOver6Mph = "";
            $scope.Total = "";
            $scope.DateOfTrip = null;
            $scope.TimeOfTrip = null;
        }
    });
})();