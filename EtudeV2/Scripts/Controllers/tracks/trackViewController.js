(function() {
    'use strict';

    angular.module('trackApp')
        .controller('trackViewController', trackViewController);

    trackViewController.$inject = ['$scope', '$routeParams', 'Track'];

    function trackViewController($scope, $routeParams, Track) {
        // data obtainment
        $scope.track = Track.get({ trackId: $routeParams.trackId });
    }
})();