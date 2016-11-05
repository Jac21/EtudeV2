(function() {
    'use strict';

    var trackCreateService = angular.module('trackCreateService', ['ngResource']);
    trackCreateService.factory('Track', [
        '$resource',
        function($resource) {
            return $resource('/api/tracks', {trackID: '@trackID'},
            {
                save: {method: 'POST'}
            });
        }
    ]);
})();