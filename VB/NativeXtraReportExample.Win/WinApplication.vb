Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Win
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Updating
'using DevExpress.ExpressApp.Security;

Namespace NativeXtraReportExample.Win
	' You can override various virtual methods and handle corresponding events to manage various aspects of your XAF application UI and behavior.
	Partial Public Class NativeXtraReportExampleWindowsFormsApplication ' http://documentation.devexpress.com/#Xaf/DevExpressExpressAppWinWinApplicationMembersTopicAll
		Inherits WinApplication
		Public Sub New()
			InitializeComponent()
			DelayedViewItemsInitialization = True
		End Sub

		' Override to execute custom code after a logon has been performed, the SecuritySystem object is initialized, logon parameters have been saved and user model differences are loaded.
		Protected Overrides Sub OnLoggedOn(ByVal args As LogonEventArgs) ' http://documentation.devexpress.com/#Xaf/DevExpressExpressAppXafApplication_LoggedOntopic
			MyBase.OnLoggedOn(args)
		End Sub

		' Override to execute custom code after a user has logged off.
		Protected Overrides Sub OnLoggedOff() ' http://documentation.devexpress.com/#Xaf/DevExpressExpressAppXafApplication_LoggedOfftopic
			MyBase.OnLoggedOff()
		End Sub

		Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
			args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection)
		End Sub
		Private Sub NativeXtraReportExampleWindowsFormsApplication_CustomizeLanguagesList(ByVal sender As Object, ByVal e As CustomizeLanguagesListEventArgs) Handles MyBase.CustomizeLanguagesList
			Dim userLanguageName As String = System.Threading.Thread.CurrentThread.CurrentUICulture.Name
			If userLanguageName <> "en-US" AndAlso e.Languages.IndexOf(userLanguageName) = -1 Then
				e.Languages.Add(userLanguageName)
			End If
		End Sub
		Private Sub NativeXtraReportExampleWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
			e.Updater.Update()
			e.Handled = True
		End Sub
	End Class
End Namespace
