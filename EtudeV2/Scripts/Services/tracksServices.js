(function() {
    'use strict';

    var tracksService = angular.module('tracksService', ['ngResource']);
    tracksService.factory('Tracks', [
        '$resource',
        function($resource) {
            return $resource('/api/tracks', {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        }
    ]);
})();