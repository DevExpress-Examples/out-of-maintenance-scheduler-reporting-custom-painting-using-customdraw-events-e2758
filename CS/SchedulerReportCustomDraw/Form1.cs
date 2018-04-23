using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraReports.UI;	

namespace SchedulerReportCustomDraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Populate();
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.DayView.TopRowTime = schedulerControl1.DayView.WorkTime.Start;
            schedulerControl1.DayView.DayCount = 3;
            schedulerControl1.Start = new DateTime(2014, 10, 12);
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            XtraSchedulerReport1 rep = new XtraSchedulerReport1();
            rep.SchedulerAdapter.SetSourceObject(schedulerStorage1);
            rep.SchedulerAdapter.TimeInterval = schedulerControl1.ActiveView.GetVisibleIntervals().Interval;
            ReportPrintTool rpt = new ReportPrintTool(rep);
            rpt.ShowPreviewDialog();
        }

        private void dateNavigator1_CustomDrawDayNumberCell(object sender, 
            DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
        {
            if (e.Date.DayOfYear % 12 == 0)
            {
                Pen p = e.Cache.GetPen(Color.Violet);
                Rectangle r = e.Bounds;
                r.Inflate(-2,0);
                r.Offset(3, 0);
                e.Cache.DrawRectangle(p, r);
            }
        }

        private void Populate()
        {
            Appointment apt = schedulerStorage1.CreateAppointment(AppointmentType.Pattern);
            apt.Start = new DateTime(2014, 10, 12, 10, 0, 0);
            apt.End = apt.Start.AddHours(1.5d);
            apt.RecurrenceInfo.Type = RecurrenceType.Monthly;
            apt.RecurrenceInfo.Start = apt.Start;
            apt.RecurrenceInfo.WeekOfMonth = WeekOfMonth.None;
            apt.RecurrenceInfo.DayNumber = 12;
            apt.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount;
            apt.RecurrenceInfo.OccurrenceCount = 13;
            apt.Subject = "Each 12th day of month";
            apt.Location = "City Center";
            apt.StatusId = 2;
            apt.LabelId = 3;
            apt.ResourceId = 1;
            schedulerStorage1.Appointments.Add(apt);
            schedulerStorage1.Resources.Add(new Resource(1,"Resource One"));
            schedulerStorage1.Resources.Add(new Resource(2, "Resource Two"));
            schedulerStorage1.Resources.Add(new Resource(3, "Resource Three"));

        }

    }
}