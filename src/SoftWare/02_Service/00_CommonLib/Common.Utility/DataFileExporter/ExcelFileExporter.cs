using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using org.in2bits.MyXls;

namespace Common.Utility
{
    public class ExcelFileExporter : IFileExport
    {
        protected readonly ushort FONT_HEIGHT_SCALE = 20;
        protected readonly ushort COLUMN_WIDTH_SCALE = 256;

        private XlsDocument m_xlsDocument = new XlsDocument();
        private Dictionary<string, XF> m_xlsXFs = new Dictionary<string, XF>();

        #region Private Helper Method

        private List<ColumnData> GetSetting(List<List<ColumnData>> columnList, int index)
        {
            if (columnList == null || columnList.Count <= 0 || index < 0 || index >= columnList.Count)
            {
                return new List<ColumnData>(0);
            }
            List<ColumnData> rst = columnList[index];
            if (rst == null)
            {
                return new List<ColumnData>(0);
            }
            return rst;
        }

        private TextInfo GetSetting2(List<TextInfo> columnList, int index)
        {
            if (columnList == null || columnList.Count <= 0 || index < 0 || index >= columnList.Count)
            {
                return null;
            }
            return columnList[index];
        }

        // 过滤掉重复的或不存在的列的设置
        private List<ColumnData> ProcessColumnDataList(DataTable data, List<ColumnData> columnSetting)
        {
            List<ColumnData> list;
            if ((columnSetting != null && columnSetting.Count > 0) && data.Columns.Count > 0)
            {
                list = new List<ColumnData>(columnSetting.Count);
                foreach (var cols in columnSetting)
                {
                    int index = -1;
                    if (cols.FieldIndex.HasValue)
                    {
                        index = cols.FieldIndex.Value;
                    }
                    else if (cols.FieldName != null)
                    {
                        index = data.Columns.IndexOf(cols.FieldName.Trim());
                    }
                    if (index < 0 || index >= data.Columns.Count)
                    {
                        string msg;
                        if (cols.FieldIndex.HasValue)
                        {
                            msg = string.Format("The column with field index : {0} is not exist in query result.", cols.FieldIndex);
                        }
                        else if (cols.FieldName != null)
                        {
                            msg = string.Format("The column with field name : {0} is not exist in query result.", cols.FieldName);
                        }
                        else
                        {
                            msg = "There are some column has not set with field name nor filed index.";
                        }
                        throw new ApplicationException(msg);
                    }
                    if (list.Exists(c => c.FieldIndex.HasValue && c.FieldIndex.Value == index))
                    {
                        string msg;
                        if (cols.FieldIndex.HasValue)
                        {
                            msg = string.Format("Duplicated set the column with field index : {0}.", cols.FieldIndex);
                        }
                        else
                        {
                            msg = string.Format("Duplicated set the column with field name : {0}.", cols.FieldName);
                        }
                        throw new ApplicationException(msg);
                    }
                    cols.FieldName = data.Columns[index].ColumnName;
                    cols.FieldIndex = index;
                    list.Add(cols);
                }
            }
            else
            {
                list = new List<ColumnData>(0);
                //list = new List<ColumnData>(data.Columns.Count);
                //int i = 0;
                //foreach (DataColumn c in data.Columns)
                //{
                //    list.Add(new ColumnData
                //    {
                //        FieldIndex = i,
                //        FieldName = c.ColumnName,
                //        Title = c.ColumnName
                //    });
                //    i++;
                //}
            }
            return list;
        }

        private HorizontalAlignments? ConvertAlignments(HorizAlignments? h)
        {
            if (h == null)
            {
                return null;
            }
            return (HorizontalAlignments)(int)h.Value;
        }

        private VerticalAlignments? ConvertAlignments(VertiAlignments? v)
        {
            if (v == null)
            {
                return null;
            }
            return (VerticalAlignments)(int)v.Value;
        }

