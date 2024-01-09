/**       
 * -------------------------------------------------------------------
 * 	   File name: MainMenu.Designer.cs
 * 	Project name: QueryBuilder
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/20/2022	
 *            Last Modified:    03/20/2022
 * -------------------------------------------------------------------
 */

namespace QueryBuilder
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(741, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Lab 5 - SQLite and QueryBuilder!\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Test Read (Author Class)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(51, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Test Read All (Author Class)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(51, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(244, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "Create a New Author";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(51, 269);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(244, 34);
            this.button4.TabIndex = 4;
            this.button4.Text = "Update an Existing Author";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(51, 309);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(244, 34);
            this.button5.TabIndex = 5;
            this.button5.Text = "Delete an Existing Author";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(51, 349);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(244, 34);
            this.button6.TabIndex = 6;
            this.button6.Text = "Exit the Application";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(356, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Read a Random Author from the Database!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "List all the Authors in the Database!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Create and Add a New Author to the Database!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Update an Existing Author in the Database!";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(344, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Delete an Existing Author in the Database!";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Exit the Application!";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label8.Location = new System.Drawing.Point(51, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(691, 50);
            this.label8.TabIndex = 15;
            this.label8.Text = "This lab introduces us to the SQlite Class & Package, Using and Implementing Gene" +
    "rics, \r\nand implementing CRUD (Create, Read, Update, Delete)!";
            // 
            // MainMenu
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 405);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 5 - SQLite & QueryBuilder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}