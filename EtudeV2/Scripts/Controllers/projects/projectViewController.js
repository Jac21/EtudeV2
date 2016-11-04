(function () {
    'use strict';

    angular.module('projectApp')
        .controller('projectViewController', projectViewController);

    // DI
    projectViewController.$inject = ['$scope', '$routeParams', 'Project'];

    // pass projects service
    function projectViewController($scope, $routeParams, Project) {
        // data obtainment
        $scope.project = Project.get({ projectId: $routeParams.projectId });
    }
})();