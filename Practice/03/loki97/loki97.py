decryptd_block = 0x123456789ABCDEF0123456789ABCDEF


import math

# Константа ∆
DELTA = 0x9E3779B97F4A7C15

# Функція для розширення ключа
def expand_key(key, rounds):
    expanded_key = [0] * (rounds * 3)
    
    for i in range(rounds * 3):
        expanded_key[i] = key & 0xFFFFFFFFFFFFFFFF
        key = (key + DELTA) & 0xFFFFFFFFFFFFFFFF
    
    return expanded_key

# Функція для KP (keyed permutation)
def kp(subblock, key_fragment):
    result = 0
    
    for i in range(32):
        bit = (key_fragment >> i) & 1
        result |= (subblock & (1 << bit)) << i
    
    return result

# Функція для E (expansion)
def e(subblock):
    result = 0
    bit_positions = [4, 63, 58, 52, 42, 34, 28, 18, 12]
    
    for i in range(9):
        result |= ((subblock >> bit_positions[i]) & 1) << i
    
    return result

# Функція для S1
def s1(x):
    return (((x ^ 0x1FFF) ** 3 % 0x2911) & 0xFF)

# Функція для S2
def s2(x):
    return (((x ^ 0x7FF) ** 3 % 0xAA7) & 0xFF)

# Функція для P (permutation)
def p(subblock):
    permutation_table = [
        56, 48, 40, 32, 24, 16, 8, 0,
        57, 49, 41, 33, 25, 17, 9, 1,
        58, 50, 42, 34, 26, 18, 10, 2,
        59, 51, 43, 35, 27, 19, 11, 3,
        60, 52, 44, 36, 28, 20, 12, 4,
        61, 53, 45, 37, 29, 21, 13, 5,
        62, 54, 46, 38, 30, 22, 14, 6,
        63, 55, 47, 39, 31, 23, 15, 7
    ]
    
    result = 0
    
    for i in range(64):
        result |= ((subblock >> permutation_table[i]) & 1) << i
    
    return result

# Функція для f
def f(subblock, key_fragment):
    subblock = kp(subblock, key_fragment)
    subblock = e(subblock)
    
    s1_input = (key_fragment << 11) | (subblock >> 5)
    s2_input = ((key_fragment & 0x7FF) << 11) | (subblock & 0x1F)
    
    s1_output = s1(s1_input)
    s2_output = s2(s2_input)
    
    return (s1_output << 11) | s2_output

# Головна функція для шифрування одного блоку
def loki97_encrypt_block(block, key, rounds):
    key_fragments = expand_key(key, rounds)
    
    left_subblock, right_subblock = block >> 64, block & 0xFFFFFFFFFFFFFFFF
    
    for i in range(rounds):
        temp = left_subblock
        left_subblock = right_subblock ^ f(left_subblock, key_fragments[i * 3])
        right_subblock = temp
    
    return (left_subblock << 64) | right_subblock

# Головна функція для розшифрування одного блоку
def loki97_decrypt_block(block, key, rounds):
    key_fragments = expand_key(key, rounds)
    
    left_subblock, right_subblock = block >> 64, block & 0xFFFFFFFFFFFFFFFF
    
    for i in range(rounds - 1, -1, -1):
        temp = left_subblock
        left_subblock = right_subblock ^ f(left_subblock, key_fragments[i * 3])
        right_subblock = temp
    
    return (left_subblock << 64) | right_subblock

key = 0x0123456789ABCDEF0123456789ABCDEF  # 128-бітний ключ
rounds = 16  # Кількість раундів

plaintext = 0x123456789ABCDEF0123456789ABCDEF  # 128-бітний блок даних

encrypted_block = loki97_encrypt_block(plaintext, key, rounds)
decrypted_block = loki97_decrypt_block(encrypted_block, key, rounds)

print("Вхідні дані:", hex(plaintext))
print("Зашифровані дані:", hex(encrypted_block))
print("Розшифровані дані:", hex(decryptd_block))