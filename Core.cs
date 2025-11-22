global using UnityEngine;
global using Vector2 = UnityEngine.Vector2;
using MelonLoader;

[assembly: MelonInfo(typeof(iInput.Core), "iInput", "1.0.0", "freakycheesy", "https://github.com/freakycheesy/iInput.git")]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]

namespace iInput
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
    }
}