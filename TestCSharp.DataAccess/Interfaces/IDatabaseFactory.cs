using System;
using System.Data.Entity;
using TestCSharp.Models;
using TestCSharp.Models.Entities;


namespace TestCSharp.DataAccess.Interfaces
{
    public interface IDatabaseFactory<Y> : IDisposable
        where Y : ContextBase
    {
        Y GetContext();
    }
}
