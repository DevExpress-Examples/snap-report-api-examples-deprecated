Imports DevExpress.XtraTab
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Snap
Imports DevExpress.Snap.Core.API
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList
Imports SnapServerExamples.CodeUtils
Imports System.IO

Namespace SnapServerExamples

    Public Partial Class Form1
        Inherits Form

        Private codeEditor As ExampleCodeEditor

        Private evaluator As ExampleEvaluatorByTimer

        Private examples As List(Of CodeExampleGroup)

        Private treeListRootNodeLoading As Boolean = True

        Private server As SnapDocumentServer = New SnapDocumentServer()

        Public Sub New()
            InitializeComponent()
            Dim examplePath As String = GetExamplePath("CodeExamples")
            Dim examplesCS As Dictionary(Of String, FileInfo) = GatherExamplesFromProject(examplePath, ExampleLanguage.Csharp)
            Dim examplesVB As Dictionary(Of String, FileInfo) = GatherExamplesFromProject(examplePath, ExampleLanguage.VB)
            DisableTabs(examplesCS.Count, examplesVB.Count)
            examples = FindExamples(examplePath, examplesCS, examplesVB)
            ShowExamplesInTreeList(treeList1, examples)
            codeEditor = New ExampleCodeEditor(richEditControlCS, richEditControlVB)
            CurrentExampleLanguage = DetectExampleLanguage("SnapServerExamples")
            evaluator = New RichEditExampleEvaluatorByTimer()
            AddHandler simpleButton1.Click, AddressOf SimpleButton1_Click
            AddHandler evaluator.QueryEvaluate, AddressOf OnExampleEvaluatorQueryEvaluate
            AddHandler evaluator.OnBeforeCompile, AddressOf evaluator_OnBeforeCompile
            AddHandler evaluator.OnAfterCompile, AddressOf evaluator_OnAfterCompile
            AddHandler xtraTabControl1.SelectedPageChanged, AddressOf xtraTabControl1_SelectedPageChanged
            ShowFirstExample()
            treeList1.ExpandAll()
        End Sub

        Private Sub SimpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            server.Document.SaveDocument("Result.snx")
            Dim newUC As ResultForm = New ResultForm() With {.Dock = DockStyle.Fill}
            Dim newForm As Form = New Form() With {.Size = New Size(800, 600)}
            newForm.Controls.Add(newUC)
            newForm.ShowDialog()
        End Sub

        Private Property CurrentExampleLanguage As ExampleLanguage
            Get
                If Equals(xtraTabControl1.SelectedTabPage.Tag.ToString(), "CS") Then
                    Return ExampleLanguage.Csharp
                Else
                    Return ExampleLanguage.VB
                End If
            End Get

            Set(ByVal value As ExampleLanguage)
                codeEditor.CurrentExampleLanguage = value
            'xtraTabControl1.SelectedTabPageIndex = (value == ExampleLanguage.Csharp) ? 0 : 1;
            End Set
        End Property

        Private Sub ShowExamplesInTreeList(ByVal treeList As TreeList, ByVal examples As List(Of CodeExampleGroup))
#Region "InitializeTreeList"
            treeList.OptionsPrint.UsePrintStyles = True
            AddHandler treeList.FocusedNodeChanged, New FocusedNodeChangedEventHandler(AddressOf OnNewExampleSelected)
            treeList.OptionsView.ShowColumns = False
            treeList.OptionsView.ShowIndicator = False
            AddHandler treeList.VirtualTreeGetChildNodes, AddressOf treeList_VirtualTreeGetChildNodes
            AddHandler treeList.VirtualTreeGetCellValue, AddressOf treeList_VirtualTreeGetCellValue
