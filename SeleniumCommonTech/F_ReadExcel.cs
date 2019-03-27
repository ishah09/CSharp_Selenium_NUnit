using ExcelDataReader;
using log4net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace NUnitDemo.SeleniumCommonTech
{
    [TestFixture]
    public class F_ReadExcel
    {
        private static readonly ILog Log =
         LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static FileInfo fileInfo = new FileInfo(dir);
        public static DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
        public static string parentDirName = currentDir.FullName;

        [TestCaseSource("ReadValue")]
        public void TestMethod(String a, String b, String c)
        {
            Log.Info(a +b +c);
        }

        //public object[] TestData = { ReadValue(); };

        public static object[] ReadValue()
        {
            using (var stream = File.Open(parentDirName + "./Test Excel.xlsx", FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    //do
                    //{
                    //    while (reader.Read())
                    //    {
                    //        reader.GetInt32(0);
                    //        Log.Info(reader);
                    //    }
                    //} while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    DataSet result = reader.AsDataSet();
                    //Log.Info(result.Tables[0].Rows.ToString());                                                    

                    List<string> data = new List<string>();
                    //var data = result.Tables[0].Select(dr => new {}).ToList();

                    foreach (DataRow dr in result.Tables[0].Rows)
                    {
                        data.Add(dr[0].ToString());
                        data.Add(dr[1].ToString());
                        data.Add(dr[2].ToString());
                    }

                    Object[] t = data.ToArray();
                    return t;
                    //Log.Info(data);

                    // The result of each spreadsheet is in result.Tables
                }
            }
        }
    }
}
