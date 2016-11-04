(function() {
    'use strict';

    var trackViewService = angular.module('trackViewService', ['ngResource']);
    trackViewService.factory('Track', [
        '$resource',
        function($resource) {
            return $resource('/api/tracks/:trackId', {trackID:'@trackID'}, null);
        }
    ]);
})();