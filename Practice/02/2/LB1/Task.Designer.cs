namespace LB1
{
    partial class Task
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.створитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назваФайлуToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.відкритиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проСистемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.допомогаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідЗіСистемиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EncryptTextBox = new System.Windows.Forms.RichTextBox();
            this.InputTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.keyTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DecryptTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.проСистемуToolStripMenuItem,
            this.допомогаToolStripMenuItem,
            this.вихідЗіСистемиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(464, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(325, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.створитиToolStripMenuItem,
            this.відкритиToolStripMenuItem,
            this.зберегтиToolStripMenuItem});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.файлToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // створитиToolStripMenuItem
            // 
            this.створитиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.назваФайлуToolStripMenuItem});
            this.створитиToolStripMenuItem.Name = "створитиToolStripMenuItem";
            this.створитиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.створитиToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.створитиToolStripMenuItem.Text = "Створити";
            this.створитиToolStripMenuItem.Visible = false;
            this.створитиToolStripMenuItem.Click += new System.EventHandler(this.створитиToolStripMenuItem_Click);
            // 
            // назваФайлуToolStripMenuItem
            // 
            this.назваФайлуToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.назваФайлуToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.назваФайлуToolStripMenuItem.Name = "назваФайлуToolStripMenuItem";
            this.назваФайлуToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            // 
            // відкритиToolStripMenuItem
            // 
            this.відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            this.відкритиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.відкритиToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.відкритиToolStripMenuItem.Text = "Відкрити";
            this.відкритиToolStripMenuItem.Click += new System.EventHandler(this.відкритиToolStripMenuItem_Click);
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.зберегтиToolStripMenuItem.Text = "Зберегти як";
            this.зберегтиToolStripMenuItem.Click += new System.EventHandler(this.зберегтиToolStripMenuItem_Click);
            // 
            // проСистемуToolStripMenuItem
            // 
            this.проСистемуToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.проСистемуToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.проСистемуToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.проСистемуToolStripMenuItem.Name = "проСистемуToolStripMenuItem";
            this.проСистемуToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.проСистемуToolStripMenuItem.Text = "Про розробника";
            this.проСистемуToolStripMenuItem.Click += new System.EventHandler(this.проСистемуToolStripMenuItem_Click);
            // 
            // допомогаToolStripMenuItem
            // 
            this.допомогаToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.допомогаToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.допомогаToolStripMenuItem.Name = "допомогаToolStripMenuItem";
            this.допомогаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.допомогаToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.допомогаToolStripMenuItem.Text = "Допомога";
            this.допомогаToolStripMenuItem.Click += new System.EventHandler(this.допомогаToolStripMenuItem_Click);
            // 
            // вихідЗіСистемиToolStripMenuItem
            // 
            this.вихідЗіСистемиToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.вихідЗіСистемиToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.вихідЗіСистемиToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.вихідЗіСистемиToolStripMenuItem.Name = "вихідЗіСистемиToolStripMenuItem";
            this.вихідЗіСистемиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.вихідЗіСистемиToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.вихідЗіСистемиToolStripMenuItem.Text = "Вихід";
            this.вихідЗіСистемиToolStripMenuItem.Click += new System.EventHandler(this.вихідЗіСистемиToolStripMenuItem_Click);
            // 
            // EncryptTextBox
            // 
            this.EncryptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EncryptTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EncryptTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.EncryptTextBox.Location = new System.Drawing.Point(17, 275);
            this.EncryptTextBox.Name = "EncryptTextBox";
            this.EncryptTextBox.Size = new System.Drawing.Size(274, 150);
            this.EncryptTextBox.TabIndex = 43;
            this.EncryptTextBox.Text = "";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InputTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InputTextBox.ForeColor = System.Drawing.Color.Black;
            this.InputTextBox.Location = new System.Drawing.Point(17, 60);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(274, 150);
            this.InputTextBox.TabIndex = 42;
            this.InputTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Зашифрований текст:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Текст, який треба зашифрувати";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(598, 306);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 47);
            this.button3.TabIndex = 45;
            this.button3.Text = "Зашифрувати";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(598, 377);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(190, 47);
            this.button4.TabIndex = 46;
            this.button4.Text = "Розшифрувати";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // keyTextBox1
            // 
            this.keyTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.keyTextBox1.Location = new System.Drawing.Point(598, 84);
            this.keyTextBox1.Multiline = true;
            this.keyTextBox1.Name = "keyTextBox1";
            this.keyTextBox1.Size = new System.Drawing.Size(182, 42);
            this.keyTextBox1.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(465, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "Введіть ключ:";
            // 
            // DecryptTextBox
            // 
            this.DecryptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DecryptTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DecryptTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.DecryptTextBox.Location = new System.Drawing.Point(308, 274);
            this.DecryptTextBox.Name = "DecryptTextBox";
            this.DecryptTextBox.Size = new System.Drawing.Size(274, 150);
            this.DecryptTextBox.TabIndex = 54;
            this.DecryptTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(315, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 16);
            this.label6.TabIndex = 55;
            this.label6.Text = "Розшифрований текст:";
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DecryptTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyTextBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.EncryptTextBox);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Task";
            this.Text = ",";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem створитиToolStripMenuItem;
        private ToolStripTextBox назваФайлуToolStripMenuItem;
        private ToolStripMenuItem відкритиToolStripMenuItem;
        private ToolStripMenuItem зберегтиToolStripMenuItem;
        private ToolStripMenuItem проСистемуToolStripMenuItem;
        private ToolStripMenuItem допомогаToolStripMenuItem;
        private ToolStripMenuItem вихідЗіСистемиToolStripMenuItem;
        private RichTextBox EncryptTextBox;
        private RichTextBox InputTextBox;
        private Label label3;
        private Label label2;
        private Button button3;
        private Button button4;
        private TextBox keyTextBox1;
        private Label label1;
        private RichTextBox DecryptTextBox;
        private Label label6;
    }
}

