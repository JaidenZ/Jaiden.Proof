namespace DwForm
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    //绘图层
    public partial class SkinForm : Form
    {
        private Skin _skin;

        public SkinForm(Skin form)
        {
            _skin = form;
            InitializeComponent();

            //置顶窗体
            TopMost = _skin.TopMost;
            _skin.BringToFront();
            //是否在任务栏显示
            ShowInTaskbar = false;
            //无边框模式
            FormBorderStyle = FormBorderStyle.None;
            //设置绘图层显示位置
            this.Location = new Point(_skin.Location.X - 5, _skin.Location.Y - 5);
            //设置ICO
            Icon = _skin.Icon;
            ShowIcon = _skin.ShowIcon;
            //设置大小
            Width = _skin.Width + 10;
            Height = _skin.Height + 10;
            //设置标题名
            Text = _skin.Text;
            //绘图层窗体移动
            _skin.LocationChanged += new EventHandler(Main_LocationChanged);
            _skin.SizeChanged += new EventHandler(Main_SizeChanged);
            _skin.VisibleChanged += new EventHandler(Main_VisibleChanged);


            CanPenetrate();
        }

        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = _skin.Visible;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            //设置大小
            Width = _skin.Width + 10;
            Height = _skin.Height + 10;
        }

        private void Main_LocationChanged(object sender, EventArgs e)
        {
            Location = new Point(_skin.Left - 5, _skin.Top - 5);
        }





        private void CanPenetrate()
        {
            int intExTemp = Win32.GetWindowLong(this.Handle, Win32.GWL_EXSTYLE);
            int oldGWLEx = Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, Win32.WS_EX_TRANSPARENT | Win32.WS_EX_LAYERED);
        }
    }
}
