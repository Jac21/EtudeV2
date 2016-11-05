(function() {
    'use strict';

    angular.module('trackApp')
        .controller('trackCreateController', trackCreateController);

    trackCreateController.$inject = ['$scope', '$routeParams', '$location', 'Track'];

    function trackCreateController($scope, $routeParams, $location, Track) {
        // controller variables
        $scope.newTrack = new Track();
        $scope.message = '';

        // add function
        $scope.add = function () {
            console.log($scope.newTrack);

            $scope.newTrack.$save(
                function() {
                    $location.path('/api/projects/');
                },
                function(response) {
                    alert('Something messed up!');
                });
        }
    }
})();