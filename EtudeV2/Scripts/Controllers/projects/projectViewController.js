(function () {
    'use strict';

    angular.module('projectApp')
        .controller('projectViewController', projectViewController);

    // DI
    projectViewController.$inject = ['$scope', '$routeParams', 'Project'];

    // pass projects service
    function projectViewController($scope, $routeParams, Project) {
        // controller variables
        $scope.newProject = {};
        $scope.message = '';

        // data obtainment
        $scope.project = Project.get({ projectId: $routeParams.projectId });

        // submittal function
        $scope.submit = function () {
            $scope.message = '';

            console.log($scope.newProject);
        }
    }
})();