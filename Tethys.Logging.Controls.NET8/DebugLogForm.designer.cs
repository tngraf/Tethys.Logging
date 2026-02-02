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
      this.RtfLogView = new Tethys.Logging.Controls.RtfLogView();
      this.SuspendLayout();
      // 
      // rtfLogView
      // 
      this.RtfLogView.AddAtTail = true;
      this.RtfLogView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RtfLogView.LabelText = "Application Log";
      this.RtfLogView.Location = new System.Drawing.Point(0, 0);
      this.RtfLogView.MaxLogLength = -1;
      this.RtfLogView.Name = "RtfLogView";
      this.RtfLogView.ShowDebugEvents = false;
      this.RtfLogView.Size = new System.Drawing.Size(546, 193);
      this.RtfLogView.TabIndex = 0;
      this.RtfLogView.TextColor = System.Drawing.Color.Black;
      // 
      // DebugLogForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(546, 193);
      this.Controls.Add(this.RtfLogView);
      this.MinimumSize = new System.Drawing.Size(379, 68);
      this.Name = "DebugLogForm";
      this.Text = "DebugLogForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugLogFormFormClosing);
      this.ResumeLayout(false);

    }

    #endregion
  }
}