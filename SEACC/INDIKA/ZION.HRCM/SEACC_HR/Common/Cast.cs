using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiteq.Common
{
    public class Cast
    {
        //public static DataTable ToDataTables<T>(IList<T> data)
        //{
        //    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
        //    DataTable table = new DataTable();
        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptor prp = props[i];
        //        table.Columns.Add(prp.Name, Nullable.GetUnderlyingType(prp.PropertyType) ?? prp.PropertyType);
        //    }
        //    object[] values = new object[props.Count];
        //    foreach (T item in data)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item) ?? DBNull.Value;
        //        }
        //        table.Rows.Add(values);
        //    }
        //    return table;
        //}
        public static DataTable ToDataTables(IList<dynamic> data)
        {
            var json = JsonConvert.SerializeObject(data);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }
    }
}
