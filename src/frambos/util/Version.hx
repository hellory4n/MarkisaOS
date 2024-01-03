package frambos.util;

class Version {
    public var major: Int;
    public var minor: Int;
    public var patch: Int;

    public function new(major: Int, minor: Int, patch: Int) {
        this.major = major;
        this.minor = minor;
        this.patch = patch;
    }
}