using System.Buffers.Binary;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using IData;
using Timer = System.Threading.Timer;

namespace WinFormsApp1;

using System.Diagnostics;


public partial class Form1 : Form
{
    private const string Title = "植物大战僵尸杂交版";
    // private const string Version = "v3.9.9";
    
    private string Version { get; set; }
    private int GameId { get; set; }
    private IntPtr GameProcessId { get; set; }

    private IntPtr BaseAddress { get; set; }

    private byte[] CoolBackupData { get; set; }

    private IntPtr UnlockPlantAddress { get; set; }
    
    private IPvzData PvzData { get; set; }

    public Form1()
    {
        InitializeComponent();
        LoadVersionList();
    }
    
    private void LoadVersionList()
    {
        VersionList[] list = Enum.GetValues<VersionList>();
        comboBoxVer.Items.Clear();
        foreach (VersionList value in list)
        {
            comboBoxVer.Items.Add(value.GetDescription());
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        this.Text = $"{Title}修改器";
        if (comboBoxVer.Items.Count > 0)
        {
            comboBoxVer.SelectedIndex = 0;
            Version = comboBoxVer.SelectedItem.ToString();
        }
    }
    
    private bool ReadGameInfo()
    {
        string windowTitle = $"{Title}{Version}";
        if (string.IsNullOrEmpty(windowTitle))
        {
            MessageBox.Show("请输入游戏窗口标题", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // 获取所有的进程
        Process[] processes = Process.GetProcesses();
        // 循环所有进程，根据窗口标题找到游戏窗口
        foreach (Process process in processes)
        {
            // 比较标题
            //if (process.MainWindowTitle.Trim() == windowTitle.Trim())
            if (process.MainWindowTitle.Trim().StartsWith(Title+"v3"))
            {
                GameId = process.Id; // 保存游戏进程ID
                if (process.MainModule != null)
                {
                    BaseAddress = process.MainModule.BaseAddress; // 保存游戏进程基地址
                }
                break;
            }
        }

        // 查找游戏窗口
        if (GameId == 0)
        {
            MessageBox.Show("没有找到游戏窗口", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private IPvzData LoadData(VersionList version)
    {
        // todo: 修改DLL路径
        string exePath = Process.GetCurrentProcess().MainModule.FileName;
        string exeDir = Path.GetDirectoryName(exePath);
        string dllPath = Path.Combine(exeDir, "Data.dll");
        Assembly assembly = Assembly.LoadFrom(dllPath);
        // Assembly assembly = Assembly.LoadFrom("D:\\code\\github\\gametools\\pvz\\pvzHE\\WinFormsApp1\\bin\\Debug\\net10.0-windows\\Data.dll");
        if (assembly == null)
        {
            throw new Exception("加载数据模块错误");
        }
        Type type = assembly.GetType("Data.PvzDataLoader");
        if (type == null)
        {
            throw new Exception("加载数据模块类型错误");
        }
        IPvzDataLoader instance = Activator.CreateInstance(type) as IPvzDataLoader;
        if (instance == null)
        {
            throw new Exception("创建数据模块错误");
        }
        IPvzData data = instance.GetPvzData(version);
        return data;
    }
    private void comboBoxVer_SelectedIndexChanged(object sender, EventArgs e)
    {
        string v = comboBoxVer.SelectedItem.ToString();
        Enum.TryParse<VersionList>(v, out VersionList version);
        IPvzData data = LoadData(version);
        this.PvzData = data;
    }
    private void btnGo_Click(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        if (!OpenGameProcessGame())
        {
            MessageBox.Show("打开游戏进程错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        
        //IntPtr address1 = this.BaseAddress + 0x002A9EC0;
        IntPtr address1 = new IntPtr(this.BaseAddress + this.PvzData.SunAddressOffset1);
        int dataSize = Marshal.SizeOf<IntPtr>();//return Marshal.PtrToStructure<T>(buffer);
        byte [] value1 = new byte[dataSize];
        int read = 0;
        if (!ReadMemery(address1, ref value1, dataSize, ref read))
        {
            MessageBox.Show("读取阳光数据错误1！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        
        //IntPtr address2 = new IntPtr(BitConverter.ToInt64(value1)+ 0x00000768);
        IntPtr address2 = new IntPtr(BitConverter.ToInt64(value1) + this.PvzData.SunAddressOffset2);
        byte [] value2 = new byte[dataSize];
        if (!ReadMemery(address2, ref value2, dataSize, ref read))
        {
            MessageBox.Show("读取阳光数据错误2！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        //IntPtr address = new IntPtr(BitConverter.ToInt64(value2) + 0x00005560);
        IntPtr address = new IntPtr(BitConverter.ToInt64(value2) + this.PvzData.SunAddressOffset3);
        dataSize = Marshal.SizeOf<Int32>();
        byte[] sunData = new byte[dataSize];
        if (!ReadMemery(address, ref sunData, dataSize, ref read))
        {
            MessageBox.Show("读取阳光数据错误3！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        int sun = (int)numSun.Value;
        byte[] sunByteData = BitConverter.GetBytes(sun);
        int wrote;
        bool success = WriteMemery(address, sunByteData, out wrote);
        if (!success || wrote == 0)
        {
            MessageBox.Show("写入阳光数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        end:
        CloseGameProcess();
    }

    private void checkBoxCool_CheckedChanged(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        if (!OpenGameProcessGame())
        {
            MessageBox.Show("打开游戏进程错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        // IntPtr coolAddress = this.BaseAddress + 0x00087296;
        IntPtr coolAddress = new IntPtr(this.BaseAddress + PvzData.CoolDown);
        // byte [] writeData = checkWeek.Checked ? new byte[] { 0x90, 0x90} : new byte[] { 0xxx,0xxx };
        if (this.checkBoxCool.Checked)
        {
            int read = 0;
            byte[] buffer = new byte[2];
            if (!WinApi.ReadProcessMemory(GameProcessId, coolAddress, buffer, buffer.Length, ref read))
            {
                MessageBox.Show("读取植物种植无冷却失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }

            CoolBackupData = buffer;

            byte[] data = [0x90, 0x90];
            if (!WinApi.WriteProcessMemory(GameProcessId, coolAddress, data, data.Length, ref read))
            {
                MessageBox.Show("设置植物种植无冷却失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }
        }
        else
        {
            int written = 0;
            bool success = WinApi.WriteProcessMemory(GameProcessId, 
                coolAddress, 
                CoolBackupData, 
                CoolBackupData.Length,
                ref written);
            if (!success || written == 0)
            {
                MessageBox.Show("恢复植物种植冷却失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }
        }
        end:
        WinApi.CloseHandle(GameProcessId);
    }


    private void checkAutoFillSun_CheckedChanged(object sender, EventArgs e)
    {
        timerAutoFillSun.Enabled = checkAutoFillSun.Checked;
    }

    private void timerAutoFillSun_Tick(object sender, EventArgs e)
    {
        // this.btnGo.Invoke(new Action()=>{
        // });
        Task.Run(() => { this.btnGo_Click(sender, e); });
    }

    private void checkWeek_CheckedChanged(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        // IntPtr address = this.BaseAddress + 0x0013178A;
        IntPtr address = new IntPtr(this.BaseAddress + PvzData.ZombiesWeek);
        OpenGameProcessGame();
        byte[] buffer = new byte[2];
        int read = 0;
        if (!ReadMemery(address, ref buffer, buffer.Length ,ref read))
        {
            MessageBox.Show("读取僵尸地址失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        byte [] writeData = checkWeek.Checked ? new byte[] { 0x90, 0x90} : new byte[] { 0x7F,0x1D };
        int wrote;
        bool success = WriteMemery(address, writeData, out wrote);
        if (!success || wrote == 0)
        {
            MessageBox.Show("僵尸数据写入失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        end:
        CloseGameProcess();
    }

    private bool ReadMemery(IntPtr address, ref byte[] buffer, int size, ref int read)
    {
        WinApi.MEMORY_BASIC_INFORMATION mbi = new WinApi.MEMORY_BASIC_INFORMATION();
        int result = WinApi.VirtualQuery(address, out mbi, Marshal.SizeOf(mbi));
        if (result == 0)
        {
            // 虚拟地址
            return WinApi.ReadProcessMemory(GameProcessId, address, buffer, size, ref read);
        }
        else
        {
            return WinApi.ReadProcessMemory(GameProcessId, address, buffer, size, ref read);
        }
    }

    private bool WriteMemery(IntPtr address, byte[] buffer, out int wrote)
    {
        wrote = 0;
        return WinApi.WriteProcessMemory(GameProcessId, address, buffer, buffer.Length, ref wrote);
    }
    
    private bool OpenGameProcessGame()
    {
        this.GameProcessId = WinApi.OpenProcess(WinApi.PROCESS_ALL_ACCESS, false, GameId);
        // return this.GameProcessId == IntPtr.Zero;
        if (this.GameProcessId != IntPtr.Zero)
        {
            return true;
        }

        return false;
    }

    private void CloseGameProcess()
    {
        WinApi.CloseHandle(GameProcessId);
    }

    private void btnChangeSilverCoins_Click(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }

        if (!OpenGameProcessGame())
        {
            MessageBox.Show("打开游戏进程错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        // IntPtr address1 = this.BaseAddress + 0x002A9EC0;
        IntPtr address1 = new IntPtr(this.BaseAddress + PvzData.SilverCoinsOffset1);
        byte [] value1 = new byte[8];
        int read = 0;
        if (!ReadMemery(address1, ref value1, value1.Length,ref read))
        {
            MessageBox.Show("读取银币一级地址错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        // IntPtr address2 = new IntPtr(BitConverter.ToInt64(value1) + 0x0000082C);
        IntPtr address2 = new IntPtr(BitConverter.ToInt64(value1) + PvzData.SilverCoinsOffset2);
        byte [] value2 = new byte[8];
        if (!ReadMemery(address2, ref value2, value2.Length,ref read))
        {
            MessageBox.Show("读取银币二级地址错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        // 这里必须用ToInt32，不能用ToInt64，还不知道原因
        //IntPtr address = new IntPtr(BitConverter.ToInt32(value2) + 0x00000204 + (0x00000004 * 1));
        IntPtr address = new IntPtr(BitConverter.ToInt32(value2) + PvzData.SilverCoinsOffset3);
        byte[] coinsData = new byte[4];
        if (!ReadMemery(address, ref coinsData, coinsData.Length,ref read))
        {
            MessageBox.Show("读取银币数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        int coins = (int)numSilverCoins.Value;
        byte[] coinsByteData = BitConverter.GetBytes(coins);
        int wrote = 0;
        bool success = WriteMemery(address, coinsByteData, out wrote);
        if (!success || wrote == 0)
        {
            MessageBox.Show("写入银币数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        end:
        CloseGameProcess();
    }

    private void btnChangeGoldCoins_Click(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        OpenGameProcessGame();
        // IntPtr address1 = new IntPtr(this.BaseAddress + 0x002A9EC0);
        IntPtr address1 = new IntPtr(this.BaseAddress + PvzData.GoldCoinsOffset1);
        byte [] value1 = new byte[8];
        int read = 0;
        if (!ReadMemery(address1, ref value1, value1.Length, ref read))
        {
            MessageBox.Show("读取金币一级地址错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        // IntPtr address2 = new IntPtr(BitConverter.ToInt32(value1) + 0x00082C);
        IntPtr address2 = new IntPtr(BitConverter.ToInt32(value1) + PvzData.GoldCoinsOffset2);
        byte [] value2 = new byte[8];
        if (!ReadMemery(address2, ref value2, value2.Length, ref read))
        {
            MessageBox.Show("读取金币二级地址错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        
        // IntPtr address = new IntPtr(BitConverter.ToInt32(value2) + 0x204 + (0x4 * 2));
        IntPtr address = new IntPtr(BitConverter.ToInt32(value2) + PvzData.GoldCoinsOffset3);
        byte[] coinsData = new byte[4];
        if (!ReadMemery(address, ref coinsData, coinsData.Length, ref read))
        {
            MessageBox.Show("读取金币数据错误3！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        int coins = (int)numGoldCoins.Value;
        byte[] coinsByteData = BitConverter.GetBytes(coins);
        int wrote = 0;
        bool success = WriteMemery(address, coinsByteData, out wrote);
        if (!success || wrote == 0)
        {
            MessageBox.Show("写入金币数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        end:
        CloseGameProcess();
    }

    private void btnChangeDiamond_Click(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        OpenGameProcessGame();
        // IntPtr address1 = this.BaseAddress + 0x002A9EC0;
        IntPtr address1 = new IntPtr(this.BaseAddress + PvzData.DiamondCoinsOffset1);
        byte [] value1 = new byte[4];
        int read = 0;
        if (!ReadMemery(address1, ref value1, value1.Length, ref read))
        {
            MessageBox.Show("读取钻石数据错误1！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        // IntPtr address2 = BitConverter.ToInt32(value1) + 0x00082C;
        IntPtr address2 = new IntPtr(BitConverter.ToInt32(value1) + PvzData.DiamondCoinsOffset2);
        byte [] value2 = new byte[4];
        if (!ReadMemery(address2, ref value2, value2.Length, ref read))
        {
            MessageBox.Show("读取钻石数据错误2！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        
        // IntPtr address = BitConverter.ToInt32(value2) + 0x204 + (0x4 * 3);
        IntPtr address = new IntPtr(BitConverter.ToInt32(value2) + PvzData.DiamondCoinsOffset3);
        byte[] coinsData = new byte[4];
        if (!ReadMemery(address, ref coinsData, coinsData.Length, ref read))
        {
            MessageBox.Show("读取钻石数据错误3！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        int coins = (int)numDiamond.Value;
        byte[] coinsByteData = BitConverter.GetBytes(coins);
        int wrote = 0;
        if (!WriteMemery(address, coinsByteData, out wrote))
        {
            MessageBox.Show("写入钻石数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        if (wrote == 0)
        {
            //MessageBox.Show("写入钻石数据成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("写入钻石数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        end:
        CloseGameProcess();
    }

    private void btnTree_Click(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        OpenGameProcessGame();
        // IntPtr address1 = this.BaseAddress + 0x002A9EC0;
        IntPtr address1 = new IntPtr(this.BaseAddress + PvzData.TreeOffset1);
        byte [] value1 = new byte[4];
        int read = 0;
        if (!ReadMemery(address1, ref value1, value1.Length, ref read))
        {
            MessageBox.Show("读取智慧树数据错误1！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        // IntPtr address2 = BitConverter.ToInt32(value1) + 0x00082C;
        IntPtr address2 = new IntPtr(BitConverter.ToInt32(value1) + PvzData.TreeOffset2);
        byte [] value2 = new byte[4];
        if (!ReadMemery(address2, ref value2, value2.Length, ref read))
        {
            MessageBox.Show("读取智慧树数据错误2！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        
        // IntPtr address = BitConverter.ToInt32(value2) + 0x30 + (0x4 * 0x31);
        IntPtr address = new IntPtr(BitConverter.ToInt32(value2) + PvzData.TreeOffset3);
        byte[] treeData = new byte[4];
        if (!ReadMemery(address, ref treeData, treeData.Length, ref read))
        {
            MessageBox.Show("读取智慧树数据错误3！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        
        int height = (int)numTree.Value + BitConverter.ToInt32(treeData);
        byte[] heightByteData = BitConverter.GetBytes(height);
        int wrote = 0;
        if (!WriteMemery(address, heightByteData, out wrote))
        {
            MessageBox.Show("写入智慧树数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }

        if (wrote == 0)
        {
            //MessageBox.Show("写入智慧树数据成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("写入智慧树数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        end:
        CloseGameProcess();
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        About about = new About();
        about.ShowDialog();
    }

    private void checkHat_CheckedChanged(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        // IntPtr address = this.BaseAddress + 0x00131066;
        IntPtr address = new IntPtr(this.BaseAddress + PvzData.HatOffset);
        OpenGameProcessGame();
        byte[] buffer = new byte[2];
        int read = 0;
        if (!ReadMemery(address, ref buffer, buffer.Length, ref read))
        {
            MessageBox.Show("读取帽子地址失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        // byte [] writeData = checkHat.Checked ? new byte[] { 0x90, 0x90} : new byte[] { 0x75,0x11 };
        byte [] writeData = checkHat.Checked ? new byte[] { 0x90, 0x90} : PvzData.HatShellCode;
        int wrote;
        bool success = WriteMemery(address, writeData, out wrote);
        if (!success || wrote == 0)
        {
            MessageBox.Show("帽子数据写入失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        end:
        CloseGameProcess();
    }

    private void checkHandle_CheckedChanged(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        // IntPtr address = this.BaseAddress + 0x00130CB1;
        IntPtr address = new IntPtr(this.BaseAddress + PvzData.HandleOffset);
        OpenGameProcessGame();
        byte[] buffer = new byte[2];
        int read = 0;
        if (!ReadMemery(address, ref buffer, buffer.Length,ref read))
        {
            MessageBox.Show("读取手持地址失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        // byte [] writeData = checkHandle.Checked ? new byte[] { 0x90, 0x90} : new byte[] { 0x75,0x17 };
        byte [] writeData = checkHandle.Checked ? new byte[] { 0x90, 0x90} : PvzData.HandleShellCode;
        int wrote;
        bool success = WriteMemery(address, writeData, out wrote);
        if (!success || wrote == 0)
        {
            MessageBox.Show("手持数据写入失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        end:
        CloseGameProcess();
    }

    private void checkInvincibility_CheckedChanged(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        // IntPtr address = this.BaseAddress + 0x004101B1;
        IntPtr address = new IntPtr(this.BaseAddress + PvzData.InvincibilityOffset);
        OpenGameProcessGame();
        byte[] buffer = new byte[4];
        int read = 0;
        if (!ReadMemery(address, ref buffer, buffer.Length,ref read))
        {
            MessageBox.Show("读取植物无敌地址失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        // 植物无敌原理：每当僵尸攻击植物时，植物的都会被攻击1次，现在把攻击次数改为0，植物就无敌了
        // byte [] writeData = checkInvincibility.Checked ? new byte[] { 0x83, 0x6D, 0x40, 0x00 } : new byte[] {  0x83, 0x6D, 0x40, 0x01 };
        byte [] writeData = checkInvincibility.Checked ? PvzData.InvincibilityShellCode : PvzData.DeInvincibilityShellCode;
        int wrote;
        bool success = WriteMemery(address, writeData, out wrote);
        if (!success || wrote == 0)
        {
            MessageBox.Show("植物无敌数据写入失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            goto end;
        }
        end:
        CloseGameProcess();
    }

    private void checkUnLock_CheckedChanged(object sender, EventArgs e)
    {
        if (!ReadGameInfo())
        {
            return;
        }
        OpenGameProcessGame();
        // long TARGET_HOOK_ADDRESS = this.BaseAddress + 0x00053B20;
        long TARGET_HOOK_ADDRESS = this.BaseAddress + PvzData.AllCardUnlockOffset;
        if (checkUnLockAllPlant.Checked)
        {
            UnlockPlantAddress = WinApi.VirtualAllocEx(
                GameProcessId,
                IntPtr.Zero,
                64, // 分配64字节
                WinApi.MEM_COMMIT,
                WinApi.PAGE_READWRITE
            );
            if (UnlockPlantAddress == IntPtr.Zero)
            {
                MessageBox.Show("解锁所有植物分配地址失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }

            // 步骤3：构造shellcode（MOV AL,1 + RET）并写入分配的内存
            // MOV AL,1 → 0xB0 0x01；RET → 0xC3
            // byte[] shellcode = new byte[] { 0xB0, 0x01, 0xC3 };
            // 汇编指令
            // PUSH EAX       ; 保存EAX寄存器（包含AL）到栈中
            // MOV AL, 1      ; 修改AL为1
            // POP EAX        ; 恢复EAX寄存器（仅AL被修改，其他位不变）
            // RET            ; 返回
            // 0x50 = PUSH EAX；0x58 = POP EAX
            //byte[] safe_shellcode = new byte[] { 0x50, 0xB0, 0x01, 0x58, 0xC3 };
            byte[] shellcode = PvzData.AllCardUnlockShellCode;
            int written = 0;
            bool success = WinApi.WriteProcessMemory(
                GameProcessId,
                UnlockPlantAddress,
                shellcode,
                shellcode.Length,
                ref written
            );
            if (!success || written != shellcode.Length)
            {
                MessageBox.Show("写入shellcode失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }

            // 步骤4：计算相对跳转偏移（实现Python的calculate_call_address）
            // 相对跳转公式：目标地址 - (当前地址 + 5) → 5是E9指令的长度
            long currentAddress = TARGET_HOOK_ADDRESS + 5; // 0x00453B20 + 5 = 0x00453B25
            long targetAddress = UnlockPlantAddress.ToInt64();
            int jumpOffset = (int)(targetAddress - currentAddress); // 相对偏移

            // 步骤5：构造JMP指令（E9 + 4字节偏移，小端序）
            byte[] jmpInstruction = new byte[5];
            jmpInstruction[0] = 0xE9; // E9是JMP指令的操作码
            // 将偏移转换成4字节小端序，写入jmpInstruction[1-4]
            BinaryPrimitives.WriteInt32LittleEndian(new Span<byte>(jmpInstruction, 1, 4), jumpOffset);
            // 步骤6：将JMP指令写入0x00453B20地址
            written = 0;
            success = WinApi.WriteProcessMemory(
                GameProcessId,
                (IntPtr)TARGET_HOOK_ADDRESS, 
                jmpInstruction,
                jmpInstruction.Length, // 写入5字节（E9 + 4字节偏移）
                ref written
            );
            if (!success || written != jmpInstruction.Length)
            {
                MessageBox.Show("写入shellcode失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }
        }
        else
        {
            if (UnlockPlantAddress == IntPtr.Zero)
            {
                MessageBox.Show("内存指针不存在，不能恢复！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }
            bool success = WinApi.VirtualFreeEx(
                GameProcessId,
                UnlockPlantAddress,
                0,          // 0表示释放整个已分配的内存区域（无需指定大小）
                WinApi.MEM_RELEASE // 释放类型：回收内存
            );
            if (!success)
            {
                MessageBox.Show("释放内存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }
            // 恢复原跳转代码: JMP 0x004DC4DB
            // byte[] restoreJmp = new byte[] { 0xE9, 0xDB, 0xC4, 0x4D, 0x00 };
            byte[] restoreJmp = PvzData.AllCardLockShellCode;
            int written = 0;
            success = WinApi.WriteProcessMemory(
                GameProcessId,
                (IntPtr)TARGET_HOOK_ADDRESS,
                restoreJmp,
                restoreJmp.Length, // 写入5字节
                ref written
            );
            if (!success || written != restoreJmp.Length)
            {
                MessageBox.Show("恢复代码失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }
        }

        end:
        CloseGameProcess();
    }
}

public static class EnumExtensions
{
    public static string GetDescription(this Enum enumValue)
    {
        FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
        DescriptionAttribute? attr = field?.GetCustomAttribute<DescriptionAttribute>();
        return attr?.Description ?? enumValue.ToString();
    }
}