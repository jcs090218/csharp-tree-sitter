// A simple function with no parameters or return value
func sayHello() {
    print("Hello, Swift!")
}

sayHello() // Calls the function

// A function with parameters and a return value
func greeting(for person: String) -> String {
    return "Hello, " + person + "!"
}

print(greeting(for: "Dave")) // Calls the function and prints the result
