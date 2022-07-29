using System;
namespace api.Data
{
    public class RestUtil
    {
        private readonly string startupPath = System.IO.Directory.GetParent(@"./").FullName;
        public RestUtil()
        {
            
        }
    }
}