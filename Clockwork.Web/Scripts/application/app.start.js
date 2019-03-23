$(document).ready(function () {
  if (typeof (app) != 'undefined' &&
      app instanceof WebApplication)
    ko.applyBindings(app);
});