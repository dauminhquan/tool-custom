namespace Tool_Custom
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
            this.components = new System.ComponentModel.Container();
            this.tb_linkProfile = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btn_open_chrome = new System.Windows.Forms.Button();
            this.lb_status = new System.Windows.Forms.Label();
            this.btn_load_asin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbsku = new System.Windows.Forms.Label();
            this.lb_asin = new System.Windows.Forms.Label();
            this.lb_sku = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.lb_numberProduct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_linkProfile
            // 
            this.tb_linkProfile.Location = new System.Drawing.Point(170, 52);
            this.tb_linkProfile.Name = "tb_linkProfile";
            this.tb_linkProfile.Size = new System.Drawing.Size(379, 22);
            this.tb_linkProfile.TabIndex = 0;
            this.tb_linkProfile.Text = "Profile 114";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đường dẫn Profile";
            // 
            // btn_open_chrome
            // 
            this.btn_open_chrome.Location = new System.Drawing.Point(569, 41);
            this.btn_open_chrome.Name = "btn_open_chrome";
            this.btn_open_chrome.Size = new System.Drawing.Size(117, 33);
            this.btn_open_chrome.TabIndex = 3;
            this.btn_open_chrome.Text = "Mở trình duyệt";
            this.btn_open_chrome.UseVisualStyleBackColor = true;
            this.btn_open_chrome.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(557, 399);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(46, 17);
            this.lb_status.TabIndex = 4;
            this.lb_status.Text = "label2";
            // 
            // btn_load_asin
            // 
            this.btn_load_asin.Location = new System.Drawing.Point(569, 80);
            this.btn_load_asin.Name = "btn_load_asin";
            this.btn_load_asin.Size = new System.Drawing.Size(117, 35);
            this.btn_load_asin.TabIndex = 5;
            this.btn_load_asin.Text = "Load Asin";
            this.btn_load_asin.UseVisualStyleBackColor = true;
            this.btn_load_asin.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "ASIN";
            // 
            // lbsku
            // 
            this.lbsku.AutoSize = true;
            this.lbsku.Location = new System.Drawing.Point(29, 384);
            this.lbsku.Name = "lbsku";
            this.lbsku.Size = new System.Drawing.Size(36, 17);
            this.lbsku.TabIndex = 7;
            this.lbsku.Text = "SKU";
            // 
            // lb_asin
            // 
            this.lb_asin.AutoSize = true;
            this.lb_asin.Location = new System.Drawing.Point(87, 351);
            this.lb_asin.Name = "lb_asin";
            this.lb_asin.Size = new System.Drawing.Size(46, 17);
            this.lb_asin.TabIndex = 8;
            this.lb_asin.Text = "label3";
            // 
            // lb_sku
            // 
            this.lb_sku.AutoSize = true;
            this.lb_sku.Location = new System.Drawing.Point(90, 384);
            this.lb_sku.Name = "lb_sku";
            this.lb_sku.Size = new System.Drawing.Size(46, 17);
            this.lb_sku.TabIndex = 9;
            this.lb_sku.Text = "label3";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(569, 150);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 10;
            this.btn_start.Text = "Test";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Btn_start_Click_1);
            // 
            // lb_numberProduct
            // 
            this.lb_numberProduct.AutoSize = true;
            this.lb_numberProduct.Location = new System.Drawing.Point(575, 207);
            this.lb_numberProduct.Name = "lb_numberProduct";
            this.lb_numberProduct.Size = new System.Drawing.Size(103, 17);
            this.lb_numberProduct.TabIndex = 11;
            this.lb_numberProduct.Text = "Có 0 sản phẩm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_numberProduct);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lb_sku);
            this.Controls.Add(this.lb_asin);
            this.Controls.Add(this.lbsku);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_load_asin);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.btn_open_chrome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_linkProfile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_linkProfile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_open_chrome;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Button btn_load_asin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbsku;
        private System.Windows.Forms.Label lb_asin;
        private System.Windows.Forms.Label lb_sku;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_numberProduct;
    }
}

