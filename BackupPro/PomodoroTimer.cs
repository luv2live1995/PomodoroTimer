using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupPro
{
    public partial class PomodoroTimer : Form
    {
        // 25 minutes = 1500 seconds
        int POMODORO_WORK_MINUTES = 25;
        int TWENTYFIVE_MINUTES_TO_SECONDS = 1500;
        string DEFAULT_CLOCK_STRING = "25:00";

        // Vars
        int secondsCount;
        DateTime defaultTime;

        // When user clicks Stop Button Flag
        int stopFlag = 0;

        public PomodoroTimer()
        {
            InitializeComponent();
            secondsCount = TWENTYFIVE_MINUTES_TO_SECONDS;
            defaultTime = new DateTime().AddMinutes(POMODORO_WORK_MINUTES).AddSeconds(00);
        }

        // Clock text
        private void shownTimeText_TextChanged(object sender, EventArgs e)
        {

        }

        // Start button
        private void startBtn_Click(object sender, EventArgs e)
        {
            //DateTime currTime = new DateTime();
            //timer1.Tick += new EventHandler(substract1Sec);
            stopFlag = 0;
            substract1Sec();
        }

        // Extract 1 second 
        private void substract1Sec()
        {
            while (secondsCount >= 1)
            {
                DateTime now = DateTime.Now;

                if (stopFlag == 0)
                {
                    defaultTime = defaultTime.AddSeconds(-1);

                    if (defaultTime.Second < 10)
                    {
                        this.shownTimeText.Text = defaultTime.Minute.ToString()
                                         + ":0" + defaultTime.Second.ToString();
                    }
                    else
                    {
                        this.shownTimeText.Text = defaultTime.Minute.ToString()
                                         + ":" + defaultTime.Second.ToString();
                    }
                    --secondsCount;
                    wait(1000);
                }
                else
                {
                    break;
                }
            }
        }

        // Waiting 1 second
        public void wait(int milliseconds)
        {
            if (milliseconds == 0 || milliseconds < 0) return;

            // Start wait timer 
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Stop wait timer
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        // Stop button
        private void stopBtn_Click(object sender, EventArgs e)
        {
            stopFlag = 1;
        }

        // Reset button
        private void resetBtn_Click(object sender, EventArgs e)
        {
            secondsCount = TWENTYFIVE_MINUTES_TO_SECONDS;
            this.shownTimeText.Text = DEFAULT_CLOCK_STRING;
            defaultTime = new DateTime().AddMinutes(POMODORO_WORK_MINUTES).AddSeconds(00);
        }

    }
}
