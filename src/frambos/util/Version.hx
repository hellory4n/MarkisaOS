package frambos.util;

class Version {
    public var major: UInt;
    public var minor: UInt;
    public var patch: UInt;

    public function new(major: UInt, minor: UInt, patch: UInt) {
        this.major = major;
        this.minor = minor;
        this.patch = patch;
    }
}