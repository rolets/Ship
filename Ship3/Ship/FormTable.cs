﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ship
{
    public partial class FormTable : Form
    {
        public FormTable(DataTable data)
        {
            InitializeComponent();
            dataGridView1.DataSource = data;
        }
    }
}
