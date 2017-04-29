namespace CreatingDust.AchievementSimulator.CrossContext.Services
{
    public interface IAudioService
    {
        bool fxEnabled { get; set; }
        bool musicEnabled { get; set; }
		        
        void Play(AudioId id);
        void SetBackground(AudioId id);
    }
}