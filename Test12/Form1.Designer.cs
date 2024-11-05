
namespace Test12
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
            this.btnGraph = new System.Windows.Forms.Button();
            this.redtInput = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTextfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(846, 269);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 0;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.button1_Click);
            // 
            // redtInput
            // 
            this.redtInput.Location = new System.Drawing.Point(811, 12);
            this.redtInput.Name = "redtInput";
            this.redtInput.Size = new System.Drawing.Size(147, 251);
            this.redtInput.TabIndex = 1;
            this.redtInput.Text = "max +4 +5\n+2 +1 <= 5\n+1 +2 >= 6\n+3 +0 <= 12\n+ +";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(846, 298);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTextfile
            // 
            this.btnTextfile.Location = new System.Drawing.Point(846, 327);
            this.btnTextfile.Name = "btnTextfile";
            this.btnTextfile.Size = new System.Drawing.Size(75, 23);
            this.btnTextfile.TabIndex = 3;
            this.btnTextfile.Text = "Textfile";
            this.btnTextfile.UseVisualStyleBackColor = true;
            this.btnTextfile.Click += new System.EventHandler(this.btnTextfile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 861);
            this.Controls.Add(this.btnTextfile);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.redtInput);
            this.Controls.Add(this.btnGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.RichTextBox redtInput;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTextfile;
    }
}

