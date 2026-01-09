using System.ComponentModel;

namespace IData;

public enum VersionList
{
    [Description("v3.9.9")]
    V3_9_9
}

public interface IPvzDataLoader
{
    IPvzData GetPvzData(VersionList currentVersion);
}
public interface IPvzData
{
    uint SunAddressOffset1 { get;}
    uint SunAddressOffset2 { get;}
    uint SunAddressOffset3 { get;}
}