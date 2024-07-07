namespace AdoTask
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
            execbutton = new Button();
            fillbutton = new Button();
            dataGridView1 = new DataGridView();
            id = new TextBox();
            name = new TextBox();
            sname = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // execbutton
            // 
            execbutton.Location = new Point(594, 24);
            execbutton.Name = "execbutton";
            execbutton.Size = new Size(94, 29);
            execbutton.TabIndex = 0;
            execbutton.Text = "Exec";
            execbutton.UseVisualStyleBackColor = true;
            execbutton.Click += execbutton_Click;
            // 
            // fillbutton
            // 
            fillbutton.Location = new Point(704, 24);
            fillbutton.Name = "fillbutton";
            fillbutton.Size = new Size(94, 29);
            fillbutton.TabIndex = 1;
            fillbutton.Text = "Fill";
            fillbutton.UseVisualStyleBackColor = true;
            fillbutton.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 70);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 368);
            dataGridView1.TabIndex = 3;
            // 
            // id
            // 
            id.Location = new Point(12, 26);
            id.Name = "id";
            id.PlaceholderText = "Id";
            id.Size = new Size(125, 27);
            id.TabIndex = 5;
            // 
            // name
            // 
            name.Location = new Point(185, 26);
            name.Name = "name";
            name.PlaceholderText = "Name";
            name.Size = new Size(125, 27);
            name.TabIndex = 6;
            // 
            // sname
            // 
            sname.Location = new Point(343, 25);
            sname.Name = "sname";
            sname.PlaceholderText = "SurName";
            sname.Size = new Size(125, 27);
            sname.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sname);
            Controls.Add(name);
            Controls.Add(id);
            Controls.Add(dataGridView1);
            Controls.Add(fillbutton);
            Controls.Add(execbutton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button execbutton;
        private Button fillbutton;
        private DataGridView dataGridView1;
        private TextBox id;
        private TextBox name;
        private TextBox sname;
    }
}
