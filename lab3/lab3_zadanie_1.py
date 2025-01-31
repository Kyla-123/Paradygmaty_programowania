class Employee:
    def __init__(self, first_name, last_name, age, salary):
        self.first_name = first_name
        self.last_name = last_name
        self.age = age
        self.salary = salary

    def __str__(self):
        return f"Name: {self.first_name} {self.last_name}, Age: {self.age}, Salary: ${self.salary:.2f}"

class EmployeesManager:
    def __init__(self):
        self.employees = []

    def add_employee(self, employee):
        if isinstance(employee, Employee):
            self.employees.append(employee)
        else:
            raise TypeError("Only Employee objects can be added.")

    def list_employees(self):
        return self.employees if self.employees else "No employees found."

    def remove_employees_by_age_range(self, min_age, max_age):
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]

    def find_employee_by_name(self, first_name, last_name):
        return next((emp for emp in self.employees if emp.first_name.lower() == first_name.lower() and emp.last_name.lower() == last_name.lower()), None)

    def update_employee_salary(self, first_name, last_name, new_salary):
        employee = self.find_employee_by_name(first_name, last_name)
        if employee:
            employee.salary = new_salary
            return True
        return False

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def display_menu(self):
        print("\nEmployees System Menu:")
        print("1. Add Employee")
        print("2. List Employees")
        print("3. Remove Employees by Age Range")
        print("4. Find Employee by Name")
        print("5. Update Employee Salary")
        print("6. Exit")

    def run(self):
        while True:
            self.display_menu()
            choice = input("Enter your choice (1-6): ")

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
                print("Exiting system. Goodbye!")
                break
            else:
                print("Invalid choice. Please try again.")

    def add_employee(self):
        first_name = input("Enter employee's first name: ")
        last_name = input("Enter employee's last name: ")
        age = int(input("Enter employee's age: "))
        salary = float(input("Enter employee's salary: "))
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
        min_age = int(input("Enter minimum age: "))
        max_age = int(input("Enter maximum age: "))
        self.manager.remove_employees_by_age_range(min_age, max_age)
        print(f"Employees aged between {min_age} and {max_age} have been removed.")

    def find_employee(self):
        first_name = input("Enter the first name of the employee to search for: ")
        last_name = input("Enter the last name of the employee to search for: ")
        employee = self.manager.find_employee_by_name(first_name, last_name)
        if employee:
            print("Employee found:")
            print(employee)
        else:
            print("Employee not found.")

    def update_employee_salary(self):
        first_name = input("Enter the first name of the employee to update salary: ")
        last_name = input("Enter the last name of the employee to update salary: ")
        new_salary = float(input("Enter the new salary: "))
        if self.manager.update_employee_salary(first_name, last_name, new_salary):
            print("Salary updated successfully.")
        else:
            print("Employee not found.")

# To run the system
if __name__ == "__main__":
    frontend = FrontendManager()
    frontend.run()

