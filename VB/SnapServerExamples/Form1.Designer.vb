Namespace SnapServerExamples

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SnapServerExamples.Form1))
            Me.splitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
            Me.splitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.xtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
            Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlCS = New DevExpress.XtraRichEdit.RichEditControl()
            Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlVB = New DevExpress.XtraRichEdit.RichEditControl()
            Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
            Me.snapDockManager1 = New DevExpress.Snap.Extensions.SnapDockManager(Me.components)
            CType((Me.splitContainerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerControl1.SuspendLayout()
            CType((Me.treeList1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.splitContainerControl2), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerControl2.SuspendLayout()
            CType((Me.xtraTabControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.xtraTabControl1.SuspendLayout()
            Me.xtraTabPage1.SuspendLayout()
            Me.xtraTabPage2.SuspendLayout()
            CType((Me.snapDockManager1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' splitContainerControl1
            ' 
            Me.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerControl1.Location = New System.Drawing.Point(0, 0)
            Me.splitContainerControl1.Name = "splitContainerControl1"
            Me.splitContainerControl1.Panel1.Controls.Add(Me.treeList1)
            Me.splitContainerControl1.Panel1.Text = "Panel1"
            Me.splitContainerControl1.Panel2.Controls.Add(Me.splitContainerControl2)
            Me.splitContainerControl1.Panel2.Text = "Panel2"
            Me.splitContainerControl1.Size = New System.Drawing.Size(1142, 673)
            Me.splitContainerControl1.SplitterPosition = 253
            Me.splitContainerControl1.TabIndex = 0
            Me.splitContainerControl1.Text = "splitContainerControl1"
            ' 
            ' treeList1
            ' 
            Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.treeList1.Location = New System.Drawing.Point(0, 0)
            Me.treeList1.Name = "treeList1"
            Me.treeList1.Size = New System.Drawing.Size(253, 673)
            Me.treeList1.TabIndex = 0
            ' 
            ' splitContainerControl2
            ' 
            Me.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerControl2.Horizontal = False
            Me.splitContainerControl2.Location = New System.Drawing.Point(0, 0)
            Me.splitContainerControl2.Name = "splitContainerControl2"
            Me.splitContainerControl2.Panel1.Controls.Add(Me.xtraTabControl1)
            Me.splitContainerControl2.Panel1.Text = "Panel1"
            Me.splitContainerControl2.Panel2.Controls.Add(Me.simpleButton1)
            Me.splitContainerControl2.Panel2.Text = "Panel2"
            Me.splitContainerControl2.Size = New System.Drawing.Size(884, 673)
            Me.splitContainerControl2.SplitterPosition = 547
            Me.splitContainerControl2.TabIndex = 0
            Me.splitContainerControl2.Text = "splitContainerControl2"
            ' 
            ' xtraTabControl1
            ' 
            Me.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.xtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
            Me.xtraTabControl1.Location = New System.Drawing.Point(0, 0)
            Me.xtraTabControl1.Name = "xtraTabControl1"
            Me.xtraTabControl1.SelectedTabPage = Me.xtraTabPage1
            Me.xtraTabControl1.Size = New System.Drawing.Size(884, 547)
            Me.xtraTabControl1.TabIndex = 0
            Me.xtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtraTabPage1, Me.xtraTabPage2})
            ' 
            ' xtraTabPage1
            ' 
            Me.xtraTabPage1.Controls.Add(Me.richEditControlCS)
            Me.xtraTabPage1.Name = "xtraTabPage1"
            Me.xtraTabPage1.Size = New System.Drawing.Size(878, 519)
            Me.xtraTabPage1.Tag = "CS"
            Me.xtraTabPage1.Text = "CS"
            ' 
            ' richEditControlCS
            ' 
            Me.richEditControlCS.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
            Me.richEditControlCS.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlCS.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlCS.Name = "richEditControlCS"
            Me.richEditControlCS.Size = New System.Drawing.Size(878, 519)
            Me.richEditControlCS.TabIndex = 0
            ' 
            ' xtraTabPage2
            ' 
            Me.xtraTabPage2.Controls.Add(Me.richEditControlVB)
            Me.xtraTabPage2.Name = "xtraTabPage2"
            Me.xtraTabPage2.Size = New System.Drawing.Size(878, 519)
            Me.xtraTabPage2.Tag = "VB"
            Me.xtraTabPage2.Text = "VB"
            ' 
            ' richEditControlVB
            ' 
            Me.richEditControlVB.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
            Me.richEditControlVB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlVB.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlVB.Name = "richEditControlVB"
            Me.richEditControlVB.Size = New System.Drawing.Size(878, 519)
            Me.richEditControlVB.TabIndex = 0
            ' 
            ' simpleButton1
            ' 
            Me.simpleButton1.Image = CType((resources.GetObject("simpleButton1.Image")), System.Drawing.Image)
            Me.simpleButton1.Location = New System.Drawing.Point(1, 10)
            Me.simpleButton1.Name = "simpleButton1"
            Me.simpleButton1.Size = New System.Drawing.Size(191, 41)
            Me.simpleButton1.TabIndex = 0
            Me.simpleButton1.Text = "Generate Report"
            ' 
            ' snapDockManager1
            ' 
            Me.snapDockManager1.Form = Me
            Me.snapDockManager1.SnapControl = Nothing
            Me.snapDockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1142, 673)
            Me.Controls.Add(Me.splitContainerControl1)
            Me.Name = "Form1"
            Me.Text = "Snap Document Server Examples"
            CType((Me.splitContainerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerControl1.ResumeLayout(False)
            CType((Me.treeList1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.splitContainerControl2), System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerControl2.ResumeLayout(False)
            CType((Me.xtraTabControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.xtraTabControl1.ResumeLayout(False)
            Me.xtraTabPage1.ResumeLayout(False)
            Me.xtraTabPage2.ResumeLayout(False)
            CType((Me.snapDockManager1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private splitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl

        Private treeList1 As DevExpress.XtraTreeList.TreeList

        Private splitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl

        Private xtraTabControl1 As DevExpress.XtraTab.XtraTabControl

        Private xtraTabPage1 As DevExpress.XtraTab.XtraTabPage

        Private richEditControlCS As DevExpress.XtraRichEdit.RichEditControl

        Private xtraTabPage2 As DevExpress.XtraTab.XtraTabPage

        Private richEditControlVB As DevExpress.XtraRichEdit.RichEditControl

        Private snapDockManager1 As DevExpress.Snap.Extensions.SnapDockManager

        Private simpleButton1 As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace
