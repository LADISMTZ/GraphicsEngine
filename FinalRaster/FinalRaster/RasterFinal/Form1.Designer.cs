namespace RasterFinal
{
    partial class MyForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PNL_MAIN = new System.Windows.Forms.Panel();
            PCT_CANVAS = new System.Windows.Forms.PictureBox();
            PNL_RIGHT = new System.Windows.Forms.Panel();
            listBox4 = new System.Windows.Forms.ListBox();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            textBoxAlpha = new System.Windows.Forms.TextBox();
            brightAndContrast = new System.Windows.Forms.TextBox();
            listBox3 = new System.Windows.Forms.ListBox();
            listBox2 = new System.Windows.Forms.ListBox();
            label10 = new System.Windows.Forms.Label();
            PNL_LEFT = new System.Windows.Forms.Panel();
            label9 = new System.Windows.Forms.Label();
            listBox1 = new System.Windows.Forms.ListBox();
            PNL_BOTTOM = new System.Windows.Forms.Panel();
            pos = new System.Windows.Forms.Button();
            buttonTZ = new System.Windows.Forms.Button();
            neg = new System.Windows.Forms.Button();
            buttonTY = new System.Windows.Forms.Button();
            ScaleLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            buttonTX = new System.Windows.Forms.Button();
            subtractScaleButton = new System.Windows.Forms.Button();
            addScaleButton = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            scaleTextBox = new System.Windows.Forms.TextBox();
            rotateLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            buttonPlayX = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            buttonPlayZ = new System.Windows.Forms.Button();
            buttonPlayY = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            PNL_HEADER = new System.Windows.Forms.Panel();
            buttonPlay = new System.Windows.Forms.Button();
            buttonKF2 = new System.Windows.Forms.Button();
            buttonKF1 = new System.Windows.Forms.Button();
            buttonBodies = new System.Windows.Forms.Button();
            buttonLines = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            TIMER = new System.Windows.Forms.Timer(components);
            DeleteButton = new System.Windows.Forms.Button();
            PNL_MAIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            PNL_RIGHT.SuspendLayout();
            PNL_LEFT.SuspendLayout();
            PNL_BOTTOM.SuspendLayout();
            PNL_HEADER.SuspendLayout();
            SuspendLayout();
            // 
            // PNL_MAIN
            // 
            PNL_MAIN.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            PNL_MAIN.Controls.Add(PCT_CANVAS);
            PNL_MAIN.Controls.Add(PNL_RIGHT);
            PNL_MAIN.Controls.Add(PNL_LEFT);
            PNL_MAIN.Controls.Add(PNL_BOTTOM);
            PNL_MAIN.Controls.Add(PNL_HEADER);
            PNL_MAIN.Dock = System.Windows.Forms.DockStyle.Fill;
            PNL_MAIN.Location = new System.Drawing.Point(0, 0);
            PNL_MAIN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PNL_MAIN.Name = "PNL_MAIN";
            PNL_MAIN.Size = new System.Drawing.Size(1539, 840);
            PNL_MAIN.TabIndex = 0;
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            PCT_CANVAS.Dock = System.Windows.Forms.DockStyle.Fill;
            PCT_CANVAS.Location = new System.Drawing.Point(118, 100);
            PCT_CANVAS.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new System.Drawing.Size(1301, 607);
            PCT_CANVAS.TabIndex = 4;
            PCT_CANVAS.TabStop = false;
            PCT_CANVAS.LoadCompleted += PCT_CANVAS_LoadCompleted;
            PCT_CANVAS.MouseMove += PCT_CANVAS_MouseMove;
            // 
            // PNL_RIGHT
            // 
            PNL_RIGHT.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            PNL_RIGHT.Controls.Add(listBox4);
            PNL_RIGHT.Controls.Add(label12);
            PNL_RIGHT.Controls.Add(label11);
            PNL_RIGHT.Controls.Add(textBoxAlpha);
            PNL_RIGHT.Controls.Add(brightAndContrast);
            PNL_RIGHT.Controls.Add(listBox3);
            PNL_RIGHT.Controls.Add(listBox2);
            PNL_RIGHT.Controls.Add(label10);
            PNL_RIGHT.Dock = System.Windows.Forms.DockStyle.Right;
            PNL_RIGHT.Location = new System.Drawing.Point(1419, 100);
            PNL_RIGHT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PNL_RIGHT.Name = "PNL_RIGHT";
            PNL_RIGHT.Size = new System.Drawing.Size(120, 607);
            PNL_RIGHT.TabIndex = 3;
            // 
            // listBox4
            // 
            listBox4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            listBox4.ForeColor = System.Drawing.SystemColors.Window;
            listBox4.FormattingEnabled = true;
            listBox4.Location = new System.Drawing.Point(15, 323);
            listBox4.Name = "listBox4";
            listBox4.Size = new System.Drawing.Size(73, 104);
            listBox4.TabIndex = 8;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = System.Drawing.Color.Green;
            label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label12.Location = new System.Drawing.Point(15, 293);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(19, 20);
            label12.TabIndex = 7;
            label12.Text = "A";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = System.Drawing.Color.Green;
            label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label11.Location = new System.Drawing.Point(15, 260);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(18, 20);
            label11.TabIndex = 6;
            label11.Text = "B";
            // 
            // textBoxAlpha
            // 
            textBoxAlpha.Location = new System.Drawing.Point(35, 290);
            textBoxAlpha.Name = "textBoxAlpha";
            textBoxAlpha.Size = new System.Drawing.Size(53, 27);
            textBoxAlpha.TabIndex = 5;
            textBoxAlpha.Text = "0";
            // 
            // brightAndContrast
            // 
            brightAndContrast.Location = new System.Drawing.Point(35, 257);
            brightAndContrast.Name = "brightAndContrast";
            brightAndContrast.Size = new System.Drawing.Size(53, 27);
            brightAndContrast.TabIndex = 4;
            brightAndContrast.Text = "0";
            // 
            // listBox3
            // 
            listBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            listBox3.ForeColor = System.Drawing.SystemColors.Window;
            listBox3.FormattingEnabled = true;
            listBox3.Location = new System.Drawing.Point(15, 147);
            listBox3.Name = "listBox3";
            listBox3.Size = new System.Drawing.Size(73, 104);
            listBox3.TabIndex = 3;
            // 
            // listBox2
            // 
            listBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            listBox2.ForeColor = System.Drawing.SystemColors.Window;
            listBox2.FormattingEnabled = true;
            listBox2.Location = new System.Drawing.Point(15, 37);
            listBox2.Name = "listBox2";
            listBox2.Size = new System.Drawing.Size(73, 104);
            listBox2.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.Color.Green;
            label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label10.Location = new System.Drawing.Point(15, 3);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(48, 20);
            label10.TabIndex = 2;
            label10.Text = "Filters";
            // 
            // PNL_LEFT
            // 
            PNL_LEFT.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            PNL_LEFT.Controls.Add(DeleteButton);
            PNL_LEFT.Controls.Add(label9);
            PNL_LEFT.Controls.Add(listBox1);
            PNL_LEFT.Dock = System.Windows.Forms.DockStyle.Left;
            PNL_LEFT.Location = new System.Drawing.Point(0, 100);
            PNL_LEFT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PNL_LEFT.Name = "PNL_LEFT";
            PNL_LEFT.Size = new System.Drawing.Size(118, 607);
            PNL_LEFT.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.Color.Green;
            label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label9.Location = new System.Drawing.Point(23, 3);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(56, 20);
            label9.TabIndex = 1;
            label9.Text = "Figures";
            // 
            // listBox1
            // 
            listBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            listBox1.ForeColor = System.Drawing.SystemColors.Window;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new System.Drawing.Point(23, 37);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(73, 504);
            listBox1.TabIndex = 1;
            // 
            // PNL_BOTTOM
            // 
            PNL_BOTTOM.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            PNL_BOTTOM.Controls.Add(pos);
            PNL_BOTTOM.Controls.Add(buttonTZ);
            PNL_BOTTOM.Controls.Add(neg);
            PNL_BOTTOM.Controls.Add(buttonTY);
            PNL_BOTTOM.Controls.Add(ScaleLabel);
            PNL_BOTTOM.Controls.Add(label8);
            PNL_BOTTOM.Controls.Add(buttonTX);
            PNL_BOTTOM.Controls.Add(subtractScaleButton);
            PNL_BOTTOM.Controls.Add(addScaleButton);
            PNL_BOTTOM.Controls.Add(label7);
            PNL_BOTTOM.Controls.Add(scaleTextBox);
            PNL_BOTTOM.Controls.Add(rotateLabel);
            PNL_BOTTOM.Controls.Add(label2);
            PNL_BOTTOM.Controls.Add(label6);
            PNL_BOTTOM.Controls.Add(buttonPlayX);
            PNL_BOTTOM.Controls.Add(label5);
            PNL_BOTTOM.Controls.Add(label3);
            PNL_BOTTOM.Controls.Add(buttonPlayZ);
            PNL_BOTTOM.Controls.Add(buttonPlayY);
            PNL_BOTTOM.Controls.Add(label4);
            PNL_BOTTOM.Dock = System.Windows.Forms.DockStyle.Bottom;
            PNL_BOTTOM.Location = new System.Drawing.Point(0, 707);
            PNL_BOTTOM.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PNL_BOTTOM.Name = "PNL_BOTTOM";
            PNL_BOTTOM.Size = new System.Drawing.Size(1539, 133);
            PNL_BOTTOM.TabIndex = 1;
            // 
            // pos
            // 
            pos.BackColor = System.Drawing.Color.Red;
            pos.Location = new System.Drawing.Point(437, 85);
            pos.Name = "pos";
            pos.Size = new System.Drawing.Size(24, 29);
            pos.TabIndex = 29;
            pos.Text = "+";
            pos.UseVisualStyleBackColor = false;
            pos.Click += posTZ_Click;
            // 
            // buttonTZ
            // 
            buttonTZ.Location = new System.Drawing.Point(610, 50);
            buttonTZ.Name = "buttonTZ";
            buttonTZ.Size = new System.Drawing.Size(60, 29);
            buttonTZ.TabIndex = 32;
            buttonTZ.Text = "Play Z";
            buttonTZ.UseVisualStyleBackColor = true;
            buttonTZ.Click += buttonTZ_Click;
            // 
            // neg
            // 
            neg.Location = new System.Drawing.Point(407, 85);
            neg.Name = "neg";
            neg.Size = new System.Drawing.Size(24, 29);
            neg.TabIndex = 28;
            neg.Text = "-";
            neg.UseVisualStyleBackColor = true;
            neg.Click += button7_Click;
            // 
            // buttonTY
            // 
            buttonTY.Location = new System.Drawing.Point(520, 50);
            buttonTY.Name = "buttonTY";
            buttonTY.Size = new System.Drawing.Size(60, 29);
            buttonTY.TabIndex = 31;
            buttonTY.Text = "Play Y";
            buttonTY.UseVisualStyleBackColor = true;
            buttonTY.Click += buttonTY_Click;
            // 
            // ScaleLabel
            // 
            ScaleLabel.AutoSize = true;
            ScaleLabel.BackColor = System.Drawing.Color.Green;
            ScaleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            ScaleLabel.Location = new System.Drawing.Point(23, 17);
            ScaleLabel.Name = "ScaleLabel";
            ScaleLabel.Size = new System.Drawing.Size(44, 20);
            ScaleLabel.TabIndex = 0;
            ScaleLabel.Text = "Scale";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.Color.Green;
            label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label8.Location = new System.Drawing.Point(586, 54);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(18, 20);
            label8.TabIndex = 27;
            label8.Text = "Z";
            // 
            // buttonTX
            // 
            buttonTX.Location = new System.Drawing.Point(431, 50);
            buttonTX.Name = "buttonTX";
            buttonTX.Size = new System.Drawing.Size(60, 29);
            buttonTX.TabIndex = 30;
            buttonTX.Text = "Play X";
            buttonTX.UseVisualStyleBackColor = true;
            buttonTX.Click += buttonTX_Click;
            // 
            // subtractScaleButton
            // 
            subtractScaleButton.Location = new System.Drawing.Point(23, 40);
            subtractScaleButton.Name = "subtractScaleButton";
            subtractScaleButton.Size = new System.Drawing.Size(16, 29);
            subtractScaleButton.TabIndex = 2;
            subtractScaleButton.Text = "-";
            subtractScaleButton.UseVisualStyleBackColor = true;
            subtractScaleButton.Click += subtractScaleButton_Click;
            // 
            // addScaleButton
            // 
            addScaleButton.Location = new System.Drawing.Point(64, 40);
            addScaleButton.Name = "addScaleButton";
            addScaleButton.Size = new System.Drawing.Size(17, 29);
            addScaleButton.TabIndex = 1;
            addScaleButton.Text = "+";
            addScaleButton.UseVisualStyleBackColor = true;
            addScaleButton.Click += addScaleButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.Green;
            label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label7.Location = new System.Drawing.Point(497, 54);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(17, 20);
            label7.TabIndex = 24;
            label7.Text = "Y";
            // 
            // scaleTextBox
            // 
            scaleTextBox.Location = new System.Drawing.Point(23, 75);
            scaleTextBox.Name = "scaleTextBox";
            scaleTextBox.Size = new System.Drawing.Size(60, 27);
            scaleTextBox.TabIndex = 3;
            scaleTextBox.Text = "1";
            // 
            // rotateLabel
            // 
            rotateLabel.AutoSize = true;
            rotateLabel.BackColor = System.Drawing.Color.Green;
            rotateLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            rotateLabel.Location = new System.Drawing.Point(138, 17);
            rotateLabel.Name = "rotateLabel";
            rotateLabel.Size = new System.Drawing.Size(53, 20);
            rotateLabel.TabIndex = 4;
            rotateLabel.Text = "Rotate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Green;
            label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label2.Location = new System.Drawing.Point(114, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 20);
            label2.TabIndex = 7;
            label2.Text = "X";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.Green;
            label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label6.Location = new System.Drawing.Point(407, 54);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 20);
            label6.TabIndex = 14;
            label6.Text = "X";
            // 
            // buttonPlayX
            // 
            buttonPlayX.Location = new System.Drawing.Point(138, 50);
            buttonPlayX.Name = "buttonPlayX";
            buttonPlayX.Size = new System.Drawing.Size(60, 29);
            buttonPlayX.TabIndex = 10;
            buttonPlayX.Text = "Play X";
            buttonPlayX.UseVisualStyleBackColor = true;
            buttonPlayX.Click += buttonPlayX_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Green;
            label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label5.Location = new System.Drawing.Point(407, 17);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(60, 20);
            label5.TabIndex = 13;
            label5.Text = "Traslate";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Green;
            label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label3.Location = new System.Drawing.Point(204, 54);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(17, 20);
            label3.TabIndex = 8;
            label3.Text = "Y";
            // 
            // buttonPlayZ
            // 
            buttonPlayZ.Location = new System.Drawing.Point(317, 50);
            buttonPlayZ.Name = "buttonPlayZ";
            buttonPlayZ.Size = new System.Drawing.Size(60, 29);
            buttonPlayZ.TabIndex = 12;
            buttonPlayZ.Text = "Play Z";
            buttonPlayZ.UseVisualStyleBackColor = true;
            buttonPlayZ.Click += buttonPlayZ_Click;
            // 
            // buttonPlayY
            // 
            buttonPlayY.Location = new System.Drawing.Point(227, 50);
            buttonPlayY.Name = "buttonPlayY";
            buttonPlayY.Size = new System.Drawing.Size(60, 29);
            buttonPlayY.TabIndex = 11;
            buttonPlayY.Text = "Play Y";
            buttonPlayY.UseVisualStyleBackColor = true;
            buttonPlayY.Click += buttonPlayY_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Green;
            label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label4.Location = new System.Drawing.Point(293, 54);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(18, 20);
            label4.TabIndex = 9;
            label4.Text = "Z";
            // 
            // PNL_HEADER
            // 
            PNL_HEADER.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            PNL_HEADER.Controls.Add(buttonPlay);
            PNL_HEADER.Controls.Add(buttonKF2);
            PNL_HEADER.Controls.Add(buttonKF1);
            PNL_HEADER.Controls.Add(buttonBodies);
            PNL_HEADER.Controls.Add(buttonLines);
            PNL_HEADER.Controls.Add(button1);
            PNL_HEADER.Controls.Add(label1);
            PNL_HEADER.Dock = System.Windows.Forms.DockStyle.Top;
            PNL_HEADER.Location = new System.Drawing.Point(0, 0);
            PNL_HEADER.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PNL_HEADER.Name = "PNL_HEADER";
            PNL_HEADER.Size = new System.Drawing.Size(1539, 100);
            PNL_HEADER.TabIndex = 0;
            // 
            // buttonPlay
            // 
            buttonPlay.Location = new System.Drawing.Point(607, 28);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new System.Drawing.Size(94, 29);
            buttonPlay.TabIndex = 6;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // buttonKF2
            // 
            buttonKF2.Location = new System.Drawing.Point(507, 28);
            buttonKF2.Name = "buttonKF2";
            buttonKF2.Size = new System.Drawing.Size(94, 29);
            buttonKF2.TabIndex = 5;
            buttonKF2.Text = "KeyFrame2";
            buttonKF2.UseVisualStyleBackColor = true;
            buttonKF2.Click += buttonKF2_Click;
            // 
            // buttonKF1
            // 
            buttonKF1.Location = new System.Drawing.Point(407, 29);
            buttonKF1.Name = "buttonKF1";
            buttonKF1.Size = new System.Drawing.Size(94, 29);
            buttonKF1.TabIndex = 4;
            buttonKF1.Text = "KeyFrame1";
            buttonKF1.UseVisualStyleBackColor = true;
            buttonKF1.Click += buttonKF1_Click;
            // 
            // buttonBodies
            // 
            buttonBodies.BackColor = System.Drawing.Color.Red;
            buttonBodies.Location = new System.Drawing.Point(288, 29);
            buttonBodies.Name = "buttonBodies";
            buttonBodies.Size = new System.Drawing.Size(94, 29);
            buttonBodies.TabIndex = 3;
            buttonBodies.Text = "Bodies";
            buttonBodies.UseVisualStyleBackColor = false;
            buttonBodies.Click += buttonBodies_Click;
            // 
            // buttonLines
            // 
            buttonLines.BackColor = System.Drawing.Color.Red;
            buttonLines.Location = new System.Drawing.Point(188, 29);
            buttonLines.Name = "buttonLines";
            buttonLines.Size = new System.Drawing.Size(94, 29);
            buttonLines.TabIndex = 2;
            buttonLines.Text = "Lines";
            buttonLines.UseVisualStyleBackColor = false;
            buttonLines.Click += buttonLines_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(11, 29);
            button1.Margin = new System.Windows.Forms.Padding(2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(153, 27);
            button1.TabIndex = 1;
            button1.Text = "Cargar Objeto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddObj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(114, 36);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // TIMER
            // 
            TIMER.Tick += TIMER_Tick;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new System.Drawing.Point(12, 547);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new System.Drawing.Size(94, 29);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // MyForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1539, 840);
            Controls.Add(PNL_MAIN);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "MyForm";
            Text = "Los Foráneos";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += MyForm_Load;
            MouseMove += PCT_CANVAS_MouseMove;
            PNL_MAIN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            PNL_RIGHT.ResumeLayout(false);
            PNL_RIGHT.PerformLayout();
            PNL_LEFT.ResumeLayout(false);
            PNL_LEFT.PerformLayout();
            PNL_BOTTOM.ResumeLayout(false);
            PNL_BOTTOM.PerformLayout();
            PNL_HEADER.ResumeLayout(false);
            PNL_HEADER.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel PNL_MAIN;
        private System.Windows.Forms.Panel PNL_RIGHT;
        private System.Windows.Forms.Panel PNL_LEFT;
        private System.Windows.Forms.Panel PNL_BOTTOM;
        private System.Windows.Forms.Panel PNL_HEADER;
        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox scaleTextBox;
        private System.Windows.Forms.Button subtractScaleButton;
        private System.Windows.Forms.Button addScaleButton;
        private System.Windows.Forms.Label ScaleLabel;
        private System.Windows.Forms.Label rotateLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPlayX;
        private System.Windows.Forms.Button buttonPlayZ;
        private System.Windows.Forms.Button buttonPlayY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button pos;
        private System.Windows.Forms.Button neg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonTY;
        private System.Windows.Forms.Button buttonTX;
        private System.Windows.Forms.Button buttonTZ;
        private System.Windows.Forms.Button buttonBodies;
        private System.Windows.Forms.Button buttonLines;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonKF2;
        private System.Windows.Forms.Button buttonKF1;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.TextBox brightAndContrast;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxAlpha;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Button DeleteButton;
    }
}

