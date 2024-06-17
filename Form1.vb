Imports System.IO
Imports System.Numerics
Imports ScottPlot

Public Class Form1
    Private integerList As New List(Of Double)()
    Private dftMagnitudes As New List(Of Double)()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim openFileDialog1 As New OpenFileDialog()

        ' Set the filter for file types
        openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Get the path of the selected file
            Dim filePath As String = openFileDialog1.FileName

            ' Clear the previous data
            integerList.Clear()
            dftMagnitudes.Clear()

            Label3.Text = Path.GetFileName(filePath)

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

                ' Compute the DFT and magnitudes
                ComputeDFT()

                'Plot the input
                PlotOriginalDataOnFormsPlot()

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

    Private Sub PlotOriginalDataOnFormsPlot()
        Dim xs = Enumerable.Range(0, integerList.Count).Select(Function(i) CDbl(i)).ToArray()
        Dim ys = integerList.ToArray()
        FormsPlot1.Plot.Clear()

        Dim scatterPlot = FormsPlot1.Plot.Add.Scatter(xs, ys)
        scatterPlot.MarkerShape = MarkerShape.None
        FormsPlot1.Plot.Title("Original Data Plot")
        FormsPlot1.Plot.XLabel("Time")
        FormsPlot1.Plot.YLabel("Amplitude")
        FormsPlot1.Plot.Axes.AutoScale()
        FormsPlot1.Refresh()
    End Sub

    Private Sub PlotDFTMagnitudesOnFormsPlot()
        Dim xs = Enumerable.Range(0, dftMagnitudes.Count).Select(Function(i) CDbl(i * 22050 / dftMagnitudes.Count)).ToArray()
        Dim ys = dftMagnitudes.ToArray()
        FormsPlot2.Plot.Clear()

        Dim scatterPlot = FormsPlot2.Plot.Add.Scatter(xs, ys)
        scatterPlot.MarkerShape = MarkerShape.None
        FormsPlot2.Plot.Title("DFT Magnitudes Plot")
        FormsPlot2.Plot.XLabel("Frequency(Hz)")
        FormsPlot2.Plot.YLabel("Magnitude")
        FormsPlot2.Plot.Axes.AutoScale()
        FormsPlot2.Refresh()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Plot the DFT magnitudes
        PlotDFTMagnitudesOnFormsPlot()
    End Sub
End Class