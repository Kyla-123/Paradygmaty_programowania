import numpy as np


def validate_matrices(matrix_a, matrix_b, operation):
    """Walidacja zgodności wymiarów macierzy."""
    if operation == 'add':
        return matrix_a.shape == matrix_b.shape
    elif operation == 'multiply':
        return matrix_a.shape[1] == matrix_b.shape[0]
    return True  # Transponowanie nie wymaga walidacji


def matrix_operation(operation_str):
    """Wykonuje operację na macierzach."""
    try:
        # Wyciągamy macierze z operacji
        matrix_a, operation, matrix_b = eval(operation_str)

        # Walidacja
        if not validate_matrices(matrix_a, matrix_b, operation):
            raise ValueError("Nieprawidłowe wymiary macierzy dla operacji.")

        # Wykonanie operacji
        if operation == 'add':
            result = matrix_a + matrix_b
        elif operation == 'multiply':
            result = np.dot(matrix_a, matrix_b)
        elif operation == 'transpose':
            result = matrix_a.T
        else:
            raise ValueError("Nieznana operacja.")

        return result
    except Exception as e:
        return str(e)


# Przykład użycia
matrix_a = np.array([[1, 2], [3, 4]])
matrix_b = np.array([[5, 6], [7, 8]])

# Operacje w formie stringów
operations = [
    "(matrix_a, 'add', matrix_b)",
    "(matrix_a, 'multiply', matrix_b)",
    "(matrix_a, 'transpose', None)"  # Transponowanie nie wymaga drugiej macierzy
]

for operation in operations:
    result = matrix_operation(operation)
    print(f"Wynik operacji {operation}:")
    print(result)
