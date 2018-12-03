using System.Windows.Forms;

namespace OEV_APP_UI
{
    partial class UI_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Form));
            this.tcControl = new System.Windows.Forms.TabControl();
            this.tpConnections = new System.Windows.Forms.TabPage();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.dtpDepOrArr = new System.Windows.Forms.DateTimePicker();
            this.lstConnections = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.tpTimeTable = new System.Windows.Forms.TabPage();
            this.lstTimeTable = new System.Windows.Forms.ListView();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.btnSearchStation = new System.Windows.Forms.Button();
            this.lblStation = new System.Windows.Forms.Label();
            this.tcControl.SuspendLayout();
            this.tpConnections.SuspendLayout();
            this.tpTimeTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcControl
            // 
            this.tcControl.Controls.Add(this.tpConnections);
            this.tcControl.Controls.Add(this.tpTimeTable);
            this.tcControl.Location = new System.Drawing.Point(12, 12);
            this.tcControl.Name = "tcControl";
            this.tcControl.SelectedIndex = 0;
            this.tcControl.Size = new System.Drawing.Size(890, 609);
            this.tcControl.TabIndex = 8;
            this.tcControl.SelectedIndexChanged += new System.EventHandler(this.ChangeAccpetBtn);
            // 
            // tpConnections
            // 
            this.tpConnections.Controls.Add(this.txtTime);
            this.tpConnections.Controls.Add(this.dtpDepOrArr);
            this.tpConnections.Controls.Add(this.lstConnections);
            this.tpConnections.Controls.Add(this.btnSearch);
            this.tpConnections.Controls.Add(this.txtFrom);
            this.tpConnections.Controls.Add(this.txtTo);
            this.tpConnections.Controls.Add(this.lblFrom);
            this.tpConnections.Controls.Add(this.lblTo);
            this.tpConnections.Location = new System.Drawing.Point(4, 25);
            this.tpConnections.Name = "tpConnections";
            this.tpConnections.Padding = new System.Windows.Forms.Padding(3);
            this.tpConnections.Size = new System.Drawing.Size(882, 580);
            this.tpConnections.TabIndex = 0;
            this.tpConnections.Text = "Verbindungen";
            this.tpConnections.UseVisualStyleBackColor = true;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(111, 91);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(64, 22);
            this.txtTime.TabIndex = 15;
            this.txtTime.Text = "hh:mm";
            this.txtTime.Enter += new System.EventHandler(this.txtTime_Enter);
            this.txtTime.Leave += new System.EventHandler(this.txtTime_Leave);
            // 
            // dtpDepOrArr
            // 
            this.dtpDepOrArr.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpDepOrArr.CustomFormat = "MM/dd/yyyy";
            this.dtpDepOrArr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepOrArr.Location = new System.Drawing.Point(9, 91);
            this.dtpDepOrArr.Name = "dtpDepOrArr";
            this.dtpDepOrArr.Size = new System.Drawing.Size(96, 22);
            this.dtpDepOrArr.TabIndex = 9;
            // 
            // lstConnections
            // 
            this.lstConnections.Location = new System.Drawing.Point(6, 119);
            this.lstConnections.Name = "lstConnections";
            this.lstConnections.Size = new System.Drawing.Size(867, 455);
            this.lstConnections.TabIndex = 14;
            this.lstConnections.UseCompatibleStateImageBehavior = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(747, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 52);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFrom.Location = new System.Drawing.Point(6, 36);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(225, 22);
            this.txtFrom.TabIndex = 9;
            this.txtFrom.TabStop = false;
            this.txtFrom.TextChanged += new System.EventHandler(this.GetSuggestions);
            // 
            // txtTo
            // 
            this.txtTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTo.Location = new System.Drawing.Point(387, 36);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(225, 22);
            this.txtTo.TabIndex = 12;
            this.txtTo.TextChanged += new System.EventHandler(this.GetSuggestions);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(6, 16);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 17);
            this.lblFrom.TabIndex = 10;
            this.lblFrom.Text = "Von";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Enabled = false;
            this.lblTo.Location = new System.Drawing.Point(384, 16);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(36, 20);
            this.lblTo.TabIndex = 11;
            this.lblTo.Text = "Nach";
            this.lblTo.UseCompatibleTextRendering = true;
            // 
            // tpTimeTable
            // 
            this.tpTimeTable.Controls.Add(this.lstTimeTable);
            this.tpTimeTable.Controls.Add(this.txtStation);
            this.tpTimeTable.Controls.Add(this.btnSearchStation);
            this.tpTimeTable.Controls.Add(this.lblStation);
            this.tpTimeTable.Location = new System.Drawing.Point(4, 25);
            this.tpTimeTable.Name = "tpTimeTable";
            this.tpTimeTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpTimeTable.Size = new System.Drawing.Size(882, 580);
            this.tpTimeTable.TabIndex = 1;
            this.tpTimeTable.Text = "Abfahrtstafel";
            this.tpTimeTable.UseVisualStyleBackColor = true;
            // 
            // lstTimeTable
            // 
            this.lstTimeTable.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lstTimeTable.Location = new System.Drawing.Point(6, 119);
            this.lstTimeTable.Name = "lstTimeTable";
            this.lstTimeTable.Size = new System.Drawing.Size(867, 455);
            this.lstTimeTable.TabIndex = 11;
            this.lstTimeTable.UseCompatibleStateImageBehavior = false;
            // 
            // txtStation
            // 
            this.txtStation.Location = new System.Drawing.Point(6, 36);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(301, 22);
            this.txtStation.TabIndex = 10;
            this.txtStation.TextChanged += new System.EventHandler(this.GetSuggestions);
            // 
            // btnSearchStation
            // 
            this.btnSearchStation.Location = new System.Drawing.Point(747, 6);
            this.btnSearchStation.Name = "btnSearchStation";
            this.btnSearchStation.Size = new System.Drawing.Size(129, 52);
            this.btnSearchStation.TabIndex = 1;
            this.btnSearchStation.Text = "Suchen";
            this.btnSearchStation.UseVisualStyleBackColor = true;
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(3, 16);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(52, 17);
            this.lblStation.TabIndex = 0;
            this.lblStation.Text = "Station";
            this.lblStation.UseWaitCursor = true;
            // 
            // UI_Form
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 633);
            this.Controls.Add(this.tcControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_Form";
            this.Text = "ÖV Fahrplan Preview";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcControl.ResumeLayout(false);
            this.tpConnections.ResumeLayout(false);
            this.tpConnections.PerformLayout();
            this.tpTimeTable.ResumeLayout(false);
            this.tpTimeTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcControl;
        private System.Windows.Forms.TabPage tpConnections;
        private System.Windows.Forms.ListView lstConnections;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TabPage tpTimeTable;
        private TextBox txtStation;
        private Button btnSearchStation;
        private Label lblStation;
        private ListView lstTimeTable;
        private DateTimePicker dtpDepOrArr;
        private TextBox txtTime;
    }
}

