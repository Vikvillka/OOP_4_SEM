﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOP
{
    public class Operation
    {
        public string OperationType { get; set; }
        public double? Total { get; set; }
        public DateTime Date { get; set; }
        public Operation(string operationType, double? total, DateTime date)
        {
            Total = total;
            OperationType = operationType;
            Date = date;
        }
    }
}
