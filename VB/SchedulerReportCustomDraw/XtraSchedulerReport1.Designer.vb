Namespace SchedulerReportCustomDraw
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
            Me.dayViewTimeRuler1 = New DevExpress.XtraScheduler.Reporting.DayViewTimeRuler()
            Me.dayViewTimeCells1 = New DevExpress.XtraScheduler.Reporting.DayViewTimeCells()
            Me.horizontalDateHeaders1 = New DevExpress.XtraScheduler.Reporting.HorizontalDateHeaders()
            Me.horizontalResourceHeaders1 = New DevExpress.XtraScheduler.Reporting.HorizontalResourceHeaders()
            Me.reportDayView1 = New DevExpress.XtraScheduler.Reporting.ReportDayView()
            Me.calendarControl1 = New DevExpress.XtraScheduler.Reporting.CalendarControl()
            Me.schedulerStoragePrintAdapter1 = New DevExpress.XtraScheduler.Reporting.SchedulerStoragePrintAdapter()
            Me.horizontalWeek1 = New DevExpress.XtraScheduler.Reporting.HorizontalWeek()
            DirectCast(Me.reportDayView1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerStoragePrintAdapter1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' Detail
            ' 
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() { Me.dayViewTimeRuler1, Me.horizontalResourceHeaders1, Me.calendarControl1, Me.horizontalDateHeaders1, Me.dayViewTimeCells1})
            Me.Detail.HeightF = 581.25F
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F)
            Me.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            ' 
            ' dayViewTimeRuler1
            ' 
            Me.dayViewTimeRuler1.Corners.Top = 51
            Me.dayViewTimeRuler1.LocationFloat = New DevExpress.Utils.PointFloat(0F, 147.5835F)
            Me.dayViewTimeRuler1.Name = "dayViewTimeRuler1"
            Me.dayViewTimeRuler1.SizeF = New System.Drawing.SizeF(79.16666F, 420.9999F)
            Me.dayViewTimeRuler1.TimeCells = Me.dayViewTimeCells1
            Me.dayViewTimeRuler1.TimeRuler.TimeZoneId = "Russian Standard Time"
            Me.dayViewTimeRuler1.TimeRuler.UseClientTimeZone = False
            Me.dayViewTimeRuler1.View = Me.reportDayView1
            ' 
            ' dayViewTimeCells1
            ' 
            Me.dayViewTimeCells1.HorizontalHeaders = Me.horizontalDateHeaders1
            Me.dayViewTimeCells1.LocationFloat = New DevExpress.Utils.PointFloat(79.16666F, 198.5834F)
            Me.dayViewTimeCells1.Name = "dayViewTimeCells1"
            Me.dayViewTimeCells1.ShowWorkTimeOnly = True
            Me.dayViewTimeCells1.SizeF = New System.Drawing.SizeF(570.83F, 370F)
            Me.dayViewTimeCells1.View = Me.reportDayView1
            Me.dayViewTimeCells1.VisibleTimeSnapMode = False
            ' 
            ' horizontalDateHeaders1
            ' 
            Me.horizontalDateHeaders1.HorizontalHeaders = Me.horizontalResourceHeaders1
            Me.horizontalDateHeaders1.LocationFloat = New DevExpress.Utils.PointFloat(79.16666F, 172.5834F)
            Me.horizontalDateHeaders1.Name = "horizontalDateHeaders1"
            Me.horizontalDateHeaders1.SizeF = New System.Drawing.SizeF(570.8333F, 25.99998F)
            Me.horizontalDateHeaders1.View = Me.reportDayView1
            ' 
            ' horizontalResourceHeaders1
            ' 
            Me.horizontalResourceHeaders1.LocationFloat = New DevExpress.Utils.PointFloat(79.16666F, 147.5834F)
            Me.horizontalResourceHeaders1.Name = "horizontalResourceHeaders1"
            Me.horizontalResourceHeaders1.SizeF = New System.Drawing.SizeF(570.8333F, 25F)
            Me.horizontalResourceHeaders1.View = Me.reportDayView1
            ' 
            ' reportDayView1
            ' 
            Me.reportDayView1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Date
            Me.reportDayView1.VisibleDayCount = 3
            ' 
            ' calendarControl1
            ' 
            Me.calendarControl1.LocationFloat = New DevExpress.Utils.PointFloat(0F, 0F)
            Me.calendarControl1.Name = "calendarControl1"
            Me.calendarControl1.SizeF = New System.Drawing.SizeF(650F, 147.5834F)
            Me.calendarControl1.TimeCells = Me.dayViewTimeCells1
            Me.calendarControl1.View = Me.reportDayView1
            ' 
            ' schedulerStoragePrintAdapter1
            ' 
            Me.schedulerStoragePrintAdapter1.TimeInterval.Duration = System.TimeSpan.Parse("123.00:00:00")
            Me.schedulerStoragePrintAdapter1.TimeInterval.Start = New Date(2010, 12, 12, 0, 0, 0, 0)
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
            Me.Version = "14.2"
            Me.Views.AddRange(New DevExpress.XtraScheduler.Reporting.ReportViewBase() { Me.reportDayView1})
            DirectCast(Me.reportDayView1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerStoragePrintAdapter1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        #End Region

        Private Detail As DevExpress.XtraReports.UI.DetailBand
        Private schedulerStoragePrintAdapter1 As DevExpress.XtraScheduler.Reporting.SchedulerStoragePrintAdapter
        Private horizontalWeek1 As DevExpress.XtraScheduler.Reporting.HorizontalWeek
        Private dayViewTimeCells1 As DevExpress.XtraScheduler.Reporting.DayViewTimeCells
        Private reportDayView1 As DevExpress.XtraScheduler.Reporting.ReportDayView
        Private calendarControl1 As DevExpress.XtraScheduler.Reporting.CalendarControl
        Private horizontalDateHeaders1 As DevExpress.XtraScheduler.Reporting.HorizontalDateHeaders
        Private horizontalResourceHeaders1 As DevExpress.XtraScheduler.Reporting.HorizontalResourceHeaders
        Private dayViewTimeRuler1 As DevExpress.XtraScheduler.Reporting.DayViewTimeRuler
    End Class
End Namespace
