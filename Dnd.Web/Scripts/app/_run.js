$(function () {
    var app = new AppViewModel(new AppDataModel());

    // Activate Knockout
    ko.validation.init({ grouping: { observable: false } });
    ko.applyBindings(app);
});
