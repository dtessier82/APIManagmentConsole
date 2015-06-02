﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIManagmentConsole.Models.Enum;

namespace APIManagmentConsole.Models.Extensions
{
    public static class PolicyExtensions
    {
        public static string ToPolicyString(this PolicyType type)
        {
            switch (type)
            {
                case PolicyType.SetHttpHeader: return "set-header";
                case PolicyType.ReplaceStringInBody: return "find-and-replace";
                default: return "";
            }
        }
    }
}
