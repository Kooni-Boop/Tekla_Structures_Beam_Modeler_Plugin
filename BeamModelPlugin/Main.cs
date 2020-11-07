using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using BeamModelPlugin;
using BeamModelPlugin.Tools;
using Tekla.Structures.Datatype;
using Tekla.Structures.Dialog;
using Tekla.Structures.Dialog.UIControls;
using Tekla.Structures.Model;
using Assembly = System.Reflection.Assembly;
using Component = System.ComponentModel.Component;
using String = System.String;

namespace BeamModelPlugin
{
    [System.Reflection.Obfuscation(Feature = "renaming", Exclude = true)]
    public partial class Main : PluginFormBase
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                SetControlDefault();

                Apply();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "SetControlDefault failed.");
            }
        }

        private void SetControlDefault()
        {
            InitializeControlValue(StructuresData.GetDefaultValueDic());
        }

        private Dictionary<string, object> _defaultValueDic = null;

        protected void InitializeControlValue(Dictionary<string, object> dic)
        {
            _defaultValueDic = dic;

            InitializeControlValue();
        }

        private void InitializeControlValue()
        {
            if (_defaultValueDic == null)
                return;

            this.SuspendLayout();
            SetChildControl(_defaultValueDic, this.Controls);
            this.ResumeLayout();
        }

        protected void SetChildControl(Dictionary<string, object> dic, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                var attName = structuresExtender.GetAttributeName(control);
                if (attName != null && dic.ContainsKey(attName))
                {
                    if (!structuresExtender.GetIsFilter(control))
                        SetValueIfDefault(control, dic[attName]);
                }

                SetChildControl(dic, control.Controls);
            }
        }

        protected void SetValueIfDefault(Control control, object defaultValue)
        {
            string typeName = structuresExtender.GetAttributeTypeName(control);
            switch (typeName.ToUpper())
            {
                case "INTEGER":
                {
                    int value = GetAttributeValue<int>(control);
                    if (value == int.MinValue)
                    {
                        SetAttributeValue(control, Convert.ToInt32(defaultValue));
                    }
                }
                    break;
                case "DISTANCELIST":
                case "STRING":
                {
                    string str = GetAttributeValue<string>(control);
                    if (string.IsNullOrEmpty(str))
                    {
                        SetAttributeValue(control, Convert.ToString(defaultValue));
                    }
                }
                    break;
                case "DISTANCE":
                case "DOUBLE":
                {
                    double value = GetAttributeValue<double>(control);
                    if (value == int.MinValue)
                    {
                        SetAttributeValue(control, Convert.ToDouble(defaultValue));
                    }
                }
                    break;
                case "BOOLEAN":
                {
                    int value = GetAttributeValue<int>(control);
                    if (value == int.MinValue)
                    {
                        SetAttributeValue(control, Convert.ToInt32(defaultValue));
                    }
                }
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        #region TeklaControls

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
            Close();
        }

        private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, EventArgs e)
        {
            ToggleSelection();
        }

        private void saveLoad1_AttributesSaveClicked(object sender, EventArgs e)
        {
            Apply();
        }

        private void saveLoad1_AttributesLoadClicked(object sender, EventArgs e)
        {
            Apply();
        }

        private void saveLoad1_AttributesSaveAsClicked(object sender, EventArgs e)
        {
            Apply();
        }

        private void profileCatalog1_Load(object sender, EventArgs e)
        {
            Apply();
        }
        #endregion

    }
}