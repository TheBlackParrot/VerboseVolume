using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using JetBrains.Annotations;
// ReSharper disable RedundantDefaultMemberInitializer

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace VerboseVolume.Configuration;

[UsedImplicitly]
internal class PluginConfig
{
    public static PluginConfig Instance { get; set; } = null!;
    
    public virtual float MenuMusicVolume { get; set; } = 0.25f;
    public virtual float GameMusicVolume { get; set; } = 0.67f;
    public virtual float UIVolume { get; set; } = 0.25f;
    public virtual float GoodCutVolume { get; set; } = 0.25f;
    public virtual float BadCutVolume { get; set; } = 0.25f;
    public virtual float BombCutVolume { get; set; } = 0.25f;
    public virtual float FireworksVolume { get; set; } = 0.1f;
}