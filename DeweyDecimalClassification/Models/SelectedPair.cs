using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeweyDecimalClassification.Models
{
    public class SelectedPair
    {
        public ListBoxItem Item1 { get; set; }
        public ListBoxItem Item2 { get; set; }

        public SelectedPair(ListBoxItem item1, ListBoxItem item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
}
