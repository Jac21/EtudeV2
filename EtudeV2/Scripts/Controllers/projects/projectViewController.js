(function () {
    'use strict';

    angular.module('projectApp')
        .controller('projectViewController', projectViewController);

    // DI
    projectViewController.$inject = ['$routeParams', 'Project'];

    // pass projects service
    function projectViewController($routeParams, Project) {
        var vm = this;

        // data obtainment
        vm.project = Project.get({ projectId: $routeParams.projectId });
    }
})();