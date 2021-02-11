using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace DataformXamarin
{
    public class DynamicDataModel
    {
        public dynamic ExpandoObject;

        public dynamic DynamicObject;
        public DynamicDataModel()
        {
            ExpandoObject = new ExpandoObject();
            ExpandoObject.FirstName = "John";
            ExpandoObject.LastName = "";
            ExpandoObject.DateOfBirth = DateTime.Now.Date;
            ExpandoObject.Email = "";

            DynamicObject = new Data();
            DynamicObject.FirstName = "John";
            DynamicObject.LastName = "";
            DynamicObject.DateOfBirth = DateTime.Now.Date;
            DynamicObject.Email = "";
        }
    }
    public class Data : DynamicObject, IDictionary<string, object>
    {
        Dictionary<string, object> list = new Dictionary<string, object>();

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            list[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return list.TryGetValue(binder.Name, out result);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return list.Keys;
        }

        public void Add(string key, object value)
        {
            this.list.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return this.list.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return this.list.Keys; }
        }

        public bool Remove(string key)
        {
            return this.list.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return this.list.TryGetValue(key, out value);
        }

        public ICollection<object> Values
        {
            get { return this.list.Values; }
        }

        object IDictionary<string, object>.this[string key]
        {
            get { return this.list[key]; }
            set { this.list[key] = value; }
        }

        public void Add(KeyValuePair<string, object> item)
        {
            this.list.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {

        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return this.list.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }
}

    

