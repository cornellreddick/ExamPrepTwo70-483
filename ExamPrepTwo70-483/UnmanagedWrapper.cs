using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ExamPrepTwo70_483
{
    // implementing IDisposable and a finalizer 
    class UnmanagedWrapper : IDisposable
    {
        private IntPtr unmanagedBuffer;
        public FileStream Stream { get; private set; }

        public UnmanagedWrapper()
        {
            CreateBuffer();
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }

        private void CreateBuffer()
        {
            byte[] data = new byte[1024];
            new Random().NextBytes(data);
            unmanagedBuffer = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, unmanagedBuffer, data.Length);
        }

        ~UnmanagedWrapper()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Marshal.FreeHGlobal(unmanagedBuffer);
            if (disposing)
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }
    }
}
