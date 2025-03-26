using BlazorTable.Components.Validators;

namespace BlazorTable.Components.Models;

public class ElementType
{
    public ElementType(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
}

public class Element
{
    public Element(string title, ElementType type)
    {
        Title = title;
        Type = type;
        IsValidated = ElementValidator.Validate(title, type);
    }

    public string Title { get; set; }
    public ElementType Type { get; set; }
    public bool IsValidated { get; set; }
}