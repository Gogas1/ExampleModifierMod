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
            ExampleModifierMod.QiRecoilModifierVotes.Remove(this);
            base.NotifyDeactivation();
        }

        public override void NotifyPause() {
            ExampleModifierMod.QiRecoilModifierVotes.Remove(this);
            base.NotifyPause();
        }

        public override void NotifyResume() {
            ExampleModifierMod.QiRecoilModifierVotes.Add(this);
            base.NotifyResume();
        }
    }
}
