define(function (require) {
    router = require('plugins/router');

    return {
        router: router,
        activate: function () {
            router.map([
                { route: '', title: 'Home', moduleId: 'viewmodels/home', nav: true },
                { route: 'character/show', title: 'Characters', moduleId: 'viewmodels/character/show', nav: true },
                { route: 'character/create', title: 'Create', moduleId: 'viewmodels/character/create', nav: true }
            ]).buildNavigationModel();

            return router.activate();
        }
    };
});