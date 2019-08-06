using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace FolderLogger
{
    public delegate void LogWrite(string message);

    public partial class Form1 : Form
    {
        private WatcherStore watcherStore;
        private List<Tuple<CheckBox, Label>> watchers;

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = MinimumSize = new Size(420, 400);
            MouseDown += new MouseEventHandler(Form1_MouseDown);
            BackColor = Color.DeepSkyBlue;

            notifyIcon1.Visible = false;
            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;

            Button minimizeawindow = new Button() { Width = 30, Height = 30, Top = 0, Left = Width - 60, Parent = this, Text = "–", BackColor = Color.LightYellow, FlatStyle = FlatStyle.Flat };
            minimizeawindow.Click += Minimizeawindow_Click;
            Button close = new Button()
            {
                Width = 30,
                Height = 30,
                Top = 0,
                Left = Width - 30,
                Parent = this,
                Text = "X",
                BackColor = Color.MediumVioletRed,
                FlatStyle = FlatStyle.Flat
            };
            close.Click += Close_Click;

            Panel watcherPanel = new Panel()
            {
                Parent = this,
                Height = 175,
                Width = 410,
                Left = 5,
                Top = 70,
                Name = "watcherPanel",
                BackColor = Color.Aqua                
            };
            WatcherPanelDesign(watcherPanel);
            Panel restorePanel = new Panel()
            {
                Parent = this,
                Height = 175,
                Width = 410,
                Left = 5,
                Top = 70,
                Name = "restorePanel",
                BackColor = Color.LawnGreen,
                Visible = false
            };

            RestorePanelDesign(restorePanel);

            Label MenuWatcher = new Label()
            {
                Parent = this,
                Top = 30,
                Left = 5,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 200,
                Height = 35,
                Text = "FileWatcher",
                Font = new Font("Arial", 18, FontStyle.Underline),
                Name = "MenuWatcher"
            };
            MenuWatcher.Click += MenuWatcher_Click;
            Label MenuRestore = new Label()
            {
                Parent = this,
                Top = 30,
                Left = 215,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 200,
                Height = 35,
                Text = "FileRestore",
                Font = new Font("Arial", 18),
                Name = "MenuRestore"
            };
            MenuRestore.Click += MenuRestore_Click;

            RichTextBox info = new RichTextBox()
            {
                Width = Width - 10,
                Height = 145,
                Top = 250,
                Left = 5,
                BackColor = Color.AliceBlue,
                Parent = this,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Name = "info"
            };


            CheckDir();
            watcherStore = new WatcherStore();
            watchers = new List<Tuple<CheckBox, Label>>();
        }

        private void MenuRestore_Click(object sender, EventArgs e)
        {
            Controls["watcherPanel"].Hide();
            Controls["restorePanel"].Show(); 
            Controls["MenuRestore"].Font = new Font("Arial", 18, FontStyle.Underline);
            Controls["MenuWatcher"].Font = new Font("Arial", 18, FontStyle.Regular);
        }
        private void MenuWatcher_Click(object sender, EventArgs e)
        {
            Controls["watcherPanel"].Show();
            Controls["restorePanel"].Hide();
            Controls["MenuWatcher"].Font = new Font("Arial", 18, FontStyle.Underline);
            Controls["MenuRestore"].Font = new Font("Arial", 18, FontStyle.Regular);
        }

        private void WatcherPanelDesign(Panel p)
        {            
            Label labelwatcherlist = new Label()
            {
                Width = p.Width / 2 - 5,
                Height = 30,
                Top = 5,
                Left = p.Width / 2,
                Parent = p,
                Text = "Watchers",
                Font = new Font("Arial", 18),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightBlue
            };

            Panel watchersList = new Panel()
            {
                Width = p.Width / 2 - 5,
                Height = p.Height - 40,
                Top = 35,
                Left = p.Width / 2,
                BackColor = Color.LightBlue,
                Parent = p,
                BorderStyle = BorderStyle.None,
                Name = "watchersList"
            };

            Label selectinfo1 = new Label()
            {
                Width = p.Width / 2,
                Height = 17,
                Top = 5,
                Left = 5,
                Parent = p,
                Text = "Want to start scanning folder",
                Font = new Font("Arial", 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Label selectinfo2 = new Label()
            {
                Width = p.Width / 2,
                Height = 17,
                Top = 22,
                Left = 5,
                Parent = p,
                Text = "press button and select folder",
                Font = new Font("Arial", 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Button selectFolder = new Button()
            {
                Width = p.Width / 2 - 10,
                Height = 35,
                Top = 45,
                Left = 5,
                Text = "Add watcher to folder",
                Parent = p,
                FlatStyle = FlatStyle.Flat
            };
            selectFolder.Click += Button_Click;

            Label infodelete1 = new Label()
            {
                Width = p.Width / 2,
                Height = 17,
                Top = 95,
                Left = 5,
                Parent = p,
                Text = "Select watcher from right list",
                Font = new Font("Arial", 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label infodelete2 = new Label()
            {
                Width = p.Width / 2,
                Height = 17,
                Top = 112,
                Left = 5,
                Parent = p,
                Text = "to delete and press button",
                Font = new Font("Arial", 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Button deleteFolder = new Button()
            {
                Width = p.Width / 2 - 10,
                Height = 35,
                Top = 135,
                Left = 5,
                Text = "Delete watcher folder",
                Parent = p,
                FlatStyle = FlatStyle.Flat
            };
            deleteFolder.Click += DeleteFolder_Click;
        }

        private void RestorePanelDesign(Panel p)
        {
            Label labelInfo1 = new Label()
            {
                Width = p.Width / 2,
                Height = 50,
                Top = 0,
                Left = 0,
                Parent = p,
                Text = "1) Select file to Restore",
                Font = new Font("Arial", 15),
                TextAlign = ContentAlignment.MiddleLeft
            };
                       
            Button selectFile = new Button()
            {
                Width = 200,
                Height = 40,
                Top = 5,
                Left = p.Width / 2,
                Text = "Select File",
                Parent = p,
                FlatStyle = FlatStyle.Flat
            };
            selectFile.Click += SelectFile_Click;

            Label labelInfo2 = new Label()
            {
                Width = p.Width / 2,
                Height = 50,
                Top = 60,
                Left = 0,
                Parent = p,
                Text = "2) Select time",
                Font = new Font("Arial", 15),
                TextAlign = ContentAlignment.MiddleLeft
            };
            ComboBox comboBox = new ComboBox()
            {
                Name = "comboBox",
                Parent = p,
                Left = p.Width / 2- 5,
                Top = 65,
                Width = p.Width / 2,
                Font = new Font("Arial", 15),
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Label labelInfo3 = new Label()
            {
                Width = p.Width / 2,
                Height = 50,
                Top = 120,
                Left = 0,
                Parent = p,
                Text = "3) Restore file",
                Font = new Font("Arial", 15),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Button restoreButton = new Button()
            {
                Width = 200,
                Height = 40,
                Top = 125,
                Left = p.Width / 2,
                Text = "Start",
                Parent = p,
                FlatStyle = FlatStyle.Flat,
                Name = "restoreButton"
            };
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog filedialog = new OpenFileDialog())
            {
                if (filedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Restore restore = new Restore(filedialog.FileName);
                        (Controls["restorePanel"].Controls["comboBox"] as ComboBox).Items.AddRange(restore.GetAllBackups_Date());
                        Controls["restorePanel"].Controls["restoreButton"].Click += delegate
                        {
                            restore.Backup(Controls["restorePanel"].Controls["comboBox"].Text);
                        };
                    }
                    catch (FileNotFoundException de)
                    {
                        Watcher_Change(de.Message);
                    }
                }
            }
        }

        private void CheckDir()
        {
            if (!Directory.Exists(Environment.CurrentDirectory + "\\data"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\data");
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }
        private void Minimizeawindow_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Watcher watcher = new Watcher(folderBrowserDialog.SelectedPath);
                        watcher.Change += Watcher_Change;
                        watcherStore.Add(watcher);
                        AddNewWatcherToList(folderBrowserDialog.SelectedPath);               
                    }
                    catch(Exception de)
                    {
                        Watcher_Change(de.Message);
                    }
                }
            }            
        }
        private void DeleteFolder_Click(object sender, EventArgs e)
        {
            foreach (var item in watchers)
            {
                if (item.Item1.Checked)
                {                    
                    watcherStore.Remove(item.Item2.Text);
                    item.Item1.Dispose();
                    item.Item2.Dispose();
                    item.Item2.Text = "-";
                }
            }

            RefreshWatcherList();
        }
        private void RefreshWatcherList()
        {
            int k = 0;
            for (int i = 0; i < watchers.Count; i++)
            {
                if (watchers[i].Item2.Text != "-")
                {
                    watchers[i].Item1.Top = k * 20;
                    watchers[i].Item2.Top = k * 20;
                    k++;
                }
            }

            watchers = (from x in watchers
                                where x.Item2.Text != "-"
                                select x).ToList();
        }

        private void AddNewWatcherToList(string path)
        {
            CheckBox tempcheckbos = new CheckBox()
            {
                Parent = Controls["watcherPanel"].Controls["watchersList"],
                Left = 0,
                Width = 20,
                Height = 20,
                Top = watchers.Count * 20
            };

            Label templabel = new Label {
                Parent = Controls["watcherPanel"].Controls["watchersList"],
                Left = 20,
                Width = 180,
                Height = 20,
                Text = path,
                Top = watchers.Count * 20,
                AutoEllipsis = true
            };
            watchers.Add(new Tuple<CheckBox, Label>(tempcheckbos, templabel));
        }
        

        /// <summary>
        /// Adding text to log
        /// </summary>
        /// <param name="message"></param>
        private void Watcher_Change(string message)
        {
            if ((Controls["info"] as RichTextBox).InvokeRequired)
            {
                var d = new LogWrite(Watcher_Change);
                Invoke(d, new object[] { message });
            }
            else
            {
                (Controls["info"] as RichTextBox).Text += message + "\n";
            }
        }
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }

}
