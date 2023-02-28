using ChoETL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BDD_UI_TestFramework.Utils.Helpers
{
    class CSV
    {
        public static void ReadCSVFile()
        {

            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            outPutDirectory = outPutDirectory.Substring(0, outPutDirectory.IndexOf("bin"));
            outPutDirectory = outPutDirectory.Substring(outPutDirectory.IndexOf("\\") + 1);
            String path = Path.Combine(outPutDirectory, "TestData\\sample.csv");
            using (var reader = new ChoCSVReader(path).WithFirstLineHeader())
            {
                foreach (dynamic item in reader)
                {
                    String name = item.policyID;

                }
                reader.Close();
            }


        }
    }
}
