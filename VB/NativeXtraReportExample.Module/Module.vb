Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Linq
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Model.DomainLogics
Imports DevExpress.ExpressApp.Model.NodeGenerators

Namespace NativeXtraReportExample.Module
	' You can override various virtual methods and handle corresponding events to manage various aspects of your XAF application UI and behavior.
	Public NotInheritable Partial Class NativeXtraReportExampleModule ' http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppModuleBasetopic
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
			Dim updater As ModuleUpdater = New DatabaseUpdate.Updater(objectSpace, versionFromDB)
			Return New ModuleUpdater() { updater }
		End Function

		' Override the CustomizeTypesInfo method, to customize information on a particular class or property, before it is loaded to the Application Model. 
		'public override void CustomizeTypesInfo(ITypesInfo typesInfo) { // http://documentation.devexpress.com/Xaf/CustomDocument3224.aspx
		'    base.CustomizeTypesInfo(typesInfo);
		'    ITypeInfo theTypeInfo = typesInfo.FindTypeInfo(typeof(DomainObject1));
		'    if(theTypeInfo != null) {
		'        string memberName = "MyCustomMember";
		'        IMemberInfo theMemberInfo = theTypeInfo.FindMember(memberName);
		'        if(theMemberInfo == null) {
		'            theMemberInfo = theTypeInfo.CreateMember(memberName, typeof(string));
		'        }
		'        theTypeInfo.AddAttribute(new VisibleInDetailViewAttribute(false));
		'    }
		'}

		' You can define a fully custom Application Model element or extend an existing one (http://documentation.devexpress.com/#Xaf/CustomDocument3169)
		'public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders) {
		'    base.ExtendModelInterfaces(extenders);
		'    extenders.Add<IModelApplication, IModelMyModelExtension>();
		'}
	End Class

	' Declaration of a custom Application Model element extension to keep your custom settings (http://documentation.devexpress.com/#Xaf/CustomDocument2579).
	'public interface IModelMyModelExtension : IModelNode {
	'    string MyCustomProperty { get; set; }
	'}
End Namespace
