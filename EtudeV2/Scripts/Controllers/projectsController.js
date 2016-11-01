(function() {
    'use strict';

    angular.module('projectApp')
        .controller('projectsController', projectsController);

    // DI
    projectsController.$inject = ['$scope', '$routeParams', 'Projects'];

    // pass projects service
    function projectsController($scope, $routeParams, Projects) {
        // controller variables
        $scope.newProject = {};
        $scope.message = '';

        // data obtainment
        $scope.project = Projects.get({ projectId: $routeParams.projectId });
        $scope.Projects = Projects.query();

        // submittal function
        $scope.submit = function() {
            $scope.message = '';

            console.log($scope.newProject);
        }
    }
})();