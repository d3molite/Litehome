namespace Litehome.Components.Abstract;

public abstract partial class EditablesPage
{
	protected bool HasUnsavedChanges { get; set; }
	
	protected abstract void CheckForUnsavedChanges();
}