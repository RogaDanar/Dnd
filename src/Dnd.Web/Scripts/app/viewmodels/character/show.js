define(function (require) {
    var app = require('durandal/app'),
        ko = require('knockout');

    var characterRepository = require("repositories/characterRepository");

    return {
        characters: ko.observable(),

        activate: function () {
            this.characters(characterRepository.listCharacters());
        }
    };
});