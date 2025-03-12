using System.Reflection;
using HarmonyLib;
using IPA;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using VerboseVolume.Configuration;
using VerboseVolume.Installers;
using IPALogger = IPA.Logging.Logger;
using IPAConfig = IPA.Config.Config;

namespace VerboseVolume;

[Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
internal class Plugin
{
    private static Harmony _harmony = null!;
    // ReSharper disable once MemberCanBePrivate.Global
    internal static IPALogger Log { get; set; } = null!;

    [Init]
    public Plugin(IPALogger ipaLogger, IPAConfig ipaConfig, Zenjector zenjector)
    {
        Log = ipaLogger;
        zenjector.UseLogger(Log);
        
        PluginConfig c = ipaConfig.Generated<PluginConfig>();
        PluginConfig.Instance = c;
        
        zenjector.Install<MenuInstaller>(Location.Menu);
        
        Log.Info("Plugin loaded");
    }
    
    [OnEnable]
    public void OnEnable()
    {
        _harmony = new Harmony("TheBlackParrot.VerboseVolume");
        _harmony.PatchAll(Assembly.GetExecutingAssembly());
        
        Log.Info("Patches applied");
    }
    
    [OnDisable]
    public void OnDisable()
    {
        _harmony.UnpatchSelf();
    }
}