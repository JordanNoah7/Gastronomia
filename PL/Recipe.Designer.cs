using System.ComponentModel;

namespace PL
{
    partial class Recipe
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
            this.dgvRecipes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bAddRecipe = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecipes
            // 
            this.dgvRecipes.AllowUserToAddRows = false;
            this.dgvRecipes.AllowUserToDeleteRows = false;
            this.dgvRecipes.AllowUserToResizeColumns = false;
            this.dgvRecipes.AllowUserToResizeRows = false;
            this.dgvRecipes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipes.Location = new System.Drawing.Point(12, 57);
            this.dgvRecipes.Name = "dgvRecipes";
            this.dgvRecipes.ReadOnly = true;
            this.dgvRecipes.Size = new System.Drawing.Size(760, 492);
            this.dgvRecipes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "RECETAS";
            // 
            // bAddRecipe
            // 
            this.bAddRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddRecipe.Location = new System.Drawing.Point(697, 6);
            this.bAddRecipe.Name = "bAddRecipe";
            this.bAddRecipe.Size = new System.Drawing.Size(75, 23);
            this.bAddRecipe.TabIndex = 2;
            this.bAddRecipe.Text = "Agregar";
            this.bAddRecipe.UseVisualStyleBackColor = true;
            this.bAddRecipe.Click += new System.EventHandler(this.bAddRecipe_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFilter.Location = new System.Drawing.Point(288, 12);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(183, 20);
            this.tbFilter.TabIndex = 3;
            // 
            // Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.bAddRecipe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRecipes);
            this.Name = "Recipe";
            this.Text = "Recipe";
            this.Load += new System.EventHandler(this.Recipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button bAddRecipe;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DataGridView dgvRecipes;

        #endregion

        private System.Windows.Forms.TextBox tbFilter;
    }
}