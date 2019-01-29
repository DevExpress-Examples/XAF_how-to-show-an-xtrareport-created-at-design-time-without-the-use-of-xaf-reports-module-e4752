Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Security
Imports NativeXtraReportExample.Module.BusinessObjects

Namespace NativeXtraReportExample.Module.DatabaseUpdate
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub

		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			If ObjectSpace.GetObjectsCount(GetType(Task), Nothing) = 0 Then
				For i As Integer = 1 To 100
					Dim task = ObjectSpace.CreateObject(Of Task)()
					task.Subject = String.Format("Task #{0:000}", i)
					task.Deadline = DateTime.Today.AddDays(i - 30)
				Next i
			End If
		End Sub
	End Class
End Namespace
