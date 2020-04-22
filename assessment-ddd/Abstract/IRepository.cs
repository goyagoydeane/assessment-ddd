using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_ddd.Abstract
{
    public interface IRepository<T1, T2> where T1 : class where T2 : Type 
    {
    }
}
