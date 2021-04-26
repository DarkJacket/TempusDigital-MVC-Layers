﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Helper
{
    public static class DateStringToDateTime
    {

        public static DateTime ToDateTime(this string date)
        {
            try
            {
                int[] datasplit = date
               .Split('/')
               .Select(s => int.Parse(s))
               .ToArray();

                return new DateTime(datasplit[2], datasplit[1], datasplit[0]);
            }
            catch (Exception)
            {

                return new DateTime(0, 0, 0);
            }
            
        }

    }
}
