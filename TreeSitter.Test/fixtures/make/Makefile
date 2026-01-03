# Variables for compiler and flags
CC = gcc
CFLAGS = -Wall -g
TARGET = hello
SOURCE = hello.c

# Default target: builds the 'hello' executable
all: $(TARGET)

# Rule to build the executable from the source file
$(TARGET): $(SOURCE)
	$(CC) $(CFLAGS) $(SOURCE) -o $(TARGET)

# Rule to clean up generated files
clean:
	rm -f $(TARGET)
