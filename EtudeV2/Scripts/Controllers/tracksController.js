(function() {
    'use strict';

    angular.module('trackApp')
        .controller('tracksController', tracksController);

    tracksController.$inject = ['$scope', 'Tracks'];

    function tracksController($scope, Tracks) {
        // controller variables
        $scope.newTrack = {};
        $scope.message = '';

        $scope.Tracks = Tracks.query();

        // add function
        $scope.add = function () {
            $scope.message = '';

            console.log($scope.newTrack);
        }
    }
})();