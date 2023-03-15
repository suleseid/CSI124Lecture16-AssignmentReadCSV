﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI124Lecture16_AssignmentReadCSV
{
     public class VidioGameSystem
    {
        string _company;
        string _systemName;
        string _storage;
        int _inventoryCount;

        public VidioGameSystem(string company, string systemName, string storage, int inventoryCount)
        {
            _company = company;
            _systemName = systemName;
            _storage = storage;
            _inventoryCount = inventoryCount;
        }

        // Important when useing CSVHelper to read back a list
        // You MUST have a default constructor
        public VidioGameSystem()
        {

        }
        public string Company { get => _company; set => _company = value; }
        public string SystemName { get => _systemName; set => _systemName = value; }
        public string Storage { get => _storage; set => _storage = value; }
        public int InventoryCount { get => _inventoryCount; set => _inventoryCount = value; }

        public override string ToString()
        {
            return $"{_company} {_systemName} - Storage: {_storage} - Stock: {_inventoryCount}";
        }
    }
}
