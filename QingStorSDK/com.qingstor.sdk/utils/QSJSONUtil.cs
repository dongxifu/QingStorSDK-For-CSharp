﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net;
using System.Reflection;
using QingStorSDK.com.qingstor.sdk.Attribute;
using System.IO;

namespace QingStorSDK.com.qingstor.sdk.utils
{
    class QSJSONUtil
    {
        public static Dictionary<String, Object> JsonToDictionary(object json)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();

                if (json != null)
                {
                    return jss.Deserialize<Dictionary<String, Object>>(json.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*public static Dictionary<String, Object> toDictonary(JSONObject object) throws JSONException {
        Map<String, Object> map = new HashMap<String, Object>();
        try {
            Iterator<String> keysItr = object.keys();
            while (keysItr.hasNext()) {
                String key = keysItr.next();
                Object value = object.get(key);

                if (value instanceof JSONArray) {
                    value = toList((JSONArray) value);
                } else if (value instanceof JSONObject) {
                    value = toMap((JSONObject) value);
                }

                if (value != null) {
                    map.put(key, value);
                }
            }
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return map;
    }*/

        public static List<object> toList(object json)
        {
            List<object> list = new List<object>();
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();

                if (json != null)
                {
                    return jss.Deserialize<List<object>>(json.ToString());
                }
                else
                {
                    return null;
                }
                /*for (int i = 0, cnt = array.Length; i < cnt; i++) 
                {
                    Object value = array[i];

                    if (value typeof json) 
                    {
                        value = toList((JSONArray) value);
                    } 
                    else if (value instanceof JSONObject) 
                    {
                        value = toMap((JSONObject) value);
                    }
                    list.add(value);
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string toString(object json, object key)
        {
            string rst = "";
            if (json == null || key == null)
                return rst;
            try
            {
                Dictionary<string, object> dic = JsonToDictionary(json);
                rst = dic[key.ToString()].ToString();
                return rst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public static Double toDouble(object labelDatas, int i)
        {
            if (labelDatas == null) //??????????
                return 0.0;
            double rst = 0;
            try
            {
                List<object> list = toList(labelDatas);
                if (list.Count <= i)
                    return 0.0;
                else
                    rst = Convert.ToDouble(list[i]);
                return rst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static object toObject(object labelDatas, int i)
        {
            if (labelDatas == null)
                return null;
            object rst = null;
            try
            {
                List<object> list = toList(labelDatas);
                if (list.Count <= i)
                    return 0.0;
                else
                    rst = list[i];
                return rst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static object toObject(object labelDatas, object key)
        {
            if (labelDatas == null || key == null) //little trouble
                return null;
            object rst = null;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                if (labelDatas.ToString().IndexOf("BodyInputStream") != -1 && labelDatas.ToString().Split('\\').Length-1>2)
                    dic = JsonToDictionary(labelDatas.ToString().Replace("{\"BodyInputStream\":", "").Replace("}}", "}"));
                else
                    dic = JsonToDictionary(labelDatas.ToString());
                rst = dic[key.ToString()];
                return rst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Boolean toBoolean(object Object, object key)
        {
            if (Object == null || key == null) //little trouble 
                return false;
            Boolean rst = false;
            try
            {
                Dictionary<string, object> dic = JsonToDictionary(Object);
                rst = Convert.ToBoolean(dic[key.ToString()]);
                return rst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static int toInt(object Object, object key)
        {
            int i = -1;
            try
            {
                Dictionary<string, object> dic = JsonToDictionary(Object);
                i = Convert.ToInt32(dic[key.ToString()]);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static double toDouble(object Object, object key)
        {
            double i = -1;
            try
            {
                Dictionary<string, object> dic = JsonToDictionary(Object);
                i = Convert.ToDouble(dic[key.ToString()]);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /*public static List toList(string obj, String key) {
        if (obj == null || obj.isNull(key)) return null;
        ArrayList llist = new ArrayList();
        try {
            JSONArray array = obj.getJSONArray(key);
            for (int i = 0, c = array.length(); i < c; i++) {
                llist.add(array.get(i));
            }
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return llist;
    }*/

        public static string toJSONArray(object obj, object key)
        {
            Dictionary<object, string> res = null;
            if (obj == null || key == null)
                return null;
            try
            {
                res.Add(key, obj.ToString());
                return new JavaScriptSerializer().Serialize(res);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static object toJSONObject(object obj, int index)
        {
            if (obj == null)
                return null;
            try
            {
                Dictionary<string, object> dic = JsonToDictionary(obj);
                Dictionary<string, object>.Enumerator en = dic.GetEnumerator();
                int i = 0;
                for (i = 0; i < dic.Count; i++)
                {
                    if (index == i)
                        return en.Current.Value;
                    else
                        en.MoveNext();

                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string toJSONkey(object obj, int index)
        {
            if (obj == null)
                return null;
            try
            {
                Dictionary<string, object> dic = JsonToDictionary(obj);
                Dictionary<string, object>.Enumerator en = dic.GetEnumerator();
                int i = 0;
                for (i = 0; i < dic.Count; i++)
                {
                    if (index == i)
                        return en.Current.Key.ToString();
                    else
                        en.MoveNext();

                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /*public static string toJSONArray(object obj, int i) 
        {
            JSONArray res = null;
        if (obj.length() > i) {
            try {
                res = obj.getJSONArray(i);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
        return res;
    }*/

        public static string toJSONObject(Object str)
        {
            if (str == null)
                return null;
            try
            {
                return new JavaScriptSerializer().Serialize(str);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static object toJSONObject(string jsonArray, string key)
        {
            object res = null;
            if (jsonArray == null || key == null)
            {
                return null;
            }
            try
            {
                Dictionary<string, object> dic = JsonToDictionary(jsonArray);
                res = dic[key];
                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static string ObjectToJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
        public static object ToJsonObject(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
        public static int toJSONInt(string jsonArray, int index)
        {
            int obj = 0;
            if (jsonArray == null || jsonArray.Length <= index)
            {
                return obj;
            }
            try
            {
                List<object> list = toList(jsonArray);
                obj = Convert.ToInt32(list[index]);
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public static String putJsonData(string jsonObject, string key, object value) //no return?
        {
            if (jsonObject != null)
            {
                try
                {

                    if (value.ToString().IndexOf(":") == -1)
                    {
                        object temp = value;
                        Dictionary<string, object> dic = new Dictionary<string, object>();//JsonToDictionary(jsonObject);
                        dic.Add(key, temp);
                        jsonObject = new JavaScriptSerializer().Serialize(dic);
                    }

                    else
                    {
                        Dictionary<string, object> temp = JsonToDictionary(value);
                        Dictionary<string, object> dic = new Dictionary<string, object>();//JsonToDictionary(jsonObject);
                        dic.Add(key, temp);
                        jsonObject = new JavaScriptSerializer().Serialize(dic);
                    }


                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return jsonObject;
        }

        public static string putJsonData(string jsonObject, int index, object value)
        {
            if (jsonObject != null)
            {
                try
                {
                    List<object> list = toList(jsonObject);
                    list.Insert(index, value);
                    return new JavaScriptSerializer().Serialize(list);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                return null;
            }
        }


        public static string toJSONString(string jsonArray, int index)
        {
            string obj = "";
            if (jsonArray == null || jsonArray.Length <= index)
            {
                return obj;
            }
            try
            {
                List<object> list = toList(jsonArray);
                return list[index].ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static object toJSONObject(string jsonArray, int index)
        {
            if (jsonArray == null)
                return null;
            try
            {
                List<object> list = toList(jsonArray);
                return list[index];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<object> sortJSONArray(string array)
        {
            try
            {
                List<object> list = toList(array);
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<object> sortJSONArray(List<object> array, string key) //????????
        {
            array.Add(key);
            return array;
        }

        /*public static void sortJSONArrayAscending(List array, final String key) {

        Collections.sort(
                (List<JSONObject>) array,
                new Comparator<JSONObject>() {
                    @Override
                    public int compare(JSONObject o1, JSONObject o2) {
                        String v1 = QSJSONUtil.toString(o1, key);
                        String v2 = QSJSONUtil.toString(o2, key);
                        return v1.compareToIgnoreCase(v2);
                    }
                });
    }*/

        /*public static JSONObject convertJSONObject(String string) {
        JSONObject obj = null;
        try {
            obj = new JSONObject(string);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return obj;
    }*/

        public static void responceFillValue2Object(HttpWebResponse response, object targetObj) { }
        private static Boolean initParameter(object o, FieldInfo[] declaredField, Type objType, object targetObj)
        {
            Boolean hasParam = false;
            int i = 0;
            for (i = 0; i < declaredField.Length; i++)
            {
                FieldInfo field = declaredField[i];
                string methodField = field.Name.Substring(0, 1).ToUpper() + field.Name.Substring(1);
                string getMethodName = field.GetType() == typeof(Boolean) ? "is" + methodField : "get" + methodField;
                string setMethodName = "set" + methodField;
                MethodInfo[] methods = objType.GetMethods();
                int k = 0;
                for (k = 0; k < methods.Length; k++)
                {
                    MethodInfo m = methods[k];
                    if (m.Name.Equals(getMethodName))
                    {

                        ParamAttribute attribute = (ParamAttribute)ParamAttribute.GetCustomAttribute(m, typeof(ParamAttribute));
                        if (attribute == null)
                        {
                            continue;
                        }
                        string dataKey = attribute.paramName.ToString();
                        if (o.ToString().IndexOf(dataKey) != -1 && o.ToString().IndexOf(":") != -1)
                        {
                            hasParam = true;
                            object data = toObject(o, dataKey);
                            MethodInfo setM = objType.GetMethod(setMethodName);
                            setParameterToMap(setM, targetObj, field, data);
                        }
                    }
                }
            }
            return hasParam;
        }


        public static Boolean jsonObjFillValue2Object(object o, object targetObj)
        {
            Boolean hasParam = false;
            if (targetObj != null)
            {
                try
                {
                    Type tmpType = targetObj.GetType();
                    while (!tmpType.Equals(typeof(object)))
                    {
                        FieldInfo[] fields = tmpType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                        if (initParameter(o, fields, tmpType, targetObj))
                        {
                            hasParam = true;
                        }
                        tmpType = tmpType.BaseType;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return hasParam;
        }
        public static Boolean jsonFillValue2Object(Object jsonStr, Object targetObj)
        {
            object o = toJSONObject(jsonStr);
            return jsonObjFillValue2Object(o, targetObj);
        }



        private static void setParameterToMap(MethodInfo m, object source, FieldInfo f, object data)
        {
            if (data != null)
            {
                try
                {
                    if ((data.GetType() == typeof(string) || data.GetType() == typeof(object)) && data.ToString().IndexOf(":") != -1)
                    {
                        Type fType = f.GetType();
                        if (fType == typeof(List<object>))
                        {
                            List<object> invokeData = new List<object>();

                            Type stringListType = f.GetType().GetGenericTypeDefinition();
                            Type Ts = (Type)stringListType.GetGenericArguments().First();
                            if (Ts == typeof(string)
                                    || Ts == typeof(int)
                                    || Ts == typeof(double)
                                    || Ts == typeof(long)
                                    || Ts == typeof(float))
                            {
                                if (data.GetType() == typeof(string))
                                {
                                    string jsonData = ObjectToJson(data);
                                    for (int i = 0; i < jsonData.Length; i++)
                                    {

                                        object o = toObject(jsonData, i);
                                        invokeData.Add(o);
                                    }
                                }
                            }
                            else
                            {
                                if (data.GetType() == typeof(string))
                                {
                                    string jsonData = ObjectToJson(data);
                                    List<object> list = toList(jsonData);
                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        object fObject = Activator.CreateInstance(Ts);
                                        object o = toJSONObject(jsonData, i);
                                        Type tmpType = fObject.GetType();
                                        while (tmpType != typeof(object))
                                        {
                                            FieldInfo[] fields = tmpType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                                            initParameter(o, fields, tmpType, fObject);
                                            tmpType = tmpType.BaseType;
                                        }
                                        invokeData.Add(fObject);
                                    }
                                }
                            }
                            object[] tmpobj = new object[1];
                            tmpobj[0] = invokeData;
                            m.Invoke(source, tmpobj);

                        }
                        else if (fType == typeof(Dictionary<string, object>))
                        {
                            Dictionary<string, object> invokeData = new Dictionary<string, object>();
                            if (data.GetType() == typeof(object))
                            {
                                object jsonData = ToJsonObject(data);
                                List<object> list = toList(jsonData);
                                for (int i = 0; i < list.Count; i++)
                                {
                                    string key = toJSONkey(jsonData, i);
                                    object value = toJSONObject(jsonData.ToString(), key);
                                    invokeData.Add(key, value);
                                }
                            }
                            object[] tmpobj = new object[1];
                            tmpobj[0] = invokeData;
                            m.Invoke(source, tmpobj);
                        }
                        else
                        {

                            object invokeData = Activator.CreateInstance(f.ReflectedType);
                            Type tmpType = invokeData.GetType();
                            while (tmpType != typeof(object))
                            {
                                FieldInfo[] fields = tmpType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                                data = ToJsonObject(data);
                                initParameter(data, fields, tmpType, invokeData);
                                tmpType = tmpType.BaseType;
                            }
                            object[] tmpobj = new object[1];
                            tmpobj[0] = invokeData;
                            m.Invoke(source, tmpobj);
                        }

                    }
                    else
                    {
                        if (f.GetType() == data.GetType())
                        {
                            object[] tmpobj = new object[1];
                            tmpobj[0] = data;
                            m.Invoke(source, tmpobj);
                        }
                        else
                        {
                            object[] tmpobj = new object[1];
                            tmpobj[0] = getParseValue(f.FieldType, data);
                            m.Invoke(source, tmpobj);
                        }
                    }
                }
                catch (Exception e) { throw new Exception(e.Message); }
            }
        }

        private static object getParseValue(Type type, object value)
        {
            if (type == typeof(string) || type == typeof(String))
            {
                return value.ToString();
            }
            else if (type == typeof(int))
            {
                return Convert.ToInt32(value);
            }
            else if (type == typeof(Double) || type == typeof(double))
            {
                return Convert.ToDouble(type);
            }
            else if (type == typeof(long))
            {
                return long.Parse(value.ToString());
            }
            else if (type == typeof(float))
            {
                return float.Parse(value.ToString());
            }
            else if(type == typeof(StreamReader))
            {
                MemoryStream inStream = new MemoryStream();
                StreamWriter bw = new StreamWriter(inStream);
                bw.Write(value.ToString());
                bw.Flush();
                inStream.Position = 0;
                StreamReader sr = new StreamReader(inStream);
                return sr;
            }
            return value;
        }
        public static String convertJSONObject(Object st)
        {
            String obj = null;
            try
            {
                return new JavaScriptSerializer().Serialize(st);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return obj;
        }
    }
}
