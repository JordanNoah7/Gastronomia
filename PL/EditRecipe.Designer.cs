using System.ComponentModel;

namespace PL
{
    partial class EditRecipe
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
            this.label1 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRecipeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bAddIngredient = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbIdAutor = new System.Windows.Forms.TextBox();
            this.tbAutor = new System.Windows.Forms.TextBox();
            this.bSearchAutor = new System.Windows.Forms.Button();
            this.pSteps = new System.Windows.Forms.Panel();
            this.dgvSteps = new System.Windows.Forms.DataGridView();
            this.bAddStep = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPortions = new System.Windows.Forms.TextBox();
            this.tbCookingTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPreparationTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.tbIdRecipe = new System.Windows.Forms.TextBox();
            this.bDeleteStep = new System.Windows.Forms.Button();
            this.bDeleteIngredient = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.pSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "EDITAR RECETA";
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Location = new System.Drawing.Point(621, 10);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 7;
            this.bSave.Text = "Guardar";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de receta";
            // 
            // tbRecipeName
            // 
            this.tbRecipeName.Location = new System.Drawing.Point(135, 42);
            this.tbRecipeName.Name = "tbRecipeName";
            this.tbRecipeName.Size = new System.Drawing.Size(185, 20);
            this.tbRecipeName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingredientes";
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(702, 10);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "Cancelar";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bAddIngredient
            // 
            this.bAddIngredient.Location = new System.Drawing.Point(122, 214);
            this.bAddIngredient.Name = "bAddIngredient";
            this.bAddIngredient.Size = new System.Drawing.Size(30, 23);
            this.bAddIngredient.TabIndex = 12;
            this.bAddIngredient.Text = "+";
            this.bAddIngredient.UseVisualStyleBackColor = true;
            this.bAddIngredient.Click += new System.EventHandler(this.bAddIngredient_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dgvIngredients);
            this.panel1.Location = new System.Drawing.Point(0, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 300);
            this.panel1.TabIndex = 13;
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AllowUserToAddRows = false;
            this.dgvIngredients.AllowUserToDeleteRows = false;
            this.dgvIngredients.AllowUserToResizeColumns = false;
            this.dgvIngredients.AllowUserToResizeRows = false;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredients.Location = new System.Drawing.Point(0, 0);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.Size = new System.Drawing.Size(392, 300);
            this.dgvIngredients.TabIndex = 0;
            this.dgvIngredients.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvIngredients_DataError);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(398, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Preparacion";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Autor";
            // 
            // tbIdAutor
            // 
            this.tbIdAutor.Location = new System.Drawing.Point(135, 64);
            this.tbIdAutor.Name = "tbIdAutor";
            this.tbIdAutor.Size = new System.Drawing.Size(32, 20);
            this.tbIdAutor.TabIndex = 16;
            // 
            // tbAutor
            // 
            this.tbAutor.Location = new System.Drawing.Point(173, 64);
            this.tbAutor.Name = "tbAutor";
            this.tbAutor.Size = new System.Drawing.Size(147, 20);
            this.tbAutor.TabIndex = 17;
            // 
            // bSearchAutor
            // 
            this.bSearchAutor.Location = new System.Drawing.Point(326, 64);
            this.bSearchAutor.Name = "bSearchAutor";
            this.bSearchAutor.Size = new System.Drawing.Size(30, 23);
            this.bSearchAutor.TabIndex = 18;
            this.bSearchAutor.Text = "...";
            this.bSearchAutor.UseVisualStyleBackColor = true;
            this.bSearchAutor.Click += new System.EventHandler(this.bSearchAutor_Click);
            // 
            // pSteps
            // 
            this.pSteps.AutoScroll = true;
            this.pSteps.Controls.Add(this.dgvSteps);
            this.pSteps.Location = new System.Drawing.Point(392, 239);
            this.pSteps.Name = "pSteps";
            this.pSteps.Size = new System.Drawing.Size(392, 300);
            this.pSteps.TabIndex = 14;
            // 
            // dgvSteps
            // 
            this.dgvSteps.AllowUserToAddRows = false;
            this.dgvSteps.AllowUserToDeleteRows = false;
            this.dgvSteps.AllowUserToResizeColumns = false;
            this.dgvSteps.AllowUserToResizeRows = false;
            this.dgvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSteps.Location = new System.Drawing.Point(0, 0);
            this.dgvSteps.Name = "dgvSteps";
            this.dgvSteps.Size = new System.Drawing.Size(392, 300);
            this.dgvSteps.TabIndex = 2;
            // 
            // bAddStep
            // 
            this.bAddStep.Location = new System.Drawing.Point(485, 214);
            this.bAddStep.Name = "bAddStep";
            this.bAddStep.Size = new System.Drawing.Size(30, 23);
            this.bAddStep.TabIndex = 19;
            this.bAddStep.Text = "+";
            this.bAddStep.UseVisualStyleBackColor = true;
            this.bAddStep.Click += new System.EventHandler(this.bAddStep_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Porciones";
            // 
            // tbPortions
            // 
            this.tbPortions.Location = new System.Drawing.Point(135, 86);
            this.tbPortions.Name = "tbPortions";
            this.tbPortions.Size = new System.Drawing.Size(185, 20);
            this.tbPortions.TabIndex = 21;
            // 
            // tbCookingTime
            // 
            this.tbCookingTime.Location = new System.Drawing.Point(135, 108);
            this.tbCookingTime.Name = "tbCookingTime";
            this.tbCookingTime.Size = new System.Drawing.Size(185, 20);
            this.tbCookingTime.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(12, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Tiempo de cocción";
            // 
            // tbPreparationTime
            // 
            this.tbPreparationTime.Location = new System.Drawing.Point(549, 108);
            this.tbPreparationTime.Name = "tbPreparationTime";
            this.tbPreparationTime.Size = new System.Drawing.Size(185, 20);
            this.tbPreparationTime.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(388, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tiempo de preparación";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(388, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "Dificultad";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(388, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Categoría";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(549, 64);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(185, 21);
            this.cbCategory.TabIndex = 29;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(15, 152);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(719, 60);
            this.tbDescription.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(12, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "Descripción";
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Location = new System.Drawing.Point(549, 86);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(185, 21);
            this.cbDifficulty.TabIndex = 32;
            // 
            // tbIdRecipe
            // 
            this.tbIdRecipe.Location = new System.Drawing.Point(173, 10);
            this.tbIdRecipe.Name = "tbIdRecipe";
            this.tbIdRecipe.Size = new System.Drawing.Size(32, 20);
            this.tbIdRecipe.TabIndex = 33;
            this.tbIdRecipe.Visible = false;
            // 
            // bDeleteStep
            // 
            this.bDeleteStep.Location = new System.Drawing.Point(521, 214);
            this.bDeleteStep.Name = "bDeleteStep";
            this.bDeleteStep.Size = new System.Drawing.Size(30, 23);
            this.bDeleteStep.TabIndex = 36;
            this.bDeleteStep.Text = "-";
            this.bDeleteStep.UseVisualStyleBackColor = true;
            this.bDeleteStep.Click += new System.EventHandler(this.bDeleteStep_Click);
            // 
            // bDeleteIngredient
            // 
            this.bDeleteIngredient.Location = new System.Drawing.Point(158, 214);
            this.bDeleteIngredient.Name = "bDeleteIngredient";
            this.bDeleteIngredient.Size = new System.Drawing.Size(30, 23);
            this.bDeleteIngredient.TabIndex = 35;
            this.bDeleteIngredient.Text = "-";
            this.bDeleteIngredient.UseVisualStyleBackColor = true;
            this.bDeleteIngredient.Click += new System.EventHandler(this.bDeleteIngredient_Click);
            // 
            // EditRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.bDeleteStep);
            this.Controls.Add(this.bDeleteIngredient);
            this.Controls.Add(this.tbIdRecipe);
            this.Controls.Add(this.cbDifficulty);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbPreparationTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbCookingTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPortions);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bAddStep);
            this.Controls.Add(this.pSteps);
            this.Controls.Add(this.bSearchAutor);
            this.Controls.Add(this.tbAutor);
            this.Controls.Add(this.tbIdAutor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bAddIngredient);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbRecipeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.label1);
            this.Name = "EditRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddRecipe";
            this.Load += new System.EventHandler(this.EditRecipe_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.pSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox tbCookingTime;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPortions;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbIdAutor;
        private System.Windows.Forms.TextBox tbAutor;
        private System.Windows.Forms.Button bSearchAutor;
        private System.Windows.Forms.Panel pSteps;
        private System.Windows.Forms.Button bAddStep;
        private System.Windows.Forms.Button bAddIngredient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bCancel;

        private System.Windows.Forms.TextBox tbRecipeName;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button bSave;

        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.TextBox tbPreparationTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.TextBox tbIdRecipe;
        private System.Windows.Forms.Button bDeleteStep;
        private System.Windows.Forms.Button bDeleteIngredient;
        private System.Windows.Forms.DataGridView dgvSteps;
    }
}