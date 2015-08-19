using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FDXS
{
    public static class MyTask
    {
        /// <summary>
        /// 每天做一次的任务
        /// </summary>
        public static void DayTask()
        {
            Timer t = new Timer();
            //10分钟检查一次
            t.Interval = 600000;
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(DoDayTask);
            t.Start();
        }

        /// <summary>
        /// 每天做多次的任务
        /// </summary>
        public static void Tasks()
        {
            //上报销售
            TimeSpan it = Settings.Default.XsTaskInterval;
            if (it.TotalSeconds == 0)
            {
                //间隔为0，表示不自动上报销售数据
                return;
            }
            Timer t = new Timer();
            t.Interval = it.TotalMilliseconds;
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(DoTasks);
            t.Start();
        }
        private static void DoTasks(object obj, ElapsedEventArgs args)
        {
            Timer t = (Timer)obj;
            t.Stop();           
            try
            {
                string file = Settings.Default.LogFile;
                Tool.CommonFunc.Log(file, "销售开始");
                System.Threading.Thread.Sleep(5000);
                SBXiaoshou();
                Tool.CommonFunc.Log(file, "销售结束");
            }
            catch (Exception ex)
            {
                //执行多次，不打log
            }

            t.Start();
        }

        private static void DoDayTask(object obj, ElapsedEventArgs args)
        {
            string file = null;
            try
            {
                file = Settings.Default.LogFile;

                //检查当前时间是否跟设定的任务时间一致
                TimeSpan ttime = Settings.Default.DayTaskTime;
                TimeSpan tnow = DateTime.Now.TimeOfDay;
                if (tnow < ttime)
                {
                    return;
                }

                //停止timer，防止重复触发
                Timer t = (Timer)obj;
                t.Stop();           

                //上报进出货
                Tool.CommonFunc.Log(file, "进货开始");
                SBJinchuhuo();
                Tool.CommonFunc.Log(file, "进货结束");
                //上报销售
                Tool.CommonFunc.Log(file, "销售开始");
                SBXiaoshou();
                Tool.CommonFunc.Log(file, "销售结束");
                //上报库存
                Tool.CommonFunc.Log(file, "库存开始");
                SBKucun();
                Tool.CommonFunc.Log(file, "库存结束");
                //备份数据库 
                BackUpDB();     

                //关机
                //System.Diagnostics.Process.Start("shutdown.exe", "-f -s -t 1");
            }
            catch (Exception ex)
            {
                Tool.CommonFunc.LogEx(file, ex);
            }
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        public static void BackUpDB()
        {
            
        }

        /// <summary>
        /// 上报库存
        /// </summary>
        public static void SBKucun()
        {
            DBContext db = IDB.GetDB();
            //取不为0的库存
            VKucun[] ks = db.GetKucunsByCond(1, null);

            //做服务接口参数
            JCSJData.TFendianKucunMX[] fks = ks.Select(r => new JCSJData.TFendianKucunMX
            {
                tiaomaid = r.id,
                shuliang = r.shuliang,
                jinhuoriqi = r.jinhuoriqi.Value
            }).ToArray();

            //调用服务接口
            JCSJWCF.ShangbaoKucun_FD(fks);
        }

        /// <summary>
        /// 上报销售数据
        /// </summary>
        public static void SBXiaoshou()
        {
            DBContext db = IDB.GetDB();
            //取得未上报的销售记录
            TXiaoshou[] xs = db.GetXiaoshousWeishangbao();
            if (xs.Count() == 0)
            {
                return;
            }

            //做借口参数
            JCSJData.TXiaoshou[] jxss = xs.Select(r => new JCSJData.TXiaoshou
            {
                oid = r.id,
                xiaoshoushijian = r.xiaoshoushijian,
                xiaoshouyuan = r.xiaoshouyuan,
                tiaomaid = r.tiaomaid,
                huiyuanid = r.huiyuanid,
                shuliang = r.shuliang,
                jinjia = r.jinjia,
                shoujia = r.shoujia,
                zhekou = r.zhekou,
                moling = r.moling,
                beizhu = r.beizhu
            }).ToArray();

            //调用服务接口
            JCSJWCF.ShangbaoXiaoshou(jxss);

            //更新本地上报时间
            int[] ids = xs.Select(r => r.id).ToArray();
            db.UpdateXiaoshouShangbaoshijian(ids, DateTime.Now);
        }

        /// <summary>
        /// 上报进出货
        /// </summary>
        public static void SBJinchuhuo()
        {
            //取得所有未上报的数据
            DBContext db = IDB.GetDB();
            TJinchuhuo[] jcs = db.GetJinchuhuosWeishangbao();
            if (jcs.Count() == 0)
            {
                return;
            }

            //做接口参数
            JCSJData.TFendianJinchuhuo[] jcjcs = jcs.Select(r => new JCSJData.TFendianJinchuhuo
            {
                oid = r.id,
                fangxiang = r.fangxiang,
                laiyuanquxiang = r.laiyuanquxiang,
                beizhu = r.beizhu,
                fashengshijian = r.charushijian,
                TFendianJinchuhuoMXes = r.TJinchuMXes.Select(mr => new JCSJData.TFendianJinchuhuoMX
                {
                    tiaomaid = mr.tiaomaid,
                    shuliang = mr.shuliang
                }).ToArray()
            }).ToArray();

            //调用服务接口
            JCSJWCF.ShangbaoJinchuhuo_FD(jcjcs);

            //更新本地上报时间
            int[] ids = jcs.Select(r => r.id).ToArray();
            db.UpdateJinchuhuoShangbaoshijian(ids, DateTime.Now);
        }
    }
}
