(function () {
    'use strict';

    var projectsService = angular.module('projectsService', ['ngResource']);
    projectsService.factory('Projects', [
        '$resource',
        function ($resource) {
            // performs AJAX on route
            return $resource('/api/projects', {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        }
    ]);
})();