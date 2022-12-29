using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inje.AIConvergence.Shared;

public class User
{
  public string Name { get; set; }
  public string Salt { get; set; }
  public string SaltedHashedPassword { get; set; }

  public User(string name, string salt, string saltedHashedPassword)
  {
    Name = name; 
    Salt = salt;
    SaltedHashedPassword = saltedHashedPassword;
  }
}
