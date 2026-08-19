using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDocs.Common
{
    public class Enums
    {
        public enum SessionsEnum
        {
            UserId,
            UserName,
            UserRoleId,
            TempId,
            UserObject,           
            BranchId,
            BranchName,
            EmployeeId,
            EmployeeName,
            UserRole,
            EmployeeImage,
            UserRoleName,
            GetCompanyId,
           
        }

        public enum RedirectEnum
        {
            FileViewer = 1,


        }

        public enum UserListVal
        {
            Admin = 1,
            Staff = 2,
        }

        public enum IndexSectionsEnum
        {
            eDoc = 1,           
            InboxEmail = 2,
           
        }

        public enum InventoryReferenceEnum
        {
            GRNDetails = 1,
            ItemIssue = 2,
            InventoryReturn = 3,
            SupplierReturn = 4,
            InventoryTranfer = 5,
            InventoryAdjustment = 6,
        }

        public enum UserRolevalues
        {
           
        }

     
      

    
        public enum UserRoleList
        {
          ADMIN=1,
          STAFF=2,
        }

        public enum Priority
        {
            Low = 1,
            High = 2,
            Medium = 3,
            Moderate=4,
        }

        //public enum PageList
        //{
        //   FolderAccess= 2038,
        //   ManageFiles=2028,
        //}

        public enum TypeMasterDetailsEnum
        {
            statusActive = 1,
            statusDeactive = 2,
            statusDelete = 3,
            statusmoved = 4,
            
        }

        public enum EventType
        {
            Upload=1,
            Edit=2,
            Delete=3,
            Rename=4,
            Move=5,
            Email_Received=6,
            View =7,
            Download=8,
            Restore = 9,
            Create = 10,
        }

       

        public enum ReferenceType
        {
            [Display(Name = "Purchasing Order")]
            PurchasingOrder = 1,
            [Display(Name = "GRN")]
            GRN = 2,
            [Display(Name = "Sales Order")]
            SalesOrder = 3

        }

        public enum UserRolesEnum
        {
            Admin = 1,
            User = 9,
          
            
        }

        public enum PaymentMethod
        {
            [Display(Name = "Cash")]
            Cash = 1,
            [Display(Name = "Credit")]
            Credit = 2,
        }


        public enum CompletionStatus
        {
            [Display(Name = "Open")]
            Open = 1,
            [Display(Name = "Completed")]
            Completed = 2,
        }

        public enum ResonOfReturn
        {
            [Display(Name = "Poor Quality")]
            PoorQuality = 1,
            [Display(Name = "Incomplete")]
            Incomplete = 2,
            [Display(Name = "Damaged")]
            Damaged = 3,
            [Display(Name = "Delivered Wrong Product")]
            DeliveredWrongProduct = 4,
        }



    }
}