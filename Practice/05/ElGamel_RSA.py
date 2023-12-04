import random
import hashlib
import math

def is_prime(num):
    if num < 2:
        return False
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    return True

def generate_prime(bits):
    while True:
        num = random.getrandbits(bits)
        if is_prime(num):
            return num

def find_primitive_root(p):
    primitive_roots = []
    for i in range(2, p):
        if all(pow(i, powers, p) != 1 for powers in range(1, p - 1)):
            primitive_roots.append(i)
    return random.choice(primitive_roots)

def generate_elgamal_keys():
    bits = 8  # вказуємо бажану довжину бітів для простих чисел
    p = generate_prime(bits)
    g = find_primitive_root(p)
    a = random.randint(2, p - 2)
    h = pow(g, a, p)
    return p, g, a, h # p - простий модуль, g - первісний корінь, a - закритий ключ, h - відкритий ключ

def encrypt(message, p, g, h):
    k = random.randint(2, p - 2)
    c1 = pow(g, k, p) # k - випадкове число
    s = pow(h, k, p)
    c2 = (s * message) % p
    return c1, c2

def decrypt(c1, c2, a, p):
    s = pow(c1, a, p)
    s_inv = pow(s, -1, p)
    message = (c2 * s_inv) % p
    return message

def generate_rsa_keys():
    p = generate_prime(32)
    q = generate_prime(32)
    n = p * q
    phi_n = (p - 1) * (q - 1)
    e = 65537
    d = mod_inverse(e, phi_n) 
    return n, e, d

def mod_inverse(a, m):
    m0, x0, x1 = m, 0, 1
    while a > 1:
        q = a // m
        m, a = a % m, m
        x0, x1 = x1 - q * x0, x0
    return x1 + m0 if x1 < 0 else x1

def sign(message, d, n):
    hashed_message = hashlib.sha256(str(message).encode('utf-8')).digest()
    hash_value = int.from_bytes(hashed_message, byteorder='big')
    signature = pow(hash_value, d, n)
    return signature

def verify(message, signature, e, n):
    hashed_message = hashlib.sha256(str(message).encode('utf-8')).digest()
    hash_value = int.from_bytes(hashed_message, byteorder='big')
    return hash_value == pow(signature, e, n)

if __name__ == "__main__":
    # Ель-Гамаль
    p, g, a, h = generate_elgamal_keys()
    message = 32
    c1, c2 = encrypt(message, p, g, h)
    decrypted_message = decrypt(c1, c2, a, p)
    print(f"Ель-Гамаль: Оригінальне повідомлення: {message}, \nКлючі: \n с1 - {c1} \n с2 - {c2} \n а - {a} \n р - {p} \nРозшифроване повідомлення: {decrypted_message}")

    # RSA не працює на малих числах
    
    n, e, d = generate_rsa_keys()
    signature = sign(message, d, n)
    print(f"RSA: Підпис: {signature} {verify(message, signature, e, n)}")
