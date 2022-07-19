Imports DevExpress.Data
Imports DevExpress.Snap.Core.API
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.Sparkline
Imports System
Imports DevExpress.XtraRichEdit
Imports DevExpress.Snap

Namespace SnapServerExamples.CodeExamples

    Friend Class DataShapingActions

        Private Shared Sub InsertData(ByVal server As DevExpress.Snap.SnapDocumentServer)
#Region "#InsertData"
            server.LoadDocumentTemplate("Template.snx")
            Dim list As DevExpress.Snap.Core.API.SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            ' Add a header to the Snap list.                                                                   
            Dim listHeader As DevExpress.Snap.Core.API.SnapDocument = list.ListHeader
            Dim listHeaderTable As DevExpress.XtraRichEdit.API.Native.Table = listHeader.Tables(0)
            Dim listHeaderCells As DevExpress.XtraRichEdit.API.Native.TableCellCollection = listHeaderTable.FirstRow.Cells
            listHeader.InsertText(listHeaderCells.InsertAfter(CInt((2))).ContentRange.[End], "Quantity per Unit")
            ' Add data to the row template:
            Dim listRow As DevExpress.Snap.Core.API.SnapDocument = list.RowTemplate
            Dim listRowTable As DevExpress.XtraRichEdit.API.Native.Table = listRow.Tables(0)
            Dim listRowCells As DevExpress.XtraRichEdit.API.Native.TableCellCollection = listRowTable.FirstRow.Cells
            listRow.CreateSnText(listRowCells.InsertAfter(CInt((2))).ContentRange.[End], "QuantityPerUnit")
            list.EndUpdate()
            list.Field.Update()
#End Region  ' #InsertData
        End Sub

        Private Shared Sub FormatData(ByVal server As DevExpress.Snap.SnapDocumentServer)
#Region "#FormatData"
            server.LoadDocumentTemplate("Template.snx")
            Dim list As DevExpress.Snap.Core.API.SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            list.EditorRowLimit = 100500
            Dim header As DevExpress.Snap.Core.API.SnapDocument = list.ListHeader
            Dim headerTable As DevExpress.XtraRichEdit.API.Native.Table = header.Tables(0)
            headerTable.SetPreferredWidth(50 * 100, DevExpress.XtraRichEdit.API.Native.WidthType.FiftiethsOfPercent)
            For Each row As DevExpress.XtraRichEdit.API.Native.TableRow In headerTable.Rows
                For Each cell As DevExpress.XtraRichEdit.API.Native.TableCell In row.Cells
                    ' Apply cell formatting.
                    cell.Borders.Left.LineColor = System.Drawing.Color.White
                    cell.Borders.Right.LineColor = System.Drawing.Color.White
                    cell.Borders.Top.LineColor = System.Drawing.Color.White
                    cell.Borders.Bottom.LineColor = System.Drawing.Color.White
                    cell.BackgroundColor = System.Drawing.Color.SteelBlue
                    ' Apply text formatting.
                    Dim formatting As DevExpress.XtraRichEdit.API.Native.CharacterProperties = header.BeginUpdateCharacters(cell.ContentRange)
                    formatting.Bold = True
                    formatting.ForeColor = System.Drawing.Color.White
                    header.EndUpdateCharacters(formatting)
                Next
            Next

            ' Customize the row template.
            Dim rowTemplate As DevExpress.Snap.Core.API.SnapDocument = list.RowTemplate
            Dim rowTable As DevExpress.XtraRichEdit.API.Native.Table = rowTemplate.Tables(0)
            rowTable.SetPreferredWidth(50 * 100, DevExpress.XtraRichEdit.API.Native.WidthType.FiftiethsOfPercent)
            For Each row As DevExpress.XtraRichEdit.API.Native.TableRow In rowTable.Rows
                For Each cell As DevExpress.XtraRichEdit.API.Native.TableCell In row.Cells
                    cell.Borders.Left.LineColor = System.Drawing.Color.Transparent
                    cell.Borders.Right.LineColor = System.Drawing.Color.Transparent
                    cell.Borders.Top.LineColor = System.Drawing.Color.Transparent
                    cell.Borders.Bottom.LineColor = System.Drawing.Color.LightGray
                Next
            Next

            list.EndUpdate()
            list.Field.Update()
#End Region  ' #FormatData
        End Sub

        Private Shared Sub FilterData(ByVal server As DevExpress.Snap.SnapDocumentServer)
