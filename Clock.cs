using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    public partial class Clock : Form
    {
        DateTime dt = new DateTime();
        TimeSpan ts;
        public Clock()
        {
            InitializeComponent();
        }
        enum enMonth
        {
            enJan = 1,
            enFeb,
            enMarch,
            enAbr,
            enMay,
            enJun,
            enJul,
            enAug,
            enSep,
            enOct,
            enNov,
            enDes,
        }
        enMonth eMonth;
        string GetMonth(enMonth Month)
        {
            switch (Month)
            {
                case enMonth.enJan:
                    return "Jan";
                case enMonth.enFeb:
                    return "Feb";
                case enMonth.enMarch:
                    return "Mar";
                case enMonth.enAbr:
                    return "Abr";
                case enMonth.enMay:
                    return "May";
                case enMonth.enJun:
                    return "Jun";
                case enMonth.enJul:
                    return "Jul";
                case enMonth.enAug:
                    return "Aug";
                case enMonth.enSep:
                    return "Sep";
                case enMonth.enOct:
                    return "Oct";
                case enMonth.enNov:
                    return "Nov";
                default:
                    return "Des";


            }
        }
        void MakeItColored(Label lbl, Label Prevlbl)
        {
            Prevlbl.Tag = "";
            Prevlbl.ForeColor = Color.Black;
            lbl.Tag = "Colored";
            lbl.ForeColor = Color.DarkBlue;
        }
        void CheckColoredLableColored()
        {
            if (lbl1.Tag.ToString() == "Colored")
            {
                MakeItColored(lbl2, lbl1);
                return;
            }

            if (lbl2.Tag.ToString() == "Colored")
            {
                MakeItColored(lbl3, lbl2);
                return;
            }

            if (lbl3.Tag.ToString() == "Colored")
            {
                MakeItColored(lbl4, lbl3);
                return;
            }

            if (lbl4.Tag.ToString() == "Colored")
            {
                MakeItColored(lblMiddleClock, lbl4);
                return;
            }


            if (lblMiddleClock.Tag.ToString() == "Colored")
            {
                MakeItColored(lbl5,lblMiddleClock);
                return;
            }


            if (lbl5.Tag.ToString() == "Colored")
            {
                MakeItColored(lbl6, lbl5);
                return;
            }

            if (lbl6.Tag.ToString() == "Colored")
            {
                MakeItColored(lbl7, lbl6);
                return;
            }

            if (lbl7.Tag.ToString() == "Colored")
            {
                MakeItColored(lbl8, lbl7);
                return;
            }
            if (lbl8.Tag.ToString() == "Colored")
            {
                MakeItColored(lbl1, lbl8);
                return;
            }

        }
        void UpdatSecLabel(Label lbl, TimeSpan ts, byte Value, bool IsLabelAboveClock = true)
        {
            if (IsLabelAboveClock)
            {
                lbl.Text = (ts = new TimeSpan(ts.Hours, ts.Minutes,ts.Seconds + Value)).Seconds.ToString();
                return;
            }

            lbl.Text = (ts = new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds - Value)).Seconds.ToString();

        }
        void UpdateSecondsLables(TimeSpan ts)
        {
            UpdatSecLabel(lbl1, ts, 4, false);
            UpdatSecLabel(lbl2, ts, 3, false);
            UpdatSecLabel(lbl3, ts, 2, false);
            UpdatSecLabel(lbl4, ts, 1, false);

            UpdatSecLabel(lbl5, ts, 1);
            UpdatSecLabel(lbl6, ts, 2);
            UpdatSecLabel(lbl7, ts, 3);
            UpdatSecLabel(lbl8, ts, 4);


            CheckColoredLableColored();
        }
        void UpdateTime()
        {
            dt = DateTime.Now;
            ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second);


            lblMiddleClock.Text = ts + (dt.Hour >= 12 ? " PM" : " AM");
            lblCornClock.Text = lblMiddleClock.Text;


            lblDate.Text = dt.DayOfWeek.ToString()
                         + ", " + GetMonth((enMonth)dt.Month)
                         + " " + dt.Day
                         + ", " + dt.Year;

            UpdateSecondsLables(ts);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }
    }
}
