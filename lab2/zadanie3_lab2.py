def analyze_data(data):
    # Filtracja liczb
    numbers = list(filter(lambda x: isinstance(x, (int, float)), data))
    max_number = max(numbers) if numbers else None

    # Filtracja napisów
    strings = list(filter(lambda x: isinstance(x, str), data))
    longest_string = max(strings, key=len) if strings else None

    # Filtracja krotek
    tuples = list(filter(lambda x: isinstance(x, tuple), data))
    longest_tuple = max(tuples, key=len) if tuples else None

    return {
        "max_number": max_number,
        "longest_string": longest_string,
        "longest_tuple": longest_tuple
    }


# Przykład użycia
data = [3, "hello", (1, 2, 3), 5.5, "world", (1, 2), (1, 2, 3, 4, 5), [1, 2, 3], {"key": "value"}]
result = analyze_data(data)

# Wyświetlanie wyników
print("Największa liczba:", result["max_number"])
print("Najdłuższy napis:", result["longest_string"])
print("Krotka o największej liczbie elementów:", result["longest_tuple"])
