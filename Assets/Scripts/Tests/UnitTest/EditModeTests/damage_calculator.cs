using System.Collections;
using NUnit.Framework;
using Tests.UnitTest.Scripts;
using UnityEngine.TestTools;

namespace Tests.UnitTest.EditModeTests
{
    public class damage_calculator
    {
        [Test]
        public void set_damage_to_half_with_50_percent_mitigation()
        {
            // ACT
            int finalDamage = DamageCalculator.CalculateDamage(10, .5f);
            
            // ASSERT
            Assert.AreEqual(5, finalDamage);
        }
        
        [Test]
        public void calculates_2_damage_from_10_with_80_percent_mitigation()
        {
            // ACT
            int finalDamage = DamageCalculator.CalculateDamage(10, .8f);
            
            // ASSERT
            Assert.AreEqual(2, finalDamage);
        }
    }
}
