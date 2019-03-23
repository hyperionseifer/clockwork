var CurrentTimeQuery = function(data) {
  var self = this;
  var properties = [
    'currentTimeQueryId', 'clientIp', 'time', 'timezoneId',
    'timezone', 'utcTime'
  ];
  properties.forEach(function(property) {
    self[property] = ko.observable(null);
  });

  self.time.text = ko.observable(null);
  self.utcTime.text = ko.observable(null);

  var syncFormattedTime = function(target) {
    target.text(moment(target()).format('DD-MMM-YYYY h:mm:ss A'));
  };

  self.time.subscribe(function() {
    syncFormattedTime(self.time);
  });
  self.utcTime.subscribe(function () {
    syncFormattedTime(self.utcTime);
  });

  if (typeof (data) != 'undefined' &&
      data &&
      typeof (data) == 'object')
    ko.mapping.fromJS(data, {}, self);
};