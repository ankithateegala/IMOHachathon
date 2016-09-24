(function () {
    'use strict';

    var myApp =  angular.module('app', []);
    myApp.controller('MainController', main);

    function main() {
    }

    ]);

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
        $scope.companies = [
                    {
                        'name': 'Infosys Technologies',
                        'employees': 125000,
                        'headoffice': 'Bangalore'
                    },
                        {
                            'name': 'Cognizant Technologies',
                            'employees': 100000,
                            'headoffice': 'Bangalore'
                        },
                            {
                                'name': 'Wipro',
                                'employees': 115000,
                                'headoffice': 'Bangalore'
                            },
                                {
                                    'name': 'Tata Consultancy Services (TCS)',
                                    'employees': 150000,
                                    'headoffice': 'Bangalore'
                                },
                                    {
                                        'name': 'HCL Technologies',
                                        'employees': 90000,
                                        'headoffice': 'Noida'
                                    },
        ];
        whatsItFactory.get(url).success(function (data) {
            $scope.acronymns = data;
        //}).error(function (error) {
        //    // log errors
        });
    }])



})();