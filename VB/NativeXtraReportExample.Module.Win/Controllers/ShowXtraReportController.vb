Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.ExpressApp
Imports NativeXtraReportExample.Module.BusinessObjects
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.XtraReports.UI
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Templates

Namespace NativeXtraReportExample.Module.Win.Controllers
    Public Class ShowXtraReportController
        Inherits ObjectViewController(Of ListView, Task)

        Public Sub New()
            Dim showReportAction = New SimpleAction(Me, "ShowReport", PredefinedCategory.View)
            showReportAction.ImageName = "BO_Report"
            showReportAction.PaintStyle = ActionItemPaintStyle.CaptionAndImage
            AddHandler showReportAction.Execute, AddressOf showReportAction_Execute
            Dim showReportWithParametersAction = New PopupWindowShowAction(Me, "ShowReportWithParameters", PredefinedCategory.View)
            showReportWithParametersAction.ImageName = "BO_Report"
            showReportWithParametersAction.PaintStyle = ActionItemPaintStyle.CaptionAndImage
            AddHandler showReportWithParametersAction.CustomizePopupWindowParams, AddressOf showReportWithParameters_CustomizePopupWindowParams
            AddHandler showReportWithParametersAction.Execute, AddressOf showReportWithParameters_Execute
        End Sub
        Private Sub showReportAction_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
            Dim report As New TaskReport()
            report.DataSource = View.CollectionSource.Collection
            Dim tool As New ReportPrintTool(report)
            tool.ShowPreview()
        End Sub
        Private Sub showReportWithParameters_CustomizePopupWindowParams(ByVal sender As Object, ByVal e As CustomizePopupWindowParamsEventArgs)
            e.DialogController.CanCloseWindow = False
            e.DialogController.AcceptAction.Caption = "Preview"
            Dim objectSpace = Application.CreateObjectSpace()
            Dim parameters = New ReportParameters() With {.DeadlineBefore = Date.Now}
            e.View = Application.CreateDetailView(objectSpace, parameters)
        End Sub
        Private Sub showReportWithParameters_Execute(ByVal sender As Object, ByVal e As PopupWindowShowActionExecuteEventArgs)
            Dim parameters = TryCast(e.PopupWindow.View.CurrentObject, ReportParameters)
            Dim criteria As CriteriaOperator = New BinaryOperator("Deadline", parameters.DeadlineBefore, BinaryOperatorType.Less)
            If Not String.IsNullOrEmpty(parameters.SubjectContains) Then
                criteria = GroupOperator.Combine(GroupOperatorType.And, criteria, CriteriaOperator.Parse("Contains([Subject], ?)", parameters.SubjectContains))
            End If
            Dim dataSource = Application.CreateObjectSpace().CreateCollection(GetType(Task), criteria)
            Dim report = New TaskReport()
            report.DataSource = dataSource
            report.ShowPreview()
        End Sub
    End Class
    <DomainComponent> _
    Public Class ReportParameters
        Public Property SubjectContains() As String
        Public Property DeadlineBefore() As Date
    End Class
End Namespace