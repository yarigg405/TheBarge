using Assets.Code.Data;


namespace Assets.Code.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}
