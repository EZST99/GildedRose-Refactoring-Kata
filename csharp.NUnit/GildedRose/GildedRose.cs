using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        UpdateAgedBrie(item);
                        break;

                    case "Sulfuras, Hand of Ragnaros":
                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePass(item);
                        break;

                    default:
                        UpdateNormalItem(item);
                        break;
                }
            }
        }

        private void UpdateNormalItem(Item item)
        {
            DecreaseSellIn(item);

            if (item.Quality > 0)
                item.Quality--;

            if (item.SellIn < 0 && item.Quality > 0)
                item.Quality--;
        }

        private void UpdateAgedBrie(Item item)
        {
            DecreaseSellIn(item);

            if (item.Quality < 50)
                item.Quality++;

            if (item.SellIn < 0 && item.Quality < 50)
                item.Quality++;
        }

        private void UpdateBackstagePass(Item item)
        {
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            if (item.Quality < 50)
                item.Quality++;

            if (item.SellIn < 10 && item.Quality < 50)
                item.Quality++;

            if (item.SellIn < 5 && item.Quality < 50)
                item.Quality++;
        }

        private void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}