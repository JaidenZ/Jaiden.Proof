using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DwForm
{
    //控件层
    public partial class Skin : Form
    {
        private SkinForm _skin;

        /// <summary>
        /// 获取窗体句柄
        /// </summary>
        /// <returns></returns>
        public IntPtr GetHandler()
        {
            if (this._skin == null)
            {
                throw new InvalidOperationException();
            }
            return _skin.Handle;
        }


        public Skin()
        {
            InitializeComponent();
        }



        #region Property
        private bool _skinmobile = true;
        [Category("Skin")]
        [Description("窗体是否可以移动")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinMobile
        {
            get { return _skinmobile; }
            set
            {
                if (_skinmobile != value)
                {
                    _skinmobile = value;
                }
            }
        }

        #endregion



        #region Override Event

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (SkinMobile)
            {
                //释放鼠标焦点捕获
                Win32.ReleaseCapture();
                //向当前窗体发送拖动消息
                Win32.SendMessage(this.Handle, 0x0112, 0xF011, 0);
                base.OnMouseUp(e);
            }
            base.OnMouseDown(e);
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                //启用窗口淡入淡出
                if (!DesignMode)
                {
                    //淡入特效
                    Win32.AnimateWindow(this.Handle, 150, Win32.AW_BLEND | Win32.AW_ACTIVATE);
                }
                //判断不是在设计器中
                if (!DesignMode && _skin == null)
                {
                    _skin = new SkinForm(this);
                    _skin.Show(this);
                }
                base.OnVisibleChanged(e);
            }
            else
            {
                base.OnVisibleChanged(e);
                Win32.AnimateWindow(this.Handle, 150, Win32.AW_BLEND | Win32.AW_HIDE);
            }
        }

        #endregion
    }
}
