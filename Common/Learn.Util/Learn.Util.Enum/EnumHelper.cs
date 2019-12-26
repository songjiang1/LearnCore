using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Learn.Util.Enum
{
    public class EnumHelper
    {
        public List<EnumEntity> EnumToList<T>()
        {
            List<EnumEntity> list = new List<EnumEntity>();
            foreach (var e in System.Enum.GetValues(typeof(T)))
            {
                EnumEntity m = new EnumEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.desction = da.Description;
                }
                m.value = Convert.ToInt32(e);
                m.text = e.ToString();
                list.Add(m);
            }
            return list;
        }

        public class EnumEntity
        {
            public int value { get; set; }
            public string text { get; set; }
            public string desction { get; set; }
        }
    }
}
