using System.ComponentModel;

namespace PL
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bCourses = new System.Windows.Forms.Button();
            this.bGroups = new System.Windows.Forms.Button();
            this.bChefs = new System.Windows.Forms.Button();
            this.bTeachers = new System.Windows.Forms.Button();
            this.bStudents = new System.Windows.Forms.Button();
            this.bRecipes = new System.Windows.Forms.Button();
            this.pVentana = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.lName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bCourses);
            this.panel1.Controls.Add(this.bGroups);
            this.panel1.Controls.Add(this.bChefs);
            this.panel1.Controls.Add(this.bTeachers);
            this.panel1.Controls.Add(this.bStudents);
            this.panel1.Controls.Add(this.bRecipes);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 561);
            this.panel1.TabIndex = 0;
            // 
            // lName
            // 
            this.lName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(0, 23);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(200, 30);
            this.lName.TabIndex = 7;
            this.lName.Text = "nombre";
            this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bienvenido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bCourses
            // 
            this.bCourses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.bCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCourses.Location = new System.Drawing.Point(0, 280);
            this.bCourses.Name = "bCourses";
            this.bCourses.Size = new System.Drawing.Size(200, 50);
            this.bCourses.TabIndex = 5;
            this.bCourses.Text = "CURSOS";
            this.bCourses.UseVisualStyleBackColor = true;
            // 
            // bGroups
            // 
            this.bGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.bGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGroups.Location = new System.Drawing.Point(0, 330);
            this.bGroups.Name = "bGroups";
            this.bGroups.Size = new System.Drawing.Size(200, 50);
            this.bGroups.TabIndex = 4;
            this.bGroups.Text = "GRUPOS";
            this.bGroups.UseVisualStyleBackColor = true;
            // 
            // bChefs
            // 
            this.bChefs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.bChefs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChefs.Location = new System.Drawing.Point(0, 130);
            this.bChefs.Name = "bChefs";
            this.bChefs.Size = new System.Drawing.Size(200, 50);
            this.bChefs.TabIndex = 3;
            this.bChefs.Text = "CHEFS";
            this.bChefs.UseVisualStyleBackColor = true;
            // 
            // bTeachers
            // 
            this.bTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.bTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTeachers.Location = new System.Drawing.Point(0, 180);
            this.bTeachers.Name = "bTeachers";
            this.bTeachers.Size = new System.Drawing.Size(200, 50);
            this.bTeachers.TabIndex = 2;
            this.bTeachers.Text = "PROFESORES";
            this.bTeachers.UseVisualStyleBackColor = true;
            // 
            // bStudents
            // 
            this.bStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.bStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStudents.Location = new System.Drawing.Point(0, 230);
            this.bStudents.Name = "bStudents";
            this.bStudents.Size = new System.Drawing.Size(200, 50);
            this.bStudents.TabIndex = 1;
            this.bStudents.Text = "ALUMNOS";
            this.bStudents.UseVisualStyleBackColor = true;
            // 
            // bRecipes
            // 
            this.bRecipes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.bRecipes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRecipes.Location = new System.Drawing.Point(0, 80);
            this.bRecipes.Name = "bRecipes";
            this.bRecipes.Size = new System.Drawing.Size(200, 50);
            this.bRecipes.TabIndex = 0;
            this.bRecipes.Text = "RECETAS";
            this.bRecipes.UseVisualStyleBackColor = true;
            this.bRecipes.Click += new System.EventHandler(this.bRecipes_Click);
            // 
            // pVentana
            // 
            this.pVentana.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pVentana.Location = new System.Drawing.Point(200, 0);
            this.pVentana.Name = "pVentana";
            this.pVentana.Size = new System.Drawing.Size(784, 561);
            this.pVentana.TabIndex = 1;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pVentana);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lName;

        private System.Windows.Forms.Button bRecipes;
        private System.Windows.Forms.Button bStudents;
        private System.Windows.Forms.Button bTeachers;
        private System.Windows.Forms.Button bChefs;
        private System.Windows.Forms.Button bGroups;
        private System.Windows.Forms.Button bCourses;

        private System.Windows.Forms.Panel pVentana;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}