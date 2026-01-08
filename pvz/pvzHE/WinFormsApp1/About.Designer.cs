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
        label1 = new System.Windows.Forms.Label();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        label2 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)134));
        label1.Location = new System.Drawing.Point(34, 20);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(289, 34);
        label1.TabIndex = 0;
        label1.Text = "植物大战僵尸杂交版修改器";
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
        // label2
        // 
        label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
        label2.Location = new System.Drawing.Point(34, 58);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(289, 34);
        label2.TabIndex = 4;
        label2.Text = "讨论组";
        // 
        // About
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(463, 632);
        Controls.Add(label2);
        Controls.Add(pictureBox1);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "关于";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    #endregion
}