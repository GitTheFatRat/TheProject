using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _198v7.Core
{
    public static class WinRing0
    {
        private const string DLL = "WinRing0x64.dll";
        [DllImport(DLL)]
        public static extern bool InitializeOls();
        [DllImport(DLL)]
        public static extern void DeinitializeOls();
        [DllImport (DLL)]
        public static extern uint GetDllStatus();
        [DllImport(DLL)]
        public static extern bool Rdmsr(uint index, ref uint eax, ref uint edx);
        [DllImport(DLL)]
        public static extern bool Wrmsr(uint index, uint eax, uint edx);
    }
}

