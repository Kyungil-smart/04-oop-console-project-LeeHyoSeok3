public class InputManager
{ 
    private Dictionary<ConsoleKey, ICommand> _commands;

    public InputManager()
    {
        _commands = new Dictionary<ConsoleKey, ICommand>();
    }
    
    public void BindCommand(ConsoleKey key, ICommand command) => _commands.Add(key, command);
    public void UnBindCommand(ConsoleKey key) => _commands.Remove(key);
    public void ClearCommands() => _commands.Clear();

    public void InputUpdate()
    {
        if (!Console.KeyAvailable) return;
        
        var key = Console.ReadKey(true).Key;
        if (_commands.TryGetValue(key, out var command))
        {
            command.Execute();
        }
    }
}