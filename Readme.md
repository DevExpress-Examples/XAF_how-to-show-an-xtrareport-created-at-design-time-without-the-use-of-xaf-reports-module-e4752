<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134575664/12.2.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4752)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[ShowXtraReportController.cs](./CS/NativeXtraReportExample.Module.Win/Controllers/ShowXtraReportController.cs) (VB: [ShowXtraReportController.vb](./VB/NativeXtraReportExample.Module.Win/Controllers/ShowXtraReportController.vb))**
<!-- default file list end -->
# How to: Show an XtraReport created at design time, without the use of XAF Reports module


<p><strong>NOTE:</strong> Starting with version 13.2, XAF provides the capability to display reports created at design time out-of-the-box. Please refer to the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3592"><u>Reports V2 Module</u></a> topic for additional information.</p><p>This example demonstrates how to create reports in Visual Studio at design time without using our report modules (see <a href="http://documentation.devexpress.com/#xtrareports/CustomDocument9820"><u>WinForms Reports Lessons</u></a>) and show them via XAF actions.</p><p><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-show-an-xtrareport-created-at-design-time-without-the-use-of-xaf-reports-module-e4752/12.2.8+/media/f5e4a4a1-0a66-4380-a7ea-2cbaa4bdeeff.png"></p><p>Take special note of the implementation of the ShowReportWithParameters action. It uses a custom ReportParameters object to filter the report data source. You can use this approach instead of standard XtraReport parameters to display a complex parameters object in the XAF Detail View and get benefits of XAF features (validation, conditional appearance, customizable layout, etc.).</p>

<br/>


