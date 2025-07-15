namespace WinApp
{
    partial class Form1
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
            btnqueue = new Button();
            lblseed = new Label();
            label2 = new Label();
            txtseed = new TextBox();
            txttotalrow = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnqueue
            // 
            btnqueue.Location = new Point(26, 97);
            btnqueue.Name = "btnqueue";
            btnqueue.Size = new Size(138, 42);
            btnqueue.TabIndex = 0;
            btnqueue.Text = "Load Queue";
            btnqueue.UseVisualStyleBackColor = true;
            btnqueue.Click += btnqueue_Click;
            // 
            // lblseed
            // 
            lblseed.AutoSize = true;
            lblseed.Location = new Point(26, 9);
            lblseed.Name = "lblseed";
            lblseed.Size = new Size(32, 15);
            lblseed.TabIndex = 1;
            lblseed.Text = "Seed";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 47);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Total Row";
            // 
            // txtseed
            // 
            txtseed.Location = new Point(113, 9);
            txtseed.Name = "txtseed";
            txtseed.Size = new Size(222, 23);
            txtseed.TabIndex = 3;
            txtseed.Text = "f847b251-4577-415b-aeaf-34c83fb7c7cc";
            // 
            // txttotalrow
            // 
            txttotalrow.Location = new Point(113, 44);
            txttotalrow.Name = "txttotalrow";
            txttotalrow.ReadOnly = true;
            txttotalrow.Size = new Size(121, 23);
            txttotalrow.TabIndex = 4;
            txttotalrow.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(341, 9);
            button1.Name = "button1";
            button1.Size = new Size(144, 28);
            button1.TabIndex = 5;
            button1.Text = "Load Urls";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(491, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(297, 429);
            dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 52);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 7;
            label1.Text = "Total";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(341, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(106, 23);
            textBox1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(409, 80);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 9;
            label3.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(txttotalrow);
            Controls.Add(txtseed);
            Controls.Add(label2);
            Controls.Add(lblseed);
            Controls.Add(btnqueue);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button btnqueue;
        private Label lblseed;
        private Label label2;
        private TextBox txtseed;
        private TextBox txttotalrow;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        public Label label3;
    }
}
