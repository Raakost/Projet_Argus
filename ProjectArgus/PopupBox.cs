﻿using ArgusEntities.Entities.Reddit;
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

namespace ProjectArgus
{
    public partial class PopupBox : Form, IObserver<Object>
    {
        public PopupBox()
        {
            InitializeComponent();
        }

        public void DisplayResults(List<ArgusChild> input)
        {
            lstChildren.DataSource = null;
            ReopenForm();
            lstChildren.Invoke(new Action(() =>
            {

                lstChildren.DataSource = input;
            }));


        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        public void OnCompleted()
        {
            //throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            //throw new NotImplementedException();
        }

        public void OnNext(object value)
        {
            var data = (List<ArgusChild>)value;
            DisplayResults(data);
        }

        private void ReopenForm()
        {
            if (!this.Visible)
            {
                this.Show();
            }
            //Update form information

        }
    }
}
