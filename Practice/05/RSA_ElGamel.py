import random
from hashlib import sha256
import math

def readTxt(file_name):
    with open(file_name) as f:
        lines = f.read().rstrip()
    return lines

def writeTxt(file_name, text):
    with open(file_name, 'w') as f:
        f.write(text)

def modulEqOne(a, m):
    for x in range(1, m):
        if (a * x) % m == 1:
            return x
    return -1

def primeRoot(modulo):
    roots = []
    requ = set(num for num in range(1, modulo) if math.gcd(num, modulo) == 1)

    for g in range(1, modulo):
        actual_set = set(pow(g, powers) % modulo for powers in range(1, modulo))
        if requ == actual_set:
            roots.append(g)
    return roots[0]


class RSACipher:
    def __init__(self, massage):
        self.massage = massage

    @staticmethod
    def generateKeysRSA(p, q):
        n = p * q
        phi = (p - 1) * (q - 1)

        while True:
            e = random.randrange(1, phi)
            g = math.gcd(e, phi)
            d = modulEqOne(e, phi)
            if g == 1 and e != d:
                break
        public_rsa, private_rsa = (e, n), (d, n)
        return public_rsa, private_rsa

    @staticmethod
    def generatePQ(keysize):
        p = random.randint(1, 10000)
        q = random.randint(1, 10000)
        nMin = 1 << (keysize - 1)
        nMax = (1 << keysize) - 1
        primes = [2]
        start = 1 << (keysize // 2 - 1)
        stop = 1 << (keysize // 2 + 1)

        if start >= stop:
            return []

        for i in range(3, stop + 1, 2):
            for p in primes:
                if i % p == 0:
                    break
            else:
                primes.append(i)

        while primes and primes[0] < start:
            del primes[0]
        while primes:
            p = random.choice(primes)
            primes.remove(p)
            q_values = [q for q in primes if nMin <= p * q <= nMax]
            if q_values:
                q = random.choice(q_values)
                break
        return p, q

    def encryptedText(self, public_rsa):
        e, n = public_rsa
        res = [pow(ord(c), e, n) for c in self.massage]
        res_m = "".join(chr(b) for b in res)
        return res_m

    def decryptedText(self, private_rsa):
        d, n = private_rsa
        message_b = [ord(x) for x in self.massage]
        res = "".join([chr(pow(c, d, n)) for c in message_b])
        return res


class ElGamelSign:
    def __init__(self, message):
        self.message = message

    @staticmethod
    def hashFunction(message):
        hashed = int(sha256(message.encode("UTF-8")).hexdigest(), 16)
        return hashed

    @staticmethod
    def generateKeys(P, g):
        privateKey = random.randint(1, P - 2)
        publicKey = pow(g, privateKey, P)
        return privateKey, publicKey

    def sign(self, prime_p, g_left, private_key):
        hash_mes = ElGamelSign.hashFunction(self.message)
        while 1:
            k = random.randint(1, prime_p - 2)
            if math.gcd(k, prime_p - 1) == 1:
                break
        rr = pow(g_left, k, prime_p)
        ll = modulEqOne(k, prime_p - 1)
        s = ((hash_mes - private_key * rr) * ll) % (prime_p - 1)
        lines = [encrypted_msg, "|", str(rr), "|", str(s)]
        encoded = "".join(lines)
        return encoded

    def verifyAndDecode(self, prime_p, g_left, public_key, private_rsa):
        decr_text = self.message.split("|")

        rsa_text = decr_text[0]
        r_s = int(decr_text[1])
        s_s = int(decr_text[2])
        hash_mes = ElGamelSign.hashFunction(rsa_text)

        if r_s <= 0 or s_s <= 0 or r_s >= prime_p or s_s >= (prime_p - 1):
            return False

        l = pow(g_left, hash_mes, prime_p)
        r = (pow(public_key, r_s) * pow(r_s, s_s)) % prime_p

        if l == r:
            print("\nDecrypted message: ")
            r = RSACipher(rsa_text)
            return r.decryptedText(private_rsa)
        else:
            print("Sign is not valid.")
            return 0


if __name__ == "__main__":
    P, Q = RSACipher.generatePQ(2 ** 4)
    public_rsa, private_rsa = RSACipher.generateKeysRSA(P, Q)

    g = primeRoot(P)
    privateKey, publicKey = ElGamelSign.generateKeys(P, g)

    text_file = "text.txt"
    message = readTxt(text_file)

    r = RSACipher(message)
    encrypted_msg = r.encryptedText(public_rsa)

    e = ElGamelSign(encrypted_msg)
    encoded = e.sign(P, g, privateKey)
    print(encoded)
    # -------------------------------------
    e = ElGamelSign(encoded)
    decoded = e.verifyAndDecode(P, g, publicKey, private_rsa)
    print(decoded)


