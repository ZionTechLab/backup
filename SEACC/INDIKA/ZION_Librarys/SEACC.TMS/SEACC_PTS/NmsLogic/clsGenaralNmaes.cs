using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEACC_PTS.NmsLogic
{
    class clsGenaralNmaes
    {
        #region Get Genarel Names

        public static string getNameClient(int iClientID)
        {
            tbl_masClient oTask = tbl_masClient.Select(iClientID);
            if (oTask != null)
                return oTask.Client_Name;
            else
                return "-";
        }

        public static string getNameProduct(int iProductID)
        {
            tbl_masProduct oTask = tbl_masProduct.Select(iProductID);
            if (oTask != null)
                return oTask.Product_Name;
            else
                return "-";
        }

        public static string getNameFunction(int iFunctionID)
        {
            tbl_refFunction oTask = tbl_refFunction.Select(iFunctionID);
            if (oTask != null)
                return oTask.Function_Name;
            else
                return "-";
        }

        public static string getNameTaskType(int iTaskTypeID)
        {
            tbl_refType oTask = tbl_refType.Select(iTaskTypeID);
            if (oTask != null)
                return oTask.Type;
            else
                return "-";
        }



        public static string getNameEngineer(int iEngineerID)
        {
            tbl_masUser oTask = tbl_masUser.Select(iEngineerID);
            if (oTask != null)
                return oTask.Full_Name;
            else
                return "-";
        }


        public static string getNameStatus(int iStatusID)
        {
            tbl_refStatus oTask = tbl_refStatus.Select(iStatusID);
            if (oTask != null)
                return oTask.Status;
            else
                return "-";
        }

        public static string getNamePriorityType(int iPriorityID)
        {
            tbl_masPriority oTask = tbl_masPriority.Select(iPriorityID);
            if (oTask != null)
                return oTask.priorityType;
            else
                return "-";
        }
        #endregion

        #region Get ID using Names
        //public static string getIDCreatedUser(string sCreatedUserName)
        //{
        //    tbl_masProduct oTask = tbl_masProduct.Select(iProductID);
        //    if (oTask != null)
        //        return oTask.Product_Name;
        //    else
        //        return "-";
        //}
        #endregion

        public static DateTime getNowDate()
        {
            return DateTime.Now.Date;
        }


    }
}
