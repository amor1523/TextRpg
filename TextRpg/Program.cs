namespace TextRpg
{
    internal class Program
    {
        private static Character player;
        private static List<Item> inventory;
        private static List<Item> shop;

        private static Item[] items;

        static void Main(string[] args)
        {
            InitialDataSsetting();
            DisplayGameIntro();
        }

        static void InitialDataSsetting()
        {
            // 캐릭터 정보
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500f);

            // 아이템 정보 세팅
            items = new Item[11];

            items[0] = new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 1, 0, 5, 0, 1000f);
            items[1] = new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 1, 0, 5, 0, 1800f);
            items[2] = new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 1, 0, 15, 0, 3500f);
            items[3] = new Item("개발자의 한이 서린 갑옷", "전설의 개발자가 사용했다는 최강의 갑옷입니다.", 1, 0, 50, 200, 50000f);
            items[4] = new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 0, 2, 0, 0, 300f);
            items[5] = new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 0, 5, 0, 0, 1500f);
            items[6] = new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 0, 7, 0, 0, 2700f);
            items[7] = new Item("죽 창", "평등해보이지만 데미지는 평등해보이지 않습니다.", 0, 20, 0, 0, 100000f);
            //items[8] = new Item("구리열쇠", "이상한 기호가 적혀있다. ⅳ", 2, 0, 0, 50, 0f);
            //items[9] = new Item("은열쇠", "이상한 기호가 적혀있다. ⅷ", 2, 0, 0, 100, 0f);
            //items[10] = new Item("금열쇠", "이상한 기호가 적혀있다. ⅵ", 2, 0, 0, 200, 0f);

            //상점 정보 세팅
            shop = new List<Item>();
            for (int i = 0; i < 8; i++)
            {
                shop.Add(items[i]);
            }

            //캐릭터 인벤토리 세팅
            inventory = new List<Item>();
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 저장하기 & 불러오기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int input = CheckValidInput(1, 4);
            switch (input)
            {
                case 1:
                    DisplayInfo();
                    break;

                case 2:
                    DisplayInventory();
                    break;

                case 3:
                    DisplayShop();
                    break;

                case 4:
                    DisplaySaveLoad();
                    break;
            }
        }


        static void DisplayInfo()
        {
            int atkPlus = 0;
            int defPlus = 0;
            int hpPlus = 0;

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Equipped == 1)
                {
                    atkPlus += inventory[i].Atk;
                    defPlus += inventory[i].Def;
                    hpPlus += inventory[i].Hp;
                }
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[상태보기]\n");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보를 표시합니다.\n");
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ({player.Job})");

            if (atkPlus > 0) Console.WriteLine($"공격력 :{player.Atk} (+{atkPlus})");
            else Console.WriteLine($"공격력 :{player.Atk}");

            if (defPlus > 0) Console.WriteLine($"방어력 :{player.Def} (+{defPlus})");
            else Console.WriteLine($"방어력 :{player.Def}");

            if (hpPlus > 0) Console.WriteLine($"체력 :{player.Hp} (+{hpPlus})");
            else Console.WriteLine($"체력 :{player.Hp}");

            Console.WriteLine($"Gold : {player.Gold} G\n");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");



            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        static void DisplayInventory()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[인벤토리]\n");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Equipped == 1)
                {
                    if (inventory[i].Atk > 0) Console.WriteLine($"- [E]{inventory[i].Name} | 공격력 +{inventory[i].Atk} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0 && inventory[i].Hp > 0) Console.WriteLine($"-[E]{inventory[i].Name} | 방어력 +{inventory[i].Def} |  체력 +{inventory[i].Hp} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0) Console.WriteLine($"- [E]{inventory[i].Name} | 방어력 +{inventory[i].Def} | {inventory[i].Description}");
                    else if (inventory[i].Hp > 0) Console.WriteLine($"-[E]{inventory[i].Name} |  체력 +{inventory[i].Hp} | {inventory[i].Description}");
                }
                else
                {
                    if (inventory[i].Atk > 0) Console.WriteLine($"- {inventory[i].Name} | 공격력 +{inventory[i].Atk} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0 && inventory[i].Hp > 0) Console.WriteLine($"-{inventory[i].Name} | 방어력 +{inventory[i].Def} |  체력 +{inventory[i].Hp} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0) Console.WriteLine($"- {inventory[i].Name} | 방어력 +{inventory[i].Def} | {inventory[i].Description}");
                    else if (inventory[i].Hp > 0) Console.WriteLine($"- {inventory[i].Name} |  체 력 +{inventory[i].Hp} | {inventory[i].Description}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    Displayitems();
                    break;
            }
        }

        static void Displayitems()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[인벤토리 - 장착 관리]\n");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Equipped == 1)
                {
                    if (inventory[i].Atk > 0) Console.WriteLine($"- {i + 1} [E]{inventory[i].Name} | 공격력 +{inventory[i].Atk} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0 && inventory[i].Hp > 0) Console.WriteLine($"- {i + 1} [E]{inventory[i].Name} | 방어력 +{inventory[i].Def} |  체력 +{inventory[i].Hp} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0) Console.WriteLine($"- {i + 1} [E]{inventory[i].Name} | 방어력 +{inventory[i].Def} | {inventory[i].Description}");
                    else if (inventory[i].Hp > 0) Console.WriteLine($"- {i + 1} [E]{inventory[i].Name} |  체력 +{inventory[i].Hp} | {inventory[i].Description}");
                }
                else
                {
                    if (inventory[i].Atk > 0) Console.WriteLine($"- {i + 1} {inventory[i].Name} | 공격력 +{inventory[i].Atk} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0 && inventory[i].Hp > 0) Console.WriteLine($"- {i + 1} {inventory[i].Name} | 방어력 +{inventory[i].Def} |  체력 +{inventory[i].Hp} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0) Console.WriteLine($"- {i + 1} {inventory[i].Name} | 방어력 +{inventory[i].Def} | {inventory[i].Description}");
                    else if (inventory[i].Hp > 0) Console.WriteLine($"- {i + 1} {inventory[i].Name} |  체 력 +{inventory[i].Hp} | {inventory[i].Description}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int input = CheckValidInput(0, inventory.Count);
            switch (input)
            {
                case 0:
                    DisplayInventory();
                    break;
                default:
                    if (inventory[input - 1].Equipped == 0) inventory[input - 1].Equipped += 1;
                    else inventory[input - 1].Equipped -= 1;
                    Displayitems();
                    break;
                        
            }
            
        }

        static void DisplayShop()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[상점]\n");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < shop.Count; i++)
            {
                if (shop[i].Purchased == 1)
                {
                    if (shop[i].Atk > 0) Console.WriteLine($"- {shop[i].Name} | 공격력 +{shop[i].Atk} | {shop[i].Description} | {shop[i].Price} G");
                    else if (shop[i].Def > 0 && shop[i].Hp > 0) Console.WriteLine($"- {shop[i].Name} | 방어력 +{shop[i].Def} |  체력 +{shop[i].Hp} | {shop[i].Description}");
                    else if (shop[i].Def > 0) Console.WriteLine($"- {shop[i].Name} | 방어력 +{shop[i].Def} | {shop[i].Description} | {shop[i].Price} G");
                    else if (shop[i].Hp > 0) Console.WriteLine($"- {shop[i].Name} |  체 력 +{shop[i].Hp} | {shop[i].Description} | {shop[i].Price} G");
                }
                else
                {
                    if (shop[i].Atk > 0) Console.WriteLine($"- {shop[i].Name} | 공격력 +{shop[i].Atk} | {shop[i].Description} | 구매완료");
                    else if (shop[i].Def > 0 && shop[i].Hp > 0) Console.WriteLine($"- {shop[i].Name} | 방어력 +{shop[i].Def} |  체력 +{shop[i].Hp} | {shop[i].Description} | 구매완료");
                    else if (shop[i].Def > 0) Console.WriteLine($"- {shop[i].Name} | 방어력 +{shop[i].Def} | {shop[i].Description} | 구매완료");
                    else if (shop[i].Hp > 0) Console.WriteLine($"- {shop[i].Name} | 체 력 +{shop[i].Hp} | {shop[i].Description} | 구매완료");
                }
            }

            Console.WriteLine();
            Console.WriteLine("1. 구매");
            Console.WriteLine("2. 판매");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    DisplayShopPurchasing();
                    break;
                case 2:
                    DisplayShopSelling();
                    break;
            }
        }


        static void DisplayShopPurchasing()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점 - 아이템 구매\n");
            Console.ResetColor();
            Console.WriteLine("아이템을 구매할 수 있습니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < shop.Count; i++)
            {
                if (shop[i].Purchased == 1)
                {
                    if (shop[i].Atk > 0) Console.WriteLine($"- {i + 1} {shop[i].Name} | 공격력 +{shop[i].Atk} | {shop[i].Description} | {shop[i].Price} G");
                    else if (shop[i].Def > 0 && shop[i].Hp > 0) Console.WriteLine($"- {i + 1} {shop[i].Name} | 방어력 +{shop[i].Def} |  체력 +{shop[i].Hp} | {shop[i].Price}");
                    else if (shop[i].Def > 0) Console.WriteLine($"- {i + 1} {shop[i].Name} | 방어력 +{shop[i].Def} | {shop[i].Description} | {shop[i].Price} G");
                    else if (shop[i].Hp > 0) Console.WriteLine($"- {i + 1} {shop[i].Name} |  체 력 +{shop[i].Hp} | {shop[i].Description} | {shop[i].Price} G");
                }
                else
                {
                    if (shop[i].Atk > 0) Console.WriteLine($"- {i + 1} {shop[i].Name} | 공격력 +{shop[i].Atk} | {shop[i].Description} | 구매완료");
                    else if (shop[i].Def > 0 && shop[i].Hp > 0) Console.WriteLine($"- {i + 1} {shop[i].Name} | 방어력 +{shop[i].Def} |  체력 +{shop[i].Hp} | 구매완료");
                    else if (shop[i].Def > 0) Console.WriteLine($"- {i + 1} {shop[i].Name} | 방어력 +{shop[i].Def} | {shop[i].Description} | 구매완료");
                    else if (shop[i].Hp > 0) Console.WriteLine($"- {i + 1} {shop[i].Name} | 체 력 +{shop[i].Hp} | {shop[i].Description} | 구매완료");
                }
            }


            Console.WriteLine();
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int input = CheckValidInput(0, shop.Count);
            switch (input)
            {
                case 0:
                    DisplayShop();
                    break;
                default:
                    if (shop[input - 1].Purchased == 0)
                    {
                        Console.WriteLine($"{shop[input - 1].Name} 은(는) 이미 구매한 품목입니다.");
                        Thread.Sleep(600);
                        DisplayShopPurchasing();
                    }
                    else if (player.Gold >= shop[input - 1].Price)
                    {
                        inventory.Add(shop[input - 1]);
                        player.Gold -= shop[input - 1].Price;
                        shop[input - 1].Purchased -= 1;
                        Console.WriteLine($"{shop[input - 1].Name} 을(를) 구매하였습니다.");
                        Thread.Sleep(300);
                        DisplayShopPurchasing();
                    }
                    else
                    {
                        Console.WriteLine($"{shop[input - 1].Price - player.Gold} Gold 부족합니다.");
                        Thread.Sleep(600);
                        DisplayShopPurchasing();
                    }
                    break;
            }
        }


        static void DisplayShopSelling()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점 - 아이템 판매\n");
            Console.ResetColor();
            Console.WriteLine("보유중인 아이템을 판매할 수 있습니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Equipped == 1)
                {
                    if (inventory[i].Atk > 0) Console.WriteLine($"- {i + 1} [E]{inventory[i].Name} | 공격력 +{inventory[i].Atk} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0 && inventory[i].Hp > 0) Console.WriteLine($"- {i + 1} [E]{inventory[i].Name} | 방어력 +{shop[i].Def} |  체력 +{shop[i].Hp} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0) Console.WriteLine($"- {i + 1} [E]{inventory[i].Name} | 방어력 +{inventory[i].Def} | {inventory[i].Description}");
                    else if (inventory[i].Hp > 0) Console.WriteLine($"- {i + 1} [E]{inventory[i].Name} |  체력 +{inventory[i].Hp} | {inventory[i].Description}");
                }
                else
                {
                    if (inventory[i].Atk > 0) Console.WriteLine($"- {i + 1} {inventory[i].Name} | 공격력 +{inventory[i].Atk} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0 && inventory[i].Hp > 0) Console.WriteLine($"- {i + 1} {inventory[i].Name} | 방어력 +{shop[i].Def} |  체력 +{shop[i].Hp} | {inventory[i].Description}");
                    else if (inventory[i].Def > 0) Console.WriteLine($"- {i + 1} {inventory[i].Name} | 방어력 +{inventory[i].Def} | {inventory[i].Description}");
                    else if (inventory[i].Hp > 0) Console.WriteLine($"- {i + 1} {inventory[i].Name} |  체 력 +{inventory[i].Hp} | {inventory[i].Description}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int input = CheckValidInput(0, inventory.Count);
            switch (input)
            {
                case 0:
                    DisplayShop();
                    break;
                default:
                    if (inventory[input - 1].Equipped == 0)
                    {
                        for (int i = 0; i < shop.Count; i++)
                        {
                            if (inventory[input - 1].Name == shop[i].Name)
                            {
                                shop[i].Purchased += 1;
                            }
                        }
                        float temp = inventory[input - 1].Price * 0.85f;
                        Console.WriteLine($"{inventory[input - 1].Name} 을(를) 판매하여 {temp} G를 얻었습니다.");
                        player.Gold += inventory[input - 1].Price * 0.85f;
                        inventory.RemoveAt(input - 1);
                        Thread.Sleep(600);
                        DisplayShopSelling();
                    }
                    else
                    {
                        Console.WriteLine("장착중인 장비는 판매할 수 없습니다.");
                        Thread.Sleep(600);
                        DisplayShopSelling();
                    }
                    break;
            }
        }

        static void DisplaySaveLoad()
        {
            Console.WriteLine("구현중.. 이전메뉴로 돌아갑니다");
            Thread.Sleep(1000);
            DisplayGameIntro();
        }





        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();
                bool parsed = int.TryParse(input, out var ret);

                if (parsed)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }


    }

    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public float Gold { get; set; }
        public string? WeaponEquipe { get; set; }
        public string? ArmorEquipe { get; set; }
        public string? KeyEquipe { get; set; }

        public Character(string name, string job, int level, int atk, int def, int hp, float gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }

    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public int Category { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public float Price { get; }
        public int Purchased { get; set; }
        public int Equipped { get; set; }
        

        public Item(string name, string description, int category, int atk, int def, int hp, float price)
        {
            Name = name;
            Description = description;
            Category = category;
            Atk = atk;
            Def = def;
            Hp = hp;
            Price = price;
            Purchased = 1;
            Equipped = 0;
        }
    }
}
