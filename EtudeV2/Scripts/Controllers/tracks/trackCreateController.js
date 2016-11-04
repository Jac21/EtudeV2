(function() {
    'use strict';

    angular.module('trackApp')
        .controller('trackCreateController', trackCreateController);

    trackCreateController.$inject = ['$scope', '$routeParams', 'Track'];

    function trackCreateController($scope, $routeParams, Track) {
        // controller variables
        $scope.newTrack = {};
        $scope.message = '';

        // add function
        $scope.add = function () {
            $scope.message = '';

            console.log($scope.newTrack);
        }
    }
})();