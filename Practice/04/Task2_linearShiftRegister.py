import random

def read_txt(file_name):
    with open(file_name) as f:
        lines = f.read().rstrip()
    return lines

def write_txt(file_name, text):
    with open(file_name, 'w') as f:
        f.write(text)

class LinearShiftCipher():

    def __init__(self, message, s=None):
        self.message = message
        self.l = 10  
        self.f = lambda s: str(int(s[self.l - 10]) ^ int(s[self.l - 3]) ^ 1)  
        if not s:
            self.s = self.generateState(self.l)
        else:
            self.s = s

    @staticmethod
    def generateState(l):
        return "".join([str(random.randint(0, 1) % 2) for _ in range(l)])

    def encryptedText(self):
        res = ""
        for letter in self.message:
            letter_bin = bin(ord(letter))[2:]

            res_b = ''
            letter_bin = "0" * (8 - len(letter_bin)) + letter_bin
            for b in letter_bin:
                s = int(self.s[-1])
                new_b = s ^ int(b)
                res_b += str(new_b)
                self.s = str(self.f(self.s)) + self.s[:-1]
            res_b = "0" * (8 - len(res_b)) + res_b
            res += chr(int(res_b, base=2))
        return res

    def decryptedText(self):
        res = ""
        for letter in self.message:
            letter_bin = bin(ord(letter))[2:]
            res_b = ''
            letter_bin = "0" * (8 - len(letter_bin)) + letter_bin
            for b in letter_bin:
                s = int(self.s[-1])
                new_b = s ^ int(b)
                res_b += str(new_b)
                self.s = str(self.f(self.s)) + self.s[:-1]
            res_b = "0" * (8 - len(res_b)) + res_b
            res += chr(int(res_b, base=2))
        return res

if __name__ == "__main__":
    text_file = "text.txt"

    message = read_txt(text_file)

    s = LinearShiftCipher.generateState(10)  
    print("Вхідні дані: ")
    print(message)
    print("Початковий стан регістра: ")
    print(s)

    ss = LinearShiftCipher(message, s)
    res = ss.encryptedText()
    print("------------------------------------------------------------------")
    print("Зашифрований текст: ")
    print(res)

    print("------------------------------------------------------------------")
    ss = LinearShiftCipher(res, s)
    res = ss.decryptedText()
    print("Розшифрований текст: ")
    print(res)
