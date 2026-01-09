using IData;

namespace Data;

public class PvzDataV399 : IPvzData
{
    public uint SunAddressOffset1
    {
        get { return 0x002A9EC0; }
    }

    public uint SunAddressOffset2
    {
        get { return 0x00000768; }
    }

    public uint SunAddressOffset3
    {
        get { return 0x00005560; }
    }

    public uint CoolDown
    {
        get { return 0x00087296; }
    }

    public uint ZombiesWeek
    {
        get { return 0x0013178A; }
    }

    public uint SilverCoinsOffset1
    {
        get { return 0x002A9EC0; }
    }

    public uint SilverCoinsOffset2
    {
        get { return 0x0000082C; }
    }

    public uint SilverCoinsOffset3
    {
        get { return 0x00000204 + 0x00000004 * 1; }
    }

    public uint GoldCoinsOffset1
    {
        get { return 0x002A9EC0; }
    }

    public uint GoldCoinsOffset2
    {
        get { return 0x00082C; }
    }

    public uint GoldCoinsOffset3
    {
        get { return 0x204 + 0x4 * 2; }
    }

    public uint DiamondCoinsOffset1
    {
        get { return 0x002A9EC0; }
    }

    public uint DiamondCoinsOffset2
    {
        get { return 0x00082C; }
    }

    public uint DiamondCoinsOffset3
    {
        get { return 0x204 + 0x4 * 3; }
    }

    public uint TreeOffset1
    {
        get { return 0x002A9EC0; }
    }

    public uint TreeOffset2
    {
        get { return 0x00082C; }
    }

    public uint TreeOffset3
    {
        get { return 0x30 + 0x4 * 0x31; }
    }

    public uint HatOffset
    {
        get { return 0x00131066; }
    }

    public byte[] HatShellCode
    {
        get { return [0x75, 0x11]; }
    }

    public uint HandleOffset
    {
        get { return 0x00130CB1; }
    }

    public byte[] HandleShellCode
    {
        get { return [0x75, 0x17]; }
    }

    public uint InvincibilityOffset
    {
        get { return 0x004101B1; }
    }

    public byte[] InvincibilityShellCode
    {
        get { return [0x83, 0x6D, 0x40, 0x01]; }
    }

    public byte[] DeInvincibilityShellCode
    {
        get { return [0x83, 0x6D, 0x40, 0x01]; }
    }

    public uint AllCardUnlockOffset
    {
        get { return 0x00053B20; }
    }

    public byte[] AllCardUnlockShellCode
    {
        get { return [0xB0, 0x01, 0xC3]; }
    }

    public byte[] AllCardLockShellCode
    {
        get { return [0xE9, 0xDB, 0xC4, 0x4D, 0x00]; }
    }

    public PvzDataV399()
    {
    }
}