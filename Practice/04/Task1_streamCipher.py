import random
import math

def read_txt(file_name):
    with open(file_name, 'r') as f:
        lines = f.read()
    return lines

def write_txt(file_name, text):
    with open(file_name, 'w') as f:
        f.write(text)

class StreamCipherBBS:

    def __init__(self, message, integers=None):
        self.message = message
        if not integers:
            self.p, self.q, self.r, self.n = self.generateRandomIntegers()
        else:
            self.p, self.q, self.r = integers
            self.n = self.p * self.q

    @staticmethod
    def generateRandomIntegers():
        p = random.choice([x for x in range(3, 1000, 4) if isPrime(x)])
        q = random.choice([x for x in range(3, 1000, 4) if isPrime(x)])
        n = p * q
        r = random.randint(1, 1000)
        while math.gcd(r, n) != 1:
            r = random.randint(1, 1000)
        return p, q, r, n

    def encryptedText(self):
        res = ""
        x = (self.r ** 2) % self.n
        for letter in self.message:
            letter_bin = bin(ord(letter))[2:]
            res_b = ''
            letter_bin = "0" * (8 - len(letter_bin)) + letter_bin
            for b in letter_bin:
                s = x % 2
                x = (x ** 2) % self.n
                new_b = s ^ int(b)
                res_b += str(new_b)
            res_b = "0" * (8 - len(res_b)) + res_b
            res += chr(int(res_b, base=2))
        return res

    def decryptedText(self):
        res = ""
        x = (self.r ** 2) % self.n
        for letter in self.message:
            letter_bin = bin(ord(letter))[2:]
            res_b = ''
            letter_bin = "0" * (8 - len(letter_bin)) + letter_bin
            for b in letter_bin:
                s = x % 2
                x = (x ** 2) % self.n
                new_b = s ^ int(b)
                res_b += str(new_b)
            res_b = "0" * (8 - len(res_b)) + res_b
            res += chr(int(res_b, base=2))
        return res

def isPrime(n):
    if n <= 1:
        return False
    if n <= 3:
        return True
    if n % 2 == 0 or n % 3 == 0:
        return False
    i = 5
    while i * i <= n:
        if n % i == 0 or n % (i + 2) == 0:
            return False
        i += 6
    return True

if __name__ == "__main__":
    text_file = "text.txt"

    message = read_txt(text_file)

    p, q, r, n = StreamCipherBBS.generateRandomIntegers()
    print("Вхідні дані:")
    print(message)
    print("p, q, r, n:")
    print(p, q, r, n)

    s = StreamCipherBBS(message, (p, q, r))
    encrypted = s.encryptedText()
    print("------------------------------------------------------------------")
    print("Зашифрований текст:")
    print(encrypted)

    print("------------------------------------------------------------------")
    s = StreamCipherBBS(encrypted, (p, q, r))
    decrypted = s.decryptedText()
    print("Розшифрований текст:")
    print(decrypted)
