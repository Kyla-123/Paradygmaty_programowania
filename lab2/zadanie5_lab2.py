import ast


def validate_code(code):
    """Weryfikacja poprawności kodu."""
    try:
        ast.parse(code)
        return True
    except SyntaxError as e:
        print(f"Błąd składni: {e}")
        return False


def generate_code(template, **kwargs):
    """Generuje kod na podstawie szablonu i danych wejściowych."""
    # Uzupełnianie szablonu o zmienne
    for key, value in kwargs.items():
        template = template.replace(f'{{{{ {key} }}}}', str(value))

    return template


def execute_code(code):
    """Uruchamia podany kod."""
    exec(code)


# Przykład użycia
if __name__ == "__main__":
    # Szablon kodu
    template = """
def funkcja(x):
    return x + {{ a }} + {{ b }}

wynik = funkcja(5)
print(wynik)
"""

    # Dane wejściowe do uzupełnienia
    data = {
        "a": 2,
        "b": 3
    }

    # Generowanie kodu
    generated_code = generate_code(template, **data)

    # Weryfikacja kodu
    if validate_code(generated_code):
        print("Kod jest poprawny, uruchamiam:")
        print(generated_code)
        execute_code(generated_code)
    else:
        print("Kod jest niepoprawny, nie można go uruchomić.")
