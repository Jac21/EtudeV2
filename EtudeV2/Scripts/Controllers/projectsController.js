(function() {
    'use strict';

    angular.module('projectApp')
        .controller('projectsController', projectsController);

    // DI
    projectsController.$inject = ['$scope', 'Projects'];

    // pass projects service
    function projectsController($scope, Projects) {
        $scope.Projects = Projects.query();
    }
})();