﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIConvergence.Shared
{
  public class PersonComparer : IComparer<Person>
  {
    public int Compare(Person? x, Person? y)
    {
      if(x is null || y is null)
      {
        return 0;
      }
      int result = x.Name.Length.CompareTo(y.Name.Length);
      if(result == 0)
      {
        return x.Name.CompareTo(y.Name);
      }
      else
      {
        return result;
      }
    }
  }
}
