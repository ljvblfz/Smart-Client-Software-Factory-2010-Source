Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.Practices.CompositeUI
Imports Microsoft.Practices.CompositeUI.Services
Imports System.Windows.Forms

Namespace MyModule
	Public Class MyModuleInit : Inherits ModuleInit
		Private myCatalogService As IWorkItemTypeCatalogService

		<ServiceDependency()> _
		Public WriteOnly Property myWorkItemCatalog() As IWorkItemTypeCatalogService
			Set(ByVal value As IWorkItemTypeCatalogService)
				myCatalogService = Value
			End Set
		End Property

		Public Overrides Sub Load()
			MyBase.Load()
			myCatalogService.RegisterWorkItem(Of MyWorkItem)()
			MessageBox.Show("Hello there!")
		End Sub
	End Class
End Namespace
