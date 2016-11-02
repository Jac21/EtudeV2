(function () {
    'use strict';

    var projectCreateService = angular.module('projectCreateService', ['ngResource']);
    projectCreateService.factory('Project', [
        '$resource',
        function ($resource) {
            // performs AJAX on route
            return $resource('/api/projects/:projectId', { projectID: '@projectID' }, null);
        }
    ]);
})();