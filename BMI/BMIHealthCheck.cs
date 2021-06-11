using System;
namespace BMIGtk2.Services.BMI
{
    public class BMIHealthCheck
    {
        public static string BMIHealthcheck(float BMI)
        {
            string Messsage = "";

            if (BMI <= 18.5)
                Messsage = "undernärd";
            else if (BMI > 18.5 && BMI <= 25)
                Messsage = "Normalt värde";
            else if (BMI > 25 && BMI <= 30)
                Messsage = "Över normalt värde";
            else if (BMI > 30)
                Messsage = "Mycket över normalt värde";

            return Messsage;
        }
    }
}
