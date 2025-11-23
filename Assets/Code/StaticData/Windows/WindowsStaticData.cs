using UnityEngine;


namespace Assets.Code.StaticData.Windows
{
    [CreateAssetMenu(fileName = "WindowsStaticData", menuName = "ScriptableObjects/WindowsStaticData", order = 51)]
    public sealed class WindowsStaticData : ScriptableObject
    {
        public WindowConfig[] Configs;
    }
}
