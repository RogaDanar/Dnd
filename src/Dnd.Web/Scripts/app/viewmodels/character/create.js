define(function (require) {
    var app = require('durandal/app');
    var ko = require('knockout');

    var characterRepository = require("repositories/characterRepository");

    return {
        activate: function () {
            this.newCharacter.Name("");
            this.newCharacter.Race("");
            this.newCharacter.Class("");
            this._characterAdded = false;
        },

        //canDeactivate: function () {
        //    if (this._characterAdded == false) {
        //        return app.showMessage('Are you sure you want to leave this page?', 'Navigate', ['Yes', 'No']);
        //    } else {
        //        return true;
        //    }
        //},

        newCharacter: {
            Name: ko.observable(),
            Race: ko.observable(),
            Class: ko.observable()
        },

        create: function () {
            characterRepository.createCharacter(ko.toJS(this.newCharacter));
            this._characterAdded = true;
            router.navigate('#/character/show');
        }
    };
});