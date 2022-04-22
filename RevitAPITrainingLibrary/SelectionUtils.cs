using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingLibrary
{
    public class SelectionUtils
    {
        public static List<Element> PickObjects(ExternalCommandData commandData, string message = "Выберите элементы")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var selectedObjects = uidoc.Selection.PickObjects(ObjectType.Element, message);
            var walls = new List<Element>();
            foreach (var selectedObject in selectedObjects)
            {
                Element element = doc.GetElement(selectedObject);
                walls.Add(element);
            }

            return walls;
        }
    }
}
