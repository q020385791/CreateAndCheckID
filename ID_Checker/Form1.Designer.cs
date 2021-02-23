
namespace ID_Checker
{
    partial class ID_Checker
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btncheck = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRandomAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btncheck
            // 
            this.btncheck.Location = new System.Drawing.Point(132, 66);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(86, 29);
            this.btncheck.TabIndex = 0;
            this.btncheck.Text = "Check";
            this.btncheck.UseVisualStyleBackColor = true;
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(132, 31);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(159, 29);
            this.txtID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "輸入身分證：";
            // 
            // btnRandomAdd
            // 
            this.btnRandomAdd.Location = new System.Drawing.Point(273, 66);
            this.btnRandomAdd.Name = "btnRandomAdd";
            this.btnRandomAdd.Size = new System.Drawing.Size(98, 28);
            this.btnRandomAdd.TabIndex = 3;
            this.btnRandomAdd.Text = "隨機產生";
            this.btnRandomAdd.UseVisualStyleBackColor = true;
            this.btnRandomAdd.Click += new System.EventHandler(this.btnRandomAdd_Click);
            // 
            // ID_Checker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 103);
            this.Controls.Add(this.btnRandomAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btncheck);
            this.Name = "ID_Checker";
            this.Text = "身分證字號確認與產生機";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncheck;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRandomAdd;
    }
}

