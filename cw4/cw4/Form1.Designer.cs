namespace cw4
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb_Sciezka = new System.Windows.Forms.TextBox();
            this.btn_Wczytaj = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btn_oblicz = new System.Windows.Forms.Button();
            this.tb_wynik = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_progJakosci = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tb_Sciezka
            // 
            this.tb_Sciezka.Location = new System.Drawing.Point(12, 12);
            this.tb_Sciezka.Name = "tb_Sciezka";
            this.tb_Sciezka.ReadOnly = true;
            this.tb_Sciezka.Size = new System.Drawing.Size(335, 20);
            this.tb_Sciezka.TabIndex = 0;
            this.tb_Sciezka.Text = "System decyzyjny";
            this.tb_Sciezka.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Wczytaj
            // 
            this.btn_Wczytaj.Location = new System.Drawing.Point(353, 9);
            this.btn_Wczytaj.Name = "btn_Wczytaj";
            this.btn_Wczytaj.Size = new System.Drawing.Size(75, 23);
            this.btn_Wczytaj.TabIndex = 1;
            this.btn_Wczytaj.Text = "...";
            this.btn_Wczytaj.UseVisualStyleBackColor = true;
            this.btn_Wczytaj.Click += new System.EventHandler(this.btn_Wczytaj_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // btn_oblicz
            // 
            this.btn_oblicz.BackColor = System.Drawing.SystemColors.Control;
            this.btn_oblicz.Location = new System.Drawing.Point(435, 284);
            this.btn_oblicz.Name = "btn_oblicz";
            this.btn_oblicz.Size = new System.Drawing.Size(75, 234);
            this.btn_oblicz.TabIndex = 2;
            this.btn_oblicz.Text = "Oblicz";
            this.btn_oblicz.UseVisualStyleBackColor = false;
            this.btn_oblicz.Click += new System.EventHandler(this.btn_oblicz_Click);
            // 
            // tb_wynik
            // 
            this.tb_wynik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_wynik.Location = new System.Drawing.Point(12, 38);
            this.tb_wynik.Multiline = true;
            this.tb_wynik.Name = "tb_wynik";
            this.tb_wynik.ReadOnly = true;
            this.tb_wynik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_wynik.Size = new System.Drawing.Size(416, 480);
            this.tb_wynik.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Próg Jakości";
            // 
            // cb_progJakosci
            // 
            this.cb_progJakosci.BackColor = System.Drawing.SystemColors.Window;
            this.cb_progJakosci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_progJakosci.FormattingEnabled = true;
            this.cb_progJakosci.Items.AddRange(new object[] {
            "1/10",
            "2/10",
            "3/10",
            "4/10"});
            this.cb_progJakosci.Location = new System.Drawing.Point(434, 189);
            this.cb_progJakosci.Name = "cb_progJakosci";
            this.cb_progJakosci.Size = new System.Drawing.Size(76, 21);
            this.cb_progJakosci.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(516, 530);
            this.Controls.Add(this.cb_progJakosci);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_wynik);
            this.Controls.Add(this.btn_oblicz);
            this.Controls.Add(this.btn_Wczytaj);
            this.Controls.Add(this.tb_Sciezka);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(532, 569);
            this.MinimumSize = new System.Drawing.Size(532, 569);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apriori - Piotr Uszler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Sciezka;
        private System.Windows.Forms.Button btn_Wczytaj;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btn_oblicz;
        private System.Windows.Forms.TextBox tb_wynik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_progJakosci;
    }
}

