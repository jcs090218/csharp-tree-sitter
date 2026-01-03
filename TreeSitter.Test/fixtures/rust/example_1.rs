fn main() {
    // This variable is immutable by default.
    let foo = 10;
    println!("The value of foo is {foo}");

    // To allow modification, use the 'mut' keyword.
    let mut bar = 20;
    println!("The value of bar is {bar}");
    bar = 30;
    println!("The new value of bar is {bar}");
}
