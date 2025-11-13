
namespace Lab4
{
    partial class AddFigureForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FigureChoiceComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OkAddFigureButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadiusTextbox = new System.Windows.Forms.TextBox();
            this.HeightTextbox = new System.Windows.Forms.TextBox();
            this.WidthTextbox = new System.Windows.Forms.TextBox();
            this.LengthTextbox = new System.Windows.Forms.TextBox();
            this.RadiusLabel = new System.Windows.Forms.Label();
            this.HeigthLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.CloseFormButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FigureChoiceComboBox);
            this.groupBox1.Location = new System.Drawing.Point(19, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(207, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фигура";
            // 
            // FigureChoiceComboBox
            // 
            this.FigureChoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FigureChoiceComboBox.FormattingEnabled = true;
            this.FigureChoiceComboBox.Items.AddRange(new object[] {
            "Параллелепипед",
            "Пирамида",
            "Шар"});
            this.FigureChoiceComboBox.Location = new System.Drawing.Point(13, 32);
            this.FigureChoiceComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FigureChoiceComboBox.Name = "FigureChoiceComboBox";
            this.FigureChoiceComboBox.Size = new System.Drawing.Size(180, 24);
            this.FigureChoiceComboBox.TabIndex = 5;
            this.FigureChoiceComboBox.SelectedIndexChanged += new System.EventHandler(this.FigureChoiceComboBox_SelectedIndexChanged);
            // 
            // OkAddFigureButton
            // 
            this.OkAddFigureButton.Location = new System.Drawing.Point(19, 238);
            this.OkAddFigureButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OkAddFigureButton.Name = "OkAddFigureButton";
            this.OkAddFigureButton.Size = new System.Drawing.Size(100, 28);
            this.OkAddFigureButton.TabIndex = 1;
            this.OkAddFigureButton.Text = "ОК";
            this.OkAddFigureButton.UseVisualStyleBackColor = true;
            this.OkAddFigureButton.Click += new System.EventHandler(this.OkAddFigureButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadiusTextbox);
            this.groupBox2.Controls.Add(this.HeightTextbox);
            this.groupBox2.Controls.Add(this.WidthTextbox);
            this.groupBox2.Controls.Add(this.LengthTextbox);
            this.groupBox2.Controls.Add(this.RadiusLabel);
            this.groupBox2.Controls.Add(this.HeigthLabel);
            this.groupBox2.Controls.Add(this.WidthLabel);
            this.groupBox2.Controls.Add(this.LengthLabel);
            this.groupBox2.Location = new System.Drawing.Point(19, 105);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(207, 126);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры (м)";
            // 
            // RadiusTextbox
            // 
            this.RadiusTextbox.Location = new System.Drawing.Point(79, 26);
            this.RadiusTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadiusTextbox.Name = "RadiusTextbox";
            this.RadiusTextbox.Size = new System.Drawing.Size(112, 22);
            this.RadiusTextbox.TabIndex = 7;
            this.RadiusTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // HeightTextbox
            // 
            this.HeightTextbox.Location = new System.Drawing.Point(79, 92);
            this.HeightTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HeightTextbox.Name = "HeightTextbox";
            this.HeightTextbox.Size = new System.Drawing.Size(112, 22);
            this.HeightTextbox.TabIndex = 6;
            this.HeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // WidthTextbox
            // 
            this.WidthTextbox.Location = new System.Drawing.Point(79, 58);
            this.WidthTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WidthTextbox.Name = "WidthTextbox";
            this.WidthTextbox.Size = new System.Drawing.Size(112, 22);
            this.WidthTextbox.TabIndex = 5;
            this.WidthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // LengthTextbox
            // 
            this.LengthTextbox.Location = new System.Drawing.Point(79, 26);
            this.LengthTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LengthTextbox.Name = "LengthTextbox";
            this.LengthTextbox.Size = new System.Drawing.Size(112, 22);
            this.LengthTextbox.TabIndex = 4;
            this.LengthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // RadiusLabel
            // 
            this.RadiusLabel.AutoSize = true;
            this.RadiusLabel.Location = new System.Drawing.Point(8, 30);
            this.RadiusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RadiusLabel.Name = "RadiusLabel";
            this.RadiusLabel.Size = new System.Drawing.Size(58, 16);
            this.RadiusLabel.TabIndex = 3;
            this.RadiusLabel.Text = "Радиус:";
            // 
            // HeigthLabel
            // 
            this.HeigthLabel.AutoSize = true;
            this.HeigthLabel.Location = new System.Drawing.Point(8, 96);
            this.HeigthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeigthLabel.Name = "HeigthLabel";
            this.HeigthLabel.Size = new System.Drawing.Size(58, 16);
            this.HeigthLabel.TabIndex = 2;
            this.HeigthLabel.Text = "Высота:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(8, 62);
            this.WidthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(61, 16);
            this.WidthLabel.TabIndex = 1;
            this.WidthLabel.Text = "Ширина:";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(8, 30);
            this.LengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(51, 16);
            this.LengthLabel.TabIndex = 0;
            this.LengthLabel.Text = "Длина:";
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Location = new System.Drawing.Point(125, 238);
            this.CloseFormButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(100, 28);
            this.CloseFormButton.TabIndex = 5;
            this.CloseFormButton.Text = "Закрыть";
            this.CloseFormButton.UseVisualStyleBackColor = true;
            this.CloseFormButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // AddFigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 318);
            this.ControlBox = false;
            this.Controls.Add(this.CloseFormButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.OkAddFigureButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFigureForm";
            this.Text = "Добавить фигуру";
            this.Load += new System.EventHandler(this.AddFigureForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OkAddFigureButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label RadiusLabel;
        private System.Windows.Forms.Label HeigthLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.TextBox HeightTextbox;
        private System.Windows.Forms.TextBox WidthTextbox;
        private System.Windows.Forms.TextBox LengthTextbox;
        private System.Windows.Forms.ComboBox FigureChoiceComboBox;
        private System.Windows.Forms.TextBox RadiusTextbox;
        private System.Windows.Forms.Button CloseFormButton;
    }
}