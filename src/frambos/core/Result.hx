package frambos.core;

/**
 * Can represent either a result or an error represented by a number and an optional message. This is a better alternative to exceptions, I think.
 */
enum Result<T> {
	Success(data: T);
	Error(message: String);
}