myApp.controller('HomeCtrl', ['$scope', 'webapi', '$http', 'userSvc', '$timeout', '$rootScope', 'notificationFactory', 'Reddit', function ($scope, webapi, $http, userSvc, $timeout, $rootScope, notificationFactory, Reddit) {
    $scope.reddit = new Reddit();
    $scope.messages = [];
    $scope.users = userSvc.query();
    $scope.countmess = 0;
    $scope.newMessages = [];
    $scope.severalmessages = [];
    $scope.pageNum = 0;
    
    //Удалить сообщение
    $scope.deletemess = function (message) {
        $http.delete("/api/Message", { params: { id: message.Id } }).success(function (data) {
            var index = $scope.reddit.items.indexOf(message);
            $scope.reddit.items.splice(index, 1);
            $scope.countmess -= 1;
        });
    };

    //Запрос на получение новых сообщений
    $scope.refreshmess = function () {
        webapi.query().$promise.then(function (res) {
            $scope.newMessages = res;

            for (var i = 0; i < $scope.newMessages.length; i++) {


                if ($scope.newMessages[i].CreatedOn > $scope.reddit.items[0].CreatedOn) {
                    $scope.reddit.items.unshift($scope.newMessages[i]);
                }
            }
            $scope.countmess = $scope.messages.length;
        });
    };

    $scope.onTimeout = function () {
        $scope.refreshmess();
        mytimeout = $timeout($scope.onTimeout, 10000);
    };
    var mytimeout = $timeout($scope.onTimeout, 10000);


}]);