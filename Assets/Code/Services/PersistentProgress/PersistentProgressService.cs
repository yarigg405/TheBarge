using Assets.Code.Data;


namespace Assets.Code.Services.PersistentProgress
{
    public sealed class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}
