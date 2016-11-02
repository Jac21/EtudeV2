(function () {
    'use strict';

    angular.module('projectApp')
        .controller('projectCreateController', projectCreateController);

    // DI
    projectCreateController.$inject = ['$scope', '$routeParams', 'Project'];

    // pass projects service
    function projectCreateController($scope, $routeParams, Project) {
        // controller variables
        $scope.newProject = {};
        $scope.message = '';

        // submittal function
        $scope.submit = function () {
            $scope.message = '';

            console.log($scope.newProject);
        }
    }
})();