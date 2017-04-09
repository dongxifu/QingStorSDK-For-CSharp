using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorSDK.com.qingstor.sdk.request;

namespace QingStorSDK.com.qingstor.sdk.request
{
    class ResourceRequestFactory
    {
        
            public static ResourceRequest getResourceRequest()
            {
                return new QSRequest();
            }
        
    }
}
