#region #usings
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using System;
using System.Drawing;
#endregion #usings

namespace SchedulerReportCustomDraw
{
    public partial class XtraSchedulerReport1 : DevExpress.XtraScheduler.Reporting.XtraSchedulerReport
    {
        DevExpress.Utils.ImageCollection carUsageImages;

        public XtraSchedulerReport1()
        {
            InitializeComponent();
            this.carUsageImages = DevExpress.Utils.Controls.ImageHelper.CreateImageCollectionFromResources("SchedulerReportCustomDraw.car_usage_types.png",
                System.Reflection.Assembly.GetExecutingAssembly(), new Size(16, 16));

            SusbcribeToCustomDrawEvents();
            calendarControl1.CustomDrawDayNumberCell+=
                new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(calendarControl1_CustomDrawDayNumberCell);
        }

        private void SusbcribeToCustomDrawEvents()
        {
            this.dayViewTimeCells1.CustomDrawAppointment += new CustomDrawObjectEventHandler(this.dayViewTimeCells1_CustomDrawAppointment);
            this.dayViewTimeCells1.CustomDrawTimeCell += new CustomDrawObjectEventHandler(this.dayViewTimeCells1_CustomDrawTimeCell);
            this.dayViewTimeCells1.CustomDrawAppointmentBackground += new CustomDrawObjectEventHandler(this.dayViewTimeCells1_CustomDrawAppointmentBackground);
            this.dayViewTimeCells1.CustomDrawDayViewAllDayArea += new CustomDrawObjectEventHandler(this.dayViewTimeCells1_CustomDrawDayViewAllDayArea);
            this.horizontalDateHeaders1.CustomDrawDayHeader += new CustomDrawObjectEventHandler(this.horizontalDateHeaders1_CustomDrawDayHeader);
            this.horizontalResourceHeaders1.CustomDrawResourceHeader += new CustomDrawObjectEventHandler(this.horizontalResourceHeaders1_CustomDrawResourceHeader);
        }
        #region #customdrawtimecell
        private void dayViewTimeCells1_CustomDrawTimeCell(object sender, CustomDrawObjectEventArgs e)
        {
            TimeCell cell = (TimeCell)e.ObjectInfo;
            Rectangle rect = e.Bounds;
            rect.Height = 1;
            rect.Offset(0, rect.Height - 1);
            e.Cache.DrawRectangle(Pens.Gray, rect);
            if (cell is ExtendedCell)
            {
                SchedulerColorSchema schema = this.GetResourceColorSchema(cell.Resource);
                cell.Appearance.BackColor = Color.White;
                cell.Appearance.BackColor2 = schema.CellLight;
                e.DrawDefault();
            }
            else
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Far;
                    rect = cell.Bounds;
                    rect.Inflate(-10, 0);
                    e.Cache.DrawString(cell.Interval.Start.ToShortTimeString(),
                        e.Cache.GetFont(cell.Appearance.Font, FontStyle.Regular),
                        e.Cache.GetSolidBrush(Color.Gray), rect, sf);
                }
            }
            e.Handled = true;
        }
        #endregion #customdrawtimecell
        #region #customdrawdayviewtimeruler
        private void dayViewTimeRuler1_CustomDrawDayViewTimeRuler(object sender, CustomDrawObjectEventArgs e)
        {
            e.Cache.FillRectangle(e.Cache.GetSolidBrush(Color.LightYellow), e.Bounds);
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                e.Cache.DrawVString(DevExpress.XtraScheduler.Native.SchedulerTimeZoneHelper.Instance.CurrentTimeZone.DisplayName,
                    e.Cache.GetFont(new Font(Font.FontFamily, 20, FontStyle.Bold), FontStyle.Bold),
                    e.Cache.GetSolidBrush(Color.Gray), e.Bounds, sf, -90);
                e.Handled = true;
            }
        }
        #endregion #customdrawdayviewtimeruler
        #region #customdrawresourceheader
        private void horizontalResourceHeaders1_CustomDrawResourceHeader(object sender, CustomDrawObjectEventArgs e)
        {
            ResourceHeader header = (ResourceHeader)e.ObjectInfo;
            SchedulerColorSchema schema = this.GetResourceColorSchema(header.Resource);
            header.Appearance.HeaderCaption.BackColor = schema.CellLight;
            header.Appearance.HeaderCaption.BackColor2 = schema.Cell;
            Color color = schema.CellBorderDark;
            header.Appearance.HeaderCaption.ForeColor = TransformColor(color, 0.6);
            header.Appearance.HeaderCaption.Font = e.Cache.GetFont(header.Appearance.HeaderCaption.Font, FontStyle.Bold);
            e.DrawDefault();
            e.Handled = true;
        }
        #endregion #customdrawresourceheader
        #region #customdrawdayheader
        private void horizontalDateHeaders1_CustomDrawDayHeader(object sender, CustomDrawObjectEventArgs e)
        {
            DayHeader header = (DayHeader)e.ObjectInfo;
            SchedulerColorSchema schema = this.GetResourceColorSchema(header.Resource);
            header.Appearance.HeaderCaption.BackColor = schema.CellLight;
            header.Appearance.HeaderCaption.BackColor2 = schema.Cell;
            Color color = schema.CellBorderDark;
            header.Appearance.HeaderCaption.ForeColor = TransformColor(color, 0.6);
            header.Appearance.HeaderCaption.Font = e.Cache.GetFont(header.Appearance.HeaderCaption.Font, FontStyle.Bold);
            e.DrawDefault();
            e.Handled = true;
        }
        private Color TransformColor(Color color, double light)
        {
            return Color.FromArgb((int)(color.R * light), (int)(color.G * light), (int)(color.B * light));
        }
        #endregion #customdrawdayheader
        #region #customdrawdayviewalldayarea
        private void dayViewTimeCells1_CustomDrawDayViewAllDayArea(object sender, CustomDrawObjectEventArgs e)
        {
            AllDayAreaCell cell = (AllDayAreaCell)e.ObjectInfo;
            SchedulerColorSchema schema = this.GetResourceColorSchema(cell.Resource);
            cell.Appearance.BackColor = schema.Cell;
            cell.Appearance.BackColor2 = schema.CellBorder;
        }
        #endregion #customdrawdayviewalldayarea
        #region #customdrawappointmentbackground
        private void dayViewTimeCells1_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e)
        {
            e.DrawDefault();
            AppointmentViewInfo vi = (AppointmentViewInfo)e.ObjectInfo;
            Rectangle rect = vi.Bounds;
            rect.Inflate(-vi.LeftBorderBounds.Width, -vi.TopBorderBounds.Height);
            Brush brush = e.Cache.GetGradientBrush(rect, Color.White, vi.Appearance.BackColor,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            e.Cache.FillRectangle(brush, rect);
            e.Handled = true;
        }
        #endregion #customdrawappointmentbackground
        #region #customdrawappointment
        private void dayViewTimeCells1_CustomDrawAppointment(object sender, CustomDrawObjectEventArgs e)
        {
            AppointmentViewInfo vi = (AppointmentViewInfo)e.ObjectInfo;
            // The DevExpress.XtraScheduler.Native.RectUtils is a helper object for managing rectangles.
            Rectangle imgRect = DevExpress.XtraScheduler.Native.RectUtils.CutFromLeft(vi.InnerBounds, vi.InnerBounds.Width - 18);
            imgRect = DevExpress.XtraScheduler.Native.RectUtils.AlignRectangle(new Rectangle(0, 0, 16, 16), imgRect, ContentAlignment.MiddleCenter);
            // carUsageImages is a collecion of images (DevExpress.Utils.ImageCollection) created from application resources.
            e.Cache.Paint.DrawImage(e.Graphics, carUsageImages.Images[vi.Appointment.StatusId], imgRect);
            Rectangle textRect = DevExpress.XtraScheduler.Native.RectUtils.CutFromRight(vi.InnerBounds, 18);
            using (StringFormat sf = new StringFormat())
            {
                Brush brush = e.Cache.GetSolidBrush(vi.Appearance.ForeColor);
                Font fntBold = e.Cache.GetFont(vi.Appearance.Font, FontStyle.Bold);
                Font fntItalic = e.Cache.GetFont(vi.Appearance.Font, FontStyle.Italic);
                if (vi.Appointment.LongerThanADay)
                {
                    Rectangle[] rowRects = DevExpress.XtraScheduler.Native.RectUtils.SplitHorizontally(textRect, 2);
                    string hours = String.Format(" [{0:F2} h]", vi.AppointmentInterval.Duration.TotalHours);
                    e.Cache.DrawString(vi.DisplayText + hours, fntBold, brush, textRect, sf);
                }
                else
                {
                    Rectangle[] rects = DevExpress.XtraScheduler.Native.RectUtils.SplitVertically(textRect, 3);
                    e.Cache.DrawString(vi.Interval.Start.ToShortTimeString() + " " +
                        vi.Interval.End.ToShortTimeString(), vi.Appearance.Font, brush, rects[0], sf);
                    e.Cache.DrawString(String.Format("{0} [{1}]", vi.Appointment.Subject, vi.Appointment.Location), fntBold, brush, rects[1], sf);
                    e.Cache.DrawString(vi.Description, fntItalic, brush, rects[2], sf);
                }
            }
            e.Handled = true;
        }
        #endregion #customdrawappointment
        #region #customdraw
        private void calendarControl1_CustomDrawDayNumberCell(object sender, 
            DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
        {
            if (e.Date.DayOfYear % 12 == 0)
            {
                Pen p = e.Cache.GetPen(Color.Violet);
                Rectangle r = e.Bounds;
                r.Inflate(-2, 0);
                r.Offset(3, 0);
                e.Cache.DrawRectangle(p, r);
            }
        }
        #endregion #customdraw
    }
}
