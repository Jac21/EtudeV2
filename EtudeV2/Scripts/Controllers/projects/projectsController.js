(function() {
    'use strict';

    angular.module('projectApp')
        .controller('projectsController', projectsController);

    // DI
    projectsController.$inject = ['Projects'];

    // pass projects service
    function projectsController(Projects) {
        var vm = this;

        // data obtainment
        vm.Projects = Projects.query();
    }
})();