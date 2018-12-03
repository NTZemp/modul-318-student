﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport;
using System.Windows.Forms;

namespace OEV_APP_UI
{
    public partial class Form1 : Form
    {

        APIInterface APIInterface = new APIInterface();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            txtFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFrom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            lstTimeTable.View = View.Details;
            lstTimeTable.Columns.Add("Abfahrt", lstTimeTable.Size.Width / 4);
            lstTimeTable.Columns.Add("Ankunft", lstTimeTable.Size.Width / 4);
            lstTimeTable.Columns.Add("Dauer", lstTimeTable.Size.Width / 4);
            lstTimeTable.Columns.Add("Abfahrts Gleis", lstTimeTable.Size.Width / 4);
            GC.Collect();
        }

        private void GetSuggestions(object sender, EventArgs e)
        {
            TextBox currtextBox = (TextBox)sender;
            if (currtextBox.Text.Length >= 4)
            {
                GC.Collect();
                currtextBox.AutoCompleteCustomSource = APIInterface.GetSuggestions(currtextBox.Text);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            lstTimeTable.Items.AddRange(APIInterface.GetConnections(txtFrom.Text, txtTo.Text);)
        }


    }
}
