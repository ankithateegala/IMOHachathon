﻿(function () {
    'use strict';

    var myApp = angular.module('app', []);
    myApp.controller('MainController',['$scope', function ($scope) {
        $scope.showMe = false;
        $scope.myFunc = function () {
            $scope.showMe = !$scope.showMe;
        }
    }]);

    myApp.factory('whatsItFactory',
    ['$http', function ($http) {
        return{
                get: function (url) {
                return $http.get(url);
        }
    };
    }])

    myApp.controller('whatsItController', ['$scope', 'whatsItFactory', function ($scope, whatsItFactory) {
        var url = 'http://imohackathon-1.xrzyyed2vm.us-west-2.elasticbeanstalk.com/api/Acronyms';
        whatsItFactory.get(url).success(function (data) {
            $scope.rowCollection = data;

        }).error(function (error) {
            // log errors
        });
    }])

    myApp.controller('LogController', ['$scope', 'whatsItFactory', function ($scope, whatsItFactory) {
        var url = 'http://imohackathon-1.xrzyyed2vm.us-west-2.elasticbeanstalk.com/api/Log';
        whatsItFactory.get(url).success(function (data) {
            
            $scope.rowCollection = data;
            $scope.columnColletion = [
                { label: 'Acronym Name', map: 'AcronymName' },
                { label: 'Request Times', map: 'AppearTimes' }
            ];
        }).error(function (error) {
            // log errors
        });
    }])


})();