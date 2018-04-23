Namespace SnapServerExamples
    Partial Public Class ResultForm
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.nWindDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ResultSnapControl2 = New DevExpress.Snap.SnapControl()
            Me.snapDockManager1 = New DevExpress.Snap.Extensions.SnapDockManager(Me.components)
            Me.panelContainer1 = New DevExpress.XtraBars.Docking.DockPanel()
            Me.fieldListDockPanel1 = New DevExpress.Snap.Extensions.UI.FieldListDockPanel()
            Me.fieldListDockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
            Me.reportExplorerDockPanel1 = New DevExpress.Snap.Extensions.UI.ReportExplorerDockPanel()
            Me.reportExplorerDockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
            Me.snapDocumentManager1 = New DevExpress.Snap.Extensions.SnapDocumentManager(Me.components)
            Me.noDocumentsView1 = New DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(Me.components)
            DirectCast(Me.nWindDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.snapDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelContainer1.SuspendLayout()
            Me.fieldListDockPanel1.SuspendLayout()
            Me.reportExplorerDockPanel1.SuspendLayout()
            DirectCast(Me.snapDocumentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.noDocumentsView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' ResultSnapControl2
            ' 
            Me.ResultSnapControl2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ResultSnapControl2.Location = New System.Drawing.Point(0, 0)
            Me.ResultSnapControl2.Name = "ResultSnapControl2"
            Me.ResultSnapControl2.Options.SnapMailMergeVisualOptions.DataSourceName = Nothing
            Me.ResultSnapControl2.Size = New System.Drawing.Size(369, 523)
            Me.ResultSnapControl2.TabIndex = 0
            Me.ResultSnapControl2.Text = "snapControl1"
            ' 
            ' snapDockManager1
            ' 
            Me.snapDockManager1.Form = Me
            Me.snapDockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() { Me.panelContainer1})
            Me.snapDockManager1.SnapControl = Me.ResultSnapControl2
            Me.snapDockManager1.TopZIndexControls.AddRange(New String() { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
            ' 
            ' panelContainer1
            ' 
            Me.panelContainer1.Controls.Add(Me.fieldListDockPanel1)
            Me.panelContainer1.Controls.Add(Me.reportExplorerDockPanel1)
            Me.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right
            Me.panelContainer1.ID = New System.Guid("ab35bcfc-7907-4ea2-bdb2-e45e709532c4")
            Me.panelContainer1.Location = New System.Drawing.Point(369, 0)
            Me.panelContainer1.Name = "panelContainer1"
            Me.panelContainer1.OriginalSize = New System.Drawing.Size(200, 200)
            Me.panelContainer1.Size = New System.Drawing.Size(200, 523)
            Me.panelContainer1.Text = "panelContainer1"
            ' 
            ' fieldListDockPanel1
            ' 
            Me.fieldListDockPanel1.Controls.Add(Me.fieldListDockPanel1_Container)
            Me.fieldListDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill
            Me.fieldListDockPanel1.ID = New System.Guid("ac1c829b-1201-4c2e-835e-e5de00965168")
            Me.fieldListDockPanel1.Location = New System.Drawing.Point(0, 0)
            Me.fieldListDockPanel1.Name = "fieldListDockPanel1"
            Me.fieldListDockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
            Me.fieldListDockPanel1.Size = New System.Drawing.Size(200, 262)
            Me.fieldListDockPanel1.SnapControl = Me.ResultSnapControl2
            ' 
            ' fieldListDockPanel1_Container
            ' 
            Me.fieldListDockPanel1_Container.Location = New System.Drawing.Point(5, 38)
            Me.fieldListDockPanel1_Container.Name = "fieldListDockPanel1_Container"
            Me.fieldListDockPanel1_Container.Size = New System.Drawing.Size(191, 219)
            Me.fieldListDockPanel1_Container.TabIndex = 0
            ' 
            ' reportExplorerDockPanel1
            ' 
            Me.reportExplorerDockPanel1.Controls.Add(Me.reportExplorerDockPanel1_Container)
            Me.reportExplorerDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill
            Me.reportExplorerDockPanel1.ID = New System.Guid("7eac3aac-12aa-4520-8ebb-e8791a2fd613")
            Me.reportExplorerDockPanel1.Location = New System.Drawing.Point(0, 262)
            Me.reportExplorerDockPanel1.Name = "reportExplorerDockPanel1"
            Me.reportExplorerDockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
            Me.reportExplorerDockPanel1.Size = New System.Drawing.Size(200, 261)
            Me.reportExplorerDockPanel1.SnapControl = Me.ResultSnapControl2
            ' 
            ' reportExplorerDockPanel1_Container
            ' 
            Me.reportExplorerDockPanel1_Container.Location = New System.Drawing.Point(5, 38)
            Me.reportExplorerDockPanel1_Container.Name = "reportExplorerDockPanel1_Container"
            Me.reportExplorerDockPanel1_Container.Size = New System.Drawing.Size(191, 219)
            Me.reportExplorerDockPanel1_Container.TabIndex = 0
            ' 
            ' snapDocumentManager1
            ' 
            Me.snapDocumentManager1.ClientControl = Me.ResultSnapControl2
            Me.snapDocumentManager1.View = Me.noDocumentsView1
            Me.snapDocumentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() { Me.noDocumentsView1})
            ' 
            ' ResultForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.ResultSnapControl2)
            Me.Controls.Add(Me.panelContainer1)
            Me.Name = "ResultForm"
            Me.Size = New System.Drawing.Size(569, 523)
            DirectCast(Me.nWindDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.snapDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelContainer1.ResumeLayout(False)
            Me.fieldListDockPanel1.ResumeLayout(False)
            Me.reportExplorerDockPanel1.ResumeLayout(False)
            DirectCast(Me.snapDocumentManager1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.noDocumentsView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private ResultSnapControl2 As DevExpress.Snap.SnapControl
        Private snapDockManager1 As DevExpress.Snap.Extensions.SnapDockManager
        Private panelContainer1 As DevExpress.XtraBars.Docking.DockPanel
        Private fieldListDockPanel1 As DevExpress.Snap.Extensions.UI.FieldListDockPanel
        Private fieldListDockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
        Private reportExplorerDockPanel1 As DevExpress.Snap.Extensions.UI.ReportExplorerDockPanel
        Private reportExplorerDockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
        Private snapDocumentManager1 As DevExpress.Snap.Extensions.SnapDocumentManager
        Private noDocumentsView1 As DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView

        Private nWindDataSetBindingSource As System.Windows.Forms.BindingSource
    End Class
End Namespace
