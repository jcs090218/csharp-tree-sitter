import pathlib

cmake_file = pathlib.Path("./core/tree-sitter/CMakeLists.txt")

target_line = 'option(AMALGAMATED "Build using an amalgamated source" OFF)'
insert_line = 'set(CMAKE_WINDOWS_EXPORT_ALL_SYMBOLS ON)'

def main():
    """
      Program Entry point.
    """

    text = cmake_file.read_text(encoding="utf-8")

    # If already present, do nothing
    if insert_line in text:
        print("CMAKE_WINDOWS_EXPORT_ALL_SYMBOLS already set, skipping.")
        exit(0)


    lines = text.splitlines()
    output = []

    inserted = False

    for line in lines:
        output.append(line)
        if line.strip() == target_line and not inserted:
            output.append(insert_line)
            inserted = True

    if not inserted:
        raise RuntimeError("Target option line not found in CMakeLists.txt")

    cmake_file.write_text("\n".join(output) + "\n", encoding="utf-8")
    print("Inserted CMAKE_WINDOWS_EXPORT_ALL_SYMBOLS successfully.")

if __name__ == "__main__":
    main()
