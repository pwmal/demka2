namespace demka2
{
    partial class UserControlTovar
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            labelArt = new Label();
            labelName = new Label();
            labelPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(18, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(175, 112);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelArt
            // 
            labelArt.AutoSize = true;
            labelArt.Location = new Point(199, 38);
            labelArt.Name = "labelArt";
            labelArt.Size = new Size(53, 15);
            labelArt.TabIndex = 1;
            labelArt.Text = "Артикул";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(339, 16);
            labelName.Name = "labelName";
            labelName.Size = new Size(90, 15);
            labelName.TabIndex = 2;
            labelName.Text = "Наименование";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(510, 38);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(67, 15);
            labelPrice.TabIndex = 3;
            labelPrice.Text = "Стоимость";
            // 
            // UserControlTovar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(labelPrice);
            Controls.Add(labelName);
            Controls.Add(labelArt);
            Controls.Add(pictureBox1);
            Name = "UserControlTovar";
            Size = new Size(587, 148);
            Click += UserControlTovar_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public PictureBox pictureBox1;
        public Label labelArt;
        public Label labelName;
        public Label labelPrice;
    }
}
