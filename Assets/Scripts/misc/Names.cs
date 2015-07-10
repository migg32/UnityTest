using UnityEngine;
namespace Names
{
	static public class Layers
	{
		public static int GROUND_LAYER = LayerMask.GetMask("Ground");
		public static int SHOOTABLE_LAYERS = LayerMask.GetMask("Ground", "Shootable");
	}
}
