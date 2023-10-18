using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void button3_Click(object sender, EventArgs e)
        {
            key1 = keyTextBox1.Text.ToUpper();
            key2 = keyTextBox2.Text.ToUpper();
            string plaintext = InputTextBox.Text.ToUpper();

            GeneratePlayfairTable(key1, playfairTable1);
            GeneratePlayfairTable(key2, playfairTable2);

            string ciphertext = Encrypt(plaintext);
            EncryptTextBox.Text = ciphertext;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            key1 = keyTextBox1.Text.ToUpper();
            key2 = keyTextBox2.Text.ToUpper();
            string ciphertext = EncryptTextBox.Text.ToUpper();

            GeneratePlayfairTable(key1, playfairTable1);
            GeneratePlayfairTable(key2, playfairTable2);

            string plaintext = Decrypt(ciphertext);
            DecryptTextBox.Text = plaintext;
        }

        private string key1;
        private string key2;
        private char[,] playfairTable1 = new char[5, 5];
        private char[,] playfairTable2 = new char[5, 5];

        private void GeneratePlayfairTable(string key, char[,] table)
        {
            bool[] used = new bool[26];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    table[i, j] = ' ';
                }
            }

            int row = 0;
            int col = 0;
            foreach (char c in key)
            {
                if (!Char.IsLetter(c)) continue;

                int index = c - 'A';

                if (!used[index])
                {
                    table[row, col] = c;
                    used[index] = true;
                    col++;
                    if (col == 5)
                    {
                        col = 0;
                        row++;
                    }
                }
            }

            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c == 'J') continue; 
                if (!used[c - 'A'])
                {
                    table[row, col] = c;
                    col++;
                    if (col == 5)
                    {
                        col = 0;
                        row++;
                    }
                }
            }
        }

        private string Encrypt(string plaintext)
        {
            StringBuilder cleanedText = new StringBuilder();
            foreach (char c in plaintext)
            {
                if (Char.IsLetter(c))
                    cleanedText.Append(char.ToUpper(c));
                else
                    cleanedText.Append(c);
            }

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < cleanedText.Length; i += 2)
            {
                char first = cleanedText[i];
                char second = (i + 1 < cleanedText.Length) ? cleanedText[i + 1] : 'X'; 

                if (!Char.IsLetter(first) || !Char.IsLetter(second))
                {
                    encryptedText.Append(first); 
                    encryptedText.Append(second);
                    continue;
                }

                int[] positionFirst = GetPositionInTable(first, playfairTable1);
                int[] positionSecond = GetPositionInTable(second, playfairTable2);

                if (positionFirst[0] == positionSecond[0]) 
                {
                    encryptedText.Append(playfairTable1[positionFirst[0], (positionFirst[1] + 1) % 5]);
                    encryptedText.Append(playfairTable2[positionSecond[0], (positionSecond[1] + 1) % 5]);
                }
                else if (positionFirst[1] == positionSecond[1]) 
                {
                    encryptedText.Append(playfairTable1[(positionFirst[0] + 1) % 5, positionFirst[1]]);
                    encryptedText.Append(playfairTable2[(positionSecond[0] + 1) % 5, positionSecond[1]]);
                }
                else 
                {
                    encryptedText.Append(playfairTable1[positionFirst[0], positionSecond[1]]);
                    encryptedText.Append(playfairTable2[positionSecond[0], positionFirst[1]]);
                }
            }

            return encryptedText.ToString();
        }

        private string Decrypt(string ciphertext)
        {
            StringBuilder decryptedText = new StringBuilder();

            for (int i = 0; i < ciphertext.Length; i += 2)
            {
                char first = ciphertext[i];
                char second = (i + 1 < ciphertext.Length) ? ciphertext[i + 1] : 'X'; 

                if (!Char.IsLetter(first) || !Char.IsLetter(second))
                {
                    decryptedText.Append(first); 
                    decryptedText.Append(second);
                    continue;
                }

                int[] positionFirst = GetPositionInTable(first, playfairTable1);
                int[] positionSecond = GetPositionInTable(second, playfairTable2);

                if (positionFirst[0] == positionSecond[0]) 
                {
                    decryptedText.Append(playfairTable1[positionFirst[0], (positionFirst[1] + 4) % 5]); 
                    decryptedText.Append(playfairTable2[positionSecond[0], (positionSecond[1] + 4) % 5]);
                }
                else if (positionFirst[1] == positionSecond[1]) 
                {
                    decryptedText.Append(playfairTable1[(positionFirst[0] + 4) % 5, positionFirst[1]]);
                    decryptedText.Append(playfairTable2[(positionSecond[0] + 4) % 5, positionSecond[1]]);
                }
                else 
                {
                    decryptedText.Append(playfairTable1[positionFirst[0], positionSecond[1]]);
                    decryptedText.Append(playfairTable2[positionSecond[0], positionFirst[1]]);
                }
            }

            return decryptedText.ToString();
        }

        private int[] GetPositionInTable(char letter, char[,] table)
        {
            int[] position = new int[2];
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (table[row, col] == letter)
                    {
                        position[0] = row;
                        position[1] = col;
                        return position;
                    }
                }
            }
            return position;
        }
    }
}
