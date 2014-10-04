//Контроллер создания сообщения
myApp.controller('CreateCtrl', ['$scope', '$q', 'userSvc', 'webapi', '$http', '$location', '$routeParams', 'userMailSvc', function ($scope, $q, userSvc, webapi, $http, $location, $routeParams, userMailSvc) {
    $scope.users = [];
    $scope.userRecieve = '';
    $scope.message = {};
    $scope.selectedOption = {};
    $scope.title = '';
    $scope.text = '';

    userSvc.query().$promise.then(function (data) {
        $scope.users = data;
        $scope.selectedOption = $scope.users[0];
    });

    var repeat = function () {
        if ($routeParams.param == null || $routeParams.param == '') {
            return;
        }

        webapi.get({ id: $routeParams.param }).$promise.then(function (data) {
            $scope.title = "Re:" + data.Subject;
        });

        userMailSvc.get({ messId: $routeParams.param }).$promise.then(function (data2) {
            $scope.userRecieve = data2.Mail;
        });

        var selectUser = function (users, reciever) {
            for (var i = 0; i < users.length; i++) {
                if (users[i].Email == reciever) {
                    return users[i];
                }
            }
            return users[0];
        };

        $scope.selectedOption = selectUser($scope.users, $scope.userRecieve);
    };

    repeat();

    ///Отправка сообщения
    $scope.sendmessage = function () {
        $scope.message = { Subject: $scope.title, Body: $scope.text, Reciever: $scope.selectedOption.Email };

        $http.post("/api/Message", $scope.message).success(function (data, status) {
            $location.url('/');
        });

    };
}]);