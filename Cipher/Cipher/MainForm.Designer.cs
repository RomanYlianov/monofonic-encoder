﻿namespace Cipher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            learn_btn = new Button();
            encrypt_btn = new Button();
            groupBox1 = new GroupBox();
            decrypt_btn = new Button();
            mulKoefficient = new NumericUpDown();
            label1 = new Label();
            symbolsStatistic = new CheckBox();
            progressBar1 = new ProgressBar();
            groupBox3 = new GroupBox();
            groupBox7 = new GroupBox();
            abc_btn = new Button();
            label2 = new Label();
            encodingCmb = new ComboBox();
            label3 = new Label();
            groupBox4 = new GroupBox();
            decrIncrRbtn = new RadioButton();
            decrZeroRbtn = new RadioButton();
            incrZeroRbtn = new RadioButton();
            incrDecrRbtn = new RadioButton();
            groupBox5 = new GroupBox();
            groupBox2 = new GroupBox();
            customRbtn = new RadioButton();
            defaultRbtn = new RadioButton();
            groupBox6 = new GroupBox();
            logger = new RichTextBox();
            learnGroupBox = new GroupBox();
            groupBox8 = new GroupBox();
            learnModeManualRbtn = new RadioButton();
            learnModeAutoRbtn = new RadioButton();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mulKoefficient).BeginInit();
            groupBox3.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            learnGroupBox.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // learn_btn
            // 
            learn_btn.BackColor = SystemColors.AppWorkspace;
            learn_btn.Location = new Point(6, 172);
            learn_btn.Name = "learn_btn";
            learn_btn.Size = new Size(168, 25);
            learn_btn.TabIndex = 1;
            learn_btn.Text = "LEARN";
            learn_btn.UseVisualStyleBackColor = false;
            learn_btn.Click += learn_btn_Click;
            // 
            // encrypt_btn
            // 
            encrypt_btn.BackColor = SystemColors.ActiveCaption;
            encrypt_btn.Location = new Point(6, 90);
            encrypt_btn.Name = "encrypt_btn";
            encrypt_btn.Size = new Size(146, 40);
            encrypt_btn.TabIndex = 2;
            encrypt_btn.Text = "ENCRYPT";
            encrypt_btn.UseVisualStyleBackColor = false;
            encrypt_btn.Click += encrypt_btn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(decrypt_btn);
            groupBox1.Controls.Add(encrypt_btn);
            groupBox1.Controls.Add(symbolsStatistic);
            groupBox1.Location = new Point(476, 121);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(156, 209);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "CIPHER";
            // 
            // decrypt_btn
            // 
            decrypt_btn.BackColor = SystemColors.ActiveCaption;
            decrypt_btn.Location = new Point(6, 152);
            decrypt_btn.Name = "decrypt_btn";
            decrypt_btn.Size = new Size(146, 40);
            decrypt_btn.TabIndex = 3;
            decrypt_btn.Text = "DECRYPT";
            decrypt_btn.UseVisualStyleBackColor = false;
            decrypt_btn.Click += decrypt_btn_Click;
            // 
            // mulKoefficient
            // 
            mulKoefficient.Location = new Point(8, 106);
            mulKoefficient.Name = "mulKoefficient";
            mulKoefficient.Size = new Size(154, 23);
            mulKoefficient.TabIndex = 6;
            mulKoefficient.ValueChanged += nd_koeff_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 83);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 5;
            label1.Text = "multiply coefficient";
            // 
            // symbolsStatistic
            // 
            symbolsStatistic.AutoSize = true;
            symbolsStatistic.Location = new Point(6, 37);
            symbolsStatistic.Name = "symbolsStatistic";
            symbolsStatistic.Size = new Size(144, 19);
            symbolsStatistic.TabIndex = 4;
            symbolsStatistic.Text = "show symbols statistic";
            symbolsStatistic.UseVisualStyleBackColor = true;
            symbolsStatistic.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(10, 31);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(491, 23);
            progressBar1.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox7);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Location = new Point(12, 121);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(272, 209);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "SETTINGS";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(abc_btn);
            groupBox7.Controls.Add(label2);
            groupBox7.Controls.Add(encodingCmb);
            groupBox7.Controls.Add(label3);
            groupBox7.Location = new Point(148, 48);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(124, 155);
            groupBox7.TabIndex = 4;
            groupBox7.TabStop = false;
            groupBox7.Text = "encoding and ABC";
            // 
            // abc_btn
            // 
            abc_btn.BackColor = SystemColors.GradientActiveCaption;
            abc_btn.Location = new Point(6, 120);
            abc_btn.Name = "abc_btn";
            abc_btn.RightToLeft = RightToLeft.No;
            abc_btn.Size = new Size(90, 24);
            abc_btn.TabIndex = 12;
            abc_btn.Text = "SET";
            abc_btn.UseVisualStyleBackColor = false;
            abc_btn.Click += abc_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 102);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 13;
            label2.Text = "SET ABC";
            // 
            // encodingCmb
            // 
            encodingCmb.FormattingEnabled = true;
            encodingCmb.Location = new Point(9, 53);
            encodingCmb.Name = "encodingCmb";
            encodingCmb.Size = new Size(87, 23);
            encodingCmb.TabIndex = 11;
            encodingCmb.SelectedValueChanged += encodingCmb_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 32);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 10;
            label3.Text = "encoding";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(decrIncrRbtn);
            groupBox4.Controls.Add(decrZeroRbtn);
            groupBox4.Controls.Add(incrZeroRbtn);
            groupBox4.Controls.Add(incrDecrRbtn);
            groupBox4.Location = new Point(6, 48);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(137, 155);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "order";
            // 
            // decrIncrRbtn
            // 
            decrIncrRbtn.AutoSize = true;
            decrIncrRbtn.Location = new Point(7, 120);
            decrIncrRbtn.Name = "decrIncrRbtn";
            decrIncrRbtn.Size = new Size(119, 19);
            decrIncrRbtn.TabIndex = 10;
            decrIncrRbtn.TabStop = true;
            decrIncrRbtn.Text = "decrease-increase";
            decrIncrRbtn.UseVisualStyleBackColor = true;
            decrIncrRbtn.CheckedChanged += radioButton_CheckedChanged;
            // 
            // decrZeroRbtn
            // 
            decrZeroRbtn.AutoSize = true;
            decrZeroRbtn.Location = new Point(7, 84);
            decrZeroRbtn.Name = "decrZeroRbtn";
            decrZeroRbtn.Size = new Size(98, 19);
            decrZeroRbtn.TabIndex = 9;
            decrZeroRbtn.TabStop = true;
            decrZeroRbtn.Text = "decrease-zero";
            decrZeroRbtn.UseVisualStyleBackColor = true;
            decrZeroRbtn.CheckedChanged += radioButton_CheckedChanged;
            // 
            // incrZeroRbtn
            // 
            incrZeroRbtn.AutoSize = true;
            incrZeroRbtn.Location = new Point(6, 22);
            incrZeroRbtn.Name = "incrZeroRbtn";
            incrZeroRbtn.Size = new Size(95, 19);
            incrZeroRbtn.TabIndex = 7;
            incrZeroRbtn.TabStop = true;
            incrZeroRbtn.Text = "increase-zero";
            incrZeroRbtn.UseVisualStyleBackColor = true;
            incrZeroRbtn.CheckedChanged += radioButton_CheckedChanged;
            // 
            // incrDecrRbtn
            // 
            incrDecrRbtn.AutoSize = true;
            incrDecrRbtn.Location = new Point(6, 53);
            incrDecrRbtn.Name = "incrDecrRbtn";
            incrDecrRbtn.Size = new Size(119, 19);
            incrDecrRbtn.TabIndex = 8;
            incrDecrRbtn.TabStop = true;
            incrDecrRbtn.Text = "increase-decrease";
            incrDecrRbtn.UseVisualStyleBackColor = true;
            incrDecrRbtn.CheckedChanged += radioButton_CheckedChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(progressBar1);
            groupBox5.Location = new Point(125, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(507, 93);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "PROGRESS";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(customRbtn);
            groupBox2.Controls.Add(defaultRbtn);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(90, 93);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "MODE";
            // 
            // customRbtn
            // 
            customRbtn.AutoSize = true;
            customRbtn.Location = new Point(12, 59);
            customRbtn.Name = "customRbtn";
            customRbtn.Size = new Size(65, 19);
            customRbtn.TabIndex = 1;
            customRbtn.TabStop = true;
            customRbtn.Text = "custom";
            customRbtn.UseVisualStyleBackColor = true;
            customRbtn.CheckedChanged += modeRbtn_CheckedChanged;
            // 
            // defaultRbtn
            // 
            defaultRbtn.AutoSize = true;
            defaultRbtn.Location = new Point(12, 22);
            defaultRbtn.Name = "defaultRbtn";
            defaultRbtn.Size = new Size(62, 19);
            defaultRbtn.TabIndex = 0;
            defaultRbtn.TabStop = true;
            defaultRbtn.Text = "default";
            defaultRbtn.UseVisualStyleBackColor = true;
            defaultRbtn.CheckedChanged += modeRbtn_CheckedChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(logger);
            groupBox6.Location = new Point(12, 330);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(620, 119);
            groupBox6.TabIndex = 10;
            groupBox6.TabStop = false;
            groupBox6.Text = "LOG";
            // 
            // logger
            // 
            logger.Location = new Point(16, 22);
            logger.Name = "logger";
            logger.ReadOnly = true;
            logger.Size = new Size(598, 91);
            logger.TabIndex = 0;
            logger.Text = "";
            // 
            // learnGroupBox
            // 
            learnGroupBox.Controls.Add(groupBox8);
            learnGroupBox.Controls.Add(learn_btn);
            learnGroupBox.Location = new Point(290, 127);
            learnGroupBox.Name = "learnGroupBox";
            learnGroupBox.Size = new Size(180, 203);
            learnGroupBox.TabIndex = 7;
            learnGroupBox.TabStop = false;
            learnGroupBox.Text = "learn system";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(learnModeManualRbtn);
            groupBox8.Controls.Add(learnModeAutoRbtn);
            groupBox8.Controls.Add(mulKoefficient);
            groupBox8.Controls.Add(label1);
            groupBox8.Location = new Point(6, 20);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(168, 139);
            groupBox8.TabIndex = 11;
            groupBox8.TabStop = false;
            groupBox8.Text = "learn mode";
            // 
            // learnModeManualRbtn
            // 
            learnModeManualRbtn.AutoSize = true;
            learnModeManualRbtn.Location = new Point(8, 54);
            learnModeManualRbtn.Name = "learnModeManualRbtn";
            learnModeManualRbtn.Size = new Size(65, 19);
            learnModeManualRbtn.TabIndex = 8;
            learnModeManualRbtn.TabStop = true;
            learnModeManualRbtn.Text = "manual";
            learnModeManualRbtn.UseVisualStyleBackColor = true;
            learnModeManualRbtn.CheckedChanged += learnModeRbtn_CheckedChanged;
            // 
            // learnModeAutoRbtn
            // 
            learnModeAutoRbtn.AutoSize = true;
            learnModeAutoRbtn.Location = new Point(6, 22);
            learnModeAutoRbtn.Name = "learnModeAutoRbtn";
            learnModeAutoRbtn.Size = new Size(79, 19);
            learnModeAutoRbtn.TabIndex = 7;
            learnModeAutoRbtn.TabStop = true;
            learnModeAutoRbtn.Text = "automatic";
            learnModeAutoRbtn.UseVisualStyleBackColor = true;
            learnModeAutoRbtn.CheckedChanged += learnModeRbtn_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 461);
            Controls.Add(learnGroupBox);
            Controls.Add(groupBox1);
            Controls.Add(groupBox6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "monophonic substitution";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mulKoefficient).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox6.ResumeLayout(false);
            learnGroupBox.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion


        private Button learn_btn;
        private Button encrypt_btn;
        private GroupBox groupBox1;
        private Button decrypt_btn;
        private ProgressBar progressBar1;
        private GroupBox groupBox3;
        private RadioButton incrZeroRbtn;
        private RadioButton incrDecrRbtn;
        private GroupBox groupBox4;
        private RadioButton decrZeroRbtn;

        private GroupBox groupBox5;
        private ComboBox encodingCmb;
        private Label label3;
        private GroupBox groupBox2;
        private RadioButton defaultRbtn;
        private RadioButton customRbtn;
        private GroupBox groupBox6;
        private RichTextBox logger;
        private GroupBox groupBox7;
        private Button abc_btn;
        private Label label2;
        private RadioButton decrIncrRbtn;
        private NumericUpDown mulKoefficient;
        private Label label1;
        private CheckBox symbolsStatistic;
        private GroupBox learnGroupBox;
        private RadioButton learnModeManualRbtn;
        private RadioButton learnModeAutoRbtn;
        private GroupBox groupBox8;
    }
}