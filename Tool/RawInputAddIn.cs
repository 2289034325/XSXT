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

        //����ɨ��ǹ�¼�
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
            //ע��ɨ����������
            if (_scanName == null)
            {
                OnScan(e.KeyPressEvent.DeviceName);
            }
            else if (e.KeyPressEvent.DeviceName.Equals(_scanName))
            {
                _rawinput.AddMessageFilter();
                //����UPʱ���ռ��ַ�����Ȼ���ظ�
                if (e.KeyPressEvent.KeyPressState == "MAKE")
                {
                    return;
                }
                //����ǻس��������ж��Ƿ񴥷��¼�
                if (e.KeyPressEvent.VKeyName == "ENTER")
                {
                    if (_kps.Count == 13)
                    {
                        string tiaoma = _kps.Aggregate((a, b) => { return a + b; });
                        //��ջ���
                        _kps.Clear();
                        //_rawinput.RemoveMessageFilter();
                        OnScan(tiaoma);
                    }
                }
                //��������뻺��
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
