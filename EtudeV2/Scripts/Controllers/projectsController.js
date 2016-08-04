(function() {
    'use strict';

    angular.module('projectApp')
        .controller('projectsController', projectsController);

    // DI
    projectsController.$inject = ['$scope', 'Projects'];

    $scope.projectsList;

    // pass projects service
    function projectsController($scope, Projects) {
        $scope.Projects = Projects.query();
        $scope.projectsList = $scope.Projects;
    }

    function getProject(projectId) {
        $scope.projectsList.forEach(function(project) {
            if (project.Id === projectId) {
                return project;
            }
        });

        return null;
    }
})();