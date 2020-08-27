namespace GetThingsDone.Commands
{
    public interface ICommand
    {
        public string Name { get; }
        public bool ExecuteCommand();
    }
}
