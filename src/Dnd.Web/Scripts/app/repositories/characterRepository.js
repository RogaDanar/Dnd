define(function (require) {

    return {
        _lastId: 0,
        _characters: [
        ],

        listCharacters: function () {
            return this._characters;
        },

        createCharacter: function (newCharacter) {
            newCharacter.id = ++this._lastId;
            this._characters.push(newCharacter);
        },

        getCharacter: function (id) {
            for (var i = 0; i < this._characters.length; i++) {
                if (this._characters[i].id == id) {
                    return this._characters[i];
                    break;
                }
            }
        }

    };
});