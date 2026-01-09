using System.ComponentModel;

namespace IData;

public enum VersionList
{
    [Description("v3.9.9")]
    V3_9_9,
    
    [Description("v3.14")]
    V3_14
}

public interface IPvzDataLoader
{
    IPvzData GetPvzData(VersionList currentVersion);
}
public interface IPvzData
{
    // 阳光
    uint SunAddressOffset1 { get;}
    uint SunAddressOffset2 { get;}
    uint SunAddressOffset3 { get;}
    
    // 植物种植无冷却
    uint CoolDown { get; }
    
    // 僵尸削弱
    uint ZombiesWeek { get; }
    
    // 银币
    uint SilverCoinsOffset1 { get; }
    uint SilverCoinsOffset2 { get; }
    uint SilverCoinsOffset3 { get; }
    
    // 金币
    uint GoldCoinsOffset1 { get; }
    uint GoldCoinsOffset2 { get; }
    uint GoldCoinsOffset3 { get; }
    
    // 钻石
    uint DiamondCoinsOffset1 { get; }
    uint DiamondCoinsOffset2 { get; }
    uint DiamondCoinsOffset3 { get; }
    
    // 智慧树长高
    uint TreeOffset1 { get; }
    uint TreeOffset2 { get; }
    uint TreeOffset3 { get; }
    
    // 帽子削弱
    uint HatOffset { get; }
    byte[] HatShellCode { get; }
    
    // 手持削弱
    uint HandleOffset { get; }
    byte[] HandleShellCode { get; }
    
    // 植物无敌
    uint InvincibilityOffset { get; }
    byte[] InvincibilityShellCode { get; }
    byte[] DeInvincibilityShellCode{ get; }
    
    // 卡牌解锁
    uint AllCardUnlockOffset { get; }
    byte[] AllCardUnlockShellCode { get; }
    byte[] AllCardLockShellCode { get; }
}