using System.ComponentModel;

namespace WinFormsApp1;

partial class About
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(About));
        labelName = new Label();
        pictureBox1 = new PictureBox();
        labelVer = new Label();
        ((ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // labelName
        // 
        labelName.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
        labelName.Location = new Point(34, 20);
        labelName.Name = "labelName";
        labelName.Size = new Size(385, 34);
        labelName.TabIndex = 0;
        labelName.Text = "植物大战僵尸杂交版修改器";
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(33, 105);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(386, 492);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // labelVer
        // 
        labelVer.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        labelVer.Location = new Point(34, 58);
        labelVer.Name = "labelVer";
        labelVer.Size = new Size(289, 34);
        labelVer.TabIndex = 4;
        labelVer.Text = "版本号";
        // 
        // About
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(463, 632);
        Controls.Add(labelVer);
        Controls.Add(pictureBox1);
        Controls.Add(labelName);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "About";
        StartPosition = FormStartPosition.CenterParent;
        Text = "关于";
        ((ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelVer;

    #endregion
}