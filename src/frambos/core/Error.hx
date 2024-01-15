package frambos.core;

/**
 * It's like `Result<T>` but there's no result.
 */
enum Error {
    Success;
    Error(message: String);
}