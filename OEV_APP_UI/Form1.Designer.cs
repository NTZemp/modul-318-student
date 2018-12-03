namespace OEV_APP_UI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tcControl = new System.Windows.Forms.TabControl();
            this.tpConnections = new System.Windows.Forms.TabPage();
            this.lstTimeTable = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.tpTimeTable = new System.Windows.Forms.TabPage();
            this.tcControl.SuspendLayout();
            this.tpConnections.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcControl
            // 
            this.tcControl.Controls.Add(this.tpConnections);
            this.tcControl.Controls.Add(this.tpTimeTable);
            this.tcControl.Location = new System.Drawing.Point(12, 12);
            this.tcControl.Name = "tcControl";
            this.tcControl.SelectedIndex = 0;
            this.tcControl.Size = new System.Drawing.Size(890, 585);
            this.tcControl.TabIndex = 8;
            // 
            // tpConnections
            // 
            this.tpConnections.Controls.Add(this.lstTimeTable);
            this.tpConnections.Controls.Add(this.btnSearch);
            this.tpConnections.Controls.Add(this.txtFrom);
            this.tpConnections.Controls.Add(this.txtTo);
            this.tpConnections.Controls.Add(this.lblFrom);
            this.tpConnections.Controls.Add(this.lblTo);
            this.tpConnections.Location = new System.Drawing.Point(4, 25);
            this.tpConnections.Name = "tpConnections";
            this.tpConnections.Padding = new System.Windows.Forms.Padding(3);
            this.tpConnections.Size = new System.Drawing.Size(882, 556);
            this.tpConnections.TabIndex = 0;
            this.tpConnections.Text = "Verbindungen";
            this.tpConnections.UseVisualStyleBackColor = true;
            // 
            // lstTimeTable
            // 
            this.lstTimeTable.Location = new System.Drawing.Point(6, 63);
            this.lstTimeTable.Name = "lstTimeTable";
            this.lstTimeTable.Size = new System.Drawing.Size(867, 486);
            this.lstTimeTable.TabIndex = 14;
            this.lstTimeTable.UseCompatibleStateImageBehavior = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(659, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(136, 40);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(6, 36);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(225, 22);
            this.txtFrom.TabIndex = 9;
            this.txtFrom.TabStop = false;
            this.txtFrom.TextChanged += new System.EventHandler(this.GetSuggestions);
            // 
            // txtTo
            // 
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
            this.tpTimeTable.Location = new System.Drawing.Point(4, 25);
            this.tpTimeTable.Name = "tpTimeTable";
            this.tpTimeTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpTimeTable.Size = new System.Drawing.Size(882, 556);
            this.tpTimeTable.TabIndex = 1;
            this.tpTimeTable.Text = "Abfahrtstafel";
            this.tpTimeTable.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 609);
            this.Controls.Add(this.tcControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ÖV Fahrplan Preview";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcControl.ResumeLayout(false);
            this.tpConnections.ResumeLayout(false);
            this.tpConnections.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcControl;
        private System.Windows.Forms.TabPage tpConnections;
        private System.Windows.Forms.ListView lstTimeTable;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TabPage tpTimeTable;
    }
}

