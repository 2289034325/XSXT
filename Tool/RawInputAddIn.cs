using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using RawInput_dll;

namespace Tool
{
    public class RawInputAddIn
    {
        private List<string> _kps;

        //定义扫描枪事件
        private readonly RawInput _rawinput;
        public delegate void UsbScan(string tm);
        public event UsbScan OnScan;

        private string _scanName;

        public RawInputAddIn(string scanName, IntPtr Handle, UsbScan HandleScan)
        {
            _rawinput = new RawInput(Handle, true);
            _rawinput.KeyPressed += OnRawKeyPressed;
            _kps = new List<string>();
            OnScan += new UsbScan(HandleScan);
            _scanName = scanName;
        }

        private void OnRawKeyPressed(object sender, RawInputEventArg e)
        {
            //注册扫码器的名称
            if (_scanName == null)
            {
                OnScan(e.KeyPressEvent.DeviceName);
            }
            else if (e.KeyPressEvent.DeviceName.Equals(_scanName))
            {
                _rawinput.AddMessageFilter();
                //按键UP时再收集字符，不然会重复
                if (e.KeyPressEvent.KeyPressState == "MAKE")
                {
                    return;
                }
                //如果是回车键，就判断是否触发事件
                if (e.KeyPressEvent.VKeyName == "ENTER")
                {
                    if (_kps.Count == 13)
                    {
                        string tiaoma = _kps.Aggregate((a, b) => { return a + b; });
                        //清空缓存
                        _kps.Clear();
                        //_rawinput.RemoveMessageFilter();
                        OnScan(tiaoma);
                    }
                }
                //将输入放入缓存
                else
                {
                    if (_kps.Count == 13)
                    {
                        _kps.RemoveAt(0);
                    }
                    _kps.Add(e.KeyPressEvent.VKeyName);
                }
            }
            else
            {
                _rawinput.RemoveMessageFilter();
            }
        }
    }
}
