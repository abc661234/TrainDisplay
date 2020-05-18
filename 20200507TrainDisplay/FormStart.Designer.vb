<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button200 = New System.Windows.Forms.Button()
        Me.Button100 = New System.Windows.Forms.Button()
        Me.Label500 = New System.Windows.Forms.Label()
        Me.Label600 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button200
        '
        Me.Button200.Location = New System.Drawing.Point(585, 65)
        Me.Button200.Name = "Button200"
        Me.Button200.Size = New System.Drawing.Size(121, 38)
        Me.Button200.TabIndex = 17
        Me.Button200.Text = "測試模式"
        Me.Button200.UseVisualStyleBackColor = True
        '
        'Button100
        '
        Me.Button100.Location = New System.Drawing.Point(585, 116)
        Me.Button100.Name = "Button100"
        Me.Button100.Size = New System.Drawing.Size(121, 38)
        Me.Button100.TabIndex = 16
        Me.Button100.Text = "出發！"
        Me.Button100.UseVisualStyleBackColor = True
        '
        'Label500
        '
        Me.Label500.AutoSize = True
        Me.Label500.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label500.Location = New System.Drawing.Point(35, 500)
        Me.Label500.Name = "Label500"
        Me.Label500.Size = New System.Drawing.Size(54, 27)
        Me.Label500.TabIndex = 18
        Me.Label500.Text = "新增"
        '
        'Label600
        '
        Me.Label600.AutoSize = True
        Me.Label600.ForeColor = System.Drawing.Color.Red
        Me.Label600.Location = New System.Drawing.Point(95, 500)
        Me.Label600.Name = "Label600"
        Me.Label600.Size = New System.Drawing.Size(54, 27)
        Me.Label600.TabIndex = 19
        Me.Label600.Text = "移除"
        Me.Label600.Visible = False
        '
        'FormStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 596)
        Me.Controls.Add(Me.Label600)
        Me.Controls.Add(Me.Label500)
        Me.Controls.Add(Me.Button200)
        Me.Controls.Add(Me.Button100)
        Me.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.Name = "FormStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "台鐵廣播模擬"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button200 As Button
    Friend WithEvents Button100 As Button
    Friend WithEvents Label500 As Label
    Friend WithEvents Label600 As Label
End Class
