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
            txtseed.Size = new Size(310, 23);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txttotalrow);
            Controls.Add(txtseed);
            Controls.Add(label2);
            Controls.Add(lblseed);
            Controls.Add(btnqueue);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button btnqueue;
        private Label lblseed;
        private Label label2;
        private TextBox txtseed;
        private TextBox txttotalrow;
    }
}
