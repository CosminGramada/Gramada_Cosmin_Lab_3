using System;
using System.Linq;

namespace Gramada_Cosmin_Lab_3
{
    static class Helper
    {
        public static DoughnutType GetDoughnutTypeFromSaleListItem(string saleItem)
        {
            var words = saleItem.Split(new string[] { " ", "\t", ":", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var types = Enum.GetValues(typeof(DoughnutType)).Cast<DoughnutType>().Select(v => v.ToString());
            return Enum.Parse<DoughnutType>(words.Intersect(types).FirstOrDefault());
        }
    }
}
