// A very basic fragment shader
void main() {
    // gl_FragColor is a built-in output variable that holds the final color of the fragment.
    // vec4 is a 4-component vector used to represent color (R, G, B, A).
    // The values are floats ranging from 0.0 to 1.0.
    gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0); // This sets the color to solid red.
}
