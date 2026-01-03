A = [1 2; 3 4] # A 2x2 matrix
# Output:
# 2×2 Matrix{Int64}:
#  1  2
#  3  4

println("Maximum value:", maximum(A))       #> Maximum value: 4
println("Maximum of abs2 element-wise:", maximum(abs2, A)) # maximum of the square of each element

x = [1, 2, 3, 4]
y = sin.(x) # apply sin function to each element using the dot operator
println(y)
