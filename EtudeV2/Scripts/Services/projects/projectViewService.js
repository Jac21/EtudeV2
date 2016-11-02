(function () {
    'use strict';

    var projectViewService = angular.module('projectViewService', ['ngResource']);
    projectViewService.factory('Project', [
        '$resource',
        function ($resource) {
            // performs AJAX on route
            return $resource('/api/projects/:projectId', { projectID: '@projectID' }, null);
        }
    ]);
})();