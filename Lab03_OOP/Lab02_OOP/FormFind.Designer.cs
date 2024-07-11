
namespace Lab02_OOP
{
    partial class FormFind
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
            this.menuStripSearch = new System.Windows.Forms.MenuStrip();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фИОToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.балансToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типВкладаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.номеруСчетаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конструкторПоискаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типСчетаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.датаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.впередToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchLable = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.constructorFind = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.constrycterType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.constructorNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.constructorFIO = new System.Windows.Forms.TextBox();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStripSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripSearch
            // 
            this.menuStripSearch.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.сортировкаToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.впередToolStripMenuItem,
            this.назадToolStripMenuItem});
            this.menuStripSearch.Location = new System.Drawing.Point(0, 0);
            this.menuStripSearch.Name = "menuStripSearch";
            this.menuStripSearch.Size = new System.Drawing.Size(782, 28);
            this.menuStripSearch.TabIndex = 1;
            this.menuStripSearch.Text = "menuStrip2";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фИОToolStripMenuItem,
            this.балансToolStripMenuItem,
            this.типВкладаToolStripMenuItem,
            this.номеруСчетаToolStripMenuItem,
            this.конструкторПоискаToolStripMenuItem});
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // фИОToolStripMenuItem
            // 
            this.фИОToolStripMenuItem.Name = "фИОToolStripMenuItem";
            this.фИОToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.фИОToolStripMenuItem.Text = "ФИО";
            this.фИОToolStripMenuItem.Click += new System.EventHandler(this.фИОToolStripMenuItem_Click);
            // 
            // балансToolStripMenuItem
            // 
            this.балансToolStripMenuItem.Name = "балансToolStripMenuItem";
            this.балансToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.балансToolStripMenuItem.Text = "баланс";
            this.балансToolStripMenuItem.Click += new System.EventHandler(this.балансToolStripMenuItem_Click);
            // 
            // типВкладаToolStripMenuItem
            // 
            this.типВкладаToolStripMenuItem.Name = "типВкладаToolStripMenuItem";
            this.типВкладаToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.типВкладаToolStripMenuItem.Text = "тип вклада";
            this.типВкладаToolStripMenuItem.Click += new System.EventHandler(this.типВкладаToolStripMenuItem_Click);
            // 
            // номеруСчетаToolStripMenuItem
            // 
            this.номеруСчетаToolStripMenuItem.Name = "номеруСчетаToolStripMenuItem";
            this.номеруСчетаToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.номеруСчетаToolStripMenuItem.Text = "номеру счета";
            this.номеруСчетаToolStripMenuItem.Click += new System.EventHandler(this.номеруСчетаToolStripMenuItem_Click);
            // 
            // конструкторПоискаToolStripMenuItem
            // 
            this.конструкторПоискаToolStripMenuItem.Name = "конструкторПоискаToolStripMenuItem";
            this.конструкторПоискаToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.конструкторПоискаToolStripMenuItem.Text = "конструктор поиска";
            this.конструкторПоискаToolStripMenuItem.Click += new System.EventHandler(this.конструкторПоискаToolStripMenuItem_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типСчетаToolStripMenuItem,
            this.датаToolStripMenuItem});
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            this.сортировкаToolStripMenuItem.Click += new System.EventHandler(this.сортировкаToolStripMenuItem_Click);
            // 
            // типСчетаToolStripMenuItem
            // 
            this.типСчетаToolStripMenuItem.Name = "типСчетаToolStripMenuItem";
            this.типСчетаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.типСчетаToolStripMenuItem.Text = "Тип счета";
            this.типСчетаToolStripMenuItem.Click += new System.EventHandler(this.типСчетаToolStripMenuItem_Click);
            // 
            // датаToolStripMenuItem
            // 
            this.датаToolStripMenuItem.Name = "датаToolStripMenuItem";
            this.датаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.датаToolStripMenuItem.Text = "Дата";
            this.датаToolStripMenuItem.Click += new System.EventHandler(this.датаToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // впередToolStripMenuItem
            // 
            this.впередToolStripMenuItem.Name = "впередToolStripMenuItem";
            this.впередToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.впередToolStripMenuItem.Text = "Вперед";
            this.впередToolStripMenuItem.Click += new System.EventHandler(this.впередToolStripMenuItem_Click);
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.назадToolStripMenuItem.Text = "Назад";
            this.назадToolStripMenuItem.Click += new System.EventHandler(this.назадToolStripMenuItem_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(12, 201);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(755, 196);
            this.listBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Паспорт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тип вклада";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Номер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Баланс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(611, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Дата создания";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(552, 99);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(195, 22);
            this.searchTextBox.TabIndex = 9;
            // 
            // searchLable
            // 
            this.searchLable.AutoSize = true;
            this.searchLable.Location = new System.Drawing.Point(549, 69);
            this.searchLable.Name = "searchLable";
            this.searchLable.Size = new System.Drawing.Size(195, 17);
            this.searchLable.TabIndex = 10;
            this.searchLable.Text = "Введите данный для поиска";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.constructorFind);
            this.panel1.Controls.Add(this.constructorFIO);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.constructorNumber);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.constrycterType);
            this.panel1.Location = new System.Drawing.Point(15, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 115);
            this.panel1.TabIndex = 11;
            // 
            // constructorFind
            // 
            this.constructorFind.Location = new System.Drawing.Point(227, 64);
            this.constructorFind.Name = "constructorFind";
            this.constructorFind.Size = new System.Drawing.Size(167, 33);
            this.constructorFind.TabIndex = 28;
            this.constructorFind.Text = "Найти";
            this.constructorFind.UseVisualStyleBackColor = true;
            this.constructorFind.Click += new System.EventHandler(this.constructorFind_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Тип счета";
            // 
            // constrycterType
            // 
            this.constrycterType.Location = new System.Drawing.Point(227, 26);
            this.constrycterType.Name = "constrycterType";
            this.constrycterType.Size = new System.Drawing.Size(167, 22);
            this.constrycterType.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Номер счета";
            // 
            // constructorNumber
            // 
            this.constructorNumber.Location = new System.Drawing.Point(14, 75);
            this.constructorNumber.Name = "constructorNumber";
            this.constructorNumber.Size = new System.Drawing.Size(189, 22);
            this.constructorNumber.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "ФИО";
            // 
            // constructorFIO
            // 
            this.constructorFIO.Location = new System.Drawing.Point(14, 26);
            this.constructorFIO.Name = "constructorFIO";
            this.constructorFIO.Size = new System.Drawing.Size(189, 22);
            this.constructorFIO.TabIndex = 20;
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(534, 5);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(113, 23);
            this.buttonHide.TabIndex = 29;
            this.buttonHide.Text = "Скрыть";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(657, 5);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(113, 23);
            this.buttonShow.TabIndex = 30;
            this.buttonShow.Text = "Закрепить";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
          
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(552, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 33);
            this.button1.TabIndex = 31;
            this.button1.Text = "Cохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSavee_Click);
            // 
            // FormFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchLable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.menuStripSearch);
            this.Name = "FormFind";
            this.Text = "FormFind";
            this.menuStripSearch.ResumeLayout(false);
            this.menuStripSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripSearch;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фИОToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem балансToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типВкладаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem номеруСчетаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конструкторПоискаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типСчетаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem датаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem впередToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button constructorFind;
        private System.Windows.Forms.TextBox constructorFIO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox constructorNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox constrycterType;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button button1;
    }
}