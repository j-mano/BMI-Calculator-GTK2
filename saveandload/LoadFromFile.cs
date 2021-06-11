using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BMIGtk2.Services.Model;
using System.Xml.Linq;
using System.Linq;

namespace BMIGtk2.Services.saveandload
{
    public class LoadFromFile
    {
        static List<SavedValue> savedvalues = new List<SavedValue>();

        public static async Task<List<SavedValue>> LoadValuesFromXmlAsync()
        {
            StringBuilder result = new StringBuilder();
            foreach (XElement level1Element in XElement.Load("SavedEntries.xml").Elements("Bmi_Calculation_result"))
            {
                SavedValue t = new SavedValue();

                foreach (XElement level2Element in level1Element.Elements())
                {
                    if (level2Element.Attributes().First().Parent.Name.LocalName.Contains("BMI"))
                        t.bmi = float.Parse(level2Element.Attributes().First().Value);
                    if (level2Element.Attributes().First().Parent.Name.LocalName.Contains("Date"))
                        t.Date = DateTime.Parse(level2Element.Attributes().First().Value);
                    if (level2Element.Attributes().First().Parent.Name.LocalName.Contains("Health"))
                        t.heahltRec = level2Element.Attributes().First().Value;
                }

                savedvalues.Add(t);
            }

            return savedvalues;
        }
    }
}
