using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Tests.UnitTest.Scripts;
using UnityEngine;
using UnityEngine.TestTools;

public class player_movement
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator with_positive_vertical_input_moves_forward()
    {
        GameObject playerGameObject = new GameObject("Player");
        Player player = playerGameObject.AddComponent<Player>();
        player.PlayerInput = Substitute.For<IPlayerInput>();
        player.PlayerInput.Verticle.Returns(1f);

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(playerGameObject.transform);
        cube.transform.localPosition = Vector3.zero;
        
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(.3f);

        Vector3 playerPos = player.transform.position; 
        Assert.IsTrue(playerPos.z > 0f);
        Assert.AreEqual(playerPos.y, 0f);
        Assert.AreEqual(playerPos.x, 0f);
    }
}
