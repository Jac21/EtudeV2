// http://proudmonkey.azurewebsites.net/asp-net-5-jump-start-to-angularjs-with-mvc-6-web-api/
(function () {
    'use strict';

    // has dependency on project service
    angular.module('projectApp', [
        'trackApp',
        'projectsService',
        'ngRoute'
    ]).config([
    '$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/splash-page', {
                templateUrl: '/partials/splash-page.html',
                controller: 'projectsController'
            }).
            when('/api/projects', {
                templateUrl: '/partials/project-list.html',
                controller: 'projectsController'
            }).
            when('/api/projects/:projectId', {
                templateUrl: '/partials/project-detail.html',
                controller: 'projectsController'
            }).
            otherwise({
                redirectTo: '/splash-page'
            });
        }
    ]);
})();