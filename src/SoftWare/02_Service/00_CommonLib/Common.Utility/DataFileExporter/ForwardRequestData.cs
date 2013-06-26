using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace Common.Utility
{
    public class ForwardRequestData
    {
        public string Url
        {
            get;
            set;
        }

        public int? Port
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public string HttpMethod
        {
            get;
            set;
        }

        public string HttpContentType
        {
            get;
            set;
        }

        public List<CodeNamePair> Parameters
        {
            get;
            set;
        }

        public string ExporterName
        {
            get;
            set;
        }

        public List<List<ColumnData>> ColumnSetting
        {
            get;
            set;
        }

        public List<TextInfo> TextInfoList
        {
            get;
            set;
        }
    }

    public enum HorizAlignments
    {
        // Summary:
        //     Default - General        
        Default = 0,
        //
        // Summary:
        //     General
        General = 0,
        //
        // Summary:
        //     Left
        Left = 1,
        //
        // Summary:
        //     Centered
        Centered = 2,
        //
        // Summary:
        //     Right
        Right = 3,
        //
        // Summary:
        //     Filled
        Filled = 4,
        //
        // Summary:
        //     Justified
        Justified = 5,
        //
        // Summary:
        //     Centered Across the Selection
        CenteredAcrossSelection = 6,
        //
        // Summary:
        //     Distributed
        Distributed = 7
    }

    public enum VertiAlignments
    {
        // Summary:
        //     Top
        Top = 0,
        //
        // Summary:
        //     Centered
        Centered = 1,
        //
        // Summary:
        //     Default - Bottom
        Default = 2,
        //
        // Summary:
        //     Bottom
        Bottom = 2,
        //
        // Summary:
        //     Justified
        Justified = 3,
        //
        // Summary:
        //     Distributed
        Distributed = 4,
    }

    public class ColumnData
    {
        public int? FieldIndex
        {
            get;
            set;
        }

        public string FieldName
        {
            get;
            set;
        }

        public string Title { get; set; }

        public HorizAlignments? HorizontalAlignment { get; set; }

        public VertiAlignments? VerticalAlignment { get; set; }

        public bool? HasBorder { get; set; }

        public int? Width { get; set; }

        public string ValueFormat { get; set; }

        public FooterType FooterType
        {
            get;
            set;
        }
    }

    public enum FooterType
    {
        None = 0,
        Sum = 1,
        Average = 2
    }

    public class TextInfo
    {
        public string Title { get; set; }
        public string Memo { get; set; }
    }
}
