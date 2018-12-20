(function () {

    var app = angular.module('MyApp', []);

    app.controller('TaxiFareController', function ($scope, GetTotalFare) {

        $scope.Submit = function () {
            GetTotalFare.GetFareForTrip($scope.TaxiFare).then(function (result) {
                $scope.Total = result.data;
            })
        }
        $scope.Clear = function () {
            $scope.DistanceTraveledUnder6Mph = "";
            $scope.TimeTraveledOver6Mph = "";
            $scope.Total = "";
            $scope.DateOfTrip = null;
            $scope.TimeOfTrip = null;
        }
    });
    app.factory('GetTotalFare', ['$http', '$q', function ($http, $q) {
        return {
            GetFareForTrip : function (TaxiFare) {
                var promise = $q.defer();
                $http.post('/TaxiFare/GetFare', TaxiFare).then(function (result) {
                    promise.resolve(result);
                });
                return promise;
            }
        }
    }]);
})();