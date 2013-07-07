using System;


namespace Helpmate.BizEntity
{
    public class PageModel
    {
        private Boolean _isAuto = false;
        public Boolean IsAuto
        {
            get { return _isAuto; }
            set { _isAuto = value; }
        }

        private Int32 _index = 0;

        public Int32 Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private Int32 _size = 0;

        public Int32 Size
        {
            get { return _size; }
            set { _size = value; }
        }
        private String _orderColumn = String.Empty;

        public String OrderColumn
        {
            get { return _orderColumn; }
            set { _orderColumn = value; }
        }
        private Int32 _orderSortType = 0;

        public Int32 OrderSortType
        {
            get { return _orderSortType; }
            set { _orderSortType = value; }
        }
        private Int32 _count = 0;

        public Int32 Count
        {
            get { return _count; }
            set { _count = value; }
        }
        private Int32 _rowsCount = 0;

        public Int32 RowsCount
        {
            get { return _rowsCount; }
            set { _rowsCount = value; }
        }
    }
}
