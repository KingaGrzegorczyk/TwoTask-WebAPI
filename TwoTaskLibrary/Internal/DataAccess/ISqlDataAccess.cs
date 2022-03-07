using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTaskLibrary.Internal.DataAccess
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        void UpdateData<T>(string storedProcedure, T parameters, string connectionStringName);
        void DeleteData<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}
