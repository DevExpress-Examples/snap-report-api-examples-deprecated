using DevExpress.Snap;
using DevExpress.Snap.Core.API;
using DevExpress.Sparkline;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Portable;

namespace SnapServerExamples.CodeExamples
{
    class DataVisualizationToolsActions
    {
        static void CreateParameter(SnapDocumentServer server)
        {
            #region #CreateParameter
            server.LoadDocumentTemplate("Template.snx");
            server.Document.BeginUpdate();
            //Create parameter:
            Parameter param1 = new Parameter();
            param1.Name = "Region";
            param1.Type = typeof(System.String);
            param1.Value = "NEW ENGLAND";
            server.Document.Parameters.Add(param1);
            //Insert parameter field in the document:
            SnapList list = server.Document.FindListByName("Data Source 11");
            server.Document.ParseField(list.Field);
            list.BeginUpdate();
            list.ListHeader.InsertText(list.ListHeader.Tables[0].FirstRow.Cells.InsertAfter(3).ContentRange.End, "Region");
            list.RowTemplate.CreateSnText(list.RowTemplate.Tables[0].FirstRow.Cells.InsertAfter(3).ContentRange.End, @"Region \p");
            list.Field.Update();
            list.EndUpdate();
            server.Document.EndUpdate();
            server.Document.Fields.Update();
            #endregion #CreateParameter
        }

        static void CreateSparkline(SnapDocumentServer server)
        {
            #region #CreateSparkline
            server.LoadDocumentTemplate("Template.snx");
            server.Document.BeginUpdate();
            SnapSparkline sparkline = server.Document.CreateSnSparkline(server.Document.Range.End, "UnitsInStock");
            server.Document.ParseField(sparkline.Field);
            sparkline.BeginUpdate();
            sparkline.DataSourceName = "/Data Source 1.Products";
            sparkline.ViewType = SparklineViewType.Line;
            sparkline.Color = System.Drawing.Color.Teal;
            sparkline.EndUpdate();
            sparkline.Field.Update();
            #endregion #CreateSparkline
        }
        static void CreateCheckBox(SnapDocumentServer server)
        {
            #region #CreateCheckBox      
            server.LoadDocumentTemplate("Template.snx");
            server.Document.BeginUpdate();
            SnapCheckBox checkbox = server.Document.CreateSnCheckBox(server.Document.Range.Start, "Discontinued");
            server.Document.ParseField(checkbox.Field);
            checkbox.BeginUpdate();
            checkbox.State = PortableCheckState.Checked;
            checkbox.EndUpdate();
            checkbox.Field.Update();
            #endregion #CreateCheckBox
        }
        static void CreateBarCode(SnapDocumentServer server)
        {
            #region #CreateBarcode
            server.LoadDocumentTemplate("Template.snx");
            server.Document.BeginUpdate();
            SnapBarCode barcode = server.Document.CreateSnBarCode(server.Document.Range.Start);
            server.Document.ParseField(barcode.Field);
            barcode.BeginUpdate();
            barcode.DataFieldName = "EAN13";
            barcode.Module = 10;            
            barcode.Orientation = DevExpress.XtraPrinting.BarCode.BarCodeOrientation.Normal;
            barcode.AutoModule = true;
            barcode.ShowData = false;
            barcode.EndUpdate();
            barcode.Field.Update();
            #endregion #CreateBarcode
        }
        static void CreateCalculatedField(SnapDocumentServer server)
        {
            #region #CreateCalculatedField
            server.LoadDocumentTemplate("Template.snx");
            server.Document.BeginUpdate();
            CalculatedField field = new CalculatedField("newField", "Products");
            field.FieldType = DevExpress.XtraReports.UI.FieldType.Int32;
            field.Expression = "[UnitsInStock]*[UnitPrice]";
            field.DataSourceName = "Data Source 1";
            server.Document.CalculatedFields.Add(field);
            server.Document.EndUpdate();
            server.Document.Fields.Update();
            #endregion #CreateCalculatedField
        }
    }
}
