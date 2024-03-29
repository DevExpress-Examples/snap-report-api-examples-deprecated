Imports System
Imports System.CodeDom.Compiler
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Threading.Tasks

Namespace SnapServerExamples.CodeUtils

    Public MustInherit Class ExampleCodeEvaluator

        Protected MustOverride ReadOnly Property CodeStart As String

        Protected MustOverride ReadOnly Property CodeBeforeClasses As String

        Protected MustOverride ReadOnly Property CodeEnd As String

        Protected MustOverride Function GetCodeDomProvider() As CodeDomProvider

        Protected MustOverride Function GetModuleAssembly() As String

        Protected MustOverride Function GetExampleClassName() As String

        Public Function ExecuteCodeAndGenerateDocument(ByVal args As SnapServerExamples.CodeUtils.CodeEvaluationEventArgs) As Boolean
            Dim theCode As String = System.[String].Concat(Me.CodeStart, args.Code, Me.CodeBeforeClasses, args.CodeClasses, Me.CodeEnd)
            Dim linesOfCode As String() = New String() {theCode}
            Return Me.CompileAndRun(linesOfCode, args.EvaluationParameter)
        End Function

        Protected Friend Function CompileAndRun(ByVal linesOfCode As String(), ByVal evaluationParameter As Object) As Boolean
            Dim CompilerParams As System.CodeDom.Compiler.CompilerParameters = New System.CodeDom.Compiler.CompilerParameters()
            CompilerParams.GenerateInMemory = True
            CompilerParams.TreatWarningsAsErrors = False
            CompilerParams.GenerateExecutable = False
            Dim referencesSystem As String() = New String() {"System.dll", "System.Windows.Forms.dll", "System.Data.dll", "System.Xml.dll", "System.Core.dll", "System.Drawing.dll"}
            Dim referencesDX As String() = New String() {AssemblyInfo.SRAssemblyData, Me.GetModuleAssembly(), AssemblyInfo.SRAssemblyOfficeCore, AssemblyInfo.SRAssemblyPrintingCore, AssemblyInfo.SRAssemblyPrinting, AssemblyInfo.SRAssemblyDocs, AssemblyInfo.SRAssemblyUtils, AssemblyInfo.SRAssemblyRichEdit, AssemblyInfo.SRAssemblyRichEditCore, AssemblyInfo.SRAssemblySparklineCore}
            Dim references As String() = New String(referencesSystem.Length + referencesDX.Length - 1) {}
            For referenceIndex As Integer = 0 To referencesSystem.Length - 1
                references(referenceIndex) = referencesSystem(referenceIndex)
            Next

            Dim i As Integer = 0, initial As Integer = referencesSystem.Length
            While i < referencesDX.Length
                Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.Load(referencesDX(i) & AssemblyInfo.FullAssemblyVersionExtension)
                If assembly IsNot Nothing Then references(i + initial) = assembly.Location
                i += 1
            End While

            CompilerParams.ReferencedAssemblies.AddRange(references)
            Dim provider As System.CodeDom.Compiler.CodeDomProvider = Me.GetCodeDomProvider()
            Dim compile As System.CodeDom.Compiler.CompilerResults = provider.CompileAssemblyFromSource(CompilerParams, linesOfCode)
            If compile.Errors.HasErrors Then
                Dim text As String = "Compile error: "
                For Each ce As System.CodeDom.Compiler.CompilerError In compile.Errors
                    text += "rn" & ce.ToString()
                Next

                System.Windows.Forms.MessageBox.Show(text)
                Return False
            End If

            Dim [module] As System.Reflection.[Module] = Nothing
            Try
                [module] = compile.CompiledAssembly.GetModules()(0)
            Catch
            End Try

            Dim moduleType As System.Type = Nothing
            If [module] Is Nothing Then
                Return False
            End If

            moduleType = [module].[GetType](Me.GetExampleClassName())
            Dim methInfo As System.Reflection.MethodInfo = Nothing
            If moduleType Is Nothing Then
                Return False
            End If

            methInfo = moduleType.GetMethod("Process")
            If methInfo IsNot Nothing Then
                Try
                    methInfo.Invoke(Nothing, New Object() {evaluationParameter})
                Catch __unusedException1__ As System.Exception
                    Return False ' an error
                End Try

                Return True
            End If

            Return False
        End Function
    End Class

    Public MustInherit Class SnapExampleCodeEvaluator
        Inherits SnapServerExamples.CodeUtils.ExampleCodeEvaluator

        Protected Overrides Function GetModuleAssembly() As String
            Return AssemblyInfo.SRAssemblySnapCore
        End Function

        Protected Overrides Function GetExampleClassName() As String
            Return "SnapCodeResultViewer.ExampleItem"
        End Function
    End Class

