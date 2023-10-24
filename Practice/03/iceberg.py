# Задамо таблиці для табличних замін S0 та S1
S0 = [0xD, 0x7, 0x3, 0x2, 0x9, 0xA, 0xC, 0x1, 0xF, 0x4, 0x5, 0xE, 0x6, 0x0, 0xB, 0x8]
S1 = [0x4, 0xA, 0xF, 0xC, 0x0, 0xD, 0x9, 0xB, 0xE, 0x6, 0x1, 0x7, 0x3, 0x5, 0x8, 0x2]

# Задамо таблиці для бітових перестановок P8 та P4
P8 = [0, 1, 4, 5, 2, 3, 6, 7]
P4 = [1, 0, 3, 2]

# Функція для здійснення операції тау (циклічний зсув вліво на 8 бітів)
def tau(x):
    return ((x << 8) | (x >> 8)) & 0xFFFF

# Функція для обчислення S-блоку (S0 або S1)
def s_block(input_data, sbox):
    output_data = 0
    for i in range(16):
        input_nibble = (input_data >> (4 * i)) & 0xF
        output_nibble = sbox[input_nibble]
        output_data |= (output_nibble << (4 * i))
    return output_data

# Функція для бітової перестановки P8
def p8(input_data):
    output_data = 0
    for i in range(8):
        bit = (input_data >> i) & 1
        output_data |= (bit << P8[i])
    return output_data

# Функція для бітової перестановки P4
def p4(input_data):
    output_data = 0
    for i in range(4):
        bit = (input_data >> i) & 1
        output_data |= (bit << P4[i])
    return output_data

# Функція для операції множення на матрицю М
def multiply_by_matrix(input_data):
    matrix = [[0, 1, 1, 1],
              [1, 0, 1, 1],
              [1, 1, 0, 1],
              [1, 1, 1, 0]]
    output_data = 0
    for i in range(4):
        result_bit = 0
        for j in range(4):
            result_bit ^= (input_data >> j & 1) & matrix[i][j]
        output_data |= (result_bit << i)
    return output_data

# Функція для накладання ключа (операція δ)
def apply_key_material(data, key_material):
    return data ^ key_material

# Функція для раунду преобразования
def round_transform(data, key_material, encrypt=True):
    if encrypt:
        s0_data = s_block(data, S0)
        permuted_data = p8(s0_data)
        s1_data = s_block(permuted_data, S1)
    else:
        permuted_data = p8(data)
        s1_data = s_block(permuted_data, S1)
        s0_data = s_block(s1_data, S0)

    multiplied_data = multiply_by_matrix(s0_data)
    keyed_data = apply_key_material(multiplied_data, key_material)
    permuted_data = p4(keyed_data)

    return s1_data, permuted_data

# Функція для розширення ключа
def key_expansion(key):
    key_material = [key]
    for i in range(16):
        key_material.append(tau(key_material[i]))
    return key_material

# Функція для шифрування одного блоку даних
def encrypt_block(block, key):
    key_material = key_expansion(key)
    for i in range(15):
        block, key_material[i] = round_transform(block, key_material[i])

    s0_data = s_block(block, S0)
    permuted_data = p8(s0_data)
    s1_data = s_block(permuted_data, S1)

    encrypted_block = apply_key_material(s1_data, key_material[15])

    return encrypted_block

# Функція для розшифрування одного блоку даних
def decrypt_block(block, key):
    key_material = key_expansion(key)
    for i in range(15, 0, -1):
        block, key_material[i] = round_transform(block, key_material[i], encrypt=False)

    s1_data = s_block(block, S1)
    permuted_data = p8(s1_data)
    s0_data = s_block(permuted_data, S0)

    decrypted_block = apply_key_material(s0_data, key_material[0])

    return decrypted_block

# Приклад використання для шифрування та розшифрування блоку даних
key = 0x0123456789ABCDEF  # 128-бітний ключ

data = 0x0123456789ABCDEF  # 64-бітний блок даних
print("Вхідні дані:", data)

# Шифрування
encrypted_data = encrypt_block(data, key)
print("Зашифровані дані:", hex(encrypted_data))

# Розшифрування
decrypted_data = decrypt_block(encrypted_data, key)
print("Розшифровані дані:", hex(decrypted_data))



deсryptd_data = 0x0123456789ABCDEF 