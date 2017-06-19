using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorSDK.com.qingstor.sdk.model;
using QingStorSDK.com.qingstor.sdk.exception;

namespace QingStorSDK.com.qingstor.sdk.request 
{
    interface ResponseCallBack
    {
        void onAPIResponse(object output);
    }
}
