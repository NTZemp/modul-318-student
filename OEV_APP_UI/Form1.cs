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
        string Placeholder = "hh:mm";

        public UI_Form()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.lstConnections.View = View.Details;
            this.lstConnections.Columns.Add("Abfahrt", lstConnections.Size.Width / 4);
            this.lstConnections.Columns.Add("Ankunft", lstConnections.Size.Width / 4);
            this.lstConnections.Columns.Add("Dauer", lstConnections.Size.Width / 4);
            this.lstConnections.Columns.Add("Gleis/Kante", lstConnections.Size.Width / 4);

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
            if (txtFrom.Text == "" || txtTo.Text == "")
                MessageBox.Show("Bitte alle Von und Bis Station angeben.", "Eingabefehler");
            else
                lstConnections.Items.AddRange(APIInterface.GetConnections(txtFrom.Text, txtTo.Text));
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

        private void SetPlaceholder(ref TextBox textBox)
        {

        }

        private void txtTime_DragLeave(object sender, DragEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = Placeholder;
            }
            else
            {

            }
        }

        private void Format(string ToFormat)
        {
            string[] split = ToFormat.Split(':');
            if(split.Length == 2)
            {
               if()
            }
        }
    }
}
