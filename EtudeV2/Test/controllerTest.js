describe('projectsController', function () {
    
    beforeEach(module('projectApp'));
    
    it('scopeTestSpec',
        inject(function ($controller, $rootScope) {
            var $scope = $rootScope.$new();
            $controller('projectsController', {
                $scope: $scope
            });
            expect($scope).toEqual($scope);
        }));
});