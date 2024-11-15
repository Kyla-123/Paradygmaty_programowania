# 1 zadanie - podział paczek

def zadanie1(wagi, max_waga):
    for waga in wagi:
        if waga > max_waga:
            raise ValueError(f"Paczka o wadze {waga} przekracza maksymalną dozwoloną wagę kursu ({max_waga}) kg")

        wagi_sorted = sorted(wagi, reverse=True)
        kursy = []

        for waga in wagi_sorted:
            dodano = False
            for kurs in kursy:
                if sum(kurs) + waga <=max_waga:
                    kurs.append(waga)
                    dodano = True
                    break
            if not dodano:
                kursy.append([waga])
        return len(kursy), kursy



wagi=[10,13,5,7,20,21,1]
max_waga=25
print(zadanie1(wagi, max_waga))

liczba_kursow, kursy = zadanie1(wagi, max_waga)
for i, kurs in enumerate (kursy, 1):
    print(f"Kurs {i}L {kurs} - suma wag: {sum(kurs)} w kursie")