import numpy as np
from functools import reduce

def combine_matrices(matrices, operation):
    """Łączy macierze za pomocą zdefiniowanej operacji."""
    # Dynamiczne wywołanie operacji
    return reduce(lambda x, y: eval(f"{x} {operation} {y}"), matrices)

# Przykład użycia
if __name__ == "__main__":
    # Definiowanie macierzy
    matrix1 = np.array([[1, 2], [3, 4]])
    matrix2 = np.array([[5, 6], [7, 8]])
    matrix3 = np.array([[1, 1], [1, 1]])

    matrices = [matrix1, matrix2, matrix3]

    # Wybór operacji: " + " lub " @ " (mnożenie)
    operation = input("Wybierz operację (suma: '+', mnożenie: '@'): ")

    if operation == "+":
        result = combine_matrices(matrices, "+")
    elif operation == "@":
        result = combine_matrices(matrices, "@")
    else:
        print("Nieznana operacja.")
        result = None

    # Wyświetlanie wyniku
    if result is not None:
        print("Wynik operacji:")
        print(result)
