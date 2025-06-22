using NUnit.Framework;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private GildedRose app;

        [Test]
        public void Should_Reduce_SellIn_Value()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 5 } };
            app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void Should_Reduce_Quality_Value()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 5 } };
            app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(4));
        }
        
        [Test]
        public void Should_Reduce_Quality_Twice_As_Fast_After_SellByDate()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 5 } };
            app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(3));
        }

        [Test]
        public void Should_Not_Reduce_Quality_Below_0()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }
        
        [Test]
        public void Should_Increase_Quality_Of_AgedBrie()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 5 } };
            app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(6));
        }
        
        [Test]
        public void Should_Not_Increase_Quality_Above_50()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(50));
        }
        
        [Test]
        public void Should_Not_Change_Sulfuras_Quality_Or_SellIn()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].SellIn, Is.EqualTo(10));
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }
        
        [Test]
        public void Should_Increase_Backstage_Quality_By_1_When_SellIn_GT_10()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5 } };
            app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Quality, Is.EqualTo(6));
        }
    }
}
