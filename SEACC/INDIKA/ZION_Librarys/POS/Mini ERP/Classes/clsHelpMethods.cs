using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;
using Digiteq_Logic;
using System.IO;

namespace Digiteq
{
    public class clsHelpMethods_Local
    {
        #region show Item Viewer
        public static void showItemViewer(string sItemCode, string sSerial1, string sSerial2, string sSubCategoryID1, string sSubCategoryID2)
        {
            frmItemViewer frm = new frmItemViewer();
            frm.glbItemID = sItemCode;
            frm.glbItemSerialNo1 = sSerial1;
            frm.glbItemSerialNo2 = sSerial2;
            frm.glbItemSubCategoryID1 = sSubCategoryID1;
            frm.glbItemSubCategoryID2 = sSubCategoryID2;
            frm.Show();
        }
        #endregion
        #region Set Item Image
        public static void SetItemImage(string sItemCode, ref PictureBox pbxImage)
        {
            if (sItemCode.Length > 0 && sItemCode != "default")
            {
                string sImagePath = clsGenaralName.getName_ItemImagePath_ByItemID(sItemCode);
                if (sImagePath != "" || sImagePath != "Default")
                {
                    if (clsConfig.bOpenImageInImageTempFolder)
                    {
                        if (File.Exists("ImagesTemp\\" + sImagePath))
                            pbxImage.Image = System.Drawing.Image.FromFile("ImagesTemp\\" + sImagePath);
                        else
                            pbxImage.Image = Digiteq.Properties.Resources.no_image;
                    }
                    else
                    {
                        if (File.Exists("Images\\" + sImagePath))
                            pbxImage.Image = System.Drawing.Image.FromFile("Images\\" + sImagePath);
                        else
                            pbxImage.Image = Digiteq.Properties.Resources.no_image;
                    }
                }
                else
                    pbxImage.Image = Digiteq.Properties.Resources.no_image;
            }
        }
        #endregion
        #region Display Form
        public static void DisplayForm(SEACC_Form frm, Color color, object parent)
        {
            DisplayForm(frm, color, parent, false);
        }
        public static void DisplayForm(SEACC_Form frm, Color color, object parent, bool ShowMaximizeButton)
        {
            if (!frm.bNoAccess)
            {
                MettroForm mf = new MettroForm() { };
                mf.Settings_Click += delegate (object sender, EventArgs e)
                {
                    frm.SettingsClick();
                };
                mf.bMaximizeButtonVisible = ShowMaximizeButton;
                mf.DefaultHight = frm.Height + 35;
                mf.DefaultWidth = frm.Width + 10;
                mf.Width = mf.DefaultWidth;
                mf.Height = mf.DefaultHight;
                mf.Controls.Add(frm);
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                mf.Text = frm.Name;

                if (color != Color.Empty)
                {
                    mf.ThemeColor = color;
                    frm.UI_Color = color;
                }

                frm.BringToFront();
                mf.MdiParent = parent as Form;
                mf.Show();
            }
        }

        public static void DisplayForm_2(SEACC_Form frm, Color color)
        {
            if (!frm.bNoAccess)
            {
                MettroForm mf = new MettroForm() { };
                //    mf.WindowState = FormWindowState.Maximized;
                mf.Settings_Click += delegate (object sender, EventArgs e)
                {
                    frm.SettingsClick();
                };
                mf.DefaultHight = frm.Height + 35;
                mf.DefaultWidth = frm.Width + 10;
                mf.Width = mf.DefaultWidth;
                mf.Height = mf.DefaultHight;
                mf.Controls.Add(frm);
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                mf.Text = frm.Name;

                if (color != Color.Empty)
                {
                    mf.ThemeColor = color;
                    frm.UI_Color = color;
                }

                frm.BringToFront();
                mf.ShowDialog();
            }
        }

        //public static void DisplayForm(SEACC_Form frm, Color color)
        //{
        //    MettroForm mf = new MettroForm() { };
        //    mf.Settings_Click += delegate(object sender, EventArgs e)
        //    {
        //        frm.SettingsClick();
        //    };
        //    mf.Width = frm.Width + 10;
        //    mf.Height = frm.Height + 35;
        //    mf.Controls.Add(frm);
        //    frm.Dock = System.Windows.Forms.DockStyle.Fill;
        //    mf.Text = frm.Name;

        //    if (color != Color.Empty)
        //        mf.TheamColor = color;