        private XF GetDataHeaderXF(int sheetIndex, int excelColumnIndex, HorizontalAlignments? h, VerticalAlignments? v, bool? hasBorder)
        {
            HorizontalAlignments h1 = h.GetValueOrDefault(HorizontalAlignments.Centered);
            VerticalAlignments v1 = v.GetValueOrDefault(VerticalAlignments.Centered);
            bool hasBorder1 = hasBorder.GetValueOrDefault(true);
            string key = "Header" + h1.ToString() + v1.ToString() + (hasBorder1 ? "Y" : "N") + sheetIndex;
            if (!this.m_xlsXFs.ContainsKey(key))
            {
                XF xf = this.m_xlsDocument.NewXF();
                xf.HorizontalAlignment = h1;
                xf.VerticalAlignment = v1;
                xf.Font.Height = (ushort)(10 * this.FONT_HEIGHT_SCALE);
                xf.Font.Weight = FontWeight.Bold;
                if (hasBorder1)
                {
                    xf.Pattern = 1;
                    xf.PatternColor = Colors.White;
                    xf.LeftLineStyle = 1;
                    xf.LeftLineColor = Colors.Black;
                    xf.TopLineStyle = 1;
                    xf.TopLineColor = Colors.Black;
                    xf.RightLineStyle = 1;
                    xf.RightLineColor = Colors.Black;
                    xf.BottomLineStyle = 1;
                    xf.BottomLineColor = Colors.Black;
                }
                SetXFForHeader(sheetIndex, excelColumnIndex, xf);
                this.m_xlsXFs.Add(key, xf);
                return xf;
            }
            return this.m_xlsXFs[key];
        }

        private XF GetDataCellXF(int sheetIndex, Type dataType, int excelRowIndex, int excelColumnIndex, HorizontalAlignments? h, VerticalAlignments? v, bool? hasBorder)
        {
            HorizontalAlignments h1 = h.GetValueOrDefault(SetDefaultHorizontalAlignmentsForType(dataType));
            VerticalAlignments v1 = v.GetValueOrDefault(VerticalAlignments.Centered);
            bool hasBorder1 = hasBorder.GetValueOrDefault(true);
            string key = "Cell" + h1.ToString() + v1.ToString() + (hasBorder1 ? "Y" : "N") + sheetIndex;
            if (!this.m_xlsXFs.ContainsKey(key))
            {
                XF xf = this.m_xlsDocument.NewXF();
                xf.HorizontalAlignment = h1;
                xf.VerticalAlignment = v1;
                xf.Font.Height = (ushort)(10 * this.FONT_HEIGHT_SCALE);
                if (hasBorder1)
                {
                    xf.LeftLineStyle = 1;
                    xf.LeftLineColor = Colors.Black;
                    xf.TopLineStyle = 1;
                    xf.TopLineColor = Colors.Black;
                    xf.RightLineStyle = 1;
                    xf.RightLineColor = Colors.Black;
                    xf.BottomLineStyle = 1;
                    xf.BottomLineColor = Colors.Black;
                    xf.TextWrapRight = true;
                }
                SetXFForDataCell(sheetIndex, excelRowIndex, excelColumnIndex, xf);
                this.m_xlsXFs.Add(key, xf);
                return xf;
            }
            return this.m_xlsXFs[key];
        }

        private void MergeRegion(Worksheet ws, XF xf, string content, int startRow, int startCol, int endRow, int endCol)
        {
            for (int i = startCol; i <= endCol; i++)
            {
                for (int j = startRow; j <= endRow; j++)
                {
                    ws.Cells.Add(j, i, content, xf);
                }
            }
            if (endCol > 0)
            {
                ws.Cells.Merge(startRow, endRow, startCol, endCol);
            }
        }

        #endregion Private Helper Method

