using BossChallengeMod.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleModifierMod {
    public class QiRecoilModifier : ModifierBase {

        public override void NotifyActivation() {
            ExampleModifierMod.QiRecoilModifierVotes.Add(this);

            base.NotifyActivation();
        }

        public override void NotifyDeactivation() {
            base.NotifyDeactivation();
            ExampleModifierMod.QiRecoilModifierVotes.Remove(this);
        }

        public override void NotifyPause() {
            base.NotifyPause();
            ExampleModifierMod.QiRecoilModifierVotes.Remove(this);
        }

        public override void NotifyResume() {
            base.NotifyResume();
            if(enabled) {
                ExampleModifierMod.QiRecoilModifierVotes.Add(this);
            }
        }
    }
}
