using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorIaasSDK.com.qingstor.sdk.model;
using QingStorIaasSDK.com.qingstor.sdk.exception;

namespace QingStorIaasSDK.com.qingstor.sdk.request 
{
    interface ResponseCallBack
    {
        void onAPIResponse(object output);
    }
}
