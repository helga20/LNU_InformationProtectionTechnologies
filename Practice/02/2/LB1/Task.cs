using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LB1
{
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
        }

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText("file.txt", InputTextBox.Text);
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.InitialDirectory = "C:\\";
            dialog.Title = "Виберіть текстовий файл";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fname = dialog.FileName;
                InputTextBox.Text = File.ReadAllText(fname, Encoding.UTF8);
            }
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog oSaveFileDialog = new SaveFileDialog();
            oSaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (oSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = oSaveFileDialog.FileName;
                string extesion = Path.GetExtension(fileName);
                string fullPath = Path.GetFullPath(fileName);
                switch (extesion)
                {
                    case ".txt":
                        File.WriteAllText(fullPath, EncryptTextBox.Text);
                        break;
                    default:
                        break;
                }
            }
        }

        private void проСистемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Криптосистема\n Розробник: Кравець Ольга\n Група: ПМО-41\n Рік: 2023");
        }

        private void допомогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Ctrl+H - допомога\n Ctrl+C - створити файл\n Ctrl+O - відкрити файл\n Ctrl+S - зберегти файл\n " +
               "Ctrl+P - друк файлу\n Alt+D - інформація про розробника\n Alt+X - вихід\n ");
        }

        private void вихідЗіСистемиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Здійснити вихід зі системи?", "Увага!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private int[,] GenerateKeyMatrix(string keyword)
        {
            int matrixSize = (int)Math.Ceiling(Math.Sqrt(keyword.Length)); 
            int[,] keyMatrix = new int[matrixSize, matrixSize];
            int index = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (index < keyword.Length)
                    {
                        keyMatrix[row, col] = keyword[index] - 'A'; 
                        index++;
                    }
                    else
                    {
                        keyMatrix[row, col] = 0;
                    }
                }
            }

            return keyMatrix;
        }

        private string Encrypt(string openMessage, int[,] keyMatrix)
        {
            int matrixSize = keyMatrix.GetLength(0);
            StringBuilder encryptedMessage = new StringBuilder();

            for (int i = 0; i < openMessage.Length; i += matrixSize)
            {
                string block = openMessage.Substring(i, Math.Min(matrixSize, openMessage.Length - i));
                int[] blockVector = new int[block.Length];

                for (int j = 0; j < block.Length; j++)
                {
                    char character = block[j];
                    if (char.IsLetter(character))
                    {
                        blockVector[j] = char.ToUpper(character) - 'A'; 
                    }
                    else
                    {
                        encryptedMessage.Append(character);
                    }
                }

                int[] encryptedBlock = new int[matrixSize];

                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        if (row < blockVector.Length && col < blockVector.Length)
                        {
                            encryptedBlock[row] += keyMatrix[row, col] * blockVector[col];
                        }
                    }
                }

                for (int j = 0; j < matrixSize; j++)
                {
                    encryptedBlock[j] %= 26;
                    encryptedMessage.Append((char)(encryptedBlock[j] + 'A'));
                }
            }

            return encryptedMessage.ToString();
        }

        private string Decrypt(string encryptedMessage, int[,] keyMatrix)
        {
            int matrixSize = keyMatrix.GetLength(0);
            StringBuilder decryptedMessage = new StringBuilder();
            int[,] inverseKeyMatrix = GetInverseMatrix(keyMatrix, 26); 

            for (int i = 0; i < encryptedMessage.Length; i += matrixSize)
            {
                int[] encryptedBlock = new int[matrixSize];

                for (int j = 0; j < matrixSize; j++)
                {
                    char character = encryptedMessage[i + j];
                    encryptedBlock[j] = character - 'A';
                }

                int[] decryptedBlock = MultiplyMatrixVector(inverseKeyMatrix, encryptedBlock);

                for (int j = 0; j < matrixSize; j++)
                {
                    decryptedBlock[j] = (decryptedBlock[j] % 26 + 26) % 26; 
                    decryptedMessage.Append((char)(decryptedBlock[j] + 'A'));
                }
            }

            return decryptedMessage.ToString();
        }

        private int[,] GetInverseMatrix(int[,] matrix, int mod)
        {
            int n = matrix.GetLength(0);
            int[,] adj = new int[n, n];
            int det = Determinant(matrix, n, mod);

            if (det == 0)
            {
                Console.WriteLine("Необоротна матриця");
                return null;
            }

            int det_inv = ModularInverse(det, mod);
            Adjugate(matrix, adj, n, mod);

            int[,] inv = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inv[i, j] = (adj[i, j] * det_inv) % mod;
                }
            }

            return inv;
        }

        private int Determinant(int[,] matrix, int n, int mod)
        {
            int det = 0;
            if (n == 2)
                return ((matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0])) % mod;

            int[,] submatrix = new int[n - 1, n - 1];
            for (int x = 0; x < n; x++)
            {
                int subi = 0;
                for (int i = 1; i < n; i++)
                {
                    int subj = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j == x)
                            continue;
                        submatrix[subi, subj] = matrix[i, j];
                        subj++;
                    }
                    subi++;
                }
                int recDet = Determinant(submatrix, n - 1, mod);
                det = (det + matrix[0, x] * (x % 2 == 0 ? 1 : -1) * recDet) % mod;
            }

            return (det + mod) % mod;
        }

        private void Adjugate(int[,] matrix, int[,] adj, int n, int mod)
        {
            if (n == 1)
            {
                adj[0, 0] = 1;
                return;
            }

            int sign = 1;
            int[,] submatrix = new int[n - 1, n - 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int subi = 0;
                    for (int ii = 0; ii < n; ii++)
                    {
                        if (ii == i)
                            continue;
                        int subj = 0;
                        for (int jj = 0; jj < n; jj++)
                        {
                            if (jj == j)
                                continue;
                            submatrix[subi, subj] = matrix[ii, jj];
                            subj++;
                        }
                        subi++;
                    }

                    adj[j, i] = (sign * Determinant(submatrix, n - 1, mod)) % mod;
                    sign = -sign;
                }
            }
        }

        private int[] MultiplyMatrixVector(int[,] matrix, int[] vector)
        {
            int size = vector.Length;
            int[] result = new int[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = 0;
                for (int j = 0; j < size; j++)
                {
                    result[i] += matrix[i, j] * vector[j];
                }
            }

            return result;
        }

        private int ModularInverse(int a, int mod)
        {
            int m0 = mod, t, q;
            int x0 = 0, x1 = 1;

            if (mod == 1)
                return 0;

            while (a > 1)
            {
                q = a / mod;
                t = mod;
                mod = a % mod;
                a = t;
                t = x0;
                x0 = x1 - q * x0;
                x1 = t;
            }

            if (x1 < 0)
                x1 += m0;

            return x1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = InputTextBox.Text;
            string keyword = keyTextBox1.Text;

            if (keyword.Length < 9)
            {
                MessageBox.Show("Ключ повинен містити принаймні 9 символів.");
                return;
            }

            int[,] keyMatrix = GenerateKeyMatrix(keyword);
            string cipherText = Encrypt(message, keyMatrix);
            EncryptTextBox.Text = cipherText;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string encryptedMessage = EncryptTextBox.Text;
            string keyword = keyTextBox1.Text;

            if (keyword.Length < 9)
            {
                MessageBox.Show("Ключ повинен містити принаймні 9 символів.");
                return;
            }

            int[,] keyMatrix = GenerateKeyMatrix(keyword);
            string decryptedMessage = Decrypt(encryptedMessage, keyMatrix);
            DecryptTextBox.Text = decryptedMessage;
        }
    }
}