        //    frm.BringToFront();
        //    //mf.MdiParent = new frmMain();
        //    mf.Show();
        //}
        #endregion
        #region Send SMS
        static AutoResetEvent readNow = new AutoResetEvent(false);
        //public static bool sendMessage(SerialPort port, string PhoneNo, string Message)
        public static bool sendMessage(string PhoneNo, string Message)
        {
            bool isSend = false;

            try
            {
                SerialPort port = OpenPort(clsConfig.sDonglePortNo, 9600, 8, 300, 300);

                string recievedData = ExecCommand(port, "AT", 300, "No phone connected");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");
                String command = "AT+CMGS=\"" + PhoneNo + "\"";
                recievedData = ExecCommand(port, command, 300, "Failed to accept phoneNo");
                command = Message + char.ConvertFromUtf32(26) + "\r";
                recievedData = ExecCommand(port, command, 3000, "Failed to send message"); //3 seconds
                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isSend = true;
                }
                else if (recievedData.Contains("ERROR"))
                {
                    isSend = false;
                }

                ClosePort(port);
                return isSend;
            }
            catch (Exception)
            {
                throw;
            }

        }
        static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                    readNow.Set();
            }
            catch (Exception)
            {
            }
        }
        #endregion
        #region SMS Open and Close Ports
        public static AutoResetEvent receiveNow;

        //Open Port
        public static SerialPort OpenPort(string p_strPortName, int p_uBaudRate, int p_uDataBits, int p_uReadTimeout, int p_uWriteTimeout)
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();

            try
            {
                port.PortName = p_strPortName;                 //COM1
                port.BaudRate = p_uBaudRate;                   //9600
                port.DataBits = p_uDataBits;                   //8
                port.StopBits = StopBits.One;                  //1
                port.Parity = Parity.None;                     //None
                port.ReadTimeout = p_uReadTimeout;             //300
                port.WriteTimeout = p_uWriteTimeout;           //300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception)
            {
            }
            return port;
        }

        //Close Port
        public static void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port = null;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Receive data from port
        //Receive data from port
        public static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    receiveNow.Set();
                }
            }
            catch (Exception)
            {
            }
        }
        public static string ReadResponse(SerialPort port, int timeout)
        {
            string buffer = string.Empty;
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        string t = port.ReadExisting();
                        buffer += t;
                    }
                    else
                    {
                        if (buffer.Length > 0)
                            throw new ApplicationException("Response received is incomplete.");
                        else
                            throw new ApplicationException("No data received from phone.");
                    }
                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\n> ") && !buffer.EndsWith("\r\nERROR\r\n"));
            }
            catch (Exception)
            {
            }
            return buffer;
        }
        #endregion

        #region Execute AT Command
        //Execute AT Command
        public static string ExecCommand(SerialPort port, string command, int responseTimeout, string errorMessage)
        {
            try
            {
                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                string input = ReadResponse(port, responseTimeout);
                if ((input.Length == 0) || ((!input.EndsWith("\r\n> ")) && (!input.EndsWith("\r\nOK\r\n"))))
                    throw new ApplicationException("No success message was received.");
                return input;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region View Item By ItemTypID
        public static void ItemViewerByItemTypeID(string sItem, int iFormID)
        {
            try
            {
                tbl_genItemMaster item = tbl_genItemMaster.Select(sItem);
                if (item != null)
                {
                    if (item.ItemType_ID == clsAutocode.getItemTypeID(ItemTypes.FinishGood)) //if the Product is a Finished Good
                    {
                        frm_scsItemViewer_FinishedGood frm = new frm_scsItemViewer_FinishedGood();
                        if (frm.bNoAccess)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            frm.glbItemID = item.Item_ID;
                            frm.ShowDialog();
                        }
                    }
                    else if (item.ItemType_ID == clsAutocode.getItemTypeID(ItemTypes.SemiFinishedGood)) //if the Product is a Semi Finished Good
                    {
                        frm_scsItemViewer_SemiFinishedGood frm = new frm_scsItemViewer_SemiFinishedGood();
                        if (frm.bNoAccess)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            frm.glbItemID = item.Item_ID;
                            frm.ShowDialog();
                        }
                    }
                    else if (item.ItemType_ID == clsAutocode.getItemTypeID(ItemTypes.CombinationMaterial)) //if the Product is a Combination Material
                    {
                        frm_scsItemViewer_CombinationMaterial frm = new frm_scsItemViewer_CombinationMaterial();
                        if (frm.bNoAccess)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            frm.glbItemID = item.Item_ID;
                            frm.ShowDialog();
                        }
                    }
                    else if (item.ItemType_ID == clsAutocode.getItemTypeID(ItemTypes.RawMaterial)) //if the Product is a Raw Material
                    {
                        frm_scsItemViewer_RawMaterial frm = new frm_scsItemViewer_RawMaterial();
                        if (frm.bNoAccess)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            frm.glbItemID = item.Item_ID;
                            frm.ShowDialog();
                        }
                    }
                    else if (item.ItemType_ID == clsAutocode.getItemTypeID(ItemTypes.LaminatedMaterial)) //if the Product is a Laminated Material Singal
                    {
                        frm_scsItemViewer_LaminatedMaterial frm = new frm_scsItemViewer_LaminatedMaterial();
                        if (frm.bNoAccess)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            frm.glbItemID = item.Item_ID;
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        frm_scsItemViewer_RawMaterial frm = new frm_scsItemViewer_RawMaterial();
                        if (frm.bNoAccess)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            frm.glbItemID = item.Item_ID;
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events Mouse Click
        #region Sales

        public static void MouseClick_Receipt(object sender, MouseEventArgs e, string sOrderRefNo)
        {
            frmFormList frm = new frmFormList();
            frm.glbOrderRefNo = sOrderRefNo;
            frm.pn = ProcessNote.Receipt;
            frm.glbHeader = "Receipt";
            frm.glbSub = "Invoice";
            frm.ShowDialog();

            if (frm.glbReturnNoteID.Length > 0)
            {
                //  frm_bpsReceipt_Sales detail = new frm_bpsReceipt_Sales();
                //  detail.gReceiptID = frm.glbReturnNoteID;
                //  detail.ShowDialog();
            }
        }

        #endregion
        #endregion
    }
}