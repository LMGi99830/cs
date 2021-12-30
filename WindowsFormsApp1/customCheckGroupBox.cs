using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class customCheckGroupBox : UserControl
    {
        public customCheckGroupBox()
        {
            InitializeComponent();
        }
    }

    public class CheckedGroupBox : System.Windows.Forms.GroupBox
    {
        #region Private Member Variables
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Checkbox to enable / disable the controls within the group
        /// </summary>
        private CheckBox chkBox;

        /// <summary>
        /// Label for the group box which is set to autosize
        /// </summary>
        private Label lblDisplay;
        #endregion

        /// <summary>
        ///  Default constructor for the control
        /// </summary>
        public CheckedGroupBox()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // The text of these controls should always be empty.
            this.Text = "";
            this.chkBox.Text = "";
        }

        public CheckedGroupBox(String text)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // The text of these controls should always be empty.
            this.Text = text;
            this.chkBox.Text = "";
        }
        #region Events & Delegates

        /// <summary>
        /// Event to forward the change in checked flag
        /// </summary>
        public event EventHandler CheckedChanged;

        /// <summary>
        /// Event to forward the change in checked state of the checkbox
        /// </summary>
        public event EventHandler CheckStateChanged;

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Disable the controls within the group
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name != "chkBox" && ctrl.Name != "lblDisplay")
                {
                    ctrl.Enabled = this.chkBox.Checked;
                }
            }

            // Now forward the Event from the checkbox
            if (this.CheckedChanged != null)
            {
                this.CheckedChanged(sender, e);
            }
        }

        private void chkBox_CheckStateChanged(object sender, EventArgs e)
        {
            // Forward the Event from the checkbox
            if (this.CheckStateChanged != null)
            {
                this.CheckStateChanged(sender, e);
            }
        }

        #endregion

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkBox = new System.Windows.Forms.CheckBox();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkBox
            // 
            this.chkBox.Location = new System.Drawing.Point(8, 0);
            this.chkBox.Name = "chkBox";
            this.chkBox.Size = new System.Drawing.Size(16, 16);
            this.chkBox.TabIndex = 0;
            this.chkBox.CheckStateChanged += new System.EventHandler(this.chkBox_CheckStateChanged);
            this.chkBox.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Location = new System.Drawing.Point(24, 0);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(97, 13);
            this.lblDisplay.TabIndex = 1;
            this.lblDisplay.Text = "CheckedGroupBox";
            // 
            // CheckedGroupBox
            //
            this.Controls.Add(this.chkBox);
            this.Controls.Add(this.lblDisplay);
            this.Size = new System.Drawing.Size(100, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

           


        }
        #endregion

        #region Public properties

        [Bindable(true), Category("Appearance"), DefaultValue("Check Group Text")]
        public override string Text
        {
            get { return this.lblDisplay.Text; }
            set { this.lblDisplay.Text = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("Checked")]
        public System.Windows.Forms.CheckState CheckState
        {
            get { return this.chkBox.CheckState; }
            set
            {
                this.chkBox.CheckState = value;

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl.Name != "chkBox" && ctrl.Name != "lblDisplay")
                    {
                        ctrl.Enabled = this.chkBox.Checked;
                    }
                }
            }
        }

        [Bindable(true), Category("Appearance"), DefaultValue("True")]
        public bool Checked
        {
            get { return this.chkBox.Checked; }
            set
            {
                this.chkBox.Checked = value;

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl.Name != "chkBox" && ctrl.Name != "lblDisplay")
                    {
                        ctrl.Enabled = this.chkBox.Checked;
                    }
                }
            }
        }

        [Bindable(true), Category("Behavior"), DefaultValue("False")]
        public bool ThreeState
        {
            get { return this.chkBox.ThreeState; }
            set { this.chkBox.ThreeState = value; }
        }

        #endregion

    }
}
