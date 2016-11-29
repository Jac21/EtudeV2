(function () {
    'use strict';

    angular.module('projectApp')
        .controller('projectCreateController', projectCreateController);

    // DI
    projectCreateController.$inject = ['$routeParams', '$location', 'Project'];

    // pass projects service
    function projectCreateController($routeParams, $location, Project) {
        var vm = this;

        // controller variables
        vm.newProject = new Project();
        vm.message = '';

        // submittal function
        vm.submit = function () {
            console.log(vm.newProject);

            vm.newProject.$save(
                function() {
                    $location.path('/api/projects');
                },
                function(response) {
                    alert('Something messed up!');
                });
        }
    }
})();