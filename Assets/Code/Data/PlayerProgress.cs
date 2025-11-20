using System;


namespace Assets.Code.Data
{
    [Serializable]
    public sealed class PlayerProgress
    {
        public WorldData WorldData;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new(initialLevel);
        }
    }
}
