using System;

namespace PFConsole.Util.Diagram
{
    public class ConfigurableAttribute : Attribute
    {
        public string PropertyName { get; set; }
        public string Category { get; set; }
        public Type PropertyType { get; set; }

        public string DisplayText { get; set; }
        public string Description { get; set; }

        public bool ReadOnly { get; set; }

        public ConfigurableAttribute(string propertyName, Type propertyType, string category, string displayText, string description, bool readOnly)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
            Category = category;
            DisplayText = displayText;
            Description = description;
            ReadOnly = readOnly;
        }
    }
}