namespace CodingTest
{
    public class Knapsack
    {
        /// <summary>
        /// 品物を追加
        /// </summary>
        /// <param name="items">品物（weight:重さ, value:価値）</param>
        /// <param name="W">重さの総和</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int AddItems((int weight, int value)[] items, int W)
        {
            // 計算結果を保持する変数（メモ再帰化）
            // 品物の数と重さをキーに価値を保持する
            // それぞれ0～最大数が格納できる数を用意する（「0の場合」の価値を入れる必要があるため一つ多く領域を確保）
            var dp = new int[items.Length + 1, W + 1];

            (int weight, int value) item;

            // 品物のループ
            // dpのインデックスとitemsのインデックスにずれがあるためそれぞれに変数を用意
            for (int itmIdx = 0, dpItemIdx = 1; itmIdx < items.Length; itmIdx++, dpItemIdx++)
            {
                // 『現在の品物』
                item = items[itmIdx];

                // 重さの総和のループ（『現在の重さの総和』）
                for (var dpWIdx = 0; dpWIdx <= W; dpWIdx++)
                {
                    if (item.weight > dpWIdx)
                    {
                        // 『現在の品物』の重さが『現在の重さの総和』を超えている場合
                        // 追加できないので『一つ前の品物』で『同じ重さの総和』の価値の最大値を設定する。
                        dp[dpItemIdx, dpWIdx] = dp[dpItemIdx - 1, dpWIdx];
                    }
                    else
                    {
                        // 『現在の品物』の重さが『現在の重さの総和』を超えていない場合
                        // 『現在の品物』を『追加しない場合』と『追加した場合』で比較し大きい方の値を設定する。
                        // 『追加しない場合』:『一つ前の品物』で『同じ重さの総和』の価値の最大値
                        // 『追加した場合』:『一つ前の品物』で『同じ重さの総和』から『現在の品物の重さ』を引いた価値に『現在の品物』の価値を足したもの
                        dp[dpItemIdx, dpWIdx] = Math.Max(dp[dpItemIdx - 1, dpWIdx], dp[dpItemIdx - 1, dpWIdx - item.weight] + item.value);
                    }
                }
            }

            return dp[items.Length, W];
        }
    }
}
