(function () {
    'use strict';

    angular.module('projectApp')
        .controller('projectCreateController', projectCreateController);

    // DI
    projectCreateController.$inject = ['$scope', '$routeParams', '$location', 'Project'];

    // pass projects service
    function projectCreateController($scope, $routeParams, $location, Project) {
        // controller variables
        $scope.newProject = new Project();
        $scope.message = '';

        // submittal function
        $scope.submit = function () {
            console.log($scope.newProject);

            $scope.newProject.$save(
                function() {
                    $location.path('/api/projects');
                },
                function(response) {
                    alert('Something messed up!');
                });
        }
    }
})();