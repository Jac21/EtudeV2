(function() {
    'use strict';

    angular.module('trackApp', [
        'trackService',
        'ngRoute'
    ]).config([
        '$routeProvider',
        function($routeProvider) {
            $routeProvider.
                when('/api/tracks', {
                    templateUrl: '/partials/track-list.html',
                    controller: 'tracksController'
                }).
                when('/api/tracks/:trackId', {
                    templateUrl: '/partials/track-detail.html',
                    controller: 'tracksController'
                });
        }
    ]);
})();