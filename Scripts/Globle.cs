using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Start is called before the first frame update 
    public static class Gloables
    {
        public static bool ifHintDialogX = false;
        //提示框X
        public static bool ifHintDialogC = false;
        //提示框C
        public static bool ifHintDialogSpace = false;
        //提示框空格
        public static bool ifInMission = false;
        //是否在任务中

        public static bool ifHintAboutZ = false;
        //提示Z可以回血
        public static bool ifPoisoned = false;
        //是否中毒
        // Dictionary<string,bool> State = new Dictionary<string, bool>();
        public static bool ifHintDialogPosion = false;
        //进入毒蘑菇林的提示

        public static bool ifHintTreasure = false;
        //提示开宝箱
        public static int TreasureKey = 0;
        //拥有的钥匙数量
        public static int FixedRobots = 0;
        //已修复机器人的数量

        public static int FixedInBOSSRoom;
        //在BOSS房消灭的机器人
        public static int NeedFixedRobotsNum = 30;
        //任务所需修复的机器人数量
        public static bool ifStartBoss = false;
        //是否遇到了BOSS
        public static bool ifIntoMainScene = false;
        public static int StrawberryNum = 0;

        public static bool ifInBOSSing = false;

        public static bool ifGmaeClear = false;

        public static int RubyHealth = RubyController.instance.maxHealth;
        //存主角生命中，用于切换场景后读取
        //背包中有的草莓数
        // public static bool IfHintDialogX
        // {
        //     get{return ifHintDialogX;}
        //     set{ifHintDialogX = value;}

        // // }
        // public static bool IfInMission 
        // {
        //     get{return ifInMission;}
        //     set{ifInMission = value;}
        // }
    }
