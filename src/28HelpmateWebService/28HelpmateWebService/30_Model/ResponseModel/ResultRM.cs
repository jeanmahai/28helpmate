using System;

namespace Model.ResponseModel
{
    [Serializable]
    public class ResultRM<T> 
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int Code { get; set; }
        public string Key { get; set; }

        private DateTime serverDate;
        public DateTime ServerDate { get { return DateTime.Now; } set { serverDate = value; }}
    }
}
