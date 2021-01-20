namespace Juniperr.Blazor.Toolbar.Services
{
    public interface IToolbarService
    {
        public void Reset();

        public void Set<T>()
            where T : ToolbarComponentBase;

        public void Set<T>(int group, int position)
            where T : ToolbarComponentBase;
    }
}
