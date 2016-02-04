using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojang {
    public class Agent_AI :Agent {
        public override void NextStep(Manager manager) {
            // AI的决策核心函数，决策结束后调用 manager.BehaviorCallBack
            Behavior testBehavior = new Behavior();
            testBehavior.behaviorType = BehaviorType.TEST;
            testBehavior.dataBundle = new Dictionary<string, MOJANG>();
            this.lastBehavior = testBehavior;
            manager.BehaviorCallBack(testBehavior,this.agentIndex);
        }
    }
}
