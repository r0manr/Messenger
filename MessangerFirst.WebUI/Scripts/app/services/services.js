//Сервисы

//Оповещения
myApp.factory('notificationFactory', function () {
    return {
        success: function (text) {
            toastr.success(text, "Success");
        },
        error: function (text) {
            toastr.error(text, "Error");
        }
    };
});

myApp.factory('webapi', ['$resource',
  function ($resource) {
      return $resource('api/Message/:id', {
          id: "@id"
      },
      {
          query: { method: 'GET', params: { id: '@id' }, isArray: true },
          get: { method: 'GET' },
          severalmessages: { method: 'GET', params: {}, isArray: true },
          deletemess: { method: 'DELETE' }
      });

  }]);

myApp.factory('userSvc', ['$resource',
  function ($resource) {
      return $resource('Home/GetUsers/:id:message', {
          id: "@id"
      },
      {
          query: { method: 'GET', params: { id: '@id' }, isArray: true },
          get: { method: 'GET' }
      });

  }]);

myApp.factory('userMailSvc', ['$resource',
  function ($resource) {
      return $resource('Home/GetRecieverMail/:id:message', {
          id: "@id"
      },
      {
          query: { method: 'GET', params: { id: '@id' }, isArray: true },
          get: { method: 'GET' }
      });

  }]);


//Модель для бесконечной прокрутки
myApp.factory('Reddit', ['webapi', function ( webapi) {
    var Reddit = function () {
        this.items = [];
        this.busy = false;
        this.after = '';
        this.pageNumber = 0;
    };

    Reddit.prototype.nextPage = function () {
        if (this.busy) return;
        this.busy = true;


        webapi.severalmessages({ pageNum: this.pageNumber, pageSize: '3' }).$promise.then(function (res) {
            var items = res;
            for (var i = 0; i < items.length; i++) {
                this.items.push(items[i]);
            }
            this.pageNumber += 1;
            this.busy = false;
        }.bind(this));
    };

    return Reddit;
}]);