using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoConfig : MonoBehaviour
{
   public static Dictionary<int, int> AttackDic = new Dictionary<int, int>()
   {
         {1,5 },
         {2,5 },
         {3,5 },
         {4,5 },
         {5,5 },
         {6,5 },
         {7,5 },
         {8,5 },
         {9,5 },
         {10,5},
         
         {11,10 },
         {12,10 },
         {13,10 },
         {14,10 },
         {15,10 },
         {16,10 },
         {17,10 },
         {18,10 },
         {19,10 },
         {20,10},
         
         {21,20 },
         {22,20 },
         {23,20 },
         {24,20 },
         {25,20 },
         {26,20 },
         {27,20 },
         {28,20 },
         {29,20 },
         {30,20},
   };
   
   public static Dictionary<int, int> DenfenseDic = new Dictionary<int, int>()
   {
       {1,1 },
       {2,1 },
       {3,1 },
       {4,1 },
       {5,1 },
       {6,1 },
       {7,1 },
       {8,1 },
       {9,1 },
       {10,1},
         
       {11,2 },
       {12,2 },
       {13,2 },
       {14,2 },
       {15,2 },
       {16,2 },
       {17,2 },
       {18,2 },
       {19,2 },
       {20,2},
         
       {21,5 },
       {22,5 },
       {23,5 },
       {24,5 },
       {25,5 },
       {26,5 },
       {27,5 },
       {28,5 },
       {29,5 },
       {30,5},
   };
   
   
   public static Dictionary<int, int> HpDic = new Dictionary<int, int>()
   {
       {1,10 },
       {2,10 },
       {3,10 },
       {4,10 },
       {5,10 },
       {6,10 },
       {7,10 },
       {8,10 },
       {9,10 },
       {10,10},
         
       {11,20 },
       {12,20 },
       {13,20 },
       {14,20 },
       {15,20 },
       {16,20 },
       {17,20 },
       {18,20 },
       {19,20 },
       {20,20},
         
       {21,50 },
       {22,50 },
       {23,50 },
       {24,50 },
       {25,50 },
       {26,50 },
       {27,50 },
       {28,50 },
       {29,50 },
       {30,50},
   };
   
   public static int GetPlayerMaxHp()
   {
       var hp=100;
       for(int i=2;i<=GlobalPlayerAttribute.Level;i++)
       {
           hp+=HpDic[i];
       }

       return hp;
   }
   
   public static int GetPlayerAttack()
   {
       var attack=10;
       for(int i=2;i<=GlobalPlayerAttribute.Level;i++)
       {
           attack+=AttackDic[i];
       }

       return attack;
   }
   
   public static int GetPlayerDenfence()
   {
       var defence=0;
       for(int i=2;i<=GlobalPlayerAttribute.Level;i++)
       {
           defence+=DenfenseDic[i];
       }

       return defence;
   }
}
