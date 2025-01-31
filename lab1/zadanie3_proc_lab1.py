from functools import reduce

class Task:
    def __init__(self, execution_time, reward):
        self.execution_time = execution_time
        self.reward = reward

def schedule_tasks_functional(tasks):
    # Sortowanie zadań według czasu wykonania
    sorted_tasks = sorted(tasks, key=lambda task: task.execution_time)

    total_wait_time = reduce(lambda acc, task: acc + task.execution_time, sorted_tasks, 0)
    total_reward = reduce(lambda acc, task: acc + task.reward, sorted_tasks, 0)

    return sorted_tasks, total_wait_time, total_reward

# Przykład użycia
if __name__ == "__main__":
    tasks = [
        Task(2, 100),
        Task(1, 50),
        Task(3, 150)
    ]

    scheduled_tasks, total_wait_time, total_reward = schedule_tasks_functional(tasks)

    print("\nFunkcyjne podejście:")
    for i, task in enumerate(scheduled_tasks):
        print(f"Zadanie {i + 1}: Czas: {task.execution_time}, Nagroda: {task.reward}")
    print(f"Całkowity czas oczekiwania: {total_wait_time}")
    print(f"Całkowita nagroda: {total_reward}")
