def knapsack_procedural(capacity, weights, values):
    n = len(weights)
    dp = [[0 for _ in range(capacity + 1)] for _ in range(n + 1)]

    # Budowanie tablicy dp
    for i in range(1, n + 1):
        for w in range(1, capacity + 1):
            if weights[i - 1] <= w:
                dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - weights[i - 1]] + values[i - 1])
            else:
                dp[i][w] = dp[i - 1][w]

    # Wyznaczanie przedmiotów w plecaku
    result_value = dp[n][capacity]
    w = capacity
    items = []

    for i in range(n, 0, -1):
        if result_value != dp[i - 1][w]:
            items.append(i - 1)  # dodajemy indeks przedmiotu
            w -= weights[i - 1]
            result_value -= values[i - 1]

    return dp[n][capacity], items

# Przykład użycia
if __name__ == "__main__":
    capacity = 50
    weights = [10, 20, 30]
    values = [60, 100, 120]

    max_value, selected_items = knapsack_procedural(capacity, weights, values)
    print("Proceduralne podejście:")
    print(f"Maksymalna wartość: {max_value}")
    print(f"Wybrane przedmioty: {selected_items}")
