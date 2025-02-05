using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using static 제출용RPG_2_.Program;

namespace 제출용RPG_2_
{
    internal class Program
    {
        public class BaseSetting
        {

            public static string Choice { get; set; }
            public static string Name { get; set; }
            public static string Job { get; set; }
            public static string buy { get; set; }
            public static string CheckOut { get; set; }

            public static bool equipon = false;



            public static string[] iname = new string[5] { "갑옷", "도복", "스파르탄아머", "검", "태도" };
            public static string[] stattype = new string[3] { "공격력", "방어력", "회복량" };
            public static int[] istat = new int[5] { 2, 3, 5, 4, 10 };
            public static int[] prise = new int[5] { 1000, 1500, 2600, 500, 1000 };
            
            public static string[] inven = new string[5] { null, null, null, null, null };
            public static string[] onEquipment = new string[3] {null,null,null};


            public static uint Level = 1;
            public static int Gold = 1500;
            public static int Exp = 0;
            public static int MaxExp = 300;

            public static float Hp = 100;
            public static float Damage = 10;
            public static float Damagep = 0;
            public static float Armor = 5;
            public static float Armorp = 0;

            public class Item
            {
                public string Iname { get; set; }

            }

            public static class EquipChecker//머리가 안굴러가...
            {
                public static void EquipCheck()
                {
                    for (int i = 0; i < inven.Length; i++)
                    {
                        if (onEquipment[i] == onEquipment[0] )
                        {
                            CheckOut = onEquipment[0];
                            onEquipment[0] = null;
                            if (CheckOut == "갑옷")
                            {
                                inven[i] = CheckOut;
                                CheckOut = null;
                            }
                        }
                    }
                }
            }

            public static class dilivary
            {
                public static void Dilivaryitem()
                {
                    for (int i = 0; i < inven.Length; i++)
                    {
                        if (inven[i] == null) { inven[i] = buy; buy = null; }
                        else if (inven[0] != null && inven[1] != null && inven[2] != null) { Console.WriteLine("인벤토리가 가득 찼습니다."); }
                        else  {}
                    }    
                }
            }

            public static class Player
            {
                public static string equiped { get; set; }
                public static string equipType { get; set; }
                public static string equipStat { get; set; }

            }
            public static void buyItem() //041
            {
                Console.WriteLine("구매할 아이템을 알려주세요.");

                
                
                while (Gold >= 0)
                {
                    string keyword = Console.ReadLine();
                        switch (keyword)
                        {
                            case "갑옷":
                            if (Gold >= prise[0] && iname[0] == "갑옷")
                            {
                                buy = "갑옷";
                                Gold -= 1000;
                                dilivary.Dilivaryitem();
                                Console.WriteLine($"갑옷을 구매했습니다. 남은 돈 {Gold} G");
                                iname[0] += "매진";
                                break;
                            }
                            else if (Gold >= prise[0] && iname[0] != "갑옷")
                            { Console.WriteLine("상품이 매진됐습니다."); break; }
                            else
                            {
                                Console.WriteLine("돈이 부족합니다.");
                                break;
                            }
                            case "도복":
                                if (Gold >= prise[1] && iname[1] == "도복")
                                {

                                    buy = "도복";
                                    Gold -= 1500; 
                                dilivary.Dilivaryitem();
                                Console.WriteLine($"도복을 구매했습니다. 남은 돈 {Gold} G");
                                iname[1] += "매진";
                                break;
                            }
                            else if (Gold >= prise[0] && iname[1] != "도복")
                            { Console.WriteLine("상품이 매진됐습니다."); break; }
                            else
                                {
                                    Console.WriteLine("돈이 부족합니다.");
                                }
                                break;
                            case "스파르탄아머":
                                if (Gold >= prise[2] && iname[2] == "매진")
                                {
                                    buy = "스파르탄아머";
                                    Gold -= 2600;
                                    dilivary.Dilivaryitem();
                                    Console.WriteLine($"스파르탄아머를 구매했습니다. 남은 돈 {Gold} G");
                                iname[2] += "매진";
                                break;
                            }
                            else if (Gold >= prise[0] && iname[2] != "스파르탄아머")
                            { Console.WriteLine("상품이 매진됐습니다."); break; }
                            else
                                {
                                    Console.WriteLine("돈이 부족합니다.");
                                }
                                break;
                            case "검":
                                if (Gold >= prise[3] && iname[3] == "검")
                                {
                                    buy = "검";
                                    Gold -= 500;
                                dilivary.Dilivaryitem();
                                Console.WriteLine($"검을 구매했습니다. 남은 돈 {Gold} G");
                                iname[3] += "매진";
                                break;
                            }
                            else if (Gold >= prise[0] && iname[3] != "검")
                            { Console.WriteLine("상품이 매진됐습니다."); break; }
                            else
                                {
                                    Console.WriteLine("돈이 부족합니다.");
                                }
                                break;
                            case "태도":
                                if (Gold >= prise[4] && iname[4] == "태도")
                                {
                                    buy = "태도";
                                    Gold -= 1000;
                                dilivary.Dilivaryitem();
                                Console.WriteLine($"태도를 구매했습니다. 남은 돈 {Gold} G");
                                iname[4] += "매진";
                                break;
                            }
                            else if (Gold >= prise[0] && iname[4] != "태도")
                            { Console.WriteLine("상품이 매진됐습니다."); break; }
                            else
                                {
                                    Console.WriteLine("돈이 부족합니다.");
                                }
                                break;

                            default: Console.WriteLine("구매를 취소합니다."); Console.ReadKey(); Store(); break;
                        }
                    
                }
            }


