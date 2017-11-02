using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatfishCove.Web.Models;

namespace CatfishCove.Web.Data
{
    public class Seeder : ISeeder
    {
        private readonly CatfishCoveDbContext _dbContext;

        public Seeder(CatfishCoveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (!_dbContext.FoodTypes.Any())
            {
                var foodItems = new List<FoodType>
                {
                    new FoodType {Name = "Poultry", MenuOrder = 3},
                    new FoodType {Name = "Fish", MenuOrder = 0},
                    new FoodType {Name = "Vegetable", MenuOrder = null},
                    new FoodType {Name = "Starch", MenuOrder = null},
                    new FoodType {Name = "Beef", MenuOrder = null},
                    new FoodType {Name = "Bread", MenuOrder = null},
                    new FoodType {Name = "Pork", MenuOrder = null},
                    new FoodType {Name = "Casserole", MenuOrder = null},
                    new FoodType {Name = "Beans", MenuOrder = null},
                    new FoodType {Name = "Corn", MenuOrder = null},
                    new FoodType {Name = "Buffet Meat", MenuOrder = null},
                    new FoodType {Name = "Shell Fish", MenuOrder = 1},
                    new FoodType {Name = "All You Can Eat Specials", MenuOrder = 4},
                    new FoodType {Name = "Combinations", MenuOrder = 5},
                    new FoodType {Name = "Catfish Cove's Seafood Platter", MenuOrder = 5},
                    new FoodType {Name = "Land Lubbers", MenuOrder = 2},
                    new FoodType {Name = "Side Orders", MenuOrder = 7},
                    new FoodType {Name = "Children and Senior Citizen's Plates", MenuOrder = 6}
                };
                _dbContext.FoodTypes.AddRange(foodItems);
                _dbContext.SaveChanges();

                var poultry = _dbContext.FoodTypes.First(ft => ft.Name == "Poultry");
                var vegetable = _dbContext.FoodTypes.First(ft => ft.Name == "Vegetable");
                var starch = _dbContext.FoodTypes.First(ft => ft.Name == "Starch");
                var beef = _dbContext.FoodTypes.First(ft => ft.Name == "Beef");
                var bread = _dbContext.FoodTypes.First(ft => ft.Name == "Bread");
                var buffetMeat = _dbContext.FoodTypes.First(ft => ft.Name == "Buffet Meat");
                var casserole = _dbContext.FoodTypes.First(ft => ft.Name == "Casserole");
                var corn = _dbContext.FoodTypes.First(ft => ft.Name == "Corn");
                var beans = _dbContext.FoodTypes.First(ft => ft.Name == "Beans");
                var fish = _dbContext.FoodTypes.First(ft => ft.Name == "Fish");
                var shellFish = _dbContext.FoodTypes.First(ft => ft.Name == "Shell Fish");
                var landLubbers = _dbContext.FoodTypes.First(ft => ft.Name == "Land Lubbers");
                var allYouCanEatSpecials = _dbContext.FoodTypes.First(ft => ft.Name == "All You Can Eat Specials");
                var seafood = _dbContext.FoodTypes.First(ft => ft.Name == "Catfish Cove's Seafood Platter");
                var combos = _dbContext.FoodTypes.First(ft => ft.Name == "Combinations");
                var childOrders = _dbContext.FoodTypes.First(ft => ft.Name == "Children and Senior Citizen's Plates");
                var sideOrders = _dbContext.FoodTypes.First(ft => ft.Name == "Side Orders");

                var buffetItems = new List<BuffetItem>
                {
                    new BuffetItem { FoodType = poultry, Description = "Deep Fried Chicken Breasts, Wings, Legs, and Thighs", Name = "Fried Chicken", RotationFrequency = 0 },
                    new BuffetItem { FoodType = poultry, Description = "Oven baked chicken breasts in cream of mushroom gravy", Name = "Baked Chicken", RotationFrequency = 0 },
                    new BuffetItem { FoodType = vegetable, Description = "Super good traditional mashed potatoes", Name = "Mashed Potatoes", RotationFrequency = 0 },
                    new BuffetItem { FoodType = starch, Description = "Classic white rice with butter", Name = "White Rice", RotationFrequency = 0 },
                    new BuffetItem { FoodType = beef, Description = "Deep Fried cube steak, tenderized in brown gravy.", Name = "Country Style Steak", RotationFrequency = 0 },
                    new BuffetItem { FoodType = vegetable, Description = "Traditional homemade green beans.", Name = "Green Beans", RotationFrequency = 0 },
                    new BuffetItem { FoodType = starch, Description = "Southern baked macaroni and cheese.", Name = "Macaroni and Cheese", RotationFrequency = 0 },
                    new BuffetItem { FoodType = vegetable, Description = "Sweet potatoes with a thin layer of brown sugar and pecan topping", Name = "Sweet Potato Casserole", RotationFrequency = 0 },
                    new BuffetItem { FoodType = vegetable, Description = "Deep fried, thinnly sliced, and hand breaded squash", Name = "Fried Squash", RotationFrequency = 0 },
                    new BuffetItem { FoodType = vegetable, Description = "Deep fried breaded okra pieces", Name = "Fried Okra", RotationFrequency = 0 },
                    new BuffetItem { FoodType = bread, Description = "Thick soft buttered southern style biscuits.", Name = "Biscuits", RotationFrequency = 0 },
                    new BuffetItem { FoodType = bread, Description = "The good stuff", Name = "Cornbread", RotationFrequency = 0 },
                    new BuffetItem { FoodType = buffetMeat, Description = "Deep Fried Pork Tenderloin", Name = "Pork Chops", RotationFrequency = 1 },
                    new BuffetItem { FoodType = casserole, Description = "", Name = "Chicken Casserole", RotationFrequency = 1 },
                    new BuffetItem { FoodType = corn, Description = "", Name = "Corn on the Cob", RotationFrequency = 1 },
                    new BuffetItem { FoodType = beans, Description = "", Name = "Pinto Beans", RotationFrequency = 2 },
                    new BuffetItem { FoodType = buffetMeat, Description = "", Name = "Meat Loaf", RotationFrequency = 3 },
                    new BuffetItem { FoodType = casserole, Description = "", Name = "Brocolli Casserole", RotationFrequency = 1 },
                    new BuffetItem { FoodType = corn, Description = "", Name = "Shoepeg Corn", RotationFrequency = 1 },
                    new BuffetItem { FoodType = beans, Description = "", Name = "Lima Beans", RotationFrequency = 2 },
                    new BuffetItem { FoodType = beans, Description = "", Name = "Black Eyed Peas", RotationFrequency = 2 },
                    new BuffetItem { FoodType = buffetMeat, Description = "", Name = "Baked Ham", RotationFrequency = 3 },
                    new BuffetItem { FoodType = casserole, Description = "", Name = "Collards", RotationFrequency = 99 },
                    new BuffetItem { FoodType = beans, Description = "Southern Style Pintos", Name = "Pinto Beans", RotationFrequency = 0 },
                    new BuffetItem { FoodType = buffetMeat, Description = "", Name = "Closed", RotationFrequency = 99 },
                    new BuffetItem { FoodType = beans, Description = "", Name = "Closed", RotationFrequency = 99 },
                    new BuffetItem { FoodType = corn, Description = "", Name = "Closed", RotationFrequency = 99 },
                    new BuffetItem { FoodType = casserole, Description = "", Name = "Closed", RotationFrequency = 99 }
                };

                _dbContext.BuffetItems.AddRange(buffetItems);
                _dbContext.SaveChanges();

                BuffetItemSchedule item1 = new BuffetItemSchedule
                {
                    FoodType = buffetMeat,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Pork Chops")
                };

                BuffetItemSchedule item2 = new BuffetItemSchedule
                {
                    FoodType = buffetMeat,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Meat Loaf")
                };

                BuffetItemSchedule item3 = new BuffetItemSchedule
                {
                    FoodType = buffetMeat,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Pork Chops")
                };

                BuffetItemSchedule item4 = new BuffetItemSchedule
                {
                    FoodType = buffetMeat,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Baked Ham")
                };

                BuffetItemSchedule item5 = new BuffetItemSchedule
                {
                    FoodType = corn,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Corn On the Cob")
                };

                BuffetItemSchedule item6 = new BuffetItemSchedule
                {
                    FoodType = corn,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Shoepeg Corn")
                };

                BuffetItemSchedule item7 = new BuffetItemSchedule
                {
                    FoodType = casserole,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Brocolli Casserole")
                };

                BuffetItemSchedule item8 = new BuffetItemSchedule
                {
                    FoodType = casserole,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Chicken Casserole")
                };

                BuffetItemSchedule item9 = new BuffetItemSchedule
                {
                    FoodType = beans,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Lima Beans")
                };

                BuffetItemSchedule item10 = new BuffetItemSchedule
                {
                    FoodType = beans,
                    BuffetItem = _dbContext.BuffetItems.First(bi => bi.Name == "Black Eyed Peas")
                };

                _dbContext.BuffetSchedules.AddRange(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10);
                _dbContext.SaveChanges();

                item1.NextItem = item2;
                item2.NextItem = item3;
                item3.NextItem = item4;
                item4.NextItem = item1;

                item5.NextItem = item6;
                item6.NextItem = item5;

                item7.NextItem = item8;
                item8.NextItem = item7;

                item9.NextItem = item10;
                item10.NextItem = item9;

                _dbContext.SaveChanges();

                BuffetRotatingWeek firstWeek = new BuffetRotatingWeek();

                var today = DateTime.Today.DayOfWeek;

                firstWeek.SundayDate = DateTime.Today.AddDays(7 - today.GetHashCode());
                firstWeek.Meat = item1;
                firstWeek.Casserole = item7;
                firstWeek.Corn = item5;
                firstWeek.Beans = item9;

                _dbContext.BuffetRotatingWeeks.Add(firstWeek);
                _dbContext.SaveChanges();

                
                var menuItems = new List<MenuItem>
                {
                    new MenuItem { Name = "Catfish", HalfOrderPrice = "9.25", WholeOrderPrice = "11.75", FoodType = fish },
                    new MenuItem { Name = "Catfish Fillet", HalfOrderPrice = "9.75", WholeOrderPrice = "12.25", FoodType = fish },
                    new MenuItem { Name = "Flounder Filet", HalfOrderPrice = "10.25", WholeOrderPrice = "12.95", FoodType = fish },
                    new MenuItem { Name = "Whole Flounder", HalfOrderPrice = "Market Price", WholeOrderPrice = "Market Price", FoodType = fish },
                    new MenuItem { Name = "Perch", HalfOrderPrice = "8.95", WholeOrderPrice = "11.75", FoodType = fish },
                    new MenuItem { Name = "Mahi Mahi", WholeOrderPrice = "10.50", FoodType = fish },
                    new MenuItem { Name = "Tuna", HalfOrderPrice = "11.75", WholeOrderPrice = "13.75", FoodType = fish },
                    new MenuItem { Name = "Salmon", HalfOrderPrice = "11.75", WholeOrderPrice = "13.75", FoodType = fish },
                    new MenuItem { Name = "Calabash Shrimp", HalfOrderPrice = "11.50", WholeOrderPrice = "13.50", FoodType = shellFish },
                    new MenuItem { Name = "Oysters", HalfOrderPrice = "13.50", WholeOrderPrice = "15.50", FoodType = shellFish },
                    new MenuItem { Name = "Scallops", HalfOrderPrice = "13.50", WholeOrderPrice = "15.50", FoodType = shellFish },
                    new MenuItem { Name = "Jumbo Shrimp", HalfOrderPrice = "14.75", WholeOrderPrice = "17.75", FoodType = shellFish },
                    new MenuItem { Name = "Green Shrimp", HalfOrderPrice = "13.50", WholeOrderPrice = "15.50", FoodType = shellFish },
                    new MenuItem { Name = "Boiled Shrimp", HalfOrderPrice = "13.50", WholeOrderPrice = "15.50", FoodType = shellFish },
                    new MenuItem { Name = "Snow Crab Legs", HalfOrderPrice = "2lb 19.95", WholeOrderPrice = "All You Can Eat 34.95", FoodType = shellFish },
                    new MenuItem { Name = "Deviled Crab", HalfOrderPrice = "9.00", WholeOrderPrice = "11.25", FoodType = shellFish },
                    new MenuItem { Name = "Fantail Shrimp", HalfOrderPrice = "13.50", WholeOrderPrice = "15.50", FoodType = shellFish },
                    new MenuItem { Name = "Clam Strips", HalfOrderPrice = "9.00", WholeOrderPrice = "11.25", FoodType = shellFish },
                    new MenuItem { Name = "Shrimp Salad (fried or boiled)", WholeOrderPrice = "9.75", FoodType = shellFish },
                    new MenuItem { Name = "Hamberger Steak", HalfOrderPrice = "7.50", WholeOrderPrice = "9.75", FoodType = landLubbers },
                    new MenuItem { Name = "Pork Chops", HalfOrderPrice = "7.95", WholeOrderPrice = "7.95", FoodType = landLubbers, Description = "fried or grilled"},
                    new MenuItem { Name = "Hot-n-Spicy Chicken Wings", HalfOrderPrice = "9.00", WholeOrderPrice = "11.25", FoodType = poultry },
                    new MenuItem { Name = "Fried or Grilled Chickens", HalfOrderPrice = "9.00", WholeOrderPrice = "11.25", FoodType = poultry },
                    new MenuItem { Name = "Chicken Livers", HalfOrderPrice = "9.00", WholeOrderPrice = "11.25", FoodType = poultry },
                    new MenuItem { Name = "Chicken Nuggets", HalfOrderPrice = "9.00", WholeOrderPrice = "11.25", FoodType = poultry },
                    new MenuItem { Name = "Chicken Tenders", HalfOrderPrice = "9.00", WholeOrderPrice = "11.25", FoodType = poultry },
                    new MenuItem { Name = "Calabash Chicken Tenders", HalfOrderPrice = "9.00", WholeOrderPrice = "11.25", FoodType = poultry },
                    new MenuItem { Name = "Chicken Salad", WholeOrderPrice = "9.00", FoodType = poultry },
                    new MenuItem { Name = "Special No. 1", WholeOrderPrice = "14.25", FoodType = allYouCanEatSpecials, Description = "Calabash Shrimp, Deviled Crab, Fillet Flounder"},
                    new MenuItem { Name = "Special No. 2", WholeOrderPrice = "14.25", FoodType = allYouCanEatSpecials, Description = "Calabash Shrimp, Deviled Crab, Perch"},
                    new MenuItem { Name = "Special No. 3", WholeOrderPrice = "14.25", FoodType = allYouCanEatSpecials, Description = "Catfish, Calabash Shrimp, Clam Strips, Deviled Crab"},
                    new MenuItem { Name = "Platter", WholeOrderPrice = "16.50", FoodType = seafood, Description = "Shrimp, Oysters, Deviled Crab, Flounder Fillet, Perch and Catfish"},
                    new MenuItem { Name = "Platter", WholeOrderPrice = "16.50", FoodType = combos, Description = "Combo of 3 to 5 items"},
                    new MenuItem { Name = "Premium Item Platter", WholeOrderPrice = "Add 4.00 to Combo", FoodType = combos, Description = "For Whole Flounder, Jumbo Shrimp, Salmon, or Tuna on combination platters"},
                    new MenuItem { Name = "Small Portion or Children's Plate", WholeOrderPrice = "6.00 - TOGO", FoodType = childOrders, Description = "Menu Items Except: Whole Flounder, Jumbo Shrimp and Crab Legs"},
                    new MenuItem { Name = "Small Portion or Children's Plate", WholeOrderPrice = "6.50", FoodType = childOrders, Description = "Shrimp, Oysters, or Scallops"},
                    new MenuItem { Name = "Senior Citzen's Plate", WholeOrderPrice = "6.95", FoodType = childOrders, Description = "Menu Items Except: Whole Flounder, Jumbo Shrimp and Crab Legs"},
                    new MenuItem { Name = "Senior Citzen's Plate", WholeOrderPrice = "7.95", FoodType = childOrders, Description = "Shrimp, Oysters, or Scallops"},
                    new MenuItem { Name = "Senior Citzen's Plate", WholeOrderPrice = "7.95", FoodType = childOrders, Description = "Shrimp, Oysters, or Scallops"},
                    new MenuItem { Name = "Children Under 6 Plate (Dine-In Only)", WholeOrderPrice = "1.95", FoodType = childOrders, Description = "Perch, Flounder Fillet, Calabash Shrimp, Chicken Nuggets or Chicken Tenders"},
                    new MenuItem { Name = "Grilled Cheese Sandwich", WholeOrderPrice = "4.25", FoodType = childOrders, Description = "With Fries"},
                    new MenuItem { Name = "Shrimp Cocktail", WholeOrderPrice = "8.25", FoodType = sideOrders},
                    new MenuItem { Name = "Oyster Cocktail", WholeOrderPrice = "8.25", FoodType = sideOrders},
                    new MenuItem { Name = "Oyster Stew", WholeOrderPrice = "7.25", FoodType = sideOrders, Description = "Small"},
                    new MenuItem { Name = "Oyster Stew", WholeOrderPrice = "9.50", FoodType = sideOrders, Description = "Large"},
                    new MenuItem { Name = "Deviled Crab", WholeOrderPrice = "1.95", FoodType = sideOrders},
                    new MenuItem { Name = "Trimming Plate", WholeOrderPrice = "3.95", FoodType = sideOrders},
                    new MenuItem { Name = "Apple Sticks", WholeOrderPrice = "1.95", FoodType = sideOrders},
                    new MenuItem { Name = "French Fries", WholeOrderPrice = "1.95", FoodType = sideOrders},
                    new MenuItem { Name = "Broiled Fries", WholeOrderPrice = "1.95", FoodType = sideOrders},
                    new MenuItem { Name = "Salt & Pepper Fries", WholeOrderPrice = "1.95", FoodType = sideOrders},
                    new MenuItem { Name = "Baked Potato", WholeOrderPrice = "1.95", FoodType = sideOrders},
                    new MenuItem { Name = "Onion Rings", WholeOrderPrice = "1.95", FoodType = sideOrders},
                    new MenuItem { Name = "Hushpuppies", WholeOrderPrice = "1.95", FoodType = sideOrders},
                    new MenuItem { Name = "Tarter Sauce", WholeOrderPrice = "0.75", FoodType = sideOrders},
                    new MenuItem { Name = "Cocktail Sauce", WholeOrderPrice = "0.75", FoodType = sideOrders},
                    new MenuItem { Name = "Cole Slaw", WholeOrderPrice = "0.95", FoodType = sideOrders, Description = "Cup"},
                    new MenuItem { Name = "Cole Slaw", WholeOrderPrice = "2.00", FoodType = sideOrders, Description = "Pint"},
                    new MenuItem { Name = "Clam Chowder", WholeOrderPrice = "2.50", FoodType = sideOrders, Description = "Small"},
                    new MenuItem { Name = "Clam Chowder", WholeOrderPrice = "6.00", FoodType = sideOrders, Description = "Large"},
                    new MenuItem { Name = "2 Item", WholeOrderPrice = "Based on Selection", FoodType = combos, Description = "Whole Order 2 Item Combination"},
                    new MenuItem { Name = "2 Item", WholeOrderPrice = "Based on Selection", FoodType = combos, Description = "Half Order 2 Item Combination"}
                };

                _dbContext.MenuItems.AddRange(menuItems);
                _dbContext.SaveChanges();
            }
        }
    }
}
