using System;
using System.Collections.Generic;
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
using System.IO;
using SEACC_WPFControls;
using System.Data;
using DataTire;
using Digiteq_Logic;
using System.ComponentModel;

namespace Digiteq
{
    public partial class UC_Chat : UserControl
    {
        #region Class Variables
        DataTable dt_Users = new DataTable();
        DataTable dt_Conversetions = new DataTable();
        DataTable dt_messeges = new DataTable();
        DataTable dt_ChatMsg = new DataTable(); 
        #endregion

        #region Form Load
        public UC_Chat()
        {
            InitializeComponent(); 
        } 
        #endregion

        #region Action Buttons
        private void btn_MainButtons(object sender, RoutedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btn_Chatsettings.Background = (Brush)bc.ConvertFrom("Transparent");
            btn_chatMessege.Background = (Brush)bc.ConvertFrom("Transparent");
            btn_chatConversetion.Background = (Brush)bc.ConvertFrom("Transparent");
            btn_ChatUsers.Background = (Brush)bc.ConvertFrom("Transparent");

            SEACC_Button btn = sender as SEACC_Button;

            btn.Background = (Brush)bc.ConvertFrom("White");

            grd_Settings.Visibility = Visibility.Hidden;
            grd_messeges.Visibility = Visibility.Hidden;
            grd_Users.Visibility = Visibility.Hidden;
            dgv_ChatCon.Visibility = Visibility.Hidden;

            if (btn.Name == "btn_Chatsettings")
                grd_Settings.Visibility = Visibility.Visible;
            else if (btn.Name == "btn_chatMessege")
                grd_messeges.Visibility = Visibility.Visible;
            else if (btn.Name == "btn_chatConversetion")
            {
                dgv_ChatCon.Visibility = Visibility.Visible;
            }
            else if (btn.Name == "btn_ChatUsers")
                grd_Users.Visibility = Visibility.Visible;
        }
        #endregion

        #region Refresh
        public void Refresh()
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(@"Stickers", "*.png"))
                {
                    Image img = new Image();
                    img.Source = new ImageSourceConverter().ConvertFromString(file) as ImageSource;
                    img.Tag = file;
                    img.Stretch = Stretch.Uniform;
                    img.StretchDirection = StretchDirection.Both;
                    img.Margin = new Thickness(3);
                    img.MaxWidth = img.Source.Width / 2;
                    pnl_Emo.Children.Add(img);
                    img.MouseUp += img_MouseUp;
                }
                grd_Emo.Visibility = Visibility.Hidden;

                LoadUsersToGrid();
                LoadChatConversation();

                DG_ChatHistry.ItemsSource = dt_messeges.DefaultView;
            }
            catch (Exception ex)
            {
        //        SEACCMessageBox.Show("Oops", ex.Message, MessageBoxButton.OK);
            }
        } 
        #endregion

        private void LoadChatConversation()
        {
            dt_Conversetions = DBHandling.ExecQuery("sp_getChats_relavnt_to_User "+clsSecurity.UserIDLoged).Tables[0];
            dgv_ChatConversation.ItemsSource = dt_Conversetions.DefaultView;
        }

        private void LoadChatMessages(string joinedUserId)
        {
            
        }

        #region Load Users to Chat Box
        private void LoadUsersToGrid()
        {
            dt_Users.Columns.Add("User_ID", typeof(string));
            dt_Users.Columns.Add("UserName", typeof(string));
            dt_Users.Columns.Add("Image", typeof(BitmapImage));
            dt_Users.Columns.Add("IsLoged", typeof(BitmapImage));

            foreach (tbl_securityUserMaster oUsermaster in tbl_securityUserMaster.SelectAll())
            {
                dt_Users.Rows.Add(oUsermaster.User_ID, oUsermaster.UserName, clsCommon.Convert_ByteToBitMap(oUsermaster.Image));
                //try
                //{
                //    if (oForm.IsLoged)
                //       // dt_Users.Rows.Add(oForm.User_ID, oForm.UserName, clsCommon.Convert_ByteToBitMap(oForm.Image), new BitmapImage(new Uri("file:///C:/Users/DTQUSER/Desktop/green.png")));
                //    else
                //       // dt_Users.Rows.Add(oForm.User_ID, oForm.UserName, clsCommon.Convert_ByteToBitMap(oForm.Image), new BitmapImage(new Uri("file:///C:/Users/DTQUSER/Desktop/red.jpeg")));
                //}
                //catch (Exception ex)
                //{
                //    SEACCMessageBox.Show("Oops", ex.Message, MessageBoxButton.OK);
                //}
            }

            DG_users.ItemsSource = dt_Users.DefaultView;
        } 
        #endregion

        #region Events
        void img_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image img2 = sender as Image;
            MessageBox.Show(img2.Tag.ToString());
            Image img3 = new Image();
            img3.Source = img2.Source;
            img3.Stretch = Stretch.Uniform;
            img3.StretchDirection = StretchDirection.Both;
            img3.Margin = new Thickness(3);
            img3.MaxWidth = img3.Source.Width / 1.2;
            img3.HorizontalAlignment = HorizontalAlignment.Left;
            dt_messeges.Rows.Add("", img3.Source);
            // Grd_ChatHistry.Children.Add(img3);
            //  dt_messeges.Rows.Add(new ChatLine());
            grd_Emo.Visibility = Visibility.Hidden;
        }

        private void btn_ChatEmo_Click(object sender, RoutedEventArgs e)
        {
            if (grd_Emo.Visibility == Visibility.Hidden)
                grd_Emo.Visibility = Visibility.Visible;
            else
                grd_Emo.Visibility = Visibility.Hidden;
        }

        private void btn_ChatNewLine_Click(object sender, RoutedEventArgs e)
        {
            //  ChatLine NewChatLine = new ChatLine(txt_ChatText.Text);
            //  NewChatLine.HorizontalAlignment = HorizontalAlignment.Left;
            //  NewChatLine.Width = 275;

            dt_messeges.Rows.Add(txt_ChatText.Text,null);
            //Grd_ChatHistry.Children.Add(NewChatLine); //
            txt_ChatText.Text = "";
        }



        private void chk_Merquee_Checked(object sender, RoutedEventArgs e)
        {
            FRM_Marquee_mini.CloseForm();
        }

        private void chk_Merquee_Unchecked(object sender, RoutedEventArgs e)
        {
            cls_Formater oMerquee = new cls_Formater();
            oMerquee.Marquee_Display(true, this.Width);
        }

        private void DG_users_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = DG_users.SelectedItem;
                if (item != null)
                {
                    DataRowView row = (DataRowView)DG_users.SelectedItems[0];
                    string GridID = row.Row[0].ToString();
                    grd_messeges.Visibility = Visibility.Visible;
                    grd_Settings.Visibility = Visibility.Hidden;
                    grd_Users.Visibility = Visibility.Hidden;
                    dgv_ChatCon.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        } 
        #endregion
    }
}
