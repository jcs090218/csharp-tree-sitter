def multiply = { x, y -> x * y } // A closure for multiplication
def applyOperation(operation, a, b) {
    return operation(a, b)
}

def result2 = applyOperation(multiply, 3, 4)
println("Multiplication: ${result2}") // Output: Multiplication: 12
