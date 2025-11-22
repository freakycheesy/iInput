global using UnityEngine;
global using Vector2 = UnityEngine.Vector2;
using MelonLoader;
using UnityEngine.InputSystem;

[assembly: MelonInfo(typeof(iInput.Core), "iInput", "1.0.0", "pietr", null)]
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