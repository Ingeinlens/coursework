
namespace Coursework
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.tbGraviton = new System.Windows.Forms.TrackBar();
            this.tbGraviton2 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(2, 2);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(793, 363);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(3, 403);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(274, 56);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(182, 381);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(16, 17);
            this.lblDirection.TabIndex = 2;
            this.lblDirection.Text = "0";
            // 
            // tbGraviton
            // 
            this.tbGraviton.Location = new System.Drawing.Point(300, 403);
            this.tbGraviton.Maximum = 100;
            this.tbGraviton.Name = "tbGraviton";
            this.tbGraviton.Size = new System.Drawing.Size(186, 56);
            this.tbGraviton.TabIndex = 3;
            this.tbGraviton.Scroll += new System.EventHandler(this.tbGraviton_Scroll);
            // 
            // tbGraviton2
            // 
            this.tbGraviton2.Location = new System.Drawing.Point(551, 403);
            this.tbGraviton2.Maximum = 100;
            this.tbGraviton2.Name = "tbGraviton2";
            this.tbGraviton2.Size = new System.Drawing.Size(186, 56);
            this.tbGraviton2.TabIndex = 4;
            this.tbGraviton2.Scroll += new System.EventHandler(this.tbGraviton2_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Угол наклона эмиттера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Размер первого отражателя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Размер второго отражателя";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGraviton2);
            this.Controls.Add(this.tbGraviton);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Система частиц";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.TrackBar tbGraviton;
        private System.Windows.Forms.TrackBar tbGraviton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

