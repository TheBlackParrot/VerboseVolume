using System;
using HarmonyLib;
using UnityEngine;
using VerboseVolume.Configuration;

namespace VerboseVolume.Patches;

[HarmonyPatch]
internal class VolumePatches
{
    private static PluginConfig Config => PluginConfig.Instance;
    internal static SongPreviewPlayer PreviewPlayer = null!;
    
    // ReSharper disable InconsistentNaming
    [HarmonyPatch(typeof(SongPreviewPlayer), "CrossfadeTo", typeof(AudioClip), typeof(float), typeof(float), typeof(float), typeof(Action))]
    [HarmonyPatch(typeof(SongPreviewPlayer), "CrossfadeTo", typeof(AudioClip), typeof(float), typeof(float), typeof(float), typeof(bool), typeof(Action))]
    public static bool Prefix(SongPreviewPlayer __instance, ref float ____volume)
    {
        PreviewPlayer = __instance;
        ____volume = Config.MenuMusicVolume;
        
        return true;
    }

    [HarmonyPatch(typeof(BasicUIAudioManager), "HandleButtonClickEvent")]
    public static bool Prefix(BasicUIAudioManager __instance)
    {
        __instance._audioSource.volume = Config.UIVolume;
        
        return true;
    }
    
    [HarmonyPatch(typeof(NoteCutSoundEffect), "Init")]
    public static bool Prefix(NoteCutSoundEffect __instance)
    {
        __instance._goodCutVolume = Config.GoodCutVolume;
        __instance._badCutVolume = Config.BadCutVolume;
        
        return true;
    }

    [HarmonyPatch(typeof(GameSongController), "StartSong")]
    public static bool Prefix(GameSongController __instance)
    {
        if(!__instance.gameObject.TryGetComponent(out AudioSource audioSource))
        {
            return true;
        }
        
        audioSource.volume = Config.GameMusicVolume;
        
        return true;
    }

    [HarmonyPatch(typeof(FireworkItemController), "PlayExplosionSound")]
    public static bool Prefix(FireworkItemController __instance)
    {
        if(!__instance.gameObject.TryGetComponent(out AudioSource audioSource))
        {
            return true;
        }
        
        audioSource.volume = Config.FireworksVolume;
        
        return true;
    }
    
    [HarmonyPatch(typeof(BombCutSoundEffect), "Init")]
    public static bool Prefix(BombCutSoundEffect __instance)
    {
        __instance._audioSource.volume = Config.BombCutVolume;
        
        return true;
    }
    // ReSharper restore InconsistentNaming
}