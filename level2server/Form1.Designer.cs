namespace ServerApp
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Monitoring_richTextBox = new System.Windows.Forms.RichTextBox();
            this.IP_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Port_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Monitoring_richTextBox
            // 
            this.Monitoring_richTextBox.Location = new System.Drawing.Point(31, 96);
            this.Monitoring_richTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Monitoring_richTextBox.Name = "Monitoring_richTextBox";
            this.Monitoring_richTextBox.Size = new System.Drawing.Size(967, 486);
            this.Monitoring_richTextBox.TabIndex = 0;
            this.Monitoring_richTextBox.Text = "";
            // 
            // IP_textBox
            // 
            this.IP_textBox.Location = new System.Drawing.Point(197, 46);
            this.IP_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IP_textBox.Name = "IP_textBox";
            this.IP_textBox.Size = new System.Drawing.Size(295, 25);
            this.IP_textBox.TabIndex = 1;
            this.IP_textBox.Text = "localhost";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Connect_Btn_Click);
            // 
            // Port_textBox
            // 
            this.Port_textBox.Location = new System.Drawing.Point(561, 46);
            this.Port_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Port_textBox.Name = "Port_textBox";
            this.Port_textBox.Size = new System.Drawing.Size(119, 25);
            this.Port_textBox.TabIndex = 4;
            this.Port_textBox.Text = "5000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(521, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 611);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port_textBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IP_textBox);
            this.Controls.Add(this.Monitoring_richTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Level2 Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Monitoring_richTextBox;
        private System.Windows.Forms.TextBox IP_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Port_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

