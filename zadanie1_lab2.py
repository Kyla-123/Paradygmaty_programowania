def zadanie1(text):
    text.strip('\n')


# Lista stop words
stop_words = {"i", "a", "the", "to", "w", "z", "na", "o", "jak", "że", "do", "co",
              "jest", "nie", "ale", "tak", "by", "przed", "po", "czy", "mówi", "lub"}


def count_text_features(text):
    # Zliczanie słów
    words = text.split()
    word_count = len(words)

    # Zliczanie zdań
    sentences = text.split('. ')
    sentence_count = len(sentences) - 1 if sentences[-1] == '' else len(sentences)

    # Zliczanie akapitów
    paragraphs = text.split('\n')
    paragraph_count = len(paragraphs)

    return word_count, sentence_count, paragraph_count, words


def get_most_common_words(words):
    filtered_words = filter(lambda word: word.lower() not in stop_words, words)
    word_frequency = {}

    for word in filtered_words:
        word = word.lower()  # Normalizujemy do małych liter
        if word in word_frequency:
            word_frequency[word] += 1
        else:
            word_frequency[word] = 1

    # Zwracamy 10 najczęściej występujących słów
    most_common = sorted(word_frequency.items(), key=lambda item: item[1], reverse=True)[:10]
    return most_common


def transform_words(words):
    return [word[::-1] if word.lower().startswith('a') else word for word in words]


def analyze_text(text):
    word_count, sentence_count, paragraph_count, words = count_text_features(text)
    most_common_words = get_most_common_words(words)
    transformed_words = transform_words(words)

    return {
        "word_count": word_count,
        "sentence_count": sentence_count,
        "paragraph_count": paragraph_count,
        "most_common_words": most_common_words,
        "transformed_words": transformed_words
    }
text = """
ala ma kota

ala ma kota
"""

result = analyze_text(text)

# Wyświetlanie wyników
print("Liczba słów:", result["word_count"])
print("Liczba zdań:", result["sentence_count"])
print("Liczba akapitów:", result["paragraph_count"])
print("Najczęściej występujące słowa:", result["most_common_words"])
print("Przekształcone słowa:", result["transformed_words"])