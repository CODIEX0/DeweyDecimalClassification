using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace DeweyDecimalClassification.Models
{
    public class Question
    {
        public string Description { get; set; }
        public string CallNumber { get; set; }

        public Question(string callNumber, string description)
        {
            CallNumber = callNumber;
            Description = description;
        }
    }

}