def knapsack_functional(capacity, weights, values, n=None):
    if n is None:
        n = len(weights)

    # Warunek końcowy
    if n == 0 or capacity == 0:
        return 0, []

    # Nie bierzemy przedmiotu
    if weights[n - 1] > capacity:
        return knapsack_functional(capacity, weights, values, n - 1)

    # Bierzemy przedmiot
    value_with_item, items_with_item = knapsack_functional(capacity - weights[n - 1], weights, values, n - 1)
    value_with_item += values[n - 1]

    # Nie bierzemy przedmiotu
    value_without_item, items_without_item = knapsack_functional(capacity, weights, values, n - 1)

    # Wybór lepszej opcji
    if value_with_item > value_without_item:
        return value_with_item, items_with_item + [n - 1]
    else:
        return value_without_item, items_without_item

# Przykład użycia
if __name__ == "__main__":
    capacity = 50
    weights = [10, 20, 30]
    values = [60, 100, 120]

    max_value, selected_items = knapsack_functional(capacity, weights, values)
    print("\nFunkcyjne podejście:")
    print(f"Maksymalna wartość: {max_value}")
    print(f"Wybrane przedmioty: {selected_items}")
