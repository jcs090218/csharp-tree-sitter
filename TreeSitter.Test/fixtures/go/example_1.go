package main

import "fmt"
import "math/cmplx"

func main() {
    // Standard declaration
    var i int = 1
    // Short variable declaration (type inferred)
    j := 2
    
    // Example of basic types
    ToBe := false
    MaxInt := uint64(1<<64 - 1)
    z := cmplx.Sqrt(-5 + 12i)

    fmt.Println("i:", i, "j:", j)
    fmt.Printf("Type: %T Value: %v\n", ToBe, ToBe)
    fmt.Printf("Type: %T Value: %v\n", MaxInt, MaxInt)
    fmt.Printf("Type: %T Value: %v\n", z, z)
}
