Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraReports.UI

Namespace SchedulerReportCustomDraw
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            Populate()
            schedulerControl1.GroupType = SchedulerGroupType.Resource
            schedulerControl1.DayView.TopRowTime = schedulerControl1.DayView.WorkTime.Start
            schedulerControl1.DayView.DayCount = 3
            schedulerControl1.Start = New Date(2014, 10, 12)
        End Sub

        Private Sub btnShowReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowReport.Click
            Dim rep As New XtraSchedulerReport1()
            rep.SchedulerAdapter.SetSourceObject(schedulerStorage1)
            rep.SchedulerAdapter.TimeInterval = schedulerControl1.ActiveView.GetVisibleIntervals().Interval
            Dim rpt As New ReportPrintTool(rep)
            rpt.ShowPreviewDialog()
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
            apt.Start = New Date(2014, 10, 12, 10, 0, 0)
            apt.End = apt.Start.AddHours(1.5R)
            apt.RecurrenceInfo.Type = RecurrenceType.Monthly
            apt.RecurrenceInfo.Start = apt.Start
            apt.RecurrenceInfo.WeekOfMonth = WeekOfMonth.None
            apt.RecurrenceInfo.DayNumber = 12
            apt.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount
            apt.RecurrenceInfo.OccurrenceCount = 13
            apt.Subject = "Each 12th day of month"
            apt.Location = "City Center"
            apt.StatusKey = 2
            apt.LabelKey = 3
            apt.ResourceId = 1
            schedulerStorage1.Appointments.Add(apt)
            schedulerStorage1.Resources.Add(schedulerStorage1.CreateResource(1,"Resource One"))
            schedulerStorage1.Resources.Add(schedulerStorage1.CreateResource(2, "Resource Two"))
            schedulerStorage1.Resources.Add(schedulerStorage1.CreateResource(3, "Resource Three"))

        End Sub

    End Class
End Namespace