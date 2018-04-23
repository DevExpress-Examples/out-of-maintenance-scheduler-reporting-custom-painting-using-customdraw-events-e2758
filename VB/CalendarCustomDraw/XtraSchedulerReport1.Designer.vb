Imports Microsoft.VisualBasic
Imports System
Namespace CalendarCustomDraw
	Partial Public Class XtraSchedulerReport1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
			Me.calendarControl1 = New DevExpress.XtraScheduler.Reporting.CalendarControl()
			Me.dayViewTimeCells1 = New DevExpress.XtraScheduler.Reporting.DayViewTimeCells()
			Me.horizontalDateHeaders1 = New DevExpress.XtraScheduler.Reporting.HorizontalDateHeaders()
			Me.reportDayView1 = New DevExpress.XtraScheduler.Reporting.ReportDayView()
			Me.schedulerStoragePrintAdapter1 = New DevExpress.XtraScheduler.Reporting.SchedulerStoragePrintAdapter()
			Me.horizontalWeek1 = New DevExpress.XtraScheduler.Reporting.HorizontalWeek()
			CType(Me.reportDayView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerStoragePrintAdapter1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' Detail
			' 
			Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() { Me.calendarControl1, Me.horizontalDateHeaders1, Me.dayViewTimeCells1})
			Me.Detail.HeightF = 581.25F
			Me.Detail.Name = "Detail"
			Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F)
			Me.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
			Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			' 
			' calendarControl1
			' 
			Me.calendarControl1.LocationFloat = New DevExpress.Utils.PointFloat(0F, 0F)
			Me.calendarControl1.Name = "calendarControl1"
			Me.calendarControl1.SizeF = New System.Drawing.SizeF(650F, 172.5834F)
			Me.calendarControl1.TimeCells = Me.dayViewTimeCells1
			Me.calendarControl1.View = Me.reportDayView1
			' 
			' dayViewTimeCells1
			' 
			Me.dayViewTimeCells1.HorizontalHeaders = Me.horizontalDateHeaders1
			Me.dayViewTimeCells1.LocationFloat = New DevExpress.Utils.PointFloat(0F, 198.5834F)
			Me.dayViewTimeCells1.Name = "dayViewTimeCells1"
			Me.dayViewTimeCells1.ShowWorkTimeOnly = True
			Me.dayViewTimeCells1.SizeF = New System.Drawing.SizeF(650F, 374.75F)
			Me.dayViewTimeCells1.View = Me.reportDayView1
			' 
			' horizontalDateHeaders1
			' 
			Me.horizontalDateHeaders1.LocationFloat = New DevExpress.Utils.PointFloat(0F, 172.5834F)
			Me.horizontalDateHeaders1.Name = "horizontalDateHeaders1"
			Me.horizontalDateHeaders1.SizeF = New System.Drawing.SizeF(650F, 25.99998F)
			Me.horizontalDateHeaders1.View = Me.reportDayView1
			' 
			' reportDayView1
			' 
			Me.reportDayView1.VisibleDayCount = 3
			' 
			' schedulerStoragePrintAdapter1
			' 
			Me.schedulerStoragePrintAdapter1.TimeInterval.Duration = System.TimeSpan.Parse("123.00:00:00")
			Me.schedulerStoragePrintAdapter1.TimeInterval.Start = New System.DateTime(2010, 12, 12, 0, 0, 0, 0)
			' 
			' horizontalWeek1
			' 
			Me.horizontalWeek1.LocationFloat = New DevExpress.Utils.PointFloat(0F, 0F)
			Me.horizontalWeek1.Name = "horizontalWeek1"
			Me.horizontalWeek1.SizeF = New System.Drawing.SizeF(550F, 150F)
			' 
			' XtraSchedulerReport1
			' 
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() { Me.Detail})
			Me.SchedulerAdapter = Me.schedulerStoragePrintAdapter1
			Me.Version = "10.2"
			Me.Views.AddRange(New DevExpress.XtraScheduler.Reporting.ReportViewBase() { Me.reportDayView1})
			CType(Me.reportDayView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerStoragePrintAdapter1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private Detail As DevExpress.XtraReports.UI.DetailBand
		Private schedulerStoragePrintAdapter1 As DevExpress.XtraScheduler.Reporting.SchedulerStoragePrintAdapter
		Private horizontalWeek1 As DevExpress.XtraScheduler.Reporting.HorizontalWeek
		Private dayViewTimeCells1 As DevExpress.XtraScheduler.Reporting.DayViewTimeCells
		Private reportDayView1 As DevExpress.XtraScheduler.Reporting.ReportDayView
		Private calendarControl1 As DevExpress.XtraScheduler.Reporting.CalendarControl
		Private horizontalDateHeaders1 As DevExpress.XtraScheduler.Reporting.HorizontalDateHeaders
	End Class
End Namespace
