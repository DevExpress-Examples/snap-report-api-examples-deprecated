Imports DevExpress.Snap
Imports DevExpress.Snap.Core.API
Imports DevExpress.Sparkline
Imports DevExpress.XtraPrinting.BarCode
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace SnapServerExamples.CodeExamples
    Friend Class DataVisualizationToolsActions
        Private Shared Sub CreateParameter(ByVal server As SnapDocumentServer)
'            #Region "#CreateParameter"
            server.LoadDocumentTemplate("Template.snx")
            server.Document.BeginUpdate()
            'Create parameter:
            Dim param1 As New Parameter()
            param1.Name = "Region"
            param1.Type = GetType(System.String)
            param1.Value = "NEW ENGLAND"
            server.Document.Parameters.Add(param1)
            'Insert parameter field in the document:
            Dim list As SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            list.ListHeader.InsertText(list.ListHeader.Tables(0).FirstRow.Cells.InsertAfter(3).ContentRange.End, "Region")
            list.RowTemplate.CreateSnText(list.RowTemplate.Tables(0).FirstRow.Cells.InsertAfter(3).ContentRange.End, "Region \p")
            list.Field.Update()
            list.EndUpdate()
            server.Document.EndUpdate()
            server.Document.Fields.Update()
'            #End Region ' #CreateParameter
        End Sub

        Private Shared Sub CreateSparkline(ByVal server As SnapDocumentServer)
'            #Region "#CreateSparkline"
            server.LoadDocumentTemplate("Template.snx")
            server.Document.BeginUpdate()
            Dim sparkline As SnapSparkline = server.Document.CreateSnSparkline(server.Document.Range.End, "UnitsInStock")
            server.Document.ParseField(sparkline.Field)
            sparkline.BeginUpdate()
            sparkline.DataSourceName = "/Data Source 1.Products"
            sparkline.ViewType = SparklineViewType.Line
            sparkline.Color = System.Drawing.Color.Teal
            sparkline.EndUpdate()
            sparkline.Field.Update()
'            #End Region ' #CreateSparkline
        End Sub
        Private Shared Sub CreateCheckBox(ByVal server As SnapDocumentServer)
'            #Region "#CreateCheckBox      "
            server.LoadDocumentTemplate("Template.snx")
            server.Document.BeginUpdate()
            Dim checkbox As SnapCheckBox = server.Document.CreateSnCheckBox(server.Document.Range.Start, "Discontinued")
            server.Document.ParseField(checkbox.Field)
            checkbox.BeginUpdate()
            checkbox.State = System.Windows.Forms.CheckState.Checked
            checkbox.EndUpdate()
            checkbox.Field.Update()
'            #End Region ' #CreateCheckBox
        End Sub
        Private Shared Sub CreateBarCode(ByVal server As SnapDocumentServer)
'            #Region "#CreateBarcode"
            server.LoadDocumentTemplate("Template.snx")
            server.Document.BeginUpdate()
            Dim barcode As SnapBarCode = server.Document.CreateSnBarCode(server.Document.Range.Start)
            server.Document.ParseField(barcode.Field)
            barcode.BeginUpdate()
            barcode.DataFieldName = "EAN13"
            barcode.Module = 10
            barcode.Orientation = DevExpress.XtraPrinting.BarCode.BarCodeOrientation.Normal
            barcode.AutoModule = True
            barcode.ShowData = False
            barcode.EndUpdate()
            barcode.Field.Update()
'            #End Region ' #CreateBarcode
        End Sub
        Private Shared Sub CreateCalculatedField(ByVal server As SnapDocumentServer)
'            #Region "#CreateCalculatedField"
            server.LoadDocumentTemplate("Template.snx")
            server.Document.BeginUpdate()
            Dim field As New CalculatedField("newField", "Products")
            field.FieldType = DevExpress.XtraReports.UI.FieldType.Int32
            field.Expression = "[UnitsInStock]*[UnitPrice]"
            field.DataSourceName = "Data Source 1"
            server.Document.CalculatedFields.Add(field)
            server.Document.EndUpdate()
            server.Document.Fields.Update()
'            #End Region ' #CreateCalculatedField
        End Sub
    End Class
End Namespace
