// Explicit type declaration
String name = 'Voyager I';
int year = 1977;
double antennaDiameter = 3.7;
bool isLaunched = true;

// Type inference using 'var'
var flybyObjects = ['Jupiter', 'Saturn', 'Uranus', 'Neptune']; // List<String>
var image = { // Map<String, Object>
  'tags': ['saturn'],
  'url': '//path/to/saturn.jpg',
};

// Printing variables with string interpolation
print('Name: $name');
print('Year: $year');
print('Flyby objects: $flybyObjects');
