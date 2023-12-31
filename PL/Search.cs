﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ML;

namespace PL
{
    public partial class Search : Form
    {
        public string Id, Fullname;

        public Search()
        {
            InitializeComponent();
        }

        public Search(List<Person> chefs, string title)
        {
            InitializeComponent();
            Text = title;
            tbFilter.TextChanged += TextBox_TextChanged;
            dgvDatos.Columns.Clear();
            var dtPeople = new DataTable();
            dtPeople.Columns.Add("ID_PERSONA", typeof(int));
            dtPeople.Columns.Add("NOMBRES", typeof(string));
            dtPeople.Columns.Add("APELLIDO_PATERNO", typeof(string));
            dtPeople.Columns.Add("APELLIDO_MATERNO", typeof(string));
            foreach (var person in chefs)
                dtPeople.Rows.Add(person.ID_PERSONA, person.NOMBRES, person.APELLIDO_PATERNO, person.APELLIDO_MATERNO);
            dgvDatos.DataSource = dtPeople;
            foreach (DataGridViewColumn column in dgvDatos.Columns) column.Visible = false;
            dgvDatos.Columns["ID_PERSONA"].Visible = true;
            dgvDatos.Columns["ID_PERSONA"].HeaderText = "Nro";
            dgvDatos.Columns["NOMBRES"].Visible = true;
            dgvDatos.Columns["NOMBRES"].HeaderText = "Nombres";
            dgvDatos.Columns["APELLIDO_PATERNO"].Visible = true;
            dgvDatos.Columns["APELLIDO_PATERNO"].HeaderText = "Apellido paterno";
            dgvDatos.Columns["APELLIDO_MATERNO"].Visible = true;
            dgvDatos.Columns["APELLIDO_MATERNO"].HeaderText = "Apellido materno";
        }

        public Search(List<Product> products, string title)
        {
            InitializeComponent();
            Text = title;
            tbFilter.TextChanged += TextBox_TextChanged;
            dgvDatos.Columns.Clear();
            var dtProducts = new DataTable();
            dtProducts.Columns.Add("ID_PRODUCTO", typeof(int));
            dtProducts.Columns.Add("NOMBRE", typeof(string));
            foreach (var product in products) dtProducts.Rows.Add(product.ID_PRODUCTO, product.NOMBRE);
            dgvDatos.DataSource = dtProducts;
            foreach (DataGridViewColumn column in dgvDatos.Columns) column.Visible = false;
            dgvDatos.Columns["ID_PRODUCTO"].Visible = true;
            dgvDatos.Columns["ID_PRODUCTO"].HeaderText = "Nro";
            dgvDatos.Columns["NOMBRE"].Visible = true;
            dgvDatos.Columns["NOMBRE"].HeaderText = "Nombre";
        }

        public Search(List<UnitMeasure> unitMeasure, string title)
        {
            InitializeComponent();
            Text = title;
            tbFilter.TextChanged += TextBox_TextChanged;
            dgvDatos.Columns.Clear();

            var dtProducts = new DataTable();
            dtProducts.Columns.Add("ID_UNIDAD_MEDIDA", typeof(int));
            dtProducts.Columns.Add("NOMBRE", typeof(string));
            dtProducts.Columns.Add("ABREVIATURA", typeof(string));

            foreach (var um in unitMeasure) dtProducts.Rows.Add(um.ID_UNIDAD_MEDIDA, um.NOMBRE, um.ABREVIATURA);
            dgvDatos.DataSource = dtProducts;

            foreach (DataGridViewColumn column in dgvDatos.Columns) column.Visible = false;

            dgvDatos.Columns["ID_UNIDAD_MEDIDA"].Visible = true;
            dgvDatos.Columns["ID_UNIDAD_MEDIDA"].HeaderText = "Nro";
            dgvDatos.Columns["NOMBRE"].Visible = true;
            dgvDatos.Columns["NOMBRE"].HeaderText = "Nombre";
            dgvDatos.Columns["ABREVIATURA"].Visible = true;
            dgvDatos.Columns["ABREVIATURA"].HeaderText = "Abreviatura";
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            switch (Text)
            {
                case "Chefs":
                    Id = dgvDatos.CurrentRow.Cells["ID_PERSONA"].Value.ToString();
                    Fullname = dgvDatos.CurrentRow.Cells["NOMBRES"].Value + " " +
                               dgvDatos.CurrentRow.Cells["APELLIDO_PATERNO"].Value + " " +
                               dgvDatos.CurrentRow.Cells["APELLIDO_MATERNO"].Value;
                    Close();
                    break;
                case "Productos":
                    Id = dgvDatos.CurrentRow.Cells["ID_PRODUCTO"].Value.ToString();
                    Fullname = dgvDatos.CurrentRow.Cells["NOMBRE"].Value.ToString();
                    Close();
                    break;
                case "Unidades de medida":
                    Id = dgvDatos.CurrentRow.Cells["ID_UNIDAD_MEDIDA"].Value.ToString();
                    Fullname = dgvDatos.CurrentRow.Cells["ABREVIATURA"].Value.ToString();
                    Close();
                    break;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var filter = tbFilter.Text;
            switch (Text)
            {
                case "Chefs":
                    (dgvDatos.DataSource as DataTable).DefaultView.RowFilter = $"NOMBRES LIKE '%{filter}%'";
                    break;
                case "Productos":
                    (dgvDatos.DataSource as DataTable).DefaultView.RowFilter = $"NOMBRE LIKE '%{filter}%'";
                    break;
                case "Unidades de medida":
                    (dgvDatos.DataSource as DataTable).DefaultView.RowFilter = $"NOMBRE LIKE '%{filter}%'";
                    break;
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
        }
    }
}