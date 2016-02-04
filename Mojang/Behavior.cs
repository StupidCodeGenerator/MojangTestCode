using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojang {
    /// <summary>
    /// 不知道英文咋写，就拼音了，凑合看
    /// </summary>
    public enum BehaviorType { 
        CHI, PENG, GANG, HU, TEST
    }
    /// <summary>
    /// 每一种行为包含一个行为类型（吃碰杠砸胡等等），和一个数据包（主要用来表示你碰什么牌，打什么牌之类）
    /// </summary>
    public class Behavior {
        /// <summary>
        /// 行为类型：吃碰杠胡等等
        /// </summary>
        public BehaviorType behaviorType;
        /// <summary>
        /// 数据包：每一种行为几乎都要返回一定的数据，比如碰，碰什么牌，打什么牌等等。
        /// 做成数据就是
        /// {
        ///     {"peng_card":MOJANG.b1}, {"play_card":MOJANG.b2}
        /// }
        /// 当然这只是一个例子，具体如何命名可以商榷
        /// 决定权在于回调函数如何解释你发来的数据包
        /// </summary>
        public Dictionary<string, MOJANG> dataBundle;
    }
}
