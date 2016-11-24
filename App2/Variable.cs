using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App2
{
    public class Variable
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string DataType { get; set; }

        public Variable(string name, string datatype, int value)
        {
            Name = name;
            DataType = datatype;
            Value = value;
        }

        public new string ToString
        {
            get
            {
                return string.Format("{0} {1} = {2};", DataType, Name, Value);
            }
        }
    }
}