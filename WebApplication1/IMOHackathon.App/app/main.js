(function () {
    'use strict';

    var myApp = angular.module('app', ['smart-table']);
    myApp.controller('MainController', main);

    function main() {
    }

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
            //$scope.acronymns = data;
            $scope.rowCollection = data;
            $scope.columnColletion = [
                { label: 'Acronym', map: 'Acronym' },
                { label: 'Full Name', map: 'Full_Name' },
                { label: 'Description', map: 'Description' }
            ];
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

    //var thumbsUp = element(by.css('span.glyphicon-thumbs-up'));
    //var thumbsDown = element(by.css('span.glyphicon-thumbs-down'));
    //it('should check ng-show / ng-hide', function () {
    //    expect(thumbsUp.isDisplayed()).toBeFalsy();
    //    expect(thumbsDown.isDisplayed()).toBeTruthy();

    //    element(by.model('whatsit')).click();
    //    element(by.model('checked')).click();

    //    expect(thumbsUp.isDisplayed()).toBeTruthy();
    //    expect(thumbsDown.isDisplayed()).toBeFalsy();
    //});

})();