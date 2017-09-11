var myApp = angular.module('myApp', []);

myApp.controller('myAppCtrl', function myAppCtrl($scope, $http) {

    $scope.showSingletonExample = false;
    $scope.showFactorialCalc = false;
    $scope.showFolderSizeCalc = false;


    $scope.singletonExample = {};
    $scope.singletonExample.showResult = false;

    $scope.factorialCalc = {};
    $scope.factorialCalc.showResult = false;

    $scope.folderSizeCalc = {};
    $scope.folderSizeCalc.showResult = false;


    $scope.showSingletonExampleForm = function () {
        $scope.showSingletonExample = true;
        $scope.showFactorialCalc = false;
        $scope.showFolderSizeCalc = false;
    }

    $scope.showFactorialCalculator = function () {
        $scope.showSingletonExample = false;
        $scope.showFactorialCalc = true;
        $scope.showFolderSizeCalc = false;
    }

    $scope.showFolderSizeCalculator = function () {
        $scope.showSingletonExample = false;
        $scope.showFactorialCalc = false;
        $scope.showFolderSizeCalc = true;
    }


    $scope.singletonExample.perform = function () {

        $http.post('/home/PerformSingleton', { model: { FirstName: $scope.singletonExample.firstName, LastName: $scope.singletonExample.lastName } })
            .then(function (res) {
                if (res.data.IsSuccessful) {
                    $scope.displayResult($scope.singletonExample, res.data.Data);
                } else {
                    $scope.displayErrorMessage($scope.singletonExample, res.data.Message);
                }
            },
            function (err) {
                $scope.displayErrorMessage($scope.singletonExample, err.statusText);
            }
        );
    }

    $scope.factorialCalc.calculate = function () {
        var input = tryParseInt($scope.factorialCalc.input);
        if (!input) {
            $scope.displayErrorMessage($scope.factorialCalc, "Invalid input");
            return;
        }

        if (input > 16) {
            $scope.displayErrorMessage($scope.factorialCalc, "Invalid input");
            return;
        }

        $http.post('/home/FactorialCalculator', { input: $scope.factorialCalc.input })
            .then(function (res) {
                if (res.data.IsSuccessful) {
                    $scope.displayResult($scope.factorialCalc, res.data.Data);
                } else {
                    $scope.displayErrorMessage($scope.factorialCalc, res.data.Message);
                }
            },
            function (err) {
                $scope.displayErrorMessage($scope.factorialCalc, err.statusText);
            }
        );
    }


    $scope.folderSizeCalc.calculate = function () {
        $http.post('/home/FolderSizeCalculator')
            .then(function (res) {
                if (res.data.IsSuccessful) {
                    $scope.displayResult($scope.folderSizeCalc, res.data.Data);
                } else {
                    $scope.displayErrorMessage($scope.folderSizeCalc, res.data.Message);
                }
            },
            function (err) {
                $scope.displayErrorMessage($scope.folderSizeCalc, err.statusText);
            }
        );
    }

    $scope.displayErrorMessage = function (obj, message){
        obj.showResult = false;
        obj.errorMessage = message;
        obj.showErrors = true;
    }

    $scope.displayResult = function (obj, result) {
        obj.result = result;
        obj.showResult = true;
        obj.showErrors = false;
    }

    function tryParseInt(str, defaultValue) {
        if (/^\d+$/g.test(str) === true)
            return parseInt(str);

        return defaultValue;
    }

});