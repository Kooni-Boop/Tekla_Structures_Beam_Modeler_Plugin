namespace BeamModelPlugin
{
    partial class Main
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
            this.saveLoad1 = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.okApplyModifyGetOnOffCancel1 = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LeftHeightCB = new System.Windows.Forms.CheckBox();
            this.LeftHeight = new System.Windows.Forms.TextBox();
            this.HeightCB = new System.Windows.Forms.CheckBox();
            this.CentHeight = new System.Windows.Forms.TextBox();
            this.BotWedgeCutCB = new System.Windows.Forms.CheckBox();
            this.BotWedgeCut = new System.Windows.Forms.TextBox();
            this.RightHeightCB = new System.Windows.Forms.CheckBox();
            this.RightHeight = new System.Windows.Forms.TextBox();
            this.TopWedgeCutCB = new System.Windows.Forms.CheckBox();
            this.TopWedgeCut = new System.Windows.Forms.TextBox();
            this.TopRightCutCB = new System.Windows.Forms.CheckBox();
            this.TopRightCut = new System.Windows.Forms.TextBox();
            this.TopWidthCB = new System.Windows.Forms.CheckBox();
            this.TopWidth = new System.Windows.Forms.TextBox();
            this.TopLeftCutCB = new System.Windows.Forms.CheckBox();
            this.TopLeftCut = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveLoad1
            // 
            this.structuresExtender.SetAttributeName(this.saveLoad1, null);
            this.structuresExtender.SetAttributeTypeName(this.saveLoad1, null);
            this.saveLoad1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.saveLoad1, null);
            this.saveLoad1.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveLoad1.HelpFileType = Tekla.Structures.Dialog.UIControls.SaveLoad.HelpFileTypeEnum.General;
            this.saveLoad1.HelpKeyword = "";
            this.saveLoad1.HelpUrl = "";
            this.saveLoad1.Location = new System.Drawing.Point(0, 0);
            this.saveLoad1.Name = "saveLoad1";
            this.saveLoad1.SaveAsText = "";
            this.saveLoad1.Size = new System.Drawing.Size(799, 40);
            this.saveLoad1.TabIndex = 0;
            this.saveLoad1.UserDefinedHelpFilePath = null;
            this.saveLoad1.AttributesLoadClicked += new System.EventHandler(this.saveLoad1_AttributesLoadClicked);
            this.saveLoad1.AttributesSaveClicked += new System.EventHandler(this.saveLoad1_AttributesSaveClicked);
            this.saveLoad1.AttributesSaveAsClicked += new System.EventHandler(this.saveLoad1_AttributesSaveAsClicked);
            // 
            // okApplyModifyGetOnOffCancel1
            // 
            this.structuresExtender.SetAttributeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetAttributeTypeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetBindPropertyName(this.okApplyModifyGetOnOffCancel1, null);
            this.okApplyModifyGetOnOffCancel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okApplyModifyGetOnOffCancel1.Location = new System.Drawing.Point(0, 419);
            this.okApplyModifyGetOnOffCancel1.Name = "okApplyModifyGetOnOffCancel1";
            this.okApplyModifyGetOnOffCancel1.Size = new System.Drawing.Size(799, 31);
            this.okApplyModifyGetOnOffCancel1.TabIndex = 1;
            this.okApplyModifyGetOnOffCancel1.OkClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_OkClicked);
            this.okApplyModifyGetOnOffCancel1.ApplyClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_ApplyClicked);
            this.okApplyModifyGetOnOffCancel1.ModifyClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_ModifyClicked);
            this.okApplyModifyGetOnOffCancel1.GetClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_GetClicked);
            this.okApplyModifyGetOnOffCancel1.OnOffClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_OnOffClicked);
            this.okApplyModifyGetOnOffCancel1.CancelClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_CancelClicked);
            // 
            // tabControl1
            // 
            this.structuresExtender.SetAttributeName(this.tabControl1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl1, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl1, null);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 376);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.structuresExtender.SetAttributeName(this.tabPage1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage1, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage1, null);
            this.tabPage1.Controls.Add(this.LeftHeightCB);
            this.tabPage1.Controls.Add(this.LeftHeight);
            this.tabPage1.Controls.Add(this.HeightCB);
            this.tabPage1.Controls.Add(this.CentHeight);
            this.tabPage1.Controls.Add(this.BotWedgeCutCB);
            this.tabPage1.Controls.Add(this.BotWedgeCut);
            this.tabPage1.Controls.Add(this.RightHeightCB);
            this.tabPage1.Controls.Add(this.RightHeight);
            this.tabPage1.Controls.Add(this.TopWedgeCutCB);
            this.tabPage1.Controls.Add(this.TopWedgeCut);
            this.tabPage1.Controls.Add(this.TopRightCutCB);
            this.tabPage1.Controls.Add(this.TopRightCut);
            this.tabPage1.Controls.Add(this.TopWidthCB);
            this.tabPage1.Controls.Add(this.TopWidth);
            this.tabPage1.Controls.Add(this.TopLeftCutCB);
            this.tabPage1.Controls.Add(this.TopLeftCut);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "빔";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LeftHeightCB
            // 
            this.structuresExtender.SetAttributeName(this.LeftHeightCB, "LeftHeight");
            this.structuresExtender.SetAttributeTypeName(this.LeftHeightCB, null);
            this.LeftHeightCB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LeftHeightCB, null);
            this.structuresExtender.SetIsFilter(this.LeftHeightCB, true);
            this.LeftHeightCB.Location = new System.Drawing.Point(256, 229);
            this.LeftHeightCB.Name = "LeftHeightCB";
            this.LeftHeightCB.Size = new System.Drawing.Size(15, 14);
            this.LeftHeightCB.TabIndex = 16;
            this.LeftHeightCB.UseVisualStyleBackColor = true;
            // 
            // LeftHeight
            // 
            this.structuresExtender.SetAttributeName(this.LeftHeight, "LeftHeight");
            this.structuresExtender.SetAttributeTypeName(this.LeftHeight, "Double");
            this.structuresExtender.SetBindPropertyName(this.LeftHeight, null);
            this.LeftHeight.Location = new System.Drawing.Point(209, 225);
            this.LeftHeight.Name = "LeftHeight";
            this.LeftHeight.Size = new System.Drawing.Size(41, 21);
            this.LeftHeight.TabIndex = 15;
            this.LeftHeight.Text = "0";
            // 
            // HeightCB
            // 
            this.structuresExtender.SetAttributeName(this.HeightCB, "CentHeight");
            this.structuresExtender.SetAttributeTypeName(this.HeightCB, null);
            this.HeightCB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.HeightCB, null);
            this.structuresExtender.SetIsFilter(this.HeightCB, true);
            this.HeightCB.Location = new System.Drawing.Point(397, 208);
            this.HeightCB.Name = "HeightCB";
            this.HeightCB.Size = new System.Drawing.Size(15, 14);
            this.HeightCB.TabIndex = 14;
            this.HeightCB.UseVisualStyleBackColor = true;
            // 
            // CentHeight
            // 
            this.structuresExtender.SetAttributeName(this.CentHeight, "CentHeight");
            this.structuresExtender.SetAttributeTypeName(this.CentHeight, "Double");
            this.structuresExtender.SetBindPropertyName(this.CentHeight, null);
            this.CentHeight.Location = new System.Drawing.Point(350, 204);
            this.CentHeight.Name = "CentHeight";
            this.CentHeight.Size = new System.Drawing.Size(41, 21);
            this.CentHeight.TabIndex = 13;
            this.CentHeight.Text = "0";
            // 
            // BotWedgeCutCB
            // 
            this.structuresExtender.SetAttributeName(this.BotWedgeCutCB, "BotWedgeCut");
            this.structuresExtender.SetAttributeTypeName(this.BotWedgeCutCB, null);
            this.BotWedgeCutCB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BotWedgeCutCB, null);
            this.structuresExtender.SetIsFilter(this.BotWedgeCutCB, true);
            this.BotWedgeCutCB.Location = new System.Drawing.Point(565, 310);
            this.BotWedgeCutCB.Name = "BotWedgeCutCB";
            this.BotWedgeCutCB.Size = new System.Drawing.Size(15, 14);
            this.BotWedgeCutCB.TabIndex = 12;
            this.BotWedgeCutCB.UseVisualStyleBackColor = true;
            // 
            // BotWedgeCut
            // 
            this.structuresExtender.SetAttributeName(this.BotWedgeCut, "BotWedgeCut");
            this.structuresExtender.SetAttributeTypeName(this.BotWedgeCut, "Double");
            this.structuresExtender.SetBindPropertyName(this.BotWedgeCut, null);
            this.BotWedgeCut.Location = new System.Drawing.Point(518, 306);
            this.BotWedgeCut.Name = "BotWedgeCut";
            this.BotWedgeCut.Size = new System.Drawing.Size(41, 21);
            this.BotWedgeCut.TabIndex = 11;
            this.BotWedgeCut.Text = "0";
            // 
            // RightHeightCB
            // 
            this.structuresExtender.SetAttributeName(this.RightHeightCB, "RightHeight");
            this.structuresExtender.SetAttributeTypeName(this.RightHeightCB, null);
            this.RightHeightCB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RightHeightCB, null);
            this.structuresExtender.SetIsFilter(this.RightHeightCB, true);
            this.RightHeightCB.Location = new System.Drawing.Point(544, 230);
            this.RightHeightCB.Name = "RightHeightCB";
            this.RightHeightCB.Size = new System.Drawing.Size(15, 14);
            this.RightHeightCB.TabIndex = 10;
            this.RightHeightCB.UseVisualStyleBackColor = true;
            // 
            // RightHeight
            // 
            this.structuresExtender.SetAttributeName(this.RightHeight, "RightHeight");
            this.structuresExtender.SetAttributeTypeName(this.RightHeight, "Double");
            this.structuresExtender.SetBindPropertyName(this.RightHeight, null);
            this.RightHeight.Location = new System.Drawing.Point(497, 226);
            this.RightHeight.Name = "RightHeight";
            this.RightHeight.Size = new System.Drawing.Size(41, 21);
            this.RightHeight.TabIndex = 9;
            this.RightHeight.Text = "0";
            // 
            // TopWedgeCutCB
            // 
            this.structuresExtender.SetAttributeName(this.TopWedgeCutCB, "TopWedgeCut");
            this.structuresExtender.SetAttributeTypeName(this.TopWedgeCutCB, null);
            this.TopWedgeCutCB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.TopWedgeCutCB, null);
            this.structuresExtender.SetIsFilter(this.TopWedgeCutCB, true);
            this.TopWedgeCutCB.Location = new System.Drawing.Point(544, 101);
            this.TopWedgeCutCB.Name = "TopWedgeCutCB";
            this.TopWedgeCutCB.Size = new System.Drawing.Size(15, 14);
            this.TopWedgeCutCB.TabIndex = 8;
            this.TopWedgeCutCB.UseVisualStyleBackColor = true;
            // 
            // TopWedgeCut
            // 
            this.structuresExtender.SetAttributeName(this.TopWedgeCut, "TopWedgeCut");
            this.structuresExtender.SetAttributeTypeName(this.TopWedgeCut, "Double");
            this.structuresExtender.SetBindPropertyName(this.TopWedgeCut, null);
            this.TopWedgeCut.Location = new System.Drawing.Point(497, 97);
            this.TopWedgeCut.Name = "TopWedgeCut";
            this.TopWedgeCut.Size = new System.Drawing.Size(41, 21);
            this.TopWedgeCut.TabIndex = 7;
            this.TopWedgeCut.Text = "0";
            // 
            // TopRightCutCB
            // 
            this.structuresExtender.SetAttributeName(this.TopRightCutCB, "TopRightCut");
            this.structuresExtender.SetAttributeTypeName(this.TopRightCutCB, null);
            this.TopRightCutCB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.TopRightCutCB, null);
            this.structuresExtender.SetIsFilter(this.TopRightCutCB, true);
            this.TopRightCutCB.Location = new System.Drawing.Point(473, 27);
            this.TopRightCutCB.Name = "TopRightCutCB";
            this.TopRightCutCB.Size = new System.Drawing.Size(15, 14);
            this.TopRightCutCB.TabIndex = 6;
            this.TopRightCutCB.UseVisualStyleBackColor = true;
            // 
            // TopRightCut
            // 
            this.structuresExtender.SetAttributeName(this.TopRightCut, "TopRightCut");
            this.structuresExtender.SetAttributeTypeName(this.TopRightCut, "Double");
            this.structuresExtender.SetBindPropertyName(this.TopRightCut, null);
            this.TopRightCut.Location = new System.Drawing.Point(426, 23);
            this.TopRightCut.Name = "TopRightCut";
            this.TopRightCut.Size = new System.Drawing.Size(41, 21);
            this.TopRightCut.TabIndex = 5;
            this.TopRightCut.Text = "0";
            // 
            // TopWidthCB
            // 
            this.structuresExtender.SetAttributeName(this.TopWidthCB, "TopWidth");
            this.structuresExtender.SetAttributeTypeName(this.TopWidthCB, null);
            this.TopWidthCB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.TopWidthCB, null);
            this.structuresExtender.SetIsFilter(this.TopWidthCB, true);
            this.TopWidthCB.Location = new System.Drawing.Point(397, 27);
            this.TopWidthCB.Name = "TopWidthCB";
            this.TopWidthCB.Size = new System.Drawing.Size(15, 14);
            this.TopWidthCB.TabIndex = 4;
            this.TopWidthCB.UseVisualStyleBackColor = true;
            // 
            // TopWidth
            // 
            this.structuresExtender.SetAttributeName(this.TopWidth, "TopWidth");
            this.structuresExtender.SetAttributeTypeName(this.TopWidth, "Double");
            this.structuresExtender.SetBindPropertyName(this.TopWidth, null);
            this.TopWidth.Location = new System.Drawing.Point(350, 23);
            this.TopWidth.Name = "TopWidth";
            this.TopWidth.Size = new System.Drawing.Size(41, 21);
            this.TopWidth.TabIndex = 3;
            this.TopWidth.Text = "0";
            // 
            // TopLeftCutCB
            // 
            this.structuresExtender.SetAttributeName(this.TopLeftCutCB, "TopLeftCut");
            this.structuresExtender.SetAttributeTypeName(this.TopLeftCutCB, null);
            this.TopLeftCutCB.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.TopLeftCutCB, null);
            this.structuresExtender.SetIsFilter(this.TopLeftCutCB, true);
            this.TopLeftCutCB.Location = new System.Drawing.Point(317, 27);
            this.TopLeftCutCB.Name = "TopLeftCutCB";
            this.TopLeftCutCB.Size = new System.Drawing.Size(15, 14);
            this.TopLeftCutCB.TabIndex = 2;
            this.TopLeftCutCB.UseVisualStyleBackColor = true;
            // 
            // TopLeftCut
            // 
            this.structuresExtender.SetAttributeName(this.TopLeftCut, "TopLeftCut");
            this.structuresExtender.SetAttributeTypeName(this.TopLeftCut, "Double");
            this.structuresExtender.SetBindPropertyName(this.TopLeftCut, null);
            this.TopLeftCut.Location = new System.Drawing.Point(270, 23);
            this.TopLeftCut.Name = "TopLeftCut";
            this.TopLeftCut.Size = new System.Drawing.Size(41, 21);
            this.TopLeftCut.TabIndex = 1;
            this.TopLeftCut.Text = "0";
            // 
            // pictureBox1
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox1, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox1, null);
            this.pictureBox1.Image = global::BeamModelPlugin.Properties.Resources.beam1;
            this.pictureBox1.Location = new System.Drawing.Point(209, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(534, 275);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.structuresExtender.SetAttributeName(this.tabPage2, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage2, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage2, null);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "-";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.structuresExtender.SetAttributeName(this.tabPage3, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage3, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage3, null);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 350);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "-";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.okApplyModifyGetOnOffCancel1);
            this.Controls.Add(this.saveLoad1);
            this.Name = "Main";
            this.Text = "부재 생성 옵션";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad1;
        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel okApplyModifyGetOnOffCancel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox LeftHeightCB;
        private System.Windows.Forms.TextBox LeftHeight;
        private System.Windows.Forms.CheckBox HeightCB;
        private System.Windows.Forms.TextBox CentHeight;
        private System.Windows.Forms.CheckBox BotWedgeCutCB;
        private System.Windows.Forms.TextBox BotWedgeCut;
        private System.Windows.Forms.CheckBox RightHeightCB;
        private System.Windows.Forms.TextBox RightHeight;
        private System.Windows.Forms.CheckBox TopWedgeCutCB;
        private System.Windows.Forms.TextBox TopWedgeCut;
        private System.Windows.Forms.CheckBox TopRightCutCB;
        private System.Windows.Forms.TextBox TopRightCut;
        private System.Windows.Forms.CheckBox TopWidthCB;
        private System.Windows.Forms.TextBox TopWidth;
        private System.Windows.Forms.CheckBox TopLeftCutCB;
        private System.Windows.Forms.TextBox TopLeftCut;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}