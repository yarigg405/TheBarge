using System;


namespace Assets.Code.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;

        public WorldData(string initialLevel)
        {
            PositionOnLevel = new(initialLevel, new Vector3Data(15f, 0, 28f));
        }

    }
}