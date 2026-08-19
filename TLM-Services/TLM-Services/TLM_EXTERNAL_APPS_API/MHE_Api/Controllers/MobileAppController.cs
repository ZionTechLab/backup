using MHE_Api.DAL;
using MHE_Api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MHE_Api.Controllers
{  
    public class MobileAppController : ApiController
    {
        private MobileBackendData _OutstandingData;

        public MobileAppController()
        {
            _OutstandingData = new MobileBackendData();
        }

        [Authorize, HttpPost, Route("Get_Outstanding")]
        public List<OutstandingResultView> Get_Outstanding([FromBody] outstanding_Parameters obj)
        {
            return _OutstandingData.Get_Outstanding(obj);
        }

        [Authorize, HttpPost, Route("Get_InvSummary")]
        public List<InvSummaryResult> Get_InvSummary([FromBody] invsummary_Parameters obj)
        {
            return _OutstandingData.Get_InvSummary(obj);
        }

        [Authorize, HttpPost, Route("Get_InvList")]
        public List<InvListResult> Get_InvList([FromBody] invlist_Parameters obj)
        {
            return _OutstandingData.Get_InvList(obj);
        }


        [Authorize, HttpPost, Route("Post_ApprovedCollections")]
        public ReceiptResponseView Post_ApprovedCollections(List<ReceiptsDomainView> obj)
        {
            return _OutstandingData.Post_ApprovedCollections(obj);
        }
    }
}
