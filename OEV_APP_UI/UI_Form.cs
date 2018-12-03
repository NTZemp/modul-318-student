using System;
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
    public partial class UI_Form : Form
    {

        APIInterface APIInterface = new APIInterface();

        public UI_Form()
        {
            InitializeComponent();
            InitializeColumns();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Gets Suggestions for the Autocompletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSuggestions(object sender, EventArgs e)
        { 
            TextBox currtextBox = (TextBox)sender;
            try
            {
                if (currtextBox.Text.Length >= 3)
                {
                    GC.Collect();
                    currtextBox.AutoCompleteCustomSource = APIInterface.GetSuggestions(currtextBox.Text);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Search for Connections between txtFrom and txtTo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime datetime =Convert.ToDateTime(dtpDepOrArr.Text);
            if (txtFrom.Text == "" || txtTo.Text == "")
            {
                MessageBox.Show("Bitte alle Von und Bis Station angeben.", "Eingabefehler");
            }
            else
            {
                ListViewItem[] items;
                try
                {
                    items = APIInterface.GetConnections(txtFrom.Text, txtTo.Text, dtpDepOrArr, dtpTimePicker);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                if(items == null)
                {
                    MessageBox.Show("Es wurden keine Verbindungen zwischen diesen Stationen gefunden.");
                    return;
                }

                lstConnections.Items.AddRange(items);
            }

        }

        private void ChangeAccpetBtn(object sender, EventArgs e)
        {
            if(tcControl.SelectedIndex == 0)
            {
                this.AcceptButton = btnSearch;
            }
            else
            {
                this.AcceptButton = btnSearchStation;
            }
        }







        private void btnSearchStation_Click(object sender, EventArgs e)
        {
            if(txtStation.Text == "")
            {
                MessageBox.Show("Bitte geben sie eine Station ein");
            }
            else
            {
                ListViewItem[] items;
                try
                {
                    items = APIInterface.GetStationBoard(txtStation.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                lstTimeTable.Items.AddRange(items);
            }
            
        }


        private void InitializeColumns()
        {
            // 
            // lstConections
            //
            lstConnections.View = View.Details;
            lstConnections.Columns.Add("Abfahrt", lstConnections.Size.Width / 4);
            lstConnections.Columns.Add("Ankunft", lstConnections.Size.Width / 4);
            lstConnections.Columns.Add("Dauer", lstConnections.Size.Width / 4);
            lstConnections.Columns.Add("Gleis/Kante", lstConnections.Size.Width / 4);
            //
            // lstTimeTable
            //
            lstTimeTable.View = View.Details;
            lstTimeTable.Columns.Add("Nach", lstTimeTable.Size.Width / 3);
            lstTimeTable.Columns.Add("Abfahrt", lstTimeTable.Size.Width / 3);
            lstTimeTable.Columns.Add("Gleis/Kante", lstTimeTable.Size.Width / 3);
        }
    }
}
