'===============================================================================
' Microsoft patterns & practices
' CompositeUI Application Block
'===============================================================================
' Copyright � Microsoft Corporation.  All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Practices.CompositeUI
Imports Microsoft.Practices.CompositeUI.WinForms

Namespace ModuleLoaderQuickStart
	Friend Class ModuleLoaderApplication
		Inherits FormShellApplication(Of WorkItem, MainForm)

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread()> _
		Public Shared Sub Main()
			Dim app As ModuleLoaderApplication = New ModuleLoaderApplication()
			app.Run()
		End Sub

#Region "Unhandled Exception"

		Public Overrides Sub OnUnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
			Dim ex As Exception = TryCast(e.ExceptionObject, Exception)

			If Not ex Is Nothing Then
				MessageBox.Show(BuildExceptionString(ex))
			Else
				MessageBox.Show("An Exception has occured, unable to get details")
			End If

			Environment.Exit(0)
		End Sub

		Private Function BuildExceptionString(ByVal exception As Exception) As String
			Dim errMessage As String = String.Empty

			errMessage &= exception.Message & Environment.NewLine & exception.StackTrace

			Do While Not exception.InnerException Is Nothing
				errMessage &= BuildInnerExceptionString(exception.InnerException)

				exception = exception.InnerException
			Loop

			Return errMessage
		End Function

		Private Function BuildInnerExceptionString(ByVal innerException As Exception) As String
			Dim errMessage As String = String.Empty

			errMessage &= Environment.NewLine & " InnerException "
			errMessage &= Environment.NewLine & innerException.Message & Environment.NewLine & innerException.StackTrace

			Return errMessage
		End Function
#End Region
	End Class
End Namespace