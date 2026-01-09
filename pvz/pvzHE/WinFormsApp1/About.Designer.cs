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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
        labelName = new System.Windows.Forms.Label();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        labelVer = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // labelName
        // 
        labelName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)134));
        labelName.Location = new System.Drawing.Point(34, 20);
        labelName.Name = "labelName";
        labelName.Size = new System.Drawing.Size(385, 34);
        labelName.TabIndex = 0;
        labelName.Text = "植物大战僵尸杂交版修改器";
        // 
        // pictureBox1
        // 
        pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
        pictureBox1.Location = new System.Drawing.Point(33, 105);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(386, 492);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // labelVer
        // 
        labelVer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
        labelVer.Location = new System.Drawing.Point(34, 58);
        labelVer.Name = "labelVer";
        labelVer.Size = new System.Drawing.Size(289, 34);
        labelVer.TabIndex = 4;
        labelVer.Text = "讨论组";
        // 
        // About
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(463, 632);
        Controls.Add(labelVer);
        Controls.Add(pictureBox1);
        Controls.Add(labelName);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "关于";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelVer;

    #endregion
}