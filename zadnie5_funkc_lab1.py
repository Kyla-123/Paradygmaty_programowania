from functools import reduce


class Task:
    def __init__(self, start, end, reward):
        self.start = start
        self.end = end
        self.reward = reward


def schedule_tasks_functional(tasks):
    # Sortowanie zadań według czasu zakończenia
    sorted_tasks = sorted(tasks, key=lambda task: task.end)

    def select_tasks(tasks):
        selected_tasks = []
        last_end_time = 0

        for task in tasks:
            if task.start >= last_end_time:  # Sprawdzenie, czy zadanie nie koliduje
                selected_tasks.append(task)
                last_end_time = task.end

        return selected_tasks

    selected_tasks = select_tasks(sorted_tasks)
    total_reward = reduce(lambda acc, task: acc + task.reward, selected_tasks, 0)

    return total_reward, selected_tasks


# Przykład użycia
if __name__ == "__main__":
    tasks = [
        Task(1, 3, 50),
        Task(2, 5, 20),
        Task(4, 6, 30),
        Task(6, 8, 40),
        Task(5, 7, 10)
    ]

    max_reward, selected_tasks = schedule_tasks_functional(tasks)

    print("\nFunkcyjne podejście:")
    print(f"Maksymalna nagroda: {max_reward}")
    print("Wybrane zadania:")
    for task in selected_tasks:
        print(f"Zadanie: Start: {task.start}, End: {task.end}, Reward: {task.reward}")
