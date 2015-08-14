require.config({
    paths: {
        'text': '../text',
        'durandal': '../durandal/',
        'plugins': '../durandal/plugins',
        'knockout': '../knockout-3.2.0',
        'jquery': '../jquery-2.1.1',
        'transitions': '../durandal/transitions'
    },
    urlArgs: "bust=" + (new Date()).getTime()
});

define(function (require) {
    var app = require('durandal/app'),
        system = require('durandal/system'),
        viewLocator = require('durandal/viewLocator'),
        viewEngine = require('durandal/viewEngine');

    // Overwrite the view location so views can be placed in the standard Views 
    // folder. App is routed to an AppController in RouteConfig
    viewLocator.useConvention('', '../../../App');
    // Change the standard html to cshtml, so it will be routed to a controller
    // .html normally bypasses the routes, unless it is set in web.config
    //  <add name="HtmlFileHandler" path="*.html" verb="GET" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" />
    viewEngine.viewExtension = ".cshtml";

    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.configurePlugins({
        router: true,
        dialog: true
    });

    app.start().then(function () {
        //Show the app by setting the root view model for our application.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});