using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorIaasSDK.com.qingstor.sdk.config;
using QingStorIaasSDK.com.qingstor.sdk.service;
using QingStorIaasSDK.com.qingstor.sdk.request;
using System.IO;
using System.Net;

using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace QingStorIaasSDK
{
    class Program
    {
        static void Main(string[] args)
        {

            EvnContext evn = new EvnContext("UWVDUDAMSKGAEMSGJPTC", "wex99blJOW16TJ9JOiIXeND7F9mRxDVikqc8EQe6");
            string zoneName = "pek3a";
            Instance intance = new Instance(evn, zoneName);

            Instance.DescribeInstancesInput input = new Instance.DescribeInstancesInput();
            String[] instance = { "i-3ua37u9t" };
            input.setInstances(instance);

            Instance.DescribeInstancesOutput output = new Instance.DescribeInstancesOutput();
            output = intance.DescribeInstances(input);

            Console.WriteLine (output.getInstance_set());

           
            System.Console.Read();
            
        }
    }
}
