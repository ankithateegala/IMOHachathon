(function () {
    'use strict';

    var myApp = angular.module('app', []);
    myApp.controller('MainController', main);

    function main() {
    }

    myApp.factory('whatsItFactory',
    [
        '$http', function($http) {
            return{
                get: function(url) {
                    return $http.get(url);
                }
            };
        }
    ]);
    window.keyWords = [];
    myApp.controller('whatsItController',
    [
        '$scope', 'whatsItFactory', function($scope, whatsItFactory) {
            var url = 'http://imohackathon-1.xrzyyed2vm.us-west-2.elasticbeanstalk.com/api/Acronyms';
            whatsItFactory.get(url)
                .success(function(data) {
                    $scope.rowCollection = data;
                    Object.keys(data).forEach(function (key) {
                        //get the value of name
                        var val = data[key]["Acronym"];
                        //push the name string in the array
                        if (val != null) {
                            window.keyWords.push(val);
                        }
                       
                    });
                    
                })
                .error(function(error) {
                    // log errors
                });
        }
    ]);


    myApp.controller('LogController',
    [
        '$scope', 'whatsItFactory', function($scope, whatsItFactory) {
            var url = 'http://imohackathon-1.xrzyyed2vm.us-west-2.elasticbeanstalk.com/api/Log';
            whatsItFactory.get(url)
                .success(function(data) {

                    $scope.rowCollection = data;
                    $scope.columnColletion = [
                        { label: 'Acronym Name', map: 'AcronymName' },
                        { label: 'Request Times', map: 'AppearTimes' }
                    ];
                })
                .error(function(error) {
                    // log errors
                });
        }
    ]);


})();