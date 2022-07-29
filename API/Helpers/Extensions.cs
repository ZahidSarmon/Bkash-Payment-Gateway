using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace api.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
        public static string GetJsonValue(this JObject objJson,string selectedValue)
        {
            try{
                JToken jToken = objJson.SelectToken(selectedValue);
                return jToken.ToString();
            }catch(Exception exp)
            {
                throw exp;
            }
        }
        public static string UpdateJson(this JObject objJson,string selectedValue,dynamic updatedValue=null)
        {
            try{
                JToken jToken = objJson.SelectToken(selectedValue);
                jToken.Replace(updatedValue);
                return objJson.ToString();
            }catch(Exception exp)
            {
                throw exp;
            }
        }
        public static string removeJson(this JObject objJson,string selectedToken,List<string> propList=null)
        {
            try{
                JObject header = (JObject)objJson.SelectToken(selectedToken);
                if(propList!=null)
                {
                    foreach(var item in propList)
                    {
                        header.Property(item).Remove();
                    }
                }else{
                    header.Remove();
                }
                objJson.ToString();
            }catch(Exception exp)
            {
                return objJson.ToString();
            }
            return objJson.ToString();
        }
    }
}