#Region "RichEditCSExampleCodeEvaluator"
    Public Class SnapCSExampleCodeEvaluator
        Inherits SnapServerExamples.CodeUtils.SnapExampleCodeEvaluator

        Protected Overrides Function GetCodeDomProvider() As CodeDomProvider
            Return New Microsoft.CSharp.CSharpCodeProvider()
        End Function

        Const codeStartField As String = "using System;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.Data;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.XtraPrinting;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.XtraRichEdit;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.Portable;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.XtraRichEdit.API.Native;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.Snap;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.Snap.Core.API;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.Sparkline;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.Drawing;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.Windows.Forms;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.Utils;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.IO;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.Diagnostics;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.Xml;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.Data;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.Collections.Generic;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.Linq;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using System.Globalization;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using SnapDocument = DevExpress.Snap.Core.API.SnapDocument;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using SnapSparkline = DevExpress.Snap.Core.API.SnapSparkline;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using TableRow = DevExpress.XtraRichEdit.API.Native.TableRow;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "using SnapList=DevExpress.Snap.Core.API.SnapList;" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "namespace SnapCodeResultViewer { " & Global.Microsoft.VisualBasic.Constants.vbCrLf & "public class ExampleItem { " & Global.Microsoft.VisualBasic.Constants.vbCrLf & "        public static void Process(SnapDocumentServer server) { " & Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.Microsoft.VisualBasic.Constants.vbCrLf

        Const codeBeforeClassesField As String = "       " & Global.Microsoft.VisualBasic.Constants.vbCrLf & " }" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "    }" & Global.Microsoft.VisualBasic.Constants.vbCrLf

        Const codeEndField As String = Global.Microsoft.VisualBasic.Constants.vbCrLf & "    }" & Global.Microsoft.VisualBasic.Constants.vbCrLf

        Protected Overrides ReadOnly Property CodeStart As String
            Get
                Return SnapServerExamples.CodeUtils.SnapCSExampleCodeEvaluator.codeStartField
            End Get
        End Property

        Protected Overrides ReadOnly Property CodeBeforeClasses As String
            Get
                Return SnapServerExamples.CodeUtils.SnapCSExampleCodeEvaluator.codeBeforeClassesField
            End Get
        End Property

        Protected Overrides ReadOnly Property CodeEnd As String
            Get
                Return SnapServerExamples.CodeUtils.SnapCSExampleCodeEvaluator.codeEndField
            End Get
        End Property
    End Class

#End Region
#Region "RichEditVbExampleCodeEvaluator"
    Public Class SnapVbExampleCodeEvaluator
        Inherits SnapServerExamples.CodeUtils.SnapExampleCodeEvaluator

        Protected Overrides Function GetCodeDomProvider() As CodeDomProvider
            Return New Microsoft.VisualBasic.VBCodeProvider()
        End Function

        Const codeStartField As String = "Imports Microsoft.VisualBasic" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports DevExpress.Data" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports DevExpress.XtraRichEdit" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports DevExpress.XtraRichEdit.API.Native" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports DevExpress.Snap" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports DevExpress.Snap.Core.API" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports DevExpress.Sparkline" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Drawing" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Windows.Forms" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports DevExpress.Utils" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.IO" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Diagnostics" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Xml" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Data" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Collections.Generic" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Linq" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Globalization" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports SnapDocument = DevExpress.Snap.Core.API.SnapDocument" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports SnapSparkline = DevExpress.Snap.Core.API.SnapSparkline" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports TableRow = DevExpress.XtraRichEdit.API.Native.TableRow" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Imports SnapList = DevExpress.Snap.Core.API.SnapList" & "Namespace SnapCodeResultViewer" & Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.Microsoft.VisualBasic.Constants.vbTab & "Public Class ExampleItem" & Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.Microsoft.VisualBasic.Constants.vbTab & Global.Microsoft.VisualBasic.Constants.vbTab & "Public Shared Sub Process(ByVal server As SnapDocumentServer)" & Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.Microsoft.VisualBasic.Constants.vbCrLf

        Const codeBeforeClassesField As String = Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.Microsoft.VisualBasic.Constants.vbTab & Global.Microsoft.VisualBasic.Constants.vbTab & "End Sub" & Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.Microsoft.VisualBasic.Constants.vbTab & "End Class" & Global.Microsoft.VisualBasic.Constants.vbCrLf

        Const codeEndField As String = Global.Microsoft.VisualBasic.Constants.vbCrLf & "End Namespace" & Global.Microsoft.VisualBasic.Constants.vbCrLf

        Protected Overrides ReadOnly Property CodeStart As String
            Get
                Return SnapServerExamples.CodeUtils.SnapVbExampleCodeEvaluator.codeStartField
            End Get
        End Property

        Protected Overrides ReadOnly Property CodeBeforeClasses As String
            Get
                Return SnapServerExamples.CodeUtils.SnapVbExampleCodeEvaluator.codeBeforeClassesField
            End Get
        End Property

        Protected Overrides ReadOnly Property CodeEnd As String
            Get
                Return SnapServerExamples.CodeUtils.SnapVbExampleCodeEvaluator.codeEndField
            End Get
        End Property
    End Class

#End Region
    Public MustInherit Class ExampleEvaluatorByTimer
        Implements System.IDisposable

        Private leakSafeCompileEventRouter As SnapServerExamples.CodeUtils.LeakSafeCompileEventRouter

        Private compileExampleTimer As System.Windows.Forms.Timer

        Private compileComplete As Boolean = True

        Const CompileTimeIntervalInMilliseconds As Integer = 2000

        Public Sub New(ByVal enableTimer As Boolean)
            Me.leakSafeCompileEventRouter = New SnapServerExamples.CodeUtils.LeakSafeCompileEventRouter(Me)
            If enableTimer Then
                Me.compileExampleTimer = New System.Windows.Forms.Timer()
                Me.compileExampleTimer.Interval = SnapServerExamples.CodeUtils.ExampleEvaluatorByTimer.CompileTimeIntervalInMilliseconds
                AddHandler Me.compileExampleTimer.Tick, New System.EventHandler(AddressOf Me.leakSafeCompileEventRouter.OnCompileExampleTimerTick) 'OnCompileTimerTick
                Me.compileExampleTimer.Enabled = True
            End If
        End Sub

        Public Sub New()
            Me.New(True)
        End Sub

#Region "Events"
        Public Event QueryEvaluate As SnapServerExamples.CodeUtils.CodeEvaluationEventHandler

        Protected Friend Overridable Function RaiseQueryEvaluate() As CodeEvaluationEventArgs
            If QueryEvaluateEvent IsNot Nothing Then
                Dim args As SnapServerExamples.CodeUtils.CodeEvaluationEventArgs = New SnapServerExamples.CodeUtils.CodeEvaluationEventArgs()
                RaiseEvent QueryEvaluate(Me, args)
                Return args
            End If

            Return Nothing
        End Function

        Public Event OnBeforeCompile As System.EventHandler

        Private Sub RaiseOnBeforeCompile()
            RaiseEvent OnBeforeCompile(Me, New System.EventArgs())
        End Sub

        Public Event OnAfterCompile As SnapServerExamples.CodeUtils.OnAfterCompileEventHandler

        Private Sub RaiseOnAfterCompile(ByVal result As Boolean)
            RaiseEvent OnAfterCompile(Me, New SnapServerExamples.CodeUtils.OnAfterCompileEventArgs() With {.Result = result})
        End Sub

#End Region
        Public Sub CompileExample(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not Me.compileComplete Then Return
            Dim args As SnapServerExamples.CodeUtils.CodeEvaluationEventArgs = Me.RaiseQueryEvaluate()
            If Not args.Result Then Return
            Me.ForceCompile(args)
        End Sub

        Public Sub ForceCompile(ByVal args As SnapServerExamples.CodeUtils.CodeEvaluationEventArgs)
            Me.compileComplete = False
            If Not System.[String].IsNullOrEmpty(args.Code) Then Me.CompileExampleAndShowPrintPreview(args)
            Me.compileComplete = True
        End Sub

        Private Sub CompileExampleAndShowPrintPreview(ByVal args As SnapServerExamples.CodeUtils.CodeEvaluationEventArgs)
            Dim evaluationSucceed As Boolean = False
            Try
                Me.RaiseOnBeforeCompile()
                evaluationSucceed = Me.Evaluate(args)
            Finally
                Me.RaiseOnAfterCompile(evaluationSucceed)
            End Try
        End Sub

        Public Function Evaluate(ByVal args As SnapServerExamples.CodeUtils.CodeEvaluationEventArgs) As Boolean
            Dim snapExampleCodeEvaluator As SnapServerExamples.CodeUtils.ExampleCodeEvaluator = Me.GetExampleCodeEvaluator(args.Language)
            Return snapExampleCodeEvaluator.ExecuteCodeAndGenerateDocument(args)
        End Function

        Protected MustOverride Function GetExampleCodeEvaluator(ByVal language As SnapServerExamples.CodeUtils.ExampleLanguage) As ExampleCodeEvaluator

        Public Sub Dispose() Implements Global.System.IDisposable.Dispose
            If Me.compileExampleTimer IsNot Nothing Then
                Me.compileExampleTimer.Enabled = False
                If Me.leakSafeCompileEventRouter IsNot Nothing Then RemoveHandler Me.compileExampleTimer.Tick, New System.EventHandler(AddressOf Me.leakSafeCompileEventRouter.OnCompileExampleTimerTick) 'OnCompileTimerTick
                Me.compileExampleTimer.Dispose()
                Me.compileExampleTimer = Nothing
            End If
        End Sub
    End Class

#Region "RichEditExampleEvaluatorByTimer"
    Public Class RichEditExampleEvaluatorByTimer
        Inherits SnapServerExamples.CodeUtils.ExampleEvaluatorByTimer

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function GetExampleCodeEvaluator(ByVal language As SnapServerExamples.CodeUtils.ExampleLanguage) As ExampleCodeEvaluator
            If language = SnapServerExamples.CodeUtils.ExampleLanguage.VB Then Return New SnapServerExamples.CodeUtils.SnapVbExampleCodeEvaluator()
            Return New SnapServerExamples.CodeUtils.SnapCSExampleCodeEvaluator()
        End Function
    End Class

#End Region
#Region "LeakSafeCompileEventRouter"
    Public Class LeakSafeCompileEventRouter

        Private ReadOnly weakControlRef As System.WeakReference

        Public Sub New(ByVal [module] As SnapServerExamples.CodeUtils.ExampleEvaluatorByTimer)
            'Guard.ArgumentNotNull(module, "module");
            Me.weakControlRef = New System.WeakReference([module])
        End Sub

        Public Sub OnCompileExampleTimerTick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim [module] As SnapServerExamples.CodeUtils.ExampleEvaluatorByTimer = CType(Me.weakControlRef.Target, SnapServerExamples.CodeUtils.ExampleEvaluatorByTimer)
            If [module] IsNot Nothing Then [module].CompileExample(sender, e)
        End Sub
    End Class

    Public Class CodeEvaluationEventArgs
        Inherits System.EventArgs

        Public Property Result As Boolean

        Public Property Code As String

        Public Property CodeClasses As String

        Public Property Language As ExampleLanguage

        Public Property EvaluationParameter As Object
    End Class

    Public Delegate Sub CodeEvaluationEventHandler(ByVal sender As Object, ByVal e As SnapServerExamples.CodeUtils.CodeEvaluationEventArgs)

    Public Class OnAfterCompileEventArgs
        Inherits System.EventArgs

        Public Property Result As Boolean
    End Class

    Public Delegate Sub OnAfterCompileEventHandler(ByVal sender As Object, ByVal e As SnapServerExamples.CodeUtils.OnAfterCompileEventArgs)
#End Region
End Namespace
