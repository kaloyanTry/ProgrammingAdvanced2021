using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime firstDate;
        private DateTime secondDate;


        public double CalculateDifferenceBetweenTwoDates(string firstDate, string secondDate)
        {
            string[] firstData = firstDate.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] secondData = secondDate.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            this.firstDate = new DateTime(int.Parse(firstData[0]), int.Parse(firstData[1]), int.Parse(firstData[2]));
            this.secondDate = new DateTime(int.Parse(secondData[0]), int.Parse(secondData[1]), int.Parse(secondData[2]));

            return Math.Abs((this.secondDate - this.firstDate).TotalDays);
        }
    }
}
