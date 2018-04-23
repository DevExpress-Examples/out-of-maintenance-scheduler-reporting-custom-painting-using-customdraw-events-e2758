using System;
using System.Drawing;

namespace CalendarCustomDraw
{
    public partial class XtraSchedulerReport1 : DevExpress.XtraScheduler.Reporting.XtraSchedulerReport
    {
        public XtraSchedulerReport1()
        {
            InitializeComponent();
            calendarControl1.CustomDrawDayNumberCell+=
                new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(calendarControl1_CustomDrawDayNumberCell);
        }

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
