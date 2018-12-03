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
        Formats formats = new Formats();
        string Placeholder = "hh:mm";

        public UI_Form()
        {
            InitializeComponent();
            InitializeColumns();
        }

        private void InitializeColumns()
        {
            lstConnections.View = View.Details;
            lstConnections.Columns.Add("Abfahrt", lstConnections.Size.Width / 4);
            lstConnections.Columns.Add("Ankunft", lstConnections.Size.Width / 4);
            lstConnections.Columns.Add("Dauer", lstConnections.Size.Width / 4);
            lstConnections.Columns.Add("Gleis/Kante", lstConnections.Size.Width / 4);
            lstTimeTable.View = View.Details;
            lstTimeTable.Columns.Add("Nach", lstTimeTable.Size.Width /3);
            lstTimeTable.Columns.Add("Abfahrt", lstTimeTable.Size.Width / 3);
            lstTimeTable.Columns.Add("Gleis/Kante", lstTimeTable.Size.Width / 3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
            GC.Collect();
        }

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFrom.Text == "" || txtTo.Text == "")
            {
                MessageBox.Show("Bitte alle Von und Bis Station angeben.", "Eingabefehler");
            }
            else
            {
                try
                {
                    lstConnections.Items.AddRange(APIInterface.GetConnections(txtFrom.Text, txtTo.Text));
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

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



        private void txtTime_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = Placeholder;
            }
            else
            {
                txtTime.Text = Format(textBox.Text);
            }
        }

        private string Format(string ToFormat)
        {
            string[] split = ToFormat.Split(':');
            if(split.Length == 2)
            {
                throw new NotImplementedException();
            }
            else 
            {
                string formatted = formats.FormatTime(ToFormat);
                if (formatted == "x")
                {
                    MessageBox.Show("Bitte gebes Sie die Zeit in richtigem Format an!", "Eingabefehler");
                    return Placeholder;
                }
                else
                {
                    return formatted;
                }
            }


        }

        private void txtTime_Enter(object sender, EventArgs e)
        {
            if(txtTime.Text == Placeholder)
            {
                txtTime.Text = "";
            }
        }
    }
}
