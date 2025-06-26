namespace Ois.Plus.ObjectModel;

public class ListEx<T> : List<T>
{
    private readonly InteractionObject parent;

    public ListEx() : base()
    {
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parent">Родитель</param>
    public ListEx(InteractionObject parent)
        : base()
    {
        this.parent = parent;
    }

    public new void Add(T obj)
    {
        if (obj is InteractionObject it)
            it.Parent = parent;
        base.Add(obj);
    }

    public new void AddRange(IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Add(item);
        }
    }
}
