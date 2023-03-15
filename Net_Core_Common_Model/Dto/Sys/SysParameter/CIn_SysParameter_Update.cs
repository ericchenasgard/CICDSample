namespace Net_Core_Common_Model.Dto.Sys.SysParameter
{
    /// <summary>
    /// 系統參數檔-更新欄位
    /// </summary>
    public class CIn_SysParameter_Update
    {
        /// <summary>
        /// 參數群組
        /// </summary>
        public string Ck_Par_Group { get; set; }

        /// <summary>
        /// 參數編號
        /// </summary>
        public string Ck_Par_Code { get; set; }

        /// <summary>
        /// 參數名稱
        /// </summary>
        public string Par_Name { get; set; }

        /// <summary>
        /// 狀態 (0:停用，1:啟用)
        /// </summary>
        public string Par_State { get; set; }

        /// <summary>
        /// 值1
        /// </summary>
        public string Par_Value1 { get; set; }

        /// <summary>
        /// 值2
        /// </summary>
        public string? Par_Value2 { get; set; }

        /// <summary>
        /// 值3
        /// </summary>
        public string? Par_Value3 { get; set; }

        /// <summary>
        /// 值4
        /// </summary>
        public string? Par_Value4 { get; set; }

        /// <summary>
        /// 值5
        /// </summary>
        public string? Par_Value5 { get; set; }

        /// <summary>
        /// 值6
        /// </summary>
        public string? Par_Value6 { get; set; }

        /// <summary>
        /// 值7
        /// </summary>
        public string? Par_Value7 { get; set; }

        /// <summary>
        /// 值8
        /// </summary>
        public string? Par_Value8 { get; set; }

        /// <summary>
        /// 值9
        /// </summary>
        public string? Par_Value9 { get; set; }

        /// <summary>
        /// 值10
        /// </summary>
        public string? Par_Value10 { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        public string? Par_Remarks { get; set; }
    }
}