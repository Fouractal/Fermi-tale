using UnityEngine;

namespace Utility.Hierarchy
{
   public class GameObjectRoot : RootObject
   {
      public static Transform Transform;
      
      protected override void Register()
      {
         Transform = transform;
      }
   }
}
