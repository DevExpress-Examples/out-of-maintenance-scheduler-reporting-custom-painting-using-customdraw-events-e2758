Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace CalendarCustomDraw
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Populate()
			schedulerControl1.DayView.TopRowTime = schedulerControl1.DayView.WorkTime.Start
			schedulerControl1.Start = New DateTime(2010, 12, 12)
		End Sub

		Private Sub btnShowReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowReport.Click
			Dim rep As New XtraSchedulerReport1()
			rep.SchedulerAdapter.SetSourceObject(schedulerStorage1)
			rep.ShowPreviewDialog()
		End Sub

		Private Sub dateNavigator1_CustomDrawDayNumberCell(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs) Handles dateNavigator1.CustomDrawDayNumberCell
			If e.Date.DayOfYear Mod 12 = 0 Then
				Dim p As Pen = e.Cache.GetPen(Color.Violet)
				Dim r As Rectangle = e.Bounds
				r.Inflate(-2,0)
				r.Offset(3, 0)
				e.Cache.DrawRectangle(p, r)
			End If
		End Sub

		Private Sub Populate()
			Dim apt As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Pattern)
			apt.Start = New DateTime(2010, 12, 12, 10, 0, 0)
			apt.End = apt.Start.AddHours(1.5R)
			apt.RecurrenceInfo.Type = RecurrenceType.Monthly
			apt.RecurrenceInfo.Start = apt.Start
			apt.RecurrenceInfo.WeekOfMonth = WeekOfMonth.None
			apt.RecurrenceInfo.DayNumber = 12
			apt.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount
			apt.RecurrenceInfo.OccurrenceCount = 13
			apt.Subject = "Each 12th day of month"
			schedulerStorage1.Appointments.Add(apt)

			apt.StatusId = 2
			apt.LabelId = 3

		End Sub

	End Class
End Namespace