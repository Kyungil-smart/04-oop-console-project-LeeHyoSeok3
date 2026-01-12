public class GameObjectManager
{
    private List<IGameObject> _objects = new();

    public void Add(IGameObject obj) => _objects.Add(obj);
    public void Clear() => _objects.Clear();
    public void Remove(IGameObject obj) => _objects.Remove(obj);

    public void Update()
    {
        foreach (var obj in _objects)
            obj.Update();
    }

    public void Render(RenderState state)
    {
        foreach (var obj in _objects)
            obj.Render(state);
    }
}