(function() {
    'use strict';

    angular.module('projectApp')
        .controller('projectsController', projectsController);

    // DI
    projectsController.$inject = ['$scope', '$routeParams', 'Projects'];

    // pass projects service
    function projectsController($scope, $routeParams, Projects) {
        $scope.project = Projects.get({ projectId: $routeParams.projectId });
        $scope.Projects = Projects.query();
    }
})();