#End Region
            Dim col1 As TreeListColumn = New TreeListColumn()
            col1.VisibleIndex = 0
            col1.OptionsColumn.AllowEdit = False
            col1.OptionsColumn.AllowMove = False
            col1.OptionsColumn.ReadOnly = True
            treeList.Columns.AddRange(New TreeListColumn() {col1})
            treeList.DataSource = New [Object]()
            treeList.ExpandAll()
        End Sub

        Private Sub treeList_VirtualTreeGetCellValue(ByVal sender As Object, ByVal args As VirtualTreeGetCellValueInfo)
            Dim group As CodeExampleGroup = TryCast(args.Node, CodeExampleGroup)
            If group IsNot Nothing Then args.CellData = group.Name
            Dim example As CodeExample = TryCast(args.Node, CodeExample)
            If example IsNot Nothing Then args.CellData = example.RegionName
        End Sub

        Private Sub treeList_VirtualTreeGetChildNodes(ByVal sender As Object, ByVal args As VirtualTreeGetChildNodesInfo)
            If treeListRootNodeLoading Then
                args.Children = examples
                treeListRootNodeLoading = False
            Else
                If args.Node Is Nothing Then Return
                Dim group As CodeExampleGroup = TryCast(args.Node, CodeExampleGroup)
                If group IsNot Nothing Then args.Children = group.Examples
            End If
        End Sub

        Private Sub ShowFirstExample()
            treeList1.ExpandAll()
            If treeList1.Nodes.Count > 0 Then treeList1.FocusedNode = treeList1.MoveFirst().FirstNode
        End Sub

        Private Sub evaluator_OnAfterCompile(ByVal sender As Object, ByVal args As OnAfterCompileEventArgs)
            codeEditor.AfterCompile(args.Result)
        End Sub

        Private Sub evaluator_OnBeforeCompile(ByVal sender As Object, ByVal e As EventArgs)
            server.CreateNewDocument()
            Dim document As SnapDocument = server.Document
            document.BeginUpdate()
            codeEditor.BeforeCompile()
            document.Unit = DevExpress.Office.DocumentUnit.Document
        End Sub

        Private Sub OnNewExampleSelected(ByVal sender As Object, ByVal e As FocusedNodeChangedEventArgs)
            Dim newExample As CodeExample = TryCast(TryCast(sender, TreeList).GetDataRecordByNode(e.Node), CodeExample)
            Dim oldExample As CodeExample = TryCast(TryCast(sender, TreeList).GetDataRecordByNode(e.OldNode), CodeExample)
            If newExample Is Nothing Then Return
            Dim exampleCode As String = codeEditor.ShowExample(oldExample, newExample)
            Dim args As CodeEvaluationEventArgs = New CodeEvaluationEventArgs()
            InitializeCodeEvaluationEventArgs(args)
        'evaluator.ForceCompile(args);
        End Sub

        Private Sub InitializeCodeEvaluationEventArgs(ByVal e As CodeEvaluationEventArgs)
            e.Result = True
            e.Code = codeEditor.CurrentCodeEditor.Text
            e.Language = CurrentExampleLanguage
            e.EvaluationParameter = server
        End Sub

        Private Sub OnExampleEvaluatorQueryEvaluate(ByVal sender As Object, ByVal e As CodeEvaluationEventArgs)
            e.Result = False
            If codeEditor.RichEditTextChanged Then ' && compileComplete) {
                Dim span As TimeSpan = Date.Now - codeEditor.LastExampleCodeModifiedTime
                If span < TimeSpan.FromMilliseconds(1000) Then 'CompileTimeIntervalInMilliseconds  1900
                    codeEditor.ResetLastExampleModifiedTime()
                    Return
                End If

                'e.Result = true;
                InitializeCodeEvaluationEventArgs(e)
            End If
        End Sub

        Private Sub DisableTabs(ByVal examplesCSCount As Integer, ByVal examplesVBCount As Integer)
            If examplesCSCount = 0 Then
                For Each t As XtraTabPage In xtraTabControl1.TabPages
                    If Equals(t.Tag.ToString(), "CS") Then t.PageEnabled = False
                Next
            End If

            If examplesVBCount = 0 Then
                For Each t As XtraTabPage In xtraTabControl1.TabPages
                    If Equals(t.Tag.ToString(), "VB") Then t.PageEnabled = False
                Next
            End If
        End Sub

        Private Sub xtraTabControl1_SelectedPageChanged(ByVal sender As Object, ByVal e As TabPageChangedEventArgs)
            CurrentExampleLanguage = If((Equals(e.Page.Tag.ToString(), "CS")), ExampleLanguage.Csharp, ExampleLanguage.VB)
        End Sub
    End Class
End Namespace
