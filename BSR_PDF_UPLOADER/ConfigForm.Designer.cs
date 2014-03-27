namespace BSR_PDF_UPLOADER
{
    partial class ConfigForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
        	this.label1 = new System.Windows.Forms.Label();
        	this.TBBSRBASE = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.TBBSRUSER = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.TBBSRPASS = new System.Windows.Forms.TextBox();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.checkConnection = new System.Windows.Forms.Button();
        	this.TBSEARCHFOLDER = new System.Windows.Forms.TextBox();
        	this.BrowseSearch = new System.Windows.Forms.Button();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.TBMOVEFOLDER = new System.Windows.Forms.TextBox();
        	this.BrowseMoveFolder = new System.Windows.Forms.Button();
        	this.RBMOVE = new System.Windows.Forms.RadioButton();
        	this.RBDELETE = new System.Windows.Forms.RadioButton();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.SaveButton = new System.Windows.Forms.Button();
        	this.groupBox4 = new System.Windows.Forms.GroupBox();
        	this.TBLOGFOLDER = new System.Windows.Forms.TextBox();
        	this.BrowseLogFolder = new System.Windows.Forms.Button();
        	this.label4 = new System.Windows.Forms.Label();
        	this.CBUSELOG = new System.Windows.Forms.CheckBox();
        	this.FolderBrowserDLG = new System.Windows.Forms.FolderBrowserDialog();
        	this.groupBox5 = new System.Windows.Forms.GroupBox();
        	this.RBREPLACEDOCS = new System.Windows.Forms.RadioButton();
        	this.RBADDDOCS = new System.Windows.Forms.RadioButton();
        	this.groupBox6 = new System.Windows.Forms.GroupBox();
        	this.CBREPLACEHASH = new System.Windows.Forms.CheckBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.TBREPLACEREG = new System.Windows.Forms.TextBox();
        	this.label5 = new System.Windows.Forms.Label();
        	this.TBCUSTOMREG = new System.Windows.Forms.TextBox();
        	this.CBUSECUSTOMREGEX = new System.Windows.Forms.CheckBox();
        	this.groupBox1.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.groupBox4.SuspendLayout();
        	this.groupBox5.SuspendLayout();
        	this.groupBox6.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(6, 18);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(23, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "БД";
        	// 
        	// TBBSRBASE
        	// 
        	this.TBBSRBASE.Location = new System.Drawing.Point(6, 34);
        	this.TBBSRBASE.Name = "TBBSRBASE";
        	this.TBBSRBASE.Size = new System.Drawing.Size(84, 20);
        	this.TBBSRBASE.TabIndex = 1;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(100, 18);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(80, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Пользователь";
        	// 
        	// TBBSRUSER
        	// 
        	this.TBBSRUSER.Location = new System.Drawing.Point(96, 34);
        	this.TBBSRUSER.Name = "TBBSRUSER";
        	this.TBBSRUSER.Size = new System.Drawing.Size(85, 20);
        	this.TBBSRUSER.TabIndex = 3;
        	this.TBBSRUSER.Text = "BSR";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(191, 18);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(45, 13);
        	this.label3.TabIndex = 4;
        	this.label3.Text = "Пароль";
        	// 
        	// TBBSRPASS
        	// 
        	this.TBBSRPASS.Location = new System.Drawing.Point(187, 34);
        	this.TBBSRPASS.Name = "TBBSRPASS";
        	this.TBBSRPASS.PasswordChar = '*';
        	this.TBBSRPASS.Size = new System.Drawing.Size(84, 20);
        	this.TBBSRPASS.TabIndex = 5;
        	this.TBBSRPASS.TextChanged += new System.EventHandler(this.TBBSRPASS_TextChanged);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.checkConnection);
        	this.groupBox1.Controls.Add(this.TBBSRPASS);
        	this.groupBox1.Controls.Add(this.label1);
        	this.groupBox1.Controls.Add(this.label3);
        	this.groupBox1.Controls.Add(this.TBBSRBASE);
        	this.groupBox1.Controls.Add(this.TBBSRUSER);
        	this.groupBox1.Controls.Add(this.label2);
        	this.groupBox1.Location = new System.Drawing.Point(12, 12);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(282, 95);
        	this.groupBox1.TabIndex = 6;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Доступ к БСР";
        	// 
        	// checkConnection
        	// 
        	this.checkConnection.Enabled = false;
        	this.checkConnection.Location = new System.Drawing.Point(94, 60);
        	this.checkConnection.Name = "checkConnection";
        	this.checkConnection.Size = new System.Drawing.Size(177, 23);
        	this.checkConnection.TabIndex = 6;
        	this.checkConnection.Text = "Проверить соединение";
        	this.checkConnection.UseVisualStyleBackColor = true;
        	this.checkConnection.Click += new System.EventHandler(this.checkConnection_Click);
        	// 
        	// TBSEARCHFOLDER
        	// 
        	this.TBSEARCHFOLDER.Location = new System.Drawing.Point(9, 19);
        	this.TBSEARCHFOLDER.Name = "TBSEARCHFOLDER";
        	this.TBSEARCHFOLDER.Size = new System.Drawing.Size(183, 20);
        	this.TBSEARCHFOLDER.TabIndex = 7;
        	// 
        	// BrowseSearch
        	// 
        	this.BrowseSearch.Location = new System.Drawing.Point(198, 19);
        	this.BrowseSearch.Name = "BrowseSearch";
        	this.BrowseSearch.Size = new System.Drawing.Size(75, 20);
        	this.BrowseSearch.TabIndex = 8;
        	this.BrowseSearch.Text = "Обзор";
        	this.BrowseSearch.UseVisualStyleBackColor = true;
        	this.BrowseSearch.Click += new System.EventHandler(this.BrowseSearch_Click);
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.TBMOVEFOLDER);
        	this.groupBox2.Controls.Add(this.BrowseMoveFolder);
        	this.groupBox2.Controls.Add(this.RBMOVE);
        	this.groupBox2.Controls.Add(this.RBDELETE);
        	this.groupBox2.Location = new System.Drawing.Point(12, 113);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(282, 96);
        	this.groupBox2.TabIndex = 9;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "После загрузки";
        	// 
        	// TBMOVEFOLDER
        	// 
        	this.TBMOVEFOLDER.Enabled = false;
        	this.TBMOVEFOLDER.Location = new System.Drawing.Point(9, 65);
        	this.TBMOVEFOLDER.Name = "TBMOVEFOLDER";
        	this.TBMOVEFOLDER.Size = new System.Drawing.Size(183, 20);
        	this.TBMOVEFOLDER.TabIndex = 9;
        	// 
        	// BrowseMoveFolder
        	// 
        	this.BrowseMoveFolder.Enabled = false;
        	this.BrowseMoveFolder.Location = new System.Drawing.Point(201, 65);
        	this.BrowseMoveFolder.Name = "BrowseMoveFolder";
        	this.BrowseMoveFolder.Size = new System.Drawing.Size(75, 20);
        	this.BrowseMoveFolder.TabIndex = 10;
        	this.BrowseMoveFolder.Text = "Обзор";
        	this.BrowseMoveFolder.UseVisualStyleBackColor = true;
        	this.BrowseMoveFolder.Click += new System.EventHandler(this.BrowseMoveFolder_Click);
        	// 
        	// RBMOVE
        	// 
        	this.RBMOVE.AutoSize = true;
        	this.RBMOVE.Location = new System.Drawing.Point(9, 42);
        	this.RBMOVE.Name = "RBMOVE";
        	this.RBMOVE.Size = new System.Drawing.Size(102, 17);
        	this.RBMOVE.TabIndex = 1;
        	this.RBMOVE.Text = "Переместить в";
        	this.RBMOVE.UseVisualStyleBackColor = true;
        	this.RBMOVE.CheckedChanged += new System.EventHandler(this.RBMOVE_CheckedChanged);
        	// 
        	// RBDELETE
        	// 
        	this.RBDELETE.AutoSize = true;
        	this.RBDELETE.Checked = true;
        	this.RBDELETE.Location = new System.Drawing.Point(9, 19);
        	this.RBDELETE.Name = "RBDELETE";
        	this.RBDELETE.Size = new System.Drawing.Size(68, 17);
        	this.RBDELETE.TabIndex = 0;
        	this.RBDELETE.TabStop = true;
        	this.RBDELETE.Text = "Удалить";
        	this.RBDELETE.UseVisualStyleBackColor = true;
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Controls.Add(this.TBSEARCHFOLDER);
        	this.groupBox3.Controls.Add(this.BrowseSearch);
        	this.groupBox3.Location = new System.Drawing.Point(300, 12);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(282, 50);
        	this.groupBox3.TabIndex = 10;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "Папка с файлами";
        	// 
        	// SaveButton
        	// 
        	this.SaveButton.Location = new System.Drawing.Point(461, 276);
        	this.SaveButton.Name = "SaveButton";
        	this.SaveButton.Size = new System.Drawing.Size(121, 41);
        	this.SaveButton.TabIndex = 11;
        	this.SaveButton.Text = "Сохранить";
        	this.SaveButton.UseVisualStyleBackColor = true;
        	this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
        	// 
        	// groupBox4
        	// 
        	this.groupBox4.Controls.Add(this.TBLOGFOLDER);
        	this.groupBox4.Controls.Add(this.BrowseLogFolder);
        	this.groupBox4.Controls.Add(this.label4);
        	this.groupBox4.Controls.Add(this.CBUSELOG);
        	this.groupBox4.Location = new System.Drawing.Point(300, 143);
        	this.groupBox4.Name = "groupBox4";
        	this.groupBox4.Size = new System.Drawing.Size(282, 87);
        	this.groupBox4.TabIndex = 12;
        	this.groupBox4.TabStop = false;
        	this.groupBox4.Text = "Лог";
        	// 
        	// TBLOGFOLDER
        	// 
        	this.TBLOGFOLDER.Location = new System.Drawing.Point(9, 55);
        	this.TBLOGFOLDER.Name = "TBLOGFOLDER";
        	this.TBLOGFOLDER.Size = new System.Drawing.Size(183, 20);
        	this.TBLOGFOLDER.TabIndex = 9;
        	// 
        	// BrowseLogFolder
        	// 
        	this.BrowseLogFolder.Location = new System.Drawing.Point(198, 55);
        	this.BrowseLogFolder.Name = "BrowseLogFolder";
        	this.BrowseLogFolder.Size = new System.Drawing.Size(75, 20);
        	this.BrowseLogFolder.TabIndex = 10;
        	this.BrowseLogFolder.Text = "Обзор";
        	this.BrowseLogFolder.UseVisualStyleBackColor = true;
        	this.BrowseLogFolder.Click += new System.EventHandler(this.BrowseLogFolder_Click);
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(6, 39);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(106, 13);
        	this.label4.TabIndex = 1;
        	this.label4.Text = "Папка для журнала";
        	// 
        	// CBUSELOG
        	// 
        	this.CBUSELOG.AutoSize = true;
        	this.CBUSELOG.Location = new System.Drawing.Point(6, 19);
        	this.CBUSELOG.Name = "CBUSELOG";
        	this.CBUSELOG.Size = new System.Drawing.Size(204, 17);
        	this.CBUSELOG.TabIndex = 0;
        	this.CBUSELOG.Text = "Вести подробный журнал загрузки";
        	this.CBUSELOG.UseVisualStyleBackColor = true;
        	this.CBUSELOG.CheckedChanged += new System.EventHandler(this.CBUSELOG_CheckedChanged);
        	// 
        	// groupBox5
        	// 
        	this.groupBox5.Controls.Add(this.RBREPLACEDOCS);
        	this.groupBox5.Controls.Add(this.RBADDDOCS);
        	this.groupBox5.Location = new System.Drawing.Point(300, 68);
        	this.groupBox5.Name = "groupBox5";
        	this.groupBox5.Size = new System.Drawing.Size(282, 69);
        	this.groupBox5.TabIndex = 13;
        	this.groupBox5.TabStop = false;
        	this.groupBox5.Text = "Дубли";
        	// 
        	// RBREPLACEDOCS
        	// 
        	this.RBREPLACEDOCS.AutoSize = true;
        	this.RBREPLACEDOCS.Location = new System.Drawing.Point(6, 43);
        	this.RBREPLACEDOCS.Name = "RBREPLACEDOCS";
        	this.RBREPLACEDOCS.Size = new System.Drawing.Size(183, 17);
        	this.RBREPLACEDOCS.TabIndex = 1;
        	this.RBREPLACEDOCS.Text = "Заменять последний документ";
        	this.RBREPLACEDOCS.UseVisualStyleBackColor = true;
        	// 
        	// RBADDDOCS
        	// 
        	this.RBADDDOCS.AutoSize = true;
        	this.RBADDDOCS.Checked = true;
        	this.RBADDDOCS.Location = new System.Drawing.Point(6, 20);
        	this.RBADDDOCS.Name = "RBADDDOCS";
        	this.RBADDDOCS.Size = new System.Drawing.Size(197, 17);
        	this.RBADDDOCS.TabIndex = 0;
        	this.RBADDDOCS.TabStop = true;
        	this.RBADDDOCS.Text = "Добавлять документы в карточку";
        	this.RBADDDOCS.UseVisualStyleBackColor = true;
        	// 
        	// groupBox6
        	// 
        	this.groupBox6.Controls.Add(this.CBREPLACEHASH);
        	this.groupBox6.Controls.Add(this.label6);
        	this.groupBox6.Controls.Add(this.TBREPLACEREG);
        	this.groupBox6.Controls.Add(this.label5);
        	this.groupBox6.Controls.Add(this.TBCUSTOMREG);
        	this.groupBox6.Controls.Add(this.CBUSECUSTOMREGEX);
        	this.groupBox6.Location = new System.Drawing.Point(12, 215);
        	this.groupBox6.Name = "groupBox6";
        	this.groupBox6.Size = new System.Drawing.Size(282, 190);
        	this.groupBox6.TabIndex = 14;
        	this.groupBox6.TabStop = false;
        	this.groupBox6.Text = "Способ определения номера дела";
        	// 
        	// CBREPLACEHASH
        	// 
        	this.CBREPLACEHASH.Location = new System.Drawing.Point(9, 19);
        	this.CBREPLACEHASH.Name = "CBREPLACEHASH";
        	this.CBREPLACEHASH.Size = new System.Drawing.Size(267, 38);
        	this.CBREPLACEHASH.TabIndex = 5;
        	this.CBREPLACEHASH.Text = "Автоматически заменять символ # в имени файла на /";
        	this.CBREPLACEHASH.UseVisualStyleBackColor = true;
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(6, 145);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(46, 13);
        	this.label6.TabIndex = 4;
        	this.label6.Text = "Замена";
        	// 
        	// TBREPLACEREG
        	// 
        	this.TBREPLACEREG.Location = new System.Drawing.Point(9, 161);
        	this.TBREPLACEREG.Name = "TBREPLACEREG";
        	this.TBREPLACEREG.Size = new System.Drawing.Size(262, 20);
        	this.TBREPLACEREG.TabIndex = 3;
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(8, 106);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(39, 13);
        	this.label5.TabIndex = 2;
        	this.label5.Text = "Поиск";
        	// 
        	// TBCUSTOMREG
        	// 
        	this.TBCUSTOMREG.Location = new System.Drawing.Point(9, 122);
        	this.TBCUSTOMREG.Name = "TBCUSTOMREG";
        	this.TBCUSTOMREG.Size = new System.Drawing.Size(262, 20);
        	this.TBCUSTOMREG.TabIndex = 1;
        	// 
        	// CBUSECUSTOMREGEX
        	// 
        	this.CBUSECUSTOMREGEX.Location = new System.Drawing.Point(9, 58);
        	this.CBUSECUSTOMREGEX.Name = "CBUSECUSTOMREGEX";
        	this.CBUSECUSTOMREGEX.Size = new System.Drawing.Size(270, 45);
        	this.CBUSECUSTOMREGEX.TabIndex = 0;
        	this.CBUSECUSTOMREGEX.Text = "Я на 100% понимаю, что делаю и хочу изменить регулярное выражение для определения" +
        	" номера дела";
        	this.CBUSECUSTOMREGEX.UseVisualStyleBackColor = true;
        	this.CBUSECUSTOMREGEX.CheckedChanged += new System.EventHandler(this.CBUSECUSTOMREGEX_CheckedChanged);
        	// 
        	// ConfigForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(596, 415);
        	this.Controls.Add(this.groupBox6);
        	this.Controls.Add(this.groupBox5);
        	this.Controls.Add(this.groupBox4);
        	this.Controls.Add(this.SaveButton);
        	this.Controls.Add(this.groupBox3);
        	this.Controls.Add(this.groupBox2);
        	this.Controls.Add(this.groupBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Name = "ConfigForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Настройка";
        	this.Load += new System.EventHandler(this.ConfigForm_Load);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox3.PerformLayout();
        	this.groupBox4.ResumeLayout(false);
        	this.groupBox4.PerformLayout();
        	this.groupBox5.ResumeLayout(false);
        	this.groupBox5.PerformLayout();
        	this.groupBox6.ResumeLayout(false);
        	this.groupBox6.PerformLayout();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.CheckBox CBREPLACEHASH;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBBSRBASE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBBSRUSER;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBBSRPASS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button checkConnection;
        private System.Windows.Forms.TextBox TBSEARCHFOLDER;
        private System.Windows.Forms.Button BrowseSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TBMOVEFOLDER;
        private System.Windows.Forms.Button BrowseMoveFolder;
        private System.Windows.Forms.RadioButton RBMOVE;
        private System.Windows.Forms.RadioButton RBDELETE;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TBLOGFOLDER;
        private System.Windows.Forms.Button BrowseLogFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CBUSELOG;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDLG;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton RBREPLACEDOCS;
        private System.Windows.Forms.RadioButton RBADDDOCS;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox TBCUSTOMREG;
        private System.Windows.Forms.CheckBox CBUSECUSTOMREGEX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBREPLACEREG;
        private System.Windows.Forms.Label label5;
    }
}

