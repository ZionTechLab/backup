using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using Express.View.Domain.Login;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Factory.Operations;
using Express.UI.Common.Helpers;
using Express.UI.Helpers;
using FedexExpress.View.Domain.AdminConfiguration;
using Express.UI.Common.CustomValidators;
using System.Data.Common;

namespace Express.UI.Operation.OpsHelper.POD
{
    public class PodCreate : IPodCreate
    {
        private string FilePath;
        private readonly IPodScansProvider _podscanprovider;
        private MapScanTypeDomainView _scanmap;
        public PodCreate()
        {
            _podscanprovider = OperationsUIFacotry.GetService<IPodScansProvider>();
        }
        public PodScanUploadDomainView AddPods(PodScanUploadDomainView _para , IList<PodScanUploadDomainView> _existPods)
        {
            if (IsNotValidatePodScan(_para.CompanyID , _para.AgencyID , _para.ScanTypeS))
            {
                return null;
            }

            if(_existPods!=null)
            {
                if (_existPods.Where(trn => trn.Trackno.Trim() == _para.Trackno.Trim()).FirstOrDefault() != null)
                {
                    MessageNotification.MessageBoxError("Dublicate Trackno " + _para.Trackno, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    return null;
                }
            }

            if(_para.RoutID ==null || _para.RoutID.Trim() =="")
            {
                MessageNotification.MessageBoxError("please enter route ID", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return null;
            }

            if (NumberValidator.IsOnlyDecimal(_para.RoutID))
            {
                MessageNotification.MessageBoxError("please remove decimal in route ID", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return null;
            }

            if (_para.Trackno ==null || _para.Trackno.Trim()=="")
            {
                MessageNotification.MessageBoxError("Please enter track no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return null;
            }

            if (NumberValidator.IsOnlyDecimal(_para.Trackno))
            {
                MessageNotification.MessageBoxError("please remove decimal in track no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return null;
            }

            if (_para.EmployeeID == null || _para.EmployeeID.Trim() == "")
            {
                MessageNotification.MessageBoxError("Please enter employee id", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return null;


            }

            if (NumberValidator.IsOnlyDecimal(_para.EmployeeID))
            {
                MessageNotification.MessageBoxError("please remove decimal in employee no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return null;
            }


            var mCodes = GetScanMap(_para.CompanyID, _para.AgencyID, _para.ScanTypeS);
            if (mCodes == null)
            {
                MessageNotification.MessageBoxError("Coudnot find mapped scan type", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return null;
            }

            

            var _uDate = DateTime.Now.Date;
            _para.deleted = false;

            _para.ScanTypeS = mCodes.ScanTypeS;
            _para.ScanTypeP = mCodes.ScanTypeP;
            _para.ScanDescP = mCodes.RemarkP;
            _para.ScanDescS = mCodes.RemarkS;
            _para.StatusCode = "";
            _para.ScanCapture = "DE";
            _para.ScanProcess = "N";
            _para.ScanProcessErr = "";
            _para.USM_ID = LoginInfoView.USERID;
            _para.UploadTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).ToString();
            _para.UserDate = _uDate.Year.ToString() + "-" + _uDate.Month.ToString().PadLeft(2, '0') + "-" + _uDate.Day.ToString().PadLeft(2, '0');

            
            return _para;

        }

        public void CancelPods()
        {
            throw new NotImplementedException();
        }

        public IList<PodScanUploadDomainView> DeletePod(IList<PodScanUploadDomainView> _existPods, int _sRowIdx)
        {
           if( _existPods==null)
            {
                MessageNotification.MessageBoxError("There is no data to delete ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            var dValue = _existPods[_sRowIdx];

            if(dValue ==null)
            {
                MessageNotification.MessageBoxError("Can not find seleted value ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if (MessageNotification.MessageBoxConfirm("Are you sure want to delete this track no "+ dValue.Trackno+ "  ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            {
                if (dValue.ScanProcessErr.Trim() != "")
                {
                    MessageNotification.MessageBoxError("You can't delete saved record " + dValue.Trackno, LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return null;
                }

                _existPods.RemoveAt(_sRowIdx);
                return _existPods;
            }
            return _existPods;
        }

        public List<PodScanUploadDomainView> ImportPods(int CompanyID, int AgencyCode, string ScanType)
        {
            if(IsNotValidatePodScan(CompanyID , AgencyCode , ScanType ))
            {
               return null;
            }

           
            OpenFileDialog fileDialog = new OpenFileDialog();
            FilePath = "";
            fileDialog.DefaultExt = ".xlsx";
            fileDialog.Filter = "Excel files (*.xlsx)|*.xlsx;*.xls";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
               var mCodes= GetScanMap(CompanyID, AgencyCode, ScanType);
                if(mCodes ==null )
                {
                    MessageNotification.MessageBoxError("Coudnot find mapped scan type", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    return null;
                }

                FilePath = fileDialog.FileName;
                if (FilePath != null)
                {
                    // ImportMethord();
                    PodScanUploadDomainView model = null;
                    var _uDate = DateTime.Now.Date;
                    List<PodScanUploadDomainView> podList = new List<PodScanUploadDomainView>();
                    string scDate = "";
                    string scTime = "";
                    FileInfo file = new FileInfo(FilePath);
                    if (file.Extension == ".xls")
                    {
                        // sourceFile = ExcelFormatting  (sourceFile);
                       var nFilePath = ExcelFormatting.ConvertXlsx(FilePath ,  file.Directory.ToString(), file.Name);
                       file = new FileInfo(nFilePath);
                    }



                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                        int totalRows = workSheet.Dimension.Rows;

                       

                        for (int i = 2; i <= totalRows; i++)
                        {
                            scDate = "";
                            scTime = "";
                            model = new PodScanUploadDomainView();
                            model.Trackno  = TextValidator.FixSpecialCharacters(Convert.ToString(workSheet.Cells[i, 1].Value)); 
                            model.RoutID = TextValidator.FixSpecialCharacters(Convert.ToString(workSheet.Cells[i, 4].Value));
                            model.EmployeeID = TextValidator.FixSpecialCharacters(Convert.ToString(workSheet.Cells[i, 2].Value));
                            model.StatusCode = TextValidator.FixSpecialCharacters(Convert.ToString( workSheet.Cells[i, 9].Value));

                            scDate = Convert.ToString(workSheet.Cells[i,8].Value);
                            scTime = Convert.ToString(workSheet.Cells[i, 8].Value);
                            if (scDate != "" && scDate.Length >= 10)
                            {
                                var mm = Convert.ToInt32(scDate.Substring(0, 2));
                                var dd = Convert.ToInt32(scDate.Substring(3, 2));
                                var yy = Convert.ToInt32(scDate.Substring(6, 4));

                                string str_hr = scTime.Substring(10, 2);
                                string str_minit = scTime.Substring(13, 2);
                                TimeSpan scan_time = new TimeSpan(int.Parse(str_hr), int.Parse(str_minit), 0);

                                model.ScanDateTimeObj = yy.ToString() + "-" + mm.ToString().PadLeft(2, '0') + "-" + dd.ToString().PadLeft(2, '0')+' '+ scan_time.ToString(); 
                               
                                ////model.ScanDateObject = yy.ToString() + "-" + mm.ToString().PadLeft(2, '0') + "-" + dd.ToString().PadLeft(2, '0');
                                ////model.ScanTimObject = scan_time.ToString();

                            }

                            model.AgencyID = AgencyCode ;
                            model.CompanyID = CompanyID;
                            model.deleted = false;

                            model.ScanTypeS = mCodes.ScanTypeS;
                            model.ScanTypeP = mCodes.ScanTypeP;
                            model.ScanDescP = TextValidator.FixSpecialCharacters(Convert.ToString(workSheet.Cells[i, 10].Value));


                            model.ScanDescS = mCodes.RemarkS;
                            //model.ScanRoute = ScanRoute;
                            model.ScanCapture = "DE";
                            model.ScanProcess = "X";
                            model.ScanProcessErr = "";
                            model.USM_ID = LoginInfoView.USERID;
                            model.UploadTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).ToString();
                            model.UserDate = _uDate.Year.ToString() + "-" + _uDate.Month.ToString().PadLeft(2, '0') + "-" + _uDate.Day.ToString().PadLeft(2, '0');

                            if (NumberValidator.IsOnlyDecimal(model.Trackno))
                            {
                                MessageNotification.MessageBoxError(model.Trackno+" - please remove decimal in track no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                                return null;
                            }

                            if (model.Trackno.Length >15)
                            {
                                MessageNotification.MessageBoxError(model.Trackno +" -Track no exceed expected lenght", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                                return null;
                            }

                            if (NumberValidator.IsOnlyDecimal(model.EmployeeID))
                            {
                                MessageNotification.MessageBoxError(model.EmployeeID+" - please remove decimal in Fedex employee no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                                return null;
                            }

                           if( model.EmployeeID.Length >15)
                            {
                                MessageNotification.MessageBoxError(model.EmployeeID +" - Employee no exceed expected lenght", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                                return null;
                            }


                            podList.Add(model);
                        }
                    }

                    return podList;
                }
            }
            return null;
        }
        

        public void NewPods()
        {
            throw new NotImplementedException();
        }

        public ResponseMessage SavePods(IList<PodScanUploadDomainView> PodL)
        {
            ResponseMessage responce = new ResponseMessage();
            if(PodL ==null)
            {
                responce.IsSuccess = false;
                responce.StrMessage = "No data to Process/Save";
                return responce;
            }

            if(PodL.Count==0)
            {                           
                    responce.IsSuccess = false;
                    responce.StrMessage = "No data to Process/Save";
                    return responce;               
            }
            try
            {
             
                responce = _podscanprovider.SavePods(PodL);
                return responce;
            }
            catch(Exception ex)
            {
                responce.StrMessage = ex.Message;
                responce.IsSuccess = false;
                return responce;
            }
            
        }


        private void ReadExcel(string _filePath)
        {
            //using (ExcelPackage package = new ExcelPackage(_filePath))
            //{

            //}
        }

        private MapScanTypeDomainView GetScanMap(int CompanyID, int AgencyCode, string ScanType)
        {
           /// if(_scanmap==null)
            ///{
                _scanmap = _podscanprovider.GetScanTypes(CompanyID, AgencyCode, ScanType);
            //}
            return _scanmap;
        }
        private bool IsNotValidatePodScan(int CompanyID, int AgencyCode, string ScanType)
        {
            if (CompanyID == 0)
            {
                MessageNotification.MessageBoxError("Please select company", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return true  ;
            }

            if (AgencyCode == 0)
            {
                MessageNotification.MessageBoxError("Please select agency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return true  ;
            }

            if (ScanType == null || ScanType.Trim() == "")
            {
                MessageNotification.MessageBoxError("Please enter scan type", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                return true  ;
            }

            return false;
        }

        public ResponseMessage ReprocessPods( IList<PodScanUploadDomainView> PodL, PodScanUploadParaDomainView _para)
        {

            ResponseMessage responce = new ResponseMessage();
            DateTime _uDate = DateTime.Now;

            if(_para.AgencyID  == 0)
            {
                responce.StrMessage = "Please select Agency ";
                responce.IsSuccess = false;
                return responce;
            }

            if(PodL ==null)
            {
                responce.StrMessage = "There are no data to proccess";
                responce.IsSuccess = false;
                return responce;
            }

            if (PodL.Count == 0)
            {
                responce.StrMessage = "There are no data to proccess";
                responce.IsSuccess = false;
                return responce;
            }

           

            _para.PodList = PodL;
            try
            {

                responce = _podscanprovider.ReprocessPods(_para);
                return responce;
            }
            catch (Exception ex)
            {
                responce.StrMessage = ex.Message;
                responce.IsSuccess = false;
                return responce;
            }
        }
    }
}
