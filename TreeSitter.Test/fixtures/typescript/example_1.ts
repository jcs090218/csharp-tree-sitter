// Function with typed parameters and return type
const sum = (a: number, b: number): number => {
  return a + b;
};

// Example usage
console.log(sum(5, 10)); // Output: 15

// Function with an optional parameter (using ?) and default value
const buildName = (firstName: string, lastName?: string, middleName: string = "Smith"): string => {
    if (lastName) {
        return firstName + " " + middleName + " " + lastName;
    }
    return firstName + " " + middleName;
};
