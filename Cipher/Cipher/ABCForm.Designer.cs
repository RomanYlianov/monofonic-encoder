namespace Cipher
{
    partial class ABCForm
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
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            ok_btn = new Button();
            cancel_btn = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 37);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(338, 96);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 19);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 1;
            label1.Text = "Enter ABC, separate by \",\"";
            // 
            // ok_btn
            // 
            ok_btn.BackColor = SystemColors.GradientActiveCaption;
            ok_btn.Location = new Point(17, 147);
            ok_btn.Name = "ok_btn";
            ok_btn.Size = new Size(111, 23);
            ok_btn.TabIndex = 2;
            ok_btn.Text = "OK";
            ok_btn.UseVisualStyleBackColor = false;
            ok_btn.Click += btn_Click;
            // 
            // cancel_btn
            // 
            cancel_btn.BackColor = SystemColors.ButtonShadow;
            cancel_btn.Location = new Point(239, 147);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(111, 23);
            cancel_btn.TabIndex = 3;
            cancel_btn.Text = "CANCEL";
            cancel_btn.UseVisualStyleBackColor = false;
            cancel_btn.Click += btn_Click;
            // 
            // ABCForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 186);
            Controls.Add(cancel_btn);
            Controls.Add(ok_btn);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ABCForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "set ABC";
         
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Label label1;
        private Button ok_btn;
        private Button cancel_btn;
    }
}