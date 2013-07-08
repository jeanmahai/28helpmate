using System;

namespace Model.ResponseModel
{
    [Serializable]
    public class ResultRM<T> where T:class ,new()
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int Code { get; set; }
        public string Key { get; set; }
    }
}
