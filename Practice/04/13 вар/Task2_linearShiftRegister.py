import random

# Функція для зчитування тексту з файлу
def read_txt(file_name):
    with open(file_name) as f:
        lines = f.read().rstrip()
    return lines

# Функція для запису тексту до файлу
def write_txt(file_name, text):
    with open(file_name, 'w') as f:
        f.write(text)

# Клас для лінійного зсуву регістру
class LinearShiftCipher():

    # Конструктор класу
    def __init__(self, message, s=None):
        self.message = message
        self.l = 12 # довжина регістру зсуву (12 біт)
        # функція для зсуву регістру на один біт вправо і повернення останнього біта регістру (функція зворотнього зв'язку) 
        self.f = lambda s: str(int(s[self.l - 12]) ^ int(s[self.l - 6]) ^ int(s[self.l - 4]) ^ int(s[self.l - 1]) ^ 1)  
        if not s:
            self.s = self.generateState(self.l) # початковий стан регістру 
        else:
            self.s = s

    # Статичний метод для генерації початкового стану регістру
    @staticmethod
    def generateState(l):
        return "".join([str(random.randint(0, 1) % 2) for _ in range(l)]) # генерація рандомного стану регістру

    # Функція для шифрування тексту
    def encryptedText(self):
        res = "" # змінна для зберігання зашифрованого тексту
        for letter in self.message: 
            letter_bin = bin(ord(letter))[2:] # переведення букви в бінарний код

            res_b = '' # змінна для зберігання зашифрованого бінарного коду букви
            letter_bin = "0" * (8 - len(letter_bin)) + letter_bin # доповнення бінарного коду букви нулями до 8 біт
            for b in letter_bin: # для кожного біта в бінарному коді букви
                s = int(self.s[-1]) # останній біт регістру
                new_b = s ^ int(b) # зашифрований біт
                res_b += str(new_b) # додавання зашифрованого біта до результуючого бінарного коду букви
                self.s = str(self.f(self.s)) + self.s[:-1] # зсув регістру на один біт вправо і повернення останнього біта регістру (функція зворотнього зв'язку)
            res_b = "0" * (8 - len(res_b)) + res_b # доповнення бінарного коду букви нулями до 8 біт
            res += chr(int(res_b, base=2)) # переведення бінарного коду букви в символ і додавання його до результуючого тексту
        return res # повернення зашифрованого тексту

    # Функція для розшифрування тексту
    def decryptedText(self):
        res = "" # змінна для зберігання розшифрованого тексту
        for letter in self.message: 
            letter_bin = bin(ord(letter))[2:] # переведення букви в бінарний код
            res_b = '' # змінна для зберігання розшифрованого бінарного коду букви
            letter_bin = "0" * (8 - len(letter_bin)) + letter_bin # доповнення бінарного коду букви нулями до 8 біт
            for b in letter_bin: # для кожного біта в бінарному коді букви
                s = int(self.s[-1]) # останній біт регістру
                new_b = s ^ int(b) # розшифрований біт
                res_b += str(new_b) # додавання розшифрованого біта до результуючого бінарного коду букви
                self.s = str(self.f(self.s)) + self.s[:-1] # зсув регістру на один біт вправо і повернення останнього біта регістру (функція зворотнього зв'язку)
            res_b = "0" * (8 - len(res_b)) + res_b # доповнення бінарного коду букви нулями до 8 біт
            res += chr(int(res_b, base=2)) # переведення бінарного коду букви в символ і додавання його до результуючого тексту
        return res # повернення розшифрованого тексту

if __name__ == "__main__":
    text_file = "text.txt"

    message = read_txt(text_file)

    s = LinearShiftCipher.generateState(12) # генерація початкового стану регістру зсуву (12 біт) 
    print("Вхідні дані: ")
    print(message)
    print("\nПочатковий стан регістра: ")
    print(s)

    ss = LinearShiftCipher(message, s)
    res = ss.encryptedText()
    print("\nЗашифрований текст: ")
    print(res)

    ss = LinearShiftCipher(res, s)
    res = ss.decryptedText()
    print("\nРозшифрований текст: ")
    print(res)
