namespace howto_weather_forecast2
{
    partial class Form2
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
        private void InitializeComponent()
        {
            this.lblEnterID = new System.Windows.Forms.Label();
            this.txtReceiverID = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblWeatherInfo = new System.Windows.Forms.Label();
            this.txtWeatherInfo = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblEnterID
            // 
            this.lblEnterID.AutoSize = true;
            this.lblEnterID.Location = new System.Drawing.Point(20, 20);
            this.lblEnterID.Name = "lblEnterID";
            this.lblEnterID.Size = new System.Drawing.Size(90, 13);
            this.lblEnterID.TabIndex = 0;
            this.lblEnterID.Text = "Nhập ID hoặc IP:";
            // 
            // txtReceiverID
            // 
            this.txtReceiverID.Location = new System.Drawing.Point(130, 20);
            this.txtReceiverID.Name = "txtReceiverID";
            this.txtReceiverID.Size = new System.Drawing.Size(200, 20);
            this.txtReceiverID.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(350, 20);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 30);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Gửi";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblWeatherInfo
            // 
            this.lblWeatherInfo.AutoSize = true;
            this.lblWeatherInfo.Location = new System.Drawing.Point(20, 60);
            this.lblWeatherInfo.Name = "lblWeatherInfo";
            this.lblWeatherInfo.Size = new System.Drawing.Size(92, 13);
            this.lblWeatherInfo.TabIndex = 3;
            this.lblWeatherInfo.Text = "Thông tin thời tiết:";
            // 
            // txtWeatherInfo
            // 
            this.txtWeatherInfo.Location = new System.Drawing.Point(20, 90);
            this.txtWeatherInfo.Multiline = true;
            this.txtWeatherInfo.Name = "txtWeatherInfo";
            this.txtWeatherInfo.ReadOnly = true;
            this.txtWeatherInfo.Size = new System.Drawing.Size(410, 150);
            this.txtWeatherInfo.TabIndex = 4;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(167, 57);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(100, 20);
            this.txtLog.TabIndex = 5;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(450, 260);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblEnterID);
            this.Controls.Add(this.txtReceiverID);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblWeatherInfo);
            this.Controls.Add(this.txtWeatherInfo);
            this.Name = "Form2";
            this.Text = "Ứng dụng chia sẻ thời tiết";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent1()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.lblEnterID = new System.Windows.Forms.Label();
            this.txtReceiverID = new System.Windows.Forms.TextBox();
            this.txtWeatherInfo = new System.Windows.Forms.TextBox();
            this.lblWeatherInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(350, 20);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 30);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // lblEnterID
            // 
            this.lblEnterID.AutoSize = true;
            this.lblEnterID.Location = new System.Drawing.Point(20, 20);
            this.lblEnterID.Name = "lblEnterID";
            this.lblEnterID.Size = new System.Drawing.Size(90, 13);
            this.lblEnterID.TabIndex = 1;
            this.lblEnterID.Text = "Nhập ID hoặc IP:";
            // 
            // txtReceiverID
            // 
            this.txtReceiverID.Location = new System.Drawing.Point(130, 20);
            this.txtReceiverID.Name = "txtReceiverID";
            this.txtReceiverID.Size = new System.Drawing.Size(200, 20);
            this.txtReceiverID.TabIndex = 2;
            // 
            // txtWeatherInfo
            // 
            this.txtWeatherInfo.Location = new System.Drawing.Point(23, 88);
            this.txtWeatherInfo.Name = "txtWeatherInfo";
            this.txtWeatherInfo.Size = new System.Drawing.Size(506, 20);
            this.txtWeatherInfo.TabIndex = 3;
            // 
            // lblWeatherInfo
            // 
            this.lblWeatherInfo.AutoSize = true;
            this.lblWeatherInfo.Location = new System.Drawing.Point(20, 60);
            this.lblWeatherInfo.Name = "lblWeatherInfo";
            this.lblWeatherInfo.Size = new System.Drawing.Size(92, 13);
            this.lblWeatherInfo.TabIndex = 4;
            this.lblWeatherInfo.Text = "Thông tin thời tiết:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblWeatherInfo);
            this.Controls.Add(this.txtWeatherInfo);
            this.Controls.Add(this.txtReceiverID);
            this.Controls.Add(this.lblEnterID);
            this.Controls.Add(this.btnSend);
            this.Name = "Form2";
            this.Text = "gửi thông tin chi tiết";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblEnterID;
        private System.Windows.Forms.TextBox txtReceiverID;
        private System.Windows.Forms.TextBox txtWeatherInfo;
        private System.Windows.Forms.Label lblWeatherInfo;
        private System.Windows.Forms.TextBox txtLog;

        // Khai báo txtWeatherInfo

    }
}