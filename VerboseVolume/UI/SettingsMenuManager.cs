using System;
using Zenject;
using VerboseVolume.Configuration;
using JetBrains.Annotations;
using UnityEngine;

namespace VerboseVolume.UI;

[UsedImplicitly]
internal class SettingsMenuManager : IInitializable, IDisposable
{
    private static PluginConfig Config => PluginConfig.Instance;
    
    private const string MenuName = nameof(VerboseVolume);
    private const string ResourcePath = nameof(VerboseVolume) + ".UI.BSML.Settings.bsml";
    
    [UsedImplicitly] public string PercentageFormatter(float x) => x.ToString("0%");
    [UsedImplicitly] public string DoublePercentageFormatter(float x) => (x*2).ToString("0%");
    
    public void Initialize()
    {
#if V1_40_3
        BeatSaberMarkupLanguage.Settings.BSMLSettings.Instance?.AddSettingsMenu(MenuName, ResourcePath, this);
#else
        BeatSaberMarkupLanguage.Settings.BSMLSettings.instance?.AddSettingsMenu(MenuName, ResourcePath, this);
#endif
    }

    public void Dispose()
    {
#if V1_40_3
        BeatSaberMarkupLanguage.Settings.BSMLSettings.Instance?.RemoveSettingsMenu(this);
#else
        BeatSaberMarkupLanguage.Settings.BSMLSettings.instance?.RemoveSettingsMenu(this);
#endif
    }

    protected float MenuMusicVolume
    {
        get => Mathf.Clamp(Config.MenuMusicVolume, 0f, 0.5f);
        set
        {
            Config.MenuMusicVolume = value;
            Patches.VolumePatches.PreviewPlayer._volume = value;
        }
    }
    protected float GameMusicVolume
    {
        get => Mathf.Clamp(Config.GameMusicVolume, 0f, 1f);
        set => Config.GameMusicVolume = value;
    }

    protected float UIVolume
    {
        get => Mathf.Clamp(Config.UIVolume, 0f, 1f);
        set => Config.UIVolume = value;
    }
    
    protected float GoodCutVolume
    {
        get => Mathf.Clamp(Config.GoodCutVolume, 0f, 1f);
        set => Config.GoodCutVolume = value;
    }
    protected float BadCutVolume
    {
        get => Mathf.Clamp(Config.BadCutVolume, 0f, 1f);
        set => Config.BadCutVolume = value;
    }
    protected float BombCutVolume
    {
        get => Mathf.Clamp(Config.BombCutVolume, 0f, 1f);
        set => Config.BombCutVolume = value;
    }

    protected float FireworksVolume
    {
        get => Mathf.Clamp(Config.FireworksVolume, 0f, 1f);
        set => Config.FireworksVolume = value;
    }
}