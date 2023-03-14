using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace PrintScreen
{
    public class CStage : CSprite
    {
        #region APi
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        #endregion



        public int Fps { get; }


        // 绘制线程
        private Thread _thread;
        public CStage(int fps, Point point, Size size)
        {
            this.Location = point;
            this.Size = size;
            Fps = fps;

            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            CStage.Graphics = Graphics.FromHdc(desktopPtr);


            _thread = new Thread(() =>
            {
                while (true)
                {
                    Render();
                    Thread.Sleep(1000 / Fps);
                }
            });
            _thread.IsBackground = true;
            _thread.Start();
        }

        // public override void Render()
        // {
        //    
        //   
        //     // 子节点重绘
        //     base.Render();
        //     
        //   
        // }
    }
}


