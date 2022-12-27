using System.Collections.Generic;
using Infragistics.Controls.Editors;

namespace PFConsole.Util.Diagram
{
    public class DiagramItemPropertyGenerator : PropertyGeneratorBase
    {
        public override List<PropertyGridPropertyItem> GenerateProperties(object forObject, PropertyGenerationOptions generationOptions, PropertyGridPropertyItem forPropertyItem)
        {
            var result = new List<PropertyGridPropertyItem>();

            var attribs = AttributeHelper.GetAttributes(forObject);
            if (attribs.Length != 0)
            {
                foreach (var attrib in attribs)
                {
                    var item = new PropertyGridPropertyItem(forObject, attrib.PropertyName, attrib.Category, attrib.PropertyType, attrib.ReadOnly, false);

                    item.DisplayName = attrib.DisplayText;
                    item.Description = attrib.Description;

                    result.Add(item);
                }
            }

            return result;
        }
    }
}