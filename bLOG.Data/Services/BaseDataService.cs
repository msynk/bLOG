using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bLOG.Data.Models;

namespace bLOG.Data.Services
{
  public abstract class BaseDataService
  {
    protected static readonly bLOGContext Context = new bLOGContext();
    protected BaseDataService() { }
  }
}
