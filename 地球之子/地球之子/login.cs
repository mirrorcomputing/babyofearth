using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 地球之子
{
    public partial class login : CCWin.CCSkinMain
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            loadsetting setting = new loadsetting();

            string bg_CloseDownBack = Convert.ToString(((IDictionary<string, object>)loadsetting.set["CloseBox"])["CloseDownBack"]);
            CloseDownBack = Image.FromFile(bg_CloseDownBack);
            CloseMouseBack = Image.FromFile(bg_CloseDownBack);
            string bg_CloseNormlBack = Convert.ToString(((IDictionary<string, object>)loadsetting.set["CloseBox"])["CloseNormlBack"]);
            CloseNormlBack = Image.FromFile(bg_CloseNormlBack);

            string bg_MiniDownBack = Convert.ToString(((IDictionary<string, object>)loadsetting.set["MinimizeBox"])["MiniDownBack"]);
            MiniDownBack = Image.FromFile(bg_MiniDownBack);
            MiniMouseBack = Image.FromFile(bg_MiniDownBack);
            string bg_MiniNormlBack = Convert.ToString(((IDictionary<string, object>)loadsetting.set["MinimizeBox"])["MiniNormlBack"]);
            MiniNormlBack = Image.FromFile(bg_MiniNormlBack);
        }

    }
}
