var myApp = angular.module('myApp', ['ngRoute', 'ngResource', 'infinite-scroll']);

myApp.constant('routes', (function () {
    return {
        Messages: '/api/Messages'
    };
}));

myApp.config(['$routeProvider', 'routes', function ($routeProvider, routes) {

    var pathToIncs = '/Scripts/app/views/';

    $routeProvider.when('/', { templateUrl: pathToIncs + 'messages.html', controller: 'HomeCtrl' });
    $routeProvider.when('/Create', { templateUrl: pathToIncs + 'create.html', controller: 'CreateCtrl' });
    $routeProvider.when('/Createmess/:param', { templateUrl: pathToIncs + 'create.html', controller: 'CreateCtrl' });
    $routeProvider.otherwise({ redirectTo: '/' });
}
]);