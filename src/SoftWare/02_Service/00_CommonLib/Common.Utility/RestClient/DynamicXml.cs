using System;
using System.Net;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace Common.Utility
{
    public class DynamicXml : DynamicObject, INotifyPropertyChanged
    {
        private enum XmlType
        {
            Empty = 0,
            Object = 1,
            DBNull = 2,
            Boolean = 3,
            Char = 4,
            SByte = 5,
            Byte = 6,
            Int16 = 7,
            UInt16 = 8,
            Int32 = 9,
            UInt32 = 10,
            Int64 = 11,
            UInt64 = 12,
            Single = 13,
            Double = 14,
            Decimal = 15,
            DateTime = 16,
            String = 18,
            Enumerable = 100,
        }

        // public static methods

        /// <summary>from XmlString to DynamicXml</summary>
        public static dynamic Parse(string xml)
        {
            return Parse(xml, Encoding.Unicode);
        }

        /// <summary>from XmlString to DynamicXml</summary>
        public static dynamic Parse(string xml, Encoding encoding)
        {
            using (Stream reader = new MemoryStream(encoding.GetBytes(xml)))
            {
                return ToValue(XElement.Load(reader));
            }
        }

        private static Nullable<T> CreateNullable<T>() where T : struct
        {
            return new Nullable<T>();
        }

        private static Nullable<T> CreateNullableWithValue<T>(T obj) where T : struct
        {
            return new Nullable<T>(obj);
        }

        private static MethodInfo s_NullableCreator = typeof(DynamicXml).GetMethod("CreateNullable", BindingFlags.Static | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
        private static MethodInfo s_NullableCreatorWithValue = typeof(DynamicXml).GetMethod("CreateNullableWithValue", BindingFlags.Static | BindingFlags.NonPublic);

        // private static methods
        private static dynamic ToValue(XElement element)
        {
            string typeStr = element.Attribute("type").Value;
            string str = element.Value == null ? null : element.Value.Trim();
            if (typeStr.IndexOf(',') > 0 || typeStr.IndexOf('.') > 0)  // 说明是enum类型
            {
                Type enumType = Type.GetType(typeStr);
                if (str == null || str.Length <= 0)
                {
                    return null;
                }
                return Enum.Parse(enumType, str, false);
            }
            var type = (XmlType)Enum.Parse(typeof(XmlType), typeStr, false);
            if (str == null || str.Length <= 0)
            {
                if (type == XmlType.String)
                {
                    return str;
                }
                else
                {
                    return null;
                }
            }
            switch (type)
            {
                case XmlType.Boolean:
                    return Convert.ToBoolean(str);
                case XmlType.Byte:
                    return Convert.ToByte(str);
                case XmlType.Char:
                    return Convert.ToChar(str);
                case XmlType.DateTime:
                    return Convert.ToDateTime(str);
                case XmlType.DBNull:
                    return DBNull.Value;
                case XmlType.Decimal:
                    return Convert.ToDecimal(str);
                case XmlType.Double:
                    return Convert.ToDouble(str);
                case XmlType.Int16:
                    return Convert.ToInt16(str);
                case XmlType.Int32:
                    return Convert.ToInt32(str);
                case XmlType.Int64:
                    return Convert.ToInt64(str);
                case XmlType.SByte:
                    return Convert.ToSByte(str);
                case XmlType.Single:
                    return Convert.ToSingle(str);
                case XmlType.UInt16:
                    return Convert.ToUInt16(str);
                case XmlType.UInt32:
                    return Convert.ToUInt32(str);
                case XmlType.UInt64:
                    return Convert.ToUInt64(str);
                case XmlType.String:
                    return Convert.ToString(str);
                case XmlType.Object:
                case XmlType.Enumerable:
                    return new DynamicXml(element, type);
                case XmlType.Empty:
                default:
                    return null;
            }
        }

        private static XmlType GetXmlType(object obj)
        {
            if (obj == null)
            {
                return XmlType.Empty;
            }
            TypeCode code = Type.GetTypeCode(obj.GetType());
            if (code == TypeCode.Object)
            {
                return (obj is IEnumerable) ? XmlType.Enumerable : XmlType.Object;
            }
            return (XmlType)((int)code);
        }

        private static XAttribute CreateTypeAttr(XmlType type)
        {
            return new XAttribute("type", type.ToString());
        }

        private static XAttribute CreateTypeAttr(Type type)
        {
            return new XAttribute("type", type.AssemblyQualifiedName);
        }

        private static object CreateXmlNode(object obj)
        {
            var type = GetXmlType(obj);
            switch (type)
            {
                case XmlType.Byte:
                case XmlType.Char:
                case XmlType.Decimal:
                case XmlType.Double:
                case XmlType.Int16:
                case XmlType.Int32:
                case XmlType.Int64:
                case XmlType.SByte:
                case XmlType.Single:
                case XmlType.String:
                case XmlType.UInt16:
                case XmlType.UInt32:
                case XmlType.UInt64:
                case XmlType.DateTime:
                    return obj.ToString();
                case XmlType.Boolean:
                    return obj.ToString().ToLower();
                case XmlType.Object:
                    return CreateXObject(obj);
                case XmlType.Enumerable:
                    return CreateXArray(obj as IEnumerable);
                case XmlType.DBNull:
                case XmlType.Empty:
                default:
                    return null;
            }
        }

        private static IEnumerable<XStreamingElement> CreateXArray<T>(T obj) where T : IEnumerable
        {
            return obj.Cast<object>()
                .Select(o => new XStreamingElement("item", CreateTypeAttr(GetXmlType(o)), CreateXmlNode(o)));
        }

        private static IEnumerable<XStreamingElement> CreateXObject(object obj)
        {
            return obj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(pi => new { Name = pi.Name, Value = pi.GetValue(obj, null) })
                .Select(a => new XStreamingElement(a.Name, CreateTypeAttr(GetXmlType(a.Value)), CreateXmlNode(a.Value)));
        }

        readonly XElement m_Xml;
        readonly XmlType m_XmlType;

        /// <summary>create blank JSObject</summary>
        public DynamicXml()
        {
            m_Xml = new XElement("root", CreateTypeAttr(XmlType.Object));
            m_XmlType = XmlType.Object;
        }

        private DynamicXml(XElement element, XmlType type)
        {
            //Debug.Assert(type == JsonType.array || type == JsonType.@object);

            m_Xml = element;
            m_XmlType = type;
        }

        public bool IsObject { get { return m_XmlType == XmlType.Object; } }

        public bool IsArray { get { return m_XmlType == XmlType.Enumerable; } }

        /// <summary>has property or not</summary>
        public bool IsDefined(string name)
        {
            return IsObject && (m_Xml.Element(name) != null);
        }

        /// <summary>has property or not</summary>
        public bool IsDefined(int index)
        {
            return IsArray && (m_Xml.Elements().ElementAtOrDefault(index) != null);
        }

        /// <summary>delete property</summary>
        public bool Delete(string name)
        {
            var elem = m_Xml.Element(name);
            if (elem != null)
            {
                elem.Remove();
                return true;
            }
            else return false;
        }

        /// <summary>delete property</summary>
        public bool Delete(int index)
        {
            var elem = m_Xml.Elements().ElementAtOrDefault(index);
            if (elem != null)
            {
                elem.Remove();
                return true;
            }
            else return false;
        }

        public object this[string index]
        {
            get
            {
                object result;
                TryGet(m_Xml.Element(index), out result);
                return result;
            }
            set
            {
                TrySet(index, value);
            }
        }

        /// <summary>mapping to Array or Class by Public PropertyName</summary>
        public T Deserialize<T>()
        {
            return (T)Deserialize(typeof(T));
        }

        private object Deserialize(Type type)
        {
            return (IsArray) ? DeserializeArray(type) : DeserializeObject(type);
        }

        private dynamic DeserializeValue(XElement element, Type elementType)
        {
            var value = ToValue(element);
            if (value is DynamicXml)
            {
                value = ((DynamicXml)value).Deserialize(elementType);
            }
            return Convert.ChangeType(value, elementType, null);
        }

        private object DeserializeObject(Type targetType)
        {
            var result = Activator.CreateInstance(targetType);
            var dict = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite)
                .ToDictionary(pi => pi.Name, pi => pi);
            foreach (var item in m_Xml.Elements())
            {
                PropertyInfo propertyInfo;
                if (!dict.TryGetValue(item.Name.LocalName, out propertyInfo)) continue;
                var value = DeserializeValue(item, propertyInfo.PropertyType);
                propertyInfo.SetValue(result, value, null);
            }
            return result;
        }

        private object DeserializeArray(Type targetType)
        {
            if (targetType.IsArray) // Foo[]
            {
                var elemType = targetType.GetElementType();
                dynamic array = Array.CreateInstance(elemType, m_Xml.Elements().Count());
                var index = 0;
                foreach (var item in m_Xml.Elements())
                {
                    array[index++] = DeserializeValue(item, elemType);
                }
                return array;
            }
            else // List<Foo>
            {
                var elemType = targetType.GetGenericArguments()[0];
                dynamic list = Activator.CreateInstance(targetType);
                foreach (var item in m_Xml.Elements())
                {
                    list.Add(DeserializeValue(item, elemType));
                }
                return list;
            }
        }

        // Delete
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            result = (IsArray)
                ? Delete((int)args[0])
                : Delete((string)args[0]);
            return true;
        }

        // IsDefined, if has args then TryGetMember
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (args.Length > 0)
            {
                result = null;
                return false;
            }

            result = IsDefined(binder.Name);
            return true;
        }

        // Deserialize or foreach(IEnumerable)
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof(IEnumerable) || binder.Type == typeof(object[]))
            {
                var ie = (IsArray)
                    ? m_Xml.Elements().Select(x => ToValue(x))
                    : m_Xml.Elements().Select(x => (dynamic)new KeyValuePair<string, object>(x.Name.LocalName, ToValue(x)));
                result = (binder.Type == typeof(object[])) ? ie.ToArray() : ie;
            }
            else
            {
                result = Deserialize(binder.Type);
            }
            return true;
        }

        private bool TryGet(XElement element, out object result)
        {
            if (element == null)
            {
                result = null;
                return false;
            }

            result = ToValue(element);
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            return (IsArray)
                ? TryGet(m_Xml.Elements().ElementAtOrDefault((int)indexes[0]), out result)
                : TryGet(m_Xml.Element((string)indexes[0]), out result);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return (IsArray)
                ? TryGet(m_Xml.Elements().ElementAtOrDefault(int.Parse(binder.Name)), out result)
                : TryGet(m_Xml.Element(binder.Name), out result);
        }

        private bool TrySetEnum(string name, object value)
        {
            var type = value.GetType();
            var element = m_Xml.Element(name);
            if (element == null)
            {
                m_Xml.Add(new XElement(name, CreateTypeAttr(type), ((int)value).ToString()));
            }
            else
            {
                element.Attribute("type").Value = type.AssemblyQualifiedName;
                element.ReplaceNodes(((int)value).ToString());
            }
            RaisePropertyChanged(name);
            return true;
        }

        private bool TrySetEnum(int index, object value)
        {
            var type = value.GetType();
            var e = m_Xml.Elements().ElementAtOrDefault(index);
            if (e == null)
            {
                m_Xml.Add(new XElement("item", CreateTypeAttr(type), ((int)value).ToString()));
            }
            else
            {
                e.Attribute("type").Value = type.AssemblyQualifiedName;
                e.ReplaceNodes(((int)value).ToString());
            }
            return true;
        }

        private bool TrySet(string name, object value)
        {
            if (value != null && value.GetType().IsEnum)
            {
                return TrySetEnum(name, value);
            }
            var type = GetXmlType(value);
            var element = m_Xml.Element(name);
            if (element == null)
            {
                m_Xml.Add(new XElement(name, CreateTypeAttr(type), CreateXmlNode(value)));
            }
            else
            {
                element.Attribute("type").Value = type.ToString();
                element.ReplaceNodes(CreateXmlNode(value));
            }
            RaisePropertyChanged(name);
            return true;
        }

        private bool TrySet(int index, object value)
        {
            if (value != null && value.GetType().IsEnum)
            {
                return TrySetEnum(index, value);
            }
            var type = GetXmlType(value);
            var e = m_Xml.Elements().ElementAtOrDefault(index);
            if (e == null)
            {
                m_Xml.Add(new XElement("item", CreateTypeAttr(type), CreateXmlNode(value)));
            }
            else
            {
                e.Attribute("type").Value = type.ToString();
                e.ReplaceNodes(CreateXmlNode(value));
            }
            
            return true;
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            return (IsArray)
                ? TrySet((int)indexes[0], value)
                : TrySet((string)indexes[0], value);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return (IsArray)
                ? TrySet(int.Parse(binder.Name), value)
                : TrySet(binder.Name, value);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return (IsArray)
                ? m_Xml.Elements().Select((x, i) => i.ToString())
                : m_Xml.Elements().Select(x => x.Name.LocalName);
        }

        private event PropertyChangedEventHandler m_PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { m_PropertyChanged += value; }
            remove { m_PropertyChanged -= value; }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = m_PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
