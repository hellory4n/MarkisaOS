package frambos.core;

enum Error<E: EnumValue> {
    Success;
    Error(error: E);
}