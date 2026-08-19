using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace Digiteq
{
    public partial class UC_Notes : UserControl
    {
        #region Class Variables
        DataTable dtMain = new DataTable();
        bool IsUpdateMode = false;
        #endregion

        #region Form Load
        public UC_Notes()
        {
            #region Initialize Usercontrol
            InitializeComponent(); 
            #endregion

            #region Initialize Data Table
            dtMain.Columns.Add("NoteID");
            dtMain.Columns.Add("Note");
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("ID", "NoteID", 0);
            dgr_Main.Add_DatagridColoumn("Note", "Note", 180);
            dgr_Main.setDatagrid_HeaderVisibility(false); 
            #endregion

            RefreshGrid();
        } 
        #endregion

        #region Action Button
        private void btn_Addnew_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ChekValidity())
            {
                try
                {
                    #region Update
                    if (IsUpdateMode)
                    {
                        string NoteContect = new TextRange(txtNoteArea.Document.ContentStart, txtNoteArea.Document.ContentEnd).Text;
                        tbl_cfg_Note oldRecord = tbl_cfg_Note.Select(txtNoteArea.Tag.ToString());
                        if (oldRecord != null)
                        {
                            tbl_cfg_Note detail = new tbl_cfg_Note(txtNoteArea.Tag.ToString(), NoteContect, oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.UserID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                            detail.Update();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        string NoteContect = new TextRange(txtNoteArea.Document.ContentStart, txtNoteArea.Document.ContentEnd).Text;
                        tbl_cfg_Note detail = new tbl_cfg_Note(txtNoteArea.Tag.ToString(), NoteContect, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime);
                        detail.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    } 
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    RefreshGrid();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsUpdateMode)
                {
                    if (txtNoteArea.Tag.ToString() != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_cfg_Note detail = tbl_cfg_Note.Select(txtNoteArea.Tag.ToString());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFields();
                                RefreshGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btn_GridHide_Click(object sender, RoutedEventArgs e)
        {
            if (grd_rightPanal.Visibility == Visibility.Visible)
                grd_rightPanal.Visibility = Visibility.Hidden;
            else
                grd_rightPanal.Visibility = Visibility.Visible;
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdateMode = false;
            txtNoteArea.Document.Blocks.Clear();
            txtNoteArea.Tag = null;
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dtMain.Clear();
                foreach (tbl_cfg_Note details in tbl_cfg_Note.SelectAll().Where(p => p.IsCanceled == false))
                {
                    dtMain.Rows.Add(details.Note_ID, details.Note);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool ChekValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
                bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            bool bStatus = true;
            if (txtNoteArea.Document.ToString()=="")
            {
                bStatus = false;
            }

            return bStatus;
        } 
        #endregion
        
        #region Grid Event
        private void grd_Note_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    if (GridID != null)
                    {
                        txtNoteArea.Tag= GridID;
                        IsUpdateMode = true;
                        tbl_cfg_Note detail = tbl_cfg_Note.Select(txtNoteArea.Tag.ToString());
                        TextRange TextRange = new TextRange(txtNoteArea.Document.ContentStart, txtNoteArea.Document.ContentEnd);
                        TextRange.Text = detail.Note.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion  
    }
}