﻿namespace dubaothoitiet
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnForecast = new System.Windows.Forms.Button();
            this.lvwForecast = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboQuery = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtReceiverID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWeatherInfo = new System.Windows.Forms.TextBox();
            this.receive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Dự báo thời tiết:";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(121, 11);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(379, 22);
            this.txtLocation.TabIndex = 15;
            this.txtLocation.Text = "Vũng Tàu";
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // btnForecast
            // 
            this.btnForecast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnForecast.Location = new System.Drawing.Point(183, 54);
            this.btnForecast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(137, 28);
            this.btnForecast.TabIndex = 16;
            this.btnForecast.Text = "Dự báo thời tiết";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // lvwForecast
            // 
            this.lvwForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwForecast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwForecast.GridLines = true;
            this.lvwForecast.HideSelection = false;
            this.lvwForecast.Location = new System.Drawing.Point(16, 218);
            this.lvwForecast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvwForecast.Name = "lvwForecast";
            this.lvwForecast.Size = new System.Drawing.Size(484, 242);
            this.lvwForecast.TabIndex = 19;
            this.lvwForecast.UseCompatibleStateImageBehavior = false;
            this.lvwForecast.View = System.Windows.Forms.View.Details;
            this.lvwForecast.SelectedIndexChanged += new System.EventHandler(this.lvwForecast_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ngày tháng";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Thời gian";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nhiệt độ";
            this.columnHeader3.Width = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Thành phố:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(84, 91);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(132, 22);
            this.txtCity.TabIndex = 21;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(319, 91);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.ReadOnly = true;
            this.txtCountry.Size = new System.Drawing.Size(132, 22);
            this.txtCountry.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Quốc gia:";
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(319, 123);
            this.txtLong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLong.Name = "txtLong";
            this.txtLong.ReadOnly = true;
            this.txtLong.Size = new System.Drawing.Size(132, 22);
            this.txtLong.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Kinh độ:";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(84, 123);
            this.txtLat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLat.Name = "txtLat";
            this.txtLat.ReadOnly = true;
            this.txtLat.Size = new System.Drawing.Size(132, 22);
            this.txtLat.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 127);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Vĩ độ:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(84, 155);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(132, 22);
            this.txtId.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 159);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "ID:";
            // 
            // cboQuery
            // 
            this.cboQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuery.FormattingEnabled = true;
            this.cboQuery.Location = new System.Drawing.Point(16, 10);
            this.cboQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboQuery.Name = "cboQuery";
            this.cboQuery.Size = new System.Drawing.Size(96, 24);
            this.cboQuery.TabIndex = 30;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(755, 146);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(133, 28);
            this.btnSend.TabIndex = 31;
            this.btnSend.Text = "gửi client 2";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtReceiverID
            // 
            this.txtReceiverID.Location = new System.Drawing.Point(755, 10);
            this.txtReceiverID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReceiverID.Name = "txtReceiverID";
            this.txtReceiverID.Size = new System.Drawing.Size(163, 22);
            this.txtReceiverID.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "nhập địa chỉ IP\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtWeatherInfo
            // 
            this.txtWeatherInfo.Location = new System.Drawing.Point(755, 82);
            this.txtWeatherInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWeatherInfo.Name = "txtWeatherInfo";
            this.txtWeatherInfo.Size = new System.Drawing.Size(163, 22);
            this.txtWeatherInfo.TabIndex = 34;
            this.txtWeatherInfo.TextChanged += new System.EventHandler(this.txtWeatherInfo_TextChanged);
            // 
            // receive
            // 
            this.receive.Location = new System.Drawing.Point(521, 107);
            this.receive.Name = "receive";
            this.receive.Size = new System.Drawing.Size(152, 38);
            this.receive.TabIndex = 35;
            this.receive.Text = "Nhận dữ liệu";
            this.receive.UseVisualStyleBackColor = true;
            this.receive.Click += new System.EventHandler(this.receive_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnForecast;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 475);
            this.Controls.Add(this.receive);
            this.Controls.Add(this.txtWeatherInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReceiverID);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cboQuery);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwForecast);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnForecast);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Dự báo thời tiết - https://laptrinhvb.net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.ListView lvwForecast;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboQuery;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtReceiverID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWeatherInfo;
        private System.Windows.Forms.Button receive;
    }
}

