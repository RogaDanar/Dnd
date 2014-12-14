require.config({
    paths: {
        'text': '../text',
        'durandal': '../durandal/',
        'plugins': '../durandal/plugins',
        'knockout': '../knockout-3.2.0',
        'jquery': '../jquery-2.1.1'
    }
});

define(function (require) {
    var app = require('durandal/app'),
        viewLocator = require('durandal/viewLocator'),
        system = require('durandal/system'),
        router = require('durandal/plugins/router');

    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");
    app.configurePlugins({
        router: true,
        dialog: true
    });
    app.start().then(function () {
        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('shell');
    });
});