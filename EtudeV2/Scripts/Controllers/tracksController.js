(function() {
    'use strict';

    angular.module('trackApp')
        .controller('tracksController', tracksController);

    tracksController.$inject = ['$scope', 'Tracks'];

    function tracksController($scope, Tracks) {
        $scope.Tracks = Tracks.query();
    }
})();