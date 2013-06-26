using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    internal static class FileExporterFactory
    {
        public static IFileExport CreateExporter(string exporterName)
        {
            ExporterSetting setting = FileExporterConfig.GetSetting();
            if (setting != null && exporterName != null && exporterName.Trim().Length > 0)
            {
                if (setting.FileExporterList.ContainsKey(exporterName))
                {
                    string typeName = setting.FileExporterList[exporterName];
                    if (typeName != null && typeName.Length > 0)
                    {
                        Type type = Type.GetType(typeName, true);
                        return (IFileExport)Activator.CreateInstance(type);
                    }
                }
                if (setting.Default != null && setting.Default.Length > 0 && setting.FileExporterList.ContainsKey(setting.Default))
                {
                    CreateExporter(setting.Default);
                }
            }
            return new ExcelFileExporter();
        }
    }
}
