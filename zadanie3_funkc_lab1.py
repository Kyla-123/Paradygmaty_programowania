class Task:
    def __init__(self, execution_time, reward):
        self.execution_time = execution_time
        self.reward = reward

def schedule_tasks_procedural(tasks):
    # Sortowanie zadań według czasu wykonania
    tasks.sort(key=lambda task: task.execution_time)

    total_wait_time = 0
    total_reward = 0
    schedule = []

    for task in tasks:
        total_wait_time += task.execution_time
        total_reward += task.reward
        schedule.append(task)

    return schedule, total_wait_time, total_reward

# Przykład użycia
if __name__ == "__main__":
    tasks = [
        Task(2, 100),
        Task(1, 50),
        Task(3, 150)
    ]

    scheduled_tasks, total_wait_time, total_reward = schedule_tasks_procedural(tasks)

    print("Proceduralne podejście:")
    for i, task in enumerate(scheduled_tasks):
        print(f"Zadanie {i + 1}: Czas: {task.execution_time}, Nagroda: {task.reward}")
    print(f"Całkowity czas oczekiwania: {total_wait_time}")
    print(f"Całkowita nagroda: {total_reward}")
