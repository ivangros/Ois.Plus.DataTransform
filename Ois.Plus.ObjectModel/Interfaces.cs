namespace Ois.Plus.ObjectModel;

/// <summary>
/// Доступ к родителю (владельцу) объекта
/// </summary>
public interface IParent
{
    InteractionObject Parent { get; set; }
}
