using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Dialog;

namespace BeamModelPlugin
{
    public partial class Main : PluginFormBase
    {
        public Form()
        {
            InitializeComponent();
            InitValue();
        }
        private void InitValue()
        {
            string chk = "Default";
            TextBox textBox = new TextBox();

            if (!Enum.IsDefined(typeof(LoadOption), chk))
            {
                ModifyValues("Default");
                SetAttributeValue("ConnStatus", "999999");
                SaveValues("Default");
            }
            else
            {
                throw new Exception();
            }

        }
        private void okApplyModifyGetOnOffCancel1_ApplyClicked(object sender, EventArgs e)
        {
            Apply();
        }

        private void okApplyModifyGetOnOffCancel1_CancelClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void okApplyModifyGetOnOffCancel1_GetClicked(object sender, EventArgs e)
        {
            Get();
        }

        private void okApplyModifyGetOnOffCancel1_ModifyClicked(object sender, EventArgs e)
        {
            Modify();
        }

        private void okApplyModifyGetOnOffCancel1_OkClicked(object sender, EventArgs e)
        {
            Apply();
        }

        private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, EventArgs e)
        {
            //todo
        }

        private void saveLoad1_AttributesSaveClicked(object sender, EventArgs e)
        {
            Apply();
        }

        private void saveLoad1_AttributesLoadClicked(object sender, EventArgs e)
        {
            Apply();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitValue();
        }
    }
}