(function() {
    'use strict';

    angular.module('projectApp')
        .controller('projectsController', projectsController);

    // DI
    projectsController.$inject = ['$scope', 'Projects'];

    // pass projects service
    function projectsController($scope, Projects) {
        // data obtainment
        $scope.Projects = Projects.query();
    }
})();