        // IFileExport的接口方法，对外暴露的唯一入口
        public byte[] CreateFile(List<DataTable> data, List<List<ColumnData>> columnList, List<TextInfo> textInfoList, out string fileName)
        {
            int index = 0;
            foreach (DataTable table in data)
            {
                if (table != null && table.Rows != null
                    && table.Rows.Count > MaxDataTableRowCountLimit
                    && ThrowExceptionWhenDataTableRowCountExceedLimit)
                {
                    string msg = string.Format(Common.Utility.Resources.ErrorMsg.DataExport_DataTableRowCountExceedLimit, MaxDataTableRowCountLimit);
                    throw BuildBizException(msg, table.Rows.Count);
                }
                Worksheet worksheet = this.m_xlsDocument.Workbook.Worksheets.Add("Sheet" + (index + 1));
                if (table != null)
                {
                    BuildSheet(worksheet, index, table, GetSetting(columnList, index), GetSetting2(textInfoList, index));
                }
                index++;
            }
            fileName = SetFileName(data, textInfoList);
            return this.m_xlsDocument.Bytes.ByteArray;
        }

        // 负责生成一个Sheet的主方法，调用辅助 protected virtual方法来完成，如果Override该方法则可以完全控制生成逻辑
        protected virtual void BuildSheet(Worksheet worksheet, int sheetIndex, DataTable data,
            List<ColumnData> columnSetting, TextInfo textInfo)
        {
            columnSetting = ProcessColumnDataList(data, columnSetting);

            // set header with
            SetSheetColumnsWith(worksheet, sheetIndex, columnSetting, data);

            int headerRowIndex = 1;
            if (textInfo != null)
            {
                if (textInfo.Title != null && textInfo.Title.Trim().Length > 0)
                {
                    MergeRegion(worksheet, GetSheetTitleXF(), textInfo.Title.Trim(), headerRowIndex, 1, headerRowIndex, columnSetting.Count);
                    headerRowIndex = headerRowIndex + 1;
                }
                if (textInfo.Memo != null && textInfo.Memo.Trim().Length > 0)
                {
                    MergeRegion(worksheet, GetSheetMemoXF(), textInfo.Memo.Trim(), headerRowIndex, 1, headerRowIndex, columnSetting.Count);
                    headerRowIndex = headerRowIndex + 1;
                }
            }
            // add header row to excel sheet
            int excelColIndex = 0;
            bool hasFooter = false;
            foreach (ColumnData col in columnSetting)
            {
                excelColIndex++;
                XF xf = GetDataHeaderXF(sheetIndex, excelColIndex,
                    ConvertAlignments(col.HorizontalAlignment),
                    ConvertAlignments(col.VerticalAlignment),
                    col.HasBorder);
                worksheet.Cells.Add(headerRowIndex, excelColIndex, col.Title, xf);
                if (col.FooterType != FooterType.None)
                {
                    hasFooter = true;
                }
            }

            decimal[] rstContainer = new decimal[columnSetting.Count];

            // add content row to excel sheet
            int j = 0;
            for (j = 0; j < data.Rows.Count; j++)
            {
                if (j >= MaxDataTableRowCountLimit)
                {
                    break;
                }
                for (int c = 1; c <= columnSetting.Count; c++)
                {
                    ColumnData cols = columnSetting[c - 1];
                    object tmp = data.Rows[j][cols.FieldIndex.Value];
                    if (cols.FooterType != FooterType.None)
                    {
                        rstContainer[c - 1] = rstContainer[c - 1] + Convert.ToDecimal(tmp);
                    }
                    object d = FormatCellValue(tmp, cols.ValueFormat, sheetIndex, j + 1, c);
                    XF xf = GetDataCellXF(sheetIndex, tmp.GetType(), j + 1, c,
                        ConvertAlignments(cols.HorizontalAlignment),
                        ConvertAlignments(cols.VerticalAlignment),
                        cols.HasBorder);
                    worksheet.Cells.Add(j + headerRowIndex + 1
                        , c, d, xf);
                }
            }

            if (hasFooter)
            {
                for (int c = 1; c <= columnSetting.Count; c++)
                {
                    ColumnData cols = columnSetting[c - 1];
                    object x;
                    if (cols.FooterType == FooterType.None)
                    {
                        x = string.Empty;
                    }
                    else if (cols.FooterType == FooterType.Sum)
                    {
                        x = "总计：" + FormatCellValue(rstContainer[c - 1], cols.ValueFormat, sheetIndex, j + 1, c);
                    }
                    else
                    {
                        x = "平均：" + FormatCellValue(rstContainer[c - 1] / (decimal)j, cols.ValueFormat, sheetIndex, j + 1, c);
                    }
                    XF xf = GetDataCellXF(sheetIndex, x.GetType(), j + 1, c,
                        ConvertAlignments(cols.HorizontalAlignment),
                        ConvertAlignments(cols.VerticalAlignment),
                        cols.HasBorder);
                    worksheet.Cells.Add(j + headerRowIndex + 1
                        , c, x, xf);
                }
            }
        }

