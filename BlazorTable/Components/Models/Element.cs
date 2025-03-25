namespace BlazorTable.Components.Models
{
    public class ElementType
    {
        public string Title { get; set; }

        public ElementType(string title)
        {
            Title = title;
        }
    }

    public class Element
    {
        public string Title { get; set; }
        public ElementType Type { get; set; }
        public bool IsValidated { get; set; } = true;

        public Element(string title, ElementType type)
        {
            Title = title;
            Type = type;
        }
    }
}