            public static void PlayerInfo()
            {
                Console.Clear();
                Console.WriteLine($"상태 보기\r\n캐릭터의 정보가 표시됩니다.\r\n\r\nLv. {Level}      \r\n{Name} ({Job})\r\n공격력 : {Damage} ({Damagep})\r\n방어력 : {Armor} ({Armorp})\r\n체 력 : {Hp}\r\nGold : {Gold} G\r\n\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
                while (true)
                {
                    Choice = Console.ReadLine();
                    switch (Choice)
                    {
                        case "0":
                            Title();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Choice = null;
                            break;
                    }
                }
            }
            public static void Inventory() //030
            {
                Console.Clear();
                Console.WriteLine($"인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n[장착중인 아이템 목록]\n-{onEquipment[0]}\n-{onEquipment[1]}\n-{onEquipment[2]}\r\n\r\n[보유중인 아이템 목록]\r\n- {inven[0]}\r\n- {inven[1]}\r\n- {inven[2]}\r\n\r\n1. 장착 관리\r\n2. 탈착 관리\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
                while (true)
                {
                    BaseSetting.Choice = Console.ReadLine();
                    switch (BaseSetting.Choice)
                    {
                        case "1":
                            Inventory_Equipment(); //031
                            break;
                        case "2":
                            string Keyword = null ;
                            Console.WriteLine("어느 장비를 빼시겠습니까?");
                            Keyword = Console.ReadLine();
                            switch (Keyword)
                            {
                                case "1":
                                    break;
                            }
                            break;
                        case "0":
                            Title();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
            public static void Inventory_Equipment() //031
            {
                Console.Clear();
                Console.WriteLine($"인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n[장착 슬롯]\r\n- {BaseSetting.onEquipment[0]}\r\n- {BaseSetting.onEquipment[1]}\r\n- {BaseSetting.onEquipment[2]}\r\n\r\n1. {inven[0]} 장착\r\n2. {inven[1]} 장착\r\n3. {inven[2]} 장착\r\n0. 나가기");
                while (true)
                {
                    BaseSetting.Choice = Console.ReadLine();
                    string Keyword = null;
                    switch (BaseSetting.Choice)
                    {

                        case "1":
                            if (inven[0] != null)
                            {
                                Console.WriteLine($"어느 곳에 장착하시겠습니까? \n\n1. {BaseSetting.onEquipment[0]} \n2. {BaseSetting.onEquipment[1]}\n3.{BaseSetting.onEquipment[2]}");
                                Keyword = Console.ReadLine();
                                if (Keyword == "1" && BaseSetting.onEquipment[0] == null)
                                {
                                    BaseSetting.onEquipment[0] = inven[0];
                                    Console.WriteLine($"성공적으로 {inven[0]}이/가 1번칸에 장착됐습니다.");
                                    inven[0] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else if (Keyword == "2" && BaseSetting.onEquipment[1] == null)
                                {
                                    BaseSetting.onEquipment[1] = inven[0];
                                    Console.WriteLine($"성공적으로 {inven[0]}이/가 2번칸에 장착됐습니다.");
                                    inven[0] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else if (Keyword == "3" && BaseSetting.onEquipment[2] == null)
                                {
                                    BaseSetting.onEquipment[2] = inven[0];
                                    Console.WriteLine($"성공적으로 {inven[0]}이/가 3번칸에 장착됐습니다.");
                                    inven[0] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                            }
                            else
                            {
                                Console.WriteLine("장비가 없습니다.");
                                Console.ReadKey();
                                Inventory_Equipment();
                            }
                            break;
                        case "2":
                            if (inven[1] != null)
                            {
                                Console.WriteLine($"어느 곳에 장착하시겠습니까? \n\n1. {BaseSetting.onEquipment[0]} \n2. {BaseSetting.onEquipment[1]}\n3.{BaseSetting.onEquipment[2]}");
                                Keyword = Console.ReadLine();
                                if (Keyword == "1" && BaseSetting.onEquipment[0] == null)
                                {
                                    BaseSetting.onEquipment[0] = inven[1];
                                    Console.WriteLine($"성공적으로 {inven[1]}이/가 1번칸에 장착됐습니다.");
                                    inven[1] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else if (Keyword == "2" && BaseSetting.onEquipment[1] == null)
                                {
                                    BaseSetting.onEquipment[1] = inven[1];
                                    Console.WriteLine($"성공적으로 {inven[1]}이/가 2번칸에 장착됐습니다.");
                                    inven[1] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else if (Keyword == "3" && BaseSetting.onEquipment[2] == null)
                                {
                                    BaseSetting.onEquipment[2] = inven[1];
                                    Console.WriteLine($"성공적으로 {inven[1]}이/가 3번칸에 장착됐습니다.");
                                    inven[1] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                            }
                            else
                            {
                                Console.WriteLine("장비가 없습니다.");
                                Console.ReadKey();
                                Inventory_Equipment();
                            }
                            break;
                        case "3":
                            if (inven[2] != null)
                            {
                                Console.WriteLine($"어느 곳에 장착하시겠습니까? \n\n1. {BaseSetting.onEquipment[0]} \n2. {BaseSetting.onEquipment[1]}\n3.{BaseSetting.onEquipment[2]}");
                                Keyword = Console.ReadLine();
                                if (Keyword == "1" && BaseSetting.onEquipment[0] == null)
                                {
                                    BaseSetting.onEquipment[0] = inven[2];
                                    Console.WriteLine($"성공적으로 {inven[2]}이/가 1번칸에 장착됐습니다.");
                                    inven[2] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else if (Keyword == "2" && BaseSetting.onEquipment[1] == null)
                                {
                                    BaseSetting.onEquipment[1] = inven[2];
                                    Console.WriteLine($"성공적으로 {inven[2]}이/가 2번칸에 장착됐습니다.");
                                    inven[2] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else if (Keyword == "3" && BaseSetting.onEquipment[2] == null)
                                {
                                    BaseSetting.onEquipment[2] = inven[2];
                                    Console.WriteLine($"성공적으로 {inven[2]}이/가 3번칸에 장착됐습니다.");
                                    inven[2] = null;
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                                else
                                {
                                    Console.WriteLine("잘못된 입력입니다.");
                                    Console.ReadKey();
                                    Inventory_Equipment();
                                }
                            }
                            else
                            {
                                Console.WriteLine("장비가 없습니다.");
                                Console.ReadKey();
                                Inventory_Equipment();
                            }
                            break;
                        case "0":
                            Console.WriteLine("인벤토리로 돌아갑니다.");
                            BaseSetting.Inventory();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
        }
        public static void Store() //040
        {
            Console.Clear();
            Console.WriteLine($"상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.\r\n\r\n[보유 골드]\r\n{BaseSetting.Gold} G\r\n\r\n[아이템 목록]\r\n- {BaseSetting.iname[0]}\t | {BaseSetting.stattype[1]} : {BaseSetting.istat[0]}\t | {BaseSetting.prise[0]} G\n- {BaseSetting.iname[1]}\t | {BaseSetting.stattype[1]} : {BaseSetting.istat[1]}\t | {BaseSetting.prise[1]} G\n- {BaseSetting.iname[2]}\t | {BaseSetting.stattype[1]} : {BaseSetting.istat[2]}\t | {BaseSetting.prise[2]} G\n- {BaseSetting.iname[3]}\t | {BaseSetting.stattype[0]} : {BaseSetting.istat[3]}\t | {BaseSetting.prise[3]} G\n- {BaseSetting.iname[4]}\t | {BaseSetting.stattype[0]} : {BaseSetting.istat[4]}\t | {BaseSetting.prise[4]} G\r\n\r\n1. 아이템 구매\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
            while (true)
            {
                BaseSetting.Choice = Console.ReadLine();
                switch (BaseSetting.Choice)
                {
                    case "1":
                        BaseSetting.buyItem(); //041
                        break;
                    case "0":
                        Title(); 
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }

        }
        static void Title() //001
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n\r\n1. 상태 보기\r\n2. 인벤토리\r\n3. 상점\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
            while (true)
            {
                BaseSetting.Choice = Console.ReadLine();
                switch (BaseSetting.Choice)
                {
                    case "1":
                        BaseSetting.PlayerInfo(); //002
                        break;
                    case "2":
                        BaseSetting.Inventory(); //030
                        break;
                    case "3":
                        Store(); //040
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
        static void TheName()
        {
            Console.WriteLine("당신의 이름을 알려주세요.");
            BaseSetting.Name = Console.ReadLine();
            Console.WriteLine("당신의 직업을 알려주세요.");
            BaseSetting.Job = Console.ReadLine();

        }
        static void Main(string[] args)
        {
            TheName();
            Title();//000 메인에서 타이틀로 전환 컨트롤 + f로 찾아가기 '001'
        }
    }
}
