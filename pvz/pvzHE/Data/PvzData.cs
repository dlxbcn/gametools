using IData;

namespace Data;

public class PvzDataLoader: IPvzDataLoader
{
    public PvzDataLoader()
    {
    }

    public IPvzData GetPvzData(VersionList currentVersion)
    {
        switch (currentVersion)
        {
            case VersionList.V3_9_9:
                return new PvzDataV399();
            default:
                return new PvzDataV399();
        }
    }
}