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
    }
}
