using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using Dapper;
using System.Data.SQLite;

namespace TerrainComputeC.My
{
    class DbHelper
    {
        private string conStr="data source=data.db;version=3;";
        List<Color> readColorList()
        {
            using (IDbConnection cnn = new SQLiteConnection(conStr))
            {
                cnn.Open();
                var output = cnn.Query<Color>("select * from fill_color_list", new DynamicParameters());
                return output.ToList();
            }

        }
    }
}
