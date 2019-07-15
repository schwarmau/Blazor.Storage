var storagePrototype = Storage.prototype;

window.blazorStorage = {
    getStorageProperty: function (storageType, propertyName) {
        return window[storageType][propertyName];
    },

    callStorageMethod: function (storageType, methodName, args) {
        return storagePrototype[methodName].apply(window[storageType], args);
    }
};