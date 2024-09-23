using JetBrains.Annotations;

public interface IInteractable
{

    string Prompt { get; }

    void Interact();
}