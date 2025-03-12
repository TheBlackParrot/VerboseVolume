using VerboseVolume.UI;
using JetBrains.Annotations;
using Zenject;

namespace VerboseVolume.Installers;

[UsedImplicitly]
internal class MenuInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SettingsMenuManager>().AsSingle();
    }
}