#Region "#FilterData"
            ' Delete the document's content.
            server.LoadDocument("Template.snx")
            Dim list As DevExpress.Snap.Core.API.SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            ' Apply filtering:
            Const filter As String = "[Discontinued] = False"
            If Not list.Filters.Contains(filter) Then
                list.Filters.Add(filter)
            End If

            list.EndUpdate()
            list.Field.Update()
#End Region  ' #FilterData
        End Sub

        Private Shared Sub SortList(ByVal server As DevExpress.Snap.SnapDocumentServer)
#Region "#SortData"
            server.LoadDocumentTemplate("Template.snx")
            Dim list As DevExpress.Snap.Core.API.SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            list.Sorting.Add(New DevExpress.Snap.Core.API.SnapListGroupParam("UnitPrice", DevExpress.Data.ColumnSortOrder.Descending))
            list.EndUpdate()
            list.Field.Update()
#End Region  ' #SortData
        End Sub

        Private Shared Sub GroupData(ByVal server As DevExpress.Snap.SnapDocumentServer)
#Region "#GroupData"
            server.LoadDocumentTemplate("Template.snx")
            Dim list As DevExpress.Snap.Core.API.SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            list.EditorRowLimit = 100500
            ' Add a header to the Snap list.                                                                   
            Dim listHeader As DevExpress.Snap.Core.API.SnapDocument = list.ListHeader
            Dim listHeaderTable As DevExpress.XtraRichEdit.API.Native.Table = listHeader.Tables(0)
            Dim group As DevExpress.Snap.Core.API.SnapListGroupInfo = list.Groups.CreateSnapListGroupInfo(New DevExpress.Snap.Core.API.SnapListGroupParam("CategoryID", DevExpress.Data.ColumnSortOrder.Ascending))
            list.Groups.Add(group)
            ' Add a group header.
            Dim groupHeader As DevExpress.Snap.Core.API.SnapDocument = group.CreateHeader()
            Dim headerTable As DevExpress.XtraRichEdit.API.Native.Table = groupHeader.Tables.Create(groupHeader.Range.[End], 1, 1)
            headerTable.SetPreferredWidth(50 * 100, DevExpress.XtraRichEdit.API.Native.WidthType.FiftiethsOfPercent)
            Dim groupHeaderCells As DevExpress.XtraRichEdit.API.Native.TableCellCollection = headerTable.FirstRow.Cells
            groupHeader.InsertText(groupHeaderCells(CInt((0))).ContentRange.[End], "Category ID: ")
            groupHeader.CreateSnText(groupHeaderCells(CInt((0))).ContentRange.[End], "CategoryID")
            ' Customize the group header formatting.
            groupHeaderCells(CInt((0))).BackgroundColor = System.Drawing.Color.LightGray
            groupHeaderCells(CInt((0))).Borders.Bottom.LineColor = System.Drawing.Color.White
            groupHeaderCells(CInt((0))).Borders.Left.LineColor = System.Drawing.Color.White
            groupHeaderCells(CInt((0))).Borders.Right.LineColor = System.Drawing.Color.White
            groupHeaderCells(CInt((0))).Borders.Top.LineColor = System.Drawing.Color.White
            ' Add a group footer.
            Dim groupFooter As DevExpress.Snap.Core.API.SnapDocument = group.CreateFooter()
            Dim footerTable As DevExpress.XtraRichEdit.API.Native.Table = groupFooter.Tables.Create(groupFooter.Range.[End], 1, 1)
            footerTable.SetPreferredWidth(50 * 100, DevExpress.XtraRichEdit.API.Native.WidthType.FiftiethsOfPercent)
            Dim groupFooterCells As DevExpress.XtraRichEdit.API.Native.TableCellCollection = footerTable.FirstRow.Cells
            groupFooter.InsertText(groupFooterCells(CInt((0))).ContentRange.[End], "Count = ")
            groupFooter.CreateSnText(groupFooterCells(CInt((0))).ContentRange.[End], "CategoryID \sr Group \sf Count")
            ' Customize the group footer formatting.
            groupFooterCells(CInt((0))).BackgroundColor = System.Drawing.Color.LightGray
            groupFooterCells(CInt((0))).Borders.Bottom.LineColor = System.Drawing.Color.White
            groupFooterCells(CInt((0))).Borders.Left.LineColor = System.Drawing.Color.White
            groupFooterCells(CInt((0))).Borders.Right.LineColor = System.Drawing.Color.White
            groupFooterCells(CInt((0))).Borders.Top.LineColor = System.Drawing.Color.White
            list.EndUpdate()
        'list.Field.Update();
#End Region  ' #GroupData
        End Sub
    End Class
End Namespace
