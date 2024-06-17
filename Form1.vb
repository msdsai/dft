Imports System.IO
Imports System.Numerics

Public Class Form1
    Private integerList As New List(Of Double)()
    Private dftMagnitudes As New List(Of Double)()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create an instance of the OpenFileDialog
        Dim openFileDialog1 As New OpenFileDialog()

        ' Set the filter for file types
        openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"

        ' Show the Open File dialog
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Get the path of the selected file
            Dim filePath As String = openFileDialog1.FileName

            ' Clear the previous data
            integerList.Clear()
            dftMagnitudes.Clear()

            ' Read the file line by line
            Try
                Using sr As New StreamReader(filePath)
                    Dim line As String
                    line = sr.ReadLine()
                    While line IsNot Nothing
                        Dim number As Double
                        If Double.TryParse(line, number) Then
                            integerList.Add(number)
                        End If
                        line = sr.ReadLine()
                    End While
                End Using

                Panel1.Invalidate()
                ' Compute the DFT and magnitudes
                ComputeDFT()

                ' Refresh the Panel to trigger the Paint event
                Panel2.Invalidate()

            Catch ex As Exception
                MessageBox.Show("Error reading file: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub ComputeDFT()
        Dim N As Integer = integerList.Count
        Dim dftResult(N - 1) As Complex

        For k As Integer = 0 To N - 1
            Dim sum As Complex = Complex.Zero
            For innerN As Integer = 0 To N - 1
                Dim angle As Double = -2.0 * Math.PI * k * innerN / N
                sum += integerList(innerN) * New Complex(Math.Cos(angle), Math.Sin(angle))
            Next
            dftResult(k) = sum
            dftMagnitudes.Add(dftResult(k).Magnitude)
        Next
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics = e.Graphics
        Dim panelWidth As Integer = Panel1.ClientSize.Width
        Dim panelHeight As Integer = Panel1.ClientSize.Height - 1

        If integerList.Count > 0 Then
            ' Determine the scale factors
            Dim maxValue As Double = integerList.Max()
            Dim xScale As Single = panelWidth / integerList.Count
            Dim yScale As Single = If(maxValue <> 0, panelHeight / maxValue, 1)

            ' Draw the axes
            g.DrawLine(Pens.Black, 0, panelHeight, panelWidth, panelHeight)
            g.DrawLine(Pens.Black, 0, 0, 0, panelHeight)

            ' Draw the graph
            For i As Integer = 0 To integerList.Count - 1
                Dim x As Single = i * xScale
                Dim y As Single = panelHeight - (integerList(i) * yScale)
                g.FillEllipse(Brushes.Blue, x, y, 0, 0)

                If i > 0 Then
                    Dim prevX As Single = (i - 1) * xScale
                    Dim prevY As Single = panelHeight - (integerList(i - 1) * yScale)
                    g.DrawLine(Pens.Blue, prevX, prevY, x, y)
                End If
            Next
        End If
    End Sub
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Dim g = e.Graphics
        Dim panelWidth = Panel2.ClientSize.Width - 10
        Dim panelHeight = Panel2.ClientSize.Height - 10

        If dftMagnitudes.Count > 0 Then
            ' Determine the scale factors
            Dim maxValue = dftMagnitudes.Max
            Dim xScale As Single = (panelWidth) / dftMagnitudes.Count
            Dim yScale As Single = If(maxValue <> 0, panelHeight / maxValue, 1)

            ' Draw the axes
            g.DrawLine(Pens.Black, 0, panelHeight, panelWidth, panelHeight)
            g.DrawLine(Pens.Black, 0, 0, 0, panelHeight)
            'g.DrawLine(Pens.Black, 0, 0, panelWidth, 0)
            'g.DrawLine(Pens.Black, panelWidth, 0, panelWidth, panelHeight)

            ' Draw the graph
            For i = 0 To dftMagnitudes.Count - 1
                Dim x = i * xScale
                Dim y As Single = panelHeight - dftMagnitudes(i) * yScale
                g.FillEllipse(Brushes.Blue, x, y, 0, 0)

                If i > 0 Then
                    Dim prevX = (i - 1) * xScale
                    Dim prevY As Single = panelHeight - dftMagnitudes(i - 1) * yScale
                    g.DrawLine(Pens.Blue, prevX, prevY, x, y)
                End If
            Next
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class