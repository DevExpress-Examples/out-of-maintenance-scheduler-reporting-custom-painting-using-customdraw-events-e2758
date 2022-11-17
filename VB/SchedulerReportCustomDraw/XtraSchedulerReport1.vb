#Region "#usings"
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.Utils.Controls
Imports System
Imports System.Drawing
#End Region ' #usings

Namespace SchedulerReportCustomDraw
    Partial Public Class XtraSchedulerReport1
        Inherits DevExpress.XtraScheduler.Reporting.XtraSchedulerReport

        Private carUsageImages As DevExpress.Utils.ImageCollection

        Public Sub New()
            InitializeComponent()
            Me.carUsageImages = ImageHelper.CreateImageCollectionFromResources("car_usage_types.png", System.Reflection.Assembly.GetExecutingAssembly(), New Size(16, 16))

            SusbcribeToCustomDrawEvents()
            AddHandler calendarControl1.CustomDrawDayNumberCell, AddressOf calendarControl1_CustomDrawDayNumberCell
        End Sub

        Private Sub SusbcribeToCustomDrawEvents()
            AddHandler dayViewTimeCells1.CustomDrawAppointment, AddressOf dayViewTimeCells1_CustomDrawAppointment
            AddHandler dayViewTimeCells1.CustomDrawTimeCell, AddressOf dayViewTimeCells1_CustomDrawTimeCell
            AddHandler dayViewTimeCells1.CustomDrawAppointmentBackground, AddressOf dayViewTimeCells1_CustomDrawAppointmentBackground
            AddHandler dayViewTimeCells1.CustomDrawDayViewAllDayArea, AddressOf dayViewTimeCells1_CustomDrawDayViewAllDayArea
            AddHandler horizontalDateHeaders1.CustomDrawDayHeader, AddressOf horizontalDateHeaders1_CustomDrawDayHeader
            AddHandler horizontalResourceHeaders1.CustomDrawResourceHeader, AddressOf horizontalResourceHeaders1_CustomDrawResourceHeader
            AddHandler Me.dayViewTimeRuler1.CustomDrawDayViewTimeRuler, AddressOf dayViewTimeRuler1_CustomDrawDayViewTimeRuler
        End Sub
        #Region "#customdrawtimecell"
        Private Sub dayViewTimeCells1_CustomDrawTimeCell(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            Dim cell As TimeCell = CType(e.ObjectInfo, TimeCell)
            Dim rect As Rectangle = e.Bounds
            rect.Height = 1
            rect.Offset(0, rect.Height - 1)
            e.Cache.DrawRectangle(Pens.Gray, rect)
            If TypeOf cell Is ExtendedCell Then
                Dim schema As SchedulerColorSchema = Me.GetResourceColorSchema(cell.Resource)
                cell.Appearance.BackColor = Color.White
                cell.Appearance.BackColor2 = schema.CellLight
                e.DrawDefault()
            Else
                Using sf As New StringFormat()
                    sf.Alignment = StringAlignment.Far
                    rect = cell.Bounds
                    rect.Inflate(-10, 0)
                    e.Cache.DrawString(cell.Interval.Start.ToShortTimeString(), e.Cache.GetFont(cell.Appearance.Font, FontStyle.Regular), e.Cache.GetSolidBrush(Color.Gray), rect, sf)
                End Using
            End If
            e.Handled = True
        End Sub
        #End Region ' #customdrawtimecell
        #Region "#customdrawdayviewtimeruler"
    Dim arialFont As New Font("Arial", 20, FontStyle.Bold)

        Private Sub dayViewTimeRuler1_CustomDrawDayViewTimeRuler(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            e.Cache.FillRectangle(e.Cache.GetSolidBrush(Color.LightYellow), e.Bounds)
            Using sf As New StringFormat()
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
                e.Cache.DrawVString(TimeZoneInfo.Local.DisplayName, e.Cache.GetFont(arialFont, FontStyle.Bold), e.Cache.GetSolidBrush(Color.Gray), e.Bounds, sf, -90)
                e.Handled = True
            End Using
        End Sub
        #End Region ' #customdrawdayviewtimeruler
        #Region "#customdrawresourceheader"
        Private Sub horizontalResourceHeaders1_CustomDrawResourceHeader(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            Dim header As ResourceHeader = CType(e.ObjectInfo, ResourceHeader)
            Dim schema As SchedulerColorSchema = Me.GetResourceColorSchema(header.Resource)
            header.Appearance.HeaderCaption.BackColor = schema.CellLight
            header.Appearance.HeaderCaption.BackColor2 = schema.Cell
            Dim color As Color = schema.CellBorderDark
            header.Appearance.HeaderCaption.ForeColor = TransformColor(color, 0.6)
            header.Appearance.HeaderCaption.Font = e.Cache.GetFont(header.Appearance.HeaderCaption.Font, FontStyle.Bold)
            e.DrawDefault()
            e.Handled = True
        End Sub
        #End Region ' #customdrawresourceheader
        #Region "#customdrawdayheader"
        Private Sub horizontalDateHeaders1_CustomDrawDayHeader(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            Dim header As DayHeader = CType(e.ObjectInfo, DayHeader)
            Dim schema As SchedulerColorSchema = Me.GetResourceColorSchema(header.Resource)
            header.Appearance.HeaderCaption.BackColor = schema.CellLight
            header.Appearance.HeaderCaption.BackColor2 = schema.Cell
            Dim color As Color = schema.CellBorderDark
            header.Appearance.HeaderCaption.ForeColor = TransformColor(color, 0.6)
            header.Appearance.HeaderCaption.Font = e.Cache.GetFont(header.Appearance.HeaderCaption.Font, FontStyle.Bold)
            e.DrawDefault()
            e.Handled = True
        End Sub
        Private Function TransformColor(ByVal color As Color, ByVal light As Double) As Color
            Return System.Drawing.Color.FromArgb(CInt((color.R * light)), CInt((color.G * light)), CInt((color.B * light)))
        End Function
        #End Region ' #customdrawdayheader
        #Region "#customdrawdayviewalldayarea"
        Private Sub dayViewTimeCells1_CustomDrawDayViewAllDayArea(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            Dim cell As AllDayAreaCell = CType(e.ObjectInfo, AllDayAreaCell)
            Dim schema As SchedulerColorSchema = Me.GetResourceColorSchema(cell.Resource)
            cell.Appearance.BackColor = schema.Cell
            cell.Appearance.BackColor2 = schema.CellBorder
        End Sub
        #End Region ' #customdrawdayviewalldayarea
        #Region "#customdrawappointmentbackground"
        Private Sub dayViewTimeCells1_CustomDrawAppointmentBackground(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            e.DrawDefault()
            Dim vi As AppointmentViewInfo = CType(e.ObjectInfo, AppointmentViewInfo)
            Dim rect As Rectangle = vi.Bounds
            rect.Inflate(-vi.LeftBorderBounds.Width, -vi.TopBorderBounds.Height)
            Dim brush As Brush = e.Cache.GetGradientBrush(rect, Color.White, vi.Appearance.BackColor, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            e.Cache.FillRectangle(brush, rect)
            e.Handled = True
        End Sub
        #End Region ' #customdrawappointmentbackground
        #Region "#customdrawappointment"
        Private Sub dayViewTimeCells1_CustomDrawAppointment(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            Dim vi As AppointmentViewInfo = CType(e.ObjectInfo, AppointmentViewInfo)
            ' The DevExpress.XtraScheduler.Native.RectUtils is a helper object for managing rectangles.
            Dim imgRect As Rectangle = DevExpress.XtraScheduler.Native.RectUtils.CutFromLeft(vi.InnerBounds, vi.InnerBounds.Width - 18)
            imgRect = DevExpress.XtraScheduler.Native.RectUtils.AlignRectangle(New Rectangle(0, 0, 16, 16), imgRect, ContentAlignment.MiddleCenter)
            ' carUsageImages is a collecion of images (DevExpress.Utils.ImageCollection) created from application resources.
            e.Cache.Paint.DrawImage(e.Graphics, carUsageImages.Images(Convert.ToInt32(vi.Appointment.StatusKey)), imgRect)
            Dim textRect As Rectangle = DevExpress.XtraScheduler.Native.RectUtils.CutFromRight(vi.InnerBounds, 18)
            Using sf As New StringFormat()
                Dim brush As Brush = e.Cache.GetSolidBrush(vi.Appearance.ForeColor)
                Dim fntBold As Font = e.Cache.GetFont(vi.Appearance.Font, FontStyle.Bold)
                Dim fntItalic As Font = e.Cache.GetFont(vi.Appearance.Font, FontStyle.Italic)
                If vi.Appointment.LongerThanADay Then
                    Dim rowRects() As Rectangle = DevExpress.XtraScheduler.Native.RectUtils.SplitHorizontally(textRect, 2)
                    Dim hours As String = String.Format(" [{0:F2} h]", vi.AppointmentInterval.Duration.TotalHours)
                    e.Cache.DrawString(vi.DisplayText & hours, fntBold, brush, textRect, sf)
                Else
                    Dim rects() As Rectangle = DevExpress.XtraScheduler.Native.RectUtils.SplitVertically(textRect, 3)
                    e.Cache.DrawString(vi.Interval.Start.ToShortTimeString() & " " & vi.Interval.End.ToShortTimeString(), vi.Appearance.Font, brush, rects(0), sf)
                    e.Cache.DrawString(String.Format("{0}", vi.Appointment.Subject), fntBold, brush, rects(1), sf)
                    e.Cache.DrawString(vi.Description, fntItalic, brush, rects(2), sf)
                End If
            End Using
            e.Handled = True
        End Sub
        #End Region ' #customdrawappointment
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
