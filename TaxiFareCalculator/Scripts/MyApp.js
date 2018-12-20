(function () {

    var app = angular.module('MyApp', []);

    app.controller('TaxiFareController', function ($scope, GetTotalFare) {

        $scope.Submit = function (form) {
            if (form) {//if form.$valid == true
                GetTotalFare.GetFareForTrip($scope.TaxiFare).then(function (result) { //calls the GetFareForTrip function
                    $scope.Total = 'Your total Fare is: $' + result.data; //display total returned from the function
                })
            }
        }
        $scope.Clear = function () {
            $scope.TaxiFare.DistanceTraveledUnder6Mph = "";
            $scope.TaxiFare.TimeTraveledOver6Mph = "";
            $scope.TaxiFare.Total = "";
            $scope.TaxiFare.DateOfTrip = null;
            $scope.TaxiFare.TimeOfTrip = null;
            $scope.Total = null;
        }
    });
    app.factory('GetTotalFare', ['$http', '$q', function ($http, $q) {
        return {
            GetFareForTrip : function (TaxiFare) {
                var deferred = $q.defer();
                $http.post('/TaxiFare/GetFare', TaxiFare).then(function (result) {
                    deferred.resolve(result);
                });
                return deferred.promise;
            }
        }
    }]);
})();