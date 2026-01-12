public interface IScene
{
    void Enter(RenderState state);
    void Exit(RenderState state);
    void Update(double deltaTime);
    void Render(RenderState state);
}