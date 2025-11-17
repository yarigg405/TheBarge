using UnityEngine;

namespace Assets.Code.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateHud();
        GameObject CreatePlayer(GameObject at);
    }
}