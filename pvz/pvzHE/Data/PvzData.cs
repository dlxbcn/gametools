using IData;

namespace Data;

public class PvzDataLoader: IPvzDataLoader
{
    public VersionList CurrentVersion
    {
        get;
    }
    public IPvzData Data { get; private set; }

    public PvzDataLoader()
    {
    }

    public IPvzData GetPvzData(VersionList currentVersion)
    {
        // this.CurrentVersion = currentVersion;
        switch (currentVersion)
        {
            case VersionList.V3_9_9:
                return new PvzDataV399();
            default:
                return new PvzDataV399();
        }
    }
}

public class PvzDataV399: IPvzData
{
    public uint SunAddressOffset1
    {
        get{ return 0x002A9EC0;}
    }

    public uint SunAddressOffset2
    {
        get{ return 0x00000768;}
    }

    public uint SunAddressOffset3
    {
        get { return 0x00005560; }
    }
    public PvzDataV399()
    {
    }
}