        #region 辅助 protected virtual

        protected virtual XF GetSheetTitleXF()
        {
            XF xf = this.m_xlsDocument.NewXF();
            xf.HorizontalAlignment = HorizontalAlignments.Left;
            xf.VerticalAlignment = VerticalAlignments.Centered;
            xf.Font.Height = (ushort)(14 * this.FONT_HEIGHT_SCALE);
            xf.Font.Weight = FontWeight.Bold;
            xf.LeftLineStyle = 1;
            xf.LeftLineColor = Colors.Black;
            xf.TopLineStyle = 1;
            xf.TopLineColor = Colors.Black;
            xf.RightLineStyle = 1;
            xf.RightLineColor = Colors.Black;
            xf.BottomLineStyle = 1;
            xf.BottomLineColor = Colors.Black;
            xf.TextWrapRight = true;
            return xf;
        }

        protected virtual XF GetSheetMemoXF()
        {
            XF xf = this.m_xlsDocument.NewXF();
            xf.HorizontalAlignment = HorizontalAlignments.Left;
            xf.VerticalAlignment = VerticalAlignments.Centered;
            xf.Font.Height = (ushort)(10 * this.FONT_HEIGHT_SCALE);
            xf.LeftLineStyle = 1;
            xf.LeftLineColor = Colors.Black;
            xf.TopLineStyle = 1;
            xf.TopLineColor = Colors.Black;
            xf.RightLineStyle = 1;
            xf.RightLineColor = Colors.Black;
            xf.BottomLineStyle = 1;
            xf.BottomLineColor = Colors.Black;
            xf.TextWrapRight = true;
            return xf;
        }

        protected virtual HorizontalAlignments SetDefaultHorizontalAlignmentsForType(Type type)
        {
            while (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && type.GetGenericArguments() != null
                    && type.GetGenericArguments().Length == 1)
            {
                type = type.GetGenericArguments()[0];
            }
            TypeCode code = Type.GetTypeCode(type);
            switch (code)
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return HorizontalAlignments.Right;
                case TypeCode.DateTime:
                case TypeCode.Char:
                case TypeCode.Boolean:
                case TypeCode.String:
                case TypeCode.Object:
                case TypeCode.DBNull:
                case TypeCode.Empty:
                    return HorizontalAlignments.Left;
                default:
                    return HorizontalAlignments.Centered;
            }
        }

        protected virtual Exception BuildBizException(string msg, int queryResultRowCount)
        {
            Type type = Type.GetType("ECCentral.BizEntity.BizException, ECCentral.BizEntity");
            return (Exception)Activator.CreateInstance(type, msg);
        }

        protected virtual int MaxDataTableRowCountLimit
        {
            get
            {
                if (FileExporterConfig.GetSetting().MaxRowCountLimit.HasValue)
                {
                    return FileExporterConfig.GetSetting().MaxRowCountLimit.Value;
                }
                return 10000;
            }
        }

        protected virtual bool ThrowExceptionWhenDataTableRowCountExceedLimit
        {
            get
            {
                return true;
            }
        }

