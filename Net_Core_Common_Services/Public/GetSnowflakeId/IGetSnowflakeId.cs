using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Core_Common_Services.Public.GetSnowflakeId
{
    public interface IGetSnowflakeId
    {
        /// <summary>
        /// 產生下一個ID
        /// </summary>
        /// <returns>Id</returns>
        public long fnGetNextId();
    }
}
