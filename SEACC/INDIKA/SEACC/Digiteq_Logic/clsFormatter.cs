//#################################
// Created By : Jayasuriya
// Date : 05/12/2010
// Purpose : to keep all common formats in a common a place
//#################################


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using DataTire;
using System.Windows.Forms.DataVisualization.Charting;

namespace Digiteq_Logic
{
    public class clsFormatter
    {
        public static string Format_Date = "yyyy/MM/dd";
        public static string Format_Date2 = "yyyy-MMM-dd";
        public static string Format_Date3 = "MM/dd/yyyy";
        public static string Format_Time = "HH:mm";
        public static string Format_DateTime = "yyyy/MM/dd HH:mm";

        public static string DigiteqTitle = "";
        public static Color DigiteqThemeColor = Color.FromArgb(247, 240, 240);

        Dictionary<int, Color> dictionary = new Dictionary<int, Color>();

        #region Grid Formats
        #region Old Formatters
        public static void ApplyGridFormat(DataGridView datag)
        {
            datag.RowHeadersVisible = false;
            datag.AllowUserToResizeRows = false;
            datag.MultiSelect = false;
            datag.ReadOnly = true;
            datag.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datag.AllowUserToAddRows = false;


            datag.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            datag.RowsDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.RowsDefaultCellStyle.ForeColor = Color.FromArgb(99, 50, 50);
            datag.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 141, 212);
            datag.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            datag.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 173, 173); //Color.FromKnownColor(KnownColor.DarkGray);
            datag.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Color.FromKnownColor(KnownColor.WindowText);
            datag.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
            datag.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText);
            datag.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void ApplyGridFormat(DataGridView datag, Color GridHeaderColor, Color CellText)
        {
            datag.RowHeadersVisible = false;
            datag.AllowUserToResizeRows = false;
            datag.MultiSelect = false;
            datag.ReadOnly = true;
            datag.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datag.AllowUserToAddRows = false;
            //  datag.SelectedRows = 


            // datag.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            datag.RowsDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.RowsDefaultCellStyle.ForeColor = CellText;
            datag.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 141, 212);
            datag.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            datag.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderColor; //Color.FromKnownColor(KnownColor.DarkGray);
            datag.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Color.FromKnownColor(KnownColor.WindowText);
            datag.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
            datag.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText);
            datag.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void ApplyGridFormatNoReadOnly(DataGridView datag, Color GridHeaderColor, Color CellText)
        {
            datag.RowHeadersVisible = false;
            datag.AllowUserToResizeRows = false;
            datag.MultiSelect = false;
            datag.ReadOnly = false;
            datag.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datag.AllowUserToAddRows = false;

            datag.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            datag.RowsDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.RowsDefaultCellStyle.ForeColor = CellText;
            datag.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 141, 212);
            datag.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            datag.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderColor; // Color.FromArgb(211, 173, 173); //Color.FromKnownColor(KnownColor.DarkGray);
            datag.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Color.FromKnownColor(KnownColor.WindowText);
            datag.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
            datag.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText);
            datag.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void ApplyGridFormatModify(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = true;
            dgv.AllowUserToOrderColumns = true;

            dgv.RowsDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            dgv.RowsDefaultCellStyle.ForeColor = Color.FromArgb(99, 50, 50);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 173, 173); //Color.FromKnownColor(KnownColor.DarkGray);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Color.FromKnownColor(KnownColor.WindowText);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void ApplyGridFormatModify(DataGridView datag, Color GridHeaderColor, Color CellText, Color BackGroundColor)
        {
            datag.RowHeadersVisible = false;
            datag.AllowUserToResizeRows = false;
            datag.MultiSelect = false;
            datag.SelectionMode = DataGridViewSelectionMode.CellSelect;
            datag.AllowUserToAddRows = false;
            datag.AllowUserToDeleteRows = true;
            datag.AllowUserToOrderColumns = true;

            datag.RowsDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.RowsDefaultCellStyle.ForeColor = CellText;
            datag.BackgroundColor = BackGroundColor;

            datag.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderColor; //Color.FromKnownColor(KnownColor.DarkGray);
            datag.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Color.FromKnownColor(KnownColor.WindowText);
            datag.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
            datag.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText);
            datag.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void ApplyGridFormatCheque(DataGridView datag)
        {
            datag.RowHeadersVisible = false;
            datag.AllowUserToResizeRows = false;
            datag.MultiSelect = false;
            datag.ReadOnly = true;
            datag.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datag.AllowUserToAddRows = false;
            datag.Columns[0].Visible = false;
            datag.Columns[1].Width = 160;
            datag.Columns[3].Width = 80;
            datag.Columns[4].Width = 60;


            datag.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            datag.RowsDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.RowsDefaultCellStyle.ForeColor = Color.FromArgb(99, 50, 50);
            datag.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 141, 212);
            datag.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            datag.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 173, 173); //Color.FromKnownColor(KnownColor.DarkGray);
            datag.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            datag.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Color.FromKnownColor(KnownColor.WindowText);
            datag.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
            datag.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText);
            datag.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion

        #region New Formatters
        public static void ApplyGridFormat_NewWithWhiteBackground(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(207, 202, 202);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(146, 71, 128);
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersHeight = 30;

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public static void ApplyGridFormat_NewWithWhiteBackground(DataGridView dataGridView, Color GridHeaderBackColor, Color GridHeaderForeColor)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderForeColor;
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersHeight = 30;

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public static void ApplyGridFormat_New(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = Color.DarkGray;
            dataGridView.BorderStyle = BorderStyle.None;

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(207, 202, 202);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(146, 71, 128);
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.DefaultCellStyle.BackColor = Color.DarkGray;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void ApplyGridFormat_New(DataGridView dataGridView, Color GridHeaderBackColor, Color GridHeaderForeColor)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = Color.DarkGray;
            dataGridView.BorderStyle = BorderStyle.None;

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderForeColor;
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 8.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            //      dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }


        public static void ApplyGridFormat_New2(DataGridView dataGridView, Color GridHeaderBackColor, Color GridHeaderForeColor)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.GridColor = Color.White;

            dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersHeight = 27;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(78)))), ((int)(((byte)(74)))));
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;



            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(193)))), ((int)(((byte)(187)))));



            //      dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
        //    dataGridView.SelectionMode = DataGridViewSelectionMode.;
            dataGridView.RowTemplate.Height = 18;


  
            //this.dgvPeriods.EnableHeadersVisualStyles = false;
            //this.dgvPeriods.Location = new System.Drawing.Point(636, 296);
            //this.dgvPeriods.MultiSelect = false;
            //this.dgvPeriods.Name = "dgvPeriods";
            //this.dgvPeriods.ReadOnly = true;
            //this.dgvPeriods.RowHeadersVisible = false;
            //this.dgvPeriods.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //this.dgvPeriods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.dgvPeriods.Size = new System.Drawing.Size(560, 392);
            //this.dgvPeriods.TabIndex = 441;
        }
       
        public static void ApplyGridFormatWithSize_New(DataGridView dataGridView, Color GridHeaderBackColor, Color GridHeaderForeColor, float Size)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = Color.DarkGray;
            dataGridView.BorderStyle = BorderStyle.None;

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBackColor;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", Size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderForeColor;
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.DefaultCellStyle.BackColor = Color.DarkGray;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", Size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        } 
        #endregion
        #endregion

        #region Handle Message boxes
        /// <summary>
        /// Can easyly get the message caption
        /// </summary>
        public static string GetMessageCaption()
        {
            return "SEACC Messaging System - [Digiteq]";
        }
        public static string GetMessageFrom(MessageType me, string CustomeMess)
        {
            string str = "";
            switch (me)
            {
                case MessageType.AskForSave:
                    str = "Do You Want To Save This Record? ";
                    break;
                case MessageType.SaveDone:
                    str = "Record Saved Successfully.";
                    break;
                case MessageType.SaveCancel:
                    str = "Record Saving Canceled!.";
                    break;
                case MessageType.AskForDelete:
                    str = "Do You Want To Delete This Record? " + CustomeMess.Trim() + "!.";
                    break;
                case MessageType.DeleteDone:
                    str = "Record Deleted Successfully.";
                    break;
                case MessageType.DataBaseError:
                    str = "Unable to connect with the database. Please exit the system and log again or call your Systems Administrator";
                    break;
                case MessageType.ErrorOnInput:
                    str = "There Is an unknown  Error On The" + CustomeMess.Trim() + "!.";
                    break;
                case MessageType.AskForModify:
                    str = "Do You Want To Modify This Record? " + CustomeMess.Trim() + "!.";
                    break;
                case MessageType.ModifyCancel:
                    str = "Record Modifying Canceled!.";
                    break;
                case MessageType.ModifyDone:
                    str = "Record Modified Successfully.";
                    break;
                case MessageType.ValidatePassword:
                    str = "Password you entered is not valid. Try again or call your Systems Administrator or email helpdesk@digiteq.biz ";
                    break;
                case MessageType.ValidateUserGroup:
                    str = "User does not belong to this Department. ";
                    break;
                case MessageType.ValidateUserName:
                    str = "Username you entered is not valid. Try again or call your Systems Administrator or email helpdesk@digiteq.biz ";
                    break;
                case MessageType.Common:
                    str = "Internal application error occurred on. Please Contact" + CustomeMess.Trim() + "!.";
                    break;
                case MessageType.RegistryError:
                    str = " registry error occurred. Please contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType.IOErrors:
                    str = "System is unable to access to the windows registry.";
                    break;
                case MessageType.ItemNotFound:
                    str = "Item Not Found";
                    break;
                case MessageType.IDIsEmpty:
                    str = "ID Cannot Be Empty";
                    break;
                case MessageType.PermissionToRead:
                    str = "Access Denied ! \n\nUser does not have access to Open this window, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToWrite:
                    str = "Access Denied ! \n\nUser does not have access to Save records, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToDelete:
                    str = "Access Denied ! \n\nUser does not have access to Delete records, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToApprove:
                    str = "Access Denied ! \n\nUser does not have access to Approve recods, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToCheck:
                    str = "Access Denied ! \n\nUser does not have access to Check records, Please get permission from the system administrator ";
                    break;
                case MessageType.AskForLineClose:
                    str = "Do You Want To Close This Job from Line\\Machine?\n" + CustomeMess.Trim() + "!.";
                    break;
                case MessageType.LineCloseDone:
                    str = "Line Closed Successfully.";
                    break;
                case MessageType.AskForSectionClose:
                    str = "Do You Want To Close This Job from Section?\n" + CustomeMess.Trim() + "!.";
                    break;
                case MessageType.SectionCloseDone:
                    str = "Section Closed Successfully.";
                    break;
                case MessageType.AskForChecked:
                    str = "Are You Sure You Want to Checked This?";
                    break;
                case MessageType.AskForApproved:
                    str = "Are You Sure You Want to Approved This?";
                    break;
                case MessageType.InvalidAmount:
                    str = "Invalid Amount ! \n\n" + CustomeMess + " should not be less than or equal to zero amount., \n\nDo You Want To Continue With This Amount?\n ";
                    break;

            }
            return str;
        }
        public static string GetMessageFrom(MessageType me)
        {
            string str = "";
            switch (me)
            {
                case MessageType.AlreadyApproved:
                    str = "Record Locked ! \n\nRecord is already approved .....";
                    break;
                case MessageType.AskForSave:
                    str = "Do You Want To Save This Record? ";
                    break;
                case MessageType.SaveDone:
                    str = "Record Saved Successfully.";
                    break;
                case MessageType.SaveCancel:
                    str = "Record Saving Canceled!.";
                    break;
                case MessageType.DeleteDone:
                    str = "Record Deleted Successfully.";
                    break;
                case MessageType.DataBaseError:
                    str = "Unable to connect with the database. Please exit the system and log again or call your Systems Administrator or email helpdesk@digiteq.biz";
                    break;
                case MessageType.ModifyCancel:
                    str = "Record Modifying Canceled!.";
                    break;
                case MessageType.ModifyDone:
                    str = "Record Modified Successfully.";
                    break;
                case MessageType.ValidatePassword:
                    str = "Password you entered is not valid. Try again or call your Systems Administrator or email helpdesk@digiteq.biz ";
                    break;
                case MessageType.ValidateUserGroup:
                    str = "User does not belong to this Department. ";
                    break;
                case MessageType.ValidateUserName:
                    str = "Username you entered is not valid. Try again or call your Systems Administrator or email helpdesk@digiteq.biz ";
                    break;
                case MessageType.IOErrors:
                    str = "System is unable to access to the windows registry.";
                    break;
                case MessageType.SoftwareExpired:
                    str = "The Software has expired. Please contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType.SoftwareExpired9182:
                    str = "9182 : Data mismatch in tables, Please optimize the database or restore last backup or please contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType.SoftwareUpdate:
                    str = "Please Install the New Update and contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType.ItemNotFound:
                    str = "Item Not Found";
                    break;
                case MessageType.IDIsEmpty:
                    str = "ID Cannot Be Empty";
                    break;
                case MessageType.PermissionToRead:
                    str = "Access Denied ! \n\nUser does not have access to Open this window, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToWrite:
                    str = "Access Denied ! \n\nUser does not have access to Save records, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToUpdate:
                    str = "Access Denied ! \n\nUser does not have access to Update records, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToDelete:
                    str = "Access Denied ! \n\nUser does not have access to Delete records, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToApprove:
                    str = "Access Denied ! \n\nUser does not have access to Approve recods, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToCheck:
                    str = "Access Denied ! \n\nUser does not have access to Check records, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToPrint:
                    str = "Access Denied ! \n\nUser does not have access to Print document, Please get permission from the system administrator ";
                    break;
                case MessageType.RecordLocked:
                    str = "Record Locked ! \n\nThe record is locked. user cannot modify the records...";
                    break;
                case MessageType.RecordLockedCantDelete:
                    str = "Record Locked ! \n\nThe record is locked. user cannot delete the records...";
                    break;
                case MessageType.DatabaseBackup:
                    str = "Database Backup Successfully.";
                    break;
                case MessageType.FileCopied:
                    str = "File Copied Successfully.";
                    break;
                case MessageType.DucumentPrinted:
                    str = "The Document Printed Successfully.";
                    break;
                case MessageType.PermissionToSectionClose:
                    str = "Access Denied ! \n\nUser does not have access to Close Sections, Please request Access Rights  from the system administrator ";
                    break;
                case MessageType.CreditLimitExceedMessage:
                    str = "Customer's available Credit Limit is Lower than Entered Amount....  Do You Still Want To Proceed ??? ";
                    break;
                case MessageType.CreditLimitExceedLock:
                    str = "Customer's available Credit Limit is Lower than Entered Amount.... ";
                    break;
                case MessageType.AlreadyDeleted:
                    str = "Record Locked ! \n\nThe record is already deleted before.....";
                    break;
                case MessageType.AlreadyPrinted:
                    str = "Record Locked ! \n\nThe record has printed before.....";
                    break;
                case MessageType.GINdoneForSRN:
                    str = "Record Locked ! \n\nYou are unable to delete this SRN as there is an already active GIN for this SRN .....";
                    break;
                case MessageType.GRNdoneForGIN:
                    str = "Record Locked ! \n\nYou are unable to delete this GIN as there is an already active GRN for this GIN.....";
                    break;
                case MessageType.AlreadyActive:
                    str = "Record Locked ! \n\nYou are unable to Active this Financial Year.....";
                    break;
                case MessageType.CustomerIsBlackListed:
                    str = "Black Listed Customer ! \n\nYou are unable to create customer orders for Black Listed Customer.....";
                    break;
                case MessageType.SupplierIsBlackListed:
                    str = "This Supplier is Blacklisted ! \n\nTherefore the requested function will not be proceed further \n\nPlease contact your super user or IT team to De-Blacklist this supplier.....";
                    break;
                case MessageType.SupplierIsSuspended:
                    str = "This Supplier is Suspended ! \n\nTherefore the requested function will not be proceed further \n\nPlease contact your super user or IT team to De-Suspend this supplier.....";
                    break;
                case MessageType.VersionInCompatible:
                    str = "Software Version is Incompatible, Please contact your Systems Administrator or Helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType.RecordUpdateIsBlock:
                    str = "This Record Cannot Be Update....";
                    break;
                case MessageType.GLPostedtransactions:
                    str = "Modifications not allowed for GL Posted transactions. Please contact your Accountant..!.";
                    break;
                case MessageType.UserIsBlocked:
                    str = "This User account has been expired,  Please contact your Systems Administrator or email to sales@digiteq.biz";
                    break;
                case MessageType.GLInvalidFinancialYear:
                    str = "This is an Invalid Financial Year, Please check the transaction date in par with the respective Financial Year' period";
                    break;
                case MessageType.PurgeDone:
                    str = "Record Purged Successfully.";
                    break;
                case MessageType.GRNdoneForPO:
                    str = "Record Locked ! \n\nYou are unable to delete this PO as there is an already active GRN for this PO .....";
                    break;
                case MessageType.MainStoreNotAllowed:
                    str = "Two Main Stores Are Not Allowed.";
                    break;
                case MessageType.ApproveProdibit:
                    str = "Item modification is not allowed. Good Receive Note is already Approved.";
                    break;
                case MessageType.PermissionToWrite_Store:
                    str = "Access Denied ! \n\nUser does not have access to Save records  for This Store, Please get permission from the system administrator ";
                    break;
                case MessageType.PermissionToUpdate_Store:
                    str = "Access Denied ! \n\nUser does not have access to Update records for This Store, Please get permission from the system administrator ";
                    break;
                case MessageType.AskForChecked:
                    str = "Are You Sure You Want to Checked This?";
                    break;
                case MessageType.AskForApproved:
                    str = "Are You Sure You Want to Approved This?";
                    break;
                case MessageType.EnterMinusValues:
                    str = "Grand total could not be less than Zero '0'";
                    break;
            }
            return str;
        }


        #region POS Messages
        public static string GetMessageFrom_POS(MessageType_POS me)
        {
            string str = "";
            switch (me)
            {
                case MessageType_POS.AskForSave:
                    str = "Do You Want To Save This Record? ";
                    break;
                case MessageType_POS.SaveDone:
                    str = "Record Saved Successfully.";
                    break;
                case MessageType_POS.SaveCancel:
                    str = "Record Saving Canceled!.";
                    break;
                case MessageType_POS.DeleteDone:
                    str = "Record Deleted Successfully.";
                    break;
                case MessageType_POS.DataBaseError:
                    str = "Unable to connect with the database. Please exit the system and log again or call your Systems Administrator or email helpdesk@digiteq.biz";
                    break;
                case MessageType_POS.ModifyCancel:
                    str = "Record Modifying Canceled!.";
                    break;
                case MessageType_POS.ModifyDone:
                    str = "Record Modified Successfully.";
                    break;
                case MessageType_POS.ValidatePassword:
                    str = "Password you entered is not valid. Try again or call your Systems Administrator or email helpdesk@digiteq.biz ";
                    break;
                case MessageType_POS.ValidateUserGroup:
                    str = "User does not belong to this Department. ";
                    break;
                case MessageType_POS.ValidateUserName:
                    str = "Username you entered is not valid. Try again or call your Systems Administrator or email helpdesk@digiteq.biz ";
                    break;
                case MessageType_POS.IOErrors:
                    str = "System is unable to access to the windows registry.";
                    break;
                case MessageType_POS.SoftwareExpired:
                    str = "The Software has expired. Please contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType_POS.SoftwareExpired9182:
                    str = "9182 : Data mismatch in tables, Please optimize the database or restore last backup or please contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType_POS.SoftwareUpdate:
                    str = "Please Install the New Update and contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType_POS.ItemNotFound:
                    str = "Item Not Found";
                    break;
                case MessageType_POS.IDIsEmpty:
                    str = "ID Cannot Be Empty";
                    break;
                case MessageType_POS.PermissionToRead:
                    str = "Access Denied ! \n\nUser does not have access to Open this window, Please get permission from the system administrator ";
                    break;
                case MessageType_POS.PermissionToWrite:
                    str = "Access Denied ! \n\nUser does not have access to Save records, Please get permission from the system administrator ";
                    break;
                case MessageType_POS.PermissionToUpdate:
                    str = "Access Denied ! \n\nUser does not have access to Update records, Please get permission from the system administrator ";
                    break;
                case MessageType_POS.PermissionToDelete:
                    str = "Access Denied ! \n\nUser does not have access to Delete records, Please get permission from the system administrator ";
                    break;
                case MessageType_POS.PermissionToApprove:
                    str = "Access Denied ! \n\nUser does not have access to Approve recods, Please get permission from the system administrator ";
                    break;
                case MessageType_POS.PermissionToCheck:
                    str = "Access Denied ! \n\nUser does not have access to Check records, Please get permission from the system administrator ";
                    break;
                case MessageType_POS.PermissionToPrint:
                    str = "Access Denied ! \n\nUser does not have access to Print document, Please get permission from the system administrator ";
                    break;
                case MessageType_POS.RecordLocked:
                    str = "Record Locked ! \n\nThe record is locked. user cannot modify the records...";
                    break;
                case MessageType_POS.RecordLockedCantDelete:
                    str = "Record Locked ! \n\nThe record is locked. user cannot delete the records...";
                    break;
                case MessageType_POS.DatabaseBackup:
                    str = "Database Backup Successfully.";
                    break;
                case MessageType_POS.FileCopied:
                    str = "File Copied Successfully.";
                    break;
                case MessageType_POS.DucumentPrinted:
                    str = "The Document Printed Successfully.";
                    break;
                case MessageType_POS.PermissionToSectionClose:
                    str = "Access Denied ! \n\nUser does not have access to Close Sections, Please request Access Rights  from the system administrator ";
                    break;
                case MessageType_POS.CreditLimitExceedMessage:
                    str = "Customer's available Credit Limit is Lower than Entered Amount....  Do You Still Want To Proceed ??? ";
                    break;
                case MessageType_POS.CreditLimitExceedLock:
                    str = "Customer's available Credit Limit is Lower than Entered Amount.... ";
                    break;
                case MessageType_POS.AlreadyDeleted:
                    str = "Record Locked ! \n\nThe record is already deleted before.....";
                    break;
                case MessageType_POS.AlreadyPrinted:
                    str = "Record Locked ! \n\nThe record has printed before.....";
                    break;
                case MessageType_POS.GINdoneForSRN:
                    str = "Record Locked ! \n\nYou are unable to delete this SRN as there is an already active GIN for this SRN .....";
                    break;
                case MessageType_POS.GRNdoneForGIN:
                    str = "Record Locked ! \n\nYou are unable to delete this GIN as there is an already active GRN for this GIN.....";
                    break;
                case MessageType_POS.AlreadyActive:
                    str = "Record Locked ! \n\nYou are unable to Active this Financial Year.....";
                    break;
                case MessageType_POS.CustomerIsBlackListed:
                    str = "Black Listed Customer ! \n\nYou are unable to create customer orders for Black Listed Customer.....";
                    break;
                case MessageType_POS.SupplierIsBlackListed:
                    str = "This Supplier is Blacklisted ! \n\nTherefore the requested function will not be proceed further \n\nPlease contact your super user or IT team to De-Blacklist this supplier.....";
                    break;
                case MessageType_POS.SupplierIsSuspended:
                    str = "This Supplier is Suspended ! \n\nTherefore the requested function will not be proceed further \n\nPlease contact your super user or IT team to De-Suspend this supplier.....";
                    break;
                case MessageType_POS.VersionInCompatible:
                    str = "Software Version is Incompatible, Please contact your Systems Administrator or Helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity.DigiteqTelephone + " Email: " + clsSecurity.DigiteqEmail;
                    break;
                case MessageType_POS.RecordUpdateIsBlock:
                    str = "This Record Cannot Be Update....";
                    break;
                case MessageType_POS.GLPostedtransactions:
                    str = "Cancel not allowed for GL Posted transactions. Please contact your Accountant..!.";
                    break;
                case MessageType_POS.UserIsBlocked:
                    str = "This User account has been expired,  Please contact your Systems Administrator or email to sales@digiteq.biz";
                    break;
                case MessageType_POS.GLInvalidFinancialYear:
                    str = "This is an Invalid Financial Year, Please check the transaction date in par with the respective Financial Year' period";
                    break;
                case MessageType_POS.PurgeDone:
                    str = "Record Purged Successfully.";
                    break;
                case MessageType_POS.GRNdoneForPO:
                    str = "Record Locked ! \n\nYou are unable to delete this PO as there is an already active GRN for this PO .....";
                    break;
                case MessageType_POS.MainStoreNotAllowed:
                    str = "Two Main Stores Are Not Allowed.";
                    break;
                case MessageType_POS.ApproveProdibit:
                    str = "Item modification is not allowed. Good Receive Note is already Approved.";
                    break;
            }
            return str;
        }
        #endregion

        public static string getCommonStatusStripMessage(StatusStripMessageTypes stmt, string Customemess)
        {
            string str = "";
            switch (stmt)
            {
                case StatusStripMessageTypes.WhenInsert:
                    str = "Please Check the Following Field(s) As It Cannot Be Empty !!!! \n" + Customemess;
                    break;
                case StatusStripMessageTypes.WhenUpdate:
                    str = "Please Check the Following Field(s) As It Cannot Be Empty !!!! \n";
                    break;
                case StatusStripMessageTypes.WhenDelete:
                    str = "Record has been Deleted........\n";
                    break;
                case StatusStripMessageTypes.DataGridClick:
                    str = "System is navigating the record........\n";
                    break;
                case StatusStripMessageTypes.Afterinsert:
                    str = "Record has been Successfully Insert into Database......\n";
                    break;
                case StatusStripMessageTypes.Afterupdate:
                    str = "Record has been Successfully Update in Database........\n";
                    break;
                case StatusStripMessageTypes.AfterCancel:
                    str = "Ready";
                    break;
                case StatusStripMessageTypes.WhenInserNumber:
                    str = "Please Check the Below Fields [Numbers Only]..............\n " + Customemess;
                    break;
            }
            return str;
        }

        public static string GetMessageAudit(AuditStatus au)
        {
            string str = "";
            switch (au)
            {
                case AuditStatus.RecordSave:
                    str = "Save Record ";
                    break;
                case AuditStatus.RecordDelete:
                    str = "Delete Recoed";
                    break;
                case AuditStatus.RecordModify:
                    str = "Modify Recoed";
                    break;
                case AuditStatus.ViewReport:
                    str = "Report View";
                    break;
                default:
                    break;
            }
            return str;
        }

        public static string GetMessageError(MessageTypes_GenaralError msg)
        {
            string str = "";
            switch (msg)
            {
                case MessageTypes_GenaralError.BackDateError:
                    str = "Date is Invalid - Cannot Backdate";
                    break;
                case MessageTypes_GenaralError.ForwardDateError:
                    str = "Date is Invalid - Cannot Change Date Forward";
                    break;
                default:
                    break;
            }
            return str;
        }
        #endregion

        #region Colour Cods
        public static Color colorRawMaterials = Color.FromArgb(99, 50, 50);
        public static Color colorSemiFinishedGoods = Color.FromArgb(175, 97, 97);
        public static Color colorFinishedGoods = Color.FromArgb(206, 159, 59);

        public static Color colorGeneralSupplier = Color.FromArgb(99, 50, 50);
        public static Color colorCorporateSupplier = Color.FromArgb(175, 97, 97);
        public static Color colorSalesRep = Color.FromArgb(206, 159, 59);

        public static Color colorGeneralCustomer = Color.FromArgb(99, 50, 50);
        public static Color colorCorporateCustomer = Color.FromArgb(175, 97, 97);
        public static Color colorSalesRepCustomer = Color.FromArgb(206, 159, 59);

        //cheque status colors
        public static Color colorChequeNew = Color.FromArgb(150, 103, 3); //Color.FromArgb(206, 159, 59);
        public static Color colorChequeDeposited = Color.FromArgb(40, 0, 91);
        public static Color colorChequeReleasedToSup = Color.FromArgb(35, 58, 119);//Color.FromArgb(0, 166, 166)
        public static Color colorChequeRealized = Color.FromArgb(55, 99, 42);//Color.FromArgb(0, 187, 94)
        public static Color colorChequeReturned_R = Color.FromArgb(99, 50, 50); //Color.FromArgb(99, 60, 60);
        public static Color colorChequeReturned_NR_C = Color.FromArgb(196, 56, 40);
        public static Color colorChequeReturned_NR_O = Color.FromArgb(217, 87, 72);
        public static Color colorChequeReDeposit = Color.FromArgb(106, 0, 213);
        public static Color colorChequeDeleted = Color.DarkRed;

        public static Color colorDigiteqTheamColor1 = Color.FromArgb(191, 201, 200);
        public static Color colorDigiteqTheamColor2 = Color.FromArgb(220, 221, 200);
        public static Color colorDigiteqTheamColorPsmForColour = Color.DarkSlateGray;
        public static Color colorDigiteqTheamColorPsmBackColour = Color.DarkGray;

        public static Color colorDigiteqTheamColorSales1 = Color.FromArgb(180, 205, 205);
        public static Color colorDigiteqTheamColorSales1BackColour = Color.DarkGray;
        public static Color colorDigiteqTheamColorSales1ForColour = Color.DarkGreen;
        public static Color colorDigiteqTheamColorSales1GridHeader = Color.FromArgb(140, 179, 179);
        public static Color colorDigiteqTheamColorSales2 = Color.FromArgb(200, 160, 180);
        public static Color colorDigiteqTheamColorSales2BackColour = Color.DarkGray;
        public static Color colorDigiteqTheamColorSales2ForColour = Color.FromArgb(150, 61, 128);

        public static Color colorDigiteqTheamColorMaster = Color.FromArgb(140, 199, 199);
        public static Color colorDigiteqTheamColorMasterBackColour = Color.DarkGray;
        public static Color colorDigiteqTheamColorMasterForColour = Color.DarkGreen;


        public static Color colorDigiteqTheamColorAdmin = Color.FromArgb(200, 160, 180);
        public static Color colorDigiteqTheamColorAdminForColour = Color.FromArgb(121, 70, 96);
        public static Color colorDigiteqTheamColorAdminHeaderColour = Color.FromArgb(179, 123, 151);

        public static Color colorDigiteqTheamColorStock1 = Color.FromArgb(180, 205, 205);
        public static Color colorDigiteqTheamColorStockForColour = Color.DarkGreen; //Color.FromArgb(0, 64, 128);
        public static Color colorDigiteqTheamColorStockBackColour = Color.DarkGray;// Color.FromArgb(108,185,189);
        public static Color colorDigiteqTheamColorStock2 = Color.FromArgb(150, 150, 180);

        public static Color colorDigiteqTheamColorAccount1 = Color.FromArgb(210, 211, 200);
        public static Color colorDigiteqTheamColorAccount2 = Color.FromArgb(191, 201, 200);

        public static Color colorDigiteqTheamColorSearch = Color.FromArgb(200, 160, 180);
        public static Color colorDigiteqTheamColorSearchForColour = Color.FromArgb(99, 50, 50);
        public static Color colorDigiteqTheamColorSearchHeaderColour = Color.FromKnownColor(KnownColor.Control);


        public static Color colorInProgress = Color.FromArgb(99, 50, 50);
        public static Color colorCompleted = Color.Black;
        public static Color colorDeleted = Color.Red;
        public static Color colorFinished = Color.Green;

        public static Color colorStatusUnApprovedUnChecked = Color.FromArgb(99, 50, 50);
        public static Color colorStatusUnChecked = Color.Navy;
        public static Color colorStatusUnApproved = Color.Teal;
        public static Color colorStatusCancelled = Color.Red;
        public static Color colorStatusApprovedChecked = Color.Green;


        #region Colors For New Forms n Grids
        public static Color colorSales = Color.FromArgb(117, 82, 107);
        public static Color colorAccounts = Color.FromArgb(146, 71, 128);
        public static Color colorStock = Color.FromArgb(38, 136, 133);
        public static Color colorBills = Color.FromArgb(63, 117, 162);
        public static Color colorAdmin = Color.FromArgb(102, 102, 102);
        public static Color colorMasters = Color.FromArgb(153, 102, 102);

        public static Color colorGrid = Color.FromArgb(207, 202, 202);
        #endregion
        #endregion

        #region Dates & Times

        //Added by Gayan 2016-08-13
        public static string FormatDate_SL(DateTime dt)
        {
            return dt.ToString("yyyy-MMM-dd");
        }

        public static string FormatDate_Short(DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy");
        }
        public static string FormatDate_Short_WithTime(DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy HH:mm");
        }
        public static string FormatTime_Short(DateTime dt)
        {
            return dt.ToShortTimeString();
        }
        public static string FormatDate_FullString(DateTime dt)
        {
            string sValue = dt.ToString("yyyy''MM''dd''HH''mm''ss");
            return sValue;
        }
        #endregion



        #region TextBox Dissable Mode
        public static void Format_TextBox_DisableMode(TextBox txtControl)
        {
            txtControl.BackColor = System.Drawing.SystemColors.Control;
            txtControl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtControl.ForeColor = System.Drawing.Color.DimGray;
            txtControl.ReadOnly = true;
        }
        #endregion

        #region Format Form
        public static void setFormatForm(Form myForm, string sFormName, int iModule, int iFormID)
        {
            try
            {
                if (sFormName.Trim().Length > 0)
                    myForm.Text = clsFormatter.DigiteqTitle + " - F" + iFormID.ToString("0000") + " - " + sFormName;
                foreach (Control con in myForm.Controls)
                {
                    if (con is GroupBox)
                    {
                        foreach (Control con1 in con.Controls)
                        {
                            if (con1 is Panel || con1 is TabControl)
                                setFormatFormArrange(con1, iModule);
                        }
                    }
                    else if (con is Panel || con is TabControl)
                    {
                        setFormatFormArrange(con, iModule);
                        foreach (Control con1 in con.Controls)
                        {
                            if (con1 is Panel || con1 is TabControl)
                                setFormatFormArrange(con1, iModule);
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }
        public static void setFormatFormArrange(Control con, int iModule)
        {
            string preFix = con.Name.Substring(0, 1);
            if (con is Panel)
            {
                setFormatFormFillColour(con, iModule);
            }
            else if (con is TabControl)
            {
                TabControl tb = (TabControl)con;
                for (int a = 0; a > tb.TabCount; a++)
                {
                    TabPage tbp = tb.TabPages[a];
                    setFormatFormFillColour(tbp, iModule);
                }
            }
        }
        public static void setFormatFormFillColour(Control con, int iModule)
        {
            string preFix = con.Name.Substring(0, 1);
            if (iModule == 1) //Admin
            {
                if (preFix.ToLower() == "x")
                    con.BackColor = clsFormatter.colorDigiteqTheamColorAdmin;
                else if (preFix.ToLower() == "z")
                    con.BackColor = clsFormatter.colorDigiteqTheamColorAdmin;
            }
            else if (iModule == 2) //Sales
            {
                if (preFix.ToLower() == "x")
                    con.BackColor = clsFormatter.colorDigiteqTheamColorSales1;
                else if (preFix.ToLower() == "z")
                    con.BackColor = clsFormatter.colorDigiteqTheamColorSales2;
            }
            else if (iModule == 3) //PMS
            {
                if (preFix.ToLower() == "x")
                    con.BackColor = clsFormatter.colorDigiteqTheamColor1;
                else if (preFix.ToLower() == "z")
                    con.BackColor = clsFormatter.colorDigiteqTheamColor2;
            }
            else if (iModule == 4) //Stock
            {
                if (preFix.ToLower() == "x")
                    con.BackColor = clsFormatter.colorDigiteqTheamColorStock1;
                else if (preFix.ToLower() == "z")
                    con.BackColor = clsFormatter.colorDigiteqTheamColorStock2;
            }
            else if (iModule == 5) //Search
            {
                //if (preFix.ToLower() == "x")
                //    con.BackColor = clsFormatter.colorDigiteqTheamColorStock1;
                //else if (preFix.ToLower() == "z")
                //    con.BackColor = clsFormatter.colorDigiteqTheamColorStock2;
            }
            else if (iModule == 6) //Account
            {
                if (preFix.ToLower() == "x")
                    con.BackColor = clsFormatter.colorDigiteqTheamColorAccount1;
                else if (preFix.ToLower() == "z")
                    con.BackColor = clsFormatter.colorDigiteqTheamColorAccount2;
            }
        }
        #endregion

        public static decimal RoundDecimalPlaces(decimal dCurrency)
        {
            dCurrency = Math.Round(dCurrency, 2);        
            return dCurrency;
        }
        public static decimal RoundDecimalPlaces_UnitPrice(decimal dCurrency)
        {
            dCurrency = Math.Round(dCurrency, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            return dCurrency;
        }
        public static decimal RoundDecimalPlaces_WeightPrice(decimal dCurrency)
        {
            dCurrency = Math.Round(dCurrency, clsConfig.sCurrencyDecimalPlaces_WeightPrice);
            return dCurrency;
        }
        public static decimal RoundDecimalPlaces_Quantity(decimal dCurrency)
        {
            dCurrency = Math.Round(dCurrency, clsConfig.sDecimalPlaces_Quantity);
            return dCurrency;
        }
        public static decimal RoundDecimalPlaces_Weight(decimal dCurrency)
        {
            dCurrency = Math.Round(dCurrency, clsConfig.sDecimalPlaces_Weight);
            return dCurrency;
        }

        public static string FormatToCurrecy(decimal dCurrency)
        {
            string value = "0.00";
            value = String.Format("{0:0.00}", dCurrency);
            return value;
        }
        public static string FormatToCurrecyWithThreeDecimalPlaces(decimal dCurrency)
        {
            string value = "0.00";
            value = String.Format("{0:0.000}", dCurrency);
            return value;
        }
        public static string FormatToCurrecyWithFourDecimalPlaces(decimal dCurrency)
        {
            string value = "0.00";
            value = String.Format("{0:0.0000}", dCurrency);
            return value;
        }
        public static string FormatToCurrecyWithThousendSep(decimal dCurrency)
        {
            string value = "0.00";
            value = String.Format("{0:0,0.00}", dCurrency);
            return value;
        }
        public static string FormatToNumberNoDecimal(decimal dWeight)
        {
            string value = "0.0000";
            value = String.Format("{0:0}", dWeight);
            return value;
        }
        public static string FormatToNumberWithFourDecimalPlaces(decimal dWeight)
        {
            string value = "0.0000";
            value = String.Format("{0:0.0000}", dWeight);
            return value;
        }
        public static string FormatToNumberWithOneDecimalPlaces(decimal dWeight)
        {
            string value = "0.0000";
            value = String.Format("{0:0.0}", dWeight);
            return value;
        }
        public static string FormatToNumberWithOneDecimalPlaces_ThousandSeparator(decimal dWeight)
        {
            string value = "0.0000";
            value = String.Format("{0:#,0.0}", dWeight);
            return value;
        }
        public static string FormatToNumberWithTwoDecimalPlaces(decimal dWeight)
        {
            string value = "0.0000";
            value = String.Format("{0:0.00}", dWeight);
            return value;
        }
        public static string FormatDecimal(decimal dValue, string sDecimalPlaces)
        {
            string value = "0.00";
            try
            {
                value = FormatDecimal(dValue, int.Parse(sDecimalPlaces));
            }
            catch (Exception ex)
            {
             //   SEACCException.Show(ex);
            }
            return value;
        }

        public static string FormatDecimal(decimal dValue, int DecimalPlaces)
        {
            string value = "0.00";
            string sFormat = "";

            switch (DecimalPlaces)
            {
                case 0:
                    sFormat = "{0:#,0}";
                    break;
                case 1:
                    sFormat = "{0:#,0.0}";
                    break;
                case 2:
                    sFormat = "{0:#,0.00}";
                    break;
                case 3:
                    sFormat = "{0:#,0.000}";
                    break;
                case 4:
                    sFormat = "{0:#,0.0000}";
                    break;
                case 5:
                    sFormat = "{0:#,0.00000}";
                    break;
                default:
                    break;
            }

            value = String.Format(sFormat, dValue);
            return value;
        }
        // string fmt2 = "#,##0.00;(#,##0.00)"; 

        #region Format To Decimal Places
        public static string FormatDecimalPlaces_Price(decimal dCurrency)
        {
            string value = "0.00";
            value = String.Format("{0:#,0.00}", dCurrency);
            return value;
        }
        public static string FormatDecimalPlaces_UnitPrice(decimal dCurrency)
        {
            string value = "0.00";
            if (clsConfig.sCurrencyDecimalPlaces_UnitPrice == 1)
                value = String.Format("{0:#,0.0}", dCurrency);
            else if (clsConfig.sCurrencyDecimalPlaces_UnitPrice == 2)
                value = String.Format("{0:#,0.00}", dCurrency);
            else if (clsConfig.sCurrencyDecimalPlaces_UnitPrice == 3)
                value = String.Format("{0:#,0.000}", dCurrency);
            else if (clsConfig.sCurrencyDecimalPlaces_UnitPrice == 4)
                value = String.Format("{0:#,0.0000}", dCurrency);
            else if (clsConfig.sCurrencyDecimalPlaces_UnitPrice == 5)
                value = String.Format("{0:#,0.00000}", dCurrency);
            return value;
        }
        public static string FormatDecimalPlaces_WeightPrice(decimal dCurrency)
        {
            string value = "0.00";
            if (clsConfig.sCurrencyDecimalPlaces_WeightPrice == 1)
                value = String.Format("{0:#,0.0}", dCurrency);
            else if (clsConfig.sCurrencyDecimalPlaces_WeightPrice == 2)
                value = String.Format("{0:#,0.00}", dCurrency);
            else if (clsConfig.sCurrencyDecimalPlaces_WeightPrice == 3)
                value = String.Format("{0:#,0.000}", dCurrency);
            else if (clsConfig.sCurrencyDecimalPlaces_WeightPrice == 4)
                value = String.Format("{0:#,0.0000}", dCurrency);
            else if (clsConfig.sCurrencyDecimalPlaces_WeightPrice == 5)
                value = String.Format("{0:#,0.00000}", dCurrency);
            return value;
        }
        public static string FormatDecimalPlaces_Quantity(decimal dCurrency)
        {
            string value = "0.00";
            if (clsConfig.sDecimalPlaces_Quantity == 0)
                value = String.Format("{0:#,0}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Quantity == 1)
                value = String.Format("{0:#,0.0}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Quantity == 2)
                value = String.Format("{0:#,0.00}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Quantity == 3)
                value = String.Format("{0:#,0.000}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Quantity == 4)
                value = String.Format("{0:#,0.0000}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Quantity == 5)
                value = String.Format("{0:#,0.00000}", dCurrency);
            return value;
        }
        public static string FormatDecimalPlaces_Weight(decimal dCurrency)
        {
            string value = "0.00";
            if (clsConfig.sDecimalPlaces_Weight == 0)
                value = String.Format("{0:#,0}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Weight == 1)
                value = String.Format("{0:#,0.0}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Weight == 2)
                value = String.Format("{0:#,0.00}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Weight == 3)
                value = String.Format("{0:#,0.000}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Weight == 4)
                value = String.Format("{0:#,0.0000}", dCurrency);
            else if (clsConfig.sDecimalPlaces_Weight == 5)
                value = String.Format("{0:#,0.00000}", dCurrency);
            return value;
        }
        #endregion

        #region Format Zero Values to Dash
        public static string FormatZeroValueToDash(decimal dValue, decimal dDecimalPlaces)
        {
            string value = "0";
            if (dValue == 0)
                value = "-";
            else
            {
                if (dDecimalPlaces == 0)
                    value = String.Format("{0:0,0}", dValue);
                else if (dDecimalPlaces == 1)
                    value = String.Format("{0:0,0.0}", dValue);
                else if (dDecimalPlaces == 2)
                    value = String.Format("{0:0,0.00}", dValue);
                else if (dDecimalPlaces == 3)
                    value = String.Format("{0:0,0.000}", dValue);
                else if (dDecimalPlaces == 4)
                    value = String.Format("{0:0,0.0000}", dValue);
                else if (dDecimalPlaces == 5)
                    value = String.Format("{0:0,0.00000}", dValue);
                else if (dDecimalPlaces == 6)
                    value = String.Format("{0:0,0.000000}", dValue);

            }
            return value;
        }
        #endregion

        #region Get Month Name
        public static string GetMonthName(int Month)
        {
            if (Month == 0)
                Month = 1;

            string sMonth = "";
            System.Globalization.DateTimeFormatInfo MonthName = new System.Globalization.DateTimeFormatInfo();
            sMonth = MonthName.GetMonthName(Month);
            return sMonth;
        }
        #endregion
    }
}
