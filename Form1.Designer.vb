<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Button1 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        FormsPlot1 = New ScottPlot.WinForms.FormsPlot()
        FormsPlot2 = New ScottPlot.WinForms.FormsPlot()
        Button2 = New Button()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Button1.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(342, 418)
        Button1.Name = "Button1"
        Button1.Size = New Size(151, 50)
        Button1.TabIndex = 0
        Button1.Text = "Select vowel"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(1164, 383)
        Label1.Name = "Label1"
        Label1.Size = New Size(160, 23)
        Label1.TabIndex = 4
        Label1.Text = "Frequency Domain"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(367, 383)
        Label2.Name = "Label2"
        Label2.Size = New Size(113, 23)
        Label2.TabIndex = 5
        Label2.Text = "TimeDomain"
        ' 
        ' FormsPlot1
        ' 
        FormsPlot1.DisplayScale = 1.25F
        FormsPlot1.Location = New Point(50, 12)
        FormsPlot1.Name = "FormsPlot1"
        FormsPlot1.Size = New Size(735, 343)
        FormsPlot1.TabIndex = 6
        ' 
        ' FormsPlot2
        ' 
        FormsPlot2.DisplayScale = 1.25F
        FormsPlot2.Location = New Point(862, 12)
        FormsPlot2.Name = "FormsPlot2"
        FormsPlot2.Size = New Size(735, 343)
        FormsPlot2.TabIndex = 7
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(1164, 418)
        Button2.Name = "Button2"
        Button2.Size = New Size(151, 50)
        Button2.TabIndex = 8
        Button2.Text = "Output"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(742, 407)
        Label3.Name = "Label3"
        Label3.Size = New Size(0, 28)
        Label3.TabIndex = 9
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1637, 493)
        Controls.Add(Label3)
        Controls.Add(Button2)
        Controls.Add(FormsPlot2)
        Controls.Add(FormsPlot1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents FormsPlot1 As ScottPlot.WinForms.FormsPlot
    Friend WithEvents FormsPlot2 As ScottPlot.WinForms.FormsPlot
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label

End Class
