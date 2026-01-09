namespace WinFormsApp1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        btnGo = new Button();
        labelSun = new Label();
        numSun = new NumericUpDown();
        checkBoxCool = new CheckBox();
        checkAutoFillSun = new CheckBox();
        timerAutoFillSun = new System.Windows.Forms.Timer(components);
        checkWeek = new CheckBox();
        numSilverCoins = new NumericUpDown();
        label2 = new Label();
        btnChangeSilverCoins = new Button();
        btnChangeGoldCoins = new Button();
        label3 = new Label();
        numGoldCoins = new NumericUpDown();
        btnChangeDiamond = new Button();
        label4 = new Label();
        numDiamond = new NumericUpDown();
        btnTree = new Button();
        label5 = new Label();
        numTree = new NumericUpDown();
        label6 = new Label();
        label7 = new Label();
        checkHat = new CheckBox();
        checkHandle = new CheckBox();
        checkInvincibility = new CheckBox();
        checkUnLockAllPlant = new CheckBox();
        label1 = new Label();
        comboBoxVer = new ComboBox();
        pictureBox1 = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)numSun).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numSilverCoins).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numGoldCoins).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numDiamond).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numTree).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // btnGo
        // 
        btnGo.Location = new Point(348, 97);
        btnGo.Name = "btnGo";
        btnGo.Size = new Size(132, 41);
        btnGo.TabIndex = 0;
        btnGo.Text = "修改阳光";
        btnGo.UseVisualStyleBackColor = true;
        btnGo.Click += btnGo_Click;
        // 
        // labelSun
        // 
        labelSun.Location = new Point(42, 105);
        labelSun.Name = "labelSun";
        labelSun.Size = new Size(68, 29);
        labelSun.TabIndex = 4;
        labelSun.Text = "阳光";
        // 
        // numSun
        // 
        numSun.Location = new Point(116, 103);
        numSun.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        numSun.Name = "numSun";
        numSun.Size = new Size(196, 30);
        numSun.TabIndex = 5;
        numSun.Value = new decimal(new int[] { 99999, 0, 0, 0 });
        // 
        // checkBoxCool
        // 
        checkBoxCool.Location = new Point(116, 307);
        checkBoxCool.Name = "checkBoxCool";
        checkBoxCool.Size = new Size(196, 40);
        checkBoxCool.TabIndex = 6;
        checkBoxCool.Text = "种植无冷却时间";
        checkBoxCool.UseVisualStyleBackColor = true;
        checkBoxCool.CheckedChanged += checkBoxCool_CheckedChanged;
        // 
        // checkAutoFillSun
        // 
        checkAutoFillSun.Location = new Point(501, 105);
        checkAutoFillSun.Name = "checkAutoFillSun";
        checkAutoFillSun.Size = new Size(147, 32);
        checkAutoFillSun.TabIndex = 7;
        checkAutoFillSun.Text = "自动补满";
        checkAutoFillSun.UseVisualStyleBackColor = true;
        checkAutoFillSun.Visible = false;
        checkAutoFillSun.CheckedChanged += checkAutoFillSun_CheckedChanged;
        // 
        // timerAutoFillSun
        // 
        timerAutoFillSun.Interval = 5000;
        timerAutoFillSun.Tick += timerAutoFillSun_Tick;
        // 
        // checkWeek
        // 
        checkWeek.Location = new Point(116, 429);
        checkWeek.Name = "checkWeek";
        checkWeek.Size = new Size(218, 33);
        checkWeek.TabIndex = 8;
        checkWeek.Text = "僵尸削弱(一枪就死)";
        checkWeek.UseVisualStyleBackColor = true;
        checkWeek.CheckedChanged += checkWeek_CheckedChanged;
        // 
        // numSilverCoins
        // 
        numSilverCoins.Location = new Point(116, 150);
        numSilverCoins.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numSilverCoins.Name = "numSilverCoins";
        numSilverCoins.Size = new Size(196, 30);
        numSilverCoins.TabIndex = 9;
        numSilverCoins.Value = new decimal(new int[] { 999999, 0, 0, 0 });
        // 
        // label2
        // 
        label2.Location = new Point(42, 152);
        label2.Name = "label2";
        label2.Size = new Size(68, 29);
        label2.TabIndex = 10;
        label2.Text = "银币";
        // 
        // btnChangeSilverCoins
        // 
        btnChangeSilverCoins.Location = new Point(348, 144);
        btnChangeSilverCoins.Name = "btnChangeSilverCoins";
        btnChangeSilverCoins.Size = new Size(132, 41);
        btnChangeSilverCoins.TabIndex = 11;
        btnChangeSilverCoins.Text = "修改银币";
        btnChangeSilverCoins.UseVisualStyleBackColor = true;
        btnChangeSilverCoins.Click += btnChangeSilverCoins_Click;
        // 
        // btnChangeGoldCoins
        // 
        btnChangeGoldCoins.Location = new Point(348, 191);
        btnChangeGoldCoins.Name = "btnChangeGoldCoins";
        btnChangeGoldCoins.Size = new Size(132, 41);
        btnChangeGoldCoins.TabIndex = 14;
        btnChangeGoldCoins.Text = "修改金币";
        btnChangeGoldCoins.UseVisualStyleBackColor = true;
        btnChangeGoldCoins.Click += btnChangeGoldCoins_Click;
        // 
        // label3
        // 
        label3.Location = new Point(42, 199);
        label3.Name = "label3";
        label3.Size = new Size(68, 29);
        label3.TabIndex = 13;
        label3.Text = "金币";
        // 
        // numGoldCoins
        // 
        numGoldCoins.Location = new Point(116, 197);
        numGoldCoins.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numGoldCoins.Name = "numGoldCoins";
        numGoldCoins.Size = new Size(196, 30);
        numGoldCoins.TabIndex = 12;
        numGoldCoins.Value = new decimal(new int[] { 999999, 0, 0, 0 });
        // 
        // btnChangeDiamond
        // 
        btnChangeDiamond.Location = new Point(348, 238);
        btnChangeDiamond.Name = "btnChangeDiamond";
        btnChangeDiamond.Size = new Size(132, 41);
        btnChangeDiamond.TabIndex = 17;
        btnChangeDiamond.Text = "修改钻石";
        btnChangeDiamond.UseVisualStyleBackColor = true;
        btnChangeDiamond.Click += btnChangeDiamond_Click;
        // 
        // label4
        // 
        label4.Location = new Point(42, 246);
        label4.Name = "label4";
        label4.Size = new Size(68, 29);
        label4.TabIndex = 16;
        label4.Text = "钻石";
        // 
        // numDiamond
        // 
        numDiamond.Location = new Point(116, 244);
        numDiamond.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numDiamond.Name = "numDiamond";
        numDiamond.Size = new Size(196, 30);
        numDiamond.TabIndex = 15;
        numDiamond.Value = new decimal(new int[] { 999999, 0, 0, 0 });
        // 
        // btnTree
        // 
        btnTree.Location = new Point(348, 521);
        btnTree.Name = "btnTree";
        btnTree.Size = new Size(132, 41);
        btnTree.TabIndex = 18;
        btnTree.Text = "长高";
        btnTree.UseVisualStyleBackColor = true;
        btnTree.Click += btnTree_Click;
        // 
        // label5
        // 
        label5.Location = new Point(42, 529);
        label5.Name = "label5";
        label5.Size = new Size(68, 29);
        label5.TabIndex = 20;
        label5.Text = "智慧树";
        // 
        // numTree
        // 
        numTree.Location = new Point(116, 527);
        numTree.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numTree.Name = "numTree";
        numTree.Size = new Size(196, 30);
        numTree.TabIndex = 19;
        numTree.Value = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // label6
        // 
        label6.Location = new Point(42, 314);
        label6.Name = "label6";
        label6.Size = new Size(68, 29);
        label6.TabIndex = 21;
        label6.Text = "植物";
        // 
        // label7
        // 
        label7.Location = new Point(42, 433);
        label7.Name = "label7";
        label7.Size = new Size(68, 29);
        label7.TabIndex = 22;
        label7.Text = "僵尸";
        // 
        // checkHat
        // 
        checkHat.Location = new Point(348, 425);
        checkHat.Name = "checkHat";
        checkHat.Size = new Size(218, 40);
        checkHat.TabIndex = 24;
        checkHat.Text = "帽子削弱(一枪就掉)";
        checkHat.UseVisualStyleBackColor = true;
        checkHat.CheckedChanged += checkHat_CheckedChanged;
        // 
        // checkHandle
        // 
        checkHandle.Location = new Point(116, 468);
        checkHandle.Name = "checkHandle";
        checkHandle.Size = new Size(218, 40);
        checkHandle.TabIndex = 25;
        checkHandle.Text = "手持削弱(一枪就掉)";
        checkHandle.UseVisualStyleBackColor = true;
        checkHandle.CheckedChanged += checkHandle_CheckedChanged;
        // 
        // checkInvincibility
        // 
        checkInvincibility.Location = new Point(348, 307);
        checkInvincibility.Name = "checkInvincibility";
        checkInvincibility.Size = new Size(159, 40);
        checkInvincibility.TabIndex = 26;
        checkInvincibility.Text = "植物无敌";
        checkInvincibility.UseVisualStyleBackColor = true;
        checkInvincibility.CheckedChanged += checkInvincibility_CheckedChanged;
        // 
        // checkUnLockAllPlant
        // 
        checkUnLockAllPlant.Location = new Point(116, 353);
        checkUnLockAllPlant.Name = "checkUnLockAllPlant";
        checkUnLockAllPlant.Size = new Size(177, 40);
        checkUnLockAllPlant.TabIndex = 27;
        checkUnLockAllPlant.Text = "解锁所有植物";
        checkUnLockAllPlant.UseVisualStyleBackColor = true;
        checkUnLockAllPlant.CheckedChanged += checkUnLock_CheckedChanged;
        // 
        // label1
        // 
        label1.Location = new Point(42, 38);
        label1.Name = "label1";
        label1.Size = new Size(68, 29);
        label1.TabIndex = 28;
        label1.Text = "版本";
        // 
        // comboBoxVer
        // 
        comboBoxVer.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxVer.FormattingEnabled = true;
        comboBoxVer.Items.AddRange(new object[] { "v3.9.9" });
        comboBoxVer.Location = new Point(113, 35);
        comboBoxVer.Name = "comboBoxVer";
        comboBoxVer.Size = new Size(199, 32);
        comboBoxVer.TabIndex = 29;
        comboBoxVer.SelectedIndexChanged += comboBoxVer_SelectedIndexChanged;
        // 
        // pictureBox1
        // 
        pictureBox1.Cursor = Cursors.Hand;
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(570, 521);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(50, 50);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 23;
        pictureBox1.TabStop = false;
        pictureBox1.Click += pictureBox1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(644, 591);
        Controls.Add(comboBoxVer);
        Controls.Add(label1);
        Controls.Add(checkUnLockAllPlant);
        Controls.Add(checkInvincibility);
        Controls.Add(checkHandle);
        Controls.Add(checkHat);
        Controls.Add(pictureBox1);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(numTree);
        Controls.Add(btnTree);
        Controls.Add(btnChangeDiamond);
        Controls.Add(label4);
        Controls.Add(numDiamond);
        Controls.Add(btnChangeGoldCoins);
        Controls.Add(label3);
        Controls.Add(numGoldCoins);
        Controls.Add(btnChangeSilverCoins);
        Controls.Add(label2);
        Controls.Add(numSilverCoins);
        Controls.Add(checkWeek);
        Controls.Add(checkAutoFillSun);
        Controls.Add(checkBoxCool);
        Controls.Add(numSun);
        Controls.Add(labelSun);
        Controls.Add(btnGo);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "游戏修改器";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)numSun).EndInit();
        ((System.ComponentModel.ISupportInitialize)numSilverCoins).EndInit();
        ((System.ComponentModel.ISupportInitialize)numGoldCoins).EndInit();
        ((System.ComponentModel.ISupportInitialize)numDiamond).EndInit();
        ((System.ComponentModel.ISupportInitialize)numTree).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.ComboBox comboBoxVer;

    private System.Windows.Forms.CheckBox checkUnLockAllPlant;

    private System.Windows.Forms.CheckBox checkInvincibility;

    private System.Windows.Forms.CheckBox checkHandle;

    private System.Windows.Forms.CheckBox checkHat;

    private System.Windows.Forms.Button btnTree;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown numTree;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Button btnChangeDiamond;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown numDiamond;

    private System.Windows.Forms.Button btnChangeGoldCoins;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown numGoldCoins;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnChangeSilverCoins;

    private System.Windows.Forms.NumericUpDown numSilverCoins;

    private System.Windows.Forms.CheckBox checkWeek;

    private System.Windows.Forms.Timer timerAutoFillSun;

    private System.Windows.Forms.CheckBox checkAutoFillSun;

    private System.Windows.Forms.CheckBox checkBoxCool;


    private System.Windows.Forms.NumericUpDown numSun;
    
    private System.Windows.Forms.Label labelSun;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button btnGo;

    #endregion
}