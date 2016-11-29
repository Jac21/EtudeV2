(function() {
    'use strict';

    angular.module('trackApp')
        .controller('trackCreateController', trackCreateController);

    trackCreateController.$inject = ['$routeParams', '$location', 'Track'];

    function trackCreateController($routeParams, $location, Track) {
        var vm = this;

        // controller variables
        vm.newTrack = new Track();
        vm.message = '';

        // add function
        vm.add = function () {
            console.log(vm.newTrack);

            vm.newTrack.$save(
                function() {
                    $location.path('/api/projects/');
                },
                function(response) {
                    alert('Something messed up!');
                });
        }
    }
})();