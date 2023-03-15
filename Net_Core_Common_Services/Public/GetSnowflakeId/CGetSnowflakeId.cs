using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

namespace Net_Core_Common_Services.Public.GetSnowflakeId
{
    public sealed class CGetSnowflakeId : IGetSnowflakeId
    {
        // 每一部分占用的位數
        // 對于移位運算子 << 和 >>，右側運算元的型別必須為 int，或具有預定義隱式數值轉換 為 int 的型別
        private const int ISequenceBit = 12;   // 序列號占用的位數
        private const int IMachingBit = 5;     // 機器標識占用的位數
        private const int IDataCenterBit = 5; // 資料中心占用的位數

        // 每一部分向左的位移
        private const int IMachingLeft = ISequenceBit;
        private const int IDataCenterLeft = ISequenceBit + IMachingBit;
        private const int ITimeStampLeft = IDataCenterLeft + IDataCenterBit;

        // 起始的時間戳:唯一時間，這是一個避免重複的隨機量，自行設定不要大于當前時間戳，
        // 一個計時周期表示一百納秒，即一千萬分之一秒， 1 毫秒內有 10,000 個計時周期，即 1 秒內有 1,000 萬個計時周期
        private static long iStartTimeStamp = new DateTime(2020, 7, 1).Ticks / 10000;

        // 每一部分的最大值
        private static long iMaxSequence = -1L ^ (-1L << ISequenceBit);
        private static long iMaxMachingNum = -1L ^ (-1L << IMachingBit);
        private static long iMaxDataCenterNum = -1L ^ (-1L << IDataCenterBit);

        private readonly IConfiguration _configuration;

        private long iDataCenterId;  // 資料中心
        private long iMachineId;     // 機器標識
        private long iSequence; // 序列號
        private long iLastTimeStamp = -1;  // 上一次時間戳

        private long fnGetNextMill()
        {
            long iMill = this.fnGetNewTimeStamp();
            while (iMill <= this.iLastTimeStamp)
            {
                iMill = this.fnGetNewTimeStamp();
            }

            return iMill;
        }

        private long fnGetNewTimeStamp()
        {
            return DateTime.Now.Ticks / 10000;
        }

        public CGetSnowflakeId(IConfiguration configuration)
        {
            this._configuration = configuration;
            long.TryParse(this._configuration["SnowflakeId:DataCenterId"], out this.iDataCenterId);
            long.TryParse(this._configuration["SnowflakeId:MachineId"], out this.iMachineId);
            this.fnCheckMachineId();
        }

        /// <summary>
        /// 檢查資料中心ID和機器標志ID是否合法
        /// </summary>
        /// <param name="dataCenterId">資料中心ID</param>
        /// <param name="machineId">機器標志ID</param>
        public void fnCheckMachineId()
        {
            if (this.iDataCenterId > iMaxDataCenterNum || this.iDataCenterId < 0)
            {
                throw new ArgumentException("DataCenterId can't be greater than MAX_DATA_CENTER_NUM or less than 0！");
            }

            if (this.iMachineId > iMaxMachingNum || this.iMachineId < 0)
            {
                throw new ArgumentException("MachineId can't be greater than MAX_MACHINE_NUM or less than 0！");
            }
        }

        /// <summary>
        /// 產生下一個ID
        /// </summary>
        /// <returns>Id</returns>
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public long fnGetNextId()
        {
            long iCurrTimeStamp = this.fnGetNewTimeStamp();
            if (iCurrTimeStamp < this.iLastTimeStamp)
            {
                // 如果當前時間戳比上一次生成ID時時間戳還小，拋出例外，因為不能保證現在生成的ID之前沒有生成過
                throw new Exception("Clock moved backwards.  Refusing to generate id");
            }

            if (iCurrTimeStamp == this.iLastTimeStamp)
            {
                // 相同毫秒內，序列號自增
                this.iSequence = (this.iSequence + 1) & iMaxSequence;
                // 同一毫秒的序列數已經達到最大
                if (this.iSequence == 0L)
                {
                    iCurrTimeStamp = this.fnGetNextMill();
                }
            }
            else
            {
                // 不同毫秒內，序列號置為0
                this.iSequence = 0L;
            }

            this.iLastTimeStamp = iCurrTimeStamp;

            return (iCurrTimeStamp - iStartTimeStamp) << ITimeStampLeft // 時間戳部分
                    | this.iDataCenterId << IDataCenterLeft // 資料中心部分
                    | this.iMachineId << IMachingLeft // 機器標識部分
                    | this.iSequence; // 序列號部分
        }
    }
}