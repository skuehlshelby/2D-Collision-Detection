<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Simulation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.particleArea = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFPS = New System.Windows.Forms.NumericUpDown()
        Me.lblFPS = New System.Windows.Forms.Label()
        Me.particleCount = New System.Windows.Forms.NumericUpDown()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.cbxCollisionDetectionMethod = New System.Windows.Forms.ComboBox()
        Me.lbl_particleCount = New System.Windows.Forms.Label()
        Me.cbxSplitMethod = New System.Windows.Forms.ComboBox()
        Me.cbxShowRenderTime = New System.Windows.Forms.CheckBox()
        Me.cbxShowBoundingVolumes = New System.Windows.Forms.CheckBox()
        Me.colorPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2.SuspendLayout
        CType(Me.btnFPS,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.particleCount,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'particleArea
        '
        Me.particleArea.BackColor = System.Drawing.Color.FromArgb(CType(CType(23,Byte),Integer), CType(CType(23,Byte),Integer), CType(CType(23,Byte),Integer))
        Me.particleArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.particleArea.Location = New System.Drawing.Point(243, 3)
        Me.particleArea.Name = "particleArea"
        Me.particleArea.Size = New System.Drawing.Size(554, 444)
        Me.particleArea.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnFPS, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblFPS, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.particleCount, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPause, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxCollisionDetectionMethod, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.lbl_particleCount, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxSplitMethod, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxShowRenderTime, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxShowBoundingVolumes, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.colorPanel, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 7)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(10, 10)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 9
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(220, 297)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'btnFPS
        '
        Me.btnFPS.BackColor = System.Drawing.Color.FromArgb(CType(CType(68,Byte),Integer), CType(CType(68,Byte),Integer), CType(CType(68,Byte),Integer))
        Me.btnFPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnFPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnFPS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.btnFPS.Location = New System.Drawing.Point(179, 69)
        Me.btnFPS.Name = "btnFPS"
        Me.btnFPS.Size = New System.Drawing.Size(38, 23)
        Me.btnFPS.TabIndex = 2
        Me.btnFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnFPS.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'lblFPS
        '
        Me.lblFPS.AutoSize = true
        Me.lblFPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFPS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.lblFPS.Location = New System.Drawing.Point(3, 69)
        Me.lblFPS.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFPS.Name = "lblFPS"
        Me.lblFPS.Size = New System.Drawing.Size(170, 27)
        Me.lblFPS.TabIndex = 3
        Me.lblFPS.Text = "Frames Per Second:"
        Me.lblFPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'particleCount
        '
        Me.particleCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(68,Byte),Integer), CType(CType(68,Byte),Integer), CType(CType(68,Byte),Integer))
        Me.particleCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.particleCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.particleCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.particleCount.Location = New System.Drawing.Point(179, 36)
        Me.particleCount.Name = "particleCount"
        Me.particleCount.Size = New System.Drawing.Size(38, 23)
        Me.particleCount.TabIndex = 0
        Me.particleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPause
        '
        Me.btnPause.BackColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnPause, 2)
        Me.btnPause.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPause.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23,Byte),Integer), CType(CType(23,Byte),Integer), CType(CType(23,Byte),Integer))
        Me.btnPause.Location = New System.Drawing.Point(3, 3)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(214, 27)
        Me.btnPause.TabIndex = 2
        Me.btnPause.Text = "Pause"
        Me.btnPause.UseVisualStyleBackColor = false
        '
        'cbxCollisionDetectionMethod
        '
        Me.cbxCollisionDetectionMethod.BackColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbxCollisionDetectionMethod, 2)
        Me.cbxCollisionDetectionMethod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxCollisionDetectionMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCollisionDetectionMethod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23,Byte),Integer), CType(CType(23,Byte),Integer), CType(CType(23,Byte),Integer))
        Me.cbxCollisionDetectionMethod.FormattingEnabled = true
        Me.cbxCollisionDetectionMethod.Location = New System.Drawing.Point(5, 203)
        Me.cbxCollisionDetectionMethod.Margin = New System.Windows.Forms.Padding(5)
        Me.cbxCollisionDetectionMethod.Name = "cbxCollisionDetectionMethod"
        Me.cbxCollisionDetectionMethod.Size = New System.Drawing.Size(210, 23)
        Me.cbxCollisionDetectionMethod.TabIndex = 4
        Me.cbxCollisionDetectionMethod.Text = "Collision Detection Method"
        '
        'lbl_particleCount
        '
        Me.lbl_particleCount.AutoSize = true
        Me.lbl_particleCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_particleCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.lbl_particleCount.Location = New System.Drawing.Point(3, 36)
        Me.lbl_particleCount.Margin = New System.Windows.Forms.Padding(3)
        Me.lbl_particleCount.Name = "lbl_particleCount"
        Me.lbl_particleCount.Size = New System.Drawing.Size(170, 27)
        Me.lbl_particleCount.TabIndex = 1
        Me.lbl_particleCount.Text = "Particle Count:"
        Me.lbl_particleCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbxSplitMethod
        '
        Me.cbxSplitMethod.BackColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbxSplitMethod, 2)
        Me.cbxSplitMethod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxSplitMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxSplitMethod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23,Byte),Integer), CType(CType(23,Byte),Integer), CType(CType(23,Byte),Integer))
        Me.cbxSplitMethod.FormattingEnabled = true
        Me.cbxSplitMethod.Location = New System.Drawing.Point(5, 170)
        Me.cbxSplitMethod.Margin = New System.Windows.Forms.Padding(5)
        Me.cbxSplitMethod.Name = "cbxSplitMethod"
        Me.cbxSplitMethod.Size = New System.Drawing.Size(210, 23)
        Me.cbxSplitMethod.TabIndex = 3
        Me.cbxSplitMethod.Text = "Scene Split Method"
        '
        'cbxShowRenderTime
        '
        Me.cbxShowRenderTime.AutoSize = true
        Me.cbxShowRenderTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxShowRenderTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxShowRenderTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.cbxShowRenderTime.Location = New System.Drawing.Point(3, 135)
        Me.cbxShowRenderTime.Name = "cbxShowRenderTime"
        Me.cbxShowRenderTime.Size = New System.Drawing.Size(170, 27)
        Me.cbxShowRenderTime.TabIndex = 1
        Me.cbxShowRenderTime.Text = "Show Render Time (µs)"
        Me.cbxShowRenderTime.UseVisualStyleBackColor = true
        '
        'cbxShowBoundingVolumes
        '
        Me.cbxShowBoundingVolumes.AutoSize = true
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbxShowBoundingVolumes, 2)
        Me.cbxShowBoundingVolumes.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbxShowBoundingVolumes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxShowBoundingVolumes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxShowBoundingVolumes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.cbxShowBoundingVolumes.Location = New System.Drawing.Point(3, 102)
        Me.cbxShowBoundingVolumes.Name = "cbxShowBoundingVolumes"
        Me.cbxShowBoundingVolumes.Size = New System.Drawing.Size(214, 27)
        Me.cbxShowBoundingVolumes.TabIndex = 0
        Me.cbxShowBoundingVolumes.Text = "Show Bounding Volumes"
        Me.cbxShowBoundingVolumes.UseVisualStyleBackColor = true
        '
        'colorPanel
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.colorPanel, 2)
        Me.colorPanel.Location = New System.Drawing.Point(3, 267)
        Me.colorPanel.Name = "colorPanel"
        Me.colorPanel.Size = New System.Drawing.Size(214, 27)
        Me.colorPanel.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer), CType(CType(237,Byte),Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 234)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 27)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Particle Colors:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68,Byte),Integer), CType(CType(68,Byte),Integer), CType(CType(68,Byte),Integer))
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.particleArea, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Simulation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Simulation"
        Me.Text = "Particle Motion Simulation"
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        CType(Me.btnFPS,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.particleCount,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents particleArea As Panel
    Friend WithEvents lbl_particleCount As Label
    Friend WithEvents particleCount As NumericUpDown
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblFPS As Label
    Friend WithEvents btnFPS As NumericUpDown
    Friend WithEvents btnPause As Button
    Friend WithEvents cbxShowRenderTime As CheckBox
    Friend WithEvents cbxShowBoundingVolumes As CheckBox
    Friend WithEvents cbxSplitMethod As ComboBox
    Friend WithEvents cbxCollisionDetectionMethod As ComboBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents colorPanel As Panel
End Class
