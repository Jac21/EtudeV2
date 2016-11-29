(function() {
    'use strict';

    angular.module('trackApp')
        .controller('trackViewController', trackViewController);

    trackViewController.$inject = ['$routeParams', 'Track'];

    function trackViewController($routeParams, Track) {
        var vm = this;

        // data obtainment
        vm.track = Track.get({ trackId: $routeParams.trackId });
    }
})();