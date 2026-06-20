using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOverhaul.Effects
{
    public class Reach
    {
        //private static bool hasChanged;
        //private static bool Logs;

        private static List<CellOffset[]> ReachOffsetSet(int verticaloffset, int basevertical, int horizontaloffset, int basehorizontal)
        {
            List<CellOffset[]> ModifiedReach = new List<CellOffset[]>();
            List<CellOffset[]> h = new List<CellOffset[]>();
            List<CellOffset[]> v = new List<CellOffset[]>();
            if (verticaloffset <= 0 && horizontaloffset <= 0)
            {
                return ModifiedReach;
            }

            // vertical
            for (int i1 = 1; i1 <= verticaloffset; ++i1)
            {
                int n = basevertical + i1;
                List<CellOffset> cellOffsetList1 = new List<CellOffset>();

                for (int i2 = n; i2 >= 1; --i2)
                {
                    cellOffsetList1.Add(new CellOffset(0, i2));
                }
                v.Add(cellOffsetList1.ToArray());
            }

            // horizontal
            for (int j1 = 1; j1 <= horizontaloffset; ++j1)
            {
                int m = basehorizontal + j1;
                List<CellOffset> cellOffsetList2 = new List<CellOffset>();

                for (int j2 = m; j2 >= 1; --j2)
                {
                    cellOffsetList2.Add(new CellOffset(j2, 0));
                }
                h.Add(cellOffsetList2.ToArray());
            }

            ModifiedReach.AddRange((IEnumerable<CellOffset[]>)h);
            ModifiedReach.AddRange((IEnumerable<CellOffset[]>)v);

            return ModifiedReach;
        }

        public static class ReachPatch
        {
            public static void ExpandTables(int vOffset, int hOffset)
            {
                List<CellOffset[]> newReach = ReachOffsetSet(vOffset, 3, hOffset, 3);
                if (newReach.Count > 0)
                {
                    Reach.ReachPatch.ExpandTable(ref OffsetGroups.InvertedStandardTable, newReach);
                    Reach.ReachPatch.ExpandTable(ref OffsetGroups.InvertedStandardTableWithCorners, newReach);
                    //if (Reach.Logs)
                        //Debug.Log((object)$"[FoodOverhaul] Tables expanded successfully with {newReach.Count} total path(s)");
                }
                //else if (Reach.Logs)
                    //Debug.LogWarning((object)"[FoodOverhaul] No paths generated!");
                //Reach.hasChanged = true;
            }
            public static void ExpandTable(ref CellOffset[][] inputTable, List<CellOffset[]> newReach)
            {
                if (newReach == null || newReach.Count == 0)
                    return;

                CellOffset[][] merged = ((IEnumerable<CellOffset[]>)inputTable).ToList<CellOffset[]>().Concat<CellOffset[]>((IEnumerable<CellOffset[]>)newReach).ToArray<CellOffset[]>();

                CellOffset[][] cellOffsetArray = OffsetTable.Mirror(merged);
                inputTable = cellOffsetArray;
            }
        }
    }
}