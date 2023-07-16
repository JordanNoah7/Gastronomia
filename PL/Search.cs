﻿using System;
using System.Collections.Generic;
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
            dgvDatos.DataSource = chefs;
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

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            Id = dgvDatos.CurrentRow.Cells["ID_PERSONA"].Value.ToString();
            Fullname = dgvDatos.CurrentRow.Cells["NOMBRES"].Value + " " +
                       dgvDatos.CurrentRow.Cells["APELLIDO_PATERNO"].Value + " " +
                       dgvDatos.CurrentRow.Cells["APELLIDO_MATERNO"].Value;
            Close();
        }
    }
}