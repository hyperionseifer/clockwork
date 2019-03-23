var HomeViewModel = function() {
  var self = this;
  self.queryList = ko.observableArray([]);
  self.queryList.page = ko.observable(1);
  self.queryList.loading = ko.observable(false);
  self.requesting = ko.observable(false);
  self.result = new CurrentTimeQuery();
  self.hideResult = ko.observable(true);
  self.result.currentTimeQueryId.subscribe(function () {
    self.hideResult(!self.result.currentTimeQueryId());
  });
  self.requesting.subscribe(function () {
    var requesting = self.requesting();
    var $requestButton = $('.form-horizontal .btn.btn-primary');
    if (requesting)
      $requestButton.button('loading');
    else
      $requestButton.button('reset');
  });
  self.getQueryList = function (nextPage) {
    if (self.queryList.loading())
      return;

    var currentPage = self.queryList.page();
    var page = currentPage;
    if (nextPage)
      page = currentPage + 1;
    
    self.queryList.loading(true);
    app.apiRequest({
      path: '/api/currenttime/querylist?page=' + page
    }).done(function(response) {
      if (Array.isArray(response)) {
        response.forEach(function(item) {
          self.queryList.push(new CurrentTimeQuery(item));
        });

        if (nextPage &&
            response.length > 0)
          self.queryList.page(page); // if successful, update current page stamped into the client
      }
      self.queryList.loading(false);
    }).fail(function() {
      self.queryList.loading(false);
    });
  };
  self.loadNextQueryList = function () {
    self.getQueryList(true);
  };
  self.getTime = function() {
    if (self.requesting())
      return;

    self.requesting(true);
    self.result.currentTimeQueryId(null); // set to falsy value to hide the results pane
    var timezoneId = $('.form-horizontal .form-group .col-sm-10 select').val() || '';
    app.apiRequest({
      path: '/api/currenttime?timezoneId=' + timezoneId
    }).done(function (response) {
      if (typeof (response) != 'undefined' &&
          response &&
          typeof (response) == 'object' &&
          typeof (response.currentTimeQueryId) == 'number') {
        ko.mapping.fromJS(response, {}, self.result);

        // reset list
        self.queryList.removeAll(); // clear list
        self.queryList.page(0); // set page to 0
        self.loadNextQueryList(); // reload first page
      }
      self.requesting(false);
    }).fail(function() {
      self.requesting(false);
    });
  };
  self.initialize = function() {
    self.getQueryList();
  };
  $(document).ready(function() {
    self.initialize();
  });
};

if (typeof(app) != 'undefined' &&
    app instanceof WebApplication)
  app.vm = new HomeViewModel();