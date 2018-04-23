using DevExpress.Data;
using DevExpress.Snap.Core.API;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.Sparkline;
using System;
using DevExpress.XtraRichEdit;
using DevExpress.Snap;

namespace SnapServerExamples.CodeExamples
{
    class DataShapingActions
    {
        static void InsertData(SnapDocumentServer server)
        {
            #region #InsertData
            server.LoadDocumentTemplate("Template.snx");
            SnapList list = server.Document.FindListByName("Data Source 11");
            server.Document.ParseField(list.Field);
            list.BeginUpdate();            

            // Add a header to the Snap list.                                                                   
            SnapDocument listHeader = list.ListHeader;
            Table listHeaderTable = listHeader.Tables[0];
            TableCellCollection listHeaderCells = listHeaderTable.FirstRow.Cells;
            listHeader.InsertText(listHeaderCells.InsertAfter(2).ContentRange.End, "Quantity per Unit");
            
                        

            // Add data to the row template:
            SnapDocument listRow = list.RowTemplate;
            Table listRowTable = listRow.Tables[0];
            TableCellCollection listRowCells = listRowTable.FirstRow.Cells;          
            listRow.CreateSnText(listRowCells.InsertAfter(2).ContentRange.End, @"QuantityPerUnit");            
            list.EndUpdate();
            
            list.Field.Update();
            #endregion #InsertData
        }
        static void FormatData(SnapDocumentServer server)
        {
            #region #FormatData
            server.LoadDocumentTemplate("Template.snx");
            SnapList list = server.Document.FindListByName("Data Source 11");
            server.Document.ParseField(list.Field);
            list.BeginUpdate();
            list.EditorRowLimit = 100500;

            SnapDocument header = list.ListHeader;
            Table headerTable = header.Tables[0];
            headerTable.SetPreferredWidth(50 * 100, WidthType.FiftiethsOfPercent);

            foreach (TableRow row in headerTable.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    // Apply cell formatting.
                    cell.Borders.Left.LineColor = System.Drawing.Color.White;
                    cell.Borders.Right.LineColor = System.Drawing.Color.White;
                    cell.Borders.Top.LineColor = System.Drawing.Color.White;
                    cell.Borders.Bottom.LineColor = System.Drawing.Color.White;
                    cell.BackgroundColor = System.Drawing.Color.SteelBlue;

                    // Apply text formatting.
                    CharacterProperties formatting = header.BeginUpdateCharacters(cell.ContentRange);
                    formatting.Bold = true;
                    formatting.ForeColor = System.Drawing.Color.White;
                    header.EndUpdateCharacters(formatting);
                }
            }

            // Customize the row template.
            SnapDocument rowTemplate = list.RowTemplate;
            Table rowTable = rowTemplate.Tables[0];
            rowTable.SetPreferredWidth(50 * 100, WidthType.FiftiethsOfPercent);
            foreach (TableRow row in rowTable.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    cell.Borders.Left.LineColor = System.Drawing.Color.Transparent;
                    cell.Borders.Right.LineColor = System.Drawing.Color.Transparent;
                    cell.Borders.Top.LineColor = System.Drawing.Color.Transparent;
                    cell.Borders.Bottom.LineColor = System.Drawing.Color.LightGray;
                }
            }

            list.EndUpdate();
            list.Field.Update();

            #endregion #FormatData
        }

        static void FilterData(SnapDocumentServer server)
        {
            #region #FilterData
            // Delete the document's content.
            server.LoadDocument("Template.snx");

            SnapList list = server.Document.FindListByName("Data Source 11");
            server.Document.ParseField(list.Field);
            list.BeginUpdate();
            // Apply filtering:
            const string filter = "[Discontinued] = False";
            if (!list.Filters.Contains(filter))
            {
                list.Filters.Add(filter);
            }

            list.EndUpdate();
            list.Field.Update();


            #endregion #FilterData
        }

        static void SortList(SnapDocumentServer server)
        {
            #region #SortData
            server.LoadDocumentTemplate("Template.snx");            
            SnapList list = server.Document.FindListByName("Data Source 11");
            server.Document.ParseField(list.Field);
            list.BeginUpdate();
            list.Sorting.Add(new SnapListGroupParam("UnitPrice", ColumnSortOrder.Descending));
            list.EndUpdate();
            list.Field.Update();

            #endregion #SortData
        }
        static void GroupData(SnapDocumentServer server)
        {
            #region #GroupData

            server.LoadDocumentTemplate("Template.snx");            
            SnapList list = server.Document.FindListByName("Data Source 11");
            server.Document.ParseField(list.Field);
            list.BeginUpdate();
            list.EditorRowLimit = 100500;

            // Add a header to the Snap list.                                                                   
            SnapDocument listHeader = list.ListHeader;
            Table listHeaderTable = listHeader.Tables[0];
            

            SnapListGroupInfo group = list.Groups.CreateSnapListGroupInfo(
                new SnapListGroupParam("CategoryID", ColumnSortOrder.Ascending));
            list.Groups.Add(group);

            // Add a group header.
            SnapDocument groupHeader = group.CreateHeader();
            Table headerTable = groupHeader.Tables.Create(groupHeader.Range.End, 1, 1);
            headerTable.SetPreferredWidth(50 * 100, WidthType.FiftiethsOfPercent);
            TableCellCollection groupHeaderCells = headerTable.FirstRow.Cells;
            groupHeader.InsertText(groupHeaderCells[0].ContentRange.End, "Category ID: ");
            groupHeader.CreateSnText(groupHeaderCells[0].ContentRange.End, "CategoryID");

            // Customize the group header formatting.
            groupHeaderCells[0].BackgroundColor = System.Drawing.Color.LightGray;
            groupHeaderCells[0].Borders.Bottom.LineColor = System.Drawing.Color.White;
            groupHeaderCells[0].Borders.Left.LineColor = System.Drawing.Color.White;
            groupHeaderCells[0].Borders.Right.LineColor = System.Drawing.Color.White;
            groupHeaderCells[0].Borders.Top.LineColor = System.Drawing.Color.White;

            // Add a group footer.
            SnapDocument groupFooter = group.CreateFooter();
            Table footerTable = groupFooter.Tables.Create(groupFooter.Range.End, 1, 1);
            footerTable.SetPreferredWidth(50 * 100, WidthType.FiftiethsOfPercent);
            TableCellCollection groupFooterCells = footerTable.FirstRow.Cells;
            groupFooter.InsertText(groupFooterCells[0].ContentRange.End, "Count = ");
            groupFooter.CreateSnText(groupFooterCells[0].ContentRange.End,
                @"CategoryID \sr Group \sf Count");

            // Customize the group footer formatting.
            groupFooterCells[0].BackgroundColor = System.Drawing.Color.LightGray;
            groupFooterCells[0].Borders.Bottom.LineColor = System.Drawing.Color.White;
            groupFooterCells[0].Borders.Left.LineColor = System.Drawing.Color.White;
            groupFooterCells[0].Borders.Right.LineColor = System.Drawing.Color.White;
            groupFooterCells[0].Borders.Top.LineColor = System.Drawing.Color.White;

            list.EndUpdate();
            //list.Field.Update();

            #endregion #GroupData
        }
    }
}
