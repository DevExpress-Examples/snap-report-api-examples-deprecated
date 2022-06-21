Imports System.Windows.Forms

Namespace SnapServerExamples

    Public Partial Class ResultForm
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
            ResultSnapControl2.LoadDocument("Result.snx")
        End Sub
    End Class
End Namespace
