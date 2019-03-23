var WebApplication = function () {
  var self = this;
  self.apiUrl = '';
  self.apiRequest = function(config) {
    if (typeof (config) != 'undefined' &&
        typeof (config) == 'object' &&
        config) {
      var url = self.apiUrl + (config.path || '');
      var method = config.method || 'GET';
      var settings = {
        'url': url,
        'method': method,
        dataType: 'json'
      };
      var payload = config.payload;
      if (typeof (payload) != 'undefined' &&
          payload &&
          typeof (payload) == 'object') {
        settings.data = JSON.stringify(payload);
        settings.contentType = 'application/json';
      }
      return $.ajax(settings);
    }
    return null;
  };
  self.vm = {};
};

var app = new WebApplication();