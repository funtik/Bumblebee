namespace Wasp.Interfaces
{
    public interface IDraggable : IHasBackingElement
    {
        IPerformsDragAndDrop GetDragAndDropPerformer();
    }
}
