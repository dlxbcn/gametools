namespace WinFormsApp1;
using System.Runtime.InteropServices;

public class WinApi
{
    public const int PROCESS_ALL_ACCESS = 0x1F0FFF;
    public const uint MEM_COMMIT = 0x00001000;
    public const uint PAGE_READWRITE = 0x04;
    public const uint MEM_RELEASE = 0x00008000;
    
    public enum ProcessorArchitecture
    {
        X86 = 0,
        X64 = 9,
        Arm = -1,
        Itanium = 6,
        Unknown = 0xFFFF
    }

    // REQUIRED STRUCTS
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemInfo
    {
        public ProcessorArchitecture ProcessorArchitecture;
        public uint PageSize;
        public IntPtr MinimumApplicationAddress;
        public IntPtr MaximumApplicationAddress;
        public IntPtr ActiveProcessorMask;
        public uint NumberOfProcessors;
        public uint ProcessorType;
        public uint AllocationGranularity;
        public ushort ProcessorLevel;
        public ushort ProcessorRevision;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public IntPtr RegionSize;
        public uint State;
        public uint Protect;
        public uint Type;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct MODULEINFO
    {
        public IntPtr lpBaseOfDll;    // 模块的基地址（核心目标）
        public uint SizeOfImage;      // 模块镜像大小
        public IntPtr EntryPoint;     // 模块入口地址
    }
    
    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] data, int dwSize, ref int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int lpSize, ref int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(IntPtr hProcess);

    [DllImport("shell32.dll")]
    public static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

    [DllImport("kernel32.dll")]
    public static extern void GetSystemInfo(out SystemInfo lpSystemInfo);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);
    
    [DllImport("kernel32.dll")]
    public static extern int VirtualQuery(IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr VirtualAllocEx(
        IntPtr hProcess,
        IntPtr lpAddress,
        uint dwSize,
        uint flAllocationType,
        uint flProtect
    );
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool VirtualFreeEx(
        IntPtr hProcess,               // 目标进程的句柄（OpenProcess返回的句柄）
        IntPtr lpAddress,              // 要释放的内存起始地址（VirtualAllocEx返回的地址）
        uint dwSize,                   // 释放的内存大小（传0表示释放整个内存区域）
        uint dwFreeType                // 释放类型（MEM_RELEASE = 0x8000）
    );
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
    [DllImport("psapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool GetModuleInformation(IntPtr hProcess, IntPtr hModule, out MODULEINFO lpmodinfo, uint cbSizeModuleInfo);

}