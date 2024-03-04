
const Singleton = (function () {
    var instance;

    function createInstance() {
        let object = new Object("I am the instance");
        return object;
    }

    return {
        getInstance: function () {
            if (!instance) {
                instance = createInstance();
            }
            return instance;
        }
    };
})();

const firstSingletonInstance = Singleton.getInstance();
const secondSingletonInstance = Singleton.getInstance();

if (firstSingletonInstance === secondSingletonInstance) {
    console.log("The objects share the same instance");
}