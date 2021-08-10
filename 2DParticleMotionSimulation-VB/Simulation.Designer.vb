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
        Me.optionsPanel = New System.Windows.Forms.Panel()
        Me.lbl_particleCount = New System.Windows.Forms.Label()
        Me.particleCount = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.optionsPanel.SuspendLayout
        CType(Me.particleCount,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'particleArea
        '
        Me.particleArea.BackColor = System.Drawing.Color.Black
        Me.particleArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.particleArea.Location = New System.Drawing.Point(243, 3)
        Me.particleArea.Name = "particleArea"
        Me.particleArea.Size = New System.Drawing.Size(554, 444)
        Me.particleArea.TabIndex = 0
        '
        'optionsPanel
        '
        Me.optionsPanel.BackColor = System.Drawing.Color.Black
        Me.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.optionsPanel.Controls.Add(Me.lbl_particleCount)
        Me.optionsPanel.Controls.Add(Me.particleCount)
        Me.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.optionsPanel.ForeColor = System.Drawing.Color.White
        Me.optionsPanel.Location = New System.Drawing.Point(3, 3)
        Me.optionsPanel.Name = "optionsPanel"
        Me.optionsPanel.Size = New System.Drawing.Size(234, 444)
        Me.optionsPanel.TabIndex = 1
        '
        'lbl_particleCount
        '
        Me.lbl_particleCount.AutoSize = true
        Me.lbl_particleCount.Location = New System.Drawing.Point(12, 45)
        Me.lbl_particleCount.Name = "lbl_particleCount"
        Me.lbl_particleCount.Size = New System.Drawing.Size(85, 15)
        Me.lbl_particleCount.TabIndex = 1
        Me.lbl_particleCount.Text = "Particle Count:"
        '
        'particleCount
        '
        Me.particleCount.BackColor = System.Drawing.Color.Black
        Me.particleCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.particleCount.ForeColor = System.Drawing.Color.White
        Me.particleCount.Location = New System.Drawing.Point(111, 43)
        Me.particleCount.Name = "particleCount"
        Me.particleCount.Size = New System.Drawing.Size(52, 23)
        Me.particleCount.TabIndex = 0
        Me.particleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70!))
        Me.TableLayoutPanel1.Controls.Add(Me.optionsPanel, 0, 0)
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
        Me.optionsPanel.ResumeLayout(false)
        Me.optionsPanel.PerformLayout
        CType(Me.particleCount,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents particleArea As Panel
    Friend WithEvents optionsPanel As Panel
    Friend WithEvents lbl_particleCount As Label
    Friend WithEvents particleCount As NumericUpDown
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
