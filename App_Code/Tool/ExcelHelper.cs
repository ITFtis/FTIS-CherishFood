using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Tool
{

    public class ExcelHelper
    {
        #region 呼叫方式
        //    DataTable table = new DataTable(); 

        //// 填充資料（由讀者自行撰寫） 

        //// 產生 Excel 資料流。 
        //MemoryStream ms = DataTableRenderToExcel.RenderDataTableToExcel(table) as MemoryStream; 
        //// 設定強制下載標頭。 
        //Response.AddHeader("Content-Disposition", string.Format("attachment; filename=Download.xls")); 
        //// 輸出檔案。 
        //Response.BinaryWrite(ms.ToArray()); 

        //ms.Close(); 
        //ms.Dispose();


        #endregion
        #region 讀取方式
        //  DataTable table = DataTableRenderToExcel.RenderDataTableFromExcel(this.fuUpload.FileContent, 1, 0); 
        //this.gvExcel.DataSource = table; 
        //this.gvExcel.DataBind(); 
        #endregion


        #region Linq 跟DataTable轉換
        public static Stream RenderDataTableToExcel(DataTable sourceTable)
        {
            var workbook = new XSSFWorkbook();
            var ms = new MemoryStream();
            var sheet = (ISheet)workbook.CreateSheet();
            var headerRow = (IRow)sheet.CreateRow(0);

            // handling header. 
            foreach (DataColumn column in sourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value. 
            int rowIndex = 1;

            foreach (DataRow row in sourceTable.Rows)
            {
                var dataRow = (IRow)sheet.CreateRow(rowIndex);

                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();

            return ms;
        }
        /// <summary>
        /// 根据DataSet导出Excel
        /// </summary>
        /// <param name="ds">DataSet</param>
        public static Stream RenderDataSetToExcel(DataSet ds)
        {

            var fileWorkbook = new XSSFWorkbook();

            foreach (DataTable dt in ds.Tables)
            {

                var sheet = fileWorkbook.CreateSheet(dt.TableName);

                //表头
                var row = sheet.CreateRow(0);
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    var cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                //数据
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var row1 = sheet.CreateRow(i + 1);
                    for (var j = 0; j < dt.Columns.Count; j++)
                    {
                        var cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }
            }
            //转为字节数组
            var ms = new MemoryStream();
            fileWorkbook.Write(ms);
            ms.Flush();

            return ms;
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        public static DataTable ConvertToDataTable<T>(IList<T> data, string tableName)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            table.TableName = tableName;
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        public static Stream TableToExcelForXlsx(DataTable dt)
        {
            var xssfworkbook = new XSSFWorkbook();
            var sheet = xssfworkbook.CreateSheet();

            //表头
            var row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row1 = sheet.CreateRow(i + 1);
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    var cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //转为字节数组
            var stream = new MemoryStream();
            xssfworkbook.Write(stream);
            stream.Flush();
            return stream;
        }
        public static void RenderDataTableToExcel(DataTable sourceTable, string fileName)
        {
            var ms = RenderDataTableToExcel(sourceTable) as MemoryStream;
            var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            if (ms == null) return;
            var data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
        /// <summary>
        /// 將Excel轉為DataTable-xls
        /// </summary>
        /// <param name="excelFileStream">原始路徑</param>
        /// <param name="sheetIndex">資料列</param>
        /// <param name="headerRowIndex">目標文件夾</param>
        public static DataTable RenderDataTableFromExcelXls(Stream excelFileStream, int sheetIndex, int headerRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(excelFileStream);
            ISheet sheet = (HSSFSheet)workbook.GetSheetAt(sheetIndex);

            DataTable table = new DataTable();

            IRow headerRow = (HSSFRow)sheet.GetRow(headerRowIndex);
            if (headerRow != null)
            {
                int cellCount = headerRow.LastCellNum;
                int ScellCount = 0;
                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    if (!string.IsNullOrEmpty(headerRow.GetCell(i).StringCellValue))
                    {
                        table.Columns.Add(column);
                        ScellCount++;
                    }
                }

                for (var i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = (HSSFRow)sheet.GetRow(i);
                    if (row == null) continue;
                    DataRow dataRow = table.NewRow();
                    int emtyCount = 1;

                    for (int j = row.FirstCellNum; j < ScellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            if (string.IsNullOrEmpty(row.GetCell(j).ToString()))
                            {
                                emtyCount++;
                            }
                            //String  Numeric
                            var aa = row.GetCell(j).CellType.ToString();
                            //如要針對不同型別做個別處理，可善用.CellType判斷型別
                            //再用.StringCellValue, .DateCellValue, .NumericCellValue...取值
                            //此處只簡單轉成字串
                            switch (row.GetCell(j).CellType.ToString())
                            {
                                case "String":
                                    dataRow[j] = row.GetCell(j).StringCellValue;
                                    break;
                                case "Numeric":
                                    dataRow[j] = row.GetCell(j).NumericCellValue;
                                    break;
                                default:
                                    dataRow[j] = row.GetCell(j).ToString();
                                    break;
                            }

                        }
                        else
                        {
                            emtyCount++;
                        }
                    }
                    if (emtyCount < ScellCount)
                    {
                        table.Rows.Add(dataRow);
                    }

                }
            }
            excelFileStream.Close();
            return table;
        }
        public static DataTable RenderDataTableFromExcel(Stream excelFileStream, string sheetName, int headerRowIndex)
        {
            var workbook = new XSSFWorkbook(excelFileStream);
            var sheet = (XSSFSheet)workbook.GetSheet(sheetName);

            var table = new DataTable();

            var headerRow = (XSSFRow)sheet.GetRow(headerRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                var column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (var i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                var row = (XSSFRow)sheet.GetRow(i);
                var dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            excelFileStream.Close();
            return table;
        }

        public static DataTable RenderDataTableFromExcel(Stream excelFileStream, int sheetIndex, int headerRowIndex)
        {
            IWorkbook workbook = new XSSFWorkbook(excelFileStream);
            ISheet sheet = (XSSFSheet)workbook.GetSheetAt(sheetIndex);

            DataTable table = new DataTable();

            IRow headerRow = (XSSFRow)sheet.GetRow(headerRowIndex);
            int cellCount = headerRow.LastCellNum;
            int ScellCount = 0;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                if (!string.IsNullOrEmpty(headerRow.GetCell(i).StringCellValue))
                {
                    table.Columns.Add(column);
                    ScellCount++;
                }
            }

            for (var i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = (XSSFRow)sheet.GetRow(i);
                if (row == null) continue;
                DataRow dataRow = table.NewRow();
                int emtyCount = 1;

                for (int j = row.FirstCellNum; j < ScellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        if (string.IsNullOrEmpty(row.GetCell(j).ToString()))
                        {
                            emtyCount++;
                        }
                        //String  Numeric
                        var aa = row.GetCell(j).CellType.ToString();
                        //如要針對不同型別做個別處理，可善用.CellType判斷型別
                        //再用.StringCellValue, .DateCellValue, .NumericCellValue...取值
                        //此處只簡單轉成字串
                        switch (row.GetCell(j).CellType.ToString())
                        {
                            case "String":
                                dataRow[j] = row.GetCell(j).StringCellValue;
                                break;
                            case "Numeric":
                                dataRow[j] = row.GetCell(j).NumericCellValue;
                                break;
                            default:
                                dataRow[j] = row.GetCell(j).ToString();
                                break;
                        }

                    }
                    else
                    {
                        emtyCount++;
                    }
                }
                if (emtyCount < ScellCount)
                {
                    table.Rows.Add(dataRow);
                }

            }

            excelFileStream.Close();
            return table;
        }

        /// <summary>
        /// LinqToDataTable
        /// </summary>
        /// <param name="query">IEnumerable</param>
        /// <returns>DataTable</returns>
        public static DataTable LinqToDataTable<T>(IEnumerable<T> query)
        {
            DataTable tbl = new DataTable();
            PropertyInfo[] props = null;
            foreach (T item in query)
            {
                if (props == null) //尚未初始化
                {
                    Type t = item.GetType();
                    props = t.GetProperties();
                    foreach (PropertyInfo pi in props)
                    {
                        Type colType = pi.PropertyType;
                        //針對Nullable<>特別處理
                        if (colType.IsGenericType
                            && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            colType = colType.GetGenericArguments()[0];
                        //建立欄位
                        tbl.Columns.Add(pi.Name, colType);
                    }
                }
                DataRow row = tbl.NewRow();
                foreach (PropertyInfo pi in props)
                    row[pi.Name] = pi.GetValue(item, null) ?? DBNull.Value;
                tbl.Rows.Add(row);
            }
            return tbl;
        }
        #endregion

        /// <summary>
        /// 根据Excel和Sheet返回DataTable
        /// </summary>
        /// <param name="filePath">Excel文件地址</param>
        /// <param name="sheetIndex">Sheet索引</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(string filePath, int sheetIndex)
        {
            return GetDataSet(filePath, sheetIndex).Tables[0];
        }
        /// <summary>
        /// 根据Excel返回DataSet
        /// </summary>
        /// <param name="filePath">Excel文件地址</param>
        /// <param name="sheetIndex">Sheet索引，可选，默认返回所有Sheet</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string filePath, int? sheetIndex = null)
        {
            var ds = new DataSet();
            IWorkbook fileWorkbook;

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (filePath.Last() == 's')
                {
                    fileWorkbook = new XSSFWorkbook(fs);
                }
                else
                {
                    try
                    {
                        fileWorkbook = new XSSFWorkbook(fs);
                    }
                    catch
                    {
                        fileWorkbook = new XSSFWorkbook(fs);
                    }
                }
            }

            for (var i = 0; i < fileWorkbook.NumberOfSheets; i++)
            {
                if (sheetIndex != null && sheetIndex != i)
                    continue;
                var dt = new DataTable();
                var sheet = fileWorkbook.GetSheetAt(i);

                //表头
                var header = sheet.GetRow(sheet.FirstRowNum);
                var columns = new List<int>();
                for (var j = 0; j < header.LastCellNum; j++)
                {
                    var obj = GetValueTypeForXls(header.GetCell(j) as XSSFCell);
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + j.ToString()));
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    columns.Add(j);
                }
                //数据
                var rows = sheet.GetEnumerator();
                while (rows.MoveNext())
                {
                    var dr = dt.NewRow();
                    var hasValue = false;
                    foreach (var k in columns)
                    {
                        dr[k] = GetValueTypeForXls(sheet.GetRow(k).GetCell(k) as XSSFCell);
                        if (dr[k] != null && dr[k].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
                ds.Tables.Add(dt);
            }

            return ds;
        }

        /// <summary>
        /// 根据DataTable导出Excel
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="file">保存地址</param>
        public static void GetExcelByDataTable(DataTable dt, string file)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            GetExcelByDataSet(ds, file);
        }

        /// <summary>
        /// 根据DataSet导出Excel
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="file">保存地址</param>
        public static void GetExcelByDataSet(DataSet ds, string file)
        {

            IWorkbook fileWorkbook = new HSSFWorkbook();
            int index = 0;
            foreach (DataTable dt in ds.Tables)
            {
                index++;
                ISheet sheet = fileWorkbook.CreateSheet("Sheet" + index);

                //表头
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                //数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }
            }

            //转为字节数组
            MemoryStream stream = new MemoryStream();
            fileWorkbook.Write(stream);
            var buf = stream.ToArray();

            //保存为Excel文件
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }


        /// <summary>
        /// 根据单元格将内容返回为对应类型的数据
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <returns>数据</returns>
        private static object GetValueTypeForXls(XSSFCell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:
                    return null;
                case CellType.Boolean: //BOOLEAN:
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:
                    return cell.NumericCellValue;
                case CellType.String: //STRING:
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:
                    return cell.ErrorCellValue;
                default:
                    return "=" + cell.CellFormula;
            }
        }
    }
}