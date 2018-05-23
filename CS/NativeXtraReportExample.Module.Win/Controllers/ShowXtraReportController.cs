using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp;
using NativeXtraReportExample.Module.BusinessObjects;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.XtraReports.UI;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Templates;

namespace NativeXtraReportExample.Module.Win.Controllers {
    public class ShowXtraReportController : ObjectViewController<ListView, Task> {
        public ShowXtraReportController() {
            var showReportAction = new SimpleAction(this, "ShowReport", PredefinedCategory.View);
            showReportAction.ImageName = "BO_Report";
            showReportAction.PaintStyle = ActionItemPaintStyle.CaptionAndImage;
            showReportAction.Execute += new SimpleActionExecuteEventHandler(showReportAction_Execute);
            var showReportWithParametersAction = new PopupWindowShowAction(this, "ShowReportWithParameters", PredefinedCategory.View);
            showReportWithParametersAction.ImageName = "BO_Report";
            showReportWithParametersAction.PaintStyle = ActionItemPaintStyle.CaptionAndImage;
            showReportWithParametersAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(showReportWithParameters_CustomizePopupWindowParams);
            showReportWithParametersAction.Execute += new PopupWindowShowActionExecuteEventHandler(showReportWithParameters_Execute);
        }
        void showReportAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            TaskReport report = new TaskReport();
            report.DataSource = View.CollectionSource.Collection;
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }
        void showReportWithParameters_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
            e.DialogController.CanCloseWindow = false;
            e.DialogController.AcceptAction.Caption = "Preview";
            var objectSpace = Application.CreateObjectSpace();
            var parameters = new ReportParameters() { DeadlineBefore = DateTime.Now };
            e.View = Application.CreateDetailView(objectSpace, parameters);
        }
        void showReportWithParameters_Execute(object sender, PopupWindowShowActionExecuteEventArgs e) {
            var parameters = e.PopupWindow.View.CurrentObject as ReportParameters;
            CriteriaOperator criteria = new BinaryOperator("Deadline", parameters.DeadlineBefore, BinaryOperatorType.Less);
            if (!string.IsNullOrEmpty(parameters.SubjectContains)) {
                criteria = GroupOperator.Combine(GroupOperatorType.And, criteria,
                    CriteriaOperator.Parse("Contains([Subject], ?)", parameters.SubjectContains));
            }
            var dataSource = Application.CreateObjectSpace().CreateCollection(typeof(Task), criteria);
            var report = new TaskReport();
            report.DataSource = dataSource;
            report.ShowPreview();
        }
    }
    [DomainComponent]
    public class ReportParameters {
        public string SubjectContains { get; set; }
        public DateTime DeadlineBefore { get; set; }
    }
}