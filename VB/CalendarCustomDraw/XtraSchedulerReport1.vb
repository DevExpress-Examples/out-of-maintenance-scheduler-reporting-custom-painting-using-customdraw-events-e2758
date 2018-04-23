Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Namespace CalendarCustomDraw
	Partial Public Class XtraSchedulerReport1
		Inherits DevExpress.XtraScheduler.Reporting.XtraSchedulerReport
		Public Sub New()
			InitializeComponent()
			AddHandler calendarControl1.CustomDrawDayNumberCell, AddressOf calendarControl1_CustomDrawDayNumberCell
		End Sub

		#Region "#customdraw"
		Private Sub calendarControl1_CustomDrawDayNumberCell(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs)
			If e.Date.DayOfYear Mod 12 = 0 Then
				Dim p As Pen = e.Cache.GetPen(Color.Violet)
				Dim r As Rectangle = e.Bounds
				r.Inflate(-2, 0)
				r.Offset(3, 0)
				e.Cache.DrawRectangle(p, r)
			End If
		End Sub
		#End Region ' #customdraw
	End Class
End Namespace
