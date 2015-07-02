using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FDXS
{
    public class Task
    {       
        /// <summary>
        /// 每天做一次的任务
        /// </summary>
        public void DayTask()
        {
            Timer t = new Timer();
            //1分钟检查一次
            t.Interval = 60000;
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(DoDayTask);
            t.Start();
        }
        public void DoDayTask(object obj, ElapsedEventArgs args)
        {
            try
            {
                
                //上报进出货
                //上报销售
                //上报库存
                //备份数据库 
            }
            catch (Exception ex)
            {
 
            }
        }


        /// <summary>
        /// 每天做多次的任务
        /// </summary>
        public void DoTasks()
        {
            //上报销售
            Timer xt = new Timer();
            xt.Interval = 60000;
        }
    }
}
