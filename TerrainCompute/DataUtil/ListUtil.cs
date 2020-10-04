using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainComputeC.DataUtil
{
    public class ListUtil<T>
    {
        public static void remove(List<T> origin,T removed){
            if (origin == null || removed == null) return;
            for (int i = origin.Count - 1; i >= 0; i--)
            {
                if ((object)removed == (object)origin[i])
                {
                    origin.Remove(removed);
                }
            }
        }
        public static void removeRange(List<T> originList, List<T> removedList)
        {
            if (originList == null || removedList == null) return;
            for (int i = 0; i < removedList.Count; i++)
            {
                remove(originList, removedList[i]);
            }
        }

        public static List<T> getRemainedRange(List<T> originList, List<T> removedList)
        {
            if (originList == null || removedList == null) return null;
            List<T> r = new List<T>();
            if (removedList == null) return new List<T>(originList);
            for (int n = 0; n < originList.Count; n++)
            {
                T oringin=originList[n];
                bool ifRemove=false;
                for (int i = 0; i < removedList.Count; i++)
                {
                    T removed=removedList[i];
                    if ((object)oringin == (object)removed)
                    {
                        ifRemove = true;
                        break;
                    }
                }
                if (ifRemove == false)
                {
                    r.Add(oringin);
                }
            }
            return r;
        }
    }
}
