namespace WinFormsApp_OOP_2
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
            listBox = new ListBox();
            button1 = new Button();
            button2 = new Button();
            propertyGrid1 = new PropertyGrid();
            listBox1 = new ListBox();
            button3 = new Button();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            button6 = new Button();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.Location = new Point(21, 12);
            listBox.Name = "listBox";
            listBox.RightToLeft = RightToLeft.No;
            listBox.Size = new Size(119, 144);
            listBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(2, 162);
            button1.Name = "button1";
            button1.Size = new Size(150, 29);
            button1.TabIndex = 3;
            button1.Text = "jsonSerialization";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(2, 197);
            button2.Name = "button2";
            button2.Size = new Size(150, 29);
            button2.TabIndex = 4;
            button2.Text = "jsonDeserialization";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // propertyGrid1
            // 
            propertyGrid1.AccessibleName = "";
            propertyGrid1.Location = new Point(158, -2);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(292, 310);
            propertyGrid1.TabIndex = 5;
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            propertyGrid1.SelectedObjectsChanged += propertyGrid1_SelectedObjectsChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(114, 370);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(317, 304);
            listBox1.TabIndex = 6;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.KeyDown += listBox1_KeyDown;
            // 
            // button3
            // 
            button3.Location = new Point(2, 232);
            button3.Name = "button3";
            button3.Size = new Size(150, 29);
            button3.TabIndex = 7;
            button3.Text = "xmlSerialization";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(2, 267);
            button4.Name = "button4";
            button4.Size = new Size(150, 29);
            button4.TabIndex = 8;
            button4.Text = "xmlDeserialization";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Location = new Point(456, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(804, 689);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // button6
            // 
            button6.Location = new Point(2, 302);
            button6.Name = "button6";
            button6.Size = new Size(150, 29);
            button6.TabIndex = 10;
            button6.Text = "clear";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(2, 337);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(150, 29);
            buttonAdd.TabIndex = 11;
            buttonAdd.Text = "add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 686);
            Controls.Add(buttonAdd);
            Controls.Add(button6);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(listBox1);
            Controls.Add(propertyGrid1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Click += Form1_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox;
        private Button button1;
        private Button button2;
        private PropertyGrid propertyGrid1;
        private ListBox listBox1;
        private Button button3;
        private Button button4;
        private PictureBox pictureBox1;
        private Button button6;
        private Button buttonAdd;
    }
}
