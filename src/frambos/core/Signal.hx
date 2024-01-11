package frambos.core;

/**
 * Implements the [observer pattern](https://en.wikipedia.org/wiki/Observer_pattern). If you don't need any arguments, use `SignalNoArgs`
 */
class SignalArgs<T> {
    var subscribers: Array<T -> Void> = [];

    public function new() {}

    /**
     * Connects the signal to a function that returns void.
     */
    public function connect(callback: T -> Void) {
        subscribers.push(callback);
    }

    /**
     * Disconnects a function.
     */
    public function disconnect(callback: T -> Void) {
        subscribers.remove(callback);
    }

    /**
     * Emits the signal to everyone that's subscribed.
     */
    public function emit(args: T) {
        for (callback in subscribers) {
            callback(args);
        }
    }
}

/**
 * Implements the [observer pattern](https://en.wikipedia.org/wiki/Observer_pattern). If you need arguments, use `SignalArgs`
 */
class SignalNoArgs {
    var subscribers: Array<Void -> Void> = [];

    public function new() {}

    /**
     * Connects the signal to a function that returns void.
     */
    public function connect(callback: Void -> Void) {
        subscribers.push(callback);
    }

    /**
     * Disconnects a function.
     */
    public function disconnect(callback: Void -> Void) {
        subscribers.remove(callback);
    }

    /**
     * Emits the signal to everyone that's subscribed.
     */
    public function emit() {
        for (callback in subscribers) {
            callback();
        }
    }
}