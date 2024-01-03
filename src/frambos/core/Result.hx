package frambos.core;

/**
 * Can represent either a result or an error represented by an enum. This is a better alternative to exceptions, I think.
 */
enum Result<T, E:EnumValue> {
	Success(data:T);
	Error(error:E);
}
