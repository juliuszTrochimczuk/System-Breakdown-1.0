public interface IInteractable
{
    public string InteractionText { get; }
    public bool CanInteract { get; set; }
    public void Interaction();
}