        protected virtual string SetFileName(List<DataTable> data, List<TextInfo> textInfoList)
        {
            if (textInfoList == null || textInfoList.Count <= 0)
            {
                return DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss_ffff") + ".xls";
            }
            string t = null;
            foreach (var text in textInfoList)
            {
                if (text.Title != null && text.Title.Trim().Length > 0)
                {
                    t = text.Title.Trim();
                    break;
                }
            }
            if (t == null)
            {
                return DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss_ffff") + ".xls";
            }
            return t + DateTime.Now.ToString("_yyyy-MM-dd_HH_mm_ss_ffff") + ".xls";
        }

        protected virtual void SetSheetColumnsWith(Worksheet worksheet, int sheetIndex, List<ColumnData> columnSetting, DataTable data)
        {
            for (int i = 0; i < columnSetting.Count; i++)
            {
                ColumnInfo col;
                if (!columnSetting[i].Width.HasValue)
                {
                    // 如果是DateTime类型的列，设默认长度20；
                    if (data != null && data.Rows != null && data.Rows.Count > 0)
                    {
                        int rowIndex = 0;
                        object t = null;
                        while ((t == null || t == DBNull.Value) && rowIndex < data.Rows.Count)
                        {
                            t = data.Rows[rowIndex][columnSetting[i].FieldIndex.Value];
                            rowIndex++;
                        }
                        if (t != null && t != DBNull.Value && (t.GetType() == typeof(DateTime) || t.GetType() == typeof(DateTime?)))
                        {
                            col = new ColumnInfo(this.m_xlsDocument, worksheet);
                            col.Width = (ushort)(20 * this.COLUMN_WIDTH_SCALE);
                            col.ColumnIndexStart = (ushort)(i);
                            col.ColumnIndexEnd = (ushort)(i);
                            worksheet.AddColumnInfo(col);
                        }
                    }
                    continue;
                }
                col = new ColumnInfo(this.m_xlsDocument, worksheet);
                col.Width = (ushort)(columnSetting[i].Width.Value * this.COLUMN_WIDTH_SCALE);
                col.ColumnIndexStart = (ushort)(i);
                col.ColumnIndexEnd = (ushort)(i);
                worksheet.AddColumnInfo(col);
            }
        }

        protected virtual void SetXFForHeader(int sheetIndex, int excelColumnIndex, XF xf)
        {
        }

        protected virtual void SetXFForDataCell(int sheetIndex, int excelRowIndex, int excelColumnIndex, XF xf)
        {
        }

        protected virtual object FormatCellValue(object value, string format, int sheetIndex, int excelRowIndex, int excelColumnIndex)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }
            Type type = value.GetType();
            while (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && type.GetGenericArguments() != null
                    && type.GetGenericArguments().Length == 1)
            {
                type = type.GetGenericArguments()[0];
            }
            TypeCode code = Type.GetTypeCode(type);
            switch (code)
            {
                case TypeCode.DateTime:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    return Convert.ToDateTime(value).ToString(format);
                case TypeCode.Decimal:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return Convert.ToDecimal(value).ToString("#,##0.00");
                    }
                    return Convert.ToDecimal(value).ToString(format);
                case TypeCode.Double:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToDouble(value).ToString(format);
                case TypeCode.Single:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToSingle(value).ToString(format);
                case TypeCode.Byte:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToByte(value).ToString(format);
                case TypeCode.Int16:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToInt16(value).ToString(format);
                case TypeCode.Int32:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToInt32(value).ToString(format);
                case TypeCode.Int64:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToInt64(value).ToString(format);
                case TypeCode.SByte:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToSByte(value).ToString(format);
                case TypeCode.UInt16:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToUInt16(value).ToString(format);
                case TypeCode.UInt32:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToUInt32(value).ToString(format);
                case TypeCode.UInt64:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return Convert.ToUInt64(value).ToString(format);
                case TypeCode.Char:
                case TypeCode.Boolean:
                case TypeCode.String:
                case TypeCode.Object:
                    if (format == null || format.Trim().Length <= 0)
                    {
                        return value.ToString();
                    }
                    return string.Format(format, value.ToString());
                case TypeCode.DBNull:
                case TypeCode.Empty:
                    return null;
                default:
                    return value;
            }
        }

        #endregion 辅助 protected virtual
    }
}