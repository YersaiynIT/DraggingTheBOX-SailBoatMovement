public interface IDraggable
{
    bool IsDragging { get; }
    
    void OnDragStart();
    void OnDrag();
    void OnDragEnd();
}
