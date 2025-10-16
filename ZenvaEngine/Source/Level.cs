using ZenvaEngine.Source;

internal abstract class Level
{
    public abstract string LevelName { get; set; }
    public abstract bool Init { get; set; }
    public Level(string levelName)
    {
        this.LevelName = levelName;
        Init = false;
        LevelManager.AllLevels.Add(this);
    }
    public abstract void OnLoad();
    public abstract void OnUpdate();
    public virtual void OnDestroy()
    {
        foreach (GameObject obj in Engine.GameObjects)
        {
            obj.DestorySelf();
        }
    }
}