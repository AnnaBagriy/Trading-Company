namespace AppUI
{
    partial class BlockingUserForm
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
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.termTextBox = new System.Windows.Forms.TextBox();
            this.ifDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.ifDeleteLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reasonTextBox
            // 
            this.reasonTextBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.reasonTextBox.Location = new System.Drawing.Point(200, 103);
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new System.Drawing.Size(224, 22);
            this.reasonTextBox.TabIndex = 0;
            this.reasonTextBox.TextChanged += new System.EventHandler(this.reasonTextBox_TextChanged);
            // 
            // termTextBox
            // 
            this.termTextBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.termTextBox.Location = new System.Drawing.Point(268, 189);
            this.termTextBox.Name = "termTextBox";
            this.termTextBox.Size = new System.Drawing.Size(100, 22);
            this.termTextBox.TabIndex = 1;
            this.termTextBox.TextChanged += new System.EventHandler(this.termTextBox_TextChanged);
            // 
            // ifDeleteCheckBox
            // 
            this.ifDeleteCheckBox.AutoSize = true;
            this.ifDeleteCheckBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ifDeleteCheckBox.Location = new System.Drawing.Point(213, 254);
            this.ifDeleteCheckBox.Name = "ifDeleteCheckBox";
            this.ifDeleteCheckBox.Size = new System.Drawing.Size(201, 26);
            this.ifDeleteCheckBox.TabIndex = 2;
            this.ifDeleteCheckBox.Text = "Block and delete?";
            this.ifDeleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reasonLabel.Location = new System.Drawing.Point(60, 101);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(78, 22);
            this.reasonLabel.TabIndex = 3;
            this.reasonLabel.Text = "Reason";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLabel.Location = new System.Drawing.Point(25, 189);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(161, 22);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "Term (in hours)";
            // 
            // ifDeleteLabel
            // 
            this.ifDeleteLabel.AutoSize = true;
            this.ifDeleteLabel.Location = new System.Drawing.Point(304, 254);
            this.ifDeleteLabel.Name = "ifDeleteLabel";
            this.ifDeleteLabel.Size = new System.Drawing.Size(0, 17);
            this.ifDeleteLabel.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.okButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okButton.Location = new System.Drawing.Point(200, 343);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(224, 38);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Block user";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // BlockingUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(532, 453);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.ifDeleteLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.ifDeleteCheckBox);
            this.Controls.Add(this.termTextBox);
            this.Controls.Add(this.reasonTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "BlockingUserForm";
            this.Text = "BlockingUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.TextBox termTextBox;
        private System.Windows.Forms.CheckBox ifDeleteCheckBox;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label ifDeleteLabel;
        private System.Windows.Forms.Button okButton;
    }
}