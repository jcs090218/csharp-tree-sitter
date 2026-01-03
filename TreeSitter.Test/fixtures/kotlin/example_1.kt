// A function that returns the maximum of two integers
fun maxOf(a: Int, b: Int): Int { // Specifies Int parameters and Int return type
    if (a > b) {
        return a
    } else {
        return b
    }
}

// A more concise way to write the same function using expression syntax
fun maxOfConcise(a: Int, b: Int) = if (a > b) a else b

fun main() {
    println("Max of 0 and 42 is ${maxOf(0, 42)}")
    println("Max of 5 and 10 is ${maxOfConcise(5, 10)}")
}
