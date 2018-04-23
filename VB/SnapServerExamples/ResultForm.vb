Imports System.Windows.Forms
Imports System.Data.SqlClient

Namespace SnapServerExamples
    Partial Public Class ResultForm
        Inherits UserControl

        Public Sub New()
            InitializeComponent()

            ResultSnapControl2.LoadDocument("Result.snx")

        End Sub


    End Class
End Namespace
