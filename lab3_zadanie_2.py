import json
import os

class Employee:
    def __init__(self, first_name, last_name, age, salary):
        self.first_name = first_name
        self.last_name = last_name
        self.age = age
        self.salary = salary

    def __str__(self):
        return f"Name: {self.first_name} {self.last_name}, Age: {self.age}, Salary: ${self.salary:.2f}"

    def to_dict(self):
        return {
            "first_name": self.first_name,
            "last_name": self.last_name,
            "age": self.age,
            "salary": self.salary
        }

    @staticmethod
    def from_dict(data):
        return Employee(data["first_name"], data["last_name"], data["age"], data["salary"])

class EmployeesManager:
    def __init__(self, file_path="employees.json"):
        self.file_path = file_path
        self.employees = self.load_employees()

    def load_employees(self):
        if os.path.exists(self.file_path):
            with open(self.file_path, "r", encoding="utf-8") as file:
                data = json.load(file)
                return [Employee.from_dict(emp) for emp in data]
        return []

    def save_employees(self):
        with open(self.file_path, "w", encoding="utf-8") as file:
            json.dump([emp.to_dict() for emp in self.employees], file, indent=4)

    def add_employee(self, employee):
        if isinstance(employee, Employee):
            self.employees.append(employee)
            self.save_employees()
        else:
            raise TypeError("Only Employee objects can be added.")

    def list_employees(self):
        return self.employees if self.employees else "No employees found."

    def remove_employees_by_age_range(self, min_age, max_age):
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]
        self.save_employees()

    def find_employee_by_name(self, first_name, last_name):
        return next((emp for emp in self.employees if emp.first_name.lower() == first_name.lower() and emp.last_name.lower() == last_name.lower()), None)

    def update_employee_salary(self, first_name, last_name, new_salary):
        employee = self.find_employee_by_name(first_name, last_name)
        if employee:
            employee.salary = new_salary
            self.save_employees()
            return True
        return False

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()
        self.admin_credentials = {"username": "admin", "password": "admin"}

    def authenticate(self):
        print("Login to the system:")
        username = input("Enter username: ")
        password = input("Enter password: ")
        if username == self.admin_credentials["username"] and password == self.admin_credentials["password"]:
            print("Login successful.")
            return True
        print("Invalid username or password.")
        return False

    def display_menu(self):
        print("\nEmployee System Menu:")
        print("1. Add an employee")
        print("2. Display all employees")
        print("3. Remove employees by age range")
        print("4. Find an employee by name")
        print("5. Update an employee's salary")
        print("6. Exit")

    def run(self):
        if not self.authenticate():
            return

        while True:
            self.display_menu()
            choice = input("Select an option (1-6): ")

            if choice == "1":
                self.add_employee()
            elif choice == "2":
                self.list_employees()
            elif choice == "3":
                self.remove_employees_by_age_range()
            elif choice == "4":
                self.find_employee()
            elif choice == "5":
                self.update_employee_salary()
            elif choice == "6":
                print("Logged out. Goodbye!")
                break
            else:
                print("Invalid choice. Please try again.")

    def add_employee(self):
        first_name = input("Enter employee's first name: ")
        last_name = input("Enter employee's last name: ")
        try:
            age = int(input("Enter employee's age: "))
            salary = float(input("Enter employee's salary: "))
        except ValueError:
            print("Invalid input. Age must be an integer, and salary must be a number.")
            return

        employee = Employee(first_name, last_name, age, salary)
        self.manager.add_employee(employee)
        print("Employee added successfully.")

    def list_employees(self):
        employees = self.manager.list_employees()
        if isinstance(employees, str):
            print(employees)
        else:
            for emp in employees:
                print(emp)

    def remove_employees_by_age_range(self):
        try:
            min_age = int(input("Enter minimum age: "))
            max_age = int(input("Enter maximum age: "))
        except ValueError:
            print("Invalid input. Age must be an integer.")
            return

        self.manager.remove_employees_by_age_range(min_age, max_age)
        print(f"Employees aged between {min_age} and {max_age} have been removed.")

    def find_employee(self):
        first_name = input("Enter employee's first name: ")
        last_name = input("Enter employee's last name: ")
        employee = self.manager.find_employee_by_name(first_name, last_name)
        if employee:
            print("Employee found:")
            print(employee)
        else:
            print("Employee not found.")

    def update_employee_salary(self):
        first_name = input("Enter employee's first name: ")
        last_name = input("Enter employee's last name: ")
        try:
            new_salary = float(input("Enter new salary: "))
        except ValueError:
            print("Invalid input. Salary must be a number.")
            return

        if self.manager.update_employee_salary(first_name, last_name, new_salary):
            print("Salary updated successfully.")
        else:
            print("Employee not found.")

# To run the system
if __name__ == "__main__":
    frontend = FrontendManager()
    frontend.run()
