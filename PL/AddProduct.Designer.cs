using System.ComponentModel;

namespace PL
{
    partial class AddProduct
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
            this.bSearchProducto = new System.Windows.Forms.Button();
            this.tbProduct = new System.Windows.Forms.TextBox();
            this.tbIdProduct = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bSearchMeasure = new System.Windows.Forms.Button();
            this.tbIdMeasure = new System.Windows.Forms.TextBox();
            this.tbMeasure = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bAccept = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "AÑADIR PRODUCTO";
            // 
            // bSearchProducto
            // 
            this.bSearchProducto.Location = new System.Drawing.Point(230, 40);
            this.bSearchProducto.Name = "bSearchProducto";
            this.bSearchProducto.Size = new System.Drawing.Size(30, 23);
            this.bSearchProducto.TabIndex = 22;
            this.bSearchProducto.Text = "...";
            this.bSearchProducto.UseVisualStyleBackColor = true;
            this.bSearchProducto.Click += new System.EventHandler(this.bSearchProducto_Click);
            // 
            // tbProduct
            // 
            this.tbProduct.Location = new System.Drawing.Point(80, 40);
            this.tbProduct.Name = "tbProduct";
            this.tbProduct.Size = new System.Drawing.Size(147, 20);
            this.tbProduct.TabIndex = 21;
            // 
            // tbIdProduct
            // 
            this.tbIdProduct.Location = new System.Drawing.Point(260, 40);
            this.tbIdProduct.Name = "tbIdProduct";
            this.tbIdProduct.Size = new System.Drawing.Size(32, 20);
            this.tbIdProduct.TabIndex = 20;
            this.tbIdProduct.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Producto";
            // 
            // bSearchMeasure
            // 
            this.bSearchMeasure.Location = new System.Drawing.Point(230, 76);
            this.bSearchMeasure.Name = "bSearchMeasure";
            this.bSearchMeasure.Size = new System.Drawing.Size(30, 23);
            this.bSearchMeasure.TabIndex = 26;
            this.bSearchMeasure.Text = "...";
            this.bSearchMeasure.UseVisualStyleBackColor = true;
            this.bSearchMeasure.Click += new System.EventHandler(this.bSearchMeasure_Click);
            // 
            // tbIdMeasure
            // 
            this.tbIdMeasure.Location = new System.Drawing.Point(260, 76);
            this.tbIdMeasure.Name = "tbIdMeasure";
            this.tbIdMeasure.Size = new System.Drawing.Size(32, 20);
            this.tbIdMeasure.TabIndex = 24;
            this.tbIdMeasure.Visible = false;
            // 
            // tbMeasure
            // 
            this.tbMeasure.Location = new System.Drawing.Point(80, 76);
            this.tbMeasure.Name = "tbMeasure";
            this.tbMeasure.Size = new System.Drawing.Size(147, 20);
            this.tbMeasure.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Medida";
            // 
            // bAccept
            // 
            this.bAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAccept.Location = new System.Drawing.Point(49, 133);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(75, 23);
            this.bAccept.TabIndex = 29;
            this.bAccept.Text = "Aceptar";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(186, 133);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 30;
            this.bCancel.Text = "Cancelar";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 191);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.tbMeasure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bSearchMeasure);
            this.Controls.Add(this.tbIdMeasure);
            this.Controls.Add(this.bSearchProducto);
            this.Controls.Add(this.tbProduct);
            this.Controls.Add(this.tbIdProduct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddProduct";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSearchProducto;
        private System.Windows.Forms.TextBox tbProduct;
        private System.Windows.Forms.TextBox tbIdProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bSearchMeasure;
        private System.Windows.Forms.TextBox tbIdMeasure;
        private System.Windows.Forms.TextBox tbMeasure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Button bCancel;
    }
}