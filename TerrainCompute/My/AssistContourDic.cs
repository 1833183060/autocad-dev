using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerrainComputeC.BASE;
using TerrainComputeC;
namespace TerrainComputeC.My
{
    public class AssistContourDic
    {
        public List<double> elevations;
        public List<List<PLine>> plines;
        public AssistContourDic()
        {
            elevations = new List<double>();
            plines = new List<List<PLine>>();
        }
        public void set(double e, List<PLine> pl)
        {
            int i=elevations.FindIndex(item =>
            {
                if (Math.Abs(item - e) < 1e-8)
                {
                    return true;
                }
                return false;
            });
            if (i >= 0)
            {
                plines[i] = pl;
            }
            else
            {
                elevations.Add(e);
                plines.Add(pl);
            }
        }
    }
}
