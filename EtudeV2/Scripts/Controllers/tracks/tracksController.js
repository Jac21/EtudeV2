(function() {
    'use strict';

    angular.module('trackApp')
        .controller('tracksController', tracksController);

    tracksController.$inject = ['Tracks'];

    function tracksController(Tracks) {
        var vm = this;

        // controller variables
        vm.newTrack = {};
        vm.message = '';

        vm.Tracks = Tracks.query();

        // add function
        vm.add = function () {
            vm.message = '';

            console.log(vm.newTrack);
        }
    }
})();