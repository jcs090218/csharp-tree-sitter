# `compile.py`
#
# Here we used to compile all the grammar bundle.

import os
import glob
import sys
import pathlib
import subprocess

def find_grammar_js(directory, exclude_dirs=None):
    """
      Finds all 'grammar.js' files recursively under a given directory using glob.

      Args:
          directory (str): The root directory to start the search from.

      Returns:
          list: A list of absolute paths to the 'grammar.js' files.
    """
    exclude_dirs = set(exclude_dirs or [])

    search_pattern = os.path.join(directory, '**', 'grammar.js')
    files = glob.glob(search_pattern, recursive=True)

    def is_allowed(path):
        parts = set(os.path.normpath(path).split(os.sep))
        return not parts & exclude_dirs

    return [f for f in files if is_allowed(f)]

def compile_target(grammar):
    """
      Compile the grammar at path.
    """

    dir = pathlib.Path(grammar).parent

    # Old dir.
    cwd = os.getcwd()

    # Guess the grammar name.
    name = pathlib.Path(grammar).parent.name

    # Navigate to the grammar.js file's directory.
    os.chdir(dir)

    subprocess.run("npm install", shell=True, check=True)

    bin_dir = f"{cwd}/bin"

    print(f"?? {bin_dir}/{name}")

    subprocess.run(f'tree-sitter build -o "{bin_dir}/{name}"', shell=True, check=True)

    # Revert back
    os.chdir(cwd)

def main():
    """
      Program Entry point.
    """

    if len(sys.argv) > 1:
        grammar_files = find_grammar_js('./repos')

        print(f"Found {len(grammar_files)} 'grammar.js' files:")

        for file_path in grammar_files:
            print(file_path)

            compile_target(file_path)


if __name__ == "__main__":
    main()
