(function () {
    'use strict';

    // has dependency on project service
    angular.module('projectApp', [
        'trackApp',
        'projectsService',
        'projectViewService',
        'projectCreateService',
        'ngRoute'
    ]).config([
    '$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/splash-page', {
                templateUrl: '/partials/structure/splash-page.html',
                controller: 'projectsController'
            }).
            when('/learn', {
                templateUrl: '/partials/structure/learn.html',
                controller: 'projectsController'
            }).
            when('/api/projects', {
                templateUrl: '/partials/projects/project-list.html',
                controller: 'projectsController'
            }).
            when('/api/projects/:projectId', {
                templateUrl: '/partials/projects/project-detail.html',
                controller: 'projectViewController'
            }).
            when('/create-project', {
                templateUrl: '/partials/projects/create-project.html',
                controller: 'projectCreateController'
            }).
            otherwise({
                redirectTo: '/splash-page'
            });
        }
    ]);
})();