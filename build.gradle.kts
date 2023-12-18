plugins {
    kotlin("jvm") version "1.9.21"
}

group = "com.hellory4n.markisaos"
version = "1.0-SNAPSHOT"

repositories {
    mavenCentral()
}

dependencies {
    testImplementation("org.jetbrains.kotlin:kotlin-test")
    implementation(kotlin("script-runtime"))
}

kotlin {
    jvmToolchain(17)
}