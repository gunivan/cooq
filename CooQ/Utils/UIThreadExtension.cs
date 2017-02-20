using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CooQGenerate
{
    public static class UIThreadExtension
    {
        /// <summary>
        /// Execute task no avoid cross-thread not-safe-thread
        /// use this method when only process data
        /// </summary>
        /// <param name="action"></param>
        public static Task Execute<t>(this t form, Action action) where t : Form
        {
            Task task = new Task(() =>
            {
                action();
            });
            task.Start();
            return task;
        }
        public static void ExeInvoke<t>(this t control, Action action) where t : Control
        {
            InvokeControlAction<t>(control, action);
        }

        public static void InvokeControlAction<t>(t control, Action action) where t : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action<t, Action>(InvokeControlAction), new object[] { control, action });
            else
                action();
        }
        public static void MakeDoubleBuffered(this Control control, bool setting)
        {
            Type controlType = control.GetType();
            PropertyInfo pi = controlType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(control, setting, null);
        }
    }
}
