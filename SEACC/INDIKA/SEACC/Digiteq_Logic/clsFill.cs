using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.ComponentModel;

namespace Digiteq_Logic
{
    public class clsFill
    {
        //Item

        #region Fill - Item Prices
        public static void Fill_ItemPrices(ref ComboBox cmbItemPrice)
        {
            if (cmbItemPrice.Items.Count > 0)
                cmbItemPrice.Items.Clear();
            cmbItemPrice.DisplayMember = "Value";
            cmbItemPrice.ValueMember = "Text";
            cmbItemPrice.Items.Add(new ComboBoxItem("sellingPrice1", clsConfig.sItemPrice1_Name));
            cmbItemPrice.Items.Add(new ComboBoxItem("sellingPrice2", clsConfig.sItemPrice2_Name));
            cmbItemPrice.Items.Add(new ComboBoxItem("sellingPrice3", clsConfig.sItemPrice3_Name));
            cmbItemPrice.Items.Add(new ComboBoxItem("sellingPrice4", clsConfig.sItemPrice4_Name));
            cmbItemPrice.Items.Add(new ComboBoxItem("wholesalePrice", clsConfig.sItemPrice5_Name));
            cmbItemPrice.Items.Add(new ComboBoxItem("kiloPrice", clsConfig.sItemPrice6_Name));
        }
        #endregion
              
        public static string GetItemPriceName(string itemPriceVal)
        {
            string name = "-";
            if (itemPriceVal != "default")
            {
                switch (itemPriceVal)
                {
                    case "sellingPrice1":
                        name = clsConfig.sItemPrice1_Name;
                        break;
                    case "sellingPrice2":
                        name = clsConfig.sItemPrice2_Name;
                        break;
                    case "sellingPrice3":
                        name = clsConfig.sItemPrice3_Name;
                        break;
                    case "sellingPrice4":
                        name = clsConfig.sItemPrice4_Name;
                        break;
                    case "wholesalePrice":
                        name = clsConfig.sItemPrice5_Name;
                        break;
                    case "kiloPrice":
                        name = clsConfig.sItemPrice6_Name;
                        break;
                    default:
                        name = "-";
                        break;
                }
            }
            return name;
        }

        //Stock Note Types
        public static void Fill_StockNoteTypes(ref ComboBox cmbStockNoteType)
        {
            cmbStockNoteType.DisplayMember = "Value";
            cmbStockNoteType.ValueMember = "Text";
            foreach (tbl_zStockNoteType oDetail in tbl_zStockNoteType.SelectAll().Where(p => p.StockNoteType_ID != "default"))
            {
                cmbStockNoteType.Items.Add(new ComboBoxItem(oDetail.StockNoteType_ID, oDetail.StockNoteName));
            }
        }

        public static void FillEnumDescription(Type enumType, ref ComboBox cmbPriceMode)
        {
            List<string> lPeriod = new List<string>();
            foreach (var record in Enum.GetValues(enumType).Cast<Enum>().Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
        .OrderBy(item => item.value)
        .ToList())
            {
                lPeriod.Add(record.Description);
            }
            cmbPriceMode.DataSource = lPeriod;
        }
    }
}
