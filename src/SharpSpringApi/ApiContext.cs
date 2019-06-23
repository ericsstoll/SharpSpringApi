using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SharpSpringApi
{
    public class ApiContext : IGet
    {
        private ApiContextGet apiContextGet;
        private string accountId = "7A05F3178211AB753A5DB1B614586F05";
        private string secretKey = "823CD041BB29BD4B89636C3B7CF3AAD4";

        public ApiContext()
        {
            apiContextGet = new ApiContextGet(this);
        }

        public IGetEntity Get()
        {
            return apiContextGet;
        }

        private string BaseApiUrl
        {
            get
            {
                return $"http://api.sharpspring.com/pubapi/v1/?accountId{accountId}&secretKey={secretKey}";
            }
        }

        internal string ExecuteGetCommand(string command, int limit, int offset, params string[] parameters)
        {
            string requestId = Guid.NewGuid().ToString();
            dynamic p = new
            {
                where = new
                {
                    limit = limit,
                    offset = offset
                }
            };
            dynamic data = new
            {
                method = command,
                @params = p,
                id = requestId
            };

            WebRequest wr = WebRequest.Create(BaseApiUrl);
            wr.Method = "POST";
            wr.ContentType = "application/json";
            string json = JsonConvert.SerializeObject(data);
            Stream str = wr.GetRequestStream();
            StreamWriter sw = new StreamWriter(str);
            sw.Write(json);
            WebResponse wr2 = wr.GetResponse();
            Stream str2 = wr2.GetResponseStream();
            StreamReader sr = new StreamReader(str2);
            string ret = sr.ReadToEnd();
            return ret;
        }
    }

    internal class ApiContextGet: IGetEntity
    {
        ApiContext context;

        internal ApiContextGet(ApiContext context)
        {
            this.context = context;
        }

        public IEnumerable<IAccount> Accounts(int id = 0, int ownerId = 0, int limit = int.MaxValue, int offset = 0)
        {
            context.ExecuteGetCommand("getAccounts", limit, offset);
            return null;
        }

    }
}
