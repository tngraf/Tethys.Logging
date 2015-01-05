namespace Tethys.Logging.Controls
{
  partial class DebugLogForm
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
            this.rtfLogView = new Tethys.Logging.Controls.RtfLogView();
            this.SuspendLayout();
            // 
            // rtfLogView
            // 
            this.rtfLogView.AddAtTail = true;
            this.rtfLogView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfLogView.LabelText = "Application Log";
            this.rtfLogView.Location = new System.Drawing.Point(0, 0);
            this.rtfLogView.Margin = new System.Windows.Forms.Padding(4);
            this.rtfLogView.MaxLogLength = -1;
            this.rtfLogView.Name = "rtfLogView";
            this.rtfLogView.ShowDebugEvents = false;
            this.rtfLogView.Size = new System.Drawing.Size(907, 231);
            this.rtfLogView.TabIndex = 0;
            this.rtfLogView.TextColor = System.Drawing.Color.Black;
            // 
            // DebugLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 231);
            this.Controls.Add(this.rtfLogView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(500, 75);
            this.Name = "DebugLogForm";
            this.Text = "DebugLogForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugLogFormFormClosing);
            this.ResumeLayout(false);

    }

    #endregion

    private RtfLogView rtfLogView;
  }
}