using canTransport;
using Dongzr.MidiLite;
using SecurityAccess;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Uds;
using System.Threading;

namespace S11_Lock_Unlock_Source
{
    public partial class Form1 : Form
    {

        can_driver driver = new can_driver();
        canTrans driverTrans = new canTrans();
        SecurityKey securityDriver = new SecurityKey();

        int tx_id = 0x740;
        int rx_id = 0x750;
        byte[] tx_data, rx_data = new byte[8];

        int dlc;
        long timestamp = 0;
        bool rx_success = false;

        public Form1()
        {
            InitializeComponent();
            BusParamsInit();
            mmTime_init();
        }

        private void BusParamsInit()
        {
            string[] channel = new string[0];
            channel = driver.GetChannel();
            comboBoxCanDevice.Items.Clear();
            comboBoxCanDevice.Items.AddRange(channel);//add items for comboBox
            comboBoxCanDevice.SelectedIndex = 0;//default select the first , physical driver always come first
            comboBoxCanBaudRate.SelectedIndex = 4;//default select 500K                                   
        }

        private void BusButton_Click(object sender, EventArgs e)
        {
            if (BusButton.Text == "Off-Line")//bus on和 bus off 对整个应用程序（包括子窗体）有绝对的控制功能
            {
                if (driver.OpenChannel(comboBoxCanDevice.SelectedIndex, comboBoxCanBaudRate.Text) == true)
                {
                    BusButton.Text = "On-Line";
                    driverTrans.Start();
                    mmTimer.Start();
                    comboBoxCanDevice.Enabled = true;
                    comboBoxCanBaudRate.Enabled = true;
                    ReadButton.Text = "Start";
                    t_Start();
                }
                else
                {
                    MessageBox.Show("打开" + comboBoxCanDevice.Text + "通道失败!");  //最好能把原因定位出来 给故障编码写入帮助文件
                }
            }
            else
            {
                driver.CloseChannel();
                BusButton.Text = "Off-Line";
                driverTrans.Stop();
                t_Stop();
                mmTimer.Stop();
                comboBoxCanDevice.Enabled = false;
                comboBoxCanBaudRate.Enabled = false;
            }
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            if (BusButton.Text == "Off-Line")
            {
                driver.WriteData(rx_id,rx_data,4,out time);
            }
        }

        #region Timer
        public delegate void Tick_10ms();
        public delegate void Tick_50ms();
        public delegate void Tick_100ms();
        public delegate void Tick_1s();
        public Tick_10ms mmtimer_tick_10ms;
        public Tick_10ms mmtimer_tick_50ms;
        public Tick_100ms mmtimer_tick_100ms;
        public Tick_1s mmtimer_tick_1s;
        public MmTimer mmTimer;
        const int timer_interval = 10;
        int timer_10ms_counter = 0;
        int timer_50ms_counter = 0;
        int timer_100ms_counter = 0;
        int timer_1s_counter = 0;

        private void mmTime_init()
        {
            mmTimer = new MmTimer();
            mmTimer.Mode = MmTimerMode.Periodic;
            mmTimer.Interval = timer_interval;
            mmTimer.Tick += mmTimer_tick;

            mmtimer_tick_10ms += delegate
            {

            };

            mmtimer_tick_50ms += delegate
            {

            };

            mmtimer_tick_100ms += delegate
            {

            };

            mmtimer_tick_1s += delegate
            {
                EventHandler BusLoadUpdate = delegate
                {
                   BusLoad.Text = "Bus Load：" + driver.BusLoad().ToString() + "% ";
                };
                try { Invoke(BusLoadUpdate); } catch { };
            };
        }

        void mmTimer_tick(object sender, EventArgs e)
        {
            timer_10ms_counter += timer_interval;
            if (timer_10ms_counter >= 10)
            {
                timer_10ms_counter = 0;
                if (mmtimer_tick_10ms != null)
                {
                    mmtimer_tick_10ms();
                }
            }

            timer_50ms_counter += timer_interval;
            if (timer_50ms_counter >= 50)
            {
                timer_50ms_counter = 0;
                if (mmtimer_tick_10ms != null)
                {
                    mmtimer_tick_50ms();
                }
            }

            timer_100ms_counter += timer_interval;
            if (timer_100ms_counter >= 100)
            {
                timer_100ms_counter = 0;
                if (mmtimer_tick_100ms != null)
                {
                    mmtimer_tick_100ms();
                }
            }

            timer_1s_counter += timer_interval;
            if (timer_1s_counter >= 1000)
            {
                timer_1s_counter = 0;
                if (mmtimer_tick_1s != null)
                {
                    mmtimer_tick_1s();
                }
            }
        }
        #endregion
        
        #region thread t_Receive
        Thread t_Receive;
        private void t_Receive_Thread()
        {
            while (true)
            {
                int i = 0;
                while (i < 50)
                {
                    CycleRecieve();
                    i++;
                }
                t_Sleep(20);//休息10ms
            }
        }

        private void CycleRecieve()
        {
            rx_success = driver.ReadData(out rx_id, ref rx_data, out dlc, out timestamp);//接收一帧数据
            if (rx_success)
            {
                //sw.WriteLine("$" + id.ToString("X3") + " " + dlc.ToString() + " " + HexToStrings(data, " ") + (timestamp / 1000).ToString() + "." + (timestamp % 1000).ToString());
                if ((rx_data[0] + rx_data[1] + rx_data[2] + rx_data[3]) == (0x07 + 0x67 + 0xFD + 0xFF))//
                {

                }
            }
        }
        public void t_Start()
        {
            t_Receive = new Thread(new ThreadStart(t_Receive_Thread));
            t_Receive.IsBackground = true;
            t_Receive.Priority = ThreadPriority.Lowest;
            t_Receive.Start();
        }
        public void t_Stop()
        {
            if (t_Receive != null && t_Receive.IsAlive)
            {
                t_Receive.Abort();
            }
        }
        public void t_Sleep(int timespan)
        {
            if (t_Receive != null && t_Receive.IsAlive)
            {
                Thread.Sleep(timespan);
            }
        }
        #endregion

        /*将十六进制数组转换成十六进制字符串，并以space隔开*/
        public string HexToStrings(byte[] hex, string space)
        {
            string strings = "";
            for (int i = 0; i < hex.Length; i++)//逐字节变为16进制字符，并以space隔开
            {
                strings += hex[i].ToString("X2") + space;
            }
            return strings;
        }

        /*将十六进制字符串转换成十六进制数组（不足末尾补0），失败返回空数组*/
        byte[] StringToHex(string strings)
        {
            byte[] hex = new byte[0];
            try
            {
                strings = strings.Replace("0x", "");
                strings = strings.Replace("0X", "");
                strings = strings.Replace(" ", "");
                strings = Regex.Replace(strings, @"(?i)[^a-f\d\s]+", "");//表示不可变正则表达式
                if (strings.Length % 2 != 0)
                {
                    strings += "0";
                }
                hex = new byte[strings.Length / 2];
                for (int i = 0; i < hex.Length; i++)
                {
                    hex[i] = Convert.ToByte(strings.Substring(i * 2, 2), 16);
                }
                return hex;
            }
            catch
            {
                return hex;
            }
        }
    }
}
