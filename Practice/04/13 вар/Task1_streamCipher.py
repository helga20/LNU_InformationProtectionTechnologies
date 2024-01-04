import random
import math

# Функція для зчитування тексту з файлу
def read_txt(file_name):
    with open(file_name, 'r') as f:
        lines = f.read()
    return lines

# Функція для запису тексту до файлу
def write_txt(file_name, text):
    with open(file_name, 'w') as f:
        f.write(text)

# Клас для потокового шифру на основі генератора BBS
class StreamCipherBBS:

    def __init__(self, message, integers=None):
        self.message = message
        if not integers:
            self.p, self.q, self.r, self.n = self.generateRandomIntegers() # генерація випадкових цілих чисел p, q, r, n (n = p * q) 
        else:
            self.p, self.q, self.r = integers # ініціалізація цілих чисел p, q, r
            self.n = self.p * self.q # n = p * q

    # Статичний метод для генерації випадкових цілих чисел p, q, r, n (n = p * q)
    @staticmethod
    def generateRandomIntegers():
        p = random.choice([x for x in range(3, 1000, 4) if isPrime(x)]) # генерація випадкового простого числа p
        q = random.choice([x for x in range(3, 1000, 4) if isPrime(x)]) # генерація випадкового простого числа q
        n = p * q # n = p * q
        r = random.randint(1, 1000) # генерація випадкового числа r
        while math.gcd(r, n) != 1: # перевірка, що r і n взаємно прості
            r = random.randint(1, 1000) # генерація випадкового числа r
        return p, q, r, n 

    # Функція для шифрування тексту
    def encryptedText(self):
        res = ""
        x = (self.r ** 2) % self.n # x0 = r^2 mod n
        for letter in self.message: 
            letter_bin = bin(ord(letter))[2:] # переведення букви в бінарний код
            res_b = '' # змінна для зберігання зашифрованого бінарного коду букви
            letter_bin = "0" * (8 - len(letter_bin)) + letter_bin # доповнення бінарного коду букви нулями до 8 біт
            for b in letter_bin: 
                s = x % 2 # останній біт x
                x = (x ** 2) % self.n # xi = xi-1^2 mod n
                new_b = s ^ int(b) # зашифрований біт
                res_b += str(new_b) # додавання зашифрованого біта до результуючого бінарного коду букви
            res_b = "0" * (8 - len(res_b)) + res_b # доповнення бінарного коду букви нулями до 8 біт
            res += chr(int(res_b, base=2)) # переведення бінарного коду букви в символ і додавання його до результуючого тексту
        return res

    # Функція для розшифрування тексту
    def decryptedText(self):
        res = ""
        x = (self.r ** 2) % self.n # x0 = r^2 mod n
        for letter in self.message:
            letter_bin = bin(ord(letter))[2:] # переведення букви в бінарний код
            res_b = '' # змінна для зберігання розшифрованого бінарного коду букви
            letter_bin = "0" * (8 - len(letter_bin)) + letter_bin # доповнення бінарного коду букви нулями до 8 біт
            for b in letter_bin:
                s = x % 2 # останній біт x
                x = (x ** 2) % self.n # xi = xi-1^2 mod n
                new_b = s ^ int(b) # розшифрований біт
                res_b += str(new_b) # додавання розшифрованого біта до результуючого бінарного коду букви
            res_b = "0" * (8 - len(res_b)) + res_b # доповнення бінарного коду букви нулями до 8 біт
            res += chr(int(res_b, base=2)) # переведення бінарного коду букви в символ і додавання його до результуючого тексту
        return res

# Функція для перевірки, що число є простим
def isPrime(n):
    if n <= 1: # 0, 1 - не прості числа
        return False 
    if n <= 3: # 2, 3 - прості числа
        return True
    if n % 2 == 0 or n % 3 == 0: # числа, що діляться на 2 або 3 - не прості
        return False
    i = 5 
    while i * i <= n: # перевірка, що число не ділиться на числа від 5 до кореня з числа
        if n % i == 0 or n % (i + 2) == 0: # якщо число ділиться на число від 5 до кореня з числа, то воно не просте
            return False
        i += 6 # перехід до наступного числа
    return True

if __name__ == "__main__":
    text_file = "text.txt"

    message = read_txt(text_file)

    p, q, r, n = StreamCipherBBS.generateRandomIntegers() # генерація випадкових цілих чисел p, q, r, n (n = p * q)
    print("Вхідні дані:")
    print(message)
    print("\np, q, r, n:")
    print(p, q, r, n)

    s = StreamCipherBBS(message, (p, q, r)) 
    encrypted = s.encryptedText()
    print("\nЗашифрований текст:")
    print(encrypted)

    s = StreamCipherBBS(encrypted, (p, q, r))
    decrypted = s.decryptedText()
    print("\nРозшифрований текст:")
    print(decrypted)
