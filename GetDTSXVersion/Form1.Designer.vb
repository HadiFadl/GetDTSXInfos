<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdRegEx = New System.Windows.Forms.RadioButton()
        Me.rdXmlParser = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(732, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(714, 20)
        Me.TextBox1.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 75)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(779, 475)
        Me.DataGridView1.TabIndex = 2
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(692, 45)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdXmlParser)
        Me.Panel1.Controls.Add(Me.rdRegEx)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.btnStart)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(779, 75)
        Me.Panel1.TabIndex = 4
        '
        'rdRegEx
        '
        Me.rdRegEx.AutoSize = True
        Me.rdRegEx.Checked = True
        Me.rdRegEx.Location = New System.Drawing.Point(12, 45)
        Me.rdRegEx.Name = "rdRegEx"
        Me.rdRegEx.Size = New System.Drawing.Size(56, 17)
        Me.rdRegEx.TabIndex = 4
        Me.rdRegEx.TabStop = True
        Me.rdRegEx.Text = "RegEx"
        Me.rdRegEx.UseVisualStyleBackColor = True
        '
        'rdXmlParser
        '
        Me.rdXmlParser.AutoSize = True
        Me.rdXmlParser.Location = New System.Drawing.Point(108, 45)
        Me.rdXmlParser.Name = "rdXmlParser"
        Me.rdXmlParser.Size = New System.Drawing.Size(75, 17)
        Me.rdXmlParser.TabIndex = 5
        Me.rdXmlParser.Text = "Xml Parser"
        Me.rdXmlParser.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 550)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnStart As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdXmlParser As RadioButton
    Friend WithEvents rdRegEx As RadioButton
End Class
