using System;
using SwissTransport;
using System.Windows.Forms;

namespace OEV_APP_UI
{
    public partial class UI_Form : Form
    {

        APIInterface APIInterface = new APIInterface();
        AutoCompleteStringCollection SuggestionSource = new AutoCompleteStringCollection();

        public UI_Form()
        {
            InitializeComponent();
            InitializeColumns();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpDepOrArr.Text = DateTime.Now.ToLongDateString();
            dtpTimePicker.Text = DateTime.Now.ToShortTimeString();
            txtFrom.AutoCompleteCustomSource = SuggestionSource;
            txtFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
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
                    SuggestionSource = APIInterface.GetSuggestions(currtextBox.Text);

                    currtextBox.AutoCompleteCustomSource = SuggestionSource;
                    currtextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    //currtextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }

            }catch(StationNotFoundException)
            {
                SuggestionSource.Clear();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// Search for Connections between txtFrom and txtTo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstConnections.Items.Clear();
            DateTime time = Convert.ToDateTime(dtpTimePicker.Text);
            DateTime date =Convert.ToDateTime(dtpDepOrArr.Text);
            DateTime dateTime = date.Date.Add(time.TimeOfDay);
            
            if (txtFrom.Text == "" || txtTo.Text == "")
            {
                MessageBox.Show("Bitte alle Von und Bis Station angeben.", "Eingabefehler");
            }
            else
            {
                ListViewItem[] items = { new ListViewItem("0") }; 
                try
                {
                    items = APIInterface.GetConnections(txtFrom.Text, txtTo.Text, dateTime);
                }
                catch (NoConnectionException ncex)
                {
                    MessageBox.Show(ncex.Message, "Error");
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    txtStation.Text = "";
                    return;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                lstConnections.Items.AddRange(items);
            }

        }

        private void btnSearchStation_Click(object sender, EventArgs e)
        {
            if (txtStation.Text == "")
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                lstTimeTable.Items.AddRange(items);
            }

        }


        /// <summary>
        /// Changes Accept button when the TabPage Changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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




        /// <summary>
        /// init Columns of ListViews
        /// </summary>
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

        private void GetStationLocation(object sender, EventArgs e)
        {
            try
            {
                string location = APIInterface.GetStationLocation(txtStation.Text);
                System.Diagnostics.Process.Start("https://google.com/maps/place/" + location);
            }catch(StationNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
