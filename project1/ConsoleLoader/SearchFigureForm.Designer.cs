
namespace Lab4
{
    partial class SearchFigureForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBoxVolume = new System.Windows.Forms.CheckBox();
            this.TextBoxVolume = new System.Windows.Forms.TextBox();
            this.CheckBoxBall = new System.Windows.Forms.CheckBox();
            this.CheckBoxPyramid = new System.Windows.Forms.CheckBox();
            this.CheckBoxParallelepiped = new System.Windows.Forms.CheckBox();
            this.ButtonShowFigure = new System.Windows.Forms.Button();
            this.CloseFromButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CheckBoxVolume);
            this.groupBox1.Controls.Add(this.TextBoxVolume);
            this.groupBox1.Controls.Add(this.CheckBoxBall);
            this.groupBox1.Controls.Add(this.CheckBoxPyramid);
            this.groupBox1.Controls.Add(this.CheckBoxParallelepiped);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(247, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Найти фигуру...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "м";
            // 
            // CheckBoxVolume
            // 
            this.CheckBoxVolume.AutoSize = true;
            this.CheckBoxVolume.Location = new System.Drawing.Point(8, 108);
            this.CheckBoxVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckBoxVolume.Name = "CheckBoxVolume";
            this.CheckBoxVolume.Size = new System.Drawing.Size(100, 20);
            this.CheckBoxVolume.TabIndex = 5;
            this.CheckBoxVolume.Text = "С объёмом";
            this.CheckBoxVolume.UseVisualStyleBackColor = true;
            this.CheckBoxVolume.CheckedChanged += new System.EventHandler(this.CheckBoxVolumeCheckedChanged);
            // 
            // TextBoxVolume
            // 
            this.TextBoxVolume.Location = new System.Drawing.Point(127, 105);
            this.TextBoxVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxVolume.Name = "TextBoxVolume";
            this.TextBoxVolume.Size = new System.Drawing.Size(76, 22);
            this.TextBoxVolume.TabIndex = 4;
            this.TextBoxVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // CheckBoxBall
            // 
            this.CheckBoxBall.AutoSize = true;
            this.CheckBoxBall.Location = new System.Drawing.Point(8, 80);
            this.CheckBoxBall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckBoxBall.Name = "CheckBoxBall";
            this.CheckBoxBall.Size = new System.Drawing.Size(56, 20);
            this.CheckBoxBall.TabIndex = 2;
            this.CheckBoxBall.Text = "Шар";
            this.CheckBoxBall.UseVisualStyleBackColor = true;
            // 
            // CheckBoxPyramid
            // 
            this.CheckBoxPyramid.AutoSize = true;
            this.CheckBoxPyramid.Location = new System.Drawing.Point(8, 52);
            this.CheckBoxPyramid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckBoxPyramid.Name = "CheckBoxPyramid";
            this.CheckBoxPyramid.Size = new System.Drawing.Size(96, 20);
            this.CheckBoxPyramid.TabIndex = 1;
            this.CheckBoxPyramid.Text = "Пирамиду";
            this.CheckBoxPyramid.UseVisualStyleBackColor = true;
            // 
            // CheckBoxParallelepiped
            // 
            this.CheckBoxParallelepiped.AutoSize = true;
            this.CheckBoxParallelepiped.Location = new System.Drawing.Point(8, 23);
            this.CheckBoxParallelepiped.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckBoxParallelepiped.Name = "CheckBoxParallelepiped";
            this.CheckBoxParallelepiped.Size = new System.Drawing.Size(143, 20);
            this.CheckBoxParallelepiped.TabIndex = 0;
            this.CheckBoxParallelepiped.Text = "Параллелепипед";
            this.CheckBoxParallelepiped.UseVisualStyleBackColor = true;
            // 
            // ButtonShowFigure
            // 
            this.ButtonShowFigure.Location = new System.Drawing.Point(16, 166);
            this.ButtonShowFigure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonShowFigure.Name = "ButtonShowFigure";
            this.ButtonShowFigure.Size = new System.Drawing.Size(119, 28);
            this.ButtonShowFigure.TabIndex = 1;
            this.ButtonShowFigure.Text = "Показать";
            this.ButtonShowFigure.UseVisualStyleBackColor = true;
            this.ButtonShowFigure.Click += new System.EventHandler(this.ButtonShowFigure_Click);
            // 
            // CloseFromButton
            // 
            this.CloseFromButton.Location = new System.Drawing.Point(143, 166);
            this.CloseFromButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseFromButton.Name = "CloseFromButton";
            this.CloseFromButton.Size = new System.Drawing.Size(120, 28);
            this.CloseFromButton.TabIndex = 2;
            this.CloseFromButton.Text = "Закрыть";
            this.CloseFromButton.UseVisualStyleBackColor = true;
            this.CloseFromButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // SearchFigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 245);
            this.ControlBox = false;
            this.Controls.Add(this.CloseFromButton);
            this.Controls.Add(this.ButtonShowFigure);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SearchFigureForm";
            this.Text = "Поиск";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxVolume;
        private System.Windows.Forms.TextBox TextBoxVolume;
        private System.Windows.Forms.CheckBox CheckBoxBall;
        private System.Windows.Forms.CheckBox CheckBoxPyramid;
        private System.Windows.Forms.CheckBox CheckBoxParallelepiped;
        private System.Windows.Forms.Button ButtonShowFigure;
        private System.Windows.Forms.Button CloseFromButton;
    }
}