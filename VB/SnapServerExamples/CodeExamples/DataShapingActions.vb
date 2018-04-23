Imports DevExpress.Data
Imports DevExpress.Snap.Core.API
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.Sparkline
Imports System
Imports DevExpress.XtraRichEdit
Imports DevExpress.Snap

Namespace SnapServerExamples.CodeExamples
    Friend Class DataShapingActions
        Private Shared Sub InsertData(ByVal server As SnapDocumentServer)
'            #Region "#InsertData"
            server.LoadDocumentTemplate("Template.snx")
            Dim list As SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()

            ' Add a header to the Snap list.                                                                   
            Dim listHeader As SnapDocument = list.ListHeader
            Dim listHeaderTable As Table = listHeader.Tables(0)
            Dim listHeaderCells As TableCellCollection = listHeaderTable.FirstRow.Cells
            listHeader.InsertText(listHeaderCells.InsertAfter(2).ContentRange.End, "Quantity per Unit")



            ' Add data to the row template:
            Dim listRow As SnapDocument = list.RowTemplate
            Dim listRowTable As Table = listRow.Tables(0)
            Dim listRowCells As TableCellCollection = listRowTable.FirstRow.Cells
            listRow.CreateSnText(listRowCells.InsertAfter(2).ContentRange.End, "QuantityPerUnit")
            list.EndUpdate()

            list.Field.Update()
'            #End Region ' #InsertData
        End Sub
        Private Shared Sub FormatData(ByVal server As SnapDocumentServer)
'            #Region "#FormatData"
            server.LoadDocumentTemplate("Template.snx")
            Dim list As SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            list.EditorRowLimit = 100500

            Dim header As SnapDocument = list.ListHeader
            Dim headerTable As Table = header.Tables(0)
            headerTable.SetPreferredWidth(50 * 100, WidthType.FiftiethsOfPercent)

            For Each row As TableRow In headerTable.Rows
                For Each cell As TableCell In row.Cells
                    ' Apply cell formatting.
                    cell.Borders.Left.LineColor = System.Drawing.Color.White
                    cell.Borders.Right.LineColor = System.Drawing.Color.White
                    cell.Borders.Top.LineColor = System.Drawing.Color.White
                    cell.Borders.Bottom.LineColor = System.Drawing.Color.White
                    cell.BackgroundColor = System.Drawing.Color.SteelBlue

                    ' Apply text formatting.
                    Dim formatting As CharacterProperties = header.BeginUpdateCharacters(cell.ContentRange)
                    formatting.Bold = True
                    formatting.ForeColor = System.Drawing.Color.White
                    header.EndUpdateCharacters(formatting)
                Next cell
            Next row

            ' Customize the row template.
            Dim rowTemplate As SnapDocument = list.RowTemplate
            Dim rowTable As Table = rowTemplate.Tables(0)
            rowTable.SetPreferredWidth(50 * 100, WidthType.FiftiethsOfPercent)
            For Each row As TableRow In rowTable.Rows
                For Each cell As TableCell In row.Cells
                    cell.Borders.Left.LineColor = System.Drawing.Color.Transparent
                    cell.Borders.Right.LineColor = System.Drawing.Color.Transparent
                    cell.Borders.Top.LineColor = System.Drawing.Color.Transparent
                    cell.Borders.Bottom.LineColor = System.Drawing.Color.LightGray
                Next cell
            Next row

            list.EndUpdate()
            list.Field.Update()

'            #End Region ' #FormatData
        End Sub

        Private Shared Sub FilterData(ByVal server As SnapDocumentServer)
'            #Region "#FilterData"
            ' Delete the document's content.
            server.LoadDocument("Template.snx")

            Dim list As SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            ' Apply filtering:
            Const filter As String = "[Discontinued] = False"
            If Not list.Filters.Contains(filter) Then
                list.Filters.Add(filter)
            End If

            list.EndUpdate()
            list.Field.Update()


'            #End Region ' #FilterData
        End Sub

        Private Shared Sub SortList(ByVal server As SnapDocumentServer)
'            #Region "#SortData"
            server.LoadDocumentTemplate("Template.snx")
            Dim list As SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            list.Sorting.Add(New SnapListGroupParam("UnitPrice", ColumnSortOrder.Descending))
            list.EndUpdate()
            list.Field.Update()

'            #End Region ' #SortData
        End Sub
        Private Shared Sub GroupData(ByVal server As SnapDocumentServer)
'            #Region "#GroupData"

            server.LoadDocumentTemplate("Template.snx")
            Dim list As SnapList = server.Document.FindListByName("Data Source 11")
            server.Document.ParseField(list.Field)
            list.BeginUpdate()
            list.EditorRowLimit = 100500

            ' Add a header to the Snap list.                                                                   
            Dim listHeader As SnapDocument = list.ListHeader
            Dim listHeaderTable As Table = listHeader.Tables(0)


            Dim group As SnapListGroupInfo = list.Groups.CreateSnapListGroupInfo(New SnapListGroupParam("CategoryID", ColumnSortOrder.Ascending))
            list.Groups.Add(group)

            ' Add a group header.
            Dim groupHeader As SnapDocument = group.CreateHeader()
            Dim headerTable As Table = groupHeader.Tables.Create(groupHeader.Range.End, 1, 1)
            headerTable.SetPreferredWidth(50 * 100, WidthType.FiftiethsOfPercent)
            Dim groupHeaderCells As TableCellCollection = headerTable.FirstRow.Cells
            groupHeader.InsertText(groupHeaderCells(0).ContentRange.End, "Category ID: ")
            groupHeader.CreateSnText(groupHeaderCells(0).ContentRange.End, "CategoryID")

            ' Customize the group header formatting.
            groupHeaderCells(0).BackgroundColor = System.Drawing.Color.LightGray
            groupHeaderCells(0).Borders.Bottom.LineColor = System.Drawing.Color.White
            groupHeaderCells(0).Borders.Left.LineColor = System.Drawing.Color.White
            groupHeaderCells(0).Borders.Right.LineColor = System.Drawing.Color.White
            groupHeaderCells(0).Borders.Top.LineColor = System.Drawing.Color.White

            ' Add a group footer.
            Dim groupFooter As SnapDocument = group.CreateFooter()
            Dim footerTable As Table = groupFooter.Tables.Create(groupFooter.Range.End, 1, 1)
            footerTable.SetPreferredWidth(50 * 100, WidthType.FiftiethsOfPercent)
            Dim groupFooterCells As TableCellCollection = footerTable.FirstRow.Cells
            groupFooter.InsertText(groupFooterCells(0).ContentRange.End, "Count = ")
            groupFooter.CreateSnText(groupFooterCells(0).ContentRange.End, "CategoryID \sr Group \sf Count")

            ' Customize the group footer formatting.
            groupFooterCells(0).BackgroundColor = System.Drawing.Color.LightGray
            groupFooterCells(0).Borders.Bottom.LineColor = System.Drawing.Color.White
            groupFooterCells(0).Borders.Left.LineColor = System.Drawing.Color.White
            groupFooterCells(0).Borders.Right.LineColor = System.Drawing.Color.White
            groupFooterCells(0).Borders.Top.LineColor = System.Drawing.Color.White

            list.EndUpdate()
            'list.Field.Update();

'            #End Region ' #GroupData
        End Sub
    End Class
End Namespace
