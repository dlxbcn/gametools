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
        btnGo = new System.Windows.Forms.Button();
        txtTitle = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        labelSun = new System.Windows.Forms.Label();
        numSun = new System.Windows.Forms.NumericUpDown();
        checkBoxCool = new System.Windows.Forms.CheckBox();
        checkAutoFillSun = new System.Windows.Forms.CheckBox();
        timerAutoFillSun = new System.Windows.Forms.Timer(components);
        checkWeek = new System.Windows.Forms.CheckBox();
        numSilverCoins = new System.Windows.Forms.NumericUpDown();
        label2 = new System.Windows.Forms.Label();
        btnChangeSilverCoins = new System.Windows.Forms.Button();
        btnChangeGoldCoins = new System.Windows.Forms.Button();
        label3 = new System.Windows.Forms.Label();
        numGoldCoins = new System.Windows.Forms.NumericUpDown();
        btnChangeDiamond = new System.Windows.Forms.Button();
        label4 = new System.Windows.Forms.Label();
        numDiamond = new System.Windows.Forms.NumericUpDown();
        btnTree = new System.Windows.Forms.Button();
        label5 = new System.Windows.Forms.Label();
        numTree = new System.Windows.Forms.NumericUpDown();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        checkHat = new System.Windows.Forms.CheckBox();
        checkHandle = new System.Windows.Forms.CheckBox();
        checkInvincibility = new System.Windows.Forms.CheckBox();
        checkUnLockAllPlant = new System.Windows.Forms.CheckBox();
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
        btnGo.Location = new System.Drawing.Point(348, 97);
        btnGo.Name = "btnGo";
        btnGo.Size = new System.Drawing.Size(132, 41);
        btnGo.TabIndex = 0;
        btnGo.Text = "修改阳光";
        btnGo.UseVisualStyleBackColor = true;
        btnGo.Click += btnGo_Click;
        // 
        // txtTitle
        // 
        txtTitle.Location = new System.Drawing.Point(168, 41);
        txtTitle.Name = "txtTitle";
        txtTitle.ReadOnly = true;
        txtTitle.Size = new System.Drawing.Size(441, 30);
        txtTitle.TabIndex = 1;
        txtTitle.Text = "植物大战僵尸杂交版";
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(42, 41);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(120, 30);
        label1.TabIndex = 2;
        label1.Text = "游戏窗口标题";
        // 
        // labelSun
        // 
        labelSun.Location = new System.Drawing.Point(42, 105);
        labelSun.Name = "labelSun";
        labelSun.Size = new System.Drawing.Size(68, 29);
        labelSun.TabIndex = 4;
        labelSun.Text = "阳光";
        // 
        // numSun
        // 
        numSun.Location = new System.Drawing.Point(116, 103);
        numSun.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        numSun.Name = "numSun";
        numSun.Size = new System.Drawing.Size(196, 30);
        numSun.TabIndex = 5;
        numSun.Value = new decimal(new int[] { 99999, 0, 0, 0 });
        // 
        // checkBoxCool
        // 
        checkBoxCool.Location = new System.Drawing.Point(116, 307);
        checkBoxCool.Name = "checkBoxCool";
        checkBoxCool.Size = new System.Drawing.Size(196, 40);
        checkBoxCool.TabIndex = 6;
        checkBoxCool.Text = "种植无冷却时间";
        checkBoxCool.UseVisualStyleBackColor = true;
        checkBoxCool.CheckedChanged += checkBoxCool_CheckedChanged;
        // 
        // checkAutoFillSun
        // 
        checkAutoFillSun.Location = new System.Drawing.Point(501, 105);
        checkAutoFillSun.Name = "checkAutoFillSun";
        checkAutoFillSun.Size = new System.Drawing.Size(147, 32);
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
        checkWeek.Location = new System.Drawing.Point(116, 429);
        checkWeek.Name = "checkWeek";
        checkWeek.Size = new System.Drawing.Size(218, 33);
        checkWeek.TabIndex = 8;
        checkWeek.Text = "僵尸削弱(一枪就死)";
        checkWeek.UseVisualStyleBackColor = true;
        checkWeek.CheckedChanged += checkWeek_CheckedChanged;
        // 
        // numSilverCoins
        // 
        numSilverCoins.Location = new System.Drawing.Point(116, 150);
        numSilverCoins.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numSilverCoins.Name = "numSilverCoins";
        numSilverCoins.Size = new System.Drawing.Size(196, 30);
        numSilverCoins.TabIndex = 9;
        numSilverCoins.Value = new decimal(new int[] { 999999, 0, 0, 0 });
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(42, 152);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(68, 29);
        label2.TabIndex = 10;
        label2.Text = "银币";
        // 
        // btnChangeSilverCoins
        // 
        btnChangeSilverCoins.Location = new System.Drawing.Point(348, 144);
        btnChangeSilverCoins.Name = "btnChangeSilverCoins";
        btnChangeSilverCoins.Size = new System.Drawing.Size(132, 41);
        btnChangeSilverCoins.TabIndex = 11;
        btnChangeSilverCoins.Text = "修改银币";
        btnChangeSilverCoins.UseVisualStyleBackColor = true;
        btnChangeSilverCoins.Click += btnChangeSilverCoins_Click;
        // 
        // btnChangeGoldCoins
        // 
        btnChangeGoldCoins.Location = new System.Drawing.Point(348, 191);
        btnChangeGoldCoins.Name = "btnChangeGoldCoins";
        btnChangeGoldCoins.Size = new System.Drawing.Size(132, 41);
        btnChangeGoldCoins.TabIndex = 14;
        btnChangeGoldCoins.Text = "修改金币";
        btnChangeGoldCoins.UseVisualStyleBackColor = true;
        btnChangeGoldCoins.Click += btnChangeGoldCoins_Click;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(42, 199);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(68, 29);
        label3.TabIndex = 13;
        label3.Text = "金币";
        // 
        // numGoldCoins
        // 
        numGoldCoins.Location = new System.Drawing.Point(116, 197);
        numGoldCoins.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numGoldCoins.Name = "numGoldCoins";
        numGoldCoins.Size = new System.Drawing.Size(196, 30);
        numGoldCoins.TabIndex = 12;
        numGoldCoins.Value = new decimal(new int[] { 999999, 0, 0, 0 });
        // 
        // btnChangeDiamond
        // 
        btnChangeDiamond.Location = new System.Drawing.Point(348, 238);
        btnChangeDiamond.Name = "btnChangeDiamond";
        btnChangeDiamond.Size = new System.Drawing.Size(132, 41);
        btnChangeDiamond.TabIndex = 17;
        btnChangeDiamond.Text = "修改钻石";
        btnChangeDiamond.UseVisualStyleBackColor = true;
        btnChangeDiamond.Click += btnChangeDiamond_Click;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(42, 246);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(68, 29);
        label4.TabIndex = 16;
        label4.Text = "钻石";
        // 
        // numDiamond
        // 
        numDiamond.Location = new System.Drawing.Point(116, 244);
        numDiamond.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numDiamond.Name = "numDiamond";
        numDiamond.Size = new System.Drawing.Size(196, 30);
        numDiamond.TabIndex = 15;
        numDiamond.Value = new decimal(new int[] { 999999, 0, 0, 0 });
        // 
        // btnTree
        // 
        btnTree.Location = new System.Drawing.Point(348, 521);
        btnTree.Name = "btnTree";
        btnTree.Size = new System.Drawing.Size(132, 41);
        btnTree.TabIndex = 18;
        btnTree.Text = "长高";
        btnTree.UseVisualStyleBackColor = true;
        btnTree.Click += btnTree_Click;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(42, 529);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(68, 29);
        label5.TabIndex = 20;
        label5.Text = "智慧树";
        // 
        // numTree
        // 
        numTree.Location = new System.Drawing.Point(116, 527);
        numTree.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        numTree.Name = "numTree";
        numTree.Size = new System.Drawing.Size(196, 30);
        numTree.TabIndex = 19;
        numTree.Value = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(42, 314);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(68, 29);
        label6.TabIndex = 21;
        label6.Text = "植物";
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(42, 433);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(68, 29);
        label7.TabIndex = 22;
        label7.Text = "僵尸";
        // 
        // pictureBox1
        // 
        pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
        pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
        pictureBox1.Location = new System.Drawing.Point(570, 521);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(50, 50);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 23;
        pictureBox1.TabStop = false;
        pictureBox1.Click += pictureBox1_Click;
        // 
        // checkHat
        // 
        checkHat.Location = new System.Drawing.Point(348, 425);
        checkHat.Name = "checkHat";
        checkHat.Size = new System.Drawing.Size(218, 40);
        checkHat.TabIndex = 24;
        checkHat.Text = "帽子削弱(一枪就掉)";
        checkHat.UseVisualStyleBackColor = true;
        checkHat.CheckedChanged += checkHat_CheckedChanged;
        // 
        // checkHandle
        // 
        checkHandle.Location = new System.Drawing.Point(116, 468);
        checkHandle.Name = "checkHandle";
        checkHandle.Size = new System.Drawing.Size(218, 40);
        checkHandle.TabIndex = 25;
        checkHandle.Text = "手持削弱(一枪就掉)";
        checkHandle.UseVisualStyleBackColor = true;
        checkHandle.CheckedChanged += checkHandle_CheckedChanged;
        // 
        // checkInvincibility
        // 
        checkInvincibility.Location = new System.Drawing.Point(348, 307);
        checkInvincibility.Name = "checkInvincibility";
        checkInvincibility.Size = new System.Drawing.Size(159, 40);
        checkInvincibility.TabIndex = 26;
        checkInvincibility.Text = "植物无敌";
        checkInvincibility.UseVisualStyleBackColor = true;
        checkInvincibility.CheckedChanged += checkInvincibility_CheckedChanged;
        // 
        // checkUnLockAllPlant
        // 
        checkUnLockAllPlant.Location = new System.Drawing.Point(116, 353);
        checkUnLockAllPlant.Name = "checkUnLockAllPlant";
        checkUnLockAllPlant.Size = new System.Drawing.Size(177, 40);
        checkUnLockAllPlant.TabIndex = 27;
        checkUnLockAllPlant.Text = "解锁所有植物";
        checkUnLockAllPlant.UseVisualStyleBackColor = true;
        checkUnLockAllPlant.CheckedChanged += checkUnLock_CheckedChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(644, 591);
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
        Controls.Add(label1);
        Controls.Add(txtTitle);
        Controls.Add(btnGo);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "游戏修改器";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)numSun).EndInit();
        ((System.ComponentModel.ISupportInitialize)numSilverCoins).EndInit();
        ((System.ComponentModel.ISupportInitialize)numGoldCoins).EndInit();
        ((System.ComponentModel.ISupportInitialize)numDiamond).EndInit();
        ((System.ComponentModel.ISupportInitialize)numTree).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.CheckBox checkUnLockAllPlant;

    private System.Windows.Forms.CheckBox checkInvincibility;

    private System.Windows.Forms.CheckBox checkHandle;

    private System.Windows.Forms.CheckBox checkHat;

    private System.Windows.Forms.PictureBox pictureBox1;

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

    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button btnGo;

    #endregion
}