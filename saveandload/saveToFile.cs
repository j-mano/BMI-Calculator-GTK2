using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using BMIGtk2.Services.Model;

namespace BMIGtk2.Services.saveandload
{
    public class saveToFile
    {
        public async static Task SaveInfoToFileAsync(List<SavedValue> BmiIndfoHistroy)
        {
            // Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<SavedBmiValue><name>Saved values History</name></SavedBmiValue>");

            foreach (SavedValue saveditem in BmiIndfoHistroy)
            {
                XmlElement BMI = doc.CreateElement("Bmi_Calculation_result");
                BMI.AppendChild(doc.CreateElement("BMI", saveditem.bmi.ToString()));
                BMI.AppendChild(doc.CreateElement("Date", saveditem.Date.ToString()));
                BMI.AppendChild(doc.CreateElement("Health", saveditem.heahltRec));
                doc.DocumentElement.AppendChild(BMI);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                // Save the document to a file and auto-indent the output.
                XmlWriter writer = XmlWriter.Create("SavedEntries.xml", settings);
                doc.Save(writer);

                writer.Close();
            }
        }